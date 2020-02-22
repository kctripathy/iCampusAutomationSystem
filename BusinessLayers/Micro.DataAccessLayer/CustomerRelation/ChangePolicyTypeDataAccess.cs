using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class ChangePolicyTypeDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ChangePolicyTypeDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ChangePolicyTypeDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChangePolicyTypeDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Methods & Implementation
        public int UpdatePolicyTypeChange(CustomerAccount theCustomerAccount,CustomerAccountReceipt theCustomerAccountReceipt)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, theCustomerAccount.CustomerAccountID));
                UpdateCommand.Parameters.Add(GetParameter("@PolicyTypeID", SqlDbType.Int, theCustomerAccount.PolicyTypeID));
                UpdateCommand.Parameters.Add(GetParameter("@InstallmentMode", SqlDbType.VarChar, theCustomerAccount.InstallmentMode));
                UpdateCommand.Parameters.Add(GetParameter("@TermInMonths", SqlDbType.Int, theCustomerAccount.TermInMonths));
                UpdateCommand.Parameters.Add(GetParameter("@InstallmentAmount", SqlDbType.Decimal, theCustomerAccount.InstallmentAmount));
                UpdateCommand.Parameters.Add(GetParameter("@NumberOfInstallmentsToBePaid", SqlDbType.Int, theCustomerAccount.NumberOfInstallmentsToBePaid));
                //UpdateCommand.Parameters.Add(GetParameter("@NumberOfInstallmentsPaid", SqlDbType.Int, theCustomerAccount.NumberOfInstallmentsPaid));
                UpdateCommand.Parameters.Add(GetParameter("@DueDateOfLastPayment", SqlDbType.VarChar, theCustomerAccount.DueDateOfLastPayment));
                UpdateCommand.Parameters.Add(GetParameter("@DueDateOfMaturity", SqlDbType.VarChar, theCustomerAccount.DueDateOfMaturity));
                UpdateCommand.Parameters.Add(GetParameter("@PayToCompany", SqlDbType.Decimal, theCustomerAccount.PayToCompany));
                UpdateCommand.Parameters.Add(GetParameter("@GuaranteedDividend", SqlDbType.Decimal, theCustomerAccount.GuaranteedDividend));
                UpdateCommand.Parameters.Add(GetParameter("@BonusAmount", SqlDbType.Decimal, theCustomerAccount.BonusAmount));
                UpdateCommand.Parameters.Add(GetParameter("@PayByCompany", SqlDbType.Decimal, theCustomerAccount.PayByCompany));
                UpdateCommand.Parameters.Add(GetParameter("@MoneyBackPayable", SqlDbType.Decimal, theCustomerAccount.MoneybackPayable));
                //Cancelled/Insert Receipt and Manage Scroll
                UpdateCommand.Parameters.Add(GetParameter("@CancelledReceiptID", SqlDbType.Int, theCustomerAccountReceipt.ReceiptID));
                UpdateCommand.Parameters.Add(GetParameter("@ReceiptSeries", SqlDbType.VarChar, theCustomerAccountReceipt.ReceiptSeries));
                UpdateCommand.Parameters.Add(GetParameter("@ReceiptDate", SqlDbType.VarChar, theCustomerAccountReceipt.ReceiptDate));
                UpdateCommand.Parameters.Add(GetParameter("@InstallmentNumberFrom", SqlDbType.Int, theCustomerAccountReceipt.InstallmentNumberFrom));
                UpdateCommand.Parameters.Add(GetParameter("@InstallmentNumberTo", SqlDbType.Int, theCustomerAccountReceipt.InstallmentNumberTo));
                UpdateCommand.Parameters.Add(GetParameter("@InstallmentAmountPayable", SqlDbType.Decimal, theCustomerAccountReceipt.InstallmentAmountPayable));
                UpdateCommand.Parameters.Add(GetParameter("@InstallmentAmountPaid", SqlDbType.Decimal, theCustomerAccountReceipt.InstallmentAmountPaid));
                UpdateCommand.Parameters.Add(GetParameter("@AdmissionOrFineAmount", SqlDbType.Decimal, theCustomerAccountReceipt.AdmissionOrFineAmount));
                UpdateCommand.Parameters.Add(GetParameter("@RebateAmount", SqlDbType.Decimal, theCustomerAccountReceipt.RebateAmount));
                UpdateCommand.Parameters.Add(GetParameter("@PaymentMode", SqlDbType.VarChar, theCustomerAccountReceipt.PaymentMode));
                UpdateCommand.Parameters.Add(GetParameter("@PaymentReference", SqlDbType.VarChar, theCustomerAccountReceipt.PaymentReference));
                UpdateCommand.Parameters.Add(GetParameter("@DueDateOfNextInstallment", SqlDbType.VarChar, theCustomerAccountReceipt.DueDateOfNextInstallment));
                UpdateCommand.Parameters.Add(GetParameter("@ScrollID", SqlDbType.Int, theCustomerAccountReceipt.ScrollID));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_CustomerAccounts_UpdatePolicyType";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
