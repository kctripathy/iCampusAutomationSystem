using System.Data;
using System.Data.SqlClient;
using Micro.Objects.HumanResource;

namespace Micro.DataAccessLayer.HumanResource
{
    public partial class EmployeeProfileDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static EmployeeProfileDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static EmployeeProfileDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EmployeeProfileDataAccess();
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

		public DataTable GetEmployeeProfilesList()
        {
            using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.CommandText = "pHRM_EmployeeProfiles_SelectAll";
				return ExecuteGetDataTable(SelectCommand);
			}
        }

		public DataTable GetEmployeeProfileByEmployeeID(int employeeID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@employeeID", SqlDbType.Int, employeeID));
				SelectCommand.CommandText = "pHRM_EmployeeProfiles_SelectProfileByEmployeeID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}
		
		public DataRow GetEmployeeProfileByID(int employeeProfileID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@employeeProfileID", SqlDbType.Int, employeeProfileID));
				SelectCommand.CommandText = "pHRM_EmployeeProfiles_SelectByEmployeeProfileID";
				return ExecuteGetDataRow(SelectCommand);
			}
		}

        public DataRow GetEmployeeProfileByEmployeeIDandEmployeeProfileID(int EmployeeID, int SettingKeyID)
        {

			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
				SelectCommand.Parameters.Add(GetParameter("@SettingKeyID", SqlDbType.Int, SettingKeyID));
				SelectCommand.CommandText = "pHRM_EmployeeProfiles_SelectProfileByEmployeeIDAndSettingKeyID";

				return ExecuteGetDataRow(SelectCommand);
			}
            
        }
		
		public int InsertEmployeeProfile(EmployeeProfile theEmployeeProfile)
		{
			
				int ReturnValue = 0;
				using (SqlCommand InsertCommand = new SqlCommand())
				{
					InsertCommand.CommandType = CommandType.StoredProcedure;
					InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

					InsertCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, theEmployeeProfile.EmployeeID));
					InsertCommand.Parameters.Add(GetParameter("@SettingKeyName", SqlDbType.VarChar, theEmployeeProfile.SettingKeyName));
					InsertCommand.Parameters.Add(GetParameter("@SettingKeyID", SqlDbType.Int, theEmployeeProfile.SettingKeyID));
					InsertCommand.Parameters.Add(GetParameter("@SettingKeyValue", SqlDbType.VarBinary, theEmployeeProfile.SettingKeyValue));
					InsertCommand.Parameters.Add(GetParameter("@SettingKeyDescription", SqlDbType.VarChar, theEmployeeProfile.SettingKeyReference));

					InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

					InsertCommand.CommandText = "pHRM_EmployeeProfiles_Insert";
					ExecuteStoredProcedure(InsertCommand);

					ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
				}
				return ReturnValue;
			
		}

		public int UpdateEmployeeProfile(EmployeeProfile theEmployeeProfile)
		{
			int ReturnValue = 0;
				using(SqlCommand UpdateCommand = new SqlCommand())
			{

				UpdateCommand.CommandType = CommandType.StoredProcedure;

				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

				UpdateCommand.Parameters.Add(GetParameter("@EmployeeProfileID", SqlDbType.Int, theEmployeeProfile.EmployeeProfilleID));
				UpdateCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, theEmployeeProfile.EmployeeID));
				UpdateCommand.Parameters.Add(GetParameter("@SettingKeyName", SqlDbType.VarChar, theEmployeeProfile.SettingKeyName));
				UpdateCommand.Parameters.Add(GetParameter("@SettingKeyID", SqlDbType.Int, theEmployeeProfile.SettingKeyID));
				UpdateCommand.Parameters.Add(GetParameter("@SettingKeyValue", SqlDbType.VarBinary, theEmployeeProfile.SettingKeyValue));
				UpdateCommand.Parameters.Add(GetParameter("@SettingKeyDescription", SqlDbType.VarChar, theEmployeeProfile.SettingKeyReference));

				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				UpdateCommand.CommandText = "pHRM_EmployeeProfiles_Update";
				ExecuteStoredProcedure(UpdateCommand);

				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
				}
				return ReturnValue;
			
			
		}

		public int DeleteEmployeeProfile(EmployeeProfile theEmployeeProfile)
		{
			int ReturnValue = 0;

			SqlCommand DeleteCommand = new SqlCommand();

			DeleteCommand.CommandType = CommandType.StoredProcedure;
			DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
			DeleteCommand.Parameters.Add(GetParameter("@EmployeeProfileID", SqlDbType.Int, theEmployeeProfile.EmployeeProfilleID));
			DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
			DeleteCommand.CommandText = "pHRM_EmployeeProfiles_Delete";

			ExecuteStoredProcedure(DeleteCommand);
			ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

			return ReturnValue;

		}

		public int DeleteEmployeeProfilesByEmployee(int EmployeeID)
		{
				int ReturnValue = 0;
				SqlCommand DeleteCommand = new SqlCommand();

				DeleteCommand.CommandType = CommandType.StoredProcedure;

				DeleteCommand.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				DeleteCommand.Parameters.Add(GetParameter("EmployeeID", SqlDbType.Int, EmployeeID));
				DeleteCommand.Parameters.Add(GetParameter("ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				DeleteCommand.CommandText = "pHRM_EmployeeProfiles_DeleteByEmployeeID";
				ExecuteStoredProcedure(DeleteCommand);

				ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

				return ReturnValue;
		}

        #endregion
    }
}
