using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class PaymentsMaturityDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PaymentsMaturityDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PaymentsMaturityDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaymentsMaturityDataAccess();
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
        public DataTable GetMaturityPaymentList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_Maturities_SelectAll";
                
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertPaymentMaturity(PaymentsMaturity thePaymentsMaturity)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, thePaymentsMaturity.CustomerAccountID));
                InsertCommand.Parameters.Add(GetParameter("@MaturityDate", SqlDbType.VarChar, thePaymentsMaturity.MaturityDate));
                InsertCommand.Parameters.Add(GetParameter("@MaturityPaymentDate", SqlDbType.VarChar, thePaymentsMaturity.MaturityPaymentDate));
                InsertCommand.Parameters.Add(GetParameter("@MaturityPrincipalPayable", SqlDbType.Decimal, thePaymentsMaturity.MaturityPrincipalPayable));
                InsertCommand.Parameters.Add(GetParameter("@MaturityPrincipalPaid", SqlDbType.Decimal, thePaymentsMaturity.MaturityPrincipalPaid));
                InsertCommand.Parameters.Add(GetParameter("@MaturityInterestPayable", SqlDbType.Decimal, thePaymentsMaturity.MaturityInterestPayable));
                InsertCommand.Parameters.Add(GetParameter("@MaturityInterestPaid", SqlDbType.Decimal, thePaymentsMaturity.MaturityInterestPaid));
                InsertCommand.Parameters.Add(GetParameter("@MaturityBonusPayable", SqlDbType.Decimal, thePaymentsMaturity.MaturityBonusPayable));
                InsertCommand.Parameters.Add(GetParameter("@MaturityBonusPaid", SqlDbType.Decimal, thePaymentsMaturity.MaturityBonusPaid));
                InsertCommand.Parameters.Add(GetParameter("@MaturityPrincipalDeductions", SqlDbType.Decimal, thePaymentsMaturity.MaturityPrincipalDeductions));
                InsertCommand.Parameters.Add(GetParameter("@MaturityPrincipalDeductionsRemarks", SqlDbType.VarChar, thePaymentsMaturity.MaturityPrincipalDeductionsRemarks));
                InsertCommand.Parameters.Add(GetParameter("@MaturityTotalPayable", SqlDbType.Decimal, thePaymentsMaturity.MaturityTotalPayable));
                InsertCommand.Parameters.Add(GetParameter("@MaturityTotalPaid", SqlDbType.Decimal, thePaymentsMaturity.MaturityTotalPaid));
				InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_Maturities_Insert";
                
                ExecuteStoredProcedure(InsertCommand);
                
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                
                return ReturnValue;
            }
        }
        #endregion
    }
}
