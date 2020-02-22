using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.HumanResource;
using Micro.BusinessLayer.HumanResource;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;

namespace Micro.WebApplication.MicroERP.HRMS
{
    public partial class Shifts : BasePage
	{
        #region Declaration
        public MicroEnums.DataOperation DataOperationMode;
        protected static class PageVariables
        {
            //PageVariables modified on Dt:19/2/2013
            public static Shift ThisShift
            {
                get
                {
                    Shift TheShift = HttpContext.Current.Session["ThisShift"] as Shift;
                    return TheShift;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisShift", value);
                }
            }

            public static List<Shift> ShiftList
            {
                get
                {
                    List<Shift> TheShift = HttpContext.Current.Session["ShiftList"] as List<Shift>;
                    return TheShift;
                }
                set
                {
                    HttpContext.Current.Session.Add("ShiftList", value);
                }
            }

        }
        #endregion

        #region Events
	
        protected void Page_Load(object sender, EventArgs e)
		{
            BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
            ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
         
            if (!IsPostBack )
            {
                SetValidationMessages();
                ResetPageVariables();
                BindGridView();
               
                if (HasAddPermission() && IsDefaultModeAdd())
                {
                    multiView_ShiftDetails.SetActiveView(view_InputControls);
                    ResetBackColor(view_InputControls);
                }
                else
                {
                    
                    BindGridView();
                    tab_Shifts_ActiveTabChanged(sender, e);
                    BasePage.ShowHidePagePermissions(gview_Shift, btn_AddShift, this.Page);
                }
                ctrl_Search.SearchWhat = MicroEnums.SearchForm.Shift.ToString();
            }
		}
        
        protected void tab_Shifts_ActiveTabChanged(object sender, EventArgs e)
        {
            if (tab_Shifts.ActiveTab == tab_ShiftAll)
            {
                multiView_ShiftDetails.SetActiveView(view_GridView);
            }
            else
            {
                Multiview_Desig.SetActiveView(view_GridViewShift);
                BindGridViewOfficeShifts();
            }
        }


        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (ValidateFormFields())
            {
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = InsertRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Shift", MicroEnums.DataOperation.AddNew);
                }
                else
                {
                    ProcReturnValue = UpdateRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Shift", MicroEnums.DataOperation.Edit);
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

        protected void btn_AddShift_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
            multiView_ShiftDetails.SetActiveView(view_InputControls);
            if (!(BasePage.HasAddPermission(this.Page)))
            {
                multiView_ShiftDetails.SetActiveView(view_GridView);
            }
        }

        protected void btn_ViewShift_Click(object sender, EventArgs e)
        {
            BindGridView();
            BasePage.ShowHidePagePermissions(gview_Shift, btn_AddShift, this.Page);

            multiView_ShiftDetails.SetActiveView(view_GridView);
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

        protected void gview_Shift_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            int RecordID = int.Parse(((Label)gview_Shift.Rows[RowIndex].FindControl("lbl_ShiftID")).Text);
            lbl_DataOperationMode.Text = String.Format("EDIT SHIFT : {0} [{1}]", gview_Shift.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
            PageVariables.ThisShift = ShiftManagement.GetInstance.GetShiftByID(RecordID);


            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {
                btn_Top_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
                Btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();


                multiView_ShiftDetails.SetActiveView(view_InputControls);
                EnableControls(view_InputControls, true);
                PopulatePageFields(PageVariables.ThisShift);
                ChangeBackColor(view_InputControls);
                Btn_Save.Visible = true;
                btn_Top_Save.Visible = true;
            }
            else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
            {
                int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                ProcReturnValue = DeleteRecord();
                lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Shift", MicroEnums.DataOperation.Delete);
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    BindGridView();
                }

                dialog_Message.Show();
            }
            else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
            {
                multiView_ShiftDetails.SetActiveView(view_InputControls);
                PopulatePageFields(PageVariables.ThisShift);
                lbl_DataOperationMode.Text = String.Format("VIEW DEPARTMENT : {0} [{1}]", gview_Shift.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
                bool EnableFlag = false;
                EnableControls(view_InputControls, false);
                Btn_Save.Visible = EnableFlag;
                btn_Top_Save.Visible = EnableFlag;
                btn_Cancel.Visible = EnableFlag;

                btn_Cancel_Top.Visible = EnableFlag;
            }

        }

        protected void gview_Shift_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_Shift_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;

        }

        protected void gview_Shift_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_Shift.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void gview_Shift_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnDelete(e, 4);
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
                    BasePage.GridViewToolTips(e, 3, 4);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
       
        private void searchCtrl_ButtonClicked(object sender, System.EventArgs e)
        {
            SearchShiftBindGridView();
        }

        protected void chkSelectAll_Add_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkAll = (CheckBox)gview_Shiftelect.HeaderRow.FindControl("chkSelectAll_Add");
            if (chkAll.Checked == true)
            {
                foreach (GridViewRow gvRow in gview_Shiftelect.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
                    chkSel.Checked = true;

                }
            }
            else
            {
                foreach (GridViewRow gvRow in gview_Shiftelect.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
                    chkSel.Checked = false;

                }
            }
        }

        protected void gview_Shiftelect_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gview_Shiftelect.PageIndex = e.NewPageIndex;
            BindGridViewOfficeShifts();
        }

        protected void btn_Apply_Click(object sender, EventArgs e)
        {

            int result = (int)MicroEnums.DataOperationResult.Failure;

            ShiftOfficewise TheShiftOfficewise = new ShiftOfficewise();
            List<ShiftOfficewise> thisShiftOfficewiseList = new List<ShiftOfficewise>();
            foreach (GridViewRow therow in gview_Shiftelect.Rows)
            {

                ShiftOfficewise thisShiftOfficewise = new ShiftOfficewise();
                CheckBox chkb = (CheckBox)therow.FindControl("chk_Add");
                Label theOfficelabel = (Label)therow.FindControl("lbl_ShiftOfficeId");

                if (int.Parse(theOfficelabel.Text) == 0)
                {
                    if (chkb.Checked)
                    {
                        TheShiftOfficewise.ShiftID = int.Parse(therow.Cells[2].Text);

                        result = ShiftOfficewiseManagement.GetInstance.InsertShiftOfficewise(TheShiftOfficewise);
                        lbl_TheMessage.Text = GetDataOperationResult(result, "Shift", MicroEnums.DataOperation.AddNew);

                    }
                }
                else if (int.Parse(theOfficelabel.Text) != 0)
                {
                    TheShiftOfficewise.ShiftID = int.Parse(therow.Cells[2].Text);
                    if (!chkb.Checked)
                    {
                        TheShiftOfficewise.IsActive = false;
                    }
                    else
                    {
                        TheShiftOfficewise.IsActive = true;
                    }
                    TheShiftOfficewise.ShiftOfficewiseID = int.Parse(theOfficelabel.Text);

                    result = ShiftOfficewiseManagement.GetInstance.UpdateShiftOfficewise(TheShiftOfficewise);
                       
                    lbl_TheMessage.Text = GetDataOperationResult(result, "Shift", MicroEnums.DataOperation.Edit);
                }
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
        }

        protected void gview_Shiftelect_RowDataBound(object sender, GridViewRowEventArgs e)
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

        #endregion

        #region Methods & Implementation

        private void SetValidationMessages()
        {

            requiredFieldValidator_Description.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Description");
            requiredFieldValidator_Description.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
            RequiredFieldValidator_Alias.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Alias");
            RequiredFieldValidator_Alias.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
           
            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_Description.CssClass = theClassName;
            RequiredFieldValidator_Alias.CssClass = theClassName;
        }
       
        private void BindGridView()
        {

            //gview_Shift.DataSource = null;
            //gview_Shift.DataBind();

            //PageVariables.ShiftList = ShiftManagement.GetInstance.GetShiftList();

            //if (PageVariables.ShiftList.Count > 0)
            //{
            //    gview_Shift.DataSource = PageVariables.ShiftList;
            //    gview_Shift.DataBind();
            //}

            gview_Shift.DataSource = null;
            gview_Shift.DataBind();
            PageVariables.ShiftList = ShiftManagement.GetInstance.GetShiftList();
            gview_Shift.DataSource = PageVariables.ShiftList;
            gview_Shift.DataBind();

            gview_Shiftelect.DataSource = PageVariables.ShiftList;
            gview_Shiftelect.DataBind();


        }

        private void SearchShiftBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            List<Shift> SearchList = new List<Shift>();
            // Search by Description
            if (PageVariables.ShiftList.Count > 0)
            {
                if (searchField == MicroEnums.SearchShift.Description.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        SearchList = (from shiftname in PageVariables.ShiftList
                                      where shiftname.ShiftDescription.ToUpper().StartsWith(searchText.ToUpper())
                                      select shiftname).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from depname in PageVariables.ShiftList
                                      where depname.ShiftDescription.ToUpper().Contains(searchText.ToUpper())
                                      select depname).ToList();
                    }
                }
            }

            // Search By - Alias
            if (searchField == MicroEnums.SearchShift.Alias.ToString())
            {
                if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                {
                    SearchList = (from shift in PageVariables.ShiftList
                                  where shift.ShiftAlias.ToUpper().StartsWith(searchText.ToUpper())
                                  select shift).ToList();
                }

                if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                {
                    SearchList = (from shift in PageVariables.ShiftList
                                  where shift.ShiftAlias.ToUpper().Contains(searchText.ToUpper())
                                  select shift).ToList();
                }
            }
            // Dispaly the search result
            ctrl_Search.SearchResultCount = SearchList.Count.ToString();

            gview_Shift.DataSource = SearchList;
            gview_Shift.DataBind();
        }

        private void BindSearchFields()
        {
            foreach (MicroEnums.SearchDepartment x in Enum.GetValues(typeof(MicroEnums.SearchDepartment)))
            {
                string xyz = x.ToString();
            }
        }

        private void PopulatePageFields(Shift theShift)
        {
            txt_Description.Text = theShift.ShiftDescription;
            txt_Alias.Text = theShift.ShiftAlias;
           
        }

        private bool ValidateFormFields()
        {
            bool ReturnValue = true;
            return ReturnValue;
        }

        private int InsertRecord()
        {
            int ProcReturnValue = 0;
           
            Shift TheShifts = new Shift();
            TheShifts.ShiftDescription = txt_Description.Text;
            TheShifts.ShiftAlias = txt_Alias.Text;

            ProcReturnValue = ShiftManagement.GetInstance.InsertShift(TheShifts);
            return ProcReturnValue;
        }

        private void ResetTextBoxes()
        {

            txt_Alias.Text = string.Empty;
            txt_Description.Text = string.Empty;
            

            PageVariables.ThisShift = null;
            lbl_DataOperationMode.Text = "ADD NEW SHIFT";
            Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();

            Btn_Save.Visible = true;
            btn_Top_Save.Visible = true;
            EnableControls(view_InputControls, true);
            ResetBackColor(view_InputControls);
        }

        private static void ResetPageVariables()
        {
            PageVariables.ThisShift = null;
            PageVariables.ShiftList = null;
        }

        private int UpdateRecord()
        {
            PageVariables.ThisShift.ShiftDescription = txt_Description.Text;
            PageVariables.ThisShift.ShiftAlias = txt_Alias.Text;
            

            int ProcReturnValue = ShiftManagement.GetInstance.UpdateShift(PageVariables.ThisShift);
            return ProcReturnValue;
        }

        public static int DeleteRecord()
        {
            int ProcReturnValue = ShiftManagement.GetInstance.DeleteShift(PageVariables.ThisShift);
            return ProcReturnValue;
        }

        public void BindGridViewOfficeShifts()
        {
            List<Shift> AllShifts = new List<Shift>();
            AllShifts = ShiftManagement.GetInstance.GetShiftList();

            List<ShiftOfficewise> CurrentOfficeShifts = new List<ShiftOfficewise>();
            CurrentOfficeShifts = ShiftOfficewiseManagement.GetInstance.GetShiftOfficewiseByOfficeID();

            gview_Shiftelect.DataSource = AllShifts;
            gview_Shiftelect.DataBind();


            int counter = 0;
            if (CurrentOfficeShifts.Count > 0)
            {
                foreach (ShiftOfficewise theshiftofficewise in CurrentOfficeShifts)
                {
                    counter++;
                    foreach (GridViewRow therow in gview_Shiftelect.Rows)
                    {
                        Label thedesiglabel = (Label)therow.FindControl("lbl_ShiftId");
                        Label theOfficelabel = (Label)therow.FindControl("lbl_ShiftOfficeId");
                        CheckBox theCheckBox = (CheckBox)therow.FindControl("chk_Add");

                        if (thedesiglabel.Text.Equals(theshiftofficewise.ShiftID.ToString()))
                        {
                            if (theshiftofficewise.IsActive.Equals(true))
                                theCheckBox.Checked = true;
                            theOfficelabel.Text = theshiftofficewise.ShiftOfficewiseID.ToString();

                            if (CurrentOfficeShifts.Count > 1 && counter == CurrentOfficeShifts.Count)
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
                foreach (GridViewRow therow in gview_Shiftelect.Rows)
                {
                    Label thedesiglabel = (Label)therow.FindControl("lbl_ShiftId");
                    Label theOfficelabel = (Label)therow.FindControl("lbl_ShiftOfficeId");
                    CheckBox theCheckBox = (CheckBox)therow.FindControl("chk_Add");

                    theOfficelabel.Text = "0";
                }

            }
            BasePage.HideGridViewColumn(gview_Shiftelect, "ShiftOfficeID");
            BasePage.HideGridViewColumn(gview_Shiftelect, "ShiftID");
        }

        private void FillOfficeShifts(int officeID)
        {
            try
            {

                List<ShiftOfficewise> ShiftOfficewiseList = ShiftOfficewiseManagement.GetInstance.GetShiftOfficewiseByOfficeID(officeID);
             
                List<ShiftOfficewise> BindShiftItems = (from m in ShiftOfficewiseList
                                                        where m.ShiftOfficewiseID != -1
                                                        orderby m.ShiftOfficewiseID
                                                        select m).ToList<ShiftOfficewise>();

                // Bind the GridView for the forms

                gview_Shiftelect.DataSource = BindShiftItems;
                gview_Shiftelect.DataBind();




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
            List<ShiftOfficewise> TheShiftByoffice = ShiftOfficewiseManagement.GetInstance.GetShiftOfficewiseByOfficeID(OfficeID);
           

            foreach (GridViewRow gvRow in gview_Shiftelect.Rows)
            {
                int TheOfficeID = ((User)Session["CurrentUser"]).OfficeID;
                CheckBox chkSelAdd = (CheckBox)gvRow.FindControl("chk_Add");


                Label lbl_ShiftId = (Label)gvRow.FindControl("lbl_ShiftId");

                int ShiftIdd = int.Parse(lbl_ShiftId.Text);

                chkSelAdd.Checked = WillSelectCheckBox(TheShiftByoffice, ShiftIdd, BasePage.IsActive, TheOfficeID);
            }
        }

        private bool WillSelectCheckBox(List<ShiftOfficewise> TheShiftByoffice, int shiftIdd, bool IsActive, int theofficeid)
        {
            bool ReturnValue;
            var result = TheShiftByoffice.Find
                        (mm =>
                            mm.OfficeID == theofficeid &&
                            mm.ShiftID == shiftIdd &&
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