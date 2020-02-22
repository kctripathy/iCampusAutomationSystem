using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.HumanResource;
using Micro.Commons;
using Micro.Objects.HumanResource;
using Micro.Objects.Administration;
using System.Data;
using System.Globalization;
using Micro.Framework.ReadXML;

namespace Micro.WebApplication.MicroERP.HRMS
{
    public partial class ShiftTimings : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {
            public static List<ShiftTiming> ShiftTimingList
            {
                get
                {
                    List<ShiftTiming> TheShifting = HttpContext.Current.Session["ShiftTimingList"] as List<Micro.Objects.HumanResource.ShiftTiming>;
                    return TheShifting;
                }
                set
                {
                    HttpContext.Current.Session.Add("ShiftTimingList", value);
                }

            }
            public static int TheShiftTimingID
            {

                get
                {
                    int theShiftingID = int.Parse(HttpContext.Current.Session["TheShiftTimingID"].ToString());
                    return theShiftingID;
                }

                set
                {
                    HttpContext.Current.Session.Add("TheShiftTimingID", value);
                }
            }

            public static int TheShiftID
            {

                get
                {
                    int theShiftID = int.Parse(HttpContext.Current.Session["TheShiftID"].ToString());
                    return theShiftID;
                }

                set
                {
                    HttpContext.Current.Session.Add("TheShiftID", value);
                }
            }

            public static ShiftTiming objShiftTimings = new ShiftTiming();

            public static int TheUserReferenceID;


            public static int RowIndex;



            public static int TheShiftOfficewiseID
            {

                get
                {
                    int theShiftOfficewiseID = int.Parse(HttpContext.Current.Session["TheShiftOfficewiseID"].ToString());
                    return theShiftOfficewiseID;
                }

                set
                {
                    HttpContext.Current.Session.Add("TheShiftOfficewiseID", value);
                }
            }

            public static ShiftOfficewise ThisShiftOfficewise
            {
                get
                {
                    ShiftOfficewise TheShiftOfficewise = HttpContext.Current.Session["ThisShiftOfficewise"] as ShiftOfficewise;
                    return TheShiftOfficewise;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisShiftOfficewise", value);
                }
            }

            public static List<ShiftOfficewise> ShiftOfficewiseList
            {
                get
                {
                    List<ShiftOfficewise> TheShiftOfficewise = HttpContext.Current.Session["ShiftOfficewiseList"] as List<ShiftOfficewise>;
                    return TheShiftOfficewise;
                }
                set
                {
                    HttpContext.Current.Session.Add("ShiftOfficewiseList", value);
                }
            }


        }
        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                BindGridViewOfficeDesignations();
                BindLiteralValues();

            }
            SetValidationMessages();
        }

        protected void gview_ShiftTiming_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_ShiftTiming_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            PageVariables.RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                PageVariables.RowIndex = Convert.ToInt32(e.CommandArgument);

            }
            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {

                //  
                lbl_ShiftID.Text = ((int)gview_ShiftTiming.DataKeys[PageVariables.RowIndex].Value).ToString();
                lbl_ShiftTimingID.Text = gview_ShiftTiming.Rows[PageVariables.RowIndex].Cells[1].Text;

                Label txtShiftTimingID = (Label)gview_ShiftTiming.Rows[PageVariables.RowIndex].FindControl("lbl_ShiftTimingID");
                lbl_ShiftTimingID.Text = txtShiftTimingID.Text;

                Label txtDescription = (Label)gview_ShiftTiming.Rows[PageVariables.RowIndex].FindControl("lbl_ShiftDescription");
                lbl_Description.Text = txtDescription.Text;

                Label txtAlias = (Label)gview_ShiftTiming.Rows[PageVariables.RowIndex].FindControl("lbl_ShiftAlias");
                lbl_Alias.Text = txtAlias.Text;

                Label txtweeklyoff = (Label)gview_ShiftTiming.Rows[PageVariables.RowIndex].FindControl("lbl_WeeklyOff");
                if (!string.IsNullOrEmpty(txtweeklyoff.Text))
                {

                    ddl_WeeklyOff.SelectedValue = txtweeklyoff.Text;
                    //GetDropDownSelectedIndex(ddlCompany, txtMon.Text);
                }



                if (gview_ShiftTiming.Rows[PageVariables.RowIndex] != null)
                {
                    Label txtIntime = (Label)gview_ShiftTiming.Rows[PageVariables.RowIndex].FindControl("lbl_InTime");
                    Label txtOutTime = (Label)gview_ShiftTiming.Rows[PageVariables.RowIndex].FindControl("lbl_OutTime");


                    if (!string.IsNullOrEmpty(txtIntime.Text))
                    {

                        txt_InTime.Text = txtIntime.Text;
                    }
                    if (!string.IsNullOrEmpty(txtOutTime.Text))
                    {

                        txt_OutTime.Text = txtOutTime.Text;
                    }


                }



                this.ModalPopupExtender1.Show();
               
            }

        }
       
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {


            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);


            Label txtShiftID = (Label)gview_ShiftTiming.Rows[PageVariables.RowIndex].FindControl("lbl_ShiftID");
            Label txtInTime = (Label)gview_ShiftTiming.Rows[PageVariables.RowIndex].FindControl("lbl_InTime");
            Label txtOutTime = (Label)gview_ShiftTiming.Rows[PageVariables.RowIndex].FindControl("lbl_OutTime");
            Label txtWeeklyOff = (Label)gview_ShiftTiming.Rows[PageVariables.RowIndex].FindControl("lbl_WeeklyOff");
            CheckBox chkSel = (CheckBox)gview_ShiftTiming.FindControl("chk_Add");



            txtShiftID.Text = lbl_ShiftID.Text;
            txtInTime.Text = txt_InTime.Text;
            txtOutTime.Text = txt_OutTime.Text;
            txtWeeklyOff.Text = ddl_WeeklyOff.SelectedValue;
        
            Label txtShiftTimingID = (Label)gview_ShiftTiming.Rows[PageVariables.RowIndex].FindControl("lbl_ShiftTimingID");

            if (Convert.ToInt16(txtShiftTimingID.Text) > 0)
            {
                ShiftTiming theShiftTiming = new ShiftTiming();

                theShiftTiming.ShiftTimingID = Convert.ToInt16(txtShiftTimingID.Text);
                theShiftTiming.ShiftID = Convert.ToInt16(txtShiftID.Text);
                theShiftTiming.DepartmentID = TheEmployee.DepartmentID;
                theShiftTiming.InTime = DateTime.Parse(txtInTime.Text);
                theShiftTiming.OutTime = DateTime.Parse(txtOutTime.Text);
                theShiftTiming.WeeklyOffDay = txtWeeklyOff.Text;
                theShiftTiming.EffectiveDate = DateTime.Today;
                theShiftTiming.CalculationMode = "DAY";
                ShiftTimingsManagement.GetInstance.UpdateShiftTimings(theShiftTiming);
            }
            else if (Convert.ToInt16(txtShiftTimingID.Text) == 0)
            {


                ShiftTiming theShiftTiming = new ShiftTiming();

                theShiftTiming.ShiftID = Convert.ToInt16(txtShiftID.Text);
                theShiftTiming.DepartmentID = TheEmployee.DepartmentID;
                theShiftTiming.InTime = DateTime.Parse(txtInTime.Text);
                theShiftTiming.OutTime = DateTime.Parse(txtOutTime.Text);
                theShiftTiming.WeeklyOffDay = txtWeeklyOff.Text;
                theShiftTiming.EffectiveDate = DateTime.Today;
                theShiftTiming.CalculationMode = "DAY";
                ShiftTimingsManagement.GetInstance.InsertShiftTimings(theShiftTiming);
            }

            BindGridViewOfficeDesignations();


            ResetTextBoxes();

        }
       
        protected void gview_ShiftTiming_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_ShiftTiming.PageIndex = e.NewPageIndex;
            BindGridViewOfficeDesignations();
        }

        #endregion

        #region Methods & Implementation

        private void SetValidationMessages()
        {
            regularExpressionValidator_InTime.ValidationExpression = MicroConstants.REGEX_TIME;
            regularExpressionValidator_InTime.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_12_HOURS_FORMAT");
            regularExpressionValidator_OutTime.ValidationExpression = MicroConstants.REGEX_TIME;
            regularExpressionValidator_OutTime.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_12_HOURS_FORMAT");
            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {


        }

        public void BindGridViewOfficeDesignations()
        {
            ShiftOfficewise teShiftOfficewise = new ShiftOfficewise();

            List<ShiftOfficewise> _ShiftsList = new List<ShiftOfficewise>();
            _ShiftsList = ShiftOfficewiseManagement.GetInstance.GetShiftOfficewiseByOfficeID(Connection.LoggedOnUser.OfficeID);
            gview_ShiftTiming.DataSource = _ShiftsList;
            gview_ShiftTiming.DataBind();
            int counter = 0;
            foreach (GridViewRow therow in gview_ShiftTiming.Rows)
            {
                Label theShiftlabel = (Label)therow.FindControl("lbl_ShiftID");
                Label theShiftTimingIdlabel = (Label)therow.FindControl("lbl_ShiftTimingID");
                Label theOfficelabel = (Label)therow.FindControl("lbl_ShiftOfficeId");
                Label theAilaslabel = (Label)therow.FindControl("lbl_ShiftAlias");

                Label theDescriptionlabel = (Label)therow.FindControl("lbl_ShiftDescription");
                Label theintimelabel = (Label)therow.FindControl("lbl_InTime");
                Label theouttimelabel = (Label)therow.FindControl("lbl_OutTime");
                Label theWeeklyOfflabel = (Label)therow.FindControl("lbl_WeeklyOff");
                CheckBox theCheckBox = (CheckBox)therow.FindControl("chk_Add");
                PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
                Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
                //Get ShiftTimings of Current Employee Department
                int shiftTID = (int)gview_ShiftTiming.DataKeys[therow.RowIndex].Value;
                List<ShiftTiming> _ShftTimingList = new List<Micro.Objects.HumanResource.ShiftTiming>();
                _ShftTimingList = ShiftTimingsManagement.GetInstance.GetShiftTimingsByOfficeIDandDepartmentID(TheEmployee.DepartmentID);

                var thisShiftID = _ShftTimingList.Where(shift => shift.ShiftID.Equals(shiftTID)).ToList();

                if (thisShiftID.Count > 0)
                {
                    foreach (ShiftTiming theShiftTiming in thisShiftID)
                    {

                        if (theShiftlabel.Text.Equals(theShiftTiming.ShiftID.ToString()))
                        {
                            if (theShiftTiming.IsActive.Equals(true))
                            {
                                theCheckBox.Checked = true;
                            }
                            theOfficelabel.Text = theShiftTiming.ShiftOfficewiseID.ToString();
                            theAilaslabel.Text = theShiftTiming.ShiftAlias;
                            theDescriptionlabel.Text = theShiftTiming.ShiftDescription;
                            theintimelabel.Text = theShiftTiming.InTime.ToShortTimeString();
                            theouttimelabel.Text = theShiftTiming.OutTime.ToShortTimeString();
                            theWeeklyOfflabel.Text = theShiftTiming.WeeklyOffDay;
                            theShiftTimingIdlabel.Text = theShiftTiming.ShiftTimingID.ToString();
                            if (_ShftTimingList.Count > 1 && counter == _ShftTimingList.Count)
                            {
                                break;
                            }
                        }
                    }

                }
                else
                {
                    var thisShiftID1 = _ShiftsList.Where(shift => shift.ShiftID.Equals(shiftTID)).SingleOrDefault();
                    int a = Convert.ToInt16(theShiftlabel.Text);
                    if (a == shiftTID)
                    {
                        theOfficelabel.Text = "0";
                        theShiftTimingIdlabel.Text = "0";
                        theAilaslabel.Text = thisShiftID1.ShiftAlias;
                        theDescriptionlabel.Text = thisShiftID1.ShiftDescription;
                        theintimelabel.Text = thisShiftID1.InTime;
                        theouttimelabel.Text = thisShiftID1.OutTime;
                        theWeeklyOfflabel.Text = "";

                    }

                }

            }

            BasePage.HideGridViewColumn(gview_ShiftTiming, "ShiftID");
            BasePage.HideGridViewColumn(gview_ShiftTiming, "ShiftTimingID");
            BasePage.HideGridViewColumn(gview_ShiftTiming, "ShiftOfficeWiseID");

        }

        private void CheckUncheckGridItems()
        {

           
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
            List<ShiftTiming> _ShftTimingList = new List<Micro.Objects.HumanResource.ShiftTiming>();
            _ShftTimingList = ShiftTimingsManagement.GetInstance.GetShiftTimingsByOfficeIDandDepartmentID(TheEmployee.DepartmentID);

            foreach (GridViewRow gvRow in gview_ShiftTiming.Rows)
            {
                int TheOfficeID = ((User)Session["CurrentUser"]).OfficeID;
                CheckBox chkSelAdd = (CheckBox)gvRow.FindControl("chk_Add");


                Label lbl_ShiftId = (Label)gvRow.FindControl("lbl_ShiftID");

                int DesignationIdd = int.Parse(lbl_ShiftId.Text);

                chkSelAdd.Checked = WillSelectCheckBox(_ShftTimingList, DesignationIdd, BasePage.IsActive, TheOfficeID);
            }
        }

        private bool WillSelectCheckBox(List<ShiftTiming> TheShiftByoffice, int ShiftIdd, bool IsActive, int theofficeid)
        {
            bool ReturnValue;
            var result = TheShiftByoffice.Find
                        (mm =>
                            mm.OfficeID == theofficeid &&
                            mm.ShiftID == ShiftIdd &&
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

        protected void chkSelectAll_Add_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkAll = (CheckBox)gview_ShiftTiming.HeaderRow.FindControl("chkSelectAll_Add");
            if (chkAll.Checked == true)
            {
                foreach (GridViewRow gvRow in gview_ShiftTiming.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
                    chkSel.Checked = true;

                }
            }
            else
            {
                foreach (GridViewRow gvRow in gview_ShiftTiming.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
                    chkSel.Checked = false;

                }
            }
        }

        ListItem DayList;
        private void BindLiteralValues()
        {
            foreach (var DayNameitem in DateTimeFormatInfo.CurrentInfo.DayNames)
            {
                if (DayNameitem != "")
                {
                    DayList = new ListItem();
                    DayList.Text = DayNameitem;
                    DayList.Value = DayNameitem;
                    ddl_WeeklyOff.Items.Add(DayList);
                }
            }


        }

        private void ResetTextBoxes()
        {
            txt_InTime.Text = string.Empty;
            txt_OutTime.Text = string.Empty;
            lbl_Alias.Text = string.Empty;
            lbl_Description.Text = string.Empty;
            lbl_ShiftID.Text = string.Empty;
            lbl_ShiftTimingID.Text = string.Empty;
            PageVariables.ThisShiftOfficewise = null;

        }

        #endregion
       


    }
}