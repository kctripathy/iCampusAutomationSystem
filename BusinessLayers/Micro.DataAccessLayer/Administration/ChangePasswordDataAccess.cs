using System.Data.SqlClient;
using Micro.Objects.Administration;
using System.Data;

namespace Micro.DataAccessLayer.Administration
{
    public partial class ChangePasswordDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ChangePasswordDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ChangePasswordDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChangePasswordDataAccess();
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
        public DataRow GetUserByName(string UserName)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@UserName", SqlDbType.VarChar, UserName));
                SelectCommand.CommandText = "pADM_Users_SelectByLoginName";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int UpdateChangePassword(User theUser)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, theUser.UserID));
                UpdateCommand.Parameters.Add(GetParameter("@NewPassword", SqlDbType.VarChar,theUser.Password));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pADM_Users_ChangePassword";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        #endregion
    }
}
