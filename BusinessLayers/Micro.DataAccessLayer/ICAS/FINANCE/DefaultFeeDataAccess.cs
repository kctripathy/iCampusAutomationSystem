using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Micro.Objects.ICAS.FINANCE;
using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.ICAS.FINANCE
{
    public partial class DefaultFeeDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DefaultFeeDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DefaultFeeDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DefaultFeeDataAccess();
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

        public int InsertDefaultAccountFee(DefaultFeeSetup theFeeSetup)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, theFeeSetup.QualID));
                InsertCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, theFeeSetup.StreamID));
                InsertCommand.Parameters.Add(GetParameter("@AccountTypeID", SqlDbType.Int, theFeeSetup.AccountTypeID));
                InsertCommand.Parameters.Add(GetParameter("@AccountGroupID", SqlDbType.Int, theFeeSetup.AccountGroupID));
                InsertCommand.Parameters.Add(GetParameter("@AccountID", SqlDbType.Int, theFeeSetup.AccountID));
                InsertCommand.Parameters.Add(GetParameter("@DefaultFee", SqlDbType.Decimal, theFeeSetup.DefaultFee));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));//TO DO KP
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));
                InsertCommand.CommandText = "pICAS_FIN_DefaultFee_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion

        #region Data Retrive Mathods

        public DataTable GetDefaultFeeList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pICAS_FIN_DefaultFee_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetDefaultFeeListByQual_Stream(int QualID, int StreamID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;              
                SelectCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, QualID));
                SelectCommand.Parameters.Add(GetParameter("@StreamID", SqlDbType.Int, StreamID));
                SelectCommand.CommandText = "pICAS_FIN_DefaultFee_SelectAllByQualStream";
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        #endregion
    }
}
