using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.ICAS.ADMIN;
using Micro.BusinessLayer.ICAS.ADMIN;
using Micro.Framework.ReadXML;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.ADMIN
{
    public partial class OptionMaster : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {
            public static OptionMasters ThisOptionMasters
            {
                get
                {
                    OptionMasters ThisOptionMasters = HttpContext.Current.Session["ThisOptionMasters"] as OptionMasters;
                    return ThisOptionMasters;
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

            public static List<OptionMasters> OptionMastersList
            {
                get
                {
                    List<OptionMasters> TheOptionMastersList = HttpContext.Current.Session["OptionMastersList"] as List<OptionMasters>;
                    return TheOptionMastersList;
                }
                set
                {
                    HttpContext.Current.Session.Add("OptionMastersList", value);
                }
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                multiview_ManageFeedbacks.SetActiveView(View_Grid);
                BindQuestionList();
                BindGridView();
            }
        }

        protected void btn_ViewAll_Click(object sender, EventArgs e)
        {
            multiview_ManageFeedbacks.SetActiveView(View_Grid);
            BindGridView();
        }

        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            multiview_ManageFeedbacks.SetActiveView(view_EnterQuestions);
        }

        protected void btn_Save_Click(object sender, EventArgs e)
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
                lbl_TheMessage.Text = "Updated Successfully";
            }
            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                ResetTextBoxes();
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
        }

        protected void gridview_Option_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_Option.Rows[RowIndex].FindControl("lbl_OptionID")).Text);

                PageVariables.ThisOptionMasters = (from xyz in PageVariables.OptionMastersList
                                                   where xyz.OptionID == RecordID
                                                   select xyz).Single();
                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    PopulateFormField(PageVariables.ThisOptionMasters);
                    multiview_ManageFeedbacks.SetActiveView(view_EnterQuestions);
                    btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
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

        protected void Radio_Questionpage_CheckedChanged(object sender, EventArgs e)
        {
            Response.Redirect("QuestionMaster.aspx");
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

        protected void gridview_Option_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridview_Option.PageIndex = e.NewPageIndex;
                BindGridView();
                //lit_PageCounter.Text = string.Format("Page <b>{0}</b> of {1}", e.NewPageIndex + 1, gview_Employee.PageCount);
            }
            catch
            {

            }
        }
        #endregion

        #region Method & Implementation
        private void BindQuestionList()
        {
            PageVariables.TheQuestionsList = FeedbackMasterManagement.GetInstance.GetFeedbackQuestionsList();
            ddl_Question.DataSource = PageVariables.TheQuestionsList;
            ddl_Question.DataTextField = "QuestionDesc";
            ddl_Question.DataValueField = "QuestionID";
            ddl_Question.DataBind();
            ddl_Question.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        private void BindGridView()
        {
            PageVariables.OptionMastersList = FeedbackMasterManagement.GetInstance.GetOptionMastersList();
            gridview_Option.DataSource = PageVariables.OptionMastersList;
            gridview_Option.DataBind();

        }
        private bool validateDuplicateOption(int QuestionId)
        {
            bool returnValue = true;

            List<OptionMasters> TheQuestionsList = (from xyz in PageVariables.OptionMastersList
                                                    where  xyz.OptionID == QuestionId
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
            PageVariables.ThisOptionMasters.QuestionID = int.Parse(ddl_Question.SelectedValue);
            PageVariables.ThisOptionMasters.Option1 = txt_Option1.Text;
            PageVariables.ThisOptionMasters.Option2 = txt_Option2.Text;
            PageVariables.ThisOptionMasters.Option3 = txt_Option3.Text;
            PageVariables.ThisOptionMasters.Option4 = txt_Option4.Text;

            ProcReturnValue = FeedbackMasterManagement.GetInstance.UpdateOptions(PageVariables.ThisOptionMasters);
            return ProcReturnValue;
        }

        private int DeleteQuestionOption()
        {
            int ProcReturnValue = FeedbackMasterManagement.GetInstance.DeleteOptions(PageVariables.ThisOptionMasters);
            return ProcReturnValue;
        }

        private void PopulateFormField(OptionMasters TheOption)
        {
            ddl_Question.SelectedIndex = BasePage.GetDropDownSelectedIndex(ddl_Question, TheOption.QuestionID);
            txt_Option1.Text = TheOption.Option1;
            txt_Option2.Text = TheOption.Option2;
            txt_Option3.Text = TheOption.Option3;
            txt_Option4.Text = TheOption.Option4;
        }

        private void ResetTextBoxes()
        {
            txt_Option1.Text = string.Empty;
            txt_Option2.Text = string.Empty;
            txt_Option3.Text = string.Empty;
            txt_Option4.Text = string.Empty;
            btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
            BindQuestionList();
        }
        #endregion
    }
}