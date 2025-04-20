using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.DataAccessLayer.ICAS.STUDENT;
using Micro.Commons;
using System.Data;
namespace Micro.IntegrationLayer.ICAS.STUDENT
{
    public partial class StudentIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static Student DataRowToObject(DataRow dr)
        {
            Student TheStudent = new Student();

            TheStudent.SessionID = int.Parse(dr["SessionID"].ToString());

            TheStudent.StudentID = int.Parse(dr["StudentId"].ToString());
                TheStudent.StudentCode=dr["StudentCode"].ToString();
                TheStudent. MRINO=dr["MRINO"].ToString();
                TheStudent.ReceiptNo=dr["ReceiptNo"].ToString();
                TheStudent.TCNo = dr["TCNo"].ToString();
                TheStudent.RollNo = dr["RollNo"].ToString();
                TheStudent.ClassID = (string.IsNullOrEmpty(dr["ClassId"].ToString()) == true? -1 :  int.Parse(dr["ClassId"].ToString()));
                TheStudent.QualID = (string.IsNullOrEmpty(dr["QualID"].ToString()) == true ? -1 : int.Parse(dr["QualID"].ToString()));  //int.Parse(dr["QualID"].ToString());
                TheStudent.StreamID = (string.IsNullOrEmpty(dr["StreamID"].ToString()) == true ? -1 : int.Parse(dr["StreamID"].ToString()));  //int.Parse(dr["StreamID"].ToString());
                TheStudent.Salutation = dr["Salutation"].ToString();
                TheStudent.StudentName = dr["StudentName"].ToString();
                TheStudent.FatherName = dr["FatherName"].ToString();
                TheStudent.MotherName = dr["MotherName"].ToString();
                TheStudent.Gender = dr["Gender"].ToString();
                TheStudent.Caste = dr["Caste"].ToString();
                TheStudent.PHStatus = dr["PHStatus"].ToString();
                TheStudent.Status = dr["Status"].ToString();
                TheStudent.TotalFeesPaid = dr["TotalFeesPaid"].ToString();
                TheStudent.DateOfBirth = dr["DateOfBirth"].ToString()==""?"":DateTime.Parse(dr["DateOfBirth"].ToString()).ToString(MicroConstants.DateFormat);
                TheStudent.DateOfAdmission = dr["DateOfAdmission"].ToString()==""?"":DateTime.Parse(dr["DateOfAdmission"].ToString()).ToString(MicroConstants.DateFormat);
                TheStudent.DateOfLeaving = dr["DateOfLeaving"].ToString()==""?"":DateTime.Parse(dr["DateOfLeaving"].ToString()).ToString(MicroConstants.DateFormat);
                //TheStudent.Age = int.Parse(dr["Age"].ToString());
                //TheStudent.BloodGroup = dr["BloodGroup"].ToString();
                TheStudent.Address_Present_TownOrCity = dr["Address_Present_TownOrCity"].ToString();
                TheStudent.Address_Present_Landmark = dr["Address_Present_Landmark"].ToString();
                TheStudent.Address_Present_PinCode = dr["Address_Present_PinCode"].ToString();
                TheStudent.Address_Present_DistrictID = int.Parse(dr["Address_Present_DistrictID"].ToString());
                if (dr["Address_Present_DistrictID"].ToString() != "")
                {
                    TheStudent.Address_Present_DistrictID = int.Parse(dr["Address_Present_DistrictID"].ToString());
                    TheStudent.Address_Present_DistrictName = dr["Address_Present_DistrictName"].ToString();
                }
                TheStudent.Address_Present_StateName = dr["Address_Present_StateName"].ToString();
                TheStudent.Address_Present_CountryName = dr["Address_Present_CountryName"].ToString();




                TheStudent.Address_Permanent_TownOrCity = dr["Address_Permanent_TownOrCity"].ToString();
                TheStudent.Address_Permanent_Landmark = dr["Address_Permanent_Landmark"].ToString();
                TheStudent.Address_Permanent_PinCode = dr["Address_Permanent_PinCode"].ToString();
                TheStudent.Address_Permanent_DistrictID = int.Parse(dr["Address_Permanent_DistrictID"].ToString());
                if (dr["Address_Permanent_DistrictID"].ToString() != "")
                {
                    TheStudent.Address_Permanent_DistrictID = int.Parse(dr["Address_Permanent_DistrictID"].ToString());
                    TheStudent.Address_Permanent_DistrictName = dr["Address_Permanent_DistrictName"].ToString();
                }
                TheStudent.Address_Permanent_StateName = dr["Address_Permanent_StateName"].ToString();
                TheStudent.Address_Permanent_CountryName = dr["Address_Permanent_CountryName"].ToString();

                TheStudent.PhoneNumber = dr["LandPhoneNumber"].ToString();
                TheStudent.Mobile = dr["MobileNumber"].ToString();
                TheStudent.EMailID = dr["EmailID"].ToString();
                TheStudent.OfficeID = int.Parse(dr["OfficeID"].ToString());

                TheStudent.AlumniFlag = dr["AlumniFlag"].ToString();
                TheStudent.RegistrationNumber = dr["RegistrationNumber"].ToString();
                TheStudent.AlumniPresentOccupation = dr["AlumniPresentOccupation"].ToString();
                TheStudent.AlumniYearOfPassing = dr["AlumniYearOfPassing"].ToString();

            return TheStudent;
        }

        public static StudentViewModel DataRowToStudentVidwModelObject(DataRow dr)
        {

            StudentViewModel student = new StudentViewModel();

            student.SessionID = int.Parse(dr["SessionID"].ToString());
            student.StudentID = long.Parse(dr["StudentId"].ToString());
            student.StudentCode = dr["StudentCode"].ToString();
            student.RollNo = dr["RollNo"].ToString();
            student.ClassName = dr["ClassName"].ToString();
            student.StreamName = dr["StreamName"].ToString();
            student.QualName = dr["QualName"].ToString();
            student.StreamID = (string.IsNullOrEmpty(dr["StreamID"].ToString()) == true ? -1 : int.Parse(dr["StreamID"].ToString())); 
            student.ClassID = (string.IsNullOrEmpty(dr["ClassId"].ToString()) == true ? -1 : int.Parse(dr["ClassId"].ToString()));
            student.QualID = (string.IsNullOrEmpty(dr["QualID"].ToString()) == true ? -1 : int.Parse(dr["QualID"].ToString()));
            student.Salutation = dr["Salutation"].ToString();
            student.StudentName = dr["StudentName"].ToString();
            student.FatherName = dr["FatherName"].ToString();
            student.MotherName = dr["MotherName"].ToString();
            student.Gender = dr["Gender"].ToString();
            student.Category = dr["Category"].ToString();
            student.DateOfBirth = dr["DateOfBirth"]?.ToString() == "" ? "" : DateTime.Parse(dr["DateOfBirth"].ToString()).ToString(MicroConstants.DateFormat);
            student.DateOfAdmission = dr["DateOfAdmission"]?.ToString() == "" ? "" : DateTime.Parse(dr["DateOfAdmission"].ToString()).ToString(MicroConstants.DateFormat);
            student.PresentAddress_TownCity = dr["Address_Present_TownOrCity"]?.ToString();
            student.PresentAddress_District = dr["Address_Present_DistrictName"]?.ToString();
            student.PresentAddress_State = dr["Address_Present_StateName"]?.ToString();
            student.PresentAddress_PIN =   dr["Address_Present_PinCode"]?.ToString();
            student.PermanentAddress_TownCity = dr["Address_Permanent_TownOrCity"]?.ToString();
            student.PermanentAddress_District = dr["Address_Permanent_DistrictName"]?.ToString();
            student.PermanentAddress_State = dr["Address_Permanent_StateName"]?.ToString();
            student.PermanentAddress_PIN = dr["Address_Permanent_PinCode"]?.ToString();
            student.Mobile = dr["MobileNumber"].ToString();
            student.EMail = dr["EmailID"].ToString();
            student.MRINO = dr["MRINO"].ToString();
            student.BarcodeNo = dr["BarcodeNo"].ToString();
            student.AadhaarNo = dr["AadhaarNo"].ToString();
            student.AdmissionType = dr["AdmissionType"].ToString();
            student.SubjectName = dr["SubjectName"].ToString();
            student.SLCNo = dr["SLCNo"].ToString();
            student.SLCDate = dr["SLCDate"]?.ToString() == "" ? "" : DateTime.Parse(dr["SLCDate"].ToString()).ToString(MicroConstants.DateFormat);
            student.isActive = bool.Parse(dr["isActive"].ToString());

            return student;
        }

        public static int InsertUpdateStudent(Student2Save student)
        {
            return StudentDataAccess.GetInstance.InsertUpdateStudent(student);
        }

        public static dynamic GetCollegeSummary()
        {
            DataSet ds = StudentDataAccess.GetInstance.GetCollegeSummary();
            if (ds == null) return null;
            ds.Tables[0].TableName = "StudentsByStream";
            ds.Tables[1].TableName = "StudentsByClass";
            ds.Tables[2].TableName = "StudentsByClassAndSubject";
            ds.Tables[3].TableName = "StudentsByCategory";
            ds.Tables[4].TableName = "StudentsByAdmissionType";
            ds.Tables[5].TableName = "StudentsByGender";
            ds.Tables[6].TableName = "StudentsByGenderAndStream";
            ds.Tables[7].TableName = "StudentsByGenderAndClass";
            ds.Tables[8].TableName = "LibraryBooksTotal";
            ds.Tables[9].TableName = "LibraryBooksByType";
            ds.Tables[10].TableName = "LibraryBooksBySubject";
            ds.Tables[11].TableName = "FeedbackSummary";
            //ds.Tables[12].TableName = "StudentStrengthByYear";

            return ds;
        }

        public static dynamic StudentStrengthByYear()
        {
            DataSet ds = StudentDataAccess.GetInstance.StudentStrengthByYear();
            if (ds == null) return null;
            ds.Tables[0].TableName = "StudentStrengthByYear";
            return ds;
        }

        public static StudentListBySubject StDataRowToObject(DataRow dr)
        {
            StudentListBySubject TheStudent = new StudentListBySubject();
            TheStudent.StudentID = int.Parse(dr["StudentId"].ToString());
            TheStudent.StudentCode = dr["StudentCode"].ToString();
            TheStudent.StudentName = dr["StudentName"].ToString();
            TheStudent.SubjectID = int.Parse(dr["SubjectID"].ToString());
            TheStudent.ROLLNo = dr["ROLLNo"].ToString();
            TheStudent.QualID = int.Parse(dr["QualID"].ToString());
             
            return TheStudent;
        }
        public static List<Student> GetStudentList()
        {
            List<Student> StudentList = new List<Student>();
            DataTable StudentTable = StudentDataAccess.GetInstance.GetStudentList();
            foreach (DataRow dr in StudentTable.Rows)
            {
                Student TheStudent = DataRowToObject(dr);
                StudentList.Add(TheStudent);
            }
            return StudentList;
        }



        public static List<Student> GetStudentList(bool allOffices = false, bool showDeleted = false, bool alumniFlag = false)
        {
            List<Student> StudentList = new List<Student>();
            DataTable StudentTable = StudentDataAccess.GetInstance.GetStudentList(allOffices, showDeleted, alumniFlag);
            foreach (DataRow dr in StudentTable.Rows)
            {
                Student TheStudent = DataRowToObject(dr);
                StudentList.Add(TheStudent);
            }
            return StudentList;
        }

        public static DataTable GetStudentListReport(string searchText)
        {
            DataTable StudentTable = StudentDataAccess.GetInstance.GetStudentListReport(searchText);
            return StudentTable;
        }
        public static Boolean GetStudent_SitStatus_ByQualAndStream(int QualID, int StreamID, int SessionID, string StudentCode)
        {
            bool StudentSitStatus = StudentDataAccess.GetInstance.GetStudent_SitStatus_ByQualAndStream(QualID, StreamID, SessionID, StudentCode);
            return StudentSitStatus;
        }
        public static List<StudentListBySubject> GetStudentList_BySubject(int SubjectID, int SectionID)
        {
            List<StudentListBySubject> StudentListByFac = new List<StudentListBySubject>();
            DataTable StudentListByFacTable = StudentDataAccess.GetInstance.GetStudentList_BySubject(SubjectID,SectionID);
            foreach (DataRow dr in StudentListByFacTable.Rows)
            {
                StudentListBySubject TheStudent = StDataRowToObject(dr);
                StudentListByFac.Add(TheStudent);
            }
            return StudentListByFac;
        }
        public static int InsertStudent(Student theStudent, List<StudentSubjectTaken> StudentSubjects, List<StudentPreviousQual> StudentPreQualList)
        {
            return StudentDataAccess.GetInstance.InsertStudent(theStudent, StudentSubjects, StudentPreQualList);
        }
        public static int InsertStudent(Student theStudent, List<StudentSubjectTaken> StudentSubjects, List<StudentPreviousQual> StudentPreQualList, bool alumniFlag)
        {
            return StudentDataAccess.GetInstance.InsertStudent(theStudent, StudentSubjects, StudentPreQualList, alumniFlag);
        }
        public static int UpdateStudent(Student theStudent,List <StudentSubjectTaken> StudentSubjects)
        {
            return StudentDataAccess.GetInstance.UpdateStudent(theStudent, StudentSubjects);
        }
        public static int UpdateStudent(Student theStudent)
        {
            return StudentDataAccess.GetInstance.UpdateStudent(theStudent);
        }
        public static int DeleteStudent(Student theStudent)
        {
            return StudentDataAccess.GetInstance.DeleteStudent(theStudent);
        }

        #endregion


        #region for api
        public static List<StudentViewModel> GetStudents(StudentSearchPayload payload)
        {
            List<StudentViewModel> StudentList = new List<StudentViewModel>();
            DataTable StudentTable = StudentDataAccess.GetInstance.GetStudents(payload);
            int slNo = 1;
            foreach (DataRow dr in StudentTable.Rows)
            {
                StudentViewModel TheStudent = DataRowToStudentVidwModelObject(dr);
                TheStudent.SLNo = ((payload.pageNo - 1) * payload.pageSize) + slNo;
                StudentList.Add(TheStudent);
                slNo++;
            }
            return StudentList;
        }

        #endregion

    }
}
