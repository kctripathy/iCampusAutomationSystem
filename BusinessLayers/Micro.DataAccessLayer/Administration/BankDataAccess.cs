using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
   public partial  class BankDataAccess : AbstractData_SQLClient
   {

       #region Declaration
       #endregion

       #region Code to make this as Singleton Class
       /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static BankDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static BankDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BankDataAccess();
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

       public DataTable GetAllBanks(string searchText)
       {
           SqlCommand SelectCommand = new SqlCommand();

           SelectCommand.CommandType = CommandType.StoredProcedure;
           SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
           SelectCommand.CommandText = "pADM_Banks_SelectAll";

           return ExecuteGetDataTable(SelectCommand);
       }

       public DataRow GetBankByBankId(int BankID)
       {
           SqlCommand SelectCommand = new SqlCommand();

           SelectCommand.CommandType = CommandType.StoredProcedure;
           SelectCommand.Parameters.Add(GetParameter("@BankID", SqlDbType.Int, BankID));
           SelectCommand.CommandText = "pADM_Banks_SelectByBankID";

           return ExecuteGetDataRow(SelectCommand);
       }

       public int InsertBank(Bank theBank)
       {
           int ReturnValue = 0;

           SqlCommand InsertCommand = new SqlCommand();

           InsertCommand.CommandType = CommandType.StoredProcedure;

           InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
           InsertCommand.Parameters.Add(GetParameter("@BankName", SqlDbType.VarChar, theBank.BankName));

           InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

           InsertCommand.CommandText = "pADM_Banks_Insert";

           ExecuteStoredProcedure(InsertCommand);
           ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

           return ReturnValue;
       }

       public int UpdateBank(Bank theBank)
       {
           int ReturnValue = 0;

           SqlCommand UpdateCommand = new SqlCommand();

           UpdateCommand.CommandType = CommandType.StoredProcedure;

           UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
           UpdateCommand.Parameters.Add(GetParameter("@BankID", SqlDbType.Int, theBank.BankID));
           UpdateCommand.Parameters.Add(GetParameter("@BankName", SqlDbType.VarChar, theBank.BankName));
           UpdateCommand.Parameters.Add(GetParameter("@DateModified", SqlDbType.VarChar, theBank.DateModified));
           UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

           UpdateCommand.CommandText = "pADM_Banks_Update";

           ExecuteStoredProcedure(UpdateCommand);
           ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

           return ReturnValue;
       }

       public int DeleteBank(Bank theBank)
       {
           int ReturnValue = 0;

           SqlCommand DeleteCommand = new SqlCommand();

           DeleteCommand.CommandType = CommandType.StoredProcedure;
           DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
           DeleteCommand.Parameters.Add(GetParameter("@BankID", SqlDbType.Int, theBank.BankID));
           DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
           DeleteCommand.CommandText = "pADM_Banks_Delete";

           ExecuteStoredProcedure(DeleteCommand);
           ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

           return ReturnValue;
       }

       #endregion

   }
}
