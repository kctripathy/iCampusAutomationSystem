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
    public partial class SubjectTypeDataAccess : AbstractData_SQLClient
    {
        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static SubjectTypeDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static SubjectTypeDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SubjectTypeDataAccess();
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

        public DataTable GetSubjectTypeListByCourseStream(int CourseID, string StreamID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.VarChar, StreamID));
                SelectCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, CourseID));
                SelectCommand.CommandText = "pICAS_SubjectType_SelectAllByCourseStream";

                return ExecuteGetDataTable(SelectCommand);
            }
        }       
       #endregion
        
        //public int InsertSubjects(Subjects theSubjects)
        //{
        //    int ReturnValueQuals = 0;
        //    using (SqlCommand InsertCommand = new SqlCommand())
        //    {
        //        InsertCommand.CommandType = CommandType.StoredProcedure;
        //        InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueQuals)).Direction = ParameterDirection.Output;
        //        InsertCommand.Parameters.Add(GetParameter("@SubjectName", SqlDbType.VarChar, theSubjects.SubjectName));
        //        InsertCommand.Parameters.Add(GetParameter("@SubjectTypeID", SqlDbType.VarChar, theSubjects.SubjectTypeID));
        //        InsertCommand.Parameters.Add(GetParameter("@SubjectTypeName", SqlDbType.VarChar, theSubjects.SubjectTypeName));
        //        InsertCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theSubjects.QualID));             
        //        InsertCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.VarChar, theSubjects.ClassID));
        //        InsertCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.VarChar, theSubjects.StreamID));
        //        InsertCommand.Parameters.Add(GetParameter("@SubjectFullMark", SqlDbType.VarChar, theSubjects.SubjectFullMark));
        //        InsertCommand.Parameters.Add(GetParameter("@SubjectPassMark", SqlDbType.VarChar, theSubjects.SubjectPassMark));
        //        InsertCommand.Parameters.Add(GetParameter("@SubjectPracticalFlag", SqlDbType.VarChar, theSubjects.SubjectPracticalFlag));
        //        InsertCommand.Parameters.Add(GetParameter("@SubjectPracticalMark", SqlDbType.VarChar, theSubjects.SubjectPracticalMark));
        //        InsertCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.VarChar, theSubjects.SessionID));                      
        //        InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 23));                
        //        InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int,8));
        //        InsertCommand.CommandText = "pICAS_Subjects_Insert";
        //        ExecuteStoredProcedure(InsertCommand);
        //        ReturnValueQuals = int.Parse(InsertCommand.Parameters[0].Value.ToString());
        //    }
        //    return ReturnValueQuals;
        //}
        //public int UpdateSubjects(Subjects theSubjects)
        //{
        //    int ReturnValueQuals = 0;
        //    using (SqlCommand UpdateCommand = new SqlCommand())
        //    {
        //        UpdateCommand.CommandType = CommandType.StoredProcedure;
        //        UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueQuals)).Direction = ParameterDirection.Output;
        //        UpdateCommand.Parameters.Add(GetParameter("@SubjectName", SqlDbType.VarChar, theSubjects.SubjectName));
        //        UpdateCommand.Parameters.Add(GetParameter("@SubjectTypeID", SqlDbType.Int, theSubjects.SubjectTypeID));
        //        UpdateCommand.Parameters.Add(GetParameter("@SubjectTypeName", SqlDbType.VarChar, theSubjects.SubjectTypeName));
        //        UpdateCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theSubjects.QualID));
        //        UpdateCommand.Parameters.Add(GetParameter("@ClassID", SqlDbType.VarChar, theSubjects.ClassID));
        //        UpdateCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theSubjects.StreamID));
        //        UpdateCommand.Parameters.Add(GetParameter("@SubjectFullMark", SqlDbType.VarChar, theSubjects.SubjectFullMark));
        //        UpdateCommand.Parameters.Add(GetParameter("@SubjectPassMark", SqlDbType.VarChar, theSubjects.SubjectPassMark));
        //        UpdateCommand.Parameters.Add(GetParameter("@SubjectPracticalFlag", SqlDbType.VarChar, theSubjects.SubjectPracticalFlag));
        //        UpdateCommand.Parameters.Add(GetParameter("@SubjectPracticalMark", SqlDbType.VarChar, theSubjects.SubjectPracticalMark));
        //        UpdateCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, theSubjects.SessionID));                           
        //        UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 23));
        //        UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));
        //        UpdateCommand.CommandText = "iCAS_SubjectNew_Update";
        //        ExecuteStoredProcedure(UpdateCommand);
        //        ReturnValueQuals = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
        //    }
        //    return ReturnValueQuals;
        //}
    }
}
