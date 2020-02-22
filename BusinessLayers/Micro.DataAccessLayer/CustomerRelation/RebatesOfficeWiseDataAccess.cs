using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class RebatesOfficeWiseDataAccess:AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static RebatesOfficeWiseDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static RebatesOfficeWiseDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new RebatesOfficeWiseDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region methods & Implementation

        public DataTable GetRebateOfficeWiseList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_RebatesOfficewise_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetRebatesSelectByOfficeID(bool ShowInOfficewise = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ShowInOfficewise", SqlDbType.Bit, ShowInOfficewise));
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_Rebates_SelectByOfficeID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertOfficeWiseRebates(string RebateIDs, string EffectiveDateFrom)
        {

            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@RebateIDs", SqlDbType.VarChar, RebateIDs));
                InsertCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, EffectiveDateFrom));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_RebatesOfficewise_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int DeleteOfficeWiseRebates(string RebateIDs)
        {

            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@RebateIDs", SqlDbType.VarChar, RebateIDs));
                DeleteCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pCRM_RebatesOfficewise_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion

    }
}
