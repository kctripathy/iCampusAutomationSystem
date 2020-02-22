using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
   public partial  class BankBranchDataAccess : AbstractData_SQLClient
    {
        #region Declaration
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static BankBranchDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static BankBranchDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BankBranchDataAccess();
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

       public DataTable GetAllBankBranch(string searchText)
       {
           SqlCommand SelectCommand = new SqlCommand();

           SelectCommand.CommandType = CommandType.StoredProcedure;
           SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
           SelectCommand.CommandText = "pADM_BankBranches_SelectAll";

           return ExecuteGetDataTable(SelectCommand);
       }

       public DataRow GetBankBranchesByBranchId(int BankBranchID)
       {
           SqlCommand SelectCommand = new SqlCommand();

           SelectCommand.CommandType = CommandType.StoredProcedure;
           SelectCommand.Parameters.Add(GetParameter("@BankBranchID", SqlDbType.Int, BankBranchID));
           SelectCommand.CommandText = "pADM_BankBranches_SelectByBankBranchID";

           return ExecuteGetDataRow(SelectCommand);
       }

       public DataTable GetAllBankBranchByBankID(int BankID)
       {
           SqlCommand SelectCommand = new SqlCommand();

           SelectCommand.CommandType = CommandType.StoredProcedure;
           SelectCommand.Parameters.Add(GetParameter("@BankID", SqlDbType.Int, BankID));
           SelectCommand.CommandText = "pADM_BankBranches_SelectByBankID";

           return ExecuteGetDataTable(SelectCommand);
       }

       public int InsertBankBranch(BankBranch theBankBranch)
       {
           int ReturnValue = 0;

           SqlCommand InsertCommand = new SqlCommand();

           InsertCommand.CommandType = CommandType.StoredProcedure;

           InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
           InsertCommand.Parameters.Add(GetParameter("@BranchName", SqlDbType.VarChar, theBankBranch.BranchName));
           InsertCommand.Parameters.Add(GetParameter("@BankID", SqlDbType.Int, theBankBranch.BankID));

            InsertCommand.Parameters.Add(GetParameter("@BranchAddress", SqlDbType.VarChar, theBankBranch.BranchAddress));
            InsertCommand.Parameters.Add(GetParameter("@CityOrTown", SqlDbType.VarChar, theBankBranch.CityOrTown));
            InsertCommand.Parameters.Add(GetParameter("@DistrictID", SqlDbType.Int, theBankBranch.DistrictID));
            InsertCommand.Parameters.Add(GetParameter("@PinCode", SqlDbType.VarChar, theBankBranch.PinCode));

           InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

           InsertCommand.CommandText = "pADM_BankBranches_Insert";

           ExecuteStoredProcedure(InsertCommand);
           ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

           return ReturnValue;
       }

       public int UpdateBankBranch(BankBranch theBankBranch)
       {
           int ReturnValue = 0;

           SqlCommand UpdateCommand = new SqlCommand();

           UpdateCommand.CommandType = CommandType.StoredProcedure;

           UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
           UpdateCommand.Parameters.Add(GetParameter("@BankBranchID", SqlDbType.Int, theBankBranch.BankBranchID));
           UpdateCommand.Parameters.Add(GetParameter("@BranchName", SqlDbType.VarChar, theBankBranch.BranchName));
           UpdateCommand.Parameters.Add(GetParameter("@BankID", SqlDbType.Int, theBankBranch.BankID));

           UpdateCommand.Parameters.Add(GetParameter("@BranchAddress", SqlDbType.VarChar, theBankBranch.BranchAddress));
           UpdateCommand.Parameters.Add(GetParameter("@CityOrTown", SqlDbType.VarChar, theBankBranch.CityOrTown));
           UpdateCommand.Parameters.Add(GetParameter("@DistrictID", SqlDbType.Int, theBankBranch.DistrictID));
           UpdateCommand.Parameters.Add(GetParameter("@PinCode", SqlDbType.VarChar, theBankBranch.PinCode));

           UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

           UpdateCommand.CommandText = "pADM_BankBranches_Update";

           ExecuteStoredProcedure(UpdateCommand);
           ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

           return ReturnValue;
       }

       public int DeleteBankBranch(BankBranch theBankBranch)
       {
           int ReturnValue = 0;

           SqlCommand DeleteCommand = new SqlCommand();

           DeleteCommand.CommandType = CommandType.StoredProcedure;
           DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
           DeleteCommand.Parameters.Add(GetParameter("@BankBranchID", SqlDbType.Int, theBankBranch.BankBranchID));
           DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
           DeleteCommand.CommandText = "pADM_BankBranches_Delete";

           ExecuteStoredProcedure(DeleteCommand);
           ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

           return ReturnValue;
       }

        #endregion
    }
}
