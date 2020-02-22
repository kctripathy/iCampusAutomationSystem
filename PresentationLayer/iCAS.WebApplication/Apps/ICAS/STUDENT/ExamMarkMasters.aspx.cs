using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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
    public partial class ExamMarkMasters : Page
    {
        protected static class PageVariables
        {
            public static ExamMark ThisExamMark
            {
                get
                {
                    ExamMark ThisExamMarke = HttpContext.Current.Session["ThisExamMark"] as ExamMark;
                    return ThisExamMark;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisExamMark", value);
                }
            }
            public static List<ExamMark> ExamMarkList
            {
                get
                {
                    List<ExamMark> ExamMarkList = HttpContext.Current.Session["ExamMarkList"] as List<ExamMark>;
                    return ExamMarkList;
                }
                set
                {
                    HttpContext.Current.Session.Add("ExamMarkList", value);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                SetValidationMessages();
                Bind_ExamMark_List();
                ResetAll();
                ExamMarks_Multi.SetActiveView(view_Grid);
            }
        }

        private void SetValidationMessages()
        {
            requiredFieldValidator_ExamSchedule.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_ExamSchedule.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY","ExamSchedule");

            requiredFieldValidator_MarksObtain.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY","Marks Obtained");

            requiredFieldValidator_Student.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Student.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY","Student");

            requiredFieldValidator_VarifiedBy.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY","Varified By");

            regularExpressionValidator_MarksObtain.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_MarksObtain.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_ONLY");
            regularExpressionValidator_Varifiedby.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_Varifiedby.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_ONLY");
        }
        private int InsertExamMark()
        {
            int Returnvalue = 0;

            ExamMark TheExamMark = new ExamMark();
            try
            {
                TheExamMark.ExamScheduleID =int.Parse(drpdwn_ExamMarkSeheduleID.SelectedValue);
                TheExamMark.MarksObtained = int.Parse(txt_MarksObtained.Text);
                TheExamMark.StudentID = drpdwn_StudentOnSeheduleID.SelectedValue;
                TheExamMark.VarifiedBy = txt_VarifiedBy.Text;
                TheExamMark.AddedBy = 44;//:TO DO Kanhu HARD CODE
                TheExamMark.OfficeID = 1;//:TO DO Kanhu HARD CODE
                TheExamMark.CompanyID = 1;//:TO DO Kanhu HARD CODE
                TheExamMark.IsActive = true;
                TheExamMark.IsDeleted = false;                
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                
            }
            Returnvalue = ExamMarkManagement.InsertExamMarks(TheExamMark);
            return Returnvalue;
        }

        public List<ObjExamSehedules> BindThisSechedule()
        {           
            ObjExamSehedules objSechedule = new ObjExamSehedules();
            objSechedule = (from xyzl in ExamScheduleManagement.GetInstance.GetExamSeduleList()
                                              where xyzl.ExamScheduleID ==int.Parse(drpdwn_ExamMarkSeheduleID.SelectedValue)
                                              select xyzl).Single();
            List<ObjExamSehedules> obj = new List<ObjExamSehedules>();
            obj.Add(objSechedule);
            return obj;
        }               
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertExamMark();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_ADDED");
                    ResetAll();
                    Bind_ExamMark_List();
                    ExamMarks_Multi.SetActiveView(view_Grid);
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_ADDED");
                }
            }
            else
            {
                ProcReturnValue = UpdateExamMark();
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
        private int UpdateExamMark()
        {
            int Returnvalue = 0;

            ExamMark UpdateExamMark = new ExamMark();
            UpdateExamMark.Exam_Mark_ScheduleID = int.Parse(lbl_Hidden_ExamMarkID.Text);
            UpdateExamMark.ExamScheduleID = int.Parse(drpdwn_ExamMarkSeheduleID.SelectedValue);
            UpdateExamMark.MarksObtained = int.Parse(txt_MarksObtained.Text);
            UpdateExamMark.StudentID = drpdwn_StudentOnSeheduleID.SelectedValue;
            UpdateExamMark.VarifiedBy = txt_VarifiedBy.Text;
            UpdateExamMark.ModifiedBy = 44;//:TO DO Kanhu HARD CODE
            UpdateExamMark.OfficeID = 1;//:TO DO Kanhu HARD CODE
            UpdateExamMark.CompanyID = 1;//:TO DO Kanhu HARD CODE
            UpdateExamMark.IsActive = true;
            UpdateExamMark.IsDeleted = false;

            Returnvalue = ExamMarkManagement.UpdateExamMarks(UpdateExamMark);
            return Returnvalue;
        }
        private int DeleteExamMark(int Record)
        {
            int Returnvalue = 0;

            ExamMark DeleteExamMark = new ExamMark();
            DeleteExamMark.Exam_Mark_ScheduleID = Record;
            DeleteExamMark.ModifiedBy = 1;//:TO DO Kanhu HARD CODE
            DeleteExamMark.OfficeID =44;//:TO DO Kanhu HARD CODE
            DeleteExamMark.CompanyID =8;//:TO DO Kanhu HARD CODE
            DeleteExamMark.IsActive = false;
            DeleteExamMark.IsDeleted = true;

            Returnvalue = ExamMarkManagement.DeleteExamMarks(DeleteExamMark);
            return Returnvalue;
        }
        private void BindDropdown_ExamMarkSehedule()
        {
            drpdwn_ExamMarkSeheduleID.DataSource = ExamScheduleManagement.GetInstance.GetExamSeduleList();
            drpdwn_ExamMarkSeheduleID.DataTextField = ExamScheduleManagement.GetInstance.DisplayMember;
            drpdwn_ExamMarkSeheduleID.DataValueField = ExamScheduleManagement.GetInstance.ValueMember;
            drpdwn_ExamMarkSeheduleID.DataBind();
            drpdwn_ExamMarkSeheduleID.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }
        private void BindDropdown_ExamSehedule_Students()
        {
            drpdwn_StudentOnSeheduleID.DataSource = ExamScheduleManagement.GetInstance.GetSeduleStudentList(int.Parse(drpdwn_ExamMarkSeheduleID.SelectedValue),false,false);
            drpdwn_StudentOnSeheduleID.DataTextField = ExamScheduleManagement.GetInstance.StudentMember;
            drpdwn_StudentOnSeheduleID.DataValueField = ExamScheduleManagement.GetInstance.StudentValueMember;
            drpdwn_StudentOnSeheduleID.DataBind();
            drpdwn_StudentOnSeheduleID.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }
        protected void btn_View_Click(object sender, EventArgs e)
        {
            ExamMarks_Multi.SetActiveView(view_Grid);
            Bind_ExamMark_List();
        }
        protected void Bind_ExamMark_List()
        {
            ResetAll();
            gridview_ExamMarkList.DataSource = ExamMarkManagement.GetExamsMarkList(); //PageVariables.SehedulesList;
            gridview_ExamMarkList.DataBind();
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
        void ResetAll()
        {
            BindDropdown_ExamMarkSehedule();                        
            txt_MarksObtained.Text = string.Empty;
            txt_VarifiedBy.Text = string.Empty;
            drpdwn_StudentOnSeheduleID.Items.Clear();
            gridview_ExamMarkList.DataSource = null;
            gridview_ExamMarkList.DataBind();
            lbl_Hidden_ExamMarkID.Text = "0";
            lbl_Blank.Text = "";           
            btn_Submit.Text = MicroEnums.DataOperation.Save.GetStringValue();
        }
        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            ResetAll();
            ExamMarks_Multi.SetActiveView(InputControls);
        }        
        private void PopulateFormField(ExamMark TheExamMark,int Record)
        {
            lbl_Hidden_ExamMarkID.Text = Record.ToString();
            drpdwn_ExamMarkSeheduleID.SelectedValue = TheExamMark.ExamScheduleID.ToString();

            Student objStudent = new Student();
            objStudent = (from xyzl in StudentManagement.GetInstance.GetStudentList()
                               where xyzl.StudentID == int.Parse(TheExamMark.StudentID)
                               select xyzl).Single();
            drpdwn_StudentOnSeheduleID.Items.Insert(0, new ListItem(objStudent.StudentName,TheExamMark.StudentID));

            //drpdwn_StudentOnSeheduleID.SelectedValue = TheExamMark.StudentID;
            txt_MarksObtained.Text = TheExamMark.MarksObtained.ToString();
            txt_VarifiedBy.Text = TheExamMark.VarifiedBy;       
        }
        private static int DeleteRecord()
        {
            return 0;
        }                
        protected void gridview_ExamMarkList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_ExamMarkList.Rows[RowIndex].FindControl("lbl_ExamMarkID")).Text);
                ExamMark ObjExamMark = new ExamMark();
                ObjExamMark = (from xyz2 in ExamMarkManagement.GetExamsMarkList()
                                          where xyz2.Exam_Mark_ScheduleID == RecordID
                                          select xyz2).Single();
                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    PopulateFormField(ObjExamMark,RecordID);
                    ExamMarks_Multi.SetActiveView(InputControls);
                    btn_Submit.Text = MicroEnums.DataOperation.Update.GetStringValue();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    ProcReturnValue = DeleteExamMark(RecordID);
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_DELETED");
                        Bind_ExamMark_List();
                    }
                    else
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_DATA_DELETED");
                    }
                    dialog_Message.Show();
                }
            }
        }

        protected void gridview_ExamMarkList_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void gridview_ExamMarkList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_ExamMarkList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void drpdwn_ExamMarkSeheduleID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown_ExamSehedule_Students();
            gridview_ExamSehedule.DataSource= BindThisSechedule();
            gridview_ExamSehedule.DataBind();
        }

        protected void gridview_ExamMarkList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview_ExamMarkList.PageIndex = e.NewPageIndex;
            Bind_ExamMark_List();
        }
    }
}