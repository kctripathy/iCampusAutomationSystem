using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;
using Micro.Commons;

namespace Micro.DataAccessLayer.CustomerRelation
{
	public partial class PassbookDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static PassbookDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static PassbookDataAccess GetInstance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new PassbookDataAccess();
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
		public DataRow GetPassbooksByCustomerAccountID(int CustomerAccountID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@PassbookType", SqlDbType.VarChar, MicroEnums.PassbookType.RecurringDeposit.GetStringValue()));
				SelectCommand.Parameters.Add(GetParameter("@PassbookTypeReferenceID", SqlDbType.Int, CustomerAccountID));
				SelectCommand.CommandText = "pCRM_Passbooks_SelectByPassbookTypeReferenceID";// "pCRM_Passbooks_SelectByCustomerAccountID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public DataRow GetPassbookByTypeReferenceID(string passbookType, int passbookTypeReferenceID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@PassbookType", SqlDbType.VarChar, passbookType));
				SelectCommand.Parameters.Add(GetParameter("@PassbookTypeReferenceID", SqlDbType.Int, passbookTypeReferenceID));
				SelectCommand.CommandText = "pCRM_Passbooks_SelectByPassbookTypeReferenceID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public int InsertPassbook(Passbook thePassbook, PassbookPrint thePassbookPrint)
		{
			int ReturnValue = 0;

			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@PassbookType", SqlDbType.VarChar, thePassbook.PassBookType));
				InsertCommand.Parameters.Add(GetParameter("@PassbookTypeReferenceID", SqlDbType.Int, thePassbook.CustomerAccountID));
				InsertCommand.Parameters.Add(GetParameter("@PassbookIssueDate", SqlDbType.VarChar, thePassbook.PassbookIssueDate));
				InsertCommand.Parameters.Add(GetParameter("@CoverPageState", SqlDbType.Bit, thePassbook.CoverPageState));
				InsertCommand.Parameters.Add(GetParameter("@FirstPageState", SqlDbType.Bit, thePassbook.FirstPageState));
				InsertCommand.Parameters.Add(GetParameter("@PrintPosition", SqlDbType.Int, thePassbook.PrintPosition));
				InsertCommand.Parameters.Add(GetParameter("@PassbookPage", SqlDbType.VarChar, thePassbookPrint.PassbookPage));
				InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pCRM_Passbooks_Insert";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}//TODO :Requriad  @PassbookIssueDate
		#endregion
	}
}
