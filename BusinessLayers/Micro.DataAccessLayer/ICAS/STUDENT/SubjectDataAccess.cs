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
    public partial class SubjectDataAccess : AbstractData_SQLClient
    {
        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static SubjectDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static SubjectDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SubjectDataAccess();
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
        public DataTable GetSubjectList(string searchText)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@searchText", SqlDbType.VarChar, searchText));
                SelectCommand.CommandText = "pICAS_Subjects_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetSubjectListByParent(int StreamID, int CourseID, string SubjectTypeName, string searchText = null, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, StreamID));
                SelectCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, CourseID));
                SelectCommand.Parameters.Add(GetParameter("@SubjectTypeName", SqlDbType.VarChar,SubjectTypeName));
                SelectCommand.CommandText = "pICAS_Subjects_SelectAll_ByParentID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetSubjectListByFaculty(int FacultyID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@StaffID", SqlDbType.Int,FacultyID));                
                SelectCommand.CommandText = "pICAS_Subjects_SelectAll_ByFacultyID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetSubjectListByCourse(int CourseID, int StreamID, string searchText = null, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, StreamID));
                SelectCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, CourseID));
                SelectCommand.CommandText = "pICAS_Subjects_SelectAllByCourse";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetSubjectListByCourseStreamClass(Subjects ObjSubjects, string searchText = null, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.VarChar, ObjSubjects.StreamID));
                SelectCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.VarChar, ObjSubjects.QualID));
                SelectCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.VarChar,ObjSubjects.ClassID));
                SelectCommand.CommandText = "pICAS_Subjects_SelectAllBy_CourseStream_Class";
                return ExecuteGetDataTable(SelectCommand);
            }
        } 
        #endregion
        public DataTable GetSubjectAllByStream(int StreamID, int CourseID, string SubjectTypeName, string searchText = null, bool showDeleted = false)
        {
            try
            {
                SqlCommand GetSubjectcommand = new SqlCommand();
                GetSubjectcommand.CommandType = CommandType.StoredProcedure;
                GetSubjectcommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, StreamID));
                GetSubjectcommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, CourseID));
                //GetSubjectcommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.Int, ClassID));
                GetSubjectcommand.Parameters.Add(GetParameter("@SubjectTypeName", SqlDbType.VarChar, SubjectTypeName));
                GetSubjectcommand.CommandText = "iCAS_Subjects_SelectAll_ByStreamID";
                return ExecuteGetDataTable(GetSubjectcommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public int InsertSubjects(Subjects theSubjects)
        {
            int ReturnValueQuals = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueQuals)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@SubjectName", SqlDbType.VarChar, theSubjects.SubjectName));
                InsertCommand.Parameters.Add(GetParameter("@SubjectTypeID", SqlDbType.Int, theSubjects.SubjectTypeID));
                InsertCommand.Parameters.Add(GetParameter("@SubjectTypeName", SqlDbType.VarChar, theSubjects.SubjectTypeName));
                InsertCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theSubjects.QualID));             
                InsertCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.Int, theSubjects.ClassID));
                InsertCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theSubjects.StreamID));

                InsertCommand.Parameters.Add(GetParameter("@isMain", SqlDbType.VarChar, theSubjects.isMain));
                InsertCommand.Parameters.Add(GetParameter("@isParent", SqlDbType.VarChar, theSubjects.isParent));
                InsertCommand.Parameters.Add(GetParameter("@isRoot", SqlDbType.VarChar, theSubjects.isRoot));
                InsertCommand.Parameters.Add(GetParameter("@ParentID", SqlDbType.VarChar, theSubjects.ParentID));

                InsertCommand.Parameters.Add(GetParameter("@SubjectFullMark", SqlDbType.Int, theSubjects.SubjectFullMark));
                InsertCommand.Parameters.Add(GetParameter("@StaffID", SqlDbType.Int, theSubjects.StaffID));
                InsertCommand.Parameters.Add(GetParameter("@SubjectPracticalFlag", SqlDbType.Bit, theSubjects.SubjectPracticalFlag));
                InsertCommand.Parameters.Add(GetParameter("@SubjectPracticalMark", SqlDbType.VarChar, theSubjects.SubjectPracticalMark));
                InsertCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theSubjects.SessionID));                      
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));                
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int,8));
                InsertCommand.CommandText = "pICAS_Subjects_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValueQuals = int.Parse(InsertCommand.Parameters[0].Value.ToString());
            }
            return ReturnValueQuals;
        }
        public int UpdateSubjects(Subjects theSubjects)
        {
            int ReturnValueQuals = 0;
            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueQuals)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@SubjectName", SqlDbType.VarChar, theSubjects.SubjectName));
                UpdateCommand.Parameters.Add(GetParameter("@SubjectTypeID", SqlDbType.Int, theSubjects.SubjectTypeID));
                UpdateCommand.Parameters.Add(GetParameter("@SubjectTypeName", SqlDbType.VarChar, theSubjects.SubjectTypeName));
                UpdateCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theSubjects.QualID));
                UpdateCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.VarChar, theSubjects.ClassID));
                UpdateCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theSubjects.StreamID));
                UpdateCommand.Parameters.Add(GetParameter("@SubjectFullMark", SqlDbType.VarChar, theSubjects.SubjectFullMark));
                UpdateCommand.Parameters.Add(GetParameter("@StaffID", SqlDbType.VarChar, theSubjects.StaffID));
                UpdateCommand.Parameters.Add(GetParameter("@SubjectPracticalFlag", SqlDbType.VarChar, theSubjects.SubjectPracticalFlag));
                UpdateCommand.Parameters.Add(GetParameter("@SubjectPracticalMark", SqlDbType.VarChar, theSubjects.SubjectPracticalMark));
                UpdateCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theSubjects.SessionID));                           
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 23));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));
                UpdateCommand.CommandText = "iCAS_SubjectNew_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValueQuals = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
            }
            return ReturnValueQuals;
        }
    }
}
