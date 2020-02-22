using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.HumanResource;
using Micro.Objects.HumanResource;
using Micro.BusinessLayer.Administration;
using Micro.Framework.ReadXML;
using System.Web;
using Micro.Objects.Administration;
using System.Text;
using System.Data;

namespace Micro.WebApplication.MicroERP.HRMS
{
    /// <summary>
    /// View,Add,Edit & Delete Designation Details
    /// <author>
    /// Premananda Routray  && Subrat Swain
    /// </author>
    /// </summary>

    public partial class Designations : BasePage
    {
        #region Declaration
        protected static class PageVariable
        {
            //PageVariables modified on Dt:19/2/2013
            public static List<DesignationOfficewise> CurrentOfficeDesignations;
            public static string TheDesignationID
            {
                get
                {
                    string ThisDesignationID = HttpContext.Current.Session["TheDesignationID"].ToString();
                    return ThisDesignationID;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheDesignationID", value);
                }
            }

            public static List<Designation> TheDesignationList
            {
                get
                {
                    List<Designation> DesignationList = HttpContext.Current.Session["TheDesignationList"] as List<Designation>;
                    return DesignationList;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheDesignationList", value);
                }
            }
        }
        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
            ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
            ctrl_Search.SearchWhat = MicroEnums.SearchForm.Designation.ToString();
            if (!IsPostBack && !IsCallback)
            {
                BindGridView();
                BindDropDownList();
                SetFormMessage();
                if (HasAddPermission() && IsDefaultModeAdd())
                {
                    multiView_DesignationDetails.SetActiveView(view_InputControls);
                    ResetBackColor(view_InputControls);
                }
                else
                {
                    BindGridView();
                    BasePage.ShowHidePagePermissions(gview_Designation, btn_AddDesignation, this.Page);
                    //multiView_DesignationDetails.SetActiveView(view_GridView);
                    tab_Designations_ActiveTabChanged(sender, e);
                }
            }
        }

        protected void tab_Designations_ActiveTabChanged(object sender, EventArgs e)
        {
            if (tab_Designations.ActiveTab == tab_DesignationAll)
            {
                multiView_DesignationDetails.SetActiveView(view_GridView);
            }
            else
            {
                Multiview_Desig.SetActiveView(view_GridViewDesig);
                BindGridViewOfficeDesignations();
            }
        }

