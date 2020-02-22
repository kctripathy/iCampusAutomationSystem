using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
   public partial class UserCompanyAccessDataAccess:AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static UserCompanyAccessDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static UserCompanyAccessDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UserCompanyAccessDataAccess();
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

       public DataTable GetUserCompanyWiseByUserID(int UserID)
       {
           SqlCommand SelectCommand = new SqlCommand();

           SelectCommand.CommandType = CommandType.StoredProcedure;
           SelectCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, UserID));
           SelectCommand.CommandText = "pADM_UsersCompanywise_SelectByUserID";

           return ExecuteGetDataTable(SelectCommand);
       }

       public int UpdateUserCompanyAccess(UserCompanyAccess theUserCompanyAccess)
       {
           int ReturnValue = 0;
           SqlCommand UpdateCommand = new SqlCommand();

           UpdateCommand.CommandType = CommandType.StoredProcedure;

           UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
           UpdateCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, theUserCompanyAccess.UserID));
           UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, theUserCompanyAccess.CompanyID));
           UpdateCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, theUserCompanyAccess.RoleID));
           if(theUserCompanyAccess.EffectiveDateFrom!=null)
               UpdateCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, theUserCompanyAccess.EffectiveDateFrom));
           if (theUserCompanyAccess.EffectiveDateTo != null)
               UpdateCommand.Parameters.Add(GetParameter("@EffectiveDateTo", SqlDbType.VarChar, theUserCompanyAccess.EffectiveDateTo));
           UpdateCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
           UpdateCommand.CommandText = "pADM_UsersCompanywise_Update";

           ExecuteStoredProcedure(UpdateCommand);
           ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

           return ReturnValue;
       }
        #endregion
    }
}
