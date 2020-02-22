
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Objects.ICAS.STUDENT;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using System.Data;
using Micro.Objects.Administration;
using Micro.Framework.ReadXML;
using Micro.Objects.FinancialAccounts;
using Micro.BusinessLayer.FinancialAccounts;
using System.Configuration;
using System.Reflection;
using System.Text;
using Micro.WebApplication.App_UserControls;


namespace Micro.WebApplication
{
    public partial class Students : System.Web.UI.Page
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


        private static int GetDropDownSelectedIndex(DropDownList ddl, int Value)
        {
            int ReturnValue = 0;

            if (!string.IsNullOrEmpty(Value.ToString()))
            {
                for (int index = 0; ddl.Items.Count > index; index++)
                {
                    if (ddl.Items[index].Value == Value.ToString())
                    {
                        ReturnValue = index;
                        break;
                    }
                }
            }

            return ReturnValue;
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            ((TreeView)Master.FindControl("TreeView1")).Visible = false;
            ((UC_UserLoggedOn)Master.FindControl("ctrl_LoggedOnUser")).Visible = false;
            if (Request.QueryString["Page"] == null)
            {
                if (!IsPostBack && !IsCallback)
                {
                    BindAccountingYear(string.Empty);

                    drpdwn_Salutation.Focus();
                    ResetSubjectAndPrevQual();
                    check_Address.Checked = false;
                    BindDropdown_PresentDistrict();
                    BindDropdown_PermanetDistrict();
                    BindDropdown_Salutation();
                    BindDropdown_Quals();
                    BindDropdown_Streams();
                    BindDropdown_Gender();
                    SetValidationMessages();
                    //BindStudentProfile();
                    drpdwn_PresentDistrictId.SelectedIndex = GetDropDownSelectedIndex(drpdwn_PresentDistrictId, 366);
                    drpdwn_PermanentDistrictId.SelectedIndex = GetDropDownSelectedIndex(drpdwn_PresentDistrictId, 366);
           
                    CheckForm();
                    //lit_PageTitle.Text = string.Format("{0} College Student's Profile Registration Form for the year : {1}", ConfigurationManager.AppSettings["DefaultCompanyAlias"], ddl_AcademicYear.SelectedItem);
                    //if (!(Request.QueryString["Type"] == null))
                    //{
                    //    if ((Request.QueryString["Type"].ToString().ToLower()) == "alumni")
                    //    {
                    //        //Student_Multi.SetActiveView(InputControls);
                    //        lblAdmissionYear.Text = "The Year of Admission in the college:";
                    //        Student_Multi.SetActiveView(InputControls);
                    //        ddl_AcademicYear.Focus();

                    //    }
                    //}
                    //else
                    //{
                    //    lblAdmissionYear.Text = "Admission for the session :";
                    //    Student_Multi.SetActiveView(InputControls);
                    //    txt_StudentName.Focus();
                    //}
                }
            }
            else
            {

                if (Request.QueryString["Type"] != null)
                {

                }
                if (Request.QueryString["Page"].ToString().Equals("View"))
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        //btn_View_Click(null, null);
                        BindDetailViewStudent(int.Parse(Request.QueryString["ID"].ToString()));
                        Student_Multi.SetActiveView(View_detail_Student);

                    }
                    else
                    {
                        btn_View_Click(null, null);
                    }
                }
            }
        }

        private void CheckForm()
        {
            if (Connection.LoggedOnUser != null)
            {
                if (Connection.LoggedOnUser.UserType == "Student")
                {
                    Student_Multi.SetActiveView(InputControls);
                    //btn_View.Visible = false;
                }
                else
                {
                    Student_Multi.SetActiveView(View_Grid);
                }
            }
            else
            {
                Student_Multi.SetActiveView(InputControls);
                //btn_View.Visible = false;
                Button2.Visible = false;
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

            //objQuals = (from xyzl in QualManagement.GetInstance.GetQualsList()
            //            where xyzl.ClassType.Contains("")
            //            select xyzl).ToList();
            //ddl_Qualification.Items.Clear();
            //ddl_Qualification.DataSource = objQuals;
            //ddl_Qualification.DataTextField = QualManagement.GetInstance.DisplayMember;
            //ddl_Qualification.DataValueField = QualManagement.GetInstance.ValueMember;
            //ddl_Qualification.DataBind();
            //ddl_Qualification.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            Student_Multi.SetActiveView(InputControls);
            btn_Submit.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Submit1.Text = MicroEnums.DataOperation.Save.GetStringValue();
            //btn_Submit2.Text = MicroEnums.DataOperation.Save.GetStringValue();
            ResetAll();
        }
        public List<StudentSubjectTaken> StudeSubjects()
        {
            List<StudentSubjectTaken> ObjSubjects = new List<StudentSubjectTaken>();
            foreach (ListItem liComp in chklist_CompulsorySubjectLists.Items)
            {
                if (liComp.Selected)
                {
                    StudentSubjectTaken SingleObjComp = new StudentSubjectTaken();
                    SingleObjComp.SubjectID = int.Parse(liComp.Value);
                    SingleObjComp.SubjectType = "Compulsory";
                    ObjSubjects.Add(SingleObjComp);
                }
            }
            foreach (ListItem liminor in chklist_MinorSubject.Items)
            {
                if (liminor.Selected)
                {
                    StudentSubjectTaken SingleObjMinor = new StudentSubjectTaken();
                    SingleObjMinor.SubjectID = int.Parse(liminor.Value);
                    SingleObjMinor.SubjectType = "Minor";
                    ObjSubjects.Add(SingleObjMinor);
                }
            }
            foreach (ListItem limajor in chklist_MajorElectiveSubjects.Items)
            {
                if (limajor.Selected)
                {
                    StudentSubjectTaken SingleObjMajor = new StudentSubjectTaken();
                    SingleObjMajor.SubjectID = int.Parse(limajor.Value);
                    SingleObjMajor.SubjectType = "Major";
                    ObjSubjects.Add(SingleObjMajor);
                }
            }
            foreach (ListItem lielective in chklist_ElectiveSubjectsBind.Items)
            {
                if (lielective.Selected)
                {
                    StudentSubjectTaken SingleObjelective = new StudentSubjectTaken();
                    SingleObjelective.SubjectID = int.Parse(lielective.Value);
                    SingleObjelective.SubjectType = "Elective";
                    ObjSubjects.Add(SingleObjelective);
                }
            }
            foreach (ListItem lihons in chklist_HonsSubjects.Items)
            {
                if (lihons.Selected)
                {
                    StudentSubjectTaken SingleObjhons = new StudentSubjectTaken();
                    SingleObjhons.SubjectID = int.Parse(lihons.Value);
                    SingleObjhons.SubjectType = "Hons";
                    ObjSubjects.Add(SingleObjhons);
                }
            }
            foreach (ListItem lipass in chklistPassSubjects.Items)
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
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            List<StudentSubjectTaken> StudentSubjects = new List<StudentSubjectTaken>();
            List<StudentPreviousQual> StudentPreQualList = new List<StudentPreviousQual>();
            if (((Button)sender).CommandName.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertStudent(StudentSubjects, StudentPreQualList);
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    dialog_Message.Show();
                    lbl_TheMessage.Text = "Registration done Successfully"; // ReadXML.GetSuccessMessage("OK_STUDENT_ADDED");
                }
                else
                {
                    dialog_Message.Show();
                    lbl_TheMessage.Text = "Failed to register the supplied information"; //ReadXML.GetFailureMessage("KO_STUDENT_ADDED");
                }
            }
            else
            {
                ProcReturnValue = UpdateStudent();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    dialog_Message.Show();
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_STUDENT_UPDATED");
                }
                else
                {
                    dialog_Message.Show();
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_STUDENT_UPDATED");
                }
            }
            ResetAll();
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            ResetAll();
            //GetSubjectIDs(chklist_MinorSubject);
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
        void BindStudentProfile()
        {
            try
            {
                PageVariables.ThisStudent = (from xyz in StudentManagement.GetInstance.GetStudentList()
                                             where xyz.StudentID == Micro.Commons.Connection.LoggedOnUser.UserReferenceID && Micro.Commons.Connection.LoggedOnUser.UserType.Equals("Student")
                                             select xyz).Single();
                PopulateFormField(PageVariables.ThisStudent);
                Student_Multi.SetActiveView(InputControls);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                {
                    Student_Multi.SetActiveView(InputControls);
                }
            }

        }
        protected void gridview_Students_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
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
                    btn_Submit.Text = MicroEnums.DataOperation.Update.GetStringValue();
                    btn_Submit1.Text = MicroEnums.DataOperation.Update.GetStringValue();
                    //btn_Submit2.Text = MicroEnums.DataOperation.Update.GetStringValue();
                    //btn_Submit2.Text = MicroEnums.DataOperation.Update.GetStringValue();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    ProcReturnValue = DeleteRecord();
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_Student_DELETED");
                        BindGridView();
                    }
                    else
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_Student_DELETED");
                    }
                    dialog_Message.Show();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
                {
                    PopulateFormField(PageVariables.ThisStudent);
                    Student_Multi.SetActiveView(InputControls);
                    btn_Submit.Visible = false;
                    btn_Submit1.Visible = false;
                    pnlStPreQual.Visible = false;
                    //btn_Submit2.Visible = false;
                    btn_AddNew.Visible = true;
                    
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
        //void GetDistricts(int DistrictID)
        //protected void txt_DateOfBirth_TextChanged(object sender, EventArgs e)
        //{
        //    //txt_Age.Text = string.Empty;

        //    //if (IsValidDate(txt_DateOfBirth.Text))
        //    //{
        //    //    txt_DateOfBirth.Text = DateTime.Parse(txt_DateOfBirth.Text).ToString(MicroConstants.DateFormat);
        //    //    txt_Age.Text = CalculateAge(DateTime.Parse(txt_DateOfBirth.Text)).ToString();
        //    //}
        //}

        //protected void txt_Age_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txt_DateOfBirth.Text = CalculateDateOfBirth(txt_Age.Text).ToString(MicroConstants.DateFormat);
        //    }
        //    catch
        //    {
        //    }
        //}

        protected void gridview_Students_RowDataBound(object sender, GridViewRowEventArgs e)
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
        public void ResetSubjectAndPrevQual()
        {
            chklist_CompulsorySubjectLists.Items.Clear();
            chklist_CompulsorySubjectLists.Items.Insert(0, "Choose Course And Stream");

            chklist_ElectiveSubjectsBind.Items.Clear();
            //chklist_ElectiveSubjectsBind.Items.Insert(0, "Choose Class And Stream");

            chklist_MinorSubject.Items.Clear();
            //chklist_MinorSubject.Items.Insert(0, "Choose Class And Stream");


            chklist_MajorElectiveSubjects.Items.Clear();
            //chklist_MajorElectiveSubjects.Items.Insert(0, "Choose Class And Stream");

            chklist_HonsSubjects.Items.Clear();
            //chklist_HonsSubjects.Items.Insert(0, "Choose Class And Stream");

            chklistPassSubjects.Items.Clear();
            //chklistPassSubjects.Items.Insert(0, "Choose Class And Stream");

            gview_Course.DataSource = null;
            gview_Course.DataBind();
            gview_BindCourse.DataSource = null;
            gview_BindCourse.DataBind();
        }
        public void ResetAll()
        {
            //txt_MRINo.Text = string.Empty;
            drpdwn_PresentDistrictId.ClearSelection();
            pnlStPreQual.Visible = true;
            drpdwn_PermanentDistrictId.ClearSelection();
            check_Address.Checked = false;
            txt_PermanentCity.Text = string.Empty;
            txt_PermanentStateName.Text = string.Empty;
            txt_PermanentCountry.Text = string.Empty;
            ResetSubjectAndPrevQual();
            txt_PresentCity.Text = string.Empty;
            txt_PresentCountry.Text = string.Empty;
            txt_PresentStateName.Text = string.Empty;
            txt_PresentLandmark.Text = string.Empty;
            //txt_ReceiptNo.Text = string.Empty;
            //txt_TCNo.Text = string.Empty;
            //txt_RollNo.Text = string.Empty;
            drpdwn_CourseId.ClearSelection();
            drpdwn_Salutation.ClearSelection();
            txt_StudentName.Text = string.Empty;
            txt_FatherName.Text = string.Empty;
            txt_MotherName.Text = string.Empty;
            drpdwn_Gender.ClearSelection();
            drpdwn_Caste.ClearSelection();
            radio_PHStatus.ClearSelection();
            chklist_MinorSubject.ClearSelection();
            chklist_ElectiveSubjectsBind.ClearSelection();
            chklist_CompulsorySubjectLists.ClearSelection();
            BindDropdown_Quals();
            BindDropdown_Streams();
            //txt_Status.Text = string.Empty;
            //radio_TotalFeesPaid.ClearSelection();
            txt_DateOfBirth.Text = string.Empty;
            //txt_DateOfAdmission.Text = string.Empty;
            //txt_DateOfLeaving.Text = string.Empty;
            //txt_Age.Text = string.Empty;
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
			btn_Submit1.Text = "Register New Student"; MicroEnums.DataOperation.Save.GetStringValue();
            //btn_Submit2.Text = MicroEnums.DataOperation.Save.GetStringValue();
        }


        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        private void BindDetailViewStudent(int id)
        {
            Student theStudent = new Student();
            if (PageVariables.StudentrList == null)
            {
                PageVariables.StudentrList = StudentManagement.GetInstance.GetStudentList();

            }
            //var student = (from s in PageVariables.StudentrList
            //               where s.StudentID.Equals(id)
            //               select s);

            //theStudent = student;
            theStudent = StudentManagement.GetInstance.GetStudentList().Find(a => a.StudentID == id);
            if (theStudent == null)
            {
                lit_CurrentStudentInfo.Text = string.Format("NO INFORMATION AVAILABLE FOR THE STUDENT WHOS ID IS : <span class='Name'>{0} </span>", id);
                return;
            }
            else
            {
                lit_CurrentStudentInfo.Text = string.Format("DETAIL INFORMATION OF THE STUDENT : <span class='Name'>{0} {1}</span>", theStudent.Salutation, theStudent.StudentName);
            }

            var properties = GetProperties(theStudent);


            PropertyInfo[] propertiesStudent = theStudent.GetType().GetProperties();

            StringBuilder sbStudentDetails = new StringBuilder("<ul id='StudentPersonalView' class='StudentDetailView'>");
            //Display Student Details
            int ctr = 0;
            foreach (PropertyInfo pi in propertiesStudent)
            {
                ctr++;
                string theVar = string.Concat(pi.GetValue(theStudent, null), "&nbsp;");
                sbStudentDetails.Append(string.Format("<li class='theName'>{2}. {0}</li><li class='theValue'>{1}</li>", pi.Name, theVar, ctr));
                if (ctr == 43) break;
            }
            sbStudentDetails.Append("</ul>");
            //studentDeails.InnerText = sbStudentDetails.ToString();
            lit_StudentDetail.Text = sbStudentDetails.ToString();

            ////Display Subjects taken
            //sbStudentDetails.Append("<ul id='StudentSubjects' class='StudentDetailView'>");
            //sbStudentDetails.Append(string.Format("<li class='theValue'>{0}</li><li class='theValue'>{1}</li>", "name", "value"));
            //sbStudentDetails.Append("<ul id='StudentSubjects' class='StudentDetailView'>");

            ////Display Marks Obtained
            //sbStudentDetails.Append("<ul id='StudentSubjects' class='StudentDetailView'>");
            //sbStudentDetails.Append(string.Format("<li class='theValue'>{0}</li><li class='theValue'>{1}</li>", "name", "value"));
            //sbStudentDetails.Append("<ul id='StudentSubjects' class='StudentDetailView'>");

            //// Display Attendance
            //sbStudentDetails.Append("<ul id='StudentSubjects' class='StudentDetailView'>");
            //sbStudentDetails.Append(string.Format("<li class='theValue'>{0}</li><li class='theValue'>{1}</li>", "name", "value"));
            //sbStudentDetails.Append("<ul id='StudentSubjects' class='StudentDetailView'>");
            //// Display Fees paid information.
            ////AccountTransactionManagement.GetInstance.GetAccountTransactionList

            ////Display


            //JObject json = JObject.FromObject(some_object);
            //foreach (JProperty property in json.Properties())
            //    Console.WriteLine(property.Name + " - " + property.Value);



            //detailView_Student.DataSource = PageVariables.ThisStudent;
            //detailView_Student.DataBind();

        }
        public void BindGridView()
        {
            //PageVariables.StudentrList = ;
            gridview_Students.DataSource = StudentManagement.GetInstance.GetStudentList();
            gridview_Students.DataBind();
        }

        public void BindAccountingYear(string SearctText)
        {
            List<AccountingYear> AccountingYearlist = new List<AccountingYear>();
            //List<AccountingYear> AccountingYearlistObject = new List<AccountingYear>();
            AccountingYearlist = AccountingYearManagement.GetInstance.GetAccountingYearList(SearctText);

            //AccountingYearlistObject = new AccountingYearlistObject;



            ddl_AcademicYear.DataSource = AccountingYearlist;
            ddl_AcademicYear.DataValueField = "AccountingYearID";
            ddl_AcademicYear.DataTextField = "AccountingYearDescription";
            ddl_AcademicYear.DataBind();

            try
            {
                if (Request.QueryString["Type"] != null)
                {
                    if ((Request.QueryString["Type"].ToString().ToLower()) == "alumni")
                    {

                        lit_PageTitle.Text = "Alumni Registration: ";


                        ddl_AcademicYear.Items.RemoveAt(0); // remove the current session because of alumni can only be an ex student
                        ddl_AcademicYear.Enabled = true;


                    }
                    else
                    {
                        //// student : display only the current year
                        //for (int x = 1; x < ddl_AcademicYear.Items.Count; x++)
                        //{
                        //    ddl_AcademicYear.Items.RemoveAt(x);
                        //}
                        ddl_AcademicYear.Enabled = false;
                    }
                }
                else
                {
                    // student : display only the current year
                    //for (int x = 1; x < ddl_AcademicYear.Items.Count; x++)
                    //{
                    //    ddl_AcademicYear.Items.RemoveAt(x);
                    //}
                    ddl_AcademicYear.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Exception exp = new  Exception(string.Format("Because the Accounting / Academic Years in database has not udated yet or : {0}", ex.Message.ToString()));
                Log.Error(exp);
                Server.Transfer("~/App_Error/Error500.aspx");
                return;
            }
        }

        private int InsertStudent(List<StudentSubjectTaken> AllSubjects, List<StudentPreviousQual> StudentPreQualList)
        {
            int Returnvalue = 0;
            AllSubjects = StudeSubjects();
            StudentPreQualList = PreviousQualList();
            Student TheStudent = new Student();
            //TheStudent.MRINO = txt_MRINo.Text;
            //TheStudent.ReceiptNo = txt_ReceiptNo.Text;
            TheStudent.ReceiptNo = string.Empty;
            //TheStudent.TCNo = txt_TCNo.Text;
            //TheStudent.RollNo = txt_RollNo.Text;
            TheStudent.RollNo = "";
            TheStudent.QualID = int.Parse(drpdwn_CourseId.SelectedValue);
            TheStudent.StreamID = int.Parse(DropDown_StreamList.SelectedValue);
            TheStudent.ClassID = int.Parse(drpdwn_CourseId.SelectedValue);
            TheStudent.Salutation = drpdwn_Salutation.SelectedValue;
            TheStudent.StudentName = txt_StudentName.Text;
            TheStudent.FatherName = txt_FatherName.Text;
            TheStudent.MotherName = txt_MotherName.Text;
            TheStudent.Gender = drpdwn_Gender.SelectedValue;
            TheStudent.Caste = drpdwn_Caste.SelectedValue;
            TheStudent.PHStatus = radio_PHStatus.SelectedValue;
            //TheStudent.Status = txt_Status.Text;

            //TheStudent.TotalFeesPaid = radio_TotalFeesPaid.SelectedValue;
            TheStudent.TotalFeesPaid = string.Empty;

            TheStudent.DateOfBirth = txt_DateOfBirth.Text;

            //TheStudent.DateOfAdmission = txt_DateOfAdmission.Text;
            TheStudent.DateOfAdmission = "";

            //TheStudent.DateOfLeaving = txt_DateOfLeaving.Text;
            TheStudent.Age = 0; // int.Parse(txt_Age.Text);
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

        private int UpdateStudent()
        {
            int ProcReturnvalue = 0;
            //PageVariables.ThisStudent.MRINO = txt_MRINo.Text;            
            //PageVariables.ThisStudent.ReceiptNo = txt_ReceiptNo.Text;
            //PageVariables.ThisStudent.TCNo = txt_TCNo.Text;
            //PageVariables.ThisStudent.RollNo = txt_RollNo.Text;
            PageVariables.ThisStudent.ClassID = 0;
            PageVariables.ThisStudent.QualID = int.Parse(drpdwn_CourseId.SelectedValue);
            PageVariables.ThisStudent.StreamID = int.Parse(DropDown_StreamList.SelectedValue);
            PageVariables.ThisStudent.Salutation = drpdwn_Salutation.Text;
            PageVariables.ThisStudent.StudentName = txt_StudentName.Text;
            PageVariables.ThisStudent.MotherName = txt_MotherName.Text;
            PageVariables.ThisStudent.FatherName = txt_FatherName.Text;
            PageVariables.ThisStudent.Gender = drpdwn_Gender.Text;
            PageVariables.ThisStudent.Caste = drpdwn_Caste.Text;
            PageVariables.ThisStudent.PHStatus = radio_PHStatus.SelectedValue;
            //PageVariables.ThisStudent.Status = txt_Status.Text;
            //PageVariables.ThisStudent.TotalFeesPaid = radio_TotalFeesPaid.SelectedValue;
            PageVariables.ThisStudent.DateOfBirth = txt_DateOfBirth.Text;
            //PageVariables.ThisStudent.DateOfAdmission = txt_DateOfAdmission.Text;
            //PageVariables.ThisStudent.DateOfLeaving = txt_DateOfLeaving.Text;
            PageVariables.ThisStudent.Age = 0; // int.Parse(txt_Age.Text);
            PageVariables.ThisStudent.Address_Present_TownOrCity = txt_PresentCity.Text;
            PageVariables.ThisStudent.Address_Present_Landmark = txt_PresentLandmark.Text;
            PageVariables.ThisStudent.Address_Present_PinCode = txt_PresentPincode.Text;
            PageVariables.ThisStudent.Address_Present_DistrictID = drpdwn_PresentDistrictId.SelectedIndex;
            PageVariables.ThisStudent.Address_Permanent_TownOrCity = txt_PermanentCity.Text;
            PageVariables.ThisStudent.Address_Permanent_Landmark = txt_PermanentLandmark.Text;
            PageVariables.ThisStudent.Address_Permanent_PinCode = txt_PermanentPincode.Text;
            PageVariables.ThisStudent.Address_Permanent_DistrictID = drpdwn_PermanentDistrictId.SelectedIndex;
            PageVariables.ThisStudent.PhoneNumber = txt_PhoneNumber.Text;
            PageVariables.ThisStudent.SessionID = int.Parse(ddl_AcademicYear.SelectedValue);
            PageVariables.ThisStudent.Mobile = txt_Mobile.Text;
            PageVariables.ThisStudent.EMailID = txt_EmailId.Text;

            //ProcReturnvalue = StudentManagement.GetInstance.UpdateStudent(PageVariables.ThisStudent,List<Studentsub);

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
            //txt_MRINo.Text = theStudent.MRINO;
            //txt_ReceiptNo.Text = theStudent.ReceiptNo;
            //txt_TCNo.Text = theStudent.TCNo;
            //txt_RollNo.Text = theStudent.RollNo;    
            pnlStPreQual.Visible = false;
            //btn_AddNew.Visible = false;
            btn_Submit.Visible = false;
            btn_View.Visible = false;
            btn_Submit1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            btn_reset.Visible = false;

            drpdwn_CourseId.SelectedValue = theStudent.QualID.ToString();
            DropDown_StreamList.SelectedValue = theStudent.StreamID.ToString();
            drpdwn_Salutation.SelectedIndex = BasePage.GetDropDownSelectedIndex(drpdwn_Salutation, theStudent.Salutation);
            txt_StudentName.Text = theStudent.StudentName;
            txt_FatherName.Text = theStudent.FatherName;
            txt_MotherName.Text = theStudent.MotherName;
            drpdwn_Gender.SelectedIndex = BasePage.GetDropDownSelectedIndex(drpdwn_Gender, theStudent.Gender);
            drpdwn_Caste.SelectedIndex = BasePage.GetDropDownSelectedIndex(drpdwn_Caste, theStudent.Gender);
            radio_PHStatus.SelectedIndex = BasePage.GetRadioButtonSelectedIndex(radio_PHStatus, theStudent.PHStatus);
            //txt_Age.Text = theStudent.Age.ToString();
            //txt_Status.Text = theStudent.Status;
            //radio_TotalFeesPaid.SelectedIndex = BasePage.GetRadioButtonSelectedIndex(radio_TotalFeesPaid, theStudent.TotalFeesPaid);
            txt_DateOfBirth.Text = theStudent.DateOfBirth;
            //txt_DateOfAdmission.Text = theStudent.DateOfAdmission;
            //txt_DateOfLeaving.Text = theStudent.DateOfLeaving;
            txt_PresentCity.Text = theStudent.Address_Present_TownOrCity;
            txt_PresentLandmark.Text = theStudent.Address_Present_Landmark;
            txt_PresentPincode.Text = theStudent.Address_Present_PinCode;

            drpdwn_PresentDistrictId.SelectedIndex = GetDropDownSelectedIndex(drpdwn_PresentDistrictId, theStudent.Address_Present_DistrictID);
            //drpdwn_PresentDistrictId.Text= theStudent.Address_Permanent_StateName;
            txt_PresentStateName.Text = theStudent.Address_Present_StateName;
            txt_PresentCountry.Text = theStudent.Address_Present_CountryName;
            txt_PermanentLandmark.Text = theStudent.Address_Permanent_Landmark;
            txt_PermanentPincode.Text = theStudent.Address_Permanent_PinCode;
            drpdwn_PermanentDistrictId.SelectedIndex = GetDropDownSelectedIndex(drpdwn_PermanentDistrictId, theStudent.Address_Permanent_DistrictID);
            txt_PermanentStateName.Text = theStudent.Address_Permanent_StateName;
            txt_PermanentCountry.Text = theStudent.Address_Permanent_CountryName;
            txt_PermanentCity.Text = theStudent.Address_Permanent_TownOrCity;
            txt_PhoneNumber.Text = theStudent.PhoneNumber;
            txt_Mobile.Text = theStudent.Mobile;
            txt_EmailId.Text = theStudent.EMailID;

            ResetSubjectAndPrevQual();
            btn_AddQual.Enabled = false;
            BindSubjectsAndPreviousQualGrid(theStudent);

        }
        void BindSubjectsAndPreviousQualGrid(Student theStudent)
        {
            CheckSubjects();
            int StreamID = int.Parse(DropDown_StreamList.SelectedValue);
            int CourseID = int.Parse(drpdwn_CourseId.SelectedValue);

            chklist_CompulsorySubjectLists.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "COMPULSORY", String.Empty, false);
            chklist_CompulsorySubjectLists.DataTextField = "SubjectName";//StreamManagement.GetInstance.DisplayMember;
            chklist_CompulsorySubjectLists.DataValueField = "SubjectID";//StreamManagement.GetInstance.ValueMember;
            chklist_CompulsorySubjectLists.DataBind();
            if (drpdwn_CourseId.SelectedValue.Equals("2"))
            {
                lbl_MaxCount.Text = "(Max-4)";
                chklist_ElectiveSubjectsBind.DataSource = BindelEctiveSubjects(theStudent.StudentID);
                chklist_ElectiveSubjectsBind.DataMember = "SubjectID";
                chklist_ElectiveSubjectsBind.DataTextField = "SubjectName";
                chklist_ElectiveSubjectsBind.DataBind();

               
                
            }
            else if (drpdwn_CourseId.SelectedValue.Equals("3") && (DropDown_StreamList.SelectedValue.Equals("1") || DropDown_StreamList.SelectedValue.Equals("2")))
            {
                if (DropDown_StreamList.SelectedValue.Equals("1"))
                {
                    lbl_PassMaxCount.Text = "(Max-1)";
                    lbl_MinorMaxCount.Text = "(Max-1)";
                    chklist_MinorSubject.DataSource = BindMinorSubjects(theStudent.StudentID);
                    chklist_MinorSubject.DataMember = "SubjectID";
                    chklist_MinorSubject.DataTextField = "SubjectName";
                    chklist_MinorSubject.DataBind();

                    lbl_MajorMaxCount.Text = "(Max-1)";
                    chklist_MajorElectiveSubjects.DataSource = BindMajorSubjects(theStudent.StudentID);
                    chklist_MajorElectiveSubjects.DataTextField = "SubjectName";
                    chklist_MajorElectiveSubjects.DataValueField = "SubjectID";
                    chklist_MajorElectiveSubjects.DataBind();
                }
                else
                {
                    lbl_PassMaxCount.Text = "(Max-2)";
                    lbl_MaxCount.Text = "(Max-2)";
                    chklist_ElectiveSubjectsBind.DataSource = BindelEctiveSubjects(theStudent.StudentID);
                    chklist_ElectiveSubjectsBind.DataTextField = "SubjectName";
                    chklist_ElectiveSubjectsBind.DataValueField = "SubjectID";
                    chklist_ElectiveSubjectsBind.DataBind();
                }
                lbl_HonsMaxCount.Text = "(Max-1)";
                chklist_HonsSubjects.DataSource = BindHonsSubjects(theStudent.StudentID);
                chklist_HonsSubjects.DataTextField = "SubjectName";
                chklist_HonsSubjects.DataValueField = "SubjectID";
                chklist_HonsSubjects.DataBind();

                chklistPassSubjects.DataSource = BindPassSubjects(theStudent.StudentID);
                chklistPassSubjects.DataTextField = "SubjectName";
                chklistPassSubjects.DataValueField = "SubjectID";
                chklistPassSubjects.DataBind();
            }
            //Binding Previous Qualification Detail Of then Student 
            gview_Course.DataSource = null;
            gview_Course.DataBind();
            gview_BindCourse.DataSource = StudentPreQualManagement.GetInstance.GetPreQualsList(theStudent.StudentID);
            gview_BindCourse.DataBind();


            foreach (ListItem item in chklist_CompulsorySubjectLists.Items)
            {
                item.Selected = true;
            }
            
            foreach (ListItem item in chklist_ElectiveSubjectsBind.Items)
            {
                item.Selected = true;
            }
            foreach (ListItem item in chklist_MinorSubject.Items)
            {
                item.Selected = true;
            }
            foreach (ListItem item in chklist_MinorSubject.Items)
            {
                item.Selected = true;
            }
            foreach (ListItem item in chklist_MajorElectiveSubjects.Items)
            {
                item.Selected = true;
            }
            foreach (ListItem item in chklist_HonsSubjects.Items)
            {
                item.Selected = true;
            }
            foreach (ListItem item in chklistPassSubjects.Items)
            {
                item.Selected = true;
            }
            
        }
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
        public List<StudentPreviousQual> PreviousQualList()
        {
            List<StudentPreviousQual> PreQualList = new List<StudentPreviousQual>();
            foreach (GridViewRow dr in gview_Course.Rows)
            {
                if (dr.Cells[1].Text.Equals("--SELECT--"))
                {
                    continue;
                    }
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
            requiredFieldValidator_CourseID.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Choose Your Class");

            requiredFieldValidator_StreamList.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_StreamList.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Stream");

            //rangeValidator_Age.MinimumValue = "1";
            //rangeValidator_Age.MaximumValue = "250";
            //rangeValidator_Age.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_VALID_AGE");

            //requiredFieldValidator_DateOfAdmission.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "DateOfAdmission");
            //requiredFieldValidator_DateOfLeaving.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "DateOfLeaving");

            //regularExpressionValidator_DateOFAdmission.ValidationExpression = MicroConstants.REGEX_DATE;            
            regularExpressionValidator_PhoneNumber.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_MobileNo.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_EmailId.ValidationExpression = MicroConstants.REGEX_EMAILID;
            regularExpressionValidator_PassingYear.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;

            //regularExpressionValidator_DateOFAdmission.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");
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

            //requiredFieldValidator_DateOfAdmission.CssClass = theClassName;
            //requiredFieldValidator_DateOfLeaving.CssClass = theClassName;


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
            chklist_CompulsorySubjectLists.ClearSelection();
            chklist_ElectiveSubjectsBind.ClearSelection();
            chklist_HonsSubjects.ClearSelection();
            chklist_MajorElectiveSubjects.ClearSelection();
            chklist_MinorSubject.ClearSelection();
            chklistPassSubjects.ClearSelection();
        }
        protected void DropDown_StreamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSubjects();
            int StreamID = int.Parse(DropDown_StreamList.SelectedValue);
            int CourseID = int.Parse(drpdwn_CourseId.SelectedValue);
            chklist_CompulsorySubjectLists.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "COMPULSORY", String.Empty, false);
            chklist_CompulsorySubjectLists.DataTextField = "SubjectName";//StreamManagement.GetInstance.DisplayMember;
            chklist_CompulsorySubjectLists.DataValueField = "SubjectID";//StreamManagement.GetInstance.ValueMember;
            chklist_CompulsorySubjectLists.DataBind();
            foreach (ListItem list in chklist_CompulsorySubjectLists.Items)
            {
                list.Selected = true;
            }
            if (drpdwn_CourseId.SelectedValue.Equals("2"))//For +2
            {
                lbl_MaxCount.Text = "(Max-4)";
                chklist_ElectiveSubjectsBind.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "ELECTIVE", String.Empty, false);
                chklist_ElectiveSubjectsBind.DataTextField = "SubjectName";
                chklist_ElectiveSubjectsBind.DataValueField = "SubjectID";
                chklist_ElectiveSubjectsBind.DataBind();
            }
            //For +3 Science and Arts
            else if (drpdwn_CourseId.SelectedValue.Equals("3") && (DropDown_StreamList.SelectedValue.Equals("1") || DropDown_StreamList.SelectedValue.Equals("2")))
            {
                if (DropDown_StreamList.SelectedValue.Equals("1"))//if +3 Science then
                {
                    lbl_PassMaxCount.Text = "(Max-1)";
                    lbl_MinorMaxCount.Text = "(Max-1)";
                    chklist_MinorSubject.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "MINOR", String.Empty, false);
                    chklist_MinorSubject.DataTextField = "SubjectName";
                    chklist_MinorSubject.DataValueField = "SubjectID";
                    chklist_MinorSubject.DataBind();

                    lbl_MajorMaxCount.Text = "(Max-1)";
                    chklist_MajorElectiveSubjects.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "MAJOR", String.Empty, false);
                    chklist_MajorElectiveSubjects.DataTextField = "SubjectName";
                    chklist_MajorElectiveSubjects.DataValueField = "SubjectID";
                    chklist_MajorElectiveSubjects.DataBind();
                }
                else  //else +3 arts 
                {
                    lbl_PassMaxCount.Text = "(Max-2)";
                    lbl_MaxCount.Text = "(Max-2)";
                    chklist_ElectiveSubjectsBind.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "ELECTIVE", String.Empty, false);
                    chklist_ElectiveSubjectsBind.DataTextField = "SubjectName";
                    chklist_ElectiveSubjectsBind.DataValueField = "SubjectID";
                    chklist_ElectiveSubjectsBind.DataBind();
                }
                //Common to +3 Science and Arts
                lbl_HonsMaxCount.Text = "(Max-1)";
                chklist_HonsSubjects.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "HONS", String.Empty, false);
                chklist_HonsSubjects.DataTextField = "SubjectName";
                chklist_HonsSubjects.DataValueField = "SubjectID";
                chklist_HonsSubjects.DataBind();

                chklistPassSubjects.DataSource = SubjectManagement.GetInstance.GetSubjectAllByStream(StreamID, CourseID, "PASS", String.Empty, false);
                chklistPassSubjects.DataTextField = "SubjectName";
                chklistPassSubjects.DataValueField = "SubjectID";
                chklistPassSubjects.DataBind();
            }
        }
        void CheckSubjects()
        {
            //chklist_CompulsorySubjectLists.Enabled = false;
            if (drpdwn_CourseId.SelectedValue == "2")
            {
                MultiView_Subjects.SetActiveView(View_Elective);
                PanelHonsPass.Visible = false;
            }
            else if (drpdwn_CourseId.SelectedValue == "3" && DropDown_StreamList.SelectedValue == "1")
            {
                MultiView_Subjects.SetActiveView(View_MajorMinorElective);
                PanelHonsPass.Visible = true;
            }
            else if (drpdwn_CourseId.SelectedValue == "3" && DropDown_StreamList.SelectedValue == "2")
            {
                MultiView_Subjects.SetActiveView(View_Elective);
                PanelHonsPass.Visible = true;
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
                PanelHonsPass.Visible = false;
                MultiView_Subjects.ActiveViewIndex = -1;
            }
            List<Qualification> objAllQuals = QualManagement.GetInstance.GetQualsList();
            List<Qualification> objQuals = new List<Qualification>();
            if (drpdwn_CourseId.SelectedValue == "2")
            {
                objQuals = (from xyzl in objAllQuals
                            where xyzl.ClassType.Contains("2")
                            select xyzl).ToList();
            }
            else
            {
                objQuals = (from xyzl in objAllQuals
                            where xyzl.ClassType.Contains("3") || xyzl.ClassType.Contains("2")
                            select xyzl).ToList();
            }
            ddl_Qualification.Items.Clear();
            ddl_Qualification.DataSource = objQuals;
            ddl_Qualification.DataTextField = QualManagement.GetInstance.DisplayMember;
            ddl_Qualification.DataValueField = QualManagement.GetInstance.ValueMember;
            ddl_Qualification.DataBind();
            ddl_Qualification.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }
        private void ResetQualificationValues()
        {
            //ddl_Qualification.SelectedIndex = 0;
            txt_PassingYear.Text = DateTime.Now.Year.ToString();
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
                //createrow(dt, ddl_Qualification.Text, txt_PassingYear.Text, txt_Board.Text, txt_Division.Text, txt_Percentage.Text);
                gview_Course.DataSource = (DataTable)ViewState["Data"];
                gview_Course.DataBind();
                ResetQualificationValues();
            }
            else
            {
                DataTable dt1 = new DataTable();
                dt1 = (DataTable)ViewState["Data"];
                createrow(dt1, ddl_Qualification.SelectedValue, txt_PassingYear.Text, txt_Board.Text, txt_Division.Text, txt_Percentage.Text);
                //createrow(dt1, ddl_Qualification.Text, txt_PassingYear.Text, txt_Board.Text, txt_Division.Text, txt_Percentage.Text);
                gview_Course.DataSource = (DataTable)ViewState["Data"];
                gview_Course.DataBind();
                ResetQualificationValues();
            }
        }

        protected void gridview_Students_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview_Students.PageIndex = e.NewPageIndex;
            gridview_Students.DataSource = StudentManagement.GetInstance.GetStudentList();
            gridview_Students.DataBind();
        }



    }

}