using System.Data.SqlClient;
using System.Data;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
   public partial class USerProxyDataAccess:AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
       private static USerProxyDataAccess instance = new USerProxyDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
       public static USerProxyDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation

       public int InsertUserIncharge(UserIncharge theUserIncharge)
       {
           int ReturnValue = 0;
           SqlCommand InsertCommand = new SqlCommand();

           InsertCommand.CommandType = CommandType.StoredProcedure;

           InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
           InsertCommand.Parameters.Add(GetParameter("@ParentUserID", SqlDbType.Int, theUserIncharge.ParentUserID));
           InsertCommand.Parameters.Add(GetParameter("@InChargeUserID", SqlDbType.Int, theUserIncharge.InChargeUserID));
           InsertCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, theUserIncharge.EffectiveDateFrom));
           InsertCommand.Parameters.Add(GetParameter("@EffectiveDateTo", SqlDbType.VarChar, theUserIncharge.EffectiveDateTo));
           InsertCommand.Parameters.Add(GetParameter("@ReferenceLetterNumber", SqlDbType.VarChar, theUserIncharge.ReferenceLetterNumber));
           InsertCommand.Parameters.Add(GetParameter("@ReferenceLetterDate", SqlDbType.VarChar, theUserIncharge.ReferenceLetterDate));
           InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
           InsertCommand.CommandText = "pADM_UsersIncharge_Insert";

           ExecuteStoredProcedure(InsertCommand);
           ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

           return ReturnValue;
       }
        #endregion
    }
}
