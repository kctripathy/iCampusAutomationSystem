using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
    public partial class ResetPasswordDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ResetPasswordDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ResetPasswordDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ResetPasswordDataAccess();
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
		public int ChangePassword(User theUser)
		{
			int ReturnValue = 0;

			using(SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, theUser.UserID));
				UpdateCommand.Parameters.Add(GetParameter("@NewPassword", SqlDbType.VarChar, Micro.Commons.MicroSecuritty.Encrypt(theUser.Password)));
				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				UpdateCommand.CommandText = "pADM_Users_ChangePassword";

				ExecuteStoredProcedure(UpdateCommand);

				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public DataRow GeneratePassword()
        {
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.VarChar, string.Empty)).Direction = ParameterDirection.Output;
				SelectCommand.CommandText = "pADM_Users_GenerateNewPassword";
				return ExecuteGetDataRow(SelectCommand);
			}
        }

        public int ResetPassword(User theUser)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, theUser.UserID));
                UpdateCommand.Parameters.Add(GetParameter("@NewPassword", SqlDbType.VarChar, Micro.Commons.MicroSecuritty.Encrypt(theUser.Password)));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pADM_Users_ResetPassword";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
		}
		#endregion
	}
}