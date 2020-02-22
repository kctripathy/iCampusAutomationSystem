
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.Administration;
using Micro.BusinessLayer.ICAS.FINANCE;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.Commons;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;
using Micro.Objects.FinancialAccounts;
using Micro.Objects.ICAS.FINANCE;
using Micro.Objects.ICAS.STUDENT;


namespace Micro.WebApplication.APPS.ICAS.STUDENT
{
    public partial class StudentAdmission : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {

            public static Student ThisStudent
            {
                get
                {
                    Student TheStudent = HttpContext.Current.Session["ThisStudent"] as Student;
                    return TheStudent;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisStudent", value);
                }
            }
            public static List<Student> StudentrList
            {
                get
                {
                    List<Student> TheStudentList = HttpContext.Current.Session["StudentrList"] as List<Student>;
                    return TheStudentList;
                }
                set
                {
                    HttpContext.Current.Session.Add("StudentrList", value);
                }
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;

            if (!IsPostBack && !IsCallback)
            {
                drpdwn_Salutation.Focus();
                check_Address.Checked = false;
                Student_Multi.SetActiveView(View_Grid);
                BindGridView();
                BindDropdown_PresentDistrict();
                BindDropdown_PermanetDistrict();
                BindDropdown_Salutation();
                BindDropdown_Quals();
                BindDropdown_Streams();
                BindDropdown_Gender();
                ResetSubjectAndPrevQual();
                SetValidationMessages();
                BindAccountingYear(string.Empty);

                ctrl_Search.SearchWhat = MicroEnums.SearchForm.Student.ToString();
            }
        }

        private void searchCtrl_ButtonClicked(object sender, System.EventArgs e)
        {
            SearchControlBindGridView();
        }

