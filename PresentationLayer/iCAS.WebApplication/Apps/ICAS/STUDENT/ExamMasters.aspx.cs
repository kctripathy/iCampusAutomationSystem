using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.ICAS.EXAM;
using Micro.Objects.ICAS.STUDENT;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.BusinessLayer.ICAS.EXAM;
using Micro.Objects.Administration;
using Micro.Framework.ReadXML;
using Micro.Objects.FinancialAccounts;
using Micro.BusinessLayer.FinancialAccounts;
namespace LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT
{
    public partial class ExamMasters : Page
    {
        protected static class PageVariables
        {
            public static Exams ThisExam
            {
                get
                {
                    Exams ThisExame = HttpContext.Current.Session["ThisExam"] as Exams;
                    return ThisExam;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisExam", value);
                }
            }
            public static List<Exams> ExamList
            {
                get
                {
                    List<Exams> ExamList = HttpContext.Current.Session["ExamList"] as List<Exams>;
                    return ExamList;
                }
                set
                {
                    HttpContext.Current.Session.Add("ExamList", value);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                SetValidationMessages();
                Bind_Exam_List();
                BindAccountingYear(string.Empty);
                ResetAll();
                Exams_Multi.SetActiveView(view_Grid);                
            }
        }
        public void BindAccountingYear(string SearctText)
        {
            List<AccountingYear> AccountingYearlist = new List<AccountingYear>();
            AccountingYearlist = AccountingYearManagement.GetInstance.GetAccountingYearList(SearctText);
            DropDown_CurrentSeason.DataSource = AccountingYearlist;
            DropDown_CurrentSeason.DataValueField = "AccountingYearID";
            DropDown_CurrentSeason.DataTextField = "AccountingYearDescription";
            DropDown_CurrentSeason.DataBind();
        }
        private void SetValidationMessages()
        {
            requiredFieldValidator_ClassName.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_ClassName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Class Name");

            requiredFieldValidator_EndExam.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Date Of Close");
            requiredFieldValidator_ExamName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Exam Name");
            requiredFieldValidator_StartExam.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Date Of Start");

            regularExpressionValidator_StartExam.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_StartExam.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");

            regularExpressionValidator_CloaseExam.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_CloaseExam.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");

        }
        private int InsertExam()
        {
            int Returnvalue = 0;

            Exams TheExam = new Exams();
            try
            {
                TheExam.ExamName = drpdwn_ClassID.SelectedItem.Text+ "-"+txt_ExamName.Text+"@"+DropDown_CurrentSeason.SelectedItem.Text ;
                TheExam.DateOfStart = DateTime.Parse(txt_StartExam.Text).ToString(MicroConstants.DateFormat);
                    
                TheExam.DateOfClose =DateTime.Parse(txt_DateOfClose.Text).ToString(MicroConstants.DateFormat);
                TheExam.SessionID = int.Parse(DropDown_CurrentSeason.SelectedValue);
                //TheExam.DateOfClose = txt_DateOfClose.Text;
                TheExam.QualID =  int.Parse(drpdwn_ClassID.SelectedValue);
                TheExam.AddedBy = 44;//:TO DO Kanhu HARD CODE
                TheExam.OfficeID = 1;//:TO DO Kanhu HARD CODE
                TheExam.CompanyID = 1;//:TO DO Kanhu HARD CODE
                TheExam.IsActive = true;
                TheExam.IsDeleted = false;                
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                
            }

            Returnvalue = ExamManagement.InsertExam(TheExam);
            return Returnvalue;
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertExam();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_ADDED");
                    ResetAll();
                    Bind_Exam_List();
                    Exams_Multi.SetActiveView(view_Grid);
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_ADDED");
                }
            }
            else
            {
                ProcReturnValue = UpdateExam();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_UPDATED");
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_UPDATED");
                }
            }

            dialog_Message.Show();
        }
        private int UpdateExam()
        {
            int Returnvalue = 0;

            Exams UpdateExam = new Exams();
            UpdateExam.ExamID = int.Parse(lbl_Hidden_ExamID.Text);
            UpdateExam.ExamName = txt_ExamName.Text;
            UpdateExam.DateOfStart = DateTime.Parse(txt_StartExam.Text).ToString(MicroConstants.DateFormat);
            UpdateExam.DateOfClose = DateTime.Parse(txt_DateOfClose.Text).ToString(MicroConstants.DateFormat);
            UpdateExam.SessionID = 1;//TO DO Dynamically Currenet Session
            //UpdateExam.DateOfClose = txt_DateOfClose.Text;
            UpdateExam.QualID = int.Parse(drpdwn_ClassID.SelectedValue);
            UpdateExam.ModifiedBy = 44;//:TO DO Kanhu HARD CODE
            UpdateExam.OfficeID = 1;//:TO DO Kanhu HARD CODE
            UpdateExam.CompanyID = 1;//:TO DO Kanhu HARD CODE
            UpdateExam.IsActive = true;
            UpdateExam.IsDeleted = false;

            Returnvalue = ExamManagement.UpdateExam(UpdateExam);
            return Returnvalue;
        }
        private int DeleteExam(int Record)
        {
            int Returnvalue = 0;

            Exams DeleteExam = new Exams();
            DeleteExam.ExamID = Record;

            DeleteExam.ModifiedBy = 44;//:TO DO Kanhu HARD CODE
            DeleteExam.OfficeID = 1;//:TO DO Kanhu HARD CODE
            DeleteExam.CompanyID = 1;//:TO DO Kanhu HARD CODE
            DeleteExam.IsActive = false;
            DeleteExam.IsDeleted = true;

            Returnvalue = ExamManagement.DeleteExam(DeleteExam);
            return Returnvalue;
        }
        private void BindDropdown_Quals()
        {
            drpdwn_ClassID.Items.Clear();
            List<Qualification> objQuals = new List<Qualification>();
            objQuals = (from xyzl in QualManagement.GetInstance.GetQualsList()
                        where xyzl.QualType == "C"
                        select xyzl).ToList();
            drpdwn_ClassID.DataSource = objQuals;
            drpdwn_ClassID.DataTextField = "QualCode";
            drpdwn_ClassID.DataValueField = "QualID";
            drpdwn_ClassID.DataBind();
            drpdwn_ClassID.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT, "0"));                
        }
     
        protected void btn_View_Click(object sender, EventArgs e)
        {
            Exams_Multi.SetActiveView(view_Grid);
            Bind_Exam_List();
        }
        protected void Bind_Exam_List()
        {            
            gridview_ExamList.DataSource = ExamManagement.GetInstance.GetExamsList(); //PageVariables.SehedulesList;
            gridview_ExamList.DataBind();
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
        void ResetAll()
        {
            BindDropdown_Quals();                        
            txt_StartExam.Text = string.Empty;
            txt_DateOfClose.Text = string.Empty;
            txt_ExamName.Text = string.Empty;
            BindDropdown_Quals();
            lbl_Hidden_ExamID.Text = "0";
            lbl_Blank.Text = "";           
            btn_Submit.Text = MicroEnums.DataOperation.Save.GetStringValue();
        }
        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            ResetAll();
            Exams_Multi.SetActiveView(InputControls);
        }        
        private void PopulateFormField(Exams TheExam,int Record)
        {
            lbl_Hidden_ExamID.Text = Record.ToString();
            drpdwn_ClassID.SelectedValue = TheExam.QualID.ToString();           
            txt_StartExam.Text = TheExam.DateOfStart;
            txt_DateOfClose.Text = TheExam.DateOfClose;
            txt_ExamName.Text = TheExam.ExamName;            
        }
        private static int DeleteRecord()
        {
            return 0;
        }                
        protected void gridview_ExamList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_ExamList.Rows[RowIndex].FindControl("lbl_ExamID")).Text);
                Exams ObjExam = new Exams();
                ObjExam = (from xyzl in ExamManagement.GetInstance.GetExamsList()
                                          where xyzl.ExamID == RecordID
                                          select xyzl).Single();
                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    PopulateFormField(ObjExam,RecordID);
                    Exams_Multi.SetActiveView(InputControls);
                    btn_Submit.Text = MicroEnums.DataOperation.Update.GetStringValue();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    ProcReturnValue = DeleteExam(RecordID);
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_DELETED");
                        Bind_Exam_List();
                    }
                    else
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_DATA_DELETED");
                    }
                    dialog_Message.Show();
                }
            }
        }

        protected void gridview_ExamList_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void gridview_ExamList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_ExamList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }
    }
}