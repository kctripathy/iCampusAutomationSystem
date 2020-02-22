using System;
using Micro.Commons;
using System.Collections.Generic;
using Micro.Objects.HumanResource;
using Micro.BusinessLayer.HumanResource;
using Micro.BusinessLayer.Administration;
using System.Web;
using System.Web.UI.WebControls;
using Micro.Framework.ReadXML;
using System.Linq;
using Micro.Objects.Administration;

namespace Micro.WebApplication.MicroERP.HRMS
{
	public partial class HRMSettings : BasePage
	{
        #region Declaration
        protected static class PageVariable
        {
            //PageVariables modified on Dt:19/2/2013
            public static List<HolidayOfficewise> CurrentOfficeHolidays;
            public static string TheHolidayID
            {
                get
                {
                    string ThisHolidayID = HttpContext.Current.Session["TheHolidayID"].ToString();
                    return ThisHolidayID;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheHolidayID", value);
                }
            }

            public static List<Holiday> TheHolidayList
            {
                get
                {
                    List<Holiday> HolidayList = HttpContext.Current.Session["TheHolidayList"] as List<Holiday>;
                    return HolidayList;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheHolidayList", value);
                }
            }
        }
        #endregion

        #region Events

		protected void Page_Load(object sender, EventArgs e)
		{
            BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
            ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
            ctrl_Search.SearchWhat = MicroEnums.SearchForm.Holiday.ToString();
            if (!IsPostBack && !IsCallback)
            {
                BindGridView();
                BindDropDownList();
                SetFormMessage();
                if (HasAddPermission() && IsDefaultModeAdd())
                {

                    multiView_HolidayDetails.SetActiveView(view_InputControls);
                    ResetBackColor(view_InputControls);
                }
                else
                {
                    BindGridView();

                    BasePage.ShowHidePagePermissions(gview_Holiday, btn_AddHoliday, this.Page);
                    tab_Holidays_ActiveTabChanged(sender, e);
                    
                }
            }

		}

        protected void tab_Holidays_ActiveTabChanged(object sender, EventArgs e)
        {
            if (tab_Holidays.ActiveTab == tab_HolidayAll)
            {

                multiView_HolidayDetails.SetActiveView(view_GridView);
            }
            else
            {

                Multiview_Holid.SetActiveView(view_GridViewHolida);
               // BindGridViewOfficeDesignations();
                BindGridViewOfficeHolidays();
            }
        }

        protected void btn_Top_Save_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            if (btn_Top_Save.Text == MicroEnums.DataOperation.Save.GetStringValue() && Btn_Save.Text == MicroEnums.DataOperation.Save.GetStringValue())
            {
                if (ValidateFormFields())
                {
                    ProcReturnValue = SaveHoliday();
                    dialog_Message.Show();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Holiday", MicroEnums.DataOperation.AddNew);

                }
            }
            else
            {
                ProcReturnValue = UpdateRecord();
                dialog_Message.Show();
                lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Holiday", MicroEnums.DataOperation.Edit);

            }
            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                BindGridView();
                BindGridViewOfficeHolidays();
                ResetPageFields();
            }
        }

        protected void btn_AddHoliday_Click(object sender, EventArgs e)
        {

            multiView_HolidayDetails.SetActiveView(view_InputControls);
            ResetPageFields();
            if (!(BasePage.HasAddPermission(this.Page)))
            {
                multiView_HolidayDetails.SetActiveView(view_GridView);
            }
        }

        protected void btn_ViewHolidayDetails_Click(object sender, EventArgs e)
        {

            multiView_HolidayDetails.SetActiveView(view_GridView);
            BindGridView();

            BasePage.ShowHidePagePermissions(gview_Holiday, btn_AddHoliday, this.Page);
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {

            ResetPageFields();


        }

        protected void gview_Holiday_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            PageVariable.TheHolidayID = ((Label)gview_Holiday.Rows[RowIndex].FindControl("lbl_HolidayID")).Text;

            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {
                lbl_DataOperationMode.Text = String.Format("EDIT HOLIDAY : {0} [{1}]", gview_Holiday.Rows[RowIndex].Cells[2].Text.ToUpper(), PageVariable.TheHolidayID);
                btn_Top_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Update.GetStringValue());
                Btn_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Update.GetStringValue());

                multiView_HolidayDetails.SetActiveView(view_InputControls);
                PopulatePageFields(int.Parse(PageVariable.TheHolidayID));
                EnableControls(view_InputControls, true);
                Btn_Save.Visible = true;
                btn_Top_Save.Visible = true;
                ChangeBackColor(view_InputControls);
            }

            else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
            {
                
                multiView_HolidayDetails.SetActiveView(view_InputControls);
                PopulatePageFields(int.Parse(PageVariable.TheHolidayID));
                lbl_DataOperationMode.Text = String.Format("VIEW HOLIDAY : {0} [{1}]", gview_Holiday.Rows[RowIndex].Cells[2].Text.ToUpper(), PageVariable.TheHolidayID);
                EnableControls(view_InputControls, false);
                Btn_Save.Visible = false;
                btn_Top_Save.Visible = false;
            }
        }

        protected void gview_Holiday_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_Holiday_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ProcReturnValue = 0;

            Holiday ObjHoliday = new Holiday();
            ObjHoliday.HolidayID = int.Parse(PageVariable.TheHolidayID);
            ProcReturnValue = HolidayManagement.GetInstance.DeleteHoliday(ObjHoliday.HolidayID);

            dialog_Message.Show();
            lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Holiday", MicroEnums.DataOperation.Delete);
            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {

                gview_Holiday.EditIndex = -1;
                BindGridView();
            }

        }

        protected void gview_Holiday_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_Holiday.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void gview_Holiday_RowDataBound(object sender, GridViewRowEventArgs e)
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

        private void searchCtrl_ButtonClicked(object sender, System.EventArgs e)
        {
            SearchHolidayBindGridView();
        }

        protected void btn_Apply_Click(object sender, EventArgs e)
        {

            int result = (int)MicroEnums.DataOperationResult.Failure;

            HolidayOfficewise ObjHoli = new HolidayOfficewise();
            List<HolidayOfficewise> thisHolidayOfficewiseList = new List<HolidayOfficewise>();
            foreach (GridViewRow therow in gview_HolidaySelect.Rows)
            {

                HolidayOfficewise thisHolidayOfficewise = new HolidayOfficewise();
                CheckBox chkb = (CheckBox)therow.FindControl("chk_Add");
                Label theOfficelabel = (Label)therow.FindControl("lbl_HolidayOfficeId");

                if (int.Parse(theOfficelabel.Text) == 0)
                {
                    if (chkb.Checked)
                    {
                        ObjHoli.HolidayID = int.Parse(therow.Cells[2].Text);

                        result = HolidayOfficewiseManagement.GetInstance.InsertHolidayOfficewise(ObjHoli);
                        lbl_TheMessage.Text = GetDataOperationResult(result, "Holiday", MicroEnums.DataOperation.AddNew);

                    }
                }
                else if (int.Parse(theOfficelabel.Text) != 0)
                {
                    ObjHoli.HolidayID = int.Parse(therow.Cells[2].Text);
                    if (!chkb.Checked)
                    {
                        ObjHoli.IsActive = false;
                    }
                    else
                    {
                        ObjHoli.IsActive = true;
                    }
                    ObjHoli.HolidayOfficewiseID = int.Parse(theOfficelabel.Text);

                    result = HolidayOfficewiseManagement.GetInstance.UpdateHolidayOfficewise(ObjHoli);
                    lbl_TheMessage.Text = GetDataOperationResult(result, "Holiday", MicroEnums.DataOperation.Edit);
                }
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
        }

        protected void gview_HolidaySelect_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gview_HolidaySelect_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_HolidaySelect.PageIndex = e.NewPageIndex;
            BindGridViewOfficeHolidays();
        }

        protected void chkSelectAll_Add_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox chkAll = (CheckBox)gview_HolidaySelect.HeaderRow.FindControl("chkSelectAll_Add");
            if (chkAll.Checked == true)
            {
                foreach (GridViewRow gvRow in gview_HolidaySelect.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
                    chkSel.Checked = true;

                }
            }
            else
            {
                foreach (GridViewRow gvRow in gview_HolidaySelect.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
                    chkSel.Checked = false;

                }
            }
        }

        #endregion

        #region Methods & Implemenation

        private void BindGridView()
        {

            gview_Holiday.DataSource = null;
            gview_Holiday.DataBind();
            PageVariable.TheHolidayList = HolidayManagement.GetInstance.GetAllHolidays();
            gview_Holiday.DataSource = PageVariable.TheHolidayList;
            gview_Holiday.DataBind();
            multiView_HolidayDetails.SetActiveView(view_GridView);

            gview_HolidaySelect.DataSource = PageVariable.TheHolidayList;
            gview_HolidaySelect.DataBind();

        }

        private int SaveHoliday()
        {
            int ProcReturnValue = 0;

            Holiday theHoliday = new Holiday();
            theHoliday.Occasion = txt_OccasionDescription.Text.ToString();
            theHoliday.DateOfOccasion = DateTime.Parse(txt_DateOfOccasion.Text);
            if (chk_IsDateFixed.Checked == true)
            {
                theHoliday.IsDateFixed = true;
            }
            else
            {
                theHoliday.IsDateFixed = false;

            }
         ProcReturnValue = HolidayManagement.GetInstance.InsertHoliday(theHoliday);
            return ProcReturnValue;
        }

        private void BindDropDownList()
        {
            //BindRole();
            //BindReportingTo();

            //ddl_ReportingTo.DataValueField=DesignationManagement.GetInstance
        }

      
        private bool ValidateFormFields()
        {
            bool ReturnValue = true;
           
            return ReturnValue;
        }

        private void PopulatePageFields(int theHolidayId)
        {
            Holiday objHoliday = HolidayManagement.GetInstance.GetHolidayByID(theHolidayId);
            txt_DateOfOccasion.Text = objHoliday.DateOfOccasion.ToString(MicroConstants.DateFormat);
            txt_OccasionDescription.Text = objHoliday.Occasion;
            if (objHoliday.IsDateFixed == true)
            {
                chk_IsDateFixed.Checked = true;
            }
            else
            {
                chk_IsDateFixed.Checked = false;
            }
        }

        private int UpdateRecord()
        {
            
            Holiday TheHoliday = new Holiday();
            TheHoliday.HolidayID = int.Parse(PageVariable.TheHolidayID);
            TheHoliday.Occasion = txt_OccasionDescription.Text.ToString();
            TheHoliday.DateOfOccasion = DateTime.Parse(txt_DateOfOccasion.Text);
            if (chk_IsDateFixed.Checked == true)
            {
                TheHoliday.IsDateFixed = true;
            }
            else
            {
                TheHoliday.IsDateFixed = false;

            }
          int   ProcReturnValue = HolidayManagement.GetInstance.UpdateHoliday(TheHoliday);
            return ProcReturnValue;
        }

        private void SetFormMessage()
        {
            RequiredFieldValidator_OccasionName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "OccasionName");
            RegularExpressionValidator_OccasionName.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
            requiredFieldValidator_DateOfOccasion.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "OccasionDate");
            regularExpressionValidator_DateOfOccasion.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");
            regularExpressionValidator_DateOfOccasion.ValidationExpression = MicroConstants.REGEX_DATE;
            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            RequiredFieldValidator_OccasionName.CssClass = theClassName;
            RegularExpressionValidator_OccasionName.CssClass = theClassName;
            requiredFieldValidator_DateOfOccasion.CssClass = theClassName;
        }

        private void ResetPageFields()
        {
            txt_OccasionDescription.Text = string.Empty;
            chk_IsDateFixed.Checked = false;
            txt_DateOfOccasion.Text = string.Empty;
            lbl_DataOperationMode.Text = "ADD NEW HOLIDAY";
         
            btn_Top_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Save.GetStringValue());
            Btn_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Save.GetStringValue());
          
            ResetBackColor(view_InputControls);
            Btn_Save.Visible = true;
            btn_Top_Save.Visible = true;
            ResetBackColor(view_InputControls);
            EnableControls(view_InputControls, true);
            
            if (tab_Holidays.ActiveTab == tab_HolidayAll)
            {
                multiView_HolidayDetails.SetActiveView(view_InputControls);
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

        private void SearchHolidayBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            List<Holiday> SearchList = new List<Holiday>();
            // Search by name
            if (PageVariable.TheHolidayList.Count > 0)
            {
                if (searchField == MicroEnums.SearchHoliday.Occasion.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        SearchList = (from occssion in PageVariable.TheHolidayList
                                      where occssion.Occasion.ToUpper().StartsWith(searchText.ToUpper())
                                      select occssion).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from occssion in PageVariable.TheHolidayList
                                      where occssion.Occasion.ToUpper().Contains(searchText.ToUpper())
                                      select occssion).ToList();
                    }
                }
            }
            // Dispaly the search result
            ctrl_Search.SearchResultCount = SearchList.Count.ToString();

            gview_Holiday.DataSource = SearchList;
            gview_Holiday.DataBind();
        }

        private void BindSearchFields()
        {
            foreach (MicroEnums.SearchHoliday x in Enum.GetValues(typeof(MicroEnums.SearchHoliday)))
            {
                string xyz = x.ToString();
            }
        }

        public void BindGridViewOfficeHolidays()
        {
            List<Holiday> AllHolidays = new List<Holiday>();
            AllHolidays = HolidayManagement.GetInstance.GetAllHolidays();
            int year = System.DateTime.Now.Year;
          
            List<HolidayOfficewise> CurrentOfficeHolidays = new List<HolidayOfficewise>();
            CurrentOfficeHolidays = HolidayOfficewiseManagement.GetInstance.GetHolidayOfficewiseByOfficeIDandCalenderYear(year);
            gview_HolidaySelect.DataSource = AllHolidays;
            gview_HolidaySelect.DataBind();


            int counter = 0;
            if (CurrentOfficeHolidays.Count > 0)
            {
                foreach (HolidayOfficewise theholidayofficewise in CurrentOfficeHolidays)
                {
                    counter++;
                    foreach (GridViewRow therow in gview_HolidaySelect.Rows)
                    {
                        Label theholidaylabel = (Label)therow.FindControl("lbl_HolidayId");
                        Label theOfficelabel = (Label)therow.FindControl("lbl_HolidayOfficeId");
                        CheckBox theCheckBox = (CheckBox)therow.FindControl("chk_Add");

                        if (theholidaylabel.Text.Equals(theholidayofficewise.HolidayID.ToString()))
                        {
                            if (theholidayofficewise.IsActive.Equals(true))
                                theCheckBox.Checked = true;
                            theOfficelabel.Text = theholidayofficewise.HolidayOfficewiseID.ToString();

                            if (CurrentOfficeHolidays.Count > 1 && counter == CurrentOfficeHolidays.Count)
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
                foreach (GridViewRow therow in gview_HolidaySelect.Rows)
                {
                    Label theholidaylabel = (Label)therow.FindControl("lbl_HolidayId");
                    Label theOfficelabel = (Label)therow.FindControl("lbl_HolidayOfficeId");
                    CheckBox theCheckBox = (CheckBox)therow.FindControl("chk_Add");

                    theOfficelabel.Text = "0";
                }

            }
            BasePage.HideGridViewColumn(gview_HolidaySelect, "HolidayOfficeID");
            BasePage.HideGridViewColumn(gview_HolidaySelect, "HolidayID");
        }

        private void FillOfficeHolidays(int officeID)
        {
            try
            {
                int year = System.DateTime.Now.Year;
                List<HolidayOfficewise> HolidayOfficewiseList = HolidayOfficewiseManagement.GetInstance.GetHolidayOfficewiseByOfficeIDandCalenderYear(year);
                   
                List<HolidayOfficewise> BindDesignationItems = (from m in HolidayOfficewiseList
                                                                    where m.HolidayOfficewiseID != -1
                                                                    orderby m.HolidayOfficewiseID
                                                                    select m).ToList<HolidayOfficewise>();

                // Bind the GridView for the forms

                gview_HolidaySelect.DataSource = BindDesignationItems;
                gview_HolidaySelect.DataBind();




                CheckUncheckGridItems();

            }

            catch (Exception ex)
            {

            }
          

        }

        private void CheckUncheckGridItems()
        {

            int OfficeID = ((User)Session["CurrentUser"]).OfficeID;
            int year = System.DateTime.Now.Year;
            List<HolidayOfficewise> TheHolidayByoffice = HolidayOfficewiseManagement.GetInstance.GetHolidayOfficewiseByOfficeIDandCalenderYear(year);
            foreach (GridViewRow gvRow in gview_HolidaySelect.Rows)
            {
                int TheOfficeID = ((User)Session["CurrentUser"]).OfficeID;
                CheckBox chkSelAdd = (CheckBox)gvRow.FindControl("chk_Add");


                Label lbl_HolidayId = (Label)gvRow.FindControl("lbl_HolidayId");

                int HolidayIdd = int.Parse(lbl_HolidayId.Text);

                chkSelAdd.Checked = WillSelectCheckBox(TheHolidayByoffice, HolidayIdd, BasePage.IsActive, TheOfficeID);
            }
        }

        private bool WillSelectCheckBox(List<HolidayOfficewise> TheHolidayByoffice, int holidayIdd, bool IsActive, int theofficeid)
        {
            bool ReturnValue;
            var result = TheHolidayByoffice.Find
                        (mm =>
                            mm.OfficeID == theofficeid &&
                            mm.HolidayID == holidayIdd &&
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