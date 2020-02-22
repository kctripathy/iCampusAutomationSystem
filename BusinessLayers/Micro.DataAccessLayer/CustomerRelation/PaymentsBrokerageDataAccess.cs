using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class PaymentsBrokerageDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PaymentsBrokerageDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PaymentsBrokerageDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaymentsBrokerageDataAccess();
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

        #region Methods & Implementations
        public DataTable GetBrokeragePaybleDetails(int fieldForceId, string brokerageType)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, fieldForceId));
                SelectCommand.Parameters.Add(GetParameter("@BrokerageType", SqlDbType.VarChar, brokerageType));
                SelectCommand.CommandText = "pCRM_BrokeragePayable_SelectByFieldForceID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int CalculateAndInsertCommissionPayable(PaymentsBrokerage thePaymentsBrokerage)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.ReturnValue;
                InsertCommand.Parameters.Add(GetParameter("@DateFrom", SqlDbType.VarChar, thePaymentsBrokerage.FromDate));
                InsertCommand.Parameters.Add(GetParameter("@DateTo", SqlDbType.VarChar, thePaymentsBrokerage.ToDate));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                //TODO: After @OfficeID is add in sp pCRM_CommissionPayable_Insert uncoment the following Line
                //InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeId));
                InsertCommand.CommandText = "pCRM_CommissionPayable_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                if (ReturnValue == 0)
                    ReturnValue = 1;
                return ReturnValue;
            }
        }

        public int InsertPaymentBrokerage(PaymentsBrokerage thePaymentsBrokerage)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@FromDate", SqlDbType.VarChar, thePaymentsBrokerage.FromDate));
                InsertCommand.Parameters.Add(GetParameter("@ToDate", SqlDbType.VarChar, thePaymentsBrokerage.ToDate));
                InsertCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, thePaymentsBrokerage.FieldForceID));
                InsertCommand.Parameters.Add(GetParameter("@BrokerageAmount", SqlDbType.Decimal, thePaymentsBrokerage.BrokerageAmount));
                InsertCommand.Parameters.Add(GetParameter("@BrokerageType", SqlDbType.VarChar, thePaymentsBrokerage.BrokerageType));
                InsertCommand.Parameters.Add(GetParameter("@PaymentMode", SqlDbType.VarChar, thePaymentsBrokerage.PaymentMode));
                InsertCommand.Parameters.Add(GetParameter("@BankAccountNumber", SqlDbType.VarChar, thePaymentsBrokerage.BankAccountNumber));
                InsertCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, thePaymentsBrokerage.Remarks));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_BrokerageFeeVouchers_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int CalculateAndInsertIncentiveMonthly(int Month,int Year,bool AllOffices=false)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, AllOffices));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@Month", SqlDbType.Int, Month));
                InsertCommand.Parameters.Add(GetParameter("@Year", SqlDbType.Int, Year));
                InsertCommand.CommandText = "pTMPCRM_Incentives_Monthly_201112";
                ExecuteStoredProcedure(InsertCommand);
                //ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                if (ReturnValue == 0)
                    ReturnValue = 1;
                return ReturnValue;
            }

        }

        public int CalculateAndInsertIncentiveYearly(string DateFrom,string DateTo,bool AllOffices = false)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, AllOffices));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@DateFrom", SqlDbType.VarChar,DateFrom));
                InsertCommand.Parameters.Add(GetParameter("@DateTo", SqlDbType.VarChar, DateTo));
                InsertCommand.CommandText = "pTMPCRM_Incentives_201112";
                ExecuteStoredProcedure(InsertCommand);
                //ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                if (ReturnValue == 0)
                    ReturnValue = 1;
                return ReturnValue;
            }

        }
        #endregion
    }
} 
