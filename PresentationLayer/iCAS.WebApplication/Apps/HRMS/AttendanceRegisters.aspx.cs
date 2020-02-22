using System;
using Micro.Commons;
using System.Collections.Generic;
using Micro.Objects.HumanResource;
using Micro.BusinessLayer.HumanResource;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Globalization;

namespace Micro.WebApplication.MicroERP.HRMS
{
    public partial class AttendanceRegisters : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {
            public static int TheUserReferenceID;
            public static int count = 0;
            public static List<Attendance> AttendanceList;

            //public static List<Attendance> AttendanceList
            //{
            //    get
            //    {
            //        List<Attendance> TheAttendances = HttpContext.Current.Session["AttendanceList"] as List<Attendance>;
            //        return TheAttendances;
            //    }
            //    set
            //    {
            //        HttpContext.Current.Session.Add("AttendanceList", value);
            //    }
            //}

            //public static bool IsPresent;
        }


        #endregion

        #region Events
        protected void btn_ShowAttendence_Click(object sender, EventArgs e)
        {
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
            PageVariables.AttendanceList = AttendanceManagement.GetInstance.GetEmployeeDetailsAttendanceRegister(TheEmployee.EmployeeID, (ddl_SelectMonth.Text != "" ? ddl_SelectMonth.SelectedIndex : DateTime.Today.Month),   (ddl_SelectYear.Text != "" ? int.Parse(ddl_SelectYear.Text) : DateTime.Today.Year));




            gridview_AttendanceRegisterEmployee.DataSource = PageVariables.AttendanceList;
            gridview_AttendanceRegisterEmployee.DataBind();



            int counter = 0;
            if (PageVariables.AttendanceList.Count > 0)
            {
                //foreach (Attendance theAttendance in PageVariables.AttendanceList)
                //{
                counter++;
                //  GridViewRow therow in gview_DesignationSelect.Rows
                foreach (GridViewRow therow in gridview_AttendanceRegisterEmployee.Rows)
                {
                    bool IsPresent = (bool)gridview_AttendanceRegisterEmployee.DataKeys[therow.RowIndex].Values["IsPresent"];
                    bool IsAbsent = (bool)gridview_AttendanceRegisterEmployee.DataKeys[therow.RowIndex].Values["IsAbsent"];
                    bool IsWeeklyOff = (bool)gridview_AttendanceRegisterEmployee.DataKeys[therow.RowIndex].Values["IsWeeklyOff"];
                    bool IsPresentOnWeeklyOff = (bool)gridview_AttendanceRegisterEmployee.DataKeys[therow.RowIndex].Values["IsPresentOnWeeklyOff"];
                    bool IsHoliday = (bool)gridview_AttendanceRegisterEmployee.DataKeys[therow.RowIndex].Values["IsHoliday"];
                    bool IsPresentOnHoliday = (bool)gridview_AttendanceRegisterEmployee.DataKeys[therow.RowIndex].Values["IsPresentOnHoliday"];

                    bool IsLeave = (bool)gridview_AttendanceRegisterEmployee.DataKeys[therow.RowIndex].Values["IsLeave"];

                    CheckBox theCheckBox_IsPresent = (CheckBox)therow.FindControl("chk_Present");
                    CheckBox theCheckBox_IsAbsent = (CheckBox)therow.FindControl("chk_Absent");
                    CheckBox theCheckBox_IsWeeklyOff = (CheckBox)therow.FindControl("chk_IsWeeklyOff");
                    CheckBox theCheckBox_IsPresentOnWeeklyOff = (CheckBox)therow.FindControl("chk_IsPresentOnWeeklyOff");

                    CheckBox theCheckBox_IsHoliday = (CheckBox)therow.FindControl("chk_IsHoliday");
                    CheckBox theCheckBox_IsPresentOnHoliday = (CheckBox)therow.FindControl("chk_IsPresentOnHoliday");

                    CheckBox theCheckBox_IsLeave = (CheckBox)therow.FindControl("chk_IsLeave");
                    if (IsPresent)
                    {
                        theCheckBox_IsPresent.Checked = true;

                    }
                    else
                    {
                        theCheckBox_IsPresent.Checked = false;

                    }
                    if (IsAbsent)
                    {
                        theCheckBox_IsAbsent.Checked = true;
                    }
                    else
                    {
                        theCheckBox_IsAbsent.Checked = false;

                    }
                    if (IsWeeklyOff)
                    {
                        theCheckBox_IsWeeklyOff.Checked = true;
                    }
                    else
                    {
                        theCheckBox_IsWeeklyOff.Checked = false;

                    }

                    if (IsPresentOnWeeklyOff)
                    {
                        theCheckBox_IsPresentOnWeeklyOff.Checked = true;
                    }
                    else
                    {
                        theCheckBox_IsPresentOnWeeklyOff.Checked = false;

                    }

                    if (IsHoliday)
                    {
                        theCheckBox_IsHoliday.Checked = true;
                    }
                    else
                    {
                        theCheckBox_IsHoliday.Checked = false;

                    }

                    if (IsPresentOnHoliday)
                    {
                        theCheckBox_IsPresentOnHoliday.Checked = true;
                    }
                    else
                    {
                        theCheckBox_IsPresentOnHoliday.Checked = false;

                    }


                    if (IsLeave)
                    {
                        theCheckBox_IsLeave.Checked = true;
                    }
                    else
                    {
                        theCheckBox_IsLeave.Checked = false;

                    }


                }
            }
            GridViewRow row = null;
            for (int i = 0; i < gridview_AttendanceRegisterEmployee.Rows.Count; i++)
            {
                row = gridview_AttendanceRegisterEmployee.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("chk_Present")).Checked;


                if (isChecked)
                {
                    PageVariables.count = PageVariables.count + 1;
                }

            }


        }

        protected void gridview_AttendanceRegisterEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }


        int totalAbsent = 0;
        int totalPresent = 0;
        int totalWeeklyOff = 0;
        int totalPresentOnWeeklyOff = 0;
        int totalHoliday = 0;
        int totalPresentOnHoliday = 0;
        int totalLeave = 0;

        protected void gridview_AttendanceRegisterEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalAbsent += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsAbsent"));
                totalPresent += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsPresent"));
                totalWeeklyOff += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsWeeklyOff"));
                totalPresentOnWeeklyOff += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsPresentOnWeeklyOff"));
                totalHoliday += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsHoliday"));
                totalPresentOnHoliday += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsPresentOnHoliday"));
                totalLeave += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, " IsLeave"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblAbsent = (Label)e.Row.FindControl("lbl_TotalAbsent");
                Label lblPrsent = (Label)e.Row.FindControl("lbl_TotalPrsent");
                Label lblWeeklyOff = (Label)e.Row.FindControl("lbl_TotalWeeklyOff");
                Label lblPresentOnWeeklyOff = (Label)e.Row.FindControl("lbl_PresentOnWeeklyOff");
                Label lblHoliday = (Label)e.Row.FindControl("lbl_Holiday");
                Label lblPresentOnHoliday = (Label)e.Row.FindControl("lbl_PresentOnHoliday");
                Label lblLeave = (Label)e.Row.FindControl("lbl_Leave");
                lblAbsent.Text = totalAbsent.ToString();
                lblPrsent.Text = totalPresent.ToString();
                lblWeeklyOff.Text = totalWeeklyOff.ToString();
                lblPresentOnWeeklyOff.Text = totalPresentOnWeeklyOff.ToString();
                lblHoliday.Text = totalHoliday.ToString();
                lblPresentOnHoliday.Text = totalPresentOnHoliday.ToString();
                lblLeave.Text = totalLeave.ToString();
            }

        }

        #endregion
       

    }
}