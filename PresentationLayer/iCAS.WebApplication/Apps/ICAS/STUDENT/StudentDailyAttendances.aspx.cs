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
    public partial class StudentDailyAttendances : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                multiview_StudentAttendance.SetActiveView(InputControls);
                BindGrid();
                SetValidationMessages();
            }
        }             
        private void BindGrid()
       {
           gridview_StudentAttendance.DataSource = StudentAttendanceManagement.GetInstance.GetAttnsList();
           gridview_StudentAttendance.DataBind();
       }
        private void SetValidationMessages()
        {            
            regularExpressionValidator_DateOFAttendancce.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_Invigilator.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_StartTime.ValidationExpression = MicroConstants.REGEX_DECIMAL_GREATERTHANZERO;
            regularExpressionValidator_CloseTime.ValidationExpression = MicroConstants.REGEX_DECIMAL_GREATERTHANZERO;

            regularExpressionValidator_DateOFAttendancce.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");
            regularExpressionValidator_Invigilator.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_ONLY");
            regularExpressionValidator_StartTime.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DECIMAL_GREATERTHANZERO");
            regularExpressionValidator_CloseTime.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DECIMAL_GREATERTHANZERO");

            requiredFieldValidator_ClassStarttime.ErrorMessage = "Start Time Cann Nont Left Blank";
            requiredFieldValidator_ClassClosetime.ErrorMessage ="Close Time Cann Nont Left Blank";
            requiredFieldValidator_DateOfAttendance.ErrorMessage=ReadXML.GetGeneralMessage("ONLY_DATE_FIELD");
            requiredFieldValidator_Faculty.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Faculty");
            requiredFieldValidator_Comment.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Comment");

            requiredFieldValidator_SubjectClass.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_SubjectClass.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Stream");                  
            //SetFormMessageCSSClass("ValidateMessage");
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertStudentAttendance();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_ADDED");
                    multiview_StudentAttendance.SetActiveView(InputControls);
                    BindGrid();
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_ADDED");
                }
            }
            else
            {
                ProcReturnValue = UpdateStudentAttendance();
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

        private int UpdateStudentAttendance()
        {
            int Returnvalue = 0;         
            string X = "";

            foreach (GridViewRow row in gridview_StudentAttedanceList.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk_Attendance");
                Label lbl_StudentID = (Label)row.FindControl("lbl_StudentID");

                X = X + lbl_StudentID.Text + ',';
            }
            X = X.Remove(X.Length - 1);
            StudentAttendance TheAttns = new StudentAttendance();
            TheAttns.AttenID = Convert.ToInt32(hiddenatten.Value);
            TheAttns.StudentIDS = X;
            TheAttns.SubjectID = int.Parse(DropDown_subjectClas.SelectedValue);
            TheAttns.SectionID = int.Parse(DropDown_Section.SelectedValue);
            TheAttns.ClassStartTime = txt_ClassStarttime.Text;
            TheAttns.ClassCloseTime = txt_ClassCloseTime.Text;
            TheAttns.Date = txt_ClassDate.Text;
            TheAttns.StaffID = int.Parse(txt_Faculty.Text);
            TheAttns.Comment = txt_Comment.Text;

            Returnvalue = StudentAttendanceManagement.GetInstance.UpdateStudentAttns(TheAttns);
            return Returnvalue;         
        }
        private void Reset()
        {
            txt_ClassCloseTime.Text = string.Empty;
            txt_ClassStarttime.Text = string.Empty;
            txt_ClassDate.Text = string.Empty;
            txt_Comment.Text = string.Empty;
            txt_Faculty.Text = string.Empty;
            DropDown_subjectClas.Items.Clear();
            DropDown_subjectClas.Items.Insert(0,MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            gridview_StudentAttedanceList.DataSource = null;
            gridview_StudentAttedanceList.DataBind();
            btn_Submit.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Submit1.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Go.Enabled = true;
        }
        private int InsertStudentAttendance()
        {
            int Returnvalue = 0;
            string X = "";

            foreach (GridViewRow row in gridview_StudentAttedanceList.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk_Attendance");
                Label lbl_StudentID = (Label)row.FindControl("lbl_StudentID");
                if (chk.Checked==true)
                X = X + lbl_StudentID.Text + ',';                             
            }
            X = X.Remove(X.Length - 1);
            StudentAttendance TheAttns = new StudentAttendance();
            TheAttns.StudentIDS = X;
            TheAttns.SubjectID = int.Parse(DropDown_subjectClas.SelectedValue);
            TheAttns.SectionID = int.Parse(DropDown_Section.SelectedValue);
            TheAttns.ClassStartTime = txt_ClassStarttime.Text;
            TheAttns.ClassCloseTime = txt_ClassCloseTime.Text;
            TheAttns.Date = txt_ClassDate.Text;
            TheAttns.StaffID = int.Parse(txt_Faculty.Text);
            TheAttns.Comment = txt_Comment.Text;
            Returnvalue = StudentAttendanceManagement.GetInstance.InsertStudentAttns(TheAttns);
            return Returnvalue;
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            multiview_StudentAttendance.SetActiveView(view_Grid);
           
        }        
        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            multiview_StudentAttendance.SetActiveView(InputControls);
            Reset();
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void gridview_StudentAttedanceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void txt_Faculty_TextChanged(object sender, EventArgs e)
        {
            BinDropdnSubject();
        }

        protected void btn_Go_Click(object sender, EventArgs e)
        {
            BindAttendanceList();
        }
        void BinDropdnSubject()
        {
            DropDown_subjectClas.DataSource = SubjectManagement.GetInstance.GetSubjectListByFaculty(int.Parse(txt_Faculty.Text));
            DropDown_subjectClas.DataTextField = SubjectManagement.GetInstance.DisplayMember;
            DropDown_subjectClas.DataValueField = SubjectManagement.GetInstance.ValueMember;
            DropDown_subjectClas.DataBind();
            DropDown_subjectClas.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }
        void BindAttendanceList()
        {
            gridview_StudentAttedanceList.DataSource = StudentManagement.GetInstance.StudentListBySubject(int.Parse(DropDown_subjectClas.SelectedValue), int.Parse(DropDown_Section.SelectedValue));
            gridview_StudentAttedanceList.DataBind();
        }        
        protected void gridview_StudentAttendance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_StudentAttendance.Rows[RowIndex].FindControl("lbl_AttendanceID")).Text);
                StudentAttendance TheAttn;
                TheAttn = (from xyz in StudentAttendanceManagement.GetInstance.GetAttnsList()
                                             where xyz.AttenID == RecordID
                                             select xyz).Single();
                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    PopulateFormField(TheAttn, RecordID);
                    multiview_StudentAttendance.SetActiveView(InputControls);
                    btn_Submit.Text = MicroEnums.DataOperation.Update.GetStringValue();
                    btn_Submit1.Text = MicroEnums.DataOperation.Update.GetStringValue();                    
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
                    ProcReturnValue = DeleteRecord();
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_DELETED");
                        BindGrid();
                    }
                    else
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_DATA_DELETED");
                    }
                    dialog_Message.Show();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
                {
                    PopulateFormField(TheAttn,RecordID);
                    multiview_StudentAttendance.SetActiveView(InputControls);
                    btn_Submit.Visible = false;
                    btn_Submit1.Visible = false;                    
                }
            }
        }

        private void PopulateFormField(StudentAttendance TheAttn,int AttID)
        {
            txt_Faculty.Text = TheAttn.StaffID.ToString();
            hiddenatten.Value = TheAttn.AttenID.ToString();
            BinDropdnSubject();
            DropDown_subjectClas.SelectedValue = TheAttn.SubjectID.ToString();
            txt_ClassStarttime.Text = TheAttn.ClassStartTime;
            txt_ClassCloseTime.Text = TheAttn.ClassCloseTime;
            txt_ClassDate.Text = TheAttn.Date;
            txt_Comment.Text = TheAttn.Comment;
            BindAttendanceList();
            btn_Go.Enabled = false;            
            foreach (GridViewRow row in gridview_StudentAttedanceList.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk_Attendance");
                Label lbl_StudentID = (Label)row.FindControl("lbl_StudentID");
                List<StudentAttendance> TheAttnce=new List<StudentAttendance>();
                TheAttnce = (from xyz in StudentAttendanceManagement.GetInstance.GetAttnsList()
                             where (TheAttn.AttenID.Equals(AttID) && TheAttn.StudentIDS.Contains(lbl_StudentID.Text))  
                             select xyz).ToList();
                if (TheAttnce.Count ==0)
                {
                    chk.Checked = false;
                }
                else
                {
                    chk.Checked=true;
                }

            }                
        }


        private int DeleteRecord()
        {
            throw new NotImplementedException();
        }

        protected void gridview_StudentAttendance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label x = (Label)e.Row.FindControl("lbl_AttendanceID");
            DropDownList ddlStudent = (DropDownList)e.Row.FindControl("ddlStudentsPresent");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ddlStudent.DataSource = StudentAttendanceManagement.GetInstance.GetStudentListByAttnID(int.Parse(x.Text));
                    ddlStudent.DataTextField = "ROLLNo";
                    ddlStudent.DataValueField = "StudentID";
                    ddlStudent.DataBind();
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void gridview_StudentAttendance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gridview_StudentAttendance_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gridview_StudentAttedanceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }        
        }
    }


