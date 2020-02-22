using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Micro.Commons;
using Micro.Objects.ICAS.STUDENT;


namespace Micro.DataAccessLayer.ICAS.STUDENT
{
    public partial class StudentDataAccess : AbstractData_SQLClient
    {
        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static StudentDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StudentDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        #endregion

        #region Methods & Implementation
        public DataTable GetStudentListForSendingShortMessage()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pICAS_Students_SelectAll4ShortMessage";
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //Micro.Commons.Connection.LoggedOnUser.OfficeID
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetStudentList(bool allOffices = false, bool showDeleted = false, bool alumniFlag = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;

                if (alumniFlag == true)
                {
                    SelectCommand.CommandText = "pICAS_Alumni_SelectAll";
                    //SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                    //SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                    SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //Micro.Commons.Connection.LoggedOnUser.OfficeID
                }
                else
                {
                    SelectCommand.CommandText = "pICAS_Students_SelectAll";
                    SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                    SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                    SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //Micro.Commons.Connection.LoggedOnUser.OfficeID
                }


                return ExecuteGetDataTable(SelectCommand);

            }
        }
        public DataTable GetStudentListReport(string searchText)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@searchText", SqlDbType.VarChar, searchText));
                SelectCommand.CommandText = "pICAS_Students_Search_SelectAll";

                return ExecuteGetDataTable(SelectCommand);

            }
        }
        public Boolean GetStudent_SitStatus_ByQualAndStream(int QualID, int StreamID, int SessionID, string StudentCode)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                bool ReturnVal = false;
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@Result", SqlDbType.Bit, ReturnVal)).Direction = ParameterDirection.Output;
                SelectCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, QualID));
                SelectCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, StreamID));
                SelectCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, SessionID));
                SelectCommand.Parameters.Add(GetParameter("@StudentCode", SqlDbType.VarChar, StudentCode));
                SelectCommand.CommandText = "pICAS_StudentSitStatus_ByQualAndStream";
                ExecuteStoredProcedure(SelectCommand);
                ReturnVal = Boolean.Parse(SelectCommand.Parameters[0].Value.ToString());
                return ReturnVal;
            }
        }
        public DataTable GetStudentList_BySubject(int SubjectID, int SectionID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, SubjectID));
                SelectCommand.Parameters.Add(GetParameter("@SectionID", SqlDbType.Int, SectionID));
                SelectCommand.CommandText = "pICAS_Student_SelectAll_By_SubjectID";
                return ExecuteGetDataTable(SelectCommand);

            }
        }

        public int InsertStudent(Student theStudent, List<StudentSubjectTaken> StudentSubjects, List<StudentPreviousQual> StudentPreQualList)
        {
            int ReturnValueStudent = 0;
            int ReturnValueSubjects = 0;
            int ReturnValuePreQuals = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueStudent)).Direction = ParameterDirection.Output;
                //InsertCommand.Parameters.Add(GetParameter("@StudentCode", SqlDbType.VarChar, theStudent.StudentCode));
                //InsertCommand.Parameters.Add(GetParameter("@MRINO",SqlDbType.VarChar,theStudent.MRINO));
                //InsertCommand.Parameters.Add(GetParameter("@ReceiptNo", SqlDbType.VarChar, theStudent.ReceiptNo));
                //InsertCommand.Parameters.Add(GetParameter("@TCNo", SqlDbType.VarChar, theStudent.TCNo));
                InsertCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.Int, theStudent.ClassID));
                InsertCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theStudent.QualID));
                InsertCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theStudent.StreamID));
                //InsertCommand.Parameters.Add(GetParameter("@RollNo", SqlDbType.VarChar, theStudent.RollNo==""?Convert.DBNull:theStudent.RollNo));
                InsertCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theStudent.Salutation));
                InsertCommand.Parameters.Add(GetParameter("@StudentName", SqlDbType.VarChar, theStudent.StudentName.ToUpper()));
                InsertCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theStudent.FatherName.ToUpper()));
                InsertCommand.Parameters.Add(GetParameter("@MotherName", SqlDbType.VarChar, theStudent.MotherName.ToUpper()));
                InsertCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theStudent.Gender));
                InsertCommand.Parameters.Add(GetParameter("@Caste", SqlDbType.VarChar, theStudent.Caste));
                InsertCommand.Parameters.Add(GetParameter("@PHStatus", SqlDbType.VarChar, theStudent.PHStatus));
                InsertCommand.Parameters.Add(GetParameter("@Status", SqlDbType.VarChar, theStudent.Status));
                //InsertCommand.Parameters.Add(GetParameter("@TotalFeesPaid", SqlDbType.VarChar, theStudent.TotalFeesPaid));
                InsertCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.DateTime, DateTime.Parse(theStudent.@DateOfBirth).ToString(MicroConstants.DateFormat)));
                //InsertCommand.Parameters.Add(GetParameter("@DateOfAdmission", SqlDbType.DateTime,theStudent.DateOfAdmission==string.Empty?Convert.DBNull:DateTime.Parse(theStudent.DateOfAdmission).ToString(MicroConstants.DateFormat)));
                //InsertCommand.Parameters.Add(GetParameter("@DateOfLeaving", SqlDbType.DateTime, Convert.DBNull));
                InsertCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theStudent.Age));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theStudent.Address_Present_TownOrCity.ToUpper()));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theStudent.Address_Present_Landmark.ToUpper()));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theStudent.Address_Present_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theStudent.Address_Present_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theStudent.Address_Permanent_TownOrCity.ToUpper()));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theStudent.Address_Permanent_Landmark.ToUpper()));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theStudent.Address_Permanent_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theStudent.Address_Permanent_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theStudent.PhoneNumber));
                InsertCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theStudent.Mobile));
                InsertCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theStudent.SessionID));
                InsertCommand.Parameters.Add(GetParameter("@EmailID", SqlDbType.VarChar, theStudent.EMailID.ToLower()));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));//TO DO KP Remove HardCode
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));//TO DO KP Remove HardCode
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO KP Remove HardCode
                InsertCommand.CommandText = "pICAS_Students_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValueStudent = int.Parse(InsertCommand.Parameters[0].Value.ToString());
            }
            foreach (StudentSubjectTaken StSubjects in StudentSubjects)
            {
                using (SqlCommand InsertCommandSubjects = new SqlCommand())
                {
                    InsertCommandSubjects.CommandType = CommandType.StoredProcedure;
                    InsertCommandSubjects.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueSubjects)).Direction = ParameterDirection.Output;
                    InsertCommandSubjects.Parameters.Add(GetParameter("@StudentID", SqlDbType.Int, ReturnValueStudent));
                    InsertCommandSubjects.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, StSubjects.SubjectID));
                    InsertCommandSubjects.Parameters.Add(GetParameter("@SubjectType", SqlDbType.VarChar, StSubjects.SubjectType));
                    InsertCommandSubjects.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theStudent.SessionID));//TO DO KP Remove HardCode
                    InsertCommandSubjects.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));//TO DO KP Remove HardCode
                    InsertCommandSubjects.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));//TO DO KP Remove HardCode
                    InsertCommandSubjects.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO KP Remove HardCode
                    InsertCommandSubjects.CommandText = "pICAS_Student_Subjects_Insert";
                    ExecuteStoredProcedure(InsertCommandSubjects);
                    ReturnValueSubjects = int.Parse(InsertCommandSubjects.Parameters[0].Value.ToString());
                }
            }
            foreach (StudentPreviousQual thePreQualifications in StudentPreQualList)
            {
                using (SqlCommand InsertCommandPreQuals = new SqlCommand())
                {
                    InsertCommandPreQuals.CommandType = CommandType.StoredProcedure;
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValuePreQuals)).Direction = ParameterDirection.Output;
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@StudentID", SqlDbType.Int, ReturnValueStudent));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, thePreQualifications.QualID));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@PassingYear", SqlDbType.VarChar, thePreQualifications.PassingYear));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@Board", SqlDbType.VarChar, thePreQualifications.Board));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@Division", SqlDbType.VarChar, thePreQualifications.Division));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@Percentage", SqlDbType.VarChar, thePreQualifications.Percentage));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));//TO DO
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));//TO DO

                    InsertCommandPreQuals.CommandText = "piCAS_Student_PreQuals_Insert";
                    ExecuteStoredProcedure(InsertCommandPreQuals);
                    ReturnValuePreQuals = int.Parse(InsertCommandPreQuals.Parameters[0].Value.ToString());
                }
            }
            return ReturnValueStudent;
        }

        // alumni
        public int InsertStudent(Student theStudent, List<StudentSubjectTaken> StudentSubjects, List<StudentPreviousQual> StudentPreQualList, bool alumniFlag)
        {
            int ReturnValueStudent = 0;
            int ReturnValueSubjects = 0;
            int ReturnValuePreQuals = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueStudent)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.Int, theStudent.ClassID));
                InsertCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theStudent.QualID));
                InsertCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theStudent.StreamID));
                InsertCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theStudent.Salutation));
                InsertCommand.Parameters.Add(GetParameter("@StudentName", SqlDbType.VarChar, theStudent.StudentName));
                InsertCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theStudent.FatherName));
                InsertCommand.Parameters.Add(GetParameter("@MotherName", SqlDbType.VarChar, theStudent.MotherName));
                InsertCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theStudent.Gender));
                InsertCommand.Parameters.Add(GetParameter("@Caste", SqlDbType.VarChar, theStudent.Caste));
                //InsertCommand.Parameters.Add(GetParameter("@PHStatus", SqlDbType.VarChar, theStudent.PHStatus));
                InsertCommand.Parameters.Add(GetParameter("@Status", SqlDbType.VarChar, theStudent.Status));
                InsertCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.DateTime, DateTime.Parse(theStudent.@DateOfBirth).ToString(MicroConstants.DateFormat)));
                InsertCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theStudent.Age));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theStudent.Address_Present_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theStudent.Address_Present_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theStudent.Address_Present_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theStudent.Address_Present_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theStudent.Address_Permanent_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theStudent.Address_Permanent_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theStudent.Address_Permanent_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theStudent.Address_Permanent_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theStudent.PhoneNumber));
                InsertCommand.Parameters.Add(GetParameter("@EmailID", SqlDbType.VarChar, theStudent.EMailID));
                InsertCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theStudent.Mobile));
                InsertCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theStudent.SessionID));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));//TO DO KP Remove HardCode
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));//TO DO KP Remove HardCode
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO KP Remove HardCode

                InsertCommand.Parameters.Add(GetParameter("@RegistrationNo", SqlDbType.VarChar, theStudent.RegistrationNumber));
                InsertCommand.Parameters.Add(GetParameter("@AlumniLifeMemberStatus", SqlDbType.VarChar, theStudent.LifeMemberStatus));
                InsertCommand.Parameters.Add(GetParameter("@AlumniMembershipFeesPaid", SqlDbType.Int, theStudent.AlumniMembershipFeesPaid));
                InsertCommand.Parameters.Add(GetParameter("@AlumniMembershipFeesPaidDetails", SqlDbType.VarChar, theStudent.AlumniMembershipFeesPaidDetails));
                InsertCommand.Parameters.Add(GetParameter("@AlumniPresentOccupation", SqlDbType.VarChar, theStudent.AlumniPresentOccupation));
                InsertCommand.Parameters.Add(GetParameter("@AlumniYearOfPassing", SqlDbType.VarChar, theStudent.AlumniYearOfPassing));

                InsertCommand.CommandText = "[pICAS_Alumni_Insert]";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValueStudent = int.Parse(InsertCommand.Parameters[0].Value.ToString());
            }
            foreach (StudentSubjectTaken StSubjects in StudentSubjects)
            {
                using (SqlCommand InsertCommandSubjects = new SqlCommand())
                {
                    InsertCommandSubjects.CommandType = CommandType.StoredProcedure;
                    InsertCommandSubjects.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueSubjects)).Direction = ParameterDirection.Output;
                    InsertCommandSubjects.Parameters.Add(GetParameter("@StudentID", SqlDbType.Int, ReturnValueStudent));
                    InsertCommandSubjects.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, StSubjects.SubjectID));
                    InsertCommandSubjects.Parameters.Add(GetParameter("@SubjectType", SqlDbType.VarChar, StSubjects.SubjectType));
                    InsertCommandSubjects.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theStudent.SessionID));//TO DO KP Remove HardCode
                    InsertCommandSubjects.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));//TO DO KP Remove HardCode
                    InsertCommandSubjects.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 21));//TO DO KP Remove HardCode
                    InsertCommandSubjects.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO KP Remove HardCode
                    InsertCommandSubjects.CommandText = "pICAS_Student_Subjects_Insert";
                    ExecuteStoredProcedure(InsertCommandSubjects);
                    ReturnValueSubjects = int.Parse(InsertCommandSubjects.Parameters[0].Value.ToString());
                }
            }
            foreach (StudentPreviousQual thePreQualifications in StudentPreQualList)
            {
                using (SqlCommand InsertCommandPreQuals = new SqlCommand())
                {
                    InsertCommandPreQuals.CommandType = CommandType.StoredProcedure;
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValuePreQuals)).Direction = ParameterDirection.Output;
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@StudentID", SqlDbType.Int, ReturnValueStudent));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, thePreQualifications.QualID));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@PassingYear", SqlDbType.VarChar, thePreQualifications.PassingYear));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@Board", SqlDbType.VarChar, thePreQualifications.Board));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@Division", SqlDbType.VarChar, thePreQualifications.Division));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@Percentage", SqlDbType.VarChar, thePreQualifications.Percentage));
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 23));//TO DO
                    InsertCommandPreQuals.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));//TO DO

                    InsertCommandPreQuals.CommandText = "piCAS_Student_PreQuals_Insert";
                    ExecuteStoredProcedure(InsertCommandPreQuals);
                    ReturnValuePreQuals = int.Parse(InsertCommandPreQuals.Parameters[0].Value.ToString());
                }
            }
            return ReturnValueStudent;
        }

        public int UpdateStudent(Student theStudent, List<StudentSubjectTaken> StudentSubjects)
        {
            int ReturnValue = 0;
            int ReturnValueSubjects = 0;
            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValueStudent", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@StudentId", SqlDbType.Int, theStudent.StudentID));
                UpdateCommand.Parameters.Add(GetParameter("@StudentCode", SqlDbType.VarChar, theStudent.StudentCode));
                UpdateCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.Int, theStudent.ClassID));
                UpdateCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theStudent.QualID));
                UpdateCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theStudent.StreamID));
                UpdateCommand.Parameters.Add(GetParameter("@MRINO", SqlDbType.VarChar, theStudent.MRINO));
                UpdateCommand.Parameters.Add(GetParameter("@ReceiptNo", SqlDbType.VarChar, theStudent.ReceiptNo));
                UpdateCommand.Parameters.Add(GetParameter("@TCNo", SqlDbType.VarChar, theStudent.TCNo));
                UpdateCommand.Parameters.Add(GetParameter("@RollNo", SqlDbType.VarChar, theStudent.RollNo));
                UpdateCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theStudent.Salutation));
                UpdateCommand.Parameters.Add(GetParameter("@StudentName", SqlDbType.VarChar, theStudent.StudentName));
                UpdateCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theStudent.FatherName));
                UpdateCommand.Parameters.Add(GetParameter("@MotherName", SqlDbType.VarChar, theStudent.MotherName));
                UpdateCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theStudent.Gender));
                UpdateCommand.Parameters.Add(GetParameter("@Caste", SqlDbType.VarChar, theStudent.Caste));
                UpdateCommand.Parameters.Add(GetParameter("@PHStatus", SqlDbType.VarChar, theStudent.PHStatus));
                UpdateCommand.Parameters.Add(GetParameter("@Status", SqlDbType.VarChar, theStudent.Status));
                UpdateCommand.Parameters.Add(GetParameter("@TotalFeesPaid", SqlDbType.VarChar, theStudent.TotalFeesPaid));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.DateTime, DateTime.Parse(theStudent.@DateOfBirth).ToString(MicroConstants.DateFormat)));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfAdmission", SqlDbType.DateTime, DateTime.Parse(theStudent.DateOfAdmission).ToString(MicroConstants.DateFormat)));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfLeaving", SqlDbType.DateTime, theStudent.DateOfLeaving == "" ? Convert.DBNull : DateTime.Parse(theStudent.DateOfLeaving).ToString(MicroConstants.DateFormat)));
                UpdateCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theStudent.Age));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theStudent.Address_Present_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theStudent.Address_Present_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theStudent.Address_Present_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theStudent.Address_Present_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theStudent.Address_Permanent_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theStudent.Address_Permanent_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theStudent.Address_Permanent_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theStudent.Address_Permanent_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theStudent.PhoneNumber));
                UpdateCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theStudent.Mobile));
                UpdateCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theStudent.SessionID));//TO DO Remove HardCode  KP

                UpdateCommand.Parameters.Add(GetParameter("@AccountIDs", SqlDbType.VarChar, theStudent.AccountIDs));
                UpdateCommand.Parameters.Add(GetParameter("@AccountCodes", SqlDbType.VarChar, theStudent.AccountCodes));
                UpdateCommand.Parameters.Add(GetParameter("@AccountNames", SqlDbType.VarChar, theStudent.AccountNames));
                UpdateCommand.Parameters.Add(GetParameter("@AccountFees", SqlDbType.VarChar, theStudent.AccountFees));
                UpdateCommand.Parameters.Add(GetParameter("@BalanceTypes", SqlDbType.VarChar, theStudent.BalanceTypes));
                UpdateCommand.Parameters.Add(GetParameter("@Narations", SqlDbType.VarChar, theStudent.Narations));

                UpdateCommand.Parameters.Add(GetParameter("@EmailID", SqlDbType.VarChar, theStudent.EMailID));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));//TO DO Remove HardCode  KP
                UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));//TO DO Remove HardCode  KP
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 11));//TO DO Remove HardCode  KP                
                UpdateCommand.CommandText = "pICAS_Students_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
            }
            string SubjectIDs = string.Empty;
            string valSubjects = string.Empty;
            if (ReturnValue > 0)
            {
                foreach (StudentSubjectTaken StSubjects in StudentSubjects)
                {
                    using (SqlCommand UpdateCommandSubjects = new SqlCommand())
                    {
                        UpdateCommandSubjects.CommandType = CommandType.StoredProcedure;
                        SubjectIDs = SubjectIDs + StSubjects.SubjectID + ",";
                        valSubjects = SubjectIDs.Remove(SubjectIDs.Length - 1);
                        UpdateCommandSubjects.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueSubjects)).Direction = ParameterDirection.Output;
                        UpdateCommandSubjects.Parameters.Add(GetParameter("@StudentID", SqlDbType.Int, ReturnValue));
                        UpdateCommandSubjects.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, StSubjects.SubjectID));
                        UpdateCommandSubjects.Parameters.Add(GetParameter("@SubjectType", SqlDbType.VarChar, StSubjects.SubjectType));
                        UpdateCommandSubjects.Parameters.Add(GetParameter("@SubjectIDs", SqlDbType.VarChar, valSubjects));
                        UpdateCommandSubjects.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theStudent.SessionID));//TO DO KP Remove HardCode : SERIOUS CASE .... !!!
                        UpdateCommandSubjects.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));//TO DO KP Remove HardCode
                        UpdateCommandSubjects.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));//TO DO KP Remove HardCode
                        UpdateCommandSubjects.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO KP Remove HardCode
                        UpdateCommandSubjects.CommandText = "pICAS_Student_Subjects_Register";
                        ExecuteStoredProcedure(UpdateCommandSubjects);
                        ReturnValueSubjects = int.Parse(UpdateCommandSubjects.Parameters[0].Value.ToString());
                    }
                }
            }
            return ReturnValue;

        }

        public int UpdateStudent(Student theStudent)
        {
            int ReturnValue = 0;
            int ReturnValueSubjects = 0;
            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValueStudent", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@StudentId", SqlDbType.Int, theStudent.StudentID));
                UpdateCommand.Parameters.Add(GetParameter("@StudentCode", SqlDbType.VarChar, theStudent.StudentCode));
                UpdateCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.Int, theStudent.ClassID));
                UpdateCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theStudent.QualID));
                UpdateCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theStudent.StreamID));
                UpdateCommand.Parameters.Add(GetParameter("@MRINO", SqlDbType.VarChar, theStudent.MRINO));
                UpdateCommand.Parameters.Add(GetParameter("@ReceiptNo", SqlDbType.VarChar, theStudent.ReceiptNo));
                UpdateCommand.Parameters.Add(GetParameter("@TCNo", SqlDbType.VarChar, theStudent.TCNo));
                UpdateCommand.Parameters.Add(GetParameter("@RollNo", SqlDbType.VarChar, theStudent.RollNo));
                UpdateCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theStudent.Salutation));
                UpdateCommand.Parameters.Add(GetParameter("@StudentName", SqlDbType.VarChar, theStudent.StudentName));
                UpdateCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theStudent.FatherName));
                UpdateCommand.Parameters.Add(GetParameter("@MotherName", SqlDbType.VarChar, theStudent.MotherName));
                UpdateCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theStudent.Gender));
                UpdateCommand.Parameters.Add(GetParameter("@Caste", SqlDbType.VarChar, theStudent.Caste));
                UpdateCommand.Parameters.Add(GetParameter("@PHStatus", SqlDbType.VarChar, theStudent.PHStatus));
                UpdateCommand.Parameters.Add(GetParameter("@Status", SqlDbType.VarChar, theStudent.Status));
                UpdateCommand.Parameters.Add(GetParameter("@TotalFeesPaid", SqlDbType.VarChar, theStudent.TotalFeesPaid));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.DateTime, DateTime.Parse(theStudent.@DateOfBirth).ToString(MicroConstants.DateFormat)));
                //UpdateCommand.Parameters.Add(GetParameter("@DateOfAdmission", SqlDbType.DateTime, DateTime.Parse(theStudent.DateOfAdmission).ToString(MicroConstants.DateFormat)));
                //UpdateCommand.Parameters.Add(GetParameter("@DateOfLeaving", SqlDbType.DateTime, theStudent.DateOfLeaving == "" ? Convert.DBNull : DateTime.Parse(theStudent.DateOfLeaving).ToString(MicroConstants.DateFormat)));
                //UpdateCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theStudent.Age));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theStudent.Address_Present_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theStudent.Address_Present_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theStudent.Address_Present_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theStudent.Address_Present_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theStudent.Address_Permanent_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theStudent.Address_Permanent_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theStudent.Address_Permanent_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theStudent.Address_Permanent_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theStudent.PhoneNumber));
                UpdateCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theStudent.Mobile));
                UpdateCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theStudent.SessionID));//TO DO Remove HardCode  KP

                UpdateCommand.Parameters.Add(GetParameter("@AccountIDs", SqlDbType.VarChar, theStudent.AccountIDs));
                UpdateCommand.Parameters.Add(GetParameter("@AccountCodes", SqlDbType.VarChar, theStudent.AccountCodes));
                UpdateCommand.Parameters.Add(GetParameter("@AccountNames", SqlDbType.VarChar, theStudent.AccountNames));
                UpdateCommand.Parameters.Add(GetParameter("@AccountFees", SqlDbType.VarChar, theStudent.AccountFees));
                UpdateCommand.Parameters.Add(GetParameter("@BalanceTypes", SqlDbType.VarChar, theStudent.BalanceTypes));
                UpdateCommand.Parameters.Add(GetParameter("@Narations", SqlDbType.VarChar, theStudent.Narations));

                UpdateCommand.Parameters.Add(GetParameter("@EmailID", SqlDbType.VarChar, theStudent.EMailID));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));//TO DO Remove HardCode  KP
                UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));//TO DO Remove HardCode  KP
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 11));//TO DO Remove HardCode  KP                
                UpdateCommand.CommandText = "[pICAS_Students_Update_1]";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
            }

            return ReturnValue;

        }

        public int DeleteStudent(Student theStudent)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@StudentId", SqlDbType.Int, theStudent.StudentID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));
                DeleteCommand.CommandText = "pICAS_Students_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
