using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.ICAS.ADMIN;
using Micro.Objects.ICAS.ADMIN;
using Micro.Objects.ICAS.STUDENT;
using Micro.BusinessLayer.ICAS.STUDENT;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.ADMIN
{
    public partial class FeedBackMaster : BasePage
    {
        #region Declaration
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                BindCustomerLoanList();
                //BindGrid();

            }
        }

        protected void gridview_Question_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gridview_Question.PageIndex = e.NewPageIndex;
                BindAllFeedBack();
            }
            catch
            {
            }
        }

        protected void gridview_Question_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddl_Username_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(ddl_Username.SelectedItem.Value);
                if (x > 0)
                {
                    BindGrid(x);
                }
            }
            catch
            {
                BindAllFeedBack();
            }
        }

        protected void btn_AllFeedback_Click(object sender, EventArgs e)
        {
            BindAllFeedBack();
        }
        #endregion

        #region Methods & Implementation
        private void BindGrid(int UserId)
        {

            List<FeedBackMasters> FeedBackList = new List<FeedBackMasters>();

            FeedBackList = FeedbackMasterManagement.GetInstance.GetFeedBackMastersList();
            List<FeedBackMasters> FilterList = (from xyz in FeedBackList
                                                where xyz.UserID == UserId
                                                select xyz).ToList();
            gridview_Question.DataSource = FilterList;
            gridview_Question.DataBind();
        }
        private void BindAllFeedBack()
        {

            List<FeedBackMasters> FeedBackList = new List<FeedBackMasters>();

            FeedBackList = FeedbackMasterManagement.GetInstance.GetFeedBackMastersList();

            gridview_Question.DataSource = FeedBackList;
            gridview_Question.DataBind();
        }

        public void BindCustomerLoanList()
        {
            List<Student> theStudentList = StudentManagement.GetInstance.GetStudentList();
            int FirstFieldLength = 20;
            int SecondFieldLength = 25;
            ddl_Username.DataSource = null;
            ddl_Username.DataBind();
            int ValueForSelectedText = 5;
            List<Student> ThisstudentList = theStudentList;

            List<Student> Studentlist = new List<Student>();
            foreach (Student Newstudent in theStudentList)
            {
                Student newStudent = new Student();
                TextBox t1 = new TextBox();
                t1.Text = AlignLeft(Newstudent.StudentName, FirstFieldLength) + " | " + AlignLeft(Newstudent.RollNo, SecondFieldLength);
                newStudent.StudentID = Newstudent.StudentID;
                newStudent.RollNo = t1.Text;
                Studentlist.Add(newStudent);
            }

            ddl_Username.DataSource = Studentlist;

            ddl_Username.DataTextField = "RollNo";
            ddl_Username.DataValueField = "StudentID";
            ddl_Username.DataBind();

            ddl_Username.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        private string AlignLeft(string vStr, int vSpace)
        {
            string returnvalue = "";
            if ((vStr.Trim()).Length > vSpace)
            {
                returnvalue = vStr.Substring(0, (vSpace - 3)) + "...";
            }
            else
            {
                returnvalue = vStr + AddSpace((vSpace - (vStr.Trim()).Length), "\xA0");
            }
            return returnvalue;
        }
        private string AddSpace(int totChar, string chrStr)
        {
            string retValue = "";

            for (int i = 0; i <= totChar - 1; i++)
            {
                retValue += chrStr;
            }
            return retValue;
        }
        #endregion
    }
}