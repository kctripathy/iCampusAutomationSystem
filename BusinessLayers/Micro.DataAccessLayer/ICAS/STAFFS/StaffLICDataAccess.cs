using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace Micro.DataAccessLayer.ICAS.STAFFS
{
    public partial class StaffLICDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static StaffLICDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StaffLICDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StaffLICDataAccess();
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

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertPolicyApplication(PolicyApplication ThePolicyMaster)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand InsertCommand = new SqlCommand();

                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@PolicyID", SqlDbType.Int, ThePolicyMaster.PolicyID));
                InsertCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, ThePolicyMaster.SessionID));
                InsertCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, ThePolicyMaster.EmployeeID));
                InsertCommand.Parameters.Add(GetParameter("@PolicyDate", SqlDbType.VarChar, ThePolicyMaster.PolicyDate));
                InsertCommand.Parameters.Add(GetParameter("@PolicyAmount", SqlDbType.Decimal, ThePolicyMaster.PolicyAmount));
                InsertCommand.Parameters.Add(GetParameter("@TotalNoInstallment", SqlDbType.Int, ThePolicyMaster.TotalNoInstallment));
                InsertCommand.Parameters.Add(GetParameter("@EMI", SqlDbType.Decimal, ThePolicyMaster.EMI));

                InsertCommand.Parameters.Add(GetParameter("@PolicyStatus", SqlDbType.Bit, ThePolicyMaster.PolicyStatus));

                InsertCommand.Parameters.Add(GetParameter("@Comment", SqlDbType.VarChar, ThePolicyMaster.Comment));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@SanctionedByID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pHRMS_TRN_StaffLIC_Payments_Insert";

                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdatePolicyApplication(PolicyApplication ThePolicyMaster)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand UpdateCommand = new SqlCommand();
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                UpdateCommand.Parameters.Add(GetParameter("@PolicyApplicationID", SqlDbType.Int, ThePolicyMaster.PolicyApplicationID));
                UpdateCommand.Parameters.Add(GetParameter("@PolicyID", SqlDbType.Int, ThePolicyMaster.PolicyID));
                UpdateCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, ThePolicyMaster.SessionID));
                UpdateCommand.Parameters.Add(GetParameter("@PolicyDate", SqlDbType.VarChar, ThePolicyMaster.PolicyDate));
                UpdateCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, ThePolicyMaster.EmployeeID));
                UpdateCommand.Parameters.Add(GetParameter("@PolicyAmount", SqlDbType.Decimal, ThePolicyMaster.PolicyAmount));
                UpdateCommand.Parameters.Add(GetParameter("@TotalNoInstallment", SqlDbType.Int, ThePolicyMaster.TotalNoInstallment));
                UpdateCommand.Parameters.Add(GetParameter("@EMI", SqlDbType.Decimal, ThePolicyMaster.EMI));
                UpdateCommand.Parameters.Add(GetParameter("@PolicyStatus", SqlDbType.Bit, ThePolicyMaster.PolicyStatus));
                UpdateCommand.Parameters.Add(GetParameter("@Comment", SqlDbType.VarChar, ThePolicyMaster.Comment));
                UpdateCommand.Parameters.Add(GetParameter("@SanctionedByID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                //SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Int, Desg.IsActive));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pHRMS_TRN_StaffLIC_Payments_Update";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public DataTable GetLICEmployeeList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pHRM_LICPayments_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetPolicySelectAll_By_Employee(int EmployeeID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;               
                SelectCommand.Parameters.Add(GetParameter("@UserType", SqlDbType.VarChar, "Employee"));
                SelectCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SelectCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                SelectCommand.CommandText = "pHRM_Policy_SelectAll_By_Employee";
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataRow GetEmployeePolicyDetailsByPolicyApplicationID(int PolicyApplicationID)
        {
            try
            {
                SqlCommand SelectCommandd = new SqlCommand();
                SelectCommandd.CommandType = CommandType.StoredProcedure;

                SelectCommandd.Parameters.Add(GetParameter("@PolicyApplicationID", SqlDbType.Int, PolicyApplicationID));

                SelectCommandd.CommandText = "pHRM_PolicyPayments_SelectByPolicyApplicationID";

                return ExecuteGetDataRow(SelectCommandd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }


        //public DataRow GetEmployeeLoanDetailsByEmployeeID(int EmployeeID)
        //{
        //    try
        //    {
        //        SqlCommand SelectCommandd = new SqlCommand();
        //        SelectCommandd.CommandType = CommandType.StoredProcedure;

        //        SelectCommandd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));

        //        SelectCommandd.CommandText = "pHRM_LoanPayments_SelectByEmployeeID";

        //        return ExecuteGetDataRow(SelectCommandd);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}


        //NOT DONE
        public DataTable GetEmployeePolicyListByEmployeeID(int EmployeeID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SelectCommand.CommandText = "pHRM_PolicyPayments_SelectByEmployeeID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }


        #endregion
    }
}
