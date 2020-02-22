using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class CrmSettingDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CrmSettingDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CrmSettingDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CrmSettingDataAccess();
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

        #region Methods & Implimentation
        public DataTable GetCrmSettingList(string SearchText,bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, SearchText));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "pADM_Settings_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetSettingKeyList(string searchText)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SelectCommand.CommandText = "pADM_SettingKeys_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetCrmSettingById(int SettingID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SettingID", SqlDbType.Int, SettingID));
                SelectCommand.CommandText = "pADM_Settings_SelectBySettingID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertSetting(CrmSetting TheCrmSetting)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@SettingKeyName", SqlDbType.VarChar, TheCrmSetting.SettingKeyName));
                InsertCommand.Parameters.Add(GetParameter("@SettingKeyModuleID", SqlDbType.Int, TheCrmSetting.SettingKeyModuleID));
                InsertCommand.Parameters.Add(GetParameter("@SettingDataType", SqlDbType.VarChar, TheCrmSetting.SettingDataType));
                InsertCommand.Parameters.Add(GetParameter("@SettingValue", SqlDbType.VarChar, TheCrmSetting.SettingValue));
                InsertCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, TheCrmSetting.EffectiveDateFrom));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pADM_Settings_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int UpdateSetting(CrmSetting theCrmSetting)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@SettingID", SqlDbType.Int, theCrmSetting.SettingID));
                UpdateCommand.Parameters.Add(GetParameter("@SettingKeyID", SqlDbType.Int, theCrmSetting.SettingKeyID));
                UpdateCommand.Parameters.Add(GetParameter("@SettingDataType", SqlDbType.VarChar, theCrmSetting.SettingDataType));
                UpdateCommand.Parameters.Add(GetParameter("@SettingValue", SqlDbType.VarChar, theCrmSetting.SettingValue));
                UpdateCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, theCrmSetting.EffectiveDateFrom));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pADM_Settings_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int DeleteSetting(CrmSetting theSetting)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@SettingID", SqlDbType.Int, theSetting.SettingID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pADM_Settings_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
