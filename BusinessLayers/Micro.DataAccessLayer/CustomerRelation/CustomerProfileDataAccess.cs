using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class CustomerProfileDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CustomerProfileDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CustomerProfileDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerProfileDataAccess();
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

        #region Methods & Implementation
        public DataTable GetCustomerProfileList(string searchText)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SelectCommand.CommandText = "pCRM_CustomerProfiles_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

		public DataRow GetCustomerProfileByID(int customerProfileID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@CustomerProfileID", SqlDbType.Int, customerProfileID));
				SelectCommand.CommandText = "pCRM_CustomerProfiles_SelectByCustomerProfileID";
				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public DataTable GetCustomerProfileByCustomerID(int customerID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, customerID));
                SelectCommand.CommandText = "pCRM_CustomerProfiles_SelectByCustomerID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertCustomerProfile(CustomerProfile theCustomerProfile)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, theCustomerProfile.CustomerID));
                InsertCommand.Parameters.Add(GetParameter("@SettingKeyName", SqlDbType.VarChar, theCustomerProfile.SettingKeyName));
                InsertCommand.Parameters.Add(GetParameter("@SettingKeyDescription", SqlDbType.VarChar, theCustomerProfile.SettingKeyDescription));
                InsertCommand.Parameters.Add(GetParameter("@SettingKeyValue", SqlDbType.VarBinary, theCustomerProfile.SettingKeyValue));
                InsertCommand.Parameters.Add(GetParameter("@SettingKeyReference", SqlDbType.VarChar, theCustomerProfile.SettingKeyReference));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_CustomerProfiles_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int UpdateCustomerProfile(CustomerProfile theCustomerProfile)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@CustomerProfileID", SqlDbType.Int, theCustomerProfile.CustomerProfileID));
                UpdateCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, theCustomerProfile.CustomerID));
                UpdateCommand.Parameters.Add(GetParameter("@SettingKeyName", SqlDbType.VarChar, theCustomerProfile.SettingKeyName));
                UpdateCommand.Parameters.Add(GetParameter("@SettingKeyDescription", SqlDbType.VarChar, theCustomerProfile.SettingKeyDescription));
                UpdateCommand.Parameters.Add(GetParameter("@SettingKeyValue", SqlDbType.VarBinary, theCustomerProfile.SettingKeyValue));
                UpdateCommand.Parameters.Add(GetParameter("@SettingKeyReference", SqlDbType.VarChar, theCustomerProfile.SettingKeyReference));
                UpdateCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, theCustomerProfile.IsActive));
                UpdateCommand.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, theCustomerProfile.IsDeleted));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_CustomerProfiles_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int DeleteCustomerProfile(CustomerProfile theCustomerProfile)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@CustomerProfileID", SqlDbType.Int, theCustomerProfile.CustomerProfileID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pCRM_CustomerProfiles_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
