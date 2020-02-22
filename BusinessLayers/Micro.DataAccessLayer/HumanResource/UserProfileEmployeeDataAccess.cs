#region System Namespace
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
#endregion

#region Micro Namespaces
using Micro.Commons;
using Micro.Objects.HumanResource;
#endregion

namespace Micro.DataAccessLayer.HumanResource
{
public partial	class UserProfileEmployeeDataAccess:AbstractData_SQLClient
	{
        #region Code to make this a Singleton
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static UserProfileEmployeeDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static UserProfileEmployeeDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UserProfileEmployeeDataAccess();
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
        public int UpdateUserProfileEmployee(UserProfileEmployee emp)
        {
            try
            {
                int ReturnValue = 0;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("EmployeeID", SqlDbType.Int, emp.EmployeeID));


                //SqlCmd.Parameters.Add(GetParameter("Salutation", SqlDbType.VarChar, emp.Salutation));
                //SqlCmd.Parameters.Add(GetParameter("EmployeeName", SqlDbType.VarChar, emp.EmployeeName));
                //SqlCmd.Parameters.Add(GetParameter("FatherName", SqlDbType.VarChar, emp.FatherName));
                //SqlCmd.Parameters.Add(GetParameter("SpouseName", SqlDbType.VarChar, emp.SpouseName));
                SqlCmd.Parameters.Add(GetParameter("DateOfBirth", SqlDbType.DateTime, emp.DateOfBirth.ToString(MicroConstants.DateFormat)));
                //SqlCmd.Parameters.Add(GetParameter("Gender", SqlDbType.VarChar, emp.Gender));
                //SqlCmd.Parameters.Add(GetParameter("BloodGroup", SqlDbType.VarChar, emp.BloodGroup));
                //SqlCmd.Parameters.Add(GetParameter("Religion", SqlDbType.VarChar, emp.Religion));
                //SqlCmd.Parameters.Add(GetParameter("Nationality", SqlDbType.VarChar, emp.Nationality));
                //SqlCmd.Parameters.Add(GetParameter("MaritalStatus", SqlDbType.VarChar, emp.MaritalStatus));
                //SqlCmd.Parameters.Add(GetParameter("KnownAilments", SqlDbType.VarChar, emp.KnownAilments));
                //SqlCmd.Parameters.Add(GetParameter("IdentificationMark", SqlDbType.VarChar, emp.IdentificationMark));

                SqlCmd.Parameters.Add(GetParameter("Address_Present_TownOrCity", SqlDbType.VarChar, emp.Address_Present_TownOrCity));
                SqlCmd.Parameters.Add(GetParameter("Address_Present_LandMark", SqlDbType.VarChar, emp.Address_Present_LandMark));
                SqlCmd.Parameters.Add(GetParameter("Address_Present_DistrictID", SqlDbType.Int, emp.Address_Present_DistrictID));
                SqlCmd.Parameters.Add(GetParameter("Address_Present_Pincode", SqlDbType.VarChar, emp.Address_Present_Pincode));

                //SqlCmd.Parameters.Add(GetParameter("Address_Permanent_TownOrCity", SqlDbType.VarChar, emp.Address_Permanent_TownOrCity));
                //SqlCmd.Parameters.Add(GetParameter("Address_Permanent_LandMark", SqlDbType.VarChar, emp.Address_Permanent_LandMark));
                //SqlCmd.Parameters.Add(GetParameter("Address_Permanent_DistrictID", SqlDbType.Int, emp.Address_Permanent_DistrictID));
                //SqlCmd.Parameters.Add(GetParameter("Address_Permanent_Pincode", SqlDbType.VarChar, emp.Address_Permanent_Pincode));

                SqlCmd.Parameters.Add(GetParameter("PhoneNumber", SqlDbType.VarChar, emp.PhoneNumber));
                SqlCmd.Parameters.Add(GetParameter("Mobile", SqlDbType.VarChar, emp.Mobile));
                SqlCmd.Parameters.Add(GetParameter("EmailID", SqlDbType.VarChar, emp.EmailID));
                SqlCmd.Parameters.Add(GetParameter("PersonalEMailID", SqlDbType.VarChar, emp.PersonalEMailID));
                SqlCmd.Parameters.Add(GetParameter("EmergencyContactNumber", SqlDbType.VarChar, emp.EmergencyContactNumber));

                SqlCmd.Parameters.Add(GetParameter("ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_UserProfile_Employee_Update";
                ExecuteStoredProcedure(SqlCmd);

                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

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
