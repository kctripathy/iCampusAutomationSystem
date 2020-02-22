using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class FieldForceProfileDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static FieldForceProfileDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static FieldForceProfileDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FieldForceProfileDataAccess();
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
		public DataTable GetFieldForceProfileList()
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.CommandText = "pCRM_FieldForceProfiles_SelectAll";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataRow GetFieldForceProfileByID(int fieldForceProfileID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@fieldForceProfileId", SqlDbType.Int, fieldForceProfileID));
				SelectCommand.CommandText = "pCRM_FieldForceProfiles_SelectByFieldForceProfileID";
				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public DataTable GetFieldForceProfileByFieldForceID(int fieldForceID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, fieldForceID));
				SelectCommand.CommandText = "pCRM_FieldForceProfiles_SelectByFieldForceID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

        public int InsertFieldForceProfile(FieldForceProfile theFieldForceProfile)
		{
			int ReturnValue = 0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, theFieldForceProfile.FieldForceID));

                InsertCommand.Parameters.Add(GetParameter("SettingKeyName", SqlDbType.VarChar, theFieldForceProfile.SettingKeyName));
                InsertCommand.Parameters.Add(GetParameter("SettingKeyDescription", SqlDbType.VarChar, theFieldForceProfile.SettingKeyDescription));
                InsertCommand.Parameters.Add(GetParameter("SettingKeyValue", SqlDbType.VarBinary, theFieldForceProfile.SettingKeyValue));
                InsertCommand.Parameters.Add(GetParameter("SettingKeyReference", SqlDbType.VarChar, theFieldForceProfile.SettingKeyReference));
                
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_FieldForceProfiles_Insert";

				ExecuteStoredProcedure(InsertCommand);
				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
			}

			return ReturnValue;
		}

        public int UpdateFieldForceProfile(FieldForceProfile theFieldForceProfile)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@FieldForceProfileID", SqlDbType.Int, theFieldForceProfile.FieldForceProfileID));
                UpdateCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, theFieldForceProfile.FieldForceID));

                UpdateCommand.Parameters.Add(GetParameter("SettingKeyName", SqlDbType.VarChar, theFieldForceProfile.SettingKeyName));
                UpdateCommand.Parameters.Add(GetParameter("SettingKeyDescription", SqlDbType.VarChar, theFieldForceProfile.SettingKeyDescription));
                UpdateCommand.Parameters.Add(GetParameter("SettingKeyValue", SqlDbType.VarBinary, theFieldForceProfile.SettingKeyValue));
                UpdateCommand.Parameters.Add(GetParameter("SettingKeyReference", SqlDbType.VarChar, theFieldForceProfile.SettingKeyReference));

                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_FieldForceProfiles_Update";

                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
            }

            return ReturnValue;
        }

        public int DeleteFieldForceProfile(FieldForceProfile theFieldForceProfile)
        {
            int ReturnValue = 0;

            SqlCommand DeleteCommand = new SqlCommand();

            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            DeleteCommand.Parameters.Add(GetParameter("@FieldForceProfileID", SqlDbType.Int, theFieldForceProfile.FieldForceProfileID));
            DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            DeleteCommand.CommandText = "pCRM_FieldForceProfiles_Delete";

            ExecuteStoredProcedure(DeleteCommand);
            ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }
        #endregion
    }
}
