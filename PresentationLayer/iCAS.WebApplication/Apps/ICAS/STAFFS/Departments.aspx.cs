using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS
{
    public partial class Departments : BasePage
    {
        #region Declaration
        public MicroEnums.DataOperation DataOperationMode;
        protected static class PageVariables
        {
            //PageVariables modified on Dt:19/2/2013
            public static Department ThisDepartment
            {
                get
                {
                    Department TheDepartment = HttpContext.Current.Session["ThisDepartment"] as Department;
                    return TheDepartment;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisDepartment", value);
                }
            }

            public static List<Department> DepartmentList
            {
                get
                {
                    List<Department> TheDepartment = HttpContext.Current.Session["DepartmentList"] as List<Department>;
                    return TheDepartment;
                }
                set
                {
                    HttpContext.Current.Session.Add("DepartmentList", value);
                }
            }

        }
        #endregion
      
        #region Events
      
        protected void Page_Load(object sender, EventArgs e)
        {
            BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
            if (!IsPostBack && !IsCallback)
            {
                SetValidationMessages();
                ResetPageVariables();
                BindDropdown();
                BindGridView();
                multiView_DepartmentDetails.SetActiveView(view_GridView);
                BasePage.ShowHidePagePermissions(gview_Department, btn_AddDepartment, this.Page);
            }
        }

         


        protected void gview_Department_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_Department.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void gview_Department_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            int RecordID = int.Parse(((Label)gview_Department.Rows[RowIndex].FindControl("lbl_DepartmentID")).Text);
            lbl_DataOperationMode.Text = String.Format("EDIT DEPARTMENT : {0} [{1}]", gview_Department.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
            PageVariables.ThisDepartment = DepartmentManagement.GetInstance.GetDepartmentById(RecordID);

            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {
                btn_Top_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
                Btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();

                multiView_DepartmentDetails.SetActiveView(view_InputControls);
                EnableControls(view_InputControls, true);
                PopulatePageFields(PageVariables.ThisDepartment);
                ChangeBackColor(view_InputControls);
                Btn_Save.Visible = true;
                btn_Top_Save.Visible = true;
            }
            else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
            {
                int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                ProcReturnValue = DeleteRecord();
                lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Department", MicroEnums.DataOperation.Delete);
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    BindGridView();
                }

                dialog_Message.Show();
            }
            else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
            {
                multiView_DepartmentDetails.SetActiveView(view_InputControls);
                PopulatePageFields(PageVariables.ThisDepartment);
                lbl_DataOperationMode.Text = String.Format("VIEW DEPARTMENT : {0} [{1}]", gview_Department.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
                bool EnableFlag = false;
                EnableControls(view_InputControls, false);
                Btn_Save.Visible = EnableFlag;
                btn_Top_Save.Visible = EnableFlag;
                btn_Cancel.Visible = EnableFlag;

                btn_Cancel_Top.Visible = EnableFlag;
            }

        }

        protected void gview_Department_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnDelete(e, 6);
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
                    BasePage.GridViewToolTips(e, 5, 6);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        protected void gview_Department_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_Department_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;

        }

        private void searchCtrl_ButtonClicked(object sender, System.EventArgs e)
        {
            //SearchDepartmentBindGridView();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (ValidateFormFields())
            {
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = InsertRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Department", MicroEnums.DataOperation.AddNew);
                }
                else
                {
                    ProcReturnValue = UpdateRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Department", MicroEnums.DataOperation.Edit);
                }
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    BindGridView();
                    ResetTextBoxes();
                }
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
        }

        protected void btn_ViewDepartment_Click(object sender, EventArgs e)
        {
            BindGridView();
            BasePage.ShowHidePagePermissions(gview_Department, btn_AddDepartment, this.Page);
            multiView_DepartmentDetails.SetActiveView(view_GridView);
        }

        protected void btn_AddDepartment_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
            //BindDropdown_HOD();
            multiView_DepartmentDetails.SetActiveView(view_InputControls);


            //TODO: SUBRAT: Role Permission
            //if (!(BasePage.HasAddPermission(this.Page)))
            //{
            //    multiView_DepartmentDetails.SetActiveView(view_GridView);
            //}
        }
        

        


        #endregion

        #region Methods & Implementation

        private void SetValidationMessages()
        {
            requiredFieldValidator_DepartmentDescription.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "DepartmentsName");
            regularExpressionValidator_DepartmentDescription.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
            RequiredFieldValidator_ddl_ParentDepartment.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            RequiredFieldValidator_ddl_ParentDepartment.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "ParentDepartment");
            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_DepartmentDescription.CssClass = theClassName;
            regularExpressionValidator_DepartmentDescription.CssClass = theClassName;
            RequiredFieldValidator_ddl_ParentDepartment.CssClass = theClassName;
        }

        private void BindDropdown()
        {
            BindDropdown_ParentDepartment();

            BindDropdown_HOD();
        }

        private void BindDropdown_HOD()
        {
            List<Staff> staffs = StaffMasterManagement.GetInstance.GetStaffs();
            ddl_DeptHead.DataSource = staffs;
            ddl_DeptHead.DataTextField = StaffMasterManagement.GetInstance.DisplayMember;
            ddl_DeptHead.DataValueField = StaffMasterManagement.GetInstance.ValueMember;
            ddl_DeptHead.DataBind();
            ddl_DeptHead.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }
        private void BindDropdown_ParentDepartment()
        {
            ddl_ParentDepartment.DataSource = DepartmentManagement.GetInstance.GetDepartmentsList();
            ddl_ParentDepartment.DataTextField = DepartmentManagement.GetInstance.DisplayMember;
            ddl_ParentDepartment.DataValueField = DepartmentManagement.GetInstance.ValueMember;
            ddl_ParentDepartment.DataBind();
            ddl_ParentDepartment.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }

        private void BindGridView()
        {
            gview_Department.DataSource = null;
            gview_Department.DataBind();

            PageVariables.DepartmentList = DepartmentManagement.GetInstance.GetDepartmentsList();

            if (PageVariables.DepartmentList.Count > 0)
            {
                gview_Department.DataSource = PageVariables.DepartmentList;
                gview_Department.DataBind();
            }


        }
        //////TODO: SUBRAT: Due to Search Control
        //private void SearchDepartmentBindGridView()
        //{
        //    //////////////////////string searchText = ctrl_Search.SearchText;
        //    //////////////////////string searchOperator = ctrl_Search.SearchOperator;
        //    /////////////////////string searchField = ctrl_Search.SearchField;

        //    List<Department> SearchList = new List<Department>();
        //    // Search by name
        //    if (PageVariables.DepartmentList.Count > 0)
        //    {
        //        if (searchField == MicroEnums.SearchDepartment.DepartmentName.ToString())
        //        {
        //            if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
        //            {
        //                SearchList = (from depname in PageVariables.DepartmentList
        //                              where depname.DepartmentDescription.ToUpper().StartsWith(searchText.ToUpper())
        //                              select depname).ToList();
        //            }

        //            if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
        //            {
        //                SearchList = (from depname in PageVariables.DepartmentList
        //                              where depname.DepartmentDescription.ToUpper().Contains(searchText.ToUpper())
        //                              select depname).ToList();
        //            }
        //        }
        //    }

        //    // Dispaly the search result
        //   //////////////////////////// ctrl_Search.SearchResultCount = SearchList.Count.ToString();
        //    gview_Department.DataSource = SearchList;
        //    gview_Department.DataBind();
        //}

        private void BindSearchFields()
        {
            foreach (MicroEnums.SearchDepartment x in Enum.GetValues(typeof(MicroEnums.SearchDepartment)))
            {
                string xyz = x.ToString();
            }
        }

        private void PopulatePageFields(Department theDepartment)
        {
            //BindDropdown_HOD();
            txt_DepartmentDescription.Text = theDepartment.DepartmentDescription;
            txtContent1.Text = theDepartment.DepartmentContent1;
            txtContent2.Text = theDepartment.DepartmentContent2;
            txtContent3.Text = theDepartment.DepartmentContent3;
            ddl_DeptHead.SelectedIndex = GetDropDownSelectedIndex(ddl_DeptHead, Convert.ToString(theDepartment.DepartmentHeadId));
            ddl_ParentDepartment.SelectedIndex = GetDropDownSelectedIndex(ddl_ParentDepartment, Convert.ToString(theDepartment.ParentDepartmentId));
        }

        private bool ValidateFormFields()
        {
            bool ReturnValue = true;
            return ReturnValue;
        }

        private int InsertRecord()
        {
            int ProcReturnValue = 0;
            Department TheDepartments = new Department();

            TheDepartments.DepartmentDescription = txt_DepartmentDescription.Text;
            TheDepartments.DepartmentContent1 = txtContent1.Text;
            TheDepartments.DepartmentContent2 = txtContent2.Text;
            TheDepartments.DepartmentContent3 = txtContent3.Text;
            TheDepartments.DepartmentHeadId = int.Parse(ddl_DeptHead.SelectedValue);
            TheDepartments.ParentDepartmentId = int.Parse(ddl_ParentDepartment.SelectedValue);

            ProcReturnValue = DepartmentManagement.GetInstance.InsertDepartment(TheDepartments);

            return ProcReturnValue;
        }

        private void ResetTextBoxes()
        {
            ddl_ParentDepartment.SelectedIndex = 0;
            txt_DepartmentDescription.Text = string.Empty;
            txtContent1.Text = string.Empty;
            txtContent2.Text = string.Empty;
            txtContent3.Text = string.Empty;

            PageVariables.ThisDepartment = null;
            lbl_DataOperationMode.Text = "ADD NEW DEPARTMENT";
            Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();

            Btn_Save.Visible = true;
            btn_Top_Save.Visible = true;
            EnableControls(view_InputControls, true);
            ResetBackColor(view_InputControls);

            
        }

        private static void ResetPageVariables()
        {
            PageVariables.ThisDepartment = null;
            PageVariables.DepartmentList = null;
        }

        private int UpdateRecord()
        {
            PageVariables.ThisDepartment.DepartmentDescription = txt_DepartmentDescription.Text;
            PageVariables.ThisDepartment.ParentDepartmentId = int.Parse(ddl_ParentDepartment.SelectedValue);
            PageVariables.ThisDepartment.DepartmentContent1 = txtContent1.Text;
            PageVariables.ThisDepartment.DepartmentContent2 = txtContent2.Text;
            PageVariables.ThisDepartment.DepartmentContent3 = txtContent3.Text;
            PageVariables.ThisDepartment.DepartmentHeadId = int.Parse(ddl_DeptHead.SelectedValue);
            int ProcReturnValue = DepartmentManagement.GetInstance.UpdateDepartment(PageVariables.ThisDepartment);
            return ProcReturnValue;
        }

        public static int DeleteRecord()
        {
            int ProcReturnValue = DepartmentManagement.GetInstance.DeleteDepartment(PageVariables.ThisDepartment);
            return ProcReturnValue;
        }




        private void FillOfficeDesignations(int officeID)
        {
            try
            {

                List<DepartmentOfficewise> DepartmentOfficewiseList = DepartmentOfficewiseManagement.GetInstance.GetDepartmentOfficewiseByOfficeID(officeID);
                List<DepartmentOfficewise> BindDepartmentItems = (from m in DepartmentOfficewiseList
                                                                  where m.DepartmentOfficewiseID != -1
                                                                  orderby m.DepartmentOfficewiseID
                                                                  select m).ToList<DepartmentOfficewise>();

                // Bind the GridView for the forms
 

                //All checked ITEMS in GridView

            }

            catch (Exception ex)
            {

            }
        }



        private bool WillSelectCheckBox(List<DepartmentOfficewise> TheDepartmentByoffice, int departmentIdd, bool IsActive, int theofficeid)
        {
            bool ReturnValue;
            var result = TheDepartmentByoffice.Find
                        (mm =>
                            mm.OfficeID == theofficeid &&
                            mm.DepartmentID == departmentIdd &&
                            mm.IsActive == IsActive);

            if (result == null)
            {
                ReturnValue = false;
            }
            else
            {
                ReturnValue = true;
            }
            return ReturnValue;
        }

       
        #endregion
    }
}