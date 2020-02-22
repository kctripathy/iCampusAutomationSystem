using Micro.BusinessLayer.HumanResource;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.Commons;
using Micro.Objects.HumanResource;
using Micro.Objects.ICAS.STUDENT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCon.iCAS.WebApplication
{
    public partial class SendSMS : BasePage
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
            int sendSuccess = 0;
            int sendFailure = 0;
            for (int i = 0; i < grdview_Staffs.Rows.Count; i++)
            {
                GridViewRow row = grdview_Staffs.Rows[i];
                CheckBox chkb = (CheckBox)row.FindControl("chk_EmployeeID");
                if (chkb.Checked)
                {
                    Label empID = (Label)row.FindControl("lbl_EmployeeID");
                    string phoneNumber = row.Cells[2].Text.ToString();
                    if (phoneNumber.Trim().Equals(string.Empty) || phoneNumber.Trim().Equals("&nbsp;"))
                    {
                        continue;
                    }
                    else
                    {
                        // SEND A SMS
                        string receipientName = row.Cells[1].Text.ToString();
                        string status = SendSMSNow(phoneNumber, receipientName);
                        if (status == "OK")
                        {
                            sendSuccess++;
                        }
                        else
                        {
                            sendFailure++;
                        }
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
                        string receipientName = row.Cells[1].Text.ToString();
                        string status = SendSMSNow(phoneNumber, receipientName);
                        if (status == "OK")
                        {
                            sendSuccess++;
                        }
                        else
                        {
                            sendFailure++;
                        }
                    }
                    Ctr++;

                }
            }
            lblStatus.Text = "";
            lblStatus.Text = string.Format("Successfully sent SMS to {0} person(s)", sendSuccess);
            if (sendFailure > 0)
            {
                lblStatus.Text += string.Format(" & failed to sent to {0} person(s)", sendFailure);
            }
        }

        private List<Employee> GetStaffList()
        {
            string UniqueKey = string.Concat("GetStaffList_sms");
            if (HttpRuntime.Cache[UniqueKey] == null)
            {

                List<Employee> staffList = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
                List<Employee> staffList2sms = (from s in staffList
                                                where (!s.Mobile.Trim().Equals("") && s.Mobile.Length == 10)
                                                select s).ToList();
                HttpRuntime.Cache[UniqueKey] = staffList2sms;
                lblStaffCount.Text = string.Format("({0})",staffList2sms.Count);
            }
             return (List<Employee>)(HttpRuntime.Cache[UniqueKey]);
        }



        private List<Student> GetStudentList()
        {
            string UniqueKey = string.Concat("GetStudentList_sms");
            if (HttpRuntime.Cache[UniqueKey] == null)
            {

                List<Student> studentList1 = StudentManagement.GetInstance.GetStudentList();
                List<Student> studentList = (from s in studentList1
                                             where (!s.Mobile.Trim().Equals("") && s.Mobile.Length == 10)
                                             select s).ToList();
                HttpRuntime.Cache[UniqueKey] = studentList;
            }
            List<Student> theStudentList = (List<Student>)(HttpRuntime.Cache[UniqueKey]);
            List<Student> theFilteredStudent1 =  new List<Student>();
            foreach (ListItem l in rblist_classes.Items)
            {
                if (l.Selected == true && l.Value == "0")
                {
                    theFilteredStudent1 = theStudentList;
                }
                else if (l.Selected == true)
                { 
                 theFilteredStudent1 = (from ss in theStudentList
                                      where ss.ClassID.ToString() == l.Value
                                      select ss).ToList();

                //theFilteredStudent1.Concat(theFilteredStudent);
                //theFilteredStudent1.Insert(0,theFilteredStudent);
                }
            }
            lblTextCount.Text = string.Format("- {0} ({1})", rblist_classes.SelectedItem.Text, theFilteredStudent1.Count);
            return theFilteredStudent1;

        }

        /// <summary>
        /// Courtesty - c-sharpcorner.com/UploadFile/francissvk/Asp-Net-how-to-send-sms-from-my-web-application/
        /// </summary>
        /// <param name="mobileNumber"></param>
        private string SendSMSNow(string mobileNumber, string receipientName)
        {
            // use the API URL   
            //string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=YourUserName:YourPassword&senderID=YourSenderID&    receipientno=1234567890&msgtxt=This is a test from mVaayoo API&state=4";
            //string strUrl = @"http://sandeshlive.in/API/WebSMS/Http/v1.0a/index.php?username=jsamal&password=142054&sender=SANDES&to=" + mobileNumber + @"&message=Dear " + receipientName + ", " + txtMessage.Text + " sent From TSDC, BD PUR&reqid=1&format={json|text}&route_id=23";
            string strUrl = @"http://sandeshlive.in/API/WebSMS/Http/v1.0a/index.php?username=1tsdclg&password=Tsd2@1fcg&sender=TSDCLG&to=" + mobileNumber + @"&message=Dear " + receipientName + ", " + txtMessage.Text + "&reqid=1&format={json|text}&route_id=23";

            strUrl = strUrl.Replace("&#160;", " ");
            // Create a request object  
            WebRequest request = HttpWebRequest.Create(strUrl);
            // Get the response back  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();

            HttpStatusCode st = response.StatusCode;
            return st.ToString();
        }

        protected void chkSelectUnselectAllStudents_CheckedChanged(object sender, EventArgs e)
        {
            ////if (chkSelectUnselectAllStudents.Checked == true)
            ////{
            //    foreach(GridViewRow gr in grdview_Staffs.Rows)
            //    {
            //        CheckBox chkb = (CheckBox)gr.FindControl("chk_EmployeeID");
            //        chkb.Checked = chkSelectUnselectAllStudents.Checked;
            //    }
            ////}
        }

        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in grdview_Students.Rows)
            {
                CheckBox chkb = (CheckBox)gr.FindControl("chk_StudentID");
                chkb.Checked = true;
            }
        }

        protected void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in grdview_Students.Rows)
            {
                CheckBox chkb = (CheckBox)gr.FindControl("chk_StudentID");
                chkb.Checked = false;
            }
        }

        protected void ButtonSelectAllStaffs_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in grdview_Staffs.Rows)
            {
                CheckBox chkb = (CheckBox)gr.FindControl("chk_EmployeeID");
                chkb.Checked = true;
            }
        }

        protected void ButtonUnSelectAllStaffs_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in grdview_Staffs.Rows)
            {
                CheckBox chkb = (CheckBox)gr.FindControl("chk_EmployeeID");
                chkb.Checked = false;
            }
        }

        protected string GetClassName(int classid)
        {

            //9	+2 FIRST YEAR ARTS
            //2	+2 FIRST YEAR SCIENCE
            //10	+2 SECOND YEAR ARTS
            //3	+2 SECOND YEAR SCIENCE
            //12	+3 FIRST YEAR ARTS
            //5	+3 FIRST YEAR SCIENCE
            //13	+3 SECOND YEAR ARTS
            //6	+3 SECOND YEAR SCIENCE
            //14	+3 THIRD YEAR ARTS
            //7	+3 THIRD YEAR SCIENCE
            string class_name = string.Empty;
            switch (classid)
            {
                case 9: class_name = "+2 FIRST YEAR ARTS"; break;
                case 2: class_name = "+2 FIRST YEAR SCIENCE"; break;
                case 10: class_name = "+2 SECOND YEAR ARTS"; break;
                case 3: class_name = "+2 SECOND YEAR SCIENCE"; break;
                case 12: class_name = "+3 FIRST YEAR ARTS"; break;
                case 5: class_name = "+3 FIRST YEAR SCIENCE"; break;
                case 13: class_name = "+3 SECOND YEAR ARTS"; break;
                case 6: class_name = "+3 SECOND YEAR SCIENCE"; break;
                case 14: class_name = "+3 THIRD YEAR ARTS"; break;
                case 7: class_name = "+3 THIRD YEAR SCIENCE"; break;
            }

            //return string.Format("Class {0}", classid);
            return class_name;
        }
    }
}