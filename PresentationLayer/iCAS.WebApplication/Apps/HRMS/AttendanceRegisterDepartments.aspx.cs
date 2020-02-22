using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.HumanResource;
using Micro.BusinessLayer.HumanResource;
using System.Globalization;

namespace Micro.WebApplication.MicroERP.HRMS
{
    public partial class AttendanceRegisterDepartments : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {
            public static int TheUserReferenceID;
            public static int count = 0;
            public static List<Attendance> AttendanceList;



            
        }


        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void btn_ShowAttendence_Click(object sender, EventArgs e)
        {
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
            int DepartmentID = TheEmployee.DepartmentID;

            PageVariables.AttendanceList = AttendanceManagement.GetInstance.GetEmployeeDetailsAttendanceRegisterSummaryByDepartmentID(TheEmployee.DepartmentID, (ddl_SelectMonth.Text != "" ? ddl_SelectMonth.SelectedIndex : DateTime.Today.Month), (ddl_SelectYear.Text != "" ? int.Parse(ddl_SelectYear.Text) : DateTime.Today.Year));
            gridview_AttendanceRegisterEmployee.DataSource = PageVariables.AttendanceList;
            gridview_AttendanceRegisterEmployee.DataBind();
        }
       



      
       
    


     

      


       

       

        #endregion

        #region Methods & Implementation

        private void BindDropDownList()
        {
            BindDropdown_Year();
            BindDropdown_Month();

        }

        private void BindDropdown_Year()
        {
            int i = 2009;
            ddl_SelectMonth.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            for (i = 2009; i < DateTime.Today.Year + 1; i++)
            {

                ddl_SelectYear.Items.Add(i.ToString());
            }
            ddl_SelectYear.Text = DateTime.Today.Year.ToString();
        }

        private void BindDropdown_Month()
        {
            DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
            // ddl_SelectMonth.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);

            for (int i = 1; i < 13; i++)
            {
                ddl_SelectMonth.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));

            }
        }

      

        #endregion
    
    
    
    
    }
}