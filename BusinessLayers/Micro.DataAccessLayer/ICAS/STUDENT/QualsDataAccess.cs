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
   public partial class QualsDataAccess :AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static QualsDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static QualsDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QualsDataAccess();
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
        public DataTable GetQualsList()
       {
           using (SqlCommand SelectCommand = new SqlCommand())
           {
               SelectCommand.CommandType = CommandType.StoredProcedure;

               SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, ""));               
               SelectCommand.CommandText = "piCAS_Qualifications_SelectAll";
               return ExecuteGetDataTable(SelectCommand);
           }
       }
        public int InsertQuals(Qualification theQualifications)
        {
            int ReturnValueQuals = 0;          
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueQuals)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@QualCode", SqlDbType.VarChar, theQualifications.QualCode));            
                InsertCommand.Parameters.Add(GetParameter("@QualType", SqlDbType.VarChar, theQualifications.QualType));
                InsertCommand.Parameters.Add(GetParameter("@QualName", SqlDbType.VarChar, theQualifications.QualName));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int,1));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int,23));
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int,8));

                InsertCommand.CommandText = "iCAS_Quals_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValueQuals = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            }
            return ReturnValueQuals;
        }

        #endregion
    }
}
