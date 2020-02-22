using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using System.Data;
using Micro.Objects.HumanResource;
using Micro.BusinessLayer.HumanResource;
using System.Globalization;
using Micro.Framework.ReadXML;

namespace Micro.WebApplication.MicroERP.HRMS
{
    public partial class ShiftSchedules : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {
            public static int TheUserReferenceID;
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            multiView_ShiftSchedules.SetActiveView(view_InputControls);
            
            if (!IsPostBack)
            {
                BindDropDownList();
                SetValidationMessages();
                txt_SelectDate.Text = DateTime.Now.ToShortDateString();

                
            }
            BindGridviewDateColumn();
        }

        protected void btn_ShowSchedules_Click(object sender, EventArgs e)
        {
            try
            {

                int DepartmentID = int.Parse(ddl_SelectDepartment.SelectedValue);
                string dt = DateTime.Parse(txt_SelectDate.Text).ToString(MicroConstants.DateFormat);

                BindGridView(DepartmentID, dt);
            }
            catch
            {
            }



        }

        protected void ddl_SelectDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DepartmentID = int.Parse(ddl_SelectDepartment.SelectedValue);
            string dt = DateTime.Parse(txt_SelectDate.Text).ToString(MicroConstants.DateFormat);

            BindGridView(DepartmentID, dt);
        }

        protected void gview_ShiftSchedules_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gview_ShiftSchedules.PageIndex = e.NewPageIndex;
            //BindGridView();
        }

        #endregion

        #region Methods & Implementation

        private void BindDropDownList()
        {
            BindDropdown_Department();
            BindDropdown_AppendSelectToFirst();
        }

        private void BindDropdown_Department()
        {
            ddl_SelectDepartment.DataSource = DepartmentManagement.GetInstance.GetDepartmentsListByOffice();
            ddl_SelectDepartment.DataTextField = DepartmentManagement.GetInstance.DisplayMember;
            ddl_SelectDepartment.DataValueField = DepartmentManagement.GetInstance.ValueMember;
            ddl_SelectDepartment.DataBind();
        }

        private void BindDropdown_AppendSelectToFirst()
        {
            ddl_SelectDepartment.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }

        private void SetValidationMessages()
        {

            requiredFieldValidator_SelectDepartment.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;

            requiredFieldValidator_SelectDepartment.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Department");
            SetFormMessageCSSClass("ValidateMessage");

        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_SelectDepartment.CssClass = theClassName;           
        }

        private void BindGridView(int departmentID, string date)
        {
            List<Employee> EmployeeList = new List<Employee>();
            EmployeeList = EmployeeManagement.GetInstance.GetEmployeeListByOfficeandDepartment(departmentID);

            gview_ShiftSchedules.DataSource = EmployeeList;
            gview_ShiftSchedules.DataBind();

            foreach (GridViewRow theRow in gview_ShiftSchedules.Rows)
            {
                Label theMon = (Label)theRow.FindControl("lbl_Mon");
                Label theTue = (Label)theRow.FindControl("lbl_Tue");
                Label theWed = (Label)theRow.FindControl("lbl_Wed");
                Label theThu = (Label)theRow.FindControl("lbl_Thu");
                Label theFri = (Label)theRow.FindControl("lbl_Fri");
                Label theSat = (Label)theRow.FindControl("lbl_Sat");
                Label theSun = (Label)theRow.FindControl("lbl_Sun");

                int employeeID = (int)gview_ShiftSchedules.DataKeys[theRow.RowIndex].Value;
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
        }

        private  void BindGridviewDateColumn()
        {
            DateTime dt = DateTime.Parse(txt_SelectDate.Text);
            lbl_WeekStartDate.Text = (dt.AddDays(1 - (int)dt.DayOfWeek)).ToShortDateString();
            DateTime dt1 = DateTime.Parse(lbl_WeekStartDate.Text);
            int Counter = 0;
            int j = 1;
            for (int i = 4; i < gview_ShiftSchedules.Columns.Count; i++)
            {

                if (Counter.Equals(0))
                {
                    String wkDayName = dt1.AddDays(j - 1).DayOfWeek.ToString().Substring(0, 3).ToUpper();
                    gview_ShiftSchedules.Columns[i].HeaderText = String.Format("{0}({1})", dt1.AddDays(j - 1).ToString("dd-MMM").ToUpper(), wkDayName);
                }
                else
                {
                    String wkDayName = dt1.AddDays(j - 1).DayOfWeek.ToString().Substring(0, 3).ToUpper();
                    gview_ShiftSchedules.Columns[i].HeaderText = String.Format("{0}({1})", dt1.AddDays(j - 1).ToString("dd-MMM").ToUpper(), wkDayName);
                }
                // string name = gview_OldDisplay.Rows[i].Cells[2].Text;
                Counter = Counter + 1;
                j = j + 1;
            }
        }

        #endregion
        
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

       
    }
}