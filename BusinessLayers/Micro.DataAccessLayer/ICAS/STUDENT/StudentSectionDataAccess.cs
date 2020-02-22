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
    public partial class StudentSectionDataAccess : AbstractData_SQLClient
    {
        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static StudentSectionDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StudentSectionDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentSectionDataAccess();
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
        public DataTable GetSectionList(string searchText)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@searchText", SqlDbType.VarChar, searchText)); 
                SelectCommand.CommandText = "pICAS_Student_Section_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetSectionListBysubjectID(int SubjectID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, SubjectID));                
                SelectCommand.CommandText = "pICAS_Subjects_SelectAll_BySubjectID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetStudentListBySectionID(int SectionID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SectiongroupID", SqlDbType.Int, SectionID));
                SelectCommand.CommandText = "pICAS_Student_SelectAll_By_SectionID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertStudentSection(StudentSection theSection)
        {
            int ReturnValueSection = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueSection)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@CourseID", SqlDbType.Int, theSection.CourseID));
                InsertCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theSection.StreamID));
                InsertCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.Int, theSection.ClassID));                
                InsertCommand.Parameters.Add(GetParameter("@StudentIDS", SqlDbType.VarChar, theSection.StudentIDS));
                InsertCommand.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, theSection.SubjectID));
                InsertCommand.Parameters.Add(GetParameter("@SectionID", SqlDbType.Int, theSection.SectionID));
                InsertCommand.Parameters.Add(GetParameter("@SectionName", SqlDbType.VarChar, theSection.SectionName));
                InsertCommand.Parameters.Add(GetParameter("@Comment", SqlDbType.VarChar, theSection.Comment));               
                InsertCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theSection.SessionID));                      
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));                
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int,8));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));
                InsertCommand.CommandText = "pICAS_Student_SectionGrouping_InsertNew";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValueSection = int.Parse(InsertCommand.Parameters[0].Value.ToString());
            }
            return ReturnValueSection;
        }
        public int UpdateStudentSection(StudentSection theSection)
        {
            int ReturnValueSection = 0;
            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueSection)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@CourseID", SqlDbType.Int, theSection.CourseID));
                UpdateCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theSection.StreamID));
                UpdateCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.Int, theSection.ClassID));  
                UpdateCommand.Parameters.Add(GetParameter("@StudentIDS", SqlDbType.VarChar, theSection.StudentIDS));
                UpdateCommand.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, theSection.SubjectID));
                UpdateCommand.Parameters.Add(GetParameter("@SectionID", SqlDbType.Int, theSection.SectionID));
                UpdateCommand.Parameters.Add(GetParameter("@Comment", SqlDbType.VarChar, theSection.Comment));
                //UpdateCommand.Parameters.Add(GetParameter("@SectionName", SqlDbType.VarChar, theSection.SectionName));
                UpdateCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theSection.SessionID));
                //UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));// TO DO KP
                UpdateCommand.CommandText = "pICAS_Student_SectionGrouping_UpdateNew";            
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValueSection = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
            }
            return ReturnValueSection;
        }
    }
}
        #endregion