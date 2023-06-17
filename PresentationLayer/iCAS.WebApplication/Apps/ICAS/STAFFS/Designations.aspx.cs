using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.BusinessLayer.Administration;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS
{
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
            if (!IsPostBack && !IsCallback)
            {
                BindGridView();
                BindDropDownList();
                SetFormMessage();
                multiView_DesignationDetails.SetActiveView(view_InputControls);
                ResetBackColor(view_InputControls);
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
                BindReportingTo();
                ResetPageFields();
            }
        }

        protected void btn_AddDesignation_Click(object sender, EventArgs e)
        {
            multiView_DesignationDetails.SetActiveView(view_InputControls);
            ResetPageFields();
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

        #endregion

        #region Methods & Implemenation

        private void BindGridView()
        {
            gview_Designation.DataSource = null;
            gview_Designation.DataBind();
            PageVariable.TheDesignationList = DesignationManagement.GetInstance.GetDesignationsList();
            gview_Designation.DataSource = PageVariable.TheDesignationList;
            gview_Designation.DataBind();
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
        
        private void BindSearchFields()
        {
            foreach (MicroEnums.SearchDesignation x in Enum.GetValues(typeof(MicroEnums.SearchDesignation)))
            {
                string xyz = x.ToString();
            }
        }

        #endregion
      
    }
}