using Micro.BusinessLayer.HumanResource;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.Commons;
using Micro.Objects.HumanResource;
using Micro.Objects.ICAS.STUDENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCon.iCAS.WebApplication
{
    public partial class SendEmail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSelectAllStudents_Click(object sender, EventArgs e)
        {

        }

        protected void btnSelectAllStaffs_Click(object sender, EventArgs e)
        {

        }

        protected void chk_Students_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chk_Staffs_CheckedChanged(object sender, EventArgs e)
        {

        }


        protected void btnShowRecords_Click(object sender, EventArgs e)
        {
            if (chk_Staffs.Checked)
            {
                grdview_Staffs.DataSource = GetStaffList();
                grdview_Staffs.DataBind();
            }
            else
            {
                grdview_Staffs.DataSource = null;
                grdview_Staffs.DataBind();

            }
            if (chk_Students.Checked)
            {
                grdview_Students.DataSource = GetStudentList();
                grdview_Students.DataBind();
            }
            else
            {
                grdview_Students.DataSource = null;
                grdview_Students.DataBind();

            }
        }

        protected void btnSendSMS_Click(object sender, EventArgs e)
        {
            int Ctr = 0;
            for (int i = 0; i < grdview_Staffs.Rows.Count; i++)
            {
                GridViewRow row = grdview_Staffs.Rows[i];
                CheckBox chkb = (CheckBox)row.FindControl("chk_EmployeeID");
                if (chkb.Checked)
                {
                    Label empID = (Label)row.FindControl("lbl_EmployeeID");
                    string phoneNumber = row.Cells[2].Text.ToString();
                    if (phoneNumber.Trim().Equals(string.Empty) || phoneNumber.Trim().Equals("&nbsp;") )
                    {
                        continue;
                    }
                    else
                    {
                        // SEND A SMS
                    }
                    Ctr++;
                }
            }

            Ctr = 0;
            for (int i = 0; i < grdview_Students.Rows.Count; i++)
            {
                GridViewRow row = grdview_Students.Rows[i];
                CheckBox chkb = (CheckBox)row.FindControl("chk_StudentID");
                if (chkb.Checked)
                {
                    Label empID = (Label)row.FindControl("lbl_StudentID");
                    string phoneNumber = row.Cells[2].Text.ToString();
                    if (phoneNumber.Trim().Equals(string.Empty) || phoneNumber.Trim().Equals("&nbsp;"))
                    {
                        continue;
                    }
                    else
                    {
                        // SEND A SMS
                    }
                    Ctr++;

                }
            }

        }

        private List<Employee> GetStaffList()
        {
            string UniqueKey = string.Concat("GetStaffList");
            if (HttpRuntime.Cache[UniqueKey] == null)
            {

                List<Employee> staffList = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
                HttpRuntime.Cache[UniqueKey] = staffList;
            }
            return (List<Employee>)(HttpRuntime.Cache[UniqueKey]);
        }

        private List<Student> GetStudentList()
        {
            string UniqueKey = string.Concat("GetStudentList");
            if (HttpRuntime.Cache[UniqueKey] == null)
            {

                List<Student> studentList = StudentManagement.GetInstance.GetStudentList();
                HttpRuntime.Cache[UniqueKey] = studentList;
            }
            return (List<Student>)(HttpRuntime.Cache[UniqueKey]);
        }


    }
}