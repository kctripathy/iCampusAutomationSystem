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
    public partial class StudentSections : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                multiview_StudentSections.SetActiveView(InputControls);
                BindDropDownList();
                BindGrid();
                SetValidationMessages();
            }
        }             
        private void BindGrid()
       {
           gridview_StudentSection.DataSource = StudentSectionManagement.GetInstance.GetSectionList("");
           gridview_StudentSection.DataBind();
       }
        void BindDropDownList()
        {
            DropDownList_Course.Items.Clear();
            List<Qualification> objQuals = new List<Qualification>();
            objQuals = (from xyzl in QualManagement.GetInstance.GetQualsList()
                        where xyzl.QualType == "C"
                        select xyzl).ToList();
            DropDownList_Course.DataSource = objQuals;
            DropDownList_Course.DataTextField = "QualCode";
            DropDownList_Course.DataValueField = "QualID";
            DropDownList_Course.DataBind();
            DropDownList_Course.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));

            DropDownList_Stream.DataSource = StreamManagement.GetInstance.GetStreamList();
            DropDownList_Stream.DataTextField = "StreamName";//StreamManagement.GetInstance.DisplayMember;
            DropDownList_Stream.DataValueField = "StreamID";//StreamManagement.GetInstance.ValueMember;
            DropDownList_Stream.DataBind();
            DropDownList_Stream.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }
        private void SetValidationMessages()
        {                                          
            requiredFieldValidator_Comment.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Comment");

            requiredFieldValidator_SubjectClass.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_SubjectClass.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Subject");

            requiredFieldValidator_Section.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Section.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Section");     
            //SetFormMessageCSSClass("ValidateMessage");
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertStudentSections();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_ADDED");
                    multiview_StudentSections.SetActiveView(InputControls);
                    BindGrid();
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_ADDED");
                    BindGrid();
                    multiview_StudentSections.SetActiveView(view_Grid);
                }
            }
            else
            {
                ProcReturnValue = UpdateStudentSections();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_UPDATED");
                    multiview_StudentSections.SetActiveView(view_Grid);
                }
                else
                {
                    if (ProcReturnValue == -2)
                    {
                        lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_UPDATED_STUDENT_IN_OTHER_SECTION");
                        Reset();
                    }
                    else
                        lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_UPDATED");
                }
            }

            dialog_Message.Show();
        }

        private int UpdateStudentSections()
        {
            int Returnvalue = 0;
            string X = "";

            foreach (GridViewRow row in gridview_StudentSectionList.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk_Section");
                Label lbl_StudentID = (Label)row.FindControl("lbl_StudentID");
                if (chk.Checked == true)
                    X = X + lbl_StudentID.Text + ',';
            }
            X = X.Remove(X.Length - 1);
            StudentSection TheSection = new StudentSection();
            TheSection.CourseID = int.Parse(DropDownList_Course.SelectedValue);
            TheSection.StreamID = int.Parse(DropDownList_Stream.SelectedValue);
            TheSection.ClassID = int.Parse(DropDownList_Class.SelectedValue);
            TheSection.StudentIDS = X;
            TheSection.SubjectID = int.Parse(DropDown_subjectClas.SelectedValue);
            TheSection.SectionID = int.Parse(DropDown_Section.SelectedValue);
            TheSection.SectionName = DropDown_Section.SelectedItem.Text;
            TheSection.Comment = txt_Comment.Text;
            Returnvalue = StudentSectionManagement.GetInstance.UpdateStudentSection(TheSection);
            return Returnvalue;
        }
        private void Reset()
        {

            DropDownList_Course.SelectedIndex = 0;
            DropDownList_Stream.SelectedIndex = 0;
            DropDown_Section.SelectedIndex = 0;
            DropDown_subjectClas.Items.Clear();
            DropDown_subjectClas.Items.Insert(0,MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            txt_Comment.Text = string.Empty;
            DropDownList_Class.Items.Clear();
            DropDownList_Class.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);

            gridview_StudentSectionList.DataSource = null;
            gridview_StudentSectionList.DataBind();
            btn_Submit.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Submit1.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Go.Enabled = true;
        }
        private int InsertStudentSections()
        {
            int Returnvalue = 0;
            string X = "";

            foreach (GridViewRow row in gridview_StudentSectionList.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk_Section");
                Label lbl_StudentID = (Label)row.FindControl("lbl_StudentID");
                if(chk.Checked==true)
                X = X + lbl_StudentID.Text + ',';                             
            }
            X = X.Remove(X.Length - 1);
            StudentSection TheSection = new StudentSection();
            TheSection.CourseID = int.Parse(DropDownList_Course.SelectedValue);
            TheSection.StreamID = int.Parse(DropDownList_Stream.SelectedValue);
            TheSection.ClassID = int.Parse(DropDownList_Class.SelectedValue);
            TheSection.StudentIDS = X;
            TheSection.SubjectID = int.Parse(DropDown_subjectClas.SelectedValue);
            TheSection.SectionID= int.Parse(DropDown_Section.SelectedValue);
            TheSection.SectionName = DropDown_Section.SelectedItem.Text;
            TheSection.Comment = txt_Comment.Text;
            Returnvalue = StudentSectionManagement.GetInstance.InsertStudentSection(TheSection);
            return Returnvalue;
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            multiview_StudentSections.SetActiveView(view_Grid);
           
        }        
        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            multiview_StudentSections.SetActiveView(InputControls);
            Reset();
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        protected void gridview_StudentAttedanceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
        void CheckSection(string searchText)
        {
            StudentSection TheSection=null;
            try
            {                
                TheSection = (from xyz in StudentSectionManagement.GetInstance.GetSectionList(searchText)
                              where xyz.SectionID == int.Parse(DropDown_Section.SelectedValue)
                              select xyz).Single();                
            }
            catch(Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                {

                }               
            }
            PopulateFormField(TheSection, int.Parse(DropDown_Section.SelectedValue));
        }
        protected void btn_Go_Click(object sender, EventArgs e)
        {
            String Str = MicroConstants.CONDITION_AND + "SubjectID=" + DropDown_subjectClas.SelectedValue;
            CheckSection(Str);
            btn_Go.Enabled = true;
            //BindAttendanceList();
        }        
        void BindAttendanceList()
        {
            gridview_StudentSectionList.DataSource = StudentManagement.GetInstance.StudentListBySubject(int.Parse(DropDown_subjectClas.SelectedValue),MicroConstants.NUMERIC_VALUE_ZERO);
            gridview_StudentSectionList.DataBind();
        }        
        protected void gridview_StudentSection_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            lbl_TheMessage.Text = string.Empty;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_StudentSection.Rows[RowIndex].FindControl("lbl_SectionID")).Text);
                StudentSection TheSection;
                TheSection = (from xyz in StudentSectionManagement.GetInstance.GetSectionList("")
                                             where xyz.SectionID == RecordID
                                             select xyz).Single();
                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    PopulateFormField(TheSection, RecordID);
                    multiview_StudentSections.SetActiveView(InputControls);                   
                    btn_Submit.Text = MicroEnums.DataOperation.Update.GetStringValue();
                    btn_Submit1.Text = MicroEnums.DataOperation.Update.GetStringValue();                    
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
                    ProcReturnValue = DeleteRecord();
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        dialog_Message.Show();
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_DELETED");
                        BindGrid();
                    }
                    else
                    {
                        dialog_Message.Show();
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_DATA_DELETED");
                    }                    
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
                {
                    PopulateFormField(TheSection, RecordID);
                    multiview_StudentSections.SetActiveView(InputControls);
                    btn_Submit.Visible = false;
                    btn_Submit1.Visible = false;                    
                }
            }
        }
        private void PopulateFormField(StudentSection TheSection,int SectionID)
        {
            if (TheSection != null)
            {
                btn_Submit.Visible = true;
                btn_Submit1.Visible = true;
                btn_Submit.Text = MicroEnums.DataOperation.Update.GetStringValue();
                btn_Submit1.Text = MicroEnums.DataOperation.Update.GetStringValue();
                //txt_Faculty.Text = TheAttn.StaffID.ToString();
                DropDownList_Course.SelectedValue = TheSection.CourseID.ToString();
                DropDownList_Stream.SelectedValue = TheSection.StreamID.ToString();
                BindClassListByStreamAndQual();
                DropDownList_Class.SelectedValue = TheSection.ClassID.ToString();
                BindSubjectListByCourseStreamClass();
                DropDown_subjectClas.SelectedValue = TheSection.SubjectID.ToString();
                DropDown_Section.SelectedValue = TheSection.SectionID.ToString();
                txt_Comment.Text = TheSection.Comment;
            }
            BindAttendanceList();
            btn_Go.Enabled = false;
            if (TheSection != null)
            {
                foreach (GridViewRow row in gridview_StudentSectionList.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chk_Section");
                    Label lbl_StudentID = (Label)row.FindControl("lbl_StudentID");
                    List<StudentSection> TheSectionList = new List<StudentSection>();
                    TheSectionList = (from xyz in StudentSectionManagement.GetInstance.GetSectionList("")
                                      where (TheSection.SectionID.Equals(SectionID) && TheSection.StudentIDS.Contains(lbl_StudentID.Text))
                                      select xyz).ToList();
                    if (TheSectionList.Count == 0)
                    {
                        chk.Checked = false;
                    }
                    else
                    {
                        chk.Checked = true;
                    }
                }
            }
            else
            {
                btn_Submit.Text = MicroEnums.DataOperation.Save.GetStringValue();
                btn_Submit1.Text = MicroEnums.DataOperation.Save.GetStringValue();
            }
        }

        private int DeleteRecord()
        {
            throw new NotImplementedException();
        }

        protected void gridview_StudentSection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label x = (Label)e.Row.FindControl("lbl_SectiongroupID");
            DropDownList ddlStudent = (DropDownList)e.Row.FindControl("ddlStudentsSection");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ddlStudent.DataSource = StudentSectionManagement.GetInstance.GetStudentListBySectionID(int.Parse(x.Text));
                    ddlStudent.DataTextField = "ROLLNo";
                    ddlStudent.DataValueField = "StudentID";
                    ddlStudent.DataBind();
                }
                catch (Exception ex)
                {

                }
            }
        }        

        protected void gridview_StudentSection_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gridview_StudentSectionList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        void BindClassListByStreamAndQual()
        {
            DropDownList_Class.Items.Clear();
            DropDownList_Class.DataSource = QualClassManagement.GetInstance.GetClassListByStreamAndQual(int.Parse(DropDownList_Course.SelectedValue), int.Parse(DropDownList_Stream.SelectedValue));
            DropDownList_Class.DataTextField = QualClassManagement.GetInstance.DisplayMember;
            DropDownList_Class.DataValueField = QualClassManagement.GetInstance.ValueMember;
            DropDownList_Class.DataBind();
            DropDownList_Class.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }
        protected void DropDownList_Stream_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClassListByStreamAndQual();
        }
        void BindSubjectListByCourseStreamClass()
        {
            Subjects ObjSubjects = new Subjects();
            ObjSubjects.QualID = DropDownList_Course.SelectedValue;
            ObjSubjects.StreamID = DropDownList_Stream.SelectedValue;
            ObjSubjects.ClassID = DropDownList_Class.SelectedValue;
            DropDown_subjectClas.Items.Clear();
            DropDown_subjectClas.DataSource = SubjectManagement.GetInstance.GetSubjectListByCourseStreamClass(ObjSubjects, "", false);
            DropDown_subjectClas.DataTextField = SubjectManagement.GetInstance.DisplayMember;
            DropDown_subjectClas.DataValueField = SubjectManagement.GetInstance.ValueMember;
            DropDown_subjectClas.DataBind();
            DropDown_subjectClas.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }
        protected void DropDownList_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubjectListByCourseStreamClass();
        }
        protected void gridview_StudentSectionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gridview_StudentSection_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

                
        }
    }


