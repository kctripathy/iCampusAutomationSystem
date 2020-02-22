using System.Data;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.IntegrationLayer.Administration
{
	public partial class TransactionPasswordIntegration
	{
		#region Methods & Implementation
		public static TransactionPassword DataRowToObject(DataRow dr)
		{
			TransactionPassword TheTransactionPassword = new TransactionPassword
			{
				TransactionPasswordID = int.Parse(dr["TransactionPasswordID"].ToString()),
				EmployeeID = int.Parse(dr["EmployeeID"].ToString()),
				TransactionsPassword = dr["TransactionPassword"].ToString(),
				IsActive = bool.Parse(dr["IsActive"].ToString()),
				IsDeleted = bool.Parse(dr["IsDeleted"].ToString())
			};

			return TheTransactionPassword;
		}

		public static TransactionPassword GetTransactionPasswordByEmployeeID(int EmployeeID)
		{
			TransactionPassword TheTransactionPassword;
			DataRow TransactionPasswordDataRow = TransactionPasswordDataAccess.GetInstance.GetTransactionPasswordByEmployeeID(EmployeeID);

			if (TransactionPasswordDataRow != null)
				TheTransactionPassword = DataRowToObject(TransactionPasswordDataRow);
			else
				TheTransactionPassword = new TransactionPassword();

			return TheTransactionPassword;
		}

		public static int InsertTransactionPassword(TransactionPassword theTransactionPassword)
		{
			return TransactionPasswordDataAccess.GetInstance.InsertTransactionPassword(theTransactionPassword);
		}
		#endregion
	}
}