        private void SearchControlBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

             
            List<Student> theStudentList = new List<Student>();
            if (PageVariables.StudentrList.Count>0)
            {
                if (searchField == MicroEnums.SearchStudent.StudentName.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        theStudentList = (from theName in PageVariables.StudentrList
                                      where theName.StudentName.ToUpper().StartsWith(searchText.ToUpper())
                                      select theName).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        theStudentList = (from tickName in PageVariables.StudentrList
                                          where tickName.StudentName.ToUpper().Contains(searchText.ToUpper())
                                      select tickName).ToList();
                    }
                }
                if (searchField == MicroEnums.SearchStudent.MobilePhone.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        theStudentList = (from theName in PageVariables.StudentrList
                                          where theName.Mobile.ToUpper().StartsWith(searchText.ToUpper())
                                          select theName).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        theStudentList = (from tickName in PageVariables.StudentrList
                                          where tickName.Mobile.ToUpper().Contains(searchText.ToUpper())
                                          select tickName).ToList();
                    }
                }
                ctrl_Search.SearchResultCount = theStudentList.Count.ToString();
                gridview_Students.DataSource = theStudentList;
                gridview_Students.DataBind();
            }
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            Student_Multi.SetActiveView(View_Grid);
            BindGridView();
        }

        private void BindDropdown_Streams()
        {
            DropDown_StreamList.DataSource = StreamManagement.GetInstance.GetStreamList();
            DropDown_StreamList.DataTextField = "StreamName";//StreamManagement.GetInstance.DisplayMember;
            DropDown_StreamList.DataValueField = "StreamID";//StreamManagement.GetInstance.ValueMember;
            DropDown_StreamList.DataBind();
            DropDown_StreamList.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        private void BindDropdown_Quals()
        {
            drpdwn_CourseId.Items.Clear();
            List<Qualification> objQuals = new List<Qualification>();
            objQuals = (from xyzl in QualManagement.GetInstance.GetQualsList()
                        where xyzl.QualType == "C"
                        select xyzl).ToList();
            drpdwn_CourseId.DataSource = objQuals;
            drpdwn_CourseId.DataTextField = "QualCode";
            drpdwn_CourseId.DataValueField = "QualID";
            drpdwn_CourseId.DataBind();
            drpdwn_CourseId.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));

            ddl_Qualification.Items.Clear();
            ddl_Qualification.DataSource = QualManagement.GetInstance.GetQualsList();
            ddl_Qualification.DataTextField = QualManagement.GetInstance.DisplayMember;
            ddl_Qualification.DataValueField = QualManagement.GetInstance.ValueMember;
            ddl_Qualification.DataBind();
            ddl_Qualification.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            Student_Multi.SetActiveView(InputControls);
            btn_Submit.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Submit1.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Submit2.Text = MicroEnums.DataOperation.Save.GetStringValue();
            ResetAll();
        }

        public List<StudentSubjectTaken> StudeSubjects()
        {
            List<StudentSubjectTaken> ObjSubjects = new List<StudentSubjectTaken>();
            foreach (ListItem liComp in chk_ChooseCompulsory.Items)
            {
                if (liComp.Selected)
                {
                    StudentSubjectTaken SingleObjComp = new StudentSubjectTaken();
                    SingleObjComp.SubjectID = int.Parse(liComp.Value);
                    SingleObjComp.SubjectType = "Compulsory";
                    ObjSubjects.Add(SingleObjComp);
                }
            }
            foreach (ListItem liminor in chk_chooseminor.Items)
            {
                if (liminor.Selected)
                {
                    StudentSubjectTaken SingleObjMinor = new StudentSubjectTaken();
                    SingleObjMinor.SubjectID = int.Parse(liminor.Value);
                    SingleObjMinor.SubjectType = "Minor";
                    ObjSubjects.Add(SingleObjMinor);
                }
            }
            foreach (ListItem limajor in chk_choosemajor.Items)
            {
                if (limajor.Selected)
                {
                    StudentSubjectTaken SingleObjMajor = new StudentSubjectTaken();
                    SingleObjMajor.SubjectID = int.Parse(limajor.Value);
                    SingleObjMajor.SubjectType = "Major";
                    ObjSubjects.Add(SingleObjMajor);
                }
            }
            foreach (ListItem lielective in chk_chooseElective.Items)
            {
                if (lielective.Selected)
                {
                    StudentSubjectTaken SingleObjelective = new StudentSubjectTaken();
                    SingleObjelective.SubjectID = int.Parse(lielective.Value);
                    SingleObjelective.SubjectType = "Elective";
                    ObjSubjects.Add(SingleObjelective);
                }
            }
            foreach (ListItem lihons in chk_chooseHons.Items)
            {
                if (lihons.Selected)
                {
                    StudentSubjectTaken SingleObjhons = new StudentSubjectTaken();
                    SingleObjhons.SubjectID = int.Parse(lihons.Value);
                    SingleObjhons.SubjectType = "Hons";
                    ObjSubjects.Add(SingleObjhons);
                }
            }
            foreach (ListItem lipass in chk_choosepass.Items)
            {
                if (lipass.Selected)
                {
                    StudentSubjectTaken SingleObjpass = new StudentSubjectTaken();
                    SingleObjpass.SubjectID = int.Parse(lipass.Value);
                    SingleObjpass.SubjectType = "Pass";
                    ObjSubjects.Add(SingleObjpass);
                }
            }
            return ObjSubjects;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            lbl_TheMessage.Text = "";
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            List<StudentSubjectTaken> StudentSubjects = new List<StudentSubjectTaken>();
            List<StudentPreviousQual> StudentPreQualList = new List<StudentPreviousQual>();
            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertStudent(StudentSubjects, StudentPreQualList);
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_ADDED");
                    ResetAll();
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_ADDED");
                }
            }
            else
            {
                if (CheckSubjects() == false) return;//Checking The Subject Status           
                ProcReturnValue = UpdateStudent(StudentSubjects);
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_UPDATED");
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_UPDATED");
                    dialog_Message.Show();
                    Student_Multi.SetActiveView(View_Grid);
                }
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
        }

        public static string GetAccountID(GridView parentControl)
        {



            return "";


        }

        private bool CheckSubjects()
        {
            bool CheckVal = true;
            lbl_TheMessage.Text = string.Empty;
            int maxElective = MicroConstants.NUMERIC_VALUE_ZERO;
            foreach (ListItem Chkitem in chk_chooseElective.Items)
            {
                if (Chkitem.Selected == true) maxElective++;
            }
            int minormax = MicroConstants.NUMERIC_VALUE_ZERO;
            foreach (ListItem Chkitem in chk_chooseminor.Items)
            {
                if (Chkitem.Selected == true) minormax++;
            }
            int passmax = MicroConstants.NUMERIC_VALUE_ZERO;
            foreach (ListItem Chkitem in chk_choosepass.Items)
            {
                if (Chkitem.Selected == true) passmax++;
            }
            int majormax = MicroConstants.NUMERIC_VALUE_ZERO;
            foreach (ListItem Chkitem in chk_choosemajor.Items)
            {
                if (Chkitem.Selected == true) majormax++;
            }
            int honsmax = MicroConstants.NUMERIC_VALUE_ZERO;
            foreach (ListItem Chkitem in chk_chooseHons.Items)
            {
                if (Chkitem.Selected == true) honsmax++;
            }

            // ========================================================================
            //  +2 
            // ========================================================================
            if (drpdwn_CourseId.SelectedValue.Equals(MicroConstants.NUMERIC_TWO.ToString()))
            {
                if (maxElective != 4)
                {
                    //lbl_MaxSub_elective.Text = "!!! Please Choose Four no of Elective Subjects!!!";
                    dialog_Message.Show();
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("FOUR_ELECTIVE_SUBJECT");
                    chk_chooseElective.Focus();
                    CheckVal = false;
                }
            }
            // ========================================================================
            //  +3 (1st & second year)
            // ========================================================================
            else if (drpdwn_CourseId.SelectedValue.Equals(MicroConstants.NUMERIC_THREE.ToString()) &&
                        (DropDown_StreamList.SelectedValue.Equals(MicroConstants.NUMERIC_ONE.ToString()) ||
                         DropDown_StreamList.SelectedValue.Equals(MicroConstants.NUMERIC_TWO.ToString())))
            {
                // ========================================================================
                //  +3 SCIENCE
                // ========================================================================
                if (DropDown_StreamList.SelectedValue.Trim().Equals(MicroConstants.NUMERIC_ONE.ToString()))
                {
                    if (minormax != MicroConstants.NUMERIC_ONE)
                    {
                        //lblmaxminor.Text = "!!! Please Choose One Minor Subject!!!";
                        //dialog_Message.Show();
                        lbl_TheMessage.Text = ReadXML.GetFailureMessage("ONE_MINOR_SUBJECT");
                        //chk_chooseminor.Focus();
                        CheckVal = false;
                    }
                    if (passmax != MicroConstants.NUMERIC_ONE)
                    {
                        //lblpassmax.Text = "!!! Please Choose One Pass Subject!!!";
                        //dialog_Message.Show();
                        lbl_TheMessage.Text += Environment.NewLine + ReadXML.GetFailureMessage("ONE_PASS_SUBJECT");
                        //chk_choosepass.Focus();
                        CheckVal = false;
                    }
                    if (majormax != MicroConstants.NUMERIC_ONE)
                    {
                        //lblmaxmajor.Text = "!!! Please Choose One Major Subject!!!";
                        //dialog_Message.Show();
                        lbl_TheMessage.Text += Environment.NewLine + ReadXML.GetFailureMessage("ONE_MAJOR_SUBJECT");
                        //chk_choosemajor.Focus();
                        CheckVal = false;
                    }
                    if (honsmax != MicroConstants.NUMERIC_ONE)
                    {
                        //lblhonsmax.Text = "!!! Please Choose One Hons. Subjects!!!";
                        //dialog_Message.Show();
                        lbl_TheMessage.Text += Environment.NewLine + ReadXML.GetFailureMessage("ONE_HONS_SUBJECT");
                        //chk_chooseHons.Focus();
                        CheckVal = false;
                    }

                    if (CheckVal == false)
                    {
                        dialog_Message.Show();
                    }
                }
                else
                {
                    // ========================================================================
                    //  +3 ARTS
                    // ========================================================================
                    if (maxElective != MicroConstants.NUMERIC_TWO)
                    {
                        //lbl_MaxSub_elective.Text = "!!! Please Choose Two no of Elective Subjects!!!";
                        //dialog_Message.Show();
                        lbl_TheMessage.Text = ReadXML.GetFailureMessage("TWO_ELECTIVE_SUBJECT");
                        //chk_chooseElective.Focus();
                        CheckVal = false;
                    }
                    if (passmax != MicroConstants.NUMERIC_TWO)
                    {
                        //lblpassmax.Text = "!!! Please Choose Two no of Pass Subjects!!!";
                        //dialog_Message.Show();
                        lbl_TheMessage.Text += Environment.NewLine + ReadXML.GetFailureMessage("TWO_PASS_SUBJECT");
                        //chk_choosepass.Focus();
                        CheckVal = false;
                    }
                    if (honsmax != MicroConstants.NUMERIC_ONE)
                    {
                        //lblhonsmax.Text = "!!! Please Choose One Hons. Subjects!!!";
                        //dialog_Message.Show();
                        lbl_TheMessage.Text += Environment.NewLine + ReadXML.GetFailureMessage("ONE_HONS_SUBJECT");
                        //chk_chooseHons.Focus();
                        CheckVal = false;
                    }
                    if (CheckVal == false)
                    {
                        dialog_Message.Show();
                    }
                }

            }
            return CheckVal;
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            //ResetAll();
            //GetSubjectIDs(chklist_MinorSubject);
            Student_Multi.SetActiveView(View_Grid);
        }

        protected void check_Address_CheckedChanged(object sender, EventArgs e)
        {
            CopyPresentAddress();
        }

        public List<Qualification> BindCurrentQuals()
        {
            List<Qualification> objQuals = new List<Qualification>();
            objQuals = (from xyzl in QualManagement.GetInstance.GetQualsList()
                        where xyzl.QualType == "C"
                        select xyzl).ToList();
            return objQuals;
        }

        public List<StudentSubjectTaken> BindMinorSubjects(int StudentID)
        {
            List<StudentSubjectTaken> objSubjectTaken = new List<StudentSubjectTaken>();
            objSubjectTaken = (from xyzl in StudentSubjectManagement.GetInstance.GetStudentSubjectAll()
                               where xyzl.SubjectType == "Minor" && xyzl.StudentID.ToString() == StudentID.ToString()
                               select xyzl).ToList();

            return objSubjectTaken;
        }

        public List<StudentSubjectTaken> BindCompulsorySubjects(int StudentID)
        {
            List<StudentSubjectTaken> objSubjectTaken = new List<StudentSubjectTaken>();
            objSubjectTaken = (from xyzl in StudentSubjectManagement.GetInstance.GetStudentSubjectAll()
                               where xyzl.SubjectType == "Compulsory" && xyzl.StudentID.ToString() == StudentID.ToString()
                               select xyzl).ToList();

            return objSubjectTaken;
        }

        public List<StudentSubjectTaken> BindelEctiveSubjects(int StudentID)
        {
            List<StudentSubjectTaken> objSubjectTaken = new List<StudentSubjectTaken>();
            objSubjectTaken = (from xyzl in StudentSubjectManagement.GetInstance.GetStudentSubjectAll()
                               where xyzl.SubjectType == "Elective" && xyzl.StudentID.ToString() == StudentID.ToString()
                               select xyzl).ToList();

            return objSubjectTaken;
        }

        private List<StudentSubjectTaken> BindPassSubjects(int StudentID)
        {
            List<StudentSubjectTaken> objSubjectTaken = new List<StudentSubjectTaken>();
            objSubjectTaken = (from xyzl in StudentSubjectManagement.GetInstance.GetStudentSubjectAll()
                               where xyzl.SubjectType == "Pass" && xyzl.StudentID.ToString() == StudentID.ToString()
                               select xyzl).ToList();

            return objSubjectTaken;
        }

        private List<StudentSubjectTaken> BindHonsSubjects(int StudentID)
        {
            List<StudentSubjectTaken> objSubjectTaken = new List<StudentSubjectTaken>();
            objSubjectTaken = (from xyzl in StudentSubjectManagement.GetInstance.GetStudentSubjectAll()
                               where xyzl.SubjectType == "Hons" && xyzl.StudentID.ToString() == StudentID.ToString()
                               select xyzl).ToList();

            return objSubjectTaken;
        }

        private List<StudentSubjectTaken> BindMajorSubjects(int StudentID)
        {
            List<StudentSubjectTaken> objSubjectTaken = new List<StudentSubjectTaken>();
            objSubjectTaken = (from xyzl in StudentSubjectManagement.GetInstance.GetStudentSubjectAll()
                               where xyzl.SubjectType == "Major" && xyzl.StudentID.ToString() == StudentID.ToString()
                               select xyzl).ToList();

            return objSubjectTaken;
        }

        protected void gridview_Students_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int RecordID = int.Parse(((Label)gridview_Students.Rows[RowIndex].FindControl("lbl_StudentId")).Text);

                    PageVariables.ThisStudent = (from xyz in StudentManagement.GetInstance.GetStudentList()
                                                 where xyz.StudentID == RecordID
                                                 select xyz).Single();

                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    ProcReturnValue = DeleteRecord();
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_DELETED");
                        BindGridView();
                    }
                    else
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_DATA_DELETED");
                    }
                    dialog_Message.Show();
                }
                else
                {
                    RowIndex = Convert.ToInt32(e.CommandArgument);
                    int RecordID = int.Parse(((Label)gridview_Students.Rows[RowIndex].FindControl("lbl_StudentId")).Text);

                    PageVariables.ThisStudent = (from xyz in StudentManagement.GetInstance.GetStudentList()
                                                 where xyz.StudentID == RecordID
                                                 select xyz).Single();
                    if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                    {
                        PopulateFormField(PageVariables.ThisStudent);
                        Student_Multi.SetActiveView(InputControls);
                        PnlPrevQual.Visible = false;
                        btn_Submit.Text = MicroEnums.DataOperation.Update.GetStringValue();
                        btn_Submit1.Text = MicroEnums.DataOperation.Update.GetStringValue();
                        btn_Submit2.Text = MicroEnums.DataOperation.Update.GetStringValue();
                    }
                    else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
                    {
                        PopulateFormField(PageVariables.ThisStudent);
                        Student_Multi.SetActiveView(InputControls);
                        PnlPrevQual.Visible = false;
                        btn_Submit.Text = MicroEnums.DataOperation.Update.GetStringValue();
                        btn_Submit1.Text = MicroEnums.DataOperation.Update.GetStringValue();
                        btn_Submit2.Text = MicroEnums.DataOperation.Update.GetStringValue();
                    }
                }
            }
        }

        protected void gridview_Students_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_Students_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void drpdwn_PresentDistrictId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                District theDistrict = DistrictManagement.GetInstance.GetDistrictStateCountryByDistrictId(int.Parse(drpdwn_PresentDistrictId.SelectedValue));
                txt_PresentStateName.Text = theDistrict.StateName;
                txt_PresentCountry.Text = theDistrict.CountryName;
            }
            catch
            {
                txt_PresentStateName.Text = string.Empty;
            }
        }

        protected void drpdwn_PermanentDistrictId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                District theDistrict = DistrictManagement.GetInstance.GetDistrictStateCountryByDistrictId(int.Parse(drpdwn_PermanentDistrictId.SelectedValue));
                txt_PermanentStateName.Text = theDistrict.StateName;
                txt_PermanentCountry.Text = theDistrict.CountryName;
            }
            catch
            {
                txt_PermanentStateName.Text = string.Empty;
            }

        }

        protected void txt_DateOfBirth_TextChanged(object sender, EventArgs e)
        {
            txt_Age.Text = string.Empty;

            if (IsValidDate(txt_DateOfBirth.Text))
            {
                txt_DateOfBirth.Text = DateTime.Parse(txt_DateOfBirth.Text).ToString(MicroConstants.DateFormat);
                txt_Age.Text = CalculateAge(DateTime.Parse(txt_DateOfBirth.Text)).ToString();
            }
        }

        protected void txt_Age_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_DateOfBirth.Text = CalculateDateOfBirth(txt_Age.Text).ToString(MicroConstants.DateFormat);
            }
            catch
            {
            }
        }

        protected void gridview_Students_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
                    e.Row.Cells[6].Text = "+" + e.Row.Cells[6].Text;
                    string s = e.Row.Cells[7].Text;
                    e.Row.Cells[7].Text = StreamManagement.GetInstance.GetStreamNameById(int.Parse(s));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void chklist_Details_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chklist_Details.SelectedValue.Equals("1"))
            {
                Student_Multi.SetActiveView(View_Grid);
            }
            else if (chklist_Details.SelectedValue.Equals("2"))
            {
                Student_Multi.SetActiveView(View_Admision);
            }
            else if (chklist_Details.SelectedValue.Equals("3"))
            {
                Student_Multi.SetActiveView(View_SubjectEdition);
            }
            else if (chklist_Details.SelectedValue.Equals("4"))
            {
                Student_Multi.SetActiveView(View_LeaveDetails);
            }
        }
        #endregion

        #region Methods & Implementation

        public string SendMailToUser()
        {
            if (txt_EmailId.Text.ToString().Equals(string.Empty))
            {
                return "No";
            }
            else
            {
                string MailTo = txt_EmailId.Text.ToString(); // THE STUDENT -ALUMNI
                string MailCC = ConfigurationManager.AppSettings["MailAddressesTo"] as string;
                string MailCC2 = ConfigurationManager.AppSettings["MailAddressesCC"] as string;
                string MailBCC = ConfigurationManager.AppSettings["MailAddressBCC"] as string;
                string MailSubjectPrefix = ConfigurationManager.AppSettings["MailSubjectPrefix"] as string;
                string MailCompanyPrefix = ConfigurationManager.AppSettings["DefaultCompanyAlias"] as string;
                string MailSubject = string.Format("<{0}> {1} Student Admission", MailSubjectPrefix, MailCompanyPrefix);
                string MailBody = GetHtmlTemplateCode();


                System.Net.Mail.MailMessage eMail = new System.Net.Mail.MailMessage();

                eMail.To.Add(new MailAddress(MailTo));  // STUDENT
                eMail.CC.Add(MailCC); // TSD ADMIN - TO ADDRESS
                eMail.CC.Add(MailCC2); // COLLEGE CC
                eMail.Bcc.Add(MailBCC); // COLLEGE BCC
                eMail.Subject = MailSubject;
                eMail.Body = MailBody;

                string emailContent = GetHtmlTemplateCode();
                try
                {
                    string litMessageText = Micro.Commons.SendMail.SendEmail(eMail, emailContent);
                    return "An"; // This will join with string as : An email has been sent... 
                }
                catch
                {
                    return "No";// This will join with string as : No email has been sent... 
                }




            }
        }

        private string GetHtmlTemplateCode()
        {
            string MailCompanyPrefix = ConfigurationManager.AppSettings["DefaultCompanyAlias"] as string;
            string WebsiteName = ConfigurationManager.AppSettings["WebServerIP_PRDN"] as string;
            string StudentName = string.Format("{0} {1}", drpdwn_Salutation.Text.ToUpper(), txt_StudentName.Text.ToUpper());
            string theFileContent = GetHtmlTemplateCodeReadHTML();
            string MailBody = string.Format(theFileContent, WebsiteName, MailCompanyPrefix, StudentName);
            return MailBody;
        }

        private string GetHtmlTemplateCodeReadHTML()
        {
            string htmlCode = string.Empty;
            string sFileName = Server.MapPath(".") + @"\App_Data\ICAS\html\HtmlPage_MailStudentAdmission.html";
            if (System.IO.File.Exists(sFileName))
            {
                WebClient client = new WebClient();
                htmlCode = client.DownloadString(sFileName);
                //htmlCode = htmlCode.Substring(5, htmlCode.Length-1);
            }
            return htmlCode;
        }


        public void ResetSubjectAndPrevQual()
        {
            chk_ChooseCompulsory.Items.Clear();
            chk_ChooseCompulsory.Items.Insert(0, "Choose Class And Stream");

            chk_chooseElective.Items.Clear();
            //chklist_ElectiveSubjectsBind.Items.Insert(0, "Choose Class And Stream");

            chk_chooseminor.Items.Clear();
            //chklist_MinorSubject.Items.Insert(0, "Choose Class And Stream");


            chk_choosemajor.Items.Clear();
            //chklist_MajorElectiveSubjects.Items.Insert(0, "Choose Class And Stream");

            chk_chooseHons.Items.Clear();
            //chklist_HonsSubjects.Items.Insert(0, "Choose Class And Stream");

            chk_choosepass.Items.Clear();
            //chklistPassSubjects.Items.Insert(0, "Choose Class And Stream");

            gview_Course.DataSource = null;
            gview_Course.DataBind();
            gview_BindCourse.DataSource = null;
            gview_BindCourse.DataBind();
        }
        void BindClasses()
        {
            DropDown_AdmissionTo.Items.Clear();
            DropDown_AdmissionTo.DataSource = QualClassManagement.GetInstance.GetClassListByStreamAndQual(int.Parse(drpdwn_CourseId.SelectedValue), int.Parse(DropDown_StreamList.SelectedValue));
            DropDown_AdmissionTo.DataTextField = QualClassManagement.GetInstance.DisplayMember;
            DropDown_AdmissionTo.DataValueField = QualClassManagement.GetInstance.ValueMember;
            DropDown_AdmissionTo.DataBind();
            //DropDown_AdmissionTo.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }
        public void ResetAll()
        {
            //check_Address_CheckedChanged(null, null);

            txt_MRINo.Text = "."; // string.Empty;
            drpdwn_PresentDistrictId.ClearSelection();
            drpdwn_PermanentDistrictId.ClearSelection();
            check_Address.Checked = false;
            txt_PermanentCity.Text = string.Empty;
            txt_PermanentStateName.Text = string.Empty;
            txt_PermanentCountry.Text = string.Empty;

            txt_PresentCity.Text = string.Empty;
            txt_PresentCountry.Text = string.Empty;
            txt_PresentStateName.Text = string.Empty;
            txt_PresentLandmark.Text = string.Empty;
            txt_ReceiptNo.Text = "."; // string.Empty;
            txt_TCNo.Text = string.Empty;
            txt_RollNo.Text = "."; // string.Empty;
            drpdwn_CourseId.ClearSelection();
            drpdwn_Salutation.ClearSelection();
            txt_StudentName.Text = string.Empty;
            txt_FatherName.Text = string.Empty;
            txt_MotherName.Text = "."; // string.Empty;
            drpdwn_Gender.ClearSelection();
            drpdwn_Caste.ClearSelection();
            radio_PHStatus.ClearSelection();
            ResetSubjectAndPrevQual();
            chk_chooseminor.ClearSelection();
            chk_chooseElective.ClearSelection();
            chk_ChooseCompulsory.ClearSelection();
            BindDropdown_Quals();
            BindDropdown_Streams();
            txt_Status.Text = string.Empty;
            txt_AdmissionAmount.Text = "0.00"; // string.Empty;
            txt_DateOfBirth.Text = string.Empty;
            txt_DateOfAdmission.Text = string.Empty;
            txt_DateOfLeaving.Text = string.Empty;
            txt_Age.Text = string.Empty;
            txt_PresentCity.Text = string.Empty;
            txt_PresentLandmark.Text = string.Empty;
            txt_PresentPincode.Text = string.Empty;
            drpdwn_PresentDistrictId.ClearSelection();
            txt_PermanentCity.Text = string.Empty;
            txt_PermanentLandmark.Text = string.Empty;
            txt_PermanentPincode.Text = string.Empty;
            drpdwn_PermanentDistrictId.ClearSelection();
            txt_PhoneNumber.Text = string.Empty;
            txt_Mobile.Text = string.Empty;
            txt_EmailId.Text = string.Empty;
            check_Address.Checked = true;
            btn_AddQual.Enabled = true;
            btn_Submit.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Submit1.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Submit2.Text = MicroEnums.DataOperation.Save.GetStringValue();
        }

        public void BindGridView()
        {
            PageVariables.StudentrList = StudentManagement.GetInstance.GetStudentList();
            gridview_Students.DataSource = PageVariables.StudentrList;
            gridview_Students.DataBind();
        }

        public void BindAccountingYear(string SearctText)
        {
            List<Micro.Objects.FinancialAccounts.AccountingYear> AccountingYearlist = new List<Micro.Objects.FinancialAccounts.AccountingYear>();
            AccountingYearlist = Micro.BusinessLayer.FinancialAccounts.AccountingYearManagement.GetInstance.GetAccountingYearList(SearctText);
            //AccountingYearManagement.GetInstance.GetAccountingYearList(SearctText);
            ddl_AcademicYear.DataSource = AccountingYearlist;
            ddl_AcademicYear.DataValueField = "AccountingYearID";
            ddl_AcademicYear.DataTextField = "AccountingYearDescription";
            ddl_AcademicYear.DataBind();
        }

        private int InsertStudent(List<StudentSubjectTaken> AllSubjects, List<StudentPreviousQual> StudentPreQualList)
        {
            int Returnvalue = 0;
            AllSubjects = StudeSubjects();
            StudentPreQualList = PreviousQualList();
            Student TheStudent = new Student();
            TheStudent.MRINO = txt_MRINo.Text;
            TheStudent.ReceiptNo = txt_ReceiptNo.Text;
            TheStudent.TCNo = txt_TCNo.Text;
            TheStudent.RollNo = txt_RollNo.Text;
            TheStudent.QualID = int.Parse(drpdwn_CourseId.SelectedValue);
            TheStudent.StreamID = int.Parse(DropDown_StreamList.SelectedValue);
            TheStudent.ClassID = int.Parse(DropDown_AdmissionTo.SelectedValue);
            TheStudent.Salutation = drpdwn_Salutation.SelectedValue;
            TheStudent.StudentName = txt_StudentName.Text;
            TheStudent.FatherName = txt_FatherName.Text;
            TheStudent.MotherName = txt_MotherName.Text;
            TheStudent.Gender = drpdwn_Gender.SelectedValue;
            TheStudent.Caste = drpdwn_Caste.SelectedValue;
            TheStudent.PHStatus = radio_PHStatus.SelectedValue;
            TheStudent.Status = txt_Status.Text;
            TheStudent.TotalFeesPaid = txt_AdmissionAmount.Text;
            TheStudent.DateOfBirth = txt_DateOfBirth.Text;
            TheStudent.DateOfAdmission = txt_DateOfAdmission.Text;
            TheStudent.DateOfLeaving = txt_DateOfLeaving.Text;
            TheStudent.Age = int.Parse(txt_Age.Text);
            TheStudent.Address_Present_TownOrCity = txt_PresentCity.Text;
            TheStudent.Address_Present_Landmark = txt_PresentLandmark.Text;
            TheStudent.Address_Present_PinCode = txt_PresentPincode.Text;
            TheStudent.Address_Present_DistrictID = int.Parse(drpdwn_PresentDistrictId.SelectedValue);
            TheStudent.Address_Permanent_TownOrCity = txt_PermanentCity.Text;
            TheStudent.Address_Permanent_Landmark = txt_PermanentLandmark.Text;
            TheStudent.Address_Permanent_PinCode = txt_PermanentPincode.Text;
            TheStudent.Address_Permanent_DistrictID = int.Parse(drpdwn_PermanentDistrictId.SelectedValue);
            TheStudent.PhoneNumber = txt_PhoneNumber.Text;
            TheStudent.SessionID = int.Parse(ddl_AcademicYear.SelectedValue);
            TheStudent.Mobile = txt_Mobile.Text;
            TheStudent.EMailID = txt_EmailId.Text;
            Returnvalue = StudentManagement.GetInstance.InsertStudent(TheStudent, AllSubjects, StudentPreQualList);
            return Returnvalue;
        }

        private int UpdateStudent(List<StudentSubjectTaken> AllSubjects)
        {
            //Start Finance Pass Section

            //string CheckedItemsValue = string.Empty;
            string AccountID = string.Empty;
            string AccountCode = string.Empty;
            string AccountName = string.Empty;
            string AccountFee = string.Empty;
            string AccountType = string.Empty;
            string AccountNaration = string.Empty;
            foreach (GridViewRow row in gridview_DefaultFee.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk_DefaultFe");
                if (chk.Checked == true)
                {
                    AccountID = AccountID + row.Cells[3].Text + ',';
                    AccountCode = AccountCode + row.Cells[4].Text + ',';
                    AccountName = AccountName + row.Cells[7].Text + ',';
                    AccountFee = AccountFee + row.Cells[8].Text + ',';
                    AccountType = AccountType + "CR" + ',';
                    AccountNaration = AccountNaration + "Being " + row.Cells[7].Text + " Account Debited To Account CASH IN HAND" + ',';
                }
            }
            if (gridview_DefaultFee.Rows.Count > 0)
            {
                AccountID = AccountID.Remove(AccountID.Length - 1);
                AccountCode = AccountCode.Remove(AccountCode.Length - 1);
                AccountName = AccountName.Remove(AccountName.Length - 1);
                AccountFee = AccountFee.Remove(AccountFee.Length - 1);
                AccountType = AccountType.Remove(AccountType.Length - 1);
                AccountNaration = AccountNaration.Remove(AccountNaration.Length - 1);
            }

            //End Finance Pass Section


            int ProcReturnvalue = 0;
            AllSubjects = StudeSubjects();
            PageVariables.ThisStudent.MRINO = txt_MRINo.Text;
            PageVariables.ThisStudent.ReceiptNo = txt_ReceiptNo.Text;
            PageVariables.ThisStudent.TCNo = txt_TCNo.Text;
            PageVariables.ThisStudent.RollNo = txt_RollNo.Text;
            PageVariables.ThisStudent.ClassID = int.Parse(DropDown_AdmissionTo.SelectedValue);
            PageVariables.ThisStudent.QualID = int.Parse(drpdwn_CourseId.SelectedValue);
            PageVariables.ThisStudent.StreamID = int.Parse(DropDown_StreamList.SelectedValue);
            PageVariables.ThisStudent.Salutation = drpdwn_Salutation.Text;
            PageVariables.ThisStudent.StudentName = txt_StudentName.Text;
            PageVariables.ThisStudent.MotherName = txt_MotherName.Text;
            PageVariables.ThisStudent.FatherName = txt_FatherName.Text;
            PageVariables.ThisStudent.Gender = drpdwn_Gender.Text;
            PageVariables.ThisStudent.Caste = drpdwn_Caste.Text;
            PageVariables.ThisStudent.PHStatus = radio_PHStatus.SelectedValue;
            PageVariables.ThisStudent.Status = txt_Status.Text;
            PageVariables.ThisStudent.TotalFeesPaid = txt_AdmissionAmount.Text;
            PageVariables.ThisStudent.DateOfBirth = txt_DateOfBirth.Text;
            PageVariables.ThisStudent.DateOfAdmission = txt_DateOfAdmission.Text;
            PageVariables.ThisStudent.DateOfLeaving = txt_DateOfLeaving.Text;
            PageVariables.ThisStudent.Age = int.Parse(txt_Age.Text);
            PageVariables.ThisStudent.Address_Present_TownOrCity = txt_PresentCity.Text;
            PageVariables.ThisStudent.Address_Present_Landmark = txt_PresentLandmark.Text;
            PageVariables.ThisStudent.Address_Present_PinCode = txt_PresentPincode.Text;
            PageVariables.ThisStudent.Address_Present_DistrictID = int.Parse(drpdwn_PresentDistrictId.SelectedValue.ToString()); // drpdwn_PresentDistrictId.SelectedIndex; //TODO: XXXXXXXXXXXXXXXXXX DISTRICT ID IS NOT POPULATING CORRECTLY
            PageVariables.ThisStudent.Address_Permanent_TownOrCity = txt_PermanentCity.Text;
            PageVariables.ThisStudent.Address_Permanent_Landmark = txt_PermanentLandmark.Text;
            PageVariables.ThisStudent.Address_Permanent_PinCode = txt_PermanentPincode.Text;
            PageVariables.ThisStudent.Address_Permanent_DistrictID = int.Parse(drpdwn_PermanentDistrictId.SelectedValue.ToString()); //drpdwn_PermanentDistrictId.SelectedIndex;
            PageVariables.ThisStudent.PhoneNumber = txt_PhoneNumber.Text;
            PageVariables.ThisStudent.SessionID = int.Parse(ddl_AcademicYear.SelectedValue);
            PageVariables.ThisStudent.Mobile = txt_Mobile.Text;
            PageVariables.ThisStudent.EMailID = txt_EmailId.Text;
            PageVariables.ThisStudent.AccountIDs = AccountID;
            PageVariables.ThisStudent.AccountCodes = AccountCode;
            PageVariables.ThisStudent.AccountNames = AccountName;
            PageVariables.ThisStudent.AccountFees = AccountFee;
            PageVariables.ThisStudent.BalanceTypes = AccountType;
            PageVariables.ThisStudent.Narations = AccountNaration;

            ProcReturnvalue = StudentManagement.GetInstance.UpdateStudent(PageVariables.ThisStudent, AllSubjects);

            return ProcReturnvalue;
        }

        public static int DeleteRecord()
        {
            int ProcReturnValue = StudentManagement.GetInstance.DeleteStudent(PageVariables.ThisStudent);

            return ProcReturnValue;
        }

        private void BindDropdown_PresentDistrict()
        {
            drpdwn_PresentDistrictId.DataSource = DistrictManagement.GetInstance.GetAllDistricts();
            drpdwn_PresentDistrictId.DataTextField = DistrictManagement.GetInstance.DisplayMember;
            drpdwn_PresentDistrictId.DataValueField = DistrictManagement.GetInstance.ValueMember;
            drpdwn_PresentDistrictId.DataBind();
        }

        private void BindDropdown_PermanetDistrict()
        {
            drpdwn_PermanentDistrictId.DataSource = DistrictManagement.GetInstance.GetAllDistricts();
            drpdwn_PermanentDistrictId.DataTextField = DistrictManagement.GetInstance.DisplayMember;
            drpdwn_PermanentDistrictId.DataValueField = DistrictManagement.GetInstance.ValueMember;
            drpdwn_PermanentDistrictId.DataBind();
        }

        private void CopyPresentAddress()
        {
            txt_PermanentLandmark.Text = txt_PresentLandmark.Text;
            txt_PermanentCity.Text = txt_PresentCity.Text;
            drpdwn_PermanentDistrictId.Text = drpdwn_PresentDistrictId.Text;
            txt_PermanentPincode.Text = txt_PresentPincode.Text;
            txt_PermanentStateName.Text = txt_PresentStateName.Text;
            txt_PermanentCountry.Text = txt_PresentCountry.Text;
        }

        private void PopulateFormField(Student theStudent)
        {

            lbl_RegNo.Text = theStudent.StudentCode;
            txt_MRINo.Text = theStudent.MRINO;
            txt_ReceiptNo.Text = theStudent.ReceiptNo;
            txt_TCNo.Text = theStudent.TCNo;
            txt_RollNo.Text = theStudent.RollNo;
            drpdwn_CourseId.SelectedValue = theStudent.QualID.ToString();
            DropDown_StreamList.SelectedValue = theStudent.StreamID.ToString();

            gridview_DefaultFee.DataSource = DefaultFeeManagement.GetInstance.GetDefaultFeeListByQual_Stream(theStudent.QualID, theStudent.StreamID);
            gridview_DefaultFee.DataBind();

            BindClasses();
            DropDown_AdmissionTo.SelectedValue = theStudent.ClassID.ToString();
            drpdwn_Salutation.SelectedIndex = BasePage.GetDropDownSelectedIndex(drpdwn_Salutation, theStudent.Salutation);
            txt_StudentName.Text = theStudent.StudentName;
            txt_FatherName.Text = theStudent.FatherName;
            txt_MotherName.Text = theStudent.MotherName;
            drpdwn_Gender.SelectedIndex = BasePage.GetDropDownSelectedIndex(drpdwn_Gender, theStudent.Gender);
            drpdwn_Caste.SelectedIndex = BasePage.GetDropDownSelectedIndex(drpdwn_Caste, theStudent.Gender);
            radio_PHStatus.SelectedIndex = BasePage.GetRadioButtonSelectedIndex(radio_PHStatus, theStudent.PHStatus);
            txt_Age.Text = theStudent.Age.ToString();
            txt_Status.Text = theStudent.Status;
            txt_AdmissionAmount.Text = theStudent.TotalFeesPaid;
            txt_DateOfBirth.Text = theStudent.DateOfBirth;
            txt_DateOfAdmission.Text = theStudent.DateOfAdmission;
            txt_DateOfLeaving.Text = theStudent.DateOfLeaving;
            txt_PresentCity.Text = theStudent.Address_Present_TownOrCity;
            txt_PresentLandmark.Text = theStudent.Address_Present_Landmark;
            txt_PresentPincode.Text = theStudent.Address_Present_PinCode;

            drpdwn_PresentDistrictId.SelectedIndex = GetDropDownSelectedIndex(drpdwn_PresentDistrictId, Convert.ToString(theStudent.Address_Present_DistrictID));
            //drpdwn_PresentDistrictId.Text= theStudent.Address_Permanent_StateName;
            txt_PresentStateName.Text = theStudent.Address_Present_StateName;
            txt_PresentCountry.Text = theStudent.Address_Present_CountryName;
            txt_PermanentLandmark.Text = theStudent.Address_Permanent_Landmark;
            txt_PermanentPincode.Text = theStudent.Address_Permanent_PinCode;
            drpdwn_PermanentDistrictId.SelectedIndex = GetDropDownSelectedIndex(drpdwn_PermanentDistrictId, Convert.ToString(theStudent.Address_Permanent_DistrictID));
            txt_PermanentStateName.Text = theStudent.Address_Permanent_StateName;
            txt_PermanentCountry.Text = theStudent.Address_Permanent_CountryName;
            txt_PermanentCity.Text = theStudent.Address_Permanent_TownOrCity;
            txt_PhoneNumber.Text = theStudent.PhoneNumber;
            txt_Mobile.Text = theStudent.Mobile;
            txt_EmailId.Text = theStudent.EMailID;
            //Binding Selected Subjects and Prev Qualifications
            ResetSubjectAndPrevQual();
            //Binding Chooose Subjects
            bindSubjects(theStudent);
            //Binding Student subjects
            //BindSubjectsAndPreviousQualGrid(theStudent);                        
            btn_AddQual.Enabled = false;
        }
        //void BindSubjectsAndPreviousQualGrid(Student theStudent)
        //{
        //    CheckSubjects();
        //    int StreamID = int.Parse(DropDown_StreamList.SelectedValue);
        //    int CourseID = int.Parse(drpdwn_CourseId.SelectedValue);

        //    chklist_CompulsorySubjectLists.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "COMPULSORY", String.Empty, false);
        //    chklist_CompulsorySubjectLists.DataTextField = "SubjectName";//StreamManagement.GetInstance.DisplayMember;
        //    chklist_CompulsorySubjectLists.DataValueField = "SubjectID";//StreamManagement.GetInstance.ValueMember;
        //    chklist_CompulsorySubjectLists.DataBind();
        //    foreach (ListItem list in chklist_CompulsorySubjectLists.Items)
        //    {
        //        list.Selected = true;
        //    }
        //    if (drpdwn_CourseId.SelectedValue.Equals("2"))
        //    {
        //        lbl_MaxCount.Text = "(Max-4)";
        //        chklist_ElectiveSubjectsBind.DataSource = BindelEctiveSubjects(theStudent.StudentID);
        //        chklist_ElectiveSubjectsBind.DataMember = "SubjectID";
        //        chklist_ElectiveSubjectsBind.DataTextField = "SubjectName";
        //        chklist_ElectiveSubjectsBind.DataBind();
        //        foreach (ListItem list in chklist_ElectiveSubjectsBind.Items)
        //        {
        //            list.Selected = true;
        //        }
        //    }
        //    else if (drpdwn_CourseId.SelectedValue.Equals("3") && (DropDown_StreamList.SelectedValue.Equals("1") || DropDown_StreamList.SelectedValue.Equals("2")))
        //    {
        //        if (DropDown_StreamList.SelectedValue.Equals("1"))
        //        {
        //            lbl_PassMaxCount.Text = "(Max-1)";
        //            lbl_MinorMaxCount.Text = "(Max-1)";
        //            chklist_MinorSubject.DataSource = BindMinorSubjects(theStudent.StudentID);
        //            chklist_MinorSubject.DataMember = "SubjectID";
        //            chklist_MinorSubject.DataTextField = "SubjectName";
        //            chklist_MinorSubject.DataBind();

        //            lbl_MajorMaxCount.Text = "(Max-1)";
        //            chklist_MajorElectiveSubjects.DataSource = BindMajorSubjects(theStudent.StudentID);
        //            chklist_MajorElectiveSubjects.DataTextField = "SubjectName";
        //            chklist_MajorElectiveSubjects.DataValueField = "SubjectID";
        //            chklist_MajorElectiveSubjects.DataBind();

        //            foreach (ListItem list in chklist_MinorSubject.Items)
        //            {
        //                list.Selected = true;
        //            }
        //            foreach (ListItem list in chklist_MajorElectiveSubjects.Items)
        //            {
        //                list.Selected = true;
        //            }
        //        }
        //        else
        //        {
        //            lbl_PassMaxCount.Text = "(Max-2)";
        //            lbl_MaxCount.Text = "(Max-2)";
        //            chklist_ElectiveSubjectsBind.DataSource = BindelEctiveSubjects(theStudent.StudentID);
        //            chklist_ElectiveSubjectsBind.DataTextField = "SubjectName";
        //            chklist_ElectiveSubjectsBind.DataValueField = "SubjectID";
        //            chklist_ElectiveSubjectsBind.DataBind();
        //            foreach (ListItem list in chklist_ElectiveSubjectsBind.Items)
        //            {
        //                list.Selected = true;
        //            }
        //        }
        //        lbl_HonsMaxCount.Text = "(Max-1)";
        //        chklist_HonsSubjects.DataSource = BindHonsSubjects(theStudent.StudentID);
        //        chklist_HonsSubjects.DataTextField = "SubjectName";
        //        chklist_HonsSubjects.DataValueField = "SubjectID";
        //        chklist_HonsSubjects.DataBind();
        //        foreach (ListItem list in chklist_HonsSubjects.Items)
        //        {
        //            list.Selected = true;
        //        }

        //        chklistPassSubjects.DataSource = BindPassSubjects(theStudent.StudentID);
        //        chklistPassSubjects.DataTextField = "SubjectName";
        //        chklistPassSubjects.DataValueField = "SubjectID";
        //        chklistPassSubjects.DataBind();
        //        foreach (ListItem list in chklistPassSubjects.Items)
        //        {
        //            list.Selected = true;
        //        }

        //        //Binding Previous Qualification Detail Of then Student 
        //        gview_Course.DataSource = null;
        //        gview_Course.DataBind();
        //        gview_BindCourse.DataSource = StudentPreQualManagement.GetInstance.GetPreQualsList(theStudent.StudentID);
        //        gview_BindCourse.DataBind();
        //    }                              
        //}

        private void BindDropdown_Salutation()
        {
            drpdwn_Salutation.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Salutation.GetStringValue());
            drpdwn_Salutation.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            drpdwn_Salutation.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            drpdwn_Salutation.DataBind();
        }

        private void BindDropdown_Gender()
        {
            drpdwn_Gender.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Gender.GetStringValue());
            drpdwn_Gender.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            drpdwn_Gender.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            drpdwn_Gender.DataBind();
        }
        public List<TempTranAccount> AccountTransList()
        {
            List<TempTranAccount> TempAcList = new List<TempTranAccount>();
            foreach (GridViewRow dr in gview_Course.Rows)
            {
                TempTranAccount theCurrTran = new TempTranAccount
                {
                    AccountCode = dr.Cells[5].Text,
                    AccountID = int.Parse(dr.Cells[4].Text),
                    AccountName = dr.Cells[8].Text,
                    BalanceType = "CR",
                    TranAmount = decimal.Parse(dr.Cells[9].Text)
                };
                TempAcList.Add(theCurrTran);
            }
            return TempAcList;
        }
        public List<StudentPreviousQual> PreviousQualList()
        {
            List<StudentPreviousQual> PreQualList = new List<StudentPreviousQual>();
            foreach (GridViewRow dr in gview_Course.Rows)
            {
                StudentPreviousQual ThePreQual = new StudentPreviousQual();
                ThePreQual.QualID = int.Parse(dr.Cells[1].Text);
                ThePreQual.PassingYear = dr.Cells[2].Text;
                ThePreQual.Board = dr.Cells[3].Text;
                ThePreQual.Division = dr.Cells[4].Text;
                ThePreQual.Percentage = dr.Cells[5].Text;
                PreQualList.Add(ThePreQual);
            }
            return PreQualList;
        }
        private void SetValidationMessages()
        {

            regularExpressionValidator_Name.ValidationExpression = MicroConstants.REGEX_NAME;
            regularExpressionValidator_DateOfBirth.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_Present_Pincode.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_Permanent_Pincode.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;

            regularExpressionValidator_Name.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_VALID_NAME");
            regularExpressionValidator_DateOfBirth.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_VALID_DATE");
            regularExpressionValidator_Present_Pincode.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_NUMBER_FIELD");
            regularExpressionValidator_Permanent_Pincode.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_NUMBER_FIELD");


            requiredFieldValidator_Name.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Name");
            requiredFieldValidator_AdmissionAmount.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Admission Amount");

            if (requiredFieldValidator_AdmissionTo.InitialValue.Contains(MicroConstants.DROPDOWNLIST_DEFAULT_ADMISSION))
                requiredFieldValidator_AdmissionTo.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Choose Your Class");

            requiredFieldValidator_ReceiptNo.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Receipt No");

            requiredFieldValidator_DateOfBirth.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_DATE_FIELD");
            //requiredFieldValidator_Age.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Age");
            requiredFieldValidator_Present_TownOrCity.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Present Address");
            requiredFieldValidator_Permanent_TownOrCity.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Permanent Address");

            requiredFieldValidator_FatherName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Father Name");
            regularExpressionValidator_FatherName.ValidationExpression = MicroConstants.REGEX_NAME;
            regularExpressionValidator_FatherName.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_VALID_NAME", "FatherName");

            requiredFieldValidator_MotherName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Mother Name");
            regularExpressionValidator_MotherName.ValidationExpression = MicroConstants.REGEX_NAME;
            regularExpressionValidator_MotherName.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_VALID_NAME", "Mother Name");

            //requiredFieldValidator_Qualification.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            //requiredFieldValidator_Qualification.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Qualification");

            requiredFieldValidator_CourseID.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_CourseID.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Choose Your Course");

            requiredFieldValidator_StreamList.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_StreamList.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Stream");

            //rangeValidator_Age.MinimumValue = "1";
            //rangeValidator_Age.MaximumValue = "250";
            //rangeValidator_Age.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_VALID_AGE");

            requiredFieldValidator_DateOfAdmission.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "DateOfAdmission");
            requiredFieldValidator_DateOfLeaving.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "DateOfLeaving");

            regularExpressionValidator_DateOFAdmission.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_PhoneNumber.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_MobileNo.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_EmailId.ValidationExpression = MicroConstants.REGEX_EMAILID;
            regularExpressionValidator_PassingYear.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;

            regularExpressionValidator_DateOFAdmission.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");
            regularExpressionValidator_PhoneNumber.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_ONLY");
            regularExpressionValidator_MobileNo.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_ONLY");
            regularExpressionValidator_EmailId.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_EMAILID");
            regularExpressionValidator_PassingYear.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_ONLY");
            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_Name.CssClass = theClassName;
            requiredFieldValidator_DateOfBirth.CssClass = theClassName;
            //requiredFieldValidator_Age.CssClass = theClassName;
            requiredFieldValidator_Present_TownOrCity.CssClass = theClassName;
            requiredFieldValidator_Permanent_TownOrCity.CssClass = theClassName;

            regularExpressionValidator_Name.CssClass = theClassName;
            regularExpressionValidator_DateOfBirth.CssClass = theClassName;
            regularExpressionValidator_Present_Pincode.CssClass = theClassName;
            regularExpressionValidator_Permanent_Pincode.CssClass = theClassName;

            //requiredField_fathername.CssClass = theClassName;
            //RequiredField_MotherName.CssClass = theClassName;

            requiredFieldValidator_DateOfAdmission.CssClass = theClassName;
            requiredFieldValidator_DateOfLeaving.CssClass = theClassName;


            //rangeValidator_Age.CssClass = theClassName;
        }
        #endregion

        private string GetSubjectIDs(CheckBoxList theCheckBoxList)
        {
            string c = string.Empty;

            for (int i = 0; i < theCheckBoxList.Items.Count; i++)
            {
                if (theCheckBoxList.Items[i].Selected)
                {
                    c = c + theCheckBoxList.Items[i].Text;
                }
            }
            return c;
        }

        void ClearSubjects()
        {
            chk_ChooseCompulsory.ClearSelection();
            chk_chooseElective.ClearSelection();
            chk_chooseHons.ClearSelection();
            chk_choosemajor.ClearSelection();
            chk_chooseminor.ClearSelection();
            chk_choosepass.ClearSelection();
        }

        void ForEachLoop(CheckBoxList chk, List<StudentSubjectTaken> SubList)
        {
            foreach (StudentSubjectTaken Sli in SubList)
            {
                foreach (ListItem li in chk.Items)
                {
                    if (li.Value == Sli.SubjectID.ToString())
                    {
                        li.Selected = true;
                    }
                }
            }
        }

        protected void DropDown_StreamList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void bindSubjects(Student theStudent)
        {
            CheckChooseSubjects();
            int StreamID = int.Parse(DropDown_StreamList.SelectedValue);
            int CourseID = int.Parse(drpdwn_CourseId.SelectedValue);
            chk_ChooseCompulsory.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "COMPULSORY", String.Empty, false);
            chk_ChooseCompulsory.DataTextField = "SubjectName";//StreamManagement.GetInstance.DisplayMember;
            chk_ChooseCompulsory.DataValueField = "SubjectID";//StreamManagement.GetInstance.ValueMember;
            chk_ChooseCompulsory.DataBind();
            foreach (ListItem list in chk_ChooseCompulsory.Items)
            {
                list.Selected = true;
            }

            if (drpdwn_CourseId.SelectedValue.Equals("2"))
            {
                lbl_MaxSub_elective.Text = "(Max-4)";
                chk_chooseElective.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "ELECTIVE", String.Empty, false);
                chk_chooseElective.DataTextField = "SubjectName";//StreamManagement.GetInstance.DisplayMember;
                chk_chooseElective.DataValueField = "SubjectID";//StreamManagement.GetInstance.ValueMember;
                chk_chooseElective.DataBind();
                ForEachLoop(chk_chooseElective, BindelEctiveSubjects(theStudent.StudentID));
            }
            else if (drpdwn_CourseId.SelectedValue.Equals("3") && (DropDown_StreamList.SelectedValue.Equals("1") || DropDown_StreamList.SelectedValue.Equals("2")))
            {
                if (DropDown_StreamList.SelectedValue.Equals("1"))
                {
                    lblmaxminor.Text = "(Max-1)";
                    lblpassmax.Text = "(Max-1)";
                    chk_chooseminor.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "MINOR", String.Empty, false);
                    chk_chooseminor.DataTextField = "SubjectName";//StreamManagement.GetInstance.DisplayMember;
                    chk_chooseminor.DataValueField = "SubjectID";//StreamManagement.GetInstance.ValueMember;
                    chk_chooseminor.DataBind();
                    ForEachLoop(chk_chooseminor, BindMinorSubjects(theStudent.StudentID));

                    lblmaxmajor.Text = "(Max-1)";
                    chk_choosemajor.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "MAJOR", String.Empty, false);
                    chk_choosemajor.DataTextField = "SubjectName";//StreamManagement.GetInstance.DisplayMember;
                    chk_choosemajor.DataValueField = "SubjectID";//StreamManagement.GetInstance.ValueMember;
                    chk_choosemajor.DataBind();
                    ForEachLoop(chk_choosemajor, BindMajorSubjects(theStudent.StudentID));
                }
                else
                {
                    lbl_MaxSub_elective.Text = "(Max-2)";
                    lblpassmax.Text = "(Max-2)";
                    chk_chooseElective.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "ELECTIVE", String.Empty, false);
                    chk_chooseElective.DataTextField = "SubjectName";//StreamManagement.GetInstance.DisplayMember;
                    chk_chooseElective.DataValueField = "SubjectID";//StreamManagement.GetInstance.ValueMember;
                    chk_chooseElective.DataBind();
                    ForEachLoop(chk_chooseElective, BindelEctiveSubjects(theStudent.StudentID));
                }
                lblhonsmax.Text = "(Max-1)";
                chk_chooseHons.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "HONS", String.Empty, false);
                chk_chooseHons.DataTextField = "SubjectName";//StreamManagement.GetInstance.DisplayMember;
                chk_chooseHons.DataValueField = "SubjectID";//StreamManagement.GetInstance.ValueMember;
                chk_chooseHons.DataBind();
                ForEachLoop(chk_chooseHons, BindHonsSubjects(theStudent.StudentID));

                chk_choosepass.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "PASS", String.Empty, false);
                chk_choosepass.DataTextField = "SubjectName";//StreamManagement.GetInstance.DisplayMember;
                chk_choosepass.DataValueField = "SubjectID";//StreamManagement.GetInstance.ValueMember;
                chk_choosepass.DataBind();
                ForEachLoop(chk_choosepass, BindPassSubjects(theStudent.StudentID));
            }
        }

        //void CheckSubjects()
        //{
        //    chklist_CompulsorySubjectLists.Enabled = false;
        //    chklist_ElectiveSubjectsBind.Enabled = false;
        //    chklist_HonsSubjects.Enabled = false;
        //    chklist_MajorElectiveSubjects.Enabled = false;
        //    chklist_MinorSubject.Enabled = false;
        //    chklistPassSubjects.Enabled = false;     
        //    if (drpdwn_CourseId.SelectedValue == "2")
        //    {
        //        MultiView_Subjects.SetActiveView(View_Elective);
        //        PanelHonsPass.Visible = false;
        //    }
        //    else if (drpdwn_CourseId.SelectedValue == "3" && DropDown_StreamList.SelectedValue == "1")
        //    {
        //        MultiView_Subjects.SetActiveView(View_MajorMinorElective);
        //        PanelHonsPass.Visible = true;
        //    }
        //    else if (drpdwn_CourseId.SelectedValue == "3" && DropDown_StreamList.SelectedValue == "2")
        //    {
        //        MultiView_Subjects.SetActiveView(View_Elective);
        //        PanelHonsPass.Visible = true;
        //    }
        //}
        void CheckChooseSubjects()
        {

            if (drpdwn_CourseId.SelectedValue == "2")
            {
                MultiView_Choosesub.SetActiveView(View_ChooseElactive);
                pnl_ChooseHonsPass.Visible = false;
            }
            else if (drpdwn_CourseId.SelectedValue == "3" && DropDown_StreamList.SelectedValue == "1")
            {
                MultiView_Choosesub.SetActiveView(View_Choosemajorminor);
                pnl_ChooseHonsPass.Visible = true;
            }
            else if (drpdwn_CourseId.SelectedValue == "3" && DropDown_StreamList.SelectedValue == "2")
            {
                MultiView_Choosesub.SetActiveView(View_ChooseElactive);
                pnl_ChooseHonsPass.Visible = true;
            }
        }

        protected void drpdwn_CourseId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpdwn_CourseId.SelectedIndex == 0)
            {
                DropDown_StreamList.Enabled = false;
            }
            else
            {
                DropDown_StreamList.SelectedIndex = 0;
                DropDown_StreamList.Enabled = true;
                ResetSubjectAndPrevQual();
                //PanelHonsPass.Visible = false;
                //MultiView_Subjects.ActiveViewIndex = -1;
            }
        }

        private void ResetQualificationValues()
        {
            ddl_Qualification.SelectedIndex = 0;
            txt_PassingYear.Text = string.Empty;
            txt_Percentage.Text = string.Empty;
            txt_Board.Text = string.Empty;
            txt_Division.Text = string.Empty;
        }

        void createrow(DataTable dt, string s1, string s2, string s3, string s4, string s5)
        {
            DataTable dt1 = (DataTable)ViewState["Data"];
            DataRow dr1 = dt1.NewRow();
            dr1["CourseName"] = s1;
            dr1["PassingYear"] = s2;
            dr1["Board"] = s3;
            dr1["Division"] = s4;
            dr1["Percentage"] = s5;
            dt1.Rows.Add(dr1);

        }

        protected void btn_AddQual_Click(object sender, EventArgs e)
        {
            if (ViewState["Data"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CourseName");
                dt.Columns.Add("PassingYear");
                dt.Columns.Add("Board");
                dt.Columns.Add("Division");
                dt.Columns.Add("Percentage");
                ViewState["Data"] = dt;
                createrow(dt, ddl_Qualification.SelectedValue, txt_PassingYear.Text, txt_Board.Text, txt_Division.Text, txt_Percentage.Text);
                gview_Course.DataSource = (DataTable)ViewState["Data"];
                gview_Course.DataBind();
                ResetQualificationValues();
            }
            else
            {
                DataTable dt1 = new DataTable();
                dt1 = (DataTable)ViewState["Data"];
                createrow(dt1, ddl_Qualification.SelectedValue, txt_PassingYear.Text, txt_Board.Text, txt_Division.Text, txt_Percentage.Text);
                gview_Course.DataSource = (DataTable)ViewState["Data"];
                gview_Course.DataBind();
                ResetQualificationValues();
            }
        }

        protected void gridview_Students_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview_Students.PageIndex = e.NewPageIndex;
            gridview_Students.DataSource = StudentManagement.GetInstance.GetStudentList(false); // dont refesh, get it from cache
            gridview_Students.DataBind();
        }

        protected void btn_Previous_Click(object sender, EventArgs e)
        {
            Student_Multi.SetActiveView(InputControls);
            chklist_Details.SelectedValue = "1";
        }

        protected void btn_Next_Click(object sender, EventArgs e)
        {
            Student_Multi.SetActiveView(View_SubjectEdition);
            chklist_Details.SelectedValue = "3";
        }

        protected void btn_MoveNext_Click(object sender, EventArgs e)
        {
            if (StudentManagement.GetInstance.GetStudent_SitStatus_ByQualAndStream(int.Parse(drpdwn_CourseId.SelectedValue), int.Parse(DropDown_StreamList.SelectedValue), int.Parse(ddl_AcademicYear.SelectedValue), lbl_RegNo.Text) == true)
            {
                Student_Multi.SetActiveView(View_Admision);
                chklist_Details.SelectedValue = "2";
                lbl_TheMessage.Text = "";
                chklist_Details.Items[1].Enabled = true;
                chklist_Details.Items[2].Enabled = true;
            }
            else
            {
                dialog_Message.Show();
                lbl_TheMessage.Text = ReadXML.GetFailureMessage("SEAT_NOT_AVAILBLE");
                chklist_Details.Items[1].Enabled = false;
                chklist_Details.Items[2].Enabled = false;
            }
        }

        protected void btn_MoveNext1_Click(object sender, EventArgs e)
        {
            Student_Multi.SetActiveView(View_Admision);
            chklist_Details.SelectedValue = "2";
        }

        protected void btn_BackAdmission_Click(object sender, EventArgs e)
        {
            Student_Multi.SetActiveView(View_Admision);
            chklist_Details.SelectedValue = "2";
        }

        protected void btnBackAdmission1_Click(object sender, EventArgs e)
        {
            Student_Multi.SetActiveView(View_Admision);
            chklist_Details.SelectedValue = "2";
        }

        protected void btnCheckAll_Click(object sender, EventArgs e)
        {
            decimal val = 0M;
            foreach (GridViewRow gvr in gridview_DefaultFee.Rows)
            {
                ((CheckBox)gvr.FindControl("chk_DefaultFe")).Checked = true;

                if (((CheckBox)gvr.FindControl("chk_DefaultFe")).Checked == true)
                {

                    decimal uPrimaryid = decimal.Parse(gvr.Cells[8].Text);
                    val = val + uPrimaryid;
                }
                //else
                //{
                //    decimal uPrimaryid = decimal.Parse(gvr.Cells[8].Text);
                //    val = val - uPrimaryid;
                //}
            }
            txt_AdmissionAmount.Text = val.ToString();
            txt_AdmissionAmount.Enabled = false;
        }

        protected void chk_DefaultFe_CheckedChanged(object sender, EventArgs e)
        {
            decimal val = 0M;
            foreach (GridViewRow gvr in gridview_DefaultFee.Rows)
            {
                if (((CheckBox)gvr.FindControl("chk_DefaultFe")).Checked == true)
                {

                    decimal uPrimaryid = decimal.Parse(gvr.Cells[8].Text);
                    val = val + uPrimaryid;
                }
                //else
                //{
                //    decimal uPrimaryid = decimal.Parse(gvr.Cells[8].Text);
                //    val = val - uPrimaryid;
                //}
            }
            txt_AdmissionAmount.Text = val.ToString();
            txt_AdmissionAmount.Enabled = false;
        }




    }

}