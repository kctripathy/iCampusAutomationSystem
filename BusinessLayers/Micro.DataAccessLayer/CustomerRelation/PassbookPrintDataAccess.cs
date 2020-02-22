using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
	public partial class PassbookPrintDataAccess: AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static PassbookPrintDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static PassbookPrintDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new PassbookPrintDataAccess();
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
        public int InsertPassbookPrint(Passbook thePassbook, PassbookPrint thePassbookPrint)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@PassbookID", SqlDbType.Int, thePassbookPrint.PassbookID));
                InsertCommand.Parameters.Add(GetParameter("@PassbookCode", SqlDbType.VarChar, thePassbookPrint.PassbookCode));
				InsertCommand.Parameters.Add(GetParameter("@PassbookType", SqlDbType.VarChar, thePassbook.PassBookType));
				InsertCommand.Parameters.Add(GetParameter("@PassbookTypeReferenceID", SqlDbType.Int, thePassbook.PassbookTypeReferenceID));
				InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, thePassbook.CustomerAccountID));
                InsertCommand.Parameters.Add(GetParameter("@PassbookIssueDate", SqlDbType.VarChar, thePassbook.PassbookIssueDate));
                InsertCommand.Parameters.Add(GetParameter("@CoverPageState", SqlDbType.Bit, thePassbook.CoverPageState));
                InsertCommand.Parameters.Add(GetParameter("@FirstPageState", SqlDbType.Bit, thePassbook.FirstPageState));
                InsertCommand.Parameters.Add(GetParameter("@PrintPosition", SqlDbType.Int, thePassbook.PrintPosition));
                InsertCommand.Parameters.Add(GetParameter("@PassbookPage", SqlDbType.VarChar, thePassbookPrint.PassbookPage));
                InsertCommand.Parameters.Add(GetParameter("@PassbookPrintDate", SqlDbType.VarChar, thePassbookPrint.PassbookPrintDate));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_PassbookPrints_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }//TODO :Requriad  @PassbookIssueDate, @DateModified, @PassbookPrintDate
        }
        #endregion
    }
}
