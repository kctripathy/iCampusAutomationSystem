using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using Micro.Objects.ICAS.STUDENT;

namespace Micro.DataAccessLayer.ICAS.STUDENT
{
    public partial class StudentAttendanceDataAccess : AbstractData_SQLClient
    {
        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static StudentAttendanceDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StudentAttendanceDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentAttendanceDataAccess();
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
        public DataTable GetAttnsList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pICAS_Student_Attn_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetAttnsListByFaculty(int FacultyID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@StaffID", SqlDbType.Int,FacultyID));                
                SelectCommand.CommandText = "pICAS_Subjects_SelectAll_ByFacultyID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetStudentListByAttnID(int AttnID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AttnID", SqlDbType.Int, AttnID));
                SelectCommand.CommandText = "pICAS_Student_SelectAll_By_AttnID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        
        public int InsertStudentAttns(StudentAttendance theAttns)
        {
            int ReturnValueAttns = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueAttns)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@StudentIDS", SqlDbType.VarChar, theAttns.StudentIDS));
                InsertCommand.Parameters.Add(GetParameter("@SectionID", SqlDbType.Int, theAttns.SectionID));
                InsertCommand.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, theAttns.SubjectID));
                InsertCommand.Parameters.Add(GetParameter("@StaffID", SqlDbType.Int, theAttns.StaffID));
                InsertCommand.Parameters.Add(GetParameter("@ClassCloseTime", SqlDbType.VarChar, theAttns.ClassCloseTime));
                InsertCommand.Parameters.Add(GetParameter("@ClassStartTime", SqlDbType.VarChar, theAttns.ClassStartTime));
                InsertCommand.Parameters.Add(GetParameter("@Comment", SqlDbType.VarChar, theAttns.Comment));

                InsertCommand.Parameters.Add(GetParameter("@Date", SqlDbType.VarChar, theAttns.Date));

                InsertCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theAttns.SessionID));                      
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));                
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int,8));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));
                InsertCommand.CommandText = "pICAS_Student_Attendance_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValueAttns = int.Parse(InsertCommand.Parameters[0].Value.ToString());
            }
            return ReturnValueAttns;
        }
        public int UpdateStudentAttns(StudentAttendance theAttns)
        {
            int ReturnValueAttns = 0;
            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueAttns)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@AttenID", SqlDbType.Int, theAttns.AttenID));
                UpdateCommand.Parameters.Add(GetParameter("@StudentIDS", SqlDbType.VarChar, theAttns.StudentIDS));
                UpdateCommand.Parameters.Add(GetParameter("@SectionID", SqlDbType.Int, theAttns.SectionID));
                UpdateCommand.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, theAttns.SubjectID));
                UpdateCommand.Parameters.Add(GetParameter("@StaffID", SqlDbType.VarChar, theAttns.StaffID));
                UpdateCommand.Parameters.Add(GetParameter("@ClassCloseTime", SqlDbType.Int, theAttns.ClassCloseTime));
                UpdateCommand.Parameters.Add(GetParameter("@ClassStartTime", SqlDbType.Int, theAttns.ClassStartTime));
                UpdateCommand.Parameters.Add(GetParameter("@Comment", SqlDbType.Int, theAttns.Comment));

                UpdateCommand.Parameters.Add(GetParameter("@Date", SqlDbType.VarChar, theAttns.Date));

                UpdateCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theAttns.SessionID));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));
                UpdateCommand.CommandText = "pICAS_Student_Attendance_Update";            
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValueAttns = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
            }
            return ReturnValueAttns;
        }
    }
}
        #endregion