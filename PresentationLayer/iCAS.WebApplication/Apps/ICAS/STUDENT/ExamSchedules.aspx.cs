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
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.Objects.Administration;
using Micro.Framework.ReadXML;
using Micro.Objects.FinancialAccounts;
using Micro.BusinessLayer.FinancialAccounts;
namespace LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT
{
    public partial class ExamSchedules : Page
    {
        protected static class PageVariables
        {
            public static ObjExamSehedules ThisExamSchedule
            {
                get
                {
                    ObjExamSehedules ThisExamSchedule = HttpContext.Current.Session["ThisSchedule"] as ObjExamSehedules;
                    return ThisExamSchedule;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisSchedule", value);
                }
            }
            public static List<ObjExamSehedules> SehedulesList
            {
                get
                {
                    List<ObjExamSehedules> TheSehedulesList = HttpContext.Current.Session["ExamSehedulesList"] as List<ObjExamSehedules>;
                    return TheSehedulesList;
                }
                set
                {
                    HttpContext.Current.Session.Add("ExamSehedulesList", value);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                SetValidationMessages();
                BindDropdown_Quals();           
                Bind_Exam_Sedhule();
                ResetAll();
                Examschedule_Multi.SetActiveView(view_Grid);
            }
        }

        private void SetValidationMessages()
        {
            requiredFieldValidator_ClassName.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_ClassName.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Class Name");

            requiredFieldValidator_CloseTime.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "CloseTime");
            requiredFieldValidator_ExamFullMark.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Exam Fullmark");
            requiredFieldValidator_PassMark.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", " Exam Passmark");

            requiredFieldValidator_ExamID.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_ExamID.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "ExamID");

            requiredFieldValidator_Invivilator.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Invivilator");
            requiredFieldValidator_RoomNo.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "RoomNo");
            requiredFieldValidator_SeheduleName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "SeheduleName");
            requiredFieldValidator_StartExam.ErrorMessage= ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Exam Date");
            requiredFieldValidator_StartTime.ErrorMessage= ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "StartTime");

            requiredFieldValidator_Stream.InitialValue=MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Stream.ErrorMessage= ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Stream");

            requiredFieldValidator_Subjects.InitialValue=MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Subjects.ErrorMessage= ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Subjects");

            regularExpressionValidator_CloseExamTime.ValidationExpression = MicroConstants.REGEX_DECIMAL_GREATERTHANZERO;
            regularExpressionValidator_CloseExamTime.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_TIME_GREATERTHANZERO");
            regularExpressionValidator_ExamStartTime.ValidationExpression = MicroConstants.REGEX_DECIMAL_GREATERTHANZERO;
            regularExpressionValidator_ExamStartTime.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_TIME_GREATERTHANZERO");
            //regularExpressionValidator_InvigilatorID.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            //regularExpressionValidator_InvigilatorID.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_ONLY");
            regularExpressionValidator_RoomNo.ValidationExpression = MicroConstants.REGEX_ALPHANUMERIC_MINUS;
            regularExpressionValidator_RoomNo.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_ALPHANUMERIC_MINUS");

            regularExpressionValidator_StartExam.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_StartExam.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");

            regularExpressionValidator_ExamFullmark.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_ExamFullmark.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_ONLY");

            regularExpressionValidator_PassMark.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_PassMark.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_ONLY");
           
        }
        private int InsertSchedules()
        {
            int Returnvalue = 0;

            ObjExamSehedules TheScdules = new ObjExamSehedules();
            TheScdules.ExamScheduleName = txt_ExamSeheduleName.Text;
            TheScdules.ExamID = int.Parse(drpdwn_ExamID.SelectedValue);
            TheScdules.SubjectID = int.Parse(drpdwn_Subject.SelectedValue);
            TheScdules.StreamID=int.Parse(drpdwn_Stream.SelectedValue);
            TheScdules.QualID = int.Parse(DropDown_Class.SelectedValue);
            TheScdules.ClassID = int.Parse(drpdwn_ClassID.SelectedValue);
            //TheScdules.SubjectPaperID = drpdwn_PaperID.SelectedValue == "---SELECT-" ? 0 : int.Parse(drpdwn_PaperID.SelectedValue);
            TheScdules.FullMark = int.Parse(txt_ExamFullMark.Text);
            TheScdules.PassMark = 0;//int.Parse(txt_PassMark.Text);
            TheScdules.StartTime = txt_startExamTime.Text;
            TheScdules.CloseTime = txt_CloseTime.Text;
            TheScdules.ExamDate = DateTime.Parse(txt_StartExam.Text).ToString(MicroConstants.DateFormat);
            TheScdules.InvisilatorUserID = int.Parse(DropDown_Staff.SelectedValue);
            //TheScdules.IsSubjectPractical = Boolean.Parse(radio_PraticalStatus.SelectedItem.Value);
            TheScdules.AddedBy=42;
            TheScdules.IsActive = true;
            TheScdules.IsDeleted = false;
            TheScdules.RoomNo = int.Parse(txt_Roomnumber.Text);

            Returnvalue = ExamScheduleManagement.GetInstance.InsertSchedules(TheScdules);
            return Returnvalue;
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertSchedules();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_ADDED");
                    ResetAll();
                    Bind_Exam_Sedhule();
                    Examschedule_Multi.SetActiveView(view_Grid);
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_ADDED");
                }
            }
            else
            {
                ProcReturnValue = UpdateExamSchedule();
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
            Bind_Exam_Sedhule();
        }
        private int UpdateExamSchedule()
        {
            int Returnvalue = 0;

            ObjExamSehedules TheScdules = new ObjExamSehedules();
            TheScdules.ExamScheduleID = int.Parse(lbl_Hidden_SheduleID.Text);
            TheScdules.ExamScheduleName = txt_ExamSeheduleName.Text;
            TheScdules.ExamID = int.Parse(drpdwn_ExamID.SelectedValue);
            TheScdules.SubjectID = int.Parse(drpdwn_Subject.SelectedValue);
            TheScdules.StreamID = int.Parse(drpdwn_Stream.SelectedValue);
            //TheScdules.SubjectPaperID = int.Parse(drpdwn_PaperID.SelectedValue);
            TheScdules.FullMark = int.Parse(txt_ExamFullMark.Text);
            TheScdules.PassMark = int.Parse(txt_PassMark.Text);
            TheScdules.QualID = int.Parse(DropDown_Class.SelectedValue);
            TheScdules.ClassID = int.Parse(drpdwn_ClassID.SelectedValue);
            TheScdules.StartTime = txt_startExamTime.Text;
            TheScdules.CloseTime = txt_CloseTime.Text;
            TheScdules.ExamDate = DateTime.Parse(txt_StartExam.Text).ToString(MicroConstants.DateFormat);
            TheScdules.InvisilatorUserID = int.Parse(DropDown_Staff.SelectedValue);
            //TheScdules.IsSubjectPractical = Boolean.Parse(radio_PraticalStatus.SelectedItem.Value);
            TheScdules.IsActive = true;
            TheScdules.IsDeleted = false;
            TheScdules.RoomNo = int.Parse(txt_Roomnumber.Text);

            Returnvalue = ExamScheduleManagement.GetInstance.UpdateSchedules(TheScdules);
            return Returnvalue;
        }
        private void BindDropdown_Quals()
        {
            DropDown_Class.Items.Clear();
            List<Qualification> objQuals = new List<Qualification>();
            objQuals = (from xyzl in QualManagement.GetInstance.GetQualsList()
                        where xyzl.QualType == "C"
                        select xyzl).ToList();
            DropDown_Class.DataSource = objQuals;
            DropDown_Class.DataTextField = "QualCode";
            DropDown_Class.DataValueField = "QualID";
            DropDown_Class.DataBind();
            DropDown_Class.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT,"0"));           
        }
        private void BindDropdown_Exams()
        {
            drpdwn_ExamID.DataSource = ExamManagement.GetInstance.GetExamsList();
            drpdwn_ExamID.DataTextField = ExamManagement.GetInstance.DisplayMember;
            drpdwn_ExamID.DataValueField = ExamManagement.GetInstance.ValueMember;
            drpdwn_ExamID.DataBind();
            drpdwn_ExamID.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT,"0"));
        }
        private void BindDropdown_Streams()
        {
            drpdwn_Stream.DataSource = StreamManagement.GetInstance.GetStreamList();
            drpdwn_Stream.DataTextField = "StreamName";//StreamManagement.GetInstance.DisplayMember;
            drpdwn_Stream.DataValueField = "StreamID";//StreamManagement.GetInstance.ValueMember;
            drpdwn_Stream.DataBind();
            drpdwn_Stream.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT,"0"));
        }
        private void BindDropdown_Stream_Subjects()
        {
            Subjects ObjSubjects = new Subjects();
            ObjSubjects.QualID = DropDown_Class.SelectedValue;
            ObjSubjects.StreamID = drpdwn_Stream.SelectedValue;
            ObjSubjects.ClassID = drpdwn_ClassID.SelectedValue;

            drpdwn_Subject.DataSource = SubjectManagement.GetInstance.GetSubjectListByCourseStreamClass(ObjSubjects, "", false);
            drpdwn_Subject.DataTextField = SubjectManagement.GetInstance.DisplayMember;
            drpdwn_Subject.DataValueField = SubjectManagement.GetInstance.ValueMember;
            drpdwn_Subject.DataBind();
            drpdwn_Subject.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT,"0"));
        }
        private void BindDropdown_Subjects_Papers()
        {
            //drpdwn_PaperID.DataSource = SubjectPaperManagement.GetPaperListBySubjectID(int.Parse(drpdwn_Subject.SelectedValue), String.Empty, false);
            //drpdwn_PaperID.DataTextField = SubjectPaperManagement.GetInstance.DisplayMember;
            //drpdwn_PaperID.DataValueField = SubjectPaperManagement.GetInstance.ValueMember;
            //drpdwn_PaperID.DataBind();
            //drpdwn_PaperID.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT,"0"));
            //if (drpdwn_PaperID.Items.Count < 2)
            //{
            //    String Schedule = drpdwn_ExamID.SelectedItem.Text + "@" + DropDown_Class.SelectedItem.Text + "-" + drpdwn_Stream.SelectedItem.Text + "-" + drpdwn_Subject.SelectedItem.Text ;
            //    txt_ExamSeheduleName.Text = Schedule;
            //}
        }
        private void BindDropdown_Qual_Classes()
        {
            drpdwn_ClassID.DataSource = QualClassManagement.GetInstance.GetClassListByQualID(int.Parse(DropDown_Class.SelectedValue));
            drpdwn_ClassID.DataTextField = QualClassManagement.GetInstance.DisplayMember;
            drpdwn_ClassID.DataValueField = QualClassManagement.GetInstance.ValueMember;
            drpdwn_ClassID.DataBind();
            drpdwn_ClassID.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT, "0"));
            
        }
        protected void btn_View_Click(object sender, EventArgs e)
        {
            Examschedule_Multi.SetActiveView(view_Grid);
            Bind_Exam_Sedhule();
            ResetAll();
        }
        protected void Bind_Exam_Sedhule()
        {
            //PageVariables.SehedulesList = ExamScheduleManagement.GetInstance.GetExamSeduleList();
            gridview_Examsheedules.DataSource = ExamScheduleManagement.GetInstance.GetExamSeduleList(); //PageVariables.SehedulesList;
            gridview_Examsheedules.DataBind();
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
        void ResetAll()
        {
            drpdwn_ExamID.Items.Clear();
            drpdwn_Stream.Items.Clear();
            DropDown_Class.Items.Clear();
            drpdwn_ClassID.Items.Clear();
            DropDown_Staff.Items.Clear();
            BindStaffs();
            BindDropdown_Quals();
            BindDropdown_Exams();
            BindDropdown_Streams();
            drpdwn_Subject.Items.Clear();
            //drpdwn_PaperID.Items.Clear();
            txt_ExamSeheduleName.Text = string.Empty;
            txt_StartExam.Text = string.Empty;
            txt_ExamFullMark.Text = string.Empty;
            txt_PassMark.Text = string.Empty;
            txt_startExamTime.Text = string.Empty;
            txt_CloseTime.Text = string.Empty;
            
            txt_Roomnumber.Text = string.Empty;
            //radio_PraticalStatus.ClearSelection();
            lbl_Hidden_SheduleID.Text = "0";
            lbl_Blank.Text = "";
            //Examschedule_Multi.SetActiveView(view_Grid);
            btn_Submit.Text = MicroEnums.DataOperation.Save.GetStringValue();
        }
        protected void btn_AddNew_Click(object sender, EventArgs e)
        {            
            ResetAll();
            Examschedule_Multi.SetActiveView(InputControls);
        }

        protected void Examsheedules_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_Examsheedules.Rows[RowIndex].FindControl("lbl_ExamScheduleID")).Text);

                PageVariables.ThisExamSchedule = (from xyzl in ExamScheduleManagement.GetInstance.GetExamSeduleList()
                                             where xyzl.ExamScheduleID == RecordID
                                             select xyzl).Single();
                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    PopulateFormField(PageVariables.ThisExamSchedule,RecordID);
                    Examschedule_Multi.SetActiveView(InputControls);
                    btn_Submit.Text = MicroEnums.DataOperation.Update.GetStringValue();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
                    ProcReturnValue = DeleteRecord(RecordID);
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_DELETED");
                        Bind_Exam_Sedhule();
                    }
                    else
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_DATA_DELETED");
                    }
                    dialog_Message.Show();
                }
            }
        }
        private void PopulateFormField(ObjExamSehedules theSehedules,int Record)
        {
            lbl_Hidden_SheduleID.Text = Record.ToString();
            txt_ExamSeheduleName.Text = theSehedules.ExamScheduleName;
            drpdwn_ExamID.SelectedValue = theSehedules.ExamID.ToString();
            drpdwn_Stream.SelectedValue = theSehedules.StreamID.ToString();
            BindDropdown_Quals();           
            BindClass();
            BindDropdown_Qual_Classes();
            drpdwn_ClassID.SelectedValue = theSehedules.ClassID.ToString();
            BindDropdown_Stream_Subjects();
            drpdwn_Subject.SelectedValue = theSehedules.SubjectID.ToString();
            //BindDropdown_Subjects_Papers();
            //drpdwn_PaperID.SelectedValue = theSehedules.SubjectPaperID.ToString();
            txt_StartExam.Text = theSehedules.ExamDate;
            txt_ExamFullMark.Text = theSehedules.FullMark.ToString();
            txt_PassMark.Text = theSehedules.PassMark.ToString();
            txt_startExamTime.Text = theSehedules.StartTime;
            txt_CloseTime.Text = theSehedules.CloseTime;
            DropDown_Staff.SelectedValue = theSehedules.InvisilatorUserID.ToString();
            txt_Roomnumber.Text = theSehedules.RoomNo.ToString();
            //radio_PraticalStatus.SelectedValue = theSehedules.IsSubjectPractical.ToString();
        }
        private void BindStaffs()
        {
            DropDown_Staff.DataSource = StaffMasterManagement.GetInstance.GetEmployeeList();
            DropDown_Staff.DataValueField = StaffMasterManagement.GetInstance.ValueMember;
            DropDown_Staff.DataTextField = StaffMasterManagement.GetInstance.DisplayMember;
            DropDown_Staff.DataBind();
            DropDown_Staff.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT, "0")); 
        }
        private int DeleteRecord(int Record)
        {
            int Returnvalue = 0;

            ObjExamSehedules DeleteExamSchedules = new ObjExamSehedules();
            DeleteExamSchedules.ExamScheduleID= Record;

            DeleteExamSchedules.ModifiedBy = 44;//:TO DO Kanhu HARD CODE
            DeleteExamSchedules.OfficeID = 1;//:TO DO Kanhu HARD CODE
            DeleteExamSchedules.CompanyID = 1;//:TO DO Kanhu HARD CODE
            DeleteExamSchedules.IsActive = false;
            DeleteExamSchedules.IsDeleted = true;
            Returnvalue = ExamScheduleManagement.GetInstance.DeleteSchedules(DeleteExamSchedules);
            return Returnvalue;
        }
        protected void Examsheedules_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void Examsheedules_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void Examsheedules_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void drpdwn_Stream_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpdwn_ClassID.Items.Clear();
            drpdwn_ClassID.DataSource =QualClassManagement.GetInstance.GetClassListByStreamAndQual(int.Parse(DropDown_Class.SelectedValue),int.Parse(drpdwn_Stream.SelectedValue));
            drpdwn_ClassID.DataTextField = QualClassManagement.GetInstance.DisplayMember;
            drpdwn_ClassID.DataValueField = QualClassManagement.GetInstance.ValueMember;
            drpdwn_ClassID.DataBind();
            drpdwn_ClassID.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT,"0"));            
        }

        protected void drpdwn_Subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpdwn_Subject.SelectedIndex != MicroConstants.NUMERIC_VALUE_ZERO)
            {
                String Schedule = drpdwn_ExamID.SelectedItem.Text + "[" + drpdwn_ClassID.SelectedItem.Text + "-" + drpdwn_Subject.SelectedItem.Text+"]";
                txt_ExamSeheduleName.Text = Schedule;
            }
        }

        protected void drpdwn_ExamID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DropDown_Class.Items.Clear();
            BindClass();
            //BindDropdown_Qual_Classes();
        }
        private void BindClass()
        {
            Exams objExams = new Exams();
            objExams = (from xyzl in ExamManagement.GetInstance.GetExamsList()
                        where xyzl.ExamID == int.Parse(drpdwn_ExamID.SelectedValue)
                        select xyzl).Single();
            DropDown_Class.SelectedValue = objExams.QualID.ToString();
            DropDown_Class.Enabled = false;
        }        

        protected void Link_GenerateScudeleName_Click(object sender, EventArgs e)
        {
            
        }

        protected void drpdwn_PaperID_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Schedule = drpdwn_ExamID.SelectedItem.Text + "@" + DropDown_Class.SelectedItem.Text + "-" + drpdwn_Stream.SelectedItem.Text + "-" + drpdwn_Subject.SelectedItem.Text ;
            txt_ExamSeheduleName.Text = Schedule;
        }

        protected void gridview_Examsheedules_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview_Examsheedules.PageIndex = e.NewPageIndex;
            Bind_Exam_Sedhule();

        }

        protected void drpdwn_ClassID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown_Stream_Subjects();
        }

        protected void DropDown_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}