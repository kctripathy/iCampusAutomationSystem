using Micro.Objects.Administration;
using System.Data.SqlClient;
using System.Data;

namespace Micro.DataAccessLayer.Administration
{
    public partial class StateDataAccess: AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static StateDataAccess instance = new StateDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static StateDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation

        public int InsertState(State theState)
        {
            int NewStateId = 0;
            SqlCommand InsertCommand = new SqlCommand();

            InsertCommand.CommandType = CommandType.StoredProcedure;
            InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, NewStateId)).Direction = ParameterDirection.Output;
            InsertCommand.Parameters.Add(GetParameter("@CountryId", SqlDbType.Int, theState.CountryId));
            InsertCommand.Parameters.Add(GetParameter("@StateName", SqlDbType.VarChar, theState.StateName));
            InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            InsertCommand.CommandText = "pADM_States_Insert";

            ExecuteStoredProcedure(InsertCommand);

            NewStateId = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            return NewStateId;
        }

        public int UpdateState(State theState)
        {
            int RetVal = 0;
            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.Add(GetParameter("@CountryID", SqlDbType.Int, theState.CountryId));
            UpdateCommand.Parameters.Add(GetParameter("@StateID", SqlDbType.Int, theState.StateID));
            UpdateCommand.Parameters.Add(GetParameter("@StateName", SqlDbType.VarChar, theState.StateName));
            UpdateCommand.Parameters.Add(GetParameter("@IsAvailable", SqlDbType.Bit, theState.IsAvailable));
            UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            UpdateCommand.CommandText = "pADM_Countries_Update";

            RetVal = ExecuteStoredProcedureGetID(UpdateCommand);

            return RetVal;
        }

        public int DeleteState(int StateId)
        {
            int RetVal = 0;
            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.Add(GetParameter("@StateID", SqlDbType.Int, StateId));
            UpdateCommand.Parameters.Add(GetParameter("@IsAvailable", SqlDbType.Bit, 0));
            UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            UpdateCommand.CommandText = "pADM_Countries_Update";

            RetVal = ExecuteStoredProcedureGetID(UpdateCommand);

            return RetVal;
        }

        public DataTable GetStateList(System.String searchText = null)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
            SelectCommand.CommandText = "pADM_Countries_SelectAll";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataTable GetAllStatesByCountryId(int countryId)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@CountryId", SqlDbType.Int, countryId));
            SelectCommand.CommandText = "[pADM_States_SelectByCountryId]";

            return ExecuteGetDataTable(SelectCommand);
        }

        #endregion
    }
}