        protected void btn_Top_Save_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            if (btn_Top_Save.Text == MicroEnums.DataOperation.Save.GetStringValue() && Btn_Save.Text == MicroEnums.DataOperation.Save.GetStringValue())
            {
                if (ValidateFormFields())
                {
                    ProcReturnValue = SaveDesignation();
                    dialog_Message.Show();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Designation", MicroEnums.DataOperation.AddNew);

                }
            }
            else
            {
                ProcReturnValue = UpdateRecord();
                dialog_Message.Show();
                lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Designation", MicroEnums.DataOperation.Edit);

            }
            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                BindGridView();
                BindGridViewOfficeDesignations();
                BindReportingTo();
                ResetPageFields();
            }
        }

        protected void btn_AddDesignation_Click(object sender, EventArgs e)
        {
            multiView_DesignationDetails.SetActiveView(view_InputControls);
            ResetPageFields();
            if (!(BasePage.HasAddPermission(this.Page)))
            {
                multiView_DesignationDetails.SetActiveView(view_GridView);
            }
        }

        protected void btn_ViewDesignationDetails_Click(object sender, EventArgs e)
        {
            multiView_DesignationDetails.SetActiveView(view_GridView);
            BindGridView();
            BasePage.ShowHidePagePermissions(gview_Designation, btn_AddDesignation, this.Page);
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
           
                ResetPageFields();
           

        }

        protected void gview_Designation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            PageVariable.TheDesignationID = ((Label)gview_Designation.Rows[RowIndex].FindControl("lbl_DesignationID")).Text;

            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {
                lbl_DataOperationMode.Text = String.Format("EDIT DESIGNATION : {0} [{1}]", gview_Designation.Rows[RowIndex].Cells[2].Text.ToUpper(), PageVariable.TheDesignationID);
                btn_Top_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Update.GetStringValue());
                Btn_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Update.GetStringValue());
                multiView_DesignationDetails.SetActiveView(view_InputControls);
                PopulatePageFields(int.Parse(PageVariable.TheDesignationID));
                EnableControls(view_InputControls, true);
                Btn_Save.Visible = true;
                btn_Top_Save.Visible = true;
                ChangeBackColor(view_InputControls);
            }

            else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
            {
                multiView_DesignationDetails.SetActiveView(view_InputControls);
                PopulatePageFields(int.Parse(PageVariable.TheDesignationID));
                lbl_DataOperationMode.Text = String.Format("VIEW DESIGNATION : {0} [{1}]", gview_Designation.Rows[RowIndex].Cells[2].Text.ToUpper(), PageVariable.TheDesignationID);
                EnableControls(view_InputControls, false);
                Btn_Save.Visible = false;
                btn_Top_Save.Visible = false;
            }
        }

        protected void gview_Designation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_Designation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ProcReturnValue = 0;
            Designation ObjDesignation = new Designation();
            ObjDesignation.DesignationID = int.Parse(PageVariable.TheDesignationID);
            ProcReturnValue = DesignationManagement.GetInstance.DeleteDesignation(ObjDesignation.DesignationID);

            dialog_Message.Show();
            lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Designation", MicroEnums.DataOperation.Delete);
            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                gview_Designation.EditIndex = -1;
                BindGridView();
            }

        }

        protected void gview_Designation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_Designation.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void gview_Designation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnDelete(e, 5);
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
                    BasePage.GridViewToolTips(e, 4, 5);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void searchCtrl_ButtonClicked(object sender, System.EventArgs e)
        {
            SearchDesignationBindGridView();
        }

        protected void chkSelectAll_Add_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkAll = (CheckBox)gview_DesignationSelect.HeaderRow.FindControl("chkSelectAll_Add");
            if (chkAll.Checked == true)
            {
                foreach (GridViewRow gvRow in gview_DesignationSelect.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
                    chkSel.Checked = true;

                }
            }
            else
            {
                foreach (GridViewRow gvRow in gview_DesignationSelect.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
                    chkSel.Checked = false;

                }
            }
        }

        protected void gview_DesignationSelect_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_DesignationSelect.PageIndex = e.NewPageIndex;
            BindGridViewOfficeDesignations();
        }

        protected void btn_Apply_Click(object sender, EventArgs e)
        {

            int result = (int)MicroEnums.DataOperationResult.Failure;

            DesignationOfficewise ObjDesg = new DesignationOfficewise();
            List<DesignationOfficewise> thisDesignationOfficewiseList = new List<DesignationOfficewise>();
            foreach (GridViewRow therow in gview_DesignationSelect.Rows)
            {

                DesignationOfficewise thisDesignationOfficewise = new DesignationOfficewise();
                CheckBox chkb = (CheckBox)therow.FindControl("chk_Add");
                Label theOfficelabel = (Label)therow.FindControl("lbl_DesignationOfficeId");

                if (int.Parse(theOfficelabel.Text) == 0)
                {
                    if (chkb.Checked)
                    {
                        ObjDesg.DesignationID = int.Parse(therow.Cells[2].Text);

                        result = DesignationOfficewiseManagement.GetInstance.InsertDesignationOfficewise(ObjDesg);
                        lbl_TheMessage.Text = GetDataOperationResult(result, "Designation", MicroEnums.DataOperation.AddNew);

                    }
                }
                else if (int.Parse(theOfficelabel.Text) != 0)
                {
                    ObjDesg.DesignationID = int.Parse(therow.Cells[2].Text);
                    if (!chkb.Checked)
                    {
                        ObjDesg.IsActive = false;
                    }
                    else
                    {
                        ObjDesg.IsActive = true;
                    }
                    ObjDesg.DesignationOfficewiseID = int.Parse(theOfficelabel.Text);

                    result = DesignationOfficewiseManagement.GetInstance.UpdateDesignationOfficewise(ObjDesg);
                    lbl_TheMessage.Text = GetDataOperationResult(result, "Designation", MicroEnums.DataOperation.Edit);
                }
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
        }


        #endregion

        #region Methods & Implemenation

        private void BindGridView()
        {
            gview_Designation.DataSource = null;
            gview_Designation.DataBind();
            PageVariable.TheDesignationList = DesignationManagement.GetInstance.GetDesignationsList();
            gview_Designation.DataSource = PageVariable.TheDesignationList;
            gview_Designation.DataBind();

            gview_DesignationSelect.DataSource = PageVariable.TheDesignationList;
            gview_DesignationSelect.DataBind();

        }

        private int SaveDesignation()
        {
            int ProcReturnValue = 0;
            Designation theDesignation = new Designation();
            theDesignation.DesignationDescription = txt_Designation.Text.ToString();
            theDesignation.RoleID = int.Parse(ddl_RoleDescription.SelectedValue);
            theDesignation.ReportingToDesignationID = int.Parse(ddl_ReportingTo.SelectedValue);
            ProcReturnValue = DesignationManagement.GetInstance.InsertDesignation(theDesignation);
            return ProcReturnValue;
        }

        private void BindDropDownList()
        {
            BindRole();
            BindReportingTo();

            //ddl_ReportingTo.DataValueField=DesignationManagement.GetInstance
        }

        private void BindRole()
        {
            ddl_RoleDescription.DataSource = RolesManagement.GetInstance.GetRolesList();
            ddl_RoleDescription.DataTextField = RolesManagement.GetInstance.DisplayMember;
            ddl_RoleDescription.DataValueField = RolesManagement.GetInstance.ValueMember;
            ddl_RoleDescription.DataBind();
            ddl_RoleDescription.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        private void BindReportingTo()
        {
            ddl_ReportingTo.DataSource = DesignationManagement.GetInstance.GetDesignationsList();
            ddl_ReportingTo.DataTextField = DesignationManagement.GetInstance.DisplayMember;
            ddl_ReportingTo.DataValueField = DesignationManagement.GetInstance.ValueMember;
            ddl_ReportingTo.DataBind();
            ddl_ReportingTo.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        private bool ValidateFormFields()
        {
            bool ReturnValue = true;
            if (txt_Designation.Text.Trim().Length <= 0)
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }

        private void PopulatePageFields(int theDesignationId)
        {
            Designation theDesignation = DesignationManagement.GetInstance.GetDesignationById(theDesignationId);
            txt_Designation.Text = theDesignation.DesignationDescription;

            ddl_RoleDescription.SelectedIndex = GetSelectedIndex(ddl_RoleDescription, theDesignation.RoleID);

            ddl_ReportingTo.SelectedIndex = GetSelectedIndex(ddl_ReportingTo, theDesignation.ReportingToDesignationID);

            ChangeBackColor(view_InputControls);
        }

        private int UpdateRecord()
        {
            Designation TheDesignation = new Designation();
            TheDesignation.DesignationID = int.Parse(PageVariable.TheDesignationID);
            TheDesignation.DesignationDescription = txt_Designation.Text;
            TheDesignation.RoleID = int.Parse(ddl_RoleDescription.SelectedValue);
            TheDesignation.ReportingToDesignationID = int.Parse(ddl_ReportingTo.SelectedValue);
            int ProcReturnValue = DesignationManagement.GetInstance.UpdateDesignation(TheDesignation);
            return ProcReturnValue;
        }

        private void SetFormMessage()
        {
            requiredFieldValidator_Designation.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Designation");
            RegularExpressionValidator_Designation.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
            RequiredFieldValidator_ddl_ReportingTo.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            RequiredFieldValidator_ddl_ReportingTo.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Reporting To");
            RequiredFieldValidator_RoleDescription.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            RequiredFieldValidator_RoleDescription.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Role");
            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_Designation.CssClass = theClassName;
            RegularExpressionValidator_Designation.CssClass = theClassName;
            RequiredFieldValidator_ddl_ReportingTo.CssClass = theClassName;
            RequiredFieldValidator_RoleDescription.CssClass = theClassName;
        }

        private void ResetPageFields()
        {
            txt_Designation.Text = string.Empty;
            ddl_RoleDescription.SelectedIndex = 0;
            ddl_ReportingTo.SelectedIndex = 0;
            btn_Top_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Save.GetStringValue());
            Btn_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Save.GetStringValue());
            lbl_DataOperationMode.Text = "ADD NEW DESIGNATION";
            ResetBackColor(view_InputControls);
            Btn_Save.Visible = true;
            btn_Top_Save.Visible = true;
            ResetBackColor(view_InputControls);
            EnableControls(view_InputControls, true);
            if (tab_Designations.ActiveTab ==tab_DesignationAll)
            {
                multiView_DesignationDetails.SetActiveView(view_InputControls);
            }
        }

        private int GetSelectedIndex(DropDownList ddl, int DesignationId)
        {
            int ReturnValue = 0;
            for (int ctr = 0; ddl.Items.Count > ctr; ctr++)
            {
                if (ddl.Items[ctr].Value == DesignationId.ToString())
                {
                    ReturnValue = ctr;
                    break;
                }
            }
            return ReturnValue;
        }

        private void SearchDesignationBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            List<Designation> SearchList = new List<Designation>();
            // Search by name
            if (PageVariable.TheDesignationList.Count > 0)
            {
                if (searchField == MicroEnums.SearchDesignation.DesignationDescription.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        SearchList = (from desgName in PageVariable.TheDesignationList
                                      where desgName.DesignationDescription.ToUpper().StartsWith(searchText.ToUpper())
                                      select desgName).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from desgName in PageVariable.TheDesignationList
                                      where desgName.DesignationDescription.ToUpper().Contains(searchText.ToUpper())
                                      select desgName).ToList();
                    }
                }
            }
            // Dispaly the search result
            ctrl_Search.SearchResultCount = SearchList.Count.ToString();
            gview_Designation.DataSource = SearchList;
            gview_Designation.DataBind();
        }

        private void BindSearchFields()
        {
            foreach (MicroEnums.SearchDesignation x in Enum.GetValues(typeof(MicroEnums.SearchDesignation)))
            {
                string xyz = x.ToString();
            }
        }

        public void BindGridViewOfficeDesignations()
        {
            List<Designation> AllDesignations = new List<Designation>();
            AllDesignations = DesignationManagement.GetInstance.GetDesignationsList();

            List<DesignationOfficewise> CurrentOfficeDesignations = new List<DesignationOfficewise>();
            CurrentOfficeDesignations = DesignationOfficewiseManagement.GetInstance.GetDesignationOfficewiseByOfficeID();

            gview_DesignationSelect.DataSource = AllDesignations;
            gview_DesignationSelect.DataBind();


            int counter = 0;
            if (CurrentOfficeDesignations.Count > 0)
            {
                foreach (DesignationOfficewise thedesignationofficewise in CurrentOfficeDesignations)
                {
                    counter++;
                    foreach (GridViewRow therow in gview_DesignationSelect.Rows)
                    {
                        Label thedesiglabel = (Label)therow.FindControl("lbl_DesignationId");
                        Label theOfficelabel = (Label)therow.FindControl("lbl_DesignationOfficeId");
                        CheckBox theCheckBox = (CheckBox)therow.FindControl("chk_Add");

                        if (thedesiglabel.Text.Equals(thedesignationofficewise.DesignationID.ToString()))
                        {
                            if (thedesignationofficewise.IsActive.Equals(true))
                                theCheckBox.Checked = true;
                            theOfficelabel.Text = thedesignationofficewise.DesignationOfficewiseID.ToString();

                            if (CurrentOfficeDesignations.Count > 1 && counter == CurrentOfficeDesignations.Count)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (counter == 1)
                            {
                                theOfficelabel.Text = "0";
                            }
                        }
                    }
                }
            }
            
            else
            {
                foreach (GridViewRow therow in gview_DesignationSelect.Rows)
                {
                    Label thedesiglabel = (Label)therow.FindControl("lbl_DesignationId");
                    Label theOfficelabel = (Label)therow.FindControl("lbl_DesignationOfficeId");
                    CheckBox theCheckBox = (CheckBox)therow.FindControl("chk_Add");

                    theOfficelabel.Text = "0";
                }

            }
             BasePage.HideGridViewColumn(gview_DesignationSelect, "DesignationOfficeID");
             BasePage.HideGridViewColumn(gview_DesignationSelect, "DesignationID");
        }

        private void FillOfficeDesignations(int officeID)
        {
            try
            {

                List<DesignationOfficewise> DesignationOfficewiseList = DesignationOfficewiseManagement.GetInstance.GetDesignationOfficewiseByOfficeID(officeID);
                List<DesignationOfficewise> BindDesignationItems = (from m in DesignationOfficewiseList
                                                                    where m.DesignationOfficewiseID != -1
                                                                    orderby m.DesignationOfficewiseID
                                                                    select m).ToList<DesignationOfficewise>();

                // Bind the GridView for the forms

                gview_DesignationSelect.DataSource = BindDesignationItems;
                gview_DesignationSelect.DataBind();




                CheckUncheckGridItems();

            }

            catch (Exception ex)
            {

            }
            //sbMenu.Append("</ul>");

        }

        private void CheckUncheckGridItems()
        {

            int OfficeID = ((User)Session["CurrentUser"]).OfficeID;
            List<DesignationOfficewise> TheDesignationByoffice = DesignationOfficewiseManagement.GetInstance.GetDesignationOfficewiseByOfficeID(OfficeID);

            foreach (GridViewRow gvRow in gview_DesignationSelect.Rows)
            {
                int TheOfficeID = ((User)Session["CurrentUser"]).OfficeID;
                CheckBox chkSelAdd = (CheckBox)gvRow.FindControl("chk_Add");


                Label lbl_DesignationId = (Label)gvRow.FindControl("lbl_DesignationId");

                int DesignationIdd = int.Parse(lbl_DesignationId.Text);

                chkSelAdd.Checked = WillSelectCheckBox(TheDesignationByoffice, DesignationIdd, BasePage.IsActive, TheOfficeID);
            }
        }

        private bool WillSelectCheckBox(List<DesignationOfficewise> TheDesignationByoffice, int designationIdd, bool IsActive, int theofficeid)
        {
            bool ReturnValue;
            var result = TheDesignationByoffice.Find
                        (mm =>
                            mm.OfficeID == theofficeid &&
                            mm.DesignationID == designationIdd &&
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

        protected void gview_DesignationSelect_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                   // string navUrl = e.Row.Cells[2].Text;
                    //e.Row.ForeColor = SetFormGridForeColor(navUrl);
                    //e.Row.BackColor = SetFormGridBackColor(navUrl);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
        }
    
    
    
    
    }
}