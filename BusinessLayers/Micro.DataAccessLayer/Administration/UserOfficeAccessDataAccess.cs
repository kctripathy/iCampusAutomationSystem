using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
   public partial  class UserOfficeAccessDataAccess:AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static UserOfficeAccessDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static UserOfficeAccessDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UserOfficeAccessDataAccess();
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
       public DataTable GetUserListOfficewiseByUserID(int UserID)
       {
           using (SqlCommand SelectCommand = new SqlCommand())
           {
               SelectCommand.CommandType = CommandType.StoredProcedure;
               SelectCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, UserID));
               SelectCommand.CommandText = "pADM_UsersOfficewise_SelectByUserID";
               return ExecuteGetDataTable(SelectCommand);
           }
       }

       public int InsertUserOfficeAccess(UserOfficeAccess theUserOfficeAccess)
       {
           int ReturnValue = 0;
           SqlCommand InsertCommand = new SqlCommand();

           InsertCommand.CommandType = CommandType.StoredProcedure;

           InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
           InsertCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, theUserOfficeAccess.UserID));
           InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, theUserOfficeAccess.OfficeID));
           InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, theUserOfficeAccess.CompanyID));
           InsertCommand.Parameters.Add(GetParameter("@CanAccessAllOffices", SqlDbType.Bit, theUserOfficeAccess.CanAccessAllOffices));
           
           if (theUserOfficeAccess.EffectiveDateFrom != null)
               InsertCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, theUserOfficeAccess.EffectiveDateFrom));
           if (theUserOfficeAccess.EffectiveDateTo != null)
               InsertCommand.Parameters.Add(GetParameter("@EffectiveDateTo", SqlDbType.VarChar, theUserOfficeAccess.EffectiveDateTo));
           InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
           InsertCommand.CommandText = "pADM_UsersOfficewise_Insert";

           ExecuteStoredProcedure(InsertCommand);
           ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

           return ReturnValue;
       }
        #endregion
    } 
}
