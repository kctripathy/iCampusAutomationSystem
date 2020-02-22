using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.HumanResource;
using Micro.Objects.HumanResource;
using System.Data;
using System.Globalization;

namespace Micro.WebApplication.MicroERP.HRMS
{
    public partial class ShiftRoasters : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {
            public static int TheUserReferenceID;
            public static ShiftSchedule ThisShiftSchedule
            {
                get
                {
                    ShiftSchedule TheShiftSchedule = HttpContext.Current.Session["ThisShiftSchedule"] as ShiftSchedule;
                    return TheShiftSchedule;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisShiftSchedule", value);
                }
            }

            public static List<ShiftSchedule> ShiftScheduleList
            {
                get
                {
                    List<ShiftSchedule> TheShiftSchedule = HttpContext.Current.Session["ShiftScheduleList"] as List<ShiftSchedule>;
                    return TheShiftSchedule;
                }
                set
                {
                    HttpContext.Current.Session.Add("ShiftScheduleList", value);
                }
            }

            public static int TheEmpID;

            public static int RowIndex;


        }
        public Label Label;

        Boolean AllowRescheduleOfPastShiftSchedules = false;

        List<Micro.Objects.HumanResource.ShiftSchedule> DepartmentShiftSchedules = new List<Micro.Objects.HumanResource.ShiftSchedule>();

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SetValidationMessages();
                txt_SelectDate.Text = DateTime.Now.ToShortDateString();

            }

            BindGridviewDateColumn();

        }

        protected void btn_ShowSchedules_Click(object sender, EventArgs e)
        {
            try
            {
                PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
                Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
                int DepartmentID = TheEmployee.DepartmentID;

                string dt = DateTime.Parse(txt_SelectDate.Text).ToString(MicroConstants.DateFormat);

                BindGridView(DepartmentID, dt);
            }
            catch
            {
            }

        }

        protected void gridview_AttendanceRegisterEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
            int DepartmentID = TheEmployee.DepartmentID;

            string dt = DateTime.Parse(txt_SelectDate.Text).ToString(MicroConstants.DateFormat);
            gridview_AttendanceRegisterEmployee.PageIndex = e.NewPageIndex;
            BindGridView(DepartmentID, dt);
        }

        protected void gridview_AttendanceRegisterEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            PageVariables.RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                PageVariables.RowIndex = Convert.ToInt32(e.CommandArgument);

            }
            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {
                BindDropDownList();
                lblID.Text = ((int)gridview_AttendanceRegisterEmployee.DataKeys[PageVariables.RowIndex].Value).ToString();
                lblusername.Text = gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].Cells[1].Text;

                txt_EmpCode.Text = gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].Cells[2].Text;
                txt_Designation.Text = gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].Cells[3].Text;

                if (gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex] != null)
                {
                    Label txtMon = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Mon");
                    Label txtTue = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Tue");
                    Label txtWed = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Wed");
                    Label txtThu = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Thu");
                    Label txtFri = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Fri");
                    Label txtSat = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Sat");
                    Label txtSun = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Sun");

                    if (!string.IsNullOrEmpty(txtMon.Text))
                    {
                        ddl_Mon.SelectedIndex = GetDropDownSelectedIndex(ddl_Mon, txtMon.Text);
                    }
                    if (!string.IsNullOrEmpty(txtTue.Text))
                    {
                        ddl_Tue.SelectedIndex = GetDropDownSelectedIndex(ddl_Tue, txtTue.Text);
                    }
                    if (!string.IsNullOrEmpty(txtWed.Text))
                    {
                        ddl_Wed.SelectedIndex = GetDropDownSelectedIndex(ddl_Wed, txtWed.Text);
                    }
                    if (!string.IsNullOrEmpty(txtThu.Text))
                    {
                        ddl_Thu.SelectedIndex = GetDropDownSelectedIndex(ddl_Thu, txtThu.Text);
                    }
                    if (!string.IsNullOrEmpty(txtFri.Text))
                    {
                        ddl_Fri.SelectedIndex = GetDropDownSelectedIndex(ddl_Fri, txtFri.Text);
                    }
                    if (!string.IsNullOrEmpty(txtSat.Text))
                    {
                        ddl_Sat.SelectedIndex = GetDropDownSelectedIndex(ddl_Sat, txtSat.Text);
                    }
                    if (!string.IsNullOrEmpty(txtSun.Text))
                    {
                        ddl_Sun.SelectedIndex = GetDropDownSelectedIndex(ddl_Sun, txtSun.Text);
                    }
                }



                this.ModalPopupExtender1.Show();
            }
        }

        protected void gridview_AttendanceRegisterEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = 0;
            Label txtMon = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Mon");
            Label txtTue = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Tue");
            Label txtWed = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Wed");
            Label txtThu = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Thu");
            Label txtFri = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Fri");
            Label txtSat = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Sat");
            Label txtSun = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_Sun");

            txtMon.Text = ddl_Mon.SelectedItem.Text;
            txtTue.Text = ddl_Tue.SelectedItem.Text;
            txtWed.Text = ddl_Wed.SelectedItem.Text;
            txtThu.Text = ddl_Thu.SelectedItem.Text;
            txtFri.Text = ddl_Fri.SelectedItem.Text;
            txtSat.Text = ddl_Sat.SelectedItem.Text;
            txtSun.Text = ddl_Sun.SelectedItem.Text;
            txtSun.Text = ddl_Sun.SelectedItem.Text;

            Label ShiftScheduleForWeekDay = (Label)gridview_AttendanceRegisterEmployee.Rows[PageVariables.RowIndex].FindControl("lbl_ShiftScheduleForWeekDay");
            int thisEmployeeID = (int)gridview_AttendanceRegisterEmployee.DataKeys[PageVariables.RowIndex].Value;

            List<ShiftSchedule> ThisShiftScheduleList = ShiftScheduleManagement.GetInstance.GetShiftSchedulesAll();
            List<ShiftSchedule> GetShiftSheduleListByEmployeeID = ThisShiftScheduleList.Where(ss => ss.EmployeeID.Equals(thisEmployeeID) && ss.ShiftScheduleForDate.Equals(txt_SelectDate.Text)).ToList();
            if (GetShiftSheduleListByEmployeeID.Count > 0)
            {
                foreach (ShiftSchedule theShiftSchedule in GetShiftSheduleListByEmployeeID)
                {
                    if (theShiftSchedule.ShiftScheduleID > 0)
                    {
                        if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((int)MicroEnums.WeekNameAlias.MON))
                        {
                            if (ddl_Mon.SelectedIndex > 0)
                                theShiftSchedule.ShiftTimingID = int.Parse(ddl_Mon.SelectedValue);
                            else
                                theShiftSchedule.ShiftTimingID = 0;
                        }
                        else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((int)MicroEnums.WeekNameAlias.TUE))
                        {
                            if (ddl_Tue.SelectedIndex > 0)
                                theShiftSchedule.ShiftTimingID = int.Parse(ddl_Tue.SelectedValue);
                            else
                                theShiftSchedule.ShiftTimingID = 0;
                        }
                        else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((int)MicroEnums.WeekNameAlias.WED))
                        {
                            if (ddl_Wed.SelectedIndex > 0)
                                theShiftSchedule.ShiftTimingID = int.Parse(ddl_Wed.SelectedValue);
                            else
                                theShiftSchedule.ShiftTimingID = 0;
                        }
                        else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((int)MicroEnums.WeekNameAlias.THU))
                        {
                            if (ddl_Thu.SelectedIndex > 0)
                                theShiftSchedule.ShiftTimingID = int.Parse(ddl_Thu.SelectedValue);
                            else
                                theShiftSchedule.ShiftTimingID = 0;
                        }
                        else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((int)MicroEnums.WeekNameAlias.FRI))
                        {
                            if (ddl_Fri.SelectedIndex > 0)
                                theShiftSchedule.ShiftTimingID = int.Parse(ddl_Fri.SelectedValue);
                            else
                                theShiftSchedule.ShiftTimingID = 0;
                        }
                        else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((int)MicroEnums.WeekNameAlias.SAT))
                        {
                            if (ddl_Sat.SelectedIndex > 0)
                                theShiftSchedule.ShiftTimingID = int.Parse(ddl_Sat.SelectedValue);
                            else
                                theShiftSchedule.ShiftTimingID = 0;
                        }
                        else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((int)MicroEnums.WeekNameAlias.SUN))
                        {
                            if (ddl_Sun.SelectedIndex > 0)
                                theShiftSchedule.ShiftTimingID = int.Parse(ddl_Sun.SelectedValue);
                            else
                                theShiftSchedule.ShiftTimingID = 0;
                        }

                        ProcReturnValue = ShiftScheduleManagement.GetInstance.UpdateShiftSchedule(theShiftSchedule);
                    }
                }



            }

            else
            {
                for (int col = 1; col <= 7; col++)
                {
                    DateTime dt = DateTime.Parse(txt_SelectDate.Text);
                    PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
                    Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);

                    DateTime WeekStartDate = dt.Date.AddDays(-(int)dt.Date.DayOfWeek + 1);
                    DateTime CurDate = WeekStartDate.AddDays(col - 1);
                    String WkDay = CurDate.DayOfWeek.ToString().Substring(0, 3).ToUpper();
                    String WkDayNameFull = CurDate.DayOfWeek.ToString().ToUpper();

                    ShiftSchedule theShiftSchedule = new ShiftSchedule();

                    theShiftSchedule.ShiftScheduleForWeekDay = col;
                    theShiftSchedule.ShiftScheduleForWeekDayName = WkDayNameFull;
                    theShiftSchedule.DepartmentID = TheEmployee.DepartmentID;
                    theShiftSchedule.ShiftScheduleForDate = WeekStartDate.AddDays(col - 1);

                    theShiftSchedule.EmployeeID = thisEmployeeID;
                    if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((1)))
                    {
                        theShiftSchedule.ShiftTimingID = int.Parse(ddl_Mon.SelectedValue);
                    }
                    else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((2)))
                    {
                        theShiftSchedule.ShiftTimingID = int.Parse(ddl_Tue.SelectedValue);
                    }
                    else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((3)))
                    {
                        theShiftSchedule.ShiftTimingID = int.Parse(ddl_Wed.SelectedValue);
                    }
                    else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((4)))
                    {
                        theShiftSchedule.ShiftTimingID = int.Parse(ddl_Thu.SelectedValue);
                    }
                    else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((5)))
                    {
                        theShiftSchedule.ShiftTimingID = int.Parse(ddl_Fri.SelectedValue);
                    }
                    else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((6)))
                    {
                        theShiftSchedule.ShiftTimingID = int.Parse(ddl_Sat.SelectedValue);
                    }
                    else if (theShiftSchedule.ShiftScheduleForWeekDay.Equals((7)))
                    {
                        theShiftSchedule.ShiftTimingID = int.Parse(ddl_Sun.SelectedValue);
                    }
                    ProcReturnValue = ShiftScheduleManagement.GetInstance.InsertShiftSchedule(theShiftSchedule, AllowRescheduleOfPastShiftSchedules);
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "ShiftSchedule for This Week", MicroEnums.DataOperation.AddNew);
                }
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();

            ResetTextBoxes();


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }


        #endregion

        #region Methods & Implementation
       
        private void BindDropDownList()
        {
            BindDropdown_ShiftSchedules();
        }

        private void BindDropdown_ShiftSchedules()
        {
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);

            foreach (Control theControl in pnlpopup.Controls)
            {
                if (theControl.GetType().Equals(typeof(DropDownList)))
                {
                    DropDownList theddl = (DropDownList)theControl;

                    theddl.DataSource = ShiftTimingsManagement.GetInstance.GetShiftTimingsByOfficeIDandDepartmentID(TheEmployee.DepartmentID);
                    theddl.DataTextField = ShiftTimingsManagement.GetInstance.DisplayMember;
                    theddl.DataValueField = ShiftTimingsManagement.GetInstance.ValueMember;
                    theddl.DataBind();
                    theddl.Items.Insert(0, "None");
                }
            }
            ////ddl_Sun.Items.Insert(0, "  ");
        }

        private void SetValidationMessages()
        {


            SetFormMessageCSSClass("ValidateMessage");

        }

        private void SetFormMessageCSSClass(string theClassName)
        {

        }

        private void BindGridView(int departmentID, string date)
        {
            List<Employee> EmployeeList = new List<Employee>();
            EmployeeList = EmployeeManagement.GetInstance.GetEmployeeListByOfficeandDepartment(departmentID);

            gridview_AttendanceRegisterEmployee.DataSource = EmployeeList;
            gridview_AttendanceRegisterEmployee.DataBind();

            foreach (GridViewRow theRow in gridview_AttendanceRegisterEmployee.Rows)
            {
                Label theShiftScheduleForWeekDay = (Label)theRow.FindControl("lbl_ShiftScheduleForWeekDay");
                Label theMon = (Label)theRow.FindControl("lbl_Mon");
                Label theTue = (Label)theRow.FindControl("lbl_Tue");
                Label theWed = (Label)theRow.FindControl("lbl_Wed");
                Label theThu = (Label)theRow.FindControl("lbl_Thu");
                Label theFri = (Label)theRow.FindControl("lbl_Fri");
                Label theSat = (Label)theRow.FindControl("lbl_Sat");
                Label theSun = (Label)theRow.FindControl("lbl_Sun");

                int employeeID = (int)gridview_AttendanceRegisterEmployee.DataKeys[theRow.RowIndex].Value;
                List<ShiftSchedule> thisShiftScheduleList = ShiftScheduleManagement.GetInstance.GetShiftSchedulesByDepartment(departmentID, date);

                var thisShiftScheduleListbyeEmployeeID = thisShiftScheduleList.Where(emp => emp.EmployeeID.Equals(employeeID)).ToList();

                foreach (ShiftSchedule theShiftSchedule in thisShiftScheduleListbyeEmployeeID)
                {
                    switch (theShiftSchedule.ShiftScheduleForWeekDay)
                    {
                        case 1:
                            theSun.Text = theShiftSchedule.ShiftTiming.ShiftAlias;
                            break;
                        case 2:
                            theMon.Text = theShiftSchedule.ShiftTiming.ShiftAlias;
                            break;
                        case 3:
                            theTue.Text = theShiftSchedule.ShiftTiming.ShiftAlias;
                            break;
                        case 4:
                            theWed.Text = theShiftSchedule.ShiftTiming.ShiftAlias;
                            break;
                        case 5:
                            theThu.Text = theShiftSchedule.ShiftTiming.ShiftAlias;
                            break;
                        case 6:
                            theFri.Text = theShiftSchedule.ShiftTiming.ShiftAlias;
                            break;
                        case 7:
                            theSat.Text = theShiftSchedule.ShiftTiming.ShiftAlias;
                            break;
                    }
                }
            }
            if (!(Connection.LoggedOnUser.CanAccessAllOffices))
            {
                BasePage.HideGridViewColumn(gridview_AttendanceRegisterEmployee, "Edit");
            }
        }

        public void ResetSchedules(ref DataTable Dt)
        {
            foreach (DataRow dr in Dt.Rows)
            {
                for (int i = 1; i <= 7; i++)
                {
                    string WkDay = CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(i == 7 ? 0 : i)].ToString().ToUpper().Substring(0, 3);
                    dr["wkDay" + WkDay] = "";
                }
            }
        }

        private void ResetTextBoxes()
        {
            
            txt_Designation.Text = string.Empty;
            txt_EmpCode.Text = string.Empty;
            
            PageVariables.ThisShiftSchedule = null;

        }

        private void BindGridviewDateColumn()
        {

            DateTime dt = DateTime.Parse(txt_SelectDate.Text);
            lbl_WeekStartDate.Text = (dt.AddDays(1 - (int)dt.DayOfWeek)).ToShortDateString();
            DateTime dt1 = DateTime.Parse(lbl_WeekStartDate.Text);
            int Counter = 0;
            int j = 1;
            for (int i = 4; i < gridview_AttendanceRegisterEmployee.Columns.Count - 1; i++)
            {

                if (Counter.Equals(0))
                {
                    String wkDayName = dt1.AddDays(j - 1).DayOfWeek.ToString().Substring(0, 3).ToUpper();
                    gridview_AttendanceRegisterEmployee.Columns[i].HeaderText = String.Format("{0}({1})", dt1.AddDays(j - 1).ToString("dd-MMM").ToUpper(), wkDayName);
                }
                else
                {
                    String wkDayName = dt1.AddDays(j - 1).DayOfWeek.ToString().Substring(0, 3).ToUpper();
                    gridview_AttendanceRegisterEmployee.Columns[i].HeaderText = String.Format("{0}({1})", dt1.AddDays(j - 1).ToString("dd-MMM").ToUpper(), wkDayName);
                }
                // string name = gview_OldDisplay.Rows[i].Cells[2].Text;
                Counter = Counter + 1;
                j = j + 1;
            }
        }

        #endregion

    }
}