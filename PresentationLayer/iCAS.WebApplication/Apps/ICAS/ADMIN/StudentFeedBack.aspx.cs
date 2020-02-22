using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.ICAS.ADMIN;
using Micro.Objects.ICAS.ADMIN;
using Micro.Commons;
using System.Drawing;
using System.Data;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.ADMIN
{
    /// <summary>
    /// Author
    /// Deepak Kumar Biswal
    /// </summary>
    public partial class StudentFeedBack : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {
            public static string str1;
            public static string str2;
            public static string str3;
            public static string str4;
            public static OptionMasters ThisOptionMasters
            {
                get
                {
                    OptionMasters TheOptionMasters = HttpContext.Current.Session["ThisOptionMasters"] as OptionMasters;
                    return TheOptionMasters;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisOptionMasters", value);
                }
            }
            public static List<QuestionMasters> TheQuestionsList
            {
                get
                {
                    List<QuestionMasters> TheQuestionsList = HttpContext.Current.Session["TheQuestionsList"] as List<Micro.Objects.ICAS.ADMIN.QuestionMasters>;
                    return TheQuestionsList;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheQuestionsList", value);
                }
            }
            public static List<FeedBackMasters> TheFeedbackList
            {
                get
                {
                    List<FeedBackMasters> TheFeedbackList = HttpContext.Current.Session["TheFeedbackList"] as List<Micro.Objects.ICAS.ADMIN.FeedBackMasters>;
                    return TheFeedbackList;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheFeedbackList", value);
                }
            }

            public static List<OptionMasters> TheOptionList
            {
                get
                {
                    List<OptionMasters> TheOptionList = HttpContext.Current.Session["TheOptionList"] as List<Micro.Objects.ICAS.ADMIN.OptionMasters>;
                    return TheOptionList;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheOptionList", value);
                }
            }

        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Micro.Commons.Connection.LoggedOnUser == null)
            {
                lbl_TheMessage.Text = string.Format("Please login to provide your feedback!"); //"Failed to submit your feedback";
                lbl_TheMessage.ForeColor = Color.Red;
                dialog_Message.Show();
                Response.Redirect("/APPS/Login.aspx");
            }
            else
            {

                if (!IsPostBack)
                {
                    BindQuestionList();
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            string UserName = (Micro.Commons.Connection.LoggedOnUser == null ? "User" : Micro.Commons.Connection.LoggedOnUser.UserFirstName);
            ProcReturnValue = InsertFeedback();

            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                lbl_TheMessage.Text = string.Format("Dear {0}, <b>successfully</b> submitted the feedback", UserName);
                lbl_TheMessage.ForeColor = Color.DarkGreen;
                ResetRadiButtons();
            }
            else if (ProcReturnValue == 0)
            {
                lbl_TheMessage.Text = string.Format("Dear {0}, you have already submitted the feedback", UserName); //"Failed to submit your feedback";
                lbl_TheMessage.ForeColor = Color.Blue;
                ResetRadiButtons();
            }
            else if (ProcReturnValue == -10)
            {
                lbl_TheMessage.Text = string.Format("Dear {0}, <b>Please answer all questions before you </b> submit the feedback", UserName); //"Failed to submit your feedback";
                lbl_TheMessage.ForeColor = Color.Red;
                ResetRadiButtons();
            }else
            {
                lbl_TheMessage.Text = string.Format("Dear {0}, <b>failed</b> to submitted the feedback", UserName); //"Failed to submit your feedback";
                lbl_TheMessage.ForeColor = Color.Red;
                ResetRadiButtons();
            }

            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
            {
                dialog_Message.Show();
            }
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            ResetRadiButtons();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i = GridView1.Rows.Count;
            Label x = (Label)e.Row.FindControl("lbl_QuestionID");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    List<OptionMasters> TheOptionMasters = new List<OptionMasters>();

                    RadioButton button = (RadioButton)e.Row.FindControl("RadioButton4");
                    RadioButton button1 = (RadioButton)e.Row.FindControl("RadioButton5");
                    RadioButton button2 = (RadioButton)e.Row.FindControl("RadioButton6");
                    RadioButton button3 = (RadioButton)e.Row.FindControl("RadioButton7");

                    TheOptionMasters = FeedbackMasterManagement.GetInstance.GetOptionMastersList();

                    PageVariables.ThisOptionMasters = (from xyz in TheOptionMasters
                                                       where xyz.QuestionID == int.Parse(x.Text)
                                                       select xyz).Single();


                    button.Text = PageVariables.ThisOptionMasters.Option1;
                    button1.Text = PageVariables.ThisOptionMasters.Option2;
                    button2.Text = PageVariables.ThisOptionMasters.Option3;
                    button3.Text = PageVariables.ThisOptionMasters.Option4;

                    var SelectedOption = (from s in PageVariables.TheFeedbackList
                                          where ((s.UserID == Micro.Commons.Connection.LoggedOnUser.UserID)
                                          && (s.QuestionID == int.Parse(x.Text)))
                                          select s).Single();

                    Micro.Objects.ICAS.ADMIN.FeedBackMasters userOption = ((Micro.Objects.ICAS.ADMIN.FeedBackMasters)SelectedOption);
                    if (userOption.OptionValue.Trim().Equals(button.Text.Trim()))
                    {
                        button.Checked = true;
                    }
                    else if (userOption.OptionValue.Trim().Equals(button1.Text.Trim()))
                    {
                        button1.Checked = true;
                    }
                    else if (userOption.OptionValue.Trim().Equals(button2.Text.Trim()))
                    {
                        button2.Checked = true;
                    }
                    else if (userOption.OptionValue.Trim().Equals(button3.Text.Trim()))
                    {
                        button3.Checked = true;
                    }
                }
                catch
                {

                }
            }
        }

        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in this.GridView1.Rows)
                {
                    RadioButton radio4 = (RadioButton)row.FindControl("RadioButton4");
                    RadioButton radio5 = (RadioButton)row.FindControl("RadioButton5");
                    RadioButton radio6 = (RadioButton)row.FindControl("RadioButton6");
                    RadioButton radio7 = (RadioButton)row.FindControl("RadioButton7");
                    if (radio4.Checked)
                    {
                        PageVariables.str1 = radio4.Text;
                        radio5.Checked = false;
                        radio6.Checked = false;
                        radio7.Checked = false;
                    }
                }
            }
            catch
            {
            }
        }

        protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in this.GridView1.Rows)
                {
                    RadioButton radio4 = (RadioButton)row.FindControl("RadioButton4");
                    RadioButton radio5 = (RadioButton)row.FindControl("RadioButton5");
                    RadioButton radio6 = (RadioButton)row.FindControl("RadioButton6");
                    RadioButton radio7 = (RadioButton)row.FindControl("RadioButton7");
                    if (radio5.Checked)
                    {
                        PageVariables.str2 = radio5.Text;
                        radio4.Checked = false;
                        radio6.Checked = false;
                        radio7.Checked = false;
                    }
                }
            }
            catch
            {
            }
        }

        protected void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in this.GridView1.Rows)
                {
                    RadioButton radio4 = (RadioButton)row.FindControl("RadioButton4");
                    RadioButton radio5 = (RadioButton)row.FindControl("RadioButton5");
                    RadioButton radio6 = (RadioButton)row.FindControl("RadioButton6");
                    RadioButton radio7 = (RadioButton)row.FindControl("RadioButton7");
                    if (radio6.Checked)
                    {
                        PageVariables.str3 = radio6.Text;
                        radio5.Checked = false;
                        radio4.Checked = false;
                        radio7.Checked = false;
                    }
                }
            }
            catch
            {
            }
        }

        protected void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in this.GridView1.Rows)
                {
                    RadioButton radio4 = (RadioButton)row.FindControl("RadioButton4");
                    RadioButton radio5 = (RadioButton)row.FindControl("RadioButton5");
                    RadioButton radio6 = (RadioButton)row.FindControl("RadioButton6");
                    RadioButton radio7 = (RadioButton)row.FindControl("RadioButton7");
                    if (radio7.Checked)
                    {
                        PageVariables.str4 = radio7.Text;
                        radio5.Checked = false;
                        radio6.Checked = false;
                        radio4.Checked = false;
                    }
                }
            }
            catch
            {
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindQuestionList();
            }
            catch
            {
            }
        }

        #endregion

        #region Method & Implementation
        private void BindQuestionList()
        {
            PageVariables.TheQuestionsList = null;
            PageVariables.TheFeedbackList = null;
            PageVariables.TheOptionList = null;

            PageVariables.TheQuestionsList = FeedbackMasterManagement.GetInstance.GetFeedbackQuestionsList();
            PageVariables.TheFeedbackList = FeedbackMasterManagement.GetInstance.GetFeedBackMastersList(Micro.Commons.Connection.LoggedOnUser.UserID);
            PageVariables.TheOptionList = FeedbackMasterManagement.GetInstance.GetOptionMastersList();

            GridView1.DataSource = PageVariables.TheOptionList;
            GridView1.DataBind();

            //if (PageVariables.TheFeedbackList.Count > 0)
            //{
            //    if (PageVariables.TheFeedbackList.Count > 0)
            //    {
            //        List<OptionMasters> filter = (from x1 in PageVariables.TheOptionList
            //                                      join x2 in PageVariables.TheFeedbackList on x1.QuestionID equals x2.QuestionID
            //                                      select x1).ToList();

            //        //GridView1.DataSource = filter;
            //        //GridView1.DataBind();
            //    }
            //    else
            //    {

            //    }
            //}
            //else
            //{
            //    GridView1.DataSource = PageVariables.TheOptionList;
            //    GridView1.DataBind();
            //}
        }

        private int InsertFeedback()
        {
            int procreturnvalue = 0;
            string OptionValue = string.Empty;
            int QID = 0;
            string value = string.Empty;
            List<FeedBackMasters> theList = new List<FeedBackMasters>();
            String QuestionNo = "";

            
            foreach (GridViewRow row in GridView1.Rows)
            {
                bool DidAnswerAllQuestions = false;
                OptionValue = string.Empty;
                FeedBackMasters theOM = new FeedBackMasters();
                QID = int.Parse(((Label)row.FindControl("lbl_QuestionID")).Text);
                RadioButton radio4 = (RadioButton)row.FindControl("RadioButton4");
                RadioButton radio5 = (RadioButton)row.FindControl("RadioButton5");
                RadioButton radio6 = (RadioButton)row.FindControl("RadioButton6");
                RadioButton radio7 = (RadioButton)row.FindControl("RadioButton7");
                if (radio4.Checked)
                {
                    OptionValue = radio4.Text;
                    PageVariables.str1 = PageVariables.str1 + "" + radio4.Text;
                    DidAnswerAllQuestions = true;
                }
                if (radio5.Checked)
                {
                    OptionValue = radio5.Text;
                    PageVariables.str2 = PageVariables.str1 + "" + radio5.Text;
                    DidAnswerAllQuestions = true;
                }
                if (radio6.Checked)
                {
                    OptionValue = radio6.Text;
                    PageVariables.str3 = PageVariables.str1 + "" + radio6.Text;
                    DidAnswerAllQuestions = true;
                }
                if (radio7.Checked)
                {
                    OptionValue = radio7.Text;
                    PageVariables.str4 = PageVariables.str1 + "" + radio7.Text;
                    DidAnswerAllQuestions = true;
                }

                // Check if missed any one answer
                if (DidAnswerAllQuestions == false)
                {
                    //lbl_TheMessage.Text = "Please choose One Option";
                    //dialog_Message.Show();
                    return -10;
                }
                else if (OptionValue == string.Empty)
                {
                    //lbl_TheMessage.Text = "Please choose One Option";
                    //dialog_Message.Show();
                    return -10;
                }
                else
                {
                    theOM.QuestionID = QID;
                    theOM.OptionValue = OptionValue;

                    theList.Add(theOM);
                    QuestionNo = QuestionNo + theOM.QuestionID + ',';
                    value = value + theOM.OptionValue + ',';
                }
            }

            if (QuestionNo.Length == 0)
            {
                lbl_TheMessage.Text = "Please select some values";
                dialog_Message.Show();
            }
            else if (value.Length == 0)
            {
                lbl_TheMessage.Text = "Please answer all questions before submit!";
                dialog_Message.Show();
            }
            else
            {
                QuestionNo = QuestionNo.Remove(QuestionNo.Length - 1);
                value = value.Remove(value.Length - 1);

                procreturnvalue = FeedbackMasterManagement.GetInstance.InsertFeedBack(QuestionNo, value);
            }
            return procreturnvalue;
        }

        private void ResetRadiButtons()
        {
            foreach (GridViewRow row in this.GridView1.Rows)
            {
                RadioButton radio4 = (RadioButton)row.FindControl("RadioButton4");
                RadioButton radio5 = (RadioButton)row.FindControl("RadioButton5");
                RadioButton radio6 = (RadioButton)row.FindControl("RadioButton6");
                RadioButton radio7 = (RadioButton)row.FindControl("RadioButton7");

                radio4.Checked = false;
                radio5.Checked = false;
                radio6.Checked = false;
                radio7.Checked = false;
            }
        }
        #endregion
    }
}