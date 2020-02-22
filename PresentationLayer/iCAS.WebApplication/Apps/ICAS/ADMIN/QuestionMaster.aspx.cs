using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.ICAS.ADMIN;
using Micro.Objects.ICAS.ADMIN;
using Micro.Framework.ReadXML;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.ADMIN
{
    public partial class QuestionMaster : System.Web.UI.Page
    {
        #region Declaration
        protected static class PageVariables
        {
            public static Micro.Objects.ICAS.ADMIN.QuestionMasters ThisFeedbackMaster
            {
                get
                {
                    Micro.Objects.ICAS.ADMIN.QuestionMasters ThisFeedbackMaster = HttpContext.Current.Session["ThisFeedbackMaster"] as Micro.Objects.ICAS.ADMIN.QuestionMasters;
                    return ThisFeedbackMaster;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisFeedbackMaster", value);
                }
            }
            public static List<Micro.Objects.ICAS.ADMIN.QuestionMasters> TheFeedbackQuestionsList
            {
                get
                {
                    List<Micro.Objects.ICAS.ADMIN.QuestionMasters> TheFeedbackQuestionsList = HttpContext.Current.Session["TheFeedbackQuestionsList"] as List<Micro.Objects.ICAS.ADMIN.QuestionMasters>;
                    return TheFeedbackQuestionsList;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheFeedbackQuestionsList", value);
                }
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				BindGridView();
				multiview_ManageFeedbacks.SetActiveView(view_EnterQuestions);
			}
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            ResetTextBoxesQuestions();
        }

        protected void btn_ViewAll_Click(object sender, EventArgs e)
        {
            multiview_ManageFeedbacks.SetActiveView(View_Grid);
            BindGridView();
        }

        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            multiview_ManageFeedbacks.SetActiveView(view_EnterQuestions);
            ResetTextBoxesQuestions();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals("Save and Continue For Options"))
            {
                ProcReturnValue = InsertFeedbackQuestions();
                lbl_TheMessage.Text = "Inserted Successfully";
                BindQuestionList();
                ddl_Question.SelectedValue = ProcReturnValue.ToString();
                multiview_ManageFeedbacks.SetActiveView(option_EnterQuestions);
            }
            else
            {
                ProcReturnValue = UpdateFeedbackQuestions();
                lbl_TheMessage.Text = "Updated Successfully";
            }
            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                ResetTextBoxesQuestions();
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();            
        }

        protected void gridview_Question_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_Question_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_Question_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_Question.Rows[RowIndex].FindControl("lbl_QuestionID")).Text);

                PageVariables.ThisFeedbackMaster = (from xyz in PageVariables.TheFeedbackQuestionsList
                                                    where xyz.QuestionID == RecordID
                                                    select xyz).Single();
                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    PopulateFormField(PageVariables.ThisFeedbackMaster);
                    multiview_ManageFeedbacks.SetActiveView(view_EnterQuestions);
                    btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
                }
                if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
                {
                    OptionMasters ThisOptionMasters;
                    ThisOptionMasters = (from xyz in FeedbackMasterManagement.GetInstance.GetOptionMastersList()
                                         where xyz.QuestionID == RecordID
                                         select xyz).Single();
                    PopulateFormFieldOptions(ThisOptionMasters);
                    multiview_ManageFeedbacks.SetActiveView(option_EnterQuestions);
                    btn_SaveQ.Text = MicroEnums.DataOperation.Update.GetStringValue();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    ProcReturnValue = DeleteFeedbackQuestions();

                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_ALUMINI_DELETED");
                        BindGridViewOptions();
                    }
                    else
                    {
                        lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_ALUMINI_DELETED");
                    }
                    dialog_Message.Show();
                }
            }
        }

        protected void gridview_Question_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void gridview_Question_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridview_Question.PageIndex = e.NewPageIndex;
                BindGridViewOptions();
                multiview_ManageFeedbacks.SetActiveView(View_Grid);
                //lit_PageCounter.Text = string.Format("Page <b>{0}</b> of {1}", e.NewPageIndex + 1, gview_Employee.PageCount);
            }
            catch
            {
            }

        }

        protected void gridview_Option_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_Option.Rows[RowIndex].FindControl("lbl_OptionID")).Text);
                OptionMasters ThisOptionMasters;
                ThisOptionMasters = (from xyz in FeedbackMasterManagement.GetInstance.GetOptionMastersList()
                                                   where xyz.OptionID == RecordID
                                                   select xyz).Single();
                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    PopulateFormFieldOptions(ThisOptionMasters);
                    multiview_ManageFeedbacks.SetActiveView(option_EnterQuestions);
                    btn_SaveQ.Text = MicroEnums.DataOperation.Update.GetStringValue();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    ProcReturnValue = DeleteQuestionOption();

                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        lbl_TheMessage.Text = "Deleted";
                        BindGridView();
                    }
                    else
                    {
                        lbl_TheMessage.Text = "Deleted Failure";

                    }
                    dialog_Message.Show();
                }
            }
        }

        protected void gridview_Option_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_Option_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_Option_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Methods & Implementation

        private void BindGridView()
        {
            PageVariables.TheFeedbackQuestionsList = new List<QuestionMasters>();
            PageVariables.TheFeedbackQuestionsList = FeedbackMasterManagement.GetInstance.GetFeedbackQuestionsList();
            gridview_Question.DataSource = PageVariables.TheFeedbackQuestionsList;
            gridview_Question.DataBind();

        }

        public void ResetTextBoxesQuestions()
        {
            txt_EnterQuestion.Text = string.Empty;
            txt_QuestionTitle.Text = string.Empty;
            btn_Save.Text = "Save and Continue For Options";//MicroEnums.DataOperation.Save.GetStringValue();


        }

        private int InsertFeedbackQuestions()
        {
            int ReturnValue = 0;

            QuestionMasters TheFeedbackMaster = new QuestionMasters();
            TheFeedbackMaster.QuestionTitle = txt_QuestionTitle.Text;
            TheFeedbackMaster.QuestionDesc = txt_EnterQuestion.Text;
            ReturnValue = FeedbackMasterManagement.GetInstance.InsertFeedbackQuestions(TheFeedbackMaster);
            return ReturnValue;
        }

        private int UpdateFeedbackQuestions()
        {
            int ProcReturnValue = 0;
            QuestionMasters Obj = new QuestionMasters();
            Obj.QuestionID = int.Parse(lbl_QuestionIDHide.Text);
            Obj.QuestionTitle = txt_QuestionTitle.Text;
            Obj.QuestionDesc = txt_EnterQuestion.Text;

            ProcReturnValue = FeedbackMasterManagement.GetInstance.UpdateFeedbackQuestions(Obj);
            return ProcReturnValue;
        }

        private int DeleteFeedbackQuestions()
        {
            int ProcReturnValue = FeedbackMasterManagement.GetInstance.DeleteFeedbackMaster(PageVariables.ThisFeedbackMaster);
            return ProcReturnValue;
        }
        private void BindQuestionList()
        {
            //PageVariables.TheQuestionsList = FeedbackMasterManagement.GetInstance.GetFeedbackQuestionsList();
            ddl_Question.DataSource = FeedbackMasterManagement.GetInstance.GetFeedbackQuestionsList();
            ddl_Question.DataTextField = "QuestionDesc";
            ddl_Question.DataValueField = "QuestionID";
            ddl_Question.DataBind();
            ddl_Question.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }
        private bool validateDuplicateOption(int QuestionId)
        {
            bool returnValue = true;
            List<OptionMasters> TheQuestionsList = (from xyz in FeedbackMasterManagement.GetInstance.GetOptionMastersList()
                                                    where xyz.QuestionID == QuestionId
                                                    select xyz).ToList();
            if (TheQuestionsList.Count > 0)
            {
                returnValue = false;
            }
            else
            {
                returnValue = true;
            }

            return returnValue;
        }
        private void PopulateFormField(QuestionMasters TheQuestionMasters)
        {
            lbl_QuestionIDHide.Text = TheQuestionMasters.QuestionID.ToString();
            txt_QuestionTitle.Text = TheQuestionMasters.QuestionTitle;
            txt_EnterQuestion.Text = TheQuestionMasters.QuestionDesc;
        }
        private void PopulateFormFieldOptions(OptionMasters TheOption)
        {
            RadioList_FeedBack.SelectedValue = MicroConstants.NUMERIC_ONE.ToString();
            BindQuestionList();
            ddl_Question.SelectedIndex = BasePage.GetDropDownSelectedIndex(ddl_Question, TheOption.QuestionID);
            txt_Option1.Text = TheOption.Option1;
            txt_Option2.Text = TheOption.Option2;
            txt_Option3.Text = TheOption.Option3;
            txt_Option4.Text = TheOption.Option4;
        }
        private int InsertQuestionOption()
        {
            int ReturnValue = 0;

            OptionMasters TheOption = new OptionMasters();
            TheOption.QuestionID = int.Parse(ddl_Question.SelectedValue);
            TheOption.Option1 = txt_Option1.Text;
            TheOption.Option2 = txt_Option2.Text;
            TheOption.Option3 = txt_Option3.Text;
            TheOption.Option4 = txt_Option4.Text;
            ReturnValue = FeedbackMasterManagement.GetInstance.InsertOptions(TheOption);
            return ReturnValue;
        }

        private int UpdateQuestionOption()
        {
            int ProcReturnValue = 0;
            OptionMasters ThisOptionMasters = new OptionMasters();
            ThisOptionMasters.QuestionID = int.Parse(ddl_Question.SelectedValue);
            ThisOptionMasters.Option1 = txt_Option1.Text;
            ThisOptionMasters.Option2 = txt_Option2.Text;
            ThisOptionMasters.Option3 = txt_Option3.Text;
            ThisOptionMasters.Option4 = txt_Option4.Text;

            ProcReturnValue = FeedbackMasterManagement.GetInstance.UpdateOptions(ThisOptionMasters);
            return ProcReturnValue;
        }

        private int DeleteQuestionOption()
        {
            OptionMasters ThisOptionMasters = new OptionMasters();
            ThisOptionMasters.QuestionID = int.Parse(ddl_Question.SelectedValue);
            int ProcReturnValue = FeedbackMasterManagement.GetInstance.DeleteOptions(ThisOptionMasters);
            return ProcReturnValue;
        }
        private void ResetTextBoxes()
        {
            txt_Option1.Text = string.Empty;
            txt_Option2.Text = string.Empty;
            txt_Option3.Text = string.Empty;
            txt_Option4.Text = string.Empty;
            btn_SaveQ.Text = MicroEnums.DataOperation.Save.GetStringValue();
            BindQuestionList();
        }
        private void BindGridViewOptions()
        {         
            gridview_Option.DataSource = FeedbackMasterManagement.GetInstance.GetOptionMastersList();
            gridview_Option.DataBind();
        }
        #endregion

        protected void Radio_Questionpage_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void btn_SaveQ_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                if (ddl_Question.SelectedIndex == 0)
                {
                    lbl_TheMessage.Text = "Select a Question";
                }
                else
                {
                    if (validateDuplicateOption(int.Parse(ddl_Question.SelectedItem.Value)))
                    {
                        ProcReturnValue = InsertQuestionOption();
                        lbl_TheMessage.Text = "Inserted Successfully";
                    }
                    else
                    {
                        lbl_TheMessage.Text = "You Can't Enter Option Twice";
                        ResetTextBoxes();
                    }
                }
            }
            else
            {
                ProcReturnValue = UpdateQuestionOption();
                lbl_TheMessage.Text= ProcReturnValue>0?"Update Failed":"Updated Successfully";
            }
            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                ResetTextBoxes();
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
        }

        protected void RadioList_FeedBack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioList_FeedBack.SelectedValue == "0")
            {
                multiview_ManageFeedbacks.SetActiveView(view_EnterQuestions);
            }
            else
            {
                BindQuestionList();
                txt_Option1.Text = string.Empty;
                txt_Option2.Text = string.Empty;
                txt_Option3.Text = string.Empty;
                txt_Option4.Text = string.Empty;               
                multiview_ManageFeedbacks.SetActiveView(option_EnterQuestions);
            }
        }

        protected void btn_ViewAllQ_Click(object sender, EventArgs e)
        {
            multiview_ManageFeedbacks.SetActiveView(View_Options);
            BindGridViewOptions();
        }

        protected void btn_ResetQ_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

        protected void btn_AddNewQ_Click(object sender, EventArgs e)
        {
            multiview_ManageFeedbacks.SetActiveView(option_EnterQuestions);
        }

        protected void gridview_Option_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

    }
}