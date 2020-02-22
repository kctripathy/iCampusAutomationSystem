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
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.EXAM;
using Micro.Objects.Administration;
using Micro.Framework.ReadXML;
using Micro.Objects.FinancialAccounts;
using Micro.BusinessLayer.FinancialAccounts;
namespace LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT
{
    public partial class StudentSubjects : System.Web.UI.Page
    {

        protected static class PageVariables
        {
            public static Subjects ThisSubject
            {
                get
                {
                    Subjects ThisSubject = HttpContext.Current.Session["ThisSubject"] as Subjects;
                    return ThisSubject;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisSubject", value);
                }
            }
            public static List<Subjects> SubjectList
            {
                get
                {
                    List<Subjects> Subjectlist = HttpContext.Current.Session["Subjectlist"] as List<Subjects>;
                    return Subjectlist;
                }
                set
                {
                    HttpContext.Current.Session.Add("Subjectlist", value);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                multiview_Subject.SetActiveView(InputControls);
                Bind_Subject_List(string.Empty);
                BindDropDown_SubjectTypeName();
                BindDropDown_QualID();
                BindDropDown_StreamID();
                BindDropdown_SessionID("");
                BindStaffs();
                //SetValidationMessages();
            }
        }
        private void BindStaffs()
        {
            DropDown_Staff.DataSource=StaffMasterManagement.GetInstance.GetEmployeeList();
            DropDown_Staff.DataValueField = StaffMasterManagement.GetInstance.ValueMember;
            DropDown_Staff.DataTextField = StaffMasterManagement.GetInstance.DisplayMember;
            DropDown_Staff.DataBind();
        }
        private void BindDropdown_SessionID(string SearctText)
        {
            List<AccountingYear> AccountingYearlist = new List<AccountingYear>();
            AccountingYearlist = AccountingYearManagement.GetInstance.GetAccountingYearList(SearctText);
            DropDown_SessionID.DataSource = AccountingYearlist;
            DropDown_SessionID.DataValueField = "AccountingYearID";
            DropDown_SessionID.DataTextField = "AccountingYearDescription";
            DropDown_SessionID.DataBind();
        }

        private void BindDropDown_SubjectTypeName()
        {
            DropDown_SubjectTypeName.Items.Clear();
            //DropDown_SubjectTypeName.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream();
            DropDown_SubjectTypeName.DataTextField = "SubjectName";
            DropDown_SubjectTypeName.DataValueField = "SubjectID";
            DropDown_SubjectTypeName.DataBind();
            DropDown_SubjectTypeName.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }

        private void BindDropDown_StreamID()
        {
            DropDown_StreamID.Items.Clear();
            DropDown_StreamID.DataSource = StreamManagement.GetInstance.GetStreamList();
            DropDown_StreamID.DataTextField = "StreamName";
            DropDown_StreamID.DataValueField = "StreamID";
            DropDown_StreamID.DataBind();
            DropDown_StreamID.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }

        private void BindDropDown_QualID()
        {
            DropDown_QualID.Items.Clear();
            List<Qualification> objQuals = new List<Qualification>();
            objQuals = (from xyzl in QualManagement.GetInstance.GetQualsList()
                        where xyzl.QualType == "C"
                        select xyzl).ToList();
            DropDown_QualID.DataSource = objQuals;
            DropDown_QualID.DataTextField = "QualCode";
            DropDown_QualID.DataValueField = "QualID";
            DropDown_QualID.DataBind();
            DropDown_QualID.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));            
        }
        private int InsertSubjects()
        {
            int Returnvalue = 0;
            Subjects TheSubject = new Subjects();
            TheSubject.SubjectName = txt_SubjectName.Text;
            TheSubject.SubjectTypeName = DropDown_SubjectTypeName.SelectedItem.Text;
            TheSubject.SubjectTypeID = DropDown_SubjectTypeName.SelectedValue;
            TheSubject.QualID = DropDown_QualID.SelectedValue;
            TheSubject.ClassID = DropDown_ClassID.SelectedValue;
            TheSubject.StreamID = DropDown_StreamID.SelectedValue;
            TheSubject.SubjectFullMark = txt_SubjectFullMark.Text;
            TheSubject.StaffID= DropDown_Staff.SelectedValue;
            TheSubject.SubjectPracticalFlag = chk_SubjPratical.Checked;
            TheSubject.SubjectPracticalMark = txt_SubjectPracticalMark.Text;
            TheSubject.SessionID = DropDown_SessionID.SelectedValue;
            TheSubject.isMain = RadioSubjectCategory.SelectedValue == "0" ? "Y" : "N";
            TheSubject.isParent = RadioSubjectCategory.SelectedValue == "1" ? "1" : "0";
            TheSubject.isRoot = RadioSubjectCategory.SelectedValue == "2" ? "Y" : "N";
            TheSubject.ParentID = RadioSubjectCategory.SelectedValue == "2" ? DropDownSub_Cat.SelectedValue : string.Empty;
            //TheExam.DateOfClose = txt_DateOfClose.Text;
            TheSubject.AddedBy = 1;//:TO DO Kanhu HARD CODE
            TheSubject.OfficeID = 44;//:TO DO Kanhu HARD CODE
            TheSubject.CompanyID = 8;//:TO DO Kanhu HARD CODE
            TheSubject.IsActive = true;
            TheSubject.IsDeleted = false;
            Returnvalue = SubjectManagement.GetInstance.InsertSubjects(TheSubject);
            return Returnvalue;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertSubjects();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_ADDED");
                    //ResetAll();
                    Bind_Subject_List(string.Empty);
                    //multiview_Subject.SetActiveView(view_Grid);
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_ADDED");
                }
            }
            else
            {
                ProcReturnValue = UpdateSubjects();
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
        private void Bind_Subject_ConditionList(string searchText)
        {
            gridviewCourseSubjects.DataSource = SubjectManagement.GetInstance.GetSubjectAll(searchText);
            gridviewCourseSubjects.DataBind();
        }
        private void Bind_Subject_List(string searchText)
        {           
            gridview_Subject.DataSource = SubjectManagement.GetInstance.GetSubjectAll(searchText);
            gridview_Subject.DataBind();
        }
        private int UpdateSubjects()
        {
            int Returnvalue = 0;

            Subjects UpdateSubjects = new Subjects();
            UpdateSubjects.SubjectID = (lbl_Hidden_SubjectID.Text);
            UpdateSubjects.SubjectName = txt_SubjectName.Text;
            UpdateSubjects.QualID = DropDown_QualID.SelectedValue;
            UpdateSubjects.ClassID = DropDown_ClassID.SelectedValue;
            UpdateSubjects.StreamID = DropDown_StreamID.SelectedValue;
            UpdateSubjects.SubjectFullMark = txt_SubjectFullMark.Text;
            UpdateSubjects.StaffID = DropDown_Staff.SelectedValue;
            UpdateSubjects.SubjectPracticalFlag = chk_SubjPratical.Checked;
            UpdateSubjects.SessionID = DropDown_SessionID.SelectedValue;
            //UpdateSubjects.ModifiedBy = 44;//:TO DO Kanhu HARD CODE
            UpdateSubjects.OfficeID = 4;//:TO DO Kanhu HARD CODE
            UpdateSubjects.CompanyID = 4;//:TO DO Kanhu HARD CODE
            UpdateSubjects.IsActive = true;
            UpdateSubjects.IsDeleted = false;

            Returnvalue = SubjectManagement.GetInstance.UpdateSubjects(UpdateSubjects);
            return Returnvalue;
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
        public void ResetAll()
        {
            txt_SubjectName.Text = string.Empty;
            DropDown_SubjectTypeName.ClearSelection();
            DropDown_QualID.ClearSelection();
            DropDown_ClassID.ClearSelection();
            DropDown_StreamID.ClearSelection();
            txt_SubjectFullMark.Text = string.Empty;
            DropDown_Staff.SelectedIndex=MicroConstants.NUMERIC_VALUE_ZERO;
            chk_SubjPratical.Checked = false;
            txt_SubjectPracticalMark.Text = string.Empty;
            DropDown_SessionID.ClearSelection();


        }        

        protected void btn_View_Click(object sender, EventArgs e)
        {
            multiview_Subject.SetActiveView(view_Grid);
            //BindGridview();
        }

        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            multiview_Subject.SetActiveView(InputControls);
            btn_Submit.Text = MicroEnums.DataOperation.Save.GetStringValue();
            ResetAll();
        }
        void BindSubjectTypes()
        {
            DropDown_SubjectTypeName.Items.Clear();
            DropDown_SubjectTypeName.DataSource = SubjectTypeManagement.GetInstance.GetSubjectTypeListByCourseStream(int.Parse(DropDown_QualID.SelectedValue), DropDown_StreamID.SelectedValue);
            DropDown_SubjectTypeName.DataTextField = SubjectTypeManagement.GetInstance.DisplayMember;
            DropDown_SubjectTypeName.DataValueField = SubjectTypeManagement.GetInstance.ValueMember;
            DropDown_SubjectTypeName.DataBind();
            DropDown_SubjectTypeName.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);

        }
        void BindClasses()
        {
            DropDown_ClassID.Items.Clear();
            DropDown_ClassID.DataSource = QualClassManagement.GetInstance.GetClassListByStreamAndQual(int.Parse(DropDown_QualID.SelectedValue),int.Parse(DropDown_StreamID.SelectedValue));
            DropDown_ClassID.DataTextField = QualClassManagement.GetInstance.DisplayMember;
            DropDown_ClassID.DataValueField = QualClassManagement.GetInstance.ValueMember;
            DropDown_ClassID.DataBind();
            DropDown_ClassID.Items.Insert(0,MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }
        
        protected void DropDown_StreamID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubjectTypes();
            BindClasses();
            String condition = MicroConstants.CONDITION_AND + "QualID=" + DropDown_QualID.SelectedValue + MicroConstants.CONDITION_AND + "StreamID="+DropDown_StreamID.SelectedValue;
            Bind_Subject_ConditionList(condition);
        }

        protected void gridview_Subject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview_Subject.PageIndex = e.NewPageIndex;
            Bind_Subject_List(string.Empty);
        }
        protected void gridview_Subject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_Subject.Rows[RowIndex].FindControl("lbl_SubjectID")).Text);

                PageVariables.ThisSubject = (from xyz in SubjectManagement.GetInstance.GetSubjectAll(string.Empty)
                                             where xyz.SubjectID == RecordID.ToString()
                                             select xyz).Single();
                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    PopulateFormField(PageVariables.ThisSubject);
                    multiview_Subject.SetActiveView(InputControls);
                    btn_Submit.Text = MicroEnums.DataOperation.Update.GetStringValue();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    ProcReturnValue = DeleteRecord();
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_DELETED");
                        Bind_Subject_List(string.Empty);
                    }
                    else
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_DATA_DELETED");
                    }
                    dialog_Message.Show();
                }
            }
        }

        private int DeleteRecord()
        {
            //throw new NotImplementedException();
            return 0;
        }

        private void PopulateFormField(Subjects subjects)
        {
            DropDown_QualID.SelectedValue = subjects.QualID;
            DropDown_StreamID.SelectedValue = subjects.StreamID;
            //BindDropDown_SubjectTypeName();
            BindClasses();
            DropDown_ClassID.SelectedValue = subjects.ClassID;
            BindSubjectTypes(); 
            DropDown_SubjectTypeName.SelectedValue = subjects.SubjectTypeID;
            DropDown_SessionID.SelectedValue = subjects.SessionID;
            txt_SubjectFullMark.Text = subjects.SubjectFullMark;
            txt_SubjectName.Text = subjects.SubjectName;
            if (subjects.isMain == "1")
                RadioSubjectCategory.SelectedValue = "0";
            if(subjects.isParent=="1")
                RadioSubjectCategory.SelectedValue = "1";
            if (subjects.isRoot == "1")
            {
                Panel_SubCat.Visible = true;
                RadioSubjectCategory.SelectedValue = "2";
                DropDownSub_Cat.SelectedValue = subjects.ParentID;
            }
            else
            {
                Panel_SubCat.Visible = false;
                RadioSubjectCategory.SelectedIndex = 0;                
            }
            //RadioSubjectCategory_SelectedIndexChanged(sender, e);
            DropDown_Staff.SelectedValue = subjects.StaffID;
            txt_SubjectPracticalMark.Text = subjects.SubjectPracticalMark;
            chk_SubjPratical.Checked = subjects.SubjectPracticalFlag;
        }

        protected void gridview_Subject_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_Subject_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void RadioSubjectCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioSubjectCategory.SelectedValue == "2")
            {
                int Stream = int.Parse(DropDown_StreamID.SelectedValue);
                int Qual = int.Parse(DropDown_QualID.SelectedValue);
                string SubType = DropDown_SubjectTypeName.SelectedItem.Text;
                Panel_SubCat.Visible = true;
                DropDownSub_Cat.DataSource = SubjectManagement.GetInstance.GetSubjectListByParent(Stream, Qual, SubType, String.Empty, false);
                DropDownSub_Cat.DataTextField = SubjectManagement.GetInstance.DisplayMember;
                DropDownSub_Cat.DataValueField = SubjectManagement.GetInstance.ValueMember;
                DropDownSub_Cat.DataBind();
                DropDownSub_Cat.Items.Insert(0,MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            }
            else
            {
                Panel_SubCat.Visible = false;
                DropDownSub_Cat.Items.Clear();
            }
        }

        protected void DropDown_ClassID_SelectedIndexChanged(object sender, EventArgs e)
        {
            String condition = MicroConstants.CONDITION_AND + "QualID=" + DropDown_QualID.SelectedValue + MicroConstants.CONDITION_AND + "StreamID=" + DropDown_StreamID.SelectedValue + MicroConstants.CONDITION_AND + "ClassID=" + DropDown_ClassID.SelectedValue;
            Bind_Subject_ConditionList(condition);
        }

        protected void DropDown_SubjectTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            String condition =MicroConstants.CONDITION_AND + "QualID=" + DropDown_QualID.SelectedValue;
            condition = condition + MicroConstants.CONDITION_AND + "StreamID=" + DropDown_StreamID.SelectedValue;
            condition = condition + MicroConstants.CONDITION_AND + "ClassID=" + DropDown_ClassID.SelectedValue;
            condition = condition + MicroConstants.CONDITION_AND + "SubjectTypeID=" + DropDown_SubjectTypeName.SelectedValue;
            Bind_Subject_ConditionList(condition);
        }

        

               
        
}
}

        
           
            
        


     
        

        
    

    

    
    
        
