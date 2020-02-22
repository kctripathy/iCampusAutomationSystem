using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Micro.Commons;
using System.Data.SqlClient;
using Micro.Objects.ICAS.STUDENT;

namespace Micro.DataAccessLayer.ICAS.STUDENT
{
    public partial class StudentPreQualsDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static StudentPreQualsDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StudentPreQualsDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentPreQualsDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

       

        #endregion

        #region Data Retrive Mathods
        public DataTable GetPreQualsList(int StudentID)
       {
           using (SqlCommand SelectCommand = new SqlCommand())
           {
               SelectCommand.CommandType = CommandType.StoredProcedure;

               SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, ""));
               SelectCommand.Parameters.Add(GetParameter("@StudentID", SqlDbType.Int, StudentID));
               SelectCommand.CommandText = "piCAS_Student_PreQualifications_SelectAll";               
               return ExecuteGetDataTable(SelectCommand);
           }
       }
        public int InsertQuals(StudentPreviousQual thePreQualifications)
        {
            int ReturnValueQuals = 0;           
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueQuals)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@StudentID", SqlDbType.VarChar, thePreQualifications.StudentID));
                InsertCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.VarChar, thePreQualifications.QualID));
                InsertCommand.Parameters.Add(GetParameter("@PassingYear", SqlDbType.VarChar, thePreQualifications.PassingYear));
                InsertCommand.Parameters.Add(GetParameter("@Board", SqlDbType.VarChar, thePreQualifications.Board));
                InsertCommand.Parameters.Add(GetParameter("@Division", SqlDbType.VarChar, thePreQualifications.Division));
                InsertCommand.Parameters.Add(GetParameter("@Percentage", SqlDbType.VarChar, thePreQualifications.Percentage));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.VarChar, thePreQualifications.AddedBy));


                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, thePreQualifications.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.VarChar, thePreQualifications.CompanyID));

                InsertCommand.CommandText = "piCAS_Student_PreQuals_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValueQuals = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            }
            return ReturnValueQuals;
        }

        #endregion
    }
}
