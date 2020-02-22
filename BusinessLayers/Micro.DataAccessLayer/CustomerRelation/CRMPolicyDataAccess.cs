using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Micro.Commons;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class CRMPolicyDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CRMPolicyDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CRMPolicyDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CRMPolicyDataAccess();
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
        public DataTable GetCRMPolicyList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pCRM_Policies_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetCRMPolicyListByID(int policyID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@PolicyID", SqlDbType.Int, policyID));
                SelectCommand.CommandText = "pCRM_Policies_SelectByPolicyID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetCRMPolicyTypeList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pCRM_PolicyTypes_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetCRMPolicyTypeByID(int policyTypeID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@PolicyTypeID", SqlDbType.Int, policyTypeID));
                SelectCommand.CommandText = "pCRM_PolicyTypes_SelectByPolicyTypeID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataTable GetCRMPolicyTypeListByOfficeID(bool showInOfficewise = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.Parameters.Add(GetParameter("@ShowInOfficewise", SqlDbType.Bit, showInOfficewise));
                SelectCommand.CommandText = "pCRM_PolicyTypes_SelectByOfficeID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetCRMPolicyTypeOfficewiseList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_PolicyTypesOfficewise_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertCRMPolicy(CRMPolicy theCRMPolicy)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@PolicyName", SqlDbType.VarChar, theCRMPolicy.PolicyName));
                InsertCommand.Parameters.Add(GetParameter("@PolicyFromOrganization", SqlDbType.VarChar, theCRMPolicy.PolicyFromOrganization));
                InsertCommand.Parameters.Add(GetParameter("@TenureInYears", SqlDbType.Decimal, theCRMPolicy.TenureInYears));
                InsertCommand.Parameters.Add(GetParameter("@TenureInMonths", SqlDbType.Int, theCRMPolicy.TenureInMonths));
                InsertCommand.Parameters.Add(GetParameter("@AllowDeathCompensation", SqlDbType.Bit, theCRMPolicy.AllowDeathCompensation));
                InsertCommand.Parameters.Add(GetParameter("@AllowMediclaim", SqlDbType.Bit, theCRMPolicy.AllowMediclaim));
                InsertCommand.Parameters.Add(GetParameter("@AllowPolicySurrender", SqlDbType.Bit, theCRMPolicy.AllowPolicySurrender));
                InsertCommand.Parameters.Add(GetParameter("@AllowPreMaturity", SqlDbType.Bit, theCRMPolicy.AllowPreMaturity));
                InsertCommand.Parameters.Add(GetParameter("@AllowRevival", SqlDbType.Bit, theCRMPolicy.AllowRevival));
                InsertCommand.Parameters.Add(GetParameter("@DatabaseTableName", SqlDbType.VarChar, theCRMPolicy.DatabaseTableName));
                InsertCommand.Parameters.Add(GetParameter("@StoredProcedureName", SqlDbType.VarChar, theCRMPolicy.StoredProcedureName));
                InsertCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, theCRMPolicy.EffectiveDateFrom));
                InsertCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, theCRMPolicy.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_Policies_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int InsertCRMPolicyTypes(List<CRMPolicy> theCRMPolicyList)
        {
            int ReturnValue = 0;

            int ListCount = theCRMPolicyList.Count;
            int ListCounter = 0;

            SqlCommand[] InsertCommand = new SqlCommand[ListCount];

            foreach (CRMPolicy TheCRMPolicy in theCRMPolicyList)
            {
                InsertCommand[ListCounter] = new SqlCommand();

                InsertCommand[ListCounter].CommandType = CommandType.StoredProcedure;
                InsertCommand[ListCounter].Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand[ListCounter].Parameters.Add(GetParameter("@PolicyID", SqlDbType.Int, TheCRMPolicy.PolicyID));
                InsertCommand[ListCounter].Parameters.Add(GetParameter("@PolicyTypeDescription", SqlDbType.VarChar, TheCRMPolicy.PolicyTypeDescription));
                InsertCommand[ListCounter].Parameters.Add(GetParameter("@PolicySubType", SqlDbType.VarChar, TheCRMPolicy.PolicySubType));
                InsertCommand[ListCounter].Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand[ListCounter].CommandText = "pCRM_PolicyTypes_Insert";

                ListCounter++;
            }

            ReturnValue = ExecuteStoredProcedure(InsertCommand);

            if ((ReturnValue + ListCount).Equals(0))
            {
                ReturnValue = (int)MicroEnums.DataOperationResult.Success + 1;
            }
            else
            {
                ReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            }

            return ReturnValue;
        }

        public int UpdateCRMPolicy(CRMPolicy theCRMPolicy)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@PolicyID", SqlDbType.Int, theCRMPolicy.PolicyID));
                UpdateCommand.Parameters.Add(GetParameter("@PolicyName", SqlDbType.VarChar, theCRMPolicy.PolicyName));
                UpdateCommand.Parameters.Add(GetParameter("@PolicyFromOrganization", SqlDbType.VarChar, theCRMPolicy.PolicyFromOrganization));
                UpdateCommand.Parameters.Add(GetParameter("@TenureInYears", SqlDbType.Decimal, theCRMPolicy.TenureInYears));
                UpdateCommand.Parameters.Add(GetParameter("@TenureInMonths", SqlDbType.Int, theCRMPolicy.TenureInMonths));
                UpdateCommand.Parameters.Add(GetParameter("@AllowDeathCompensation", SqlDbType.Bit, theCRMPolicy.AllowDeathCompensation));
                UpdateCommand.Parameters.Add(GetParameter("@AllowMediclaim", SqlDbType.Bit, theCRMPolicy.AllowMediclaim));
                UpdateCommand.Parameters.Add(GetParameter("@AllowPolicySurrender", SqlDbType.Bit, theCRMPolicy.AllowPolicySurrender));
                UpdateCommand.Parameters.Add(GetParameter("@AllowPreMaturity", SqlDbType.Bit, theCRMPolicy.AllowPreMaturity));
                UpdateCommand.Parameters.Add(GetParameter("@AllowRevival", SqlDbType.Bit, theCRMPolicy.AllowRevival));
                UpdateCommand.Parameters.Add(GetParameter("@DatabaseTableName", SqlDbType.VarChar, theCRMPolicy.DatabaseTableName));
                UpdateCommand.Parameters.Add(GetParameter("@StoredProcedureName", SqlDbType.VarChar, theCRMPolicy.StoredProcedureName));
                UpdateCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, theCRMPolicy.EffectiveDateFrom));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, theCRMPolicy.OfficeID));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_Policies_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int UpdateCRMPolicyTypes(List<CRMPolicy> theCRMPolicyList)
        {
            int ReturnValue = 0;

            int ListCount = theCRMPolicyList.Count;
            int ListCounter = 0;

            SqlCommand[] UpdateCommand = new SqlCommand[ListCount];

            foreach (CRMPolicy TheCRMPolicy in theCRMPolicyList)
            {
                UpdateCommand[ListCounter] = new SqlCommand();

                UpdateCommand[ListCounter].CommandType = CommandType.StoredProcedure;
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@PolicyID", SqlDbType.Int, TheCRMPolicy.PolicyID));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@PolicyTypeDescription", SqlDbType.VarChar, TheCRMPolicy.PolicyTypeDescription));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@PolicySubType", SqlDbType.VarChar, TheCRMPolicy.PolicySubType));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, TheCRMPolicy.IsActive));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, TheCRMPolicy.IsDeleted));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand[ListCounter].CommandText = "pCRM_PolicyTypes_Update";

                ListCounter++;
            }

            ReturnValue = ExecuteStoredProcedure(UpdateCommand);

            if ((ReturnValue + ListCount).Equals(0))
            {
                ReturnValue = (int)MicroEnums.DataOperationResult.Success + 1;
            }
            else
            {
                ReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            }

            return ReturnValue;
        }

        public int DeleteCRMPolicy(CRMPolicy theCRMPolicy)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@PolicyID", SqlDbType.Int, theCRMPolicy.PolicyID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pCRM_Policies_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
