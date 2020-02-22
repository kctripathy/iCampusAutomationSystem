using System;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;
using Micro.Commons;
using System.Reflection;
namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class UserProfileFieldForceDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static UserProfileFieldForceDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static UserProfileFieldForceDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UserProfileFieldForceDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Transactional Methods(Insert,Update,Delete)
        public int UpdateUserProfileFieldForce(UserProfileFieldForce theFieldForce)
        {
            try
            {
                int ReturnValue = 0;
                SqlCommand sqlcmd = new SqlCommand();

                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;


                sqlcmd.Parameters.Add(GetParameter("FieldForceID", SqlDbType.Int, theFieldForce.FieldForceID));
                sqlcmd.Parameters.Add(GetParameter("Salutation", SqlDbType.VarChar, theFieldForce.Salutation));
                sqlcmd.Parameters.Add(GetParameter("FieldForceName", SqlDbType.VarChar, theFieldForce.FieldForceName));
                sqlcmd.Parameters.Add(GetParameter("FatherName", SqlDbType.VarChar, theFieldForce.FatherName));
                sqlcmd.Parameters.Add(GetParameter("DateOfBirth", SqlDbType.DateTime, theFieldForce.DateOfBirth.ToString(MicroConstants.DateFormat)));
                sqlcmd.Parameters.Add(GetParameter("Gender", SqlDbType.VarChar, theFieldForce.Gender));
                sqlcmd.Parameters.Add(GetParameter("Religion", SqlDbType.VarChar, theFieldForce.Religion));
                sqlcmd.Parameters.Add(GetParameter("Nationality", SqlDbType.VarChar, theFieldForce.Nationality));
                sqlcmd.Parameters.Add(GetParameter("MaritalStatus", SqlDbType.VarChar, theFieldForce.MaritalStatus));
                sqlcmd.Parameters.Add(GetParameter("Address_Present_TownOrCity", SqlDbType.VarChar, theFieldForce.Address_Present_TownOrCity));
                sqlcmd.Parameters.Add(GetParameter("Address_Present_DistrictID", SqlDbType.Int, theFieldForce.Address_Present_DistrictID));
                sqlcmd.Parameters.Add(GetParameter("Address_Permanent_TownOrCity", SqlDbType.VarChar, theFieldForce.Address_Permanent_TownOrCity));
                sqlcmd.Parameters.Add(GetParameter("Address_Permanent_DistrictID", SqlDbType.Int, theFieldForce.Address_Permanent_DistrictID));
                sqlcmd.Parameters.Add(GetParameter("PhoneNumber", SqlDbType.VarChar, theFieldForce.PhoneNumber));
                sqlcmd.Parameters.Add(GetParameter("Mobile", SqlDbType.VarChar, theFieldForce.Mobile));

                sqlcmd.Parameters.Add(GetParameter("ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                sqlcmd.CommandText = "pCRM_UserProfile_FieldForce_Update";
                ExecuteStoredProcedure(sqlcmd);
                ReturnValue = int.Parse(sqlcmd.Parameters[0].Value.ToString());
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
            

            }

           
       
        #endregion
    }
}

