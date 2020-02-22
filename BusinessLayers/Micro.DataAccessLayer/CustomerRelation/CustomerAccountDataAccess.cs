using System;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
	public partial class CustomerAccountDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static CustomerAccountDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static CustomerAccountDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new CustomerAccountDataAccess();
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
		public DataTable GetCustomerAccountList(bool allOffices = false, bool showDeleted = false)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
				SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
				SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pCRM_CustomerAccounts_SelectAll";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable GetDiscontinuedCustomerAccountList(DateTime transactionDate, bool allOffices = false)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@TodaysDate", SqlDbType.DateTime, transactionDate));
				SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
				SelectCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pCRM_CustomerAccounts_SelectAllDiscontinued";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

        public DataTable GetCustomerAccountCertificateList(bool showInOneTimeCertificate = true)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ShowInOneTimeCertificates", SqlDbType.Bit, showInOneTimeCertificate));
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_CustomerAccounts_SelectCertificates";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetCustomerAccountByID(int CustomerAccountID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, CustomerAccountID));
				SelectCommand.CommandText = "pCRM_CustomerAccounts_SelectByCustomerAccountID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public DataRow GetCustomerAccountByDCAccountId(int DCAccountID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@DCAccountID", SqlDbType.Int, DCAccountID));
				SelectCommand.CommandText = "pCRM_CustomerAccounts_SelectByDCAccountID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public DataRow GetPayByCompany(int policyTypeID, decimal installmentAmount, string policyMode,int customerAge=0)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@PolicyTypeID", SqlDbType.Int, policyTypeID));
				SelectCommand.Parameters.Add(GetParameter("@InstallmentAmount", SqlDbType.Decimal, installmentAmount));
				SelectCommand.Parameters.Add(GetParameter("@PolicyMode", SqlDbType.VarChar, policyMode));
                SelectCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, customerAge));
				SelectCommand.CommandText = "pCRM_CustomerAccounts_SelectPayByCompany";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

        public DataTable GetCustomerAccountListByOfficeIDs(bool allOffices, string officeIDs)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
				SelectCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.VarChar, officeIDs));
				SelectCommand.CommandText = "pRPT_CustomerAccounts_SelectByOfficeID";
				return ExecuteGetDataTable(SelectCommand);
			}
		}

        public DataTable GetEligibleCustomerAccountListByCustomerID(int customerID, bool isProcessingApproval = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, customerID));
                SelectCommand.Parameters.Add(GetParameter("@IsProcessingApproval", SqlDbType.Bit, isProcessingApproval));
                SelectCommand.CommandText = "pCRM_CustomerAccounts_SelectMediclaimEligibility";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetContinuedCustomerAccountListByCustomerID(int customerID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, customerID));
                SelectCommand.CommandText = "pCRM_CustomerAccounts_SelectContinuedByCustomerID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

		public int InsertCustomerAccount(CustomerAccount theCustomerAccount, CustomerAccountReceipt theCustomerAccountReceipt)
		{
			int ReturnValue = 0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, theCustomerAccount.CustomerID));
				InsertCommand.Parameters.Add(GetParameter("@IsJointApplication", SqlDbType.Bit, theCustomerAccount.IsJointApplication));
				InsertCommand.Parameters.Add(GetParameter("@ApplicationFormNumber", SqlDbType.VarChar, theCustomerAccount.ApplicationFormNumber));
				InsertCommand.Parameters.Add(GetParameter("@ApplicationDate", SqlDbType.VarChar, theCustomerAccount.ApplicationDate));
				InsertCommand.Parameters.Add(GetParameter("@SecondApplicantName", SqlDbType.VarChar, theCustomerAccount.SecondApplicantName));
				InsertCommand.Parameters.Add(GetParameter("@SecondApplicantAge", SqlDbType.Int, theCustomerAccount.SecondApplicantAge));
				InsertCommand.Parameters.Add(GetParameter("@SecondApplicantSignature", SqlDbType.VarBinary, theCustomerAccount.SecondApplicantSignature));
				InsertCommand.Parameters.Add(GetParameter("@SecondApplicantPANGIR", SqlDbType.VarChar, theCustomerAccount.SecondApplicantPANGIR));
				InsertCommand.Parameters.Add(GetParameter("@ThirdApplicantName", SqlDbType.VarChar, theCustomerAccount.ThirdApplicantName));
				InsertCommand.Parameters.Add(GetParameter("@ThirdApplicantAge", SqlDbType.Int, theCustomerAccount.ThirdApplicantAge));
				InsertCommand.Parameters.Add(GetParameter("@ThirdApplicantSignature", SqlDbType.VarBinary, theCustomerAccount.ThirdApplicantSignature));
				InsertCommand.Parameters.Add(GetParameter("@ThirdApplicantPANGIR", SqlDbType.VarChar, theCustomerAccount.ThirdApplicantPANGIR));
				InsertCommand.Parameters.Add(GetParameter("@NomineeName", SqlDbType.VarChar, theCustomerAccount.NomineeName));
				InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_TownOrCity", SqlDbType.VarChar, theCustomerAccount.Nominee_Permanent_TownOrCity));
				InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_Landmark", SqlDbType.VarChar, theCustomerAccount.Nominee_Permanent_Landmark));
				InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_PinCode", SqlDbType.VarChar, theCustomerAccount.Nominee_Permanent_PinCode));
				InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_DistrictID", SqlDbType.Int, theCustomerAccount.Nominee_Permanent_DistrictID));
				InsertCommand.Parameters.Add(GetParameter("@NomineeRelationship", SqlDbType.VarChar, theCustomerAccount.NomineeRelationship));
				InsertCommand.Parameters.Add(GetParameter("@NomineeAge", SqlDbType.Int, theCustomerAccount.NomineeAge));
				InsertCommand.Parameters.Add(GetParameter("@PolicyTypeID", SqlDbType.Int, theCustomerAccount.PolicyTypeID));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentMode", SqlDbType.VarChar, theCustomerAccount.InstallmentMode));
				InsertCommand.Parameters.Add(GetParameter("@TermInMonths", SqlDbType.Int, theCustomerAccount.TermInMonths));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentAmount", SqlDbType.Decimal, theCustomerAccount.InstallmentAmount));
				InsertCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, theCustomerAccount.FieldForceID));
				InsertCommand.Parameters.Add(GetParameter("@FieldForceCode", SqlDbType.VarChar, theCustomerAccount.FieldForceCode));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentAmountPayable", SqlDbType.Decimal, theCustomerAccountReceipt.InstallmentAmountPayable));
				InsertCommand.Parameters.Add(GetParameter("@AdmissionOrFineAmount", SqlDbType.Decimal, theCustomerAccountReceipt.AdmissionOrFineAmount));
				InsertCommand.Parameters.Add(GetParameter("@RebateAmount", SqlDbType.Decimal, theCustomerAccountReceipt.RebateAmount));
				InsertCommand.Parameters.Add(GetParameter("@PaymentMode", SqlDbType.VarChar, theCustomerAccountReceipt.PaymentMode));
				InsertCommand.Parameters.Add(GetParameter("@PaymentReference", SqlDbType.VarChar, theCustomerAccountReceipt.PaymentReference));
				InsertCommand.Parameters.Add(GetParameter("@ScrollID", SqlDbType.Int, theCustomerAccountReceipt.ScrollID));
				InsertCommand.Parameters.Add(GetParameter("@NumberOfInstallmentsToBePaid", SqlDbType.Int, theCustomerAccount.NumberOfInstallmentsToBePaid));
				InsertCommand.Parameters.Add(GetParameter("@DueDateOfLastPayment", SqlDbType.VarChar, theCustomerAccount.DueDateOfLastPayment));
				InsertCommand.Parameters.Add(GetParameter("@DueDateOfMaturity", SqlDbType.VarChar, theCustomerAccount.DueDateOfMaturity));
				InsertCommand.Parameters.Add(GetParameter("@PayToCompany", SqlDbType.Decimal, theCustomerAccount.PayToCompany));
				InsertCommand.Parameters.Add(GetParameter("@GuaranteedDividend", SqlDbType.Decimal, theCustomerAccount.GuaranteedDividend));
				InsertCommand.Parameters.Add(GetParameter("@BonusAmount", SqlDbType.Decimal, theCustomerAccount.BonusAmount));
				InsertCommand.Parameters.Add(GetParameter("@PayByCompany", SqlDbType.Decimal, theCustomerAccount.PayByCompany));
				InsertCommand.Parameters.Add(GetParameter("@MoneyBackPayable", SqlDbType.Decimal, theCustomerAccount.MoneybackPayable));
				InsertCommand.Parameters.Add(GetParameter("@DCAccountID", SqlDbType.Int, theCustomerAccount.DCAccountID));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentAmountPaid", SqlDbType.Decimal, theCustomerAccountReceipt.InstallmentAmountPaid));
				InsertCommand.Parameters.Add(GetParameter("@DueDateOfNextInstallment", SqlDbType.VarChar, theCustomerAccountReceipt.DueDateOfNextInstallment));
				InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pCRM_CustomerAccounts_Insert";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

        public int UpdateCustomerAccount(CustomerAccount theCustomerAccount)
		{
			return 0;
		}

        public int DeleteCustomerAccount(CustomerAccount theCustomerAccount)
		{
			return 0;
		}
		#endregion
	}
}
