using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.Objects.ICAS.STAFFS;

namespace LTPL.ICAS.WebApplication.iCAS
{
    public partial class STAFFS : System.Web.UI.Page
    {
        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
        public static class PageVar
        {
            public static List<StaffMaster> StaffMasterList
            {
                get
                {
                    List<StaffMaster> TheStaffMasterList = HttpContext.Current.Session["StaffMasterList"] as List<StaffMaster>;
                    return TheStaffMasterList;
                }
                set
                {
                    HttpContext.Current.Session.Add("StaffMasterList", value);
                }
            }
        }


        private void BindDetailViewStaff(int staffId)
        {
            optCategory.Visible = false;

            if (PageVar.StaffMasterList == null)
            {
                PageVar.StaffMasterList = StaffMasterManagement.GetInstance.GetOfficeEmployeeList();
            }
            StaffMaster theStaff = new StaffMaster();
            theStaff = PageVar.StaffMasterList.Find(a => a.EmployeeID == staffId);

            lit_StaffDetails.Text = "";
            if (theStaff == null)
            {
                lit_StaffDetails.Text = string.Format("NO SUCH RECORD AVAILABLE FOR: <span class='Name'>{0} </span>", staffId);
                return;
            }
            else
            {

                //optCategory.SelectedIndex = -1;
                lit_StaffDetails.Text = string.Format("Detail Information of the Staff:- <span class='Name'>    {0} {1} - </span><span class='Desig'>{2}</span> <span class='dept'>({3})</span>", theStaff.Salutation, theStaff.EmployeeName, theStaff.DesignationDescription, theStaff.DepartmentDescription);
            }

            PropertyInfo[] propertiesStudent = theStaff.GetType().GetProperties();

            StringBuilder sbStaffDetails = new StringBuilder("<ul id='StaffDetailsView' class='StaffDetails'>");
            //Display Details
            //sbStaffDetails.Append(string.Format("<li class='FullRow'></li>", pi.Name, theVar, ctr));
            int ctr = 0;
            foreach (PropertyInfo pi in propertiesStudent)
            {
                ctr++;
                if (ctr > 1) // don't print the first row, as it it is the Employee ID column
                {
                    string theVar = string.Concat(pi.GetValue(theStaff, null), "&nbsp;");
                    sbStaffDetails.Append(string.Format("<li class='theName'>{2}. {0}</li><li class='theValue'>{1}</li>", pi.Name, theVar, ctr));
                }
            }
            sbStaffDetails.Append("</ul>");

            //studentDeails.InnerText = sbStaffDetails.ToString();
            lit_StaffDetailsInfo.Text = sbStaffDetails.ToString();


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int staffId = int.Parse(Request.QueryString["ID"].ToString());
                BindDetailViewStaff(staffId);
                //Student_Multi.SetActiveView(View_detail_Student);
                return;
            }
            optCategory.Enabled = true;
            if (!IsPostBack)
            {
                PageVar.StaffMasterList = StaffMasterManagement.GetInstance.GetOfficeEmployeeList();
                if (Request.QueryString["Category"] == null || Request.QueryString["Category"].ToString() == "A")
                {
                    //BindGridView("A");
                    optCategory.SelectedIndex = 0;
                    optCategory_OnSelectedIndexChanged(null, null);
                }
                else if (Request.QueryString["Category"].ToString() == "T")
                {
                    BindGridView("T");
                    optCategory.SelectedIndex = 1;
                    //optCategory_OnSelectedIndexChanged(null, null);
                }
                else if (Request.QueryString["Category"].ToString() == "N")
                {
                    BindGridView("N");
                    optCategory.SelectedIndex = 2;
                    //optCategory_OnSelectedIndexChanged(null, null);
                }


                AddRowSpanToGridView();
                //optCategory.SelectedIndex = 0;
            }
        }


        protected void optCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (optCategory.SelectedIndex != -1)
            {
                string category = optCategory.SelectedValue.ToString();
                lit_PageTitle.Text = optCategory.SelectedItem.Text.Trim();
                BindGridView(category);
                AddRowSpanToGridView();
            }
        }

        //public void BindGridView()
        //{
        //    //List<StaffMaster> StaffMasterList = StaffMasterManagement.GetInstance.GetOfficeEmployeeList();
        //    PageVar.StaffMasterList = StaffMasterManagement.GetInstance.GetOfficeEmployeeList();
        //    gview_Employee.DataSource = PageVar.StaffMasterList;
        //    gview_Employee.DataBind();
        //}

        public void BindGridView(string empCategory)
        {
            if (PageVar.StaffMasterList == null)
            {
                PageVar.StaffMasterList = StaffMasterManagement.GetInstance.GetOfficeEmployeeList();
            }
            List<StaffMaster> StaffMasterListNew = new List<StaffMaster>();

            if (empCategory.Equals("A"))
            {
                lbl_StaffCategory.Text = " -- ALL STAFFS --";
                StaffMasterListNew = (
                               from abc in PageVar.StaffMasterList
                               select abc
               ).OrderBy(x => x.DepartmentDescription).ThenBy(y => y.EmployeeID).ToList();
            }
            else if (empCategory.Equals("T"))
            {
                lbl_StaffCategory.Text = " -- ALL TEACHING STAFFS --";
                StaffMasterListNew = (
                               from abc in PageVar.StaffMasterList
                               where abc.TeachingOrNonTeaching == "T"
                               select abc
               ).OrderByDescending(x => x.DepartmentDescription).ThenBy(y => y.EmployeeID).ToList();
            }
            else if (empCategory.Equals("N"))
            {
                lbl_StaffCategory.Text = " -- ALL NON-TEACHING STAFFS --";
                StaffMasterListNew = (
                               from abc in PageVar.StaffMasterList
                               where abc.TeachingOrNonTeaching == "N"
                               select abc
               ).OrderByDescending(x => x.DepartmentDescription).ThenBy(y => y.EmployeeID).ToList();
            }
            // else
            //{
            //    StaffMasterListNew = (
            //                   from abc in PageVar.StaffMasterList
            //                   where abc.TeachingOrNonTeaching.Equals(empCategory)
            //                   select abc
            //   ).OrderByDescending(x => x.DepartmentDescription).ThenBy(y => y.EmployeeID).ToList();
            //}

            gview_Employee.DataSource = StaffMasterListNew;
            gview_Employee.DataBind();
        }

        public void AddRowSpanToGridView()
        {
            for (int rowIndex = gview_Employee.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow currentRow = gview_Employee.Rows[rowIndex];
                GridViewRow previousRow = gview_Employee.Rows[rowIndex + 1];

                //for (int i = 0; i < currentRow.Cells.Count; i++)
                for (int i = 0; i < 1; i++)
                {
                    if (currentRow.Cells[i].Text == previousRow.Cells[i].Text)
                    {
                        if (previousRow.Cells[i].RowSpan < 2)
                        {
                            currentRow.Cells[i].RowSpan = 2;
                        }
                        else
                            currentRow.Cells[i].RowSpan = previousRow.Cells[i].RowSpan + 1;
                        previousRow.Cells[i].Visible = false;
                    }
                }
            }
        }


        protected void gview_Employee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gview_Employee.PageIndex = e.NewPageIndex;


                string category = optCategory.SelectedValue.ToString();
                lit_PageTitle.Text = optCategory.SelectedItem.Text.Trim();
                BindGridView(category);
                AddRowSpanToGridView();


                //lit_PageCounter.Text = string.Format("Page <b>{0}</b> of {1}", e.NewPageIndex + 1, gview_Employee.PageCount);

            }
            catch
            {
            }
        }

        protected void lnkViewAllStaffs_Click(object sender, EventArgs e)
        {
            BindGridView("A");
            optCategory.Visible = true;
        }
    }
}