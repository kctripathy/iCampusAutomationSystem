using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class PolicySurrenderDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PolicySurrenderDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PolicySurrenderDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PolicySurrenderDataAccess();
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

        #region Methods & Implementations
        public DataTable GetPolicySurrenderList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_Surrenders_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetSurrenderChargesbyCustomerAccountID(int customerAccountID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, customerAccountID));
                SelectCommand.CommandText = "pCRM_Surrenders_CalculateSurrenderCharges";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertPolicySurrender(PolicySurrender thePolicySurrender)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, thePolicySurrender.CustomerAccountID));
                InsertCommand.Parameters.Add(GetParameter("@SurrenderDate", SqlDbType.VarChar, thePolicySurrender.SurrenderDate));
                //InsertCommand.Parameters.Add(GetParameter("@SurrenderFormNumber", SqlDbType.VarChar, thePolicySurrender.SurrenderFormNumber));
                InsertCommand.Parameters.Add(GetParameter("@SurrenderPrincipalPayable ", SqlDbType.Decimal, thePolicySurrender.SurrenderPrincipalPayable));
                InsertCommand.Parameters.Add(GetParameter("@SurrenderPrincipalPaid", SqlDbType.Decimal, thePolicySurrender.SurrenderPrincipalPaid));
                InsertCommand.Parameters.Add(GetParameter("@SurrenderInterestPayable", SqlDbType.Decimal, thePolicySurrender.SurrenderInterestPayable));
                InsertCommand.Parameters.Add(GetParameter("@SurrenderInterestPaid", SqlDbType.Decimal, thePolicySurrender.SurrenderInterestPaid));
                InsertCommand.Parameters.Add(GetParameter("@SurrenderBonusPayable", SqlDbType.Decimal, thePolicySurrender.SurrenderBonusPayable));
                InsertCommand.Parameters.Add(GetParameter("@SurrenderBonusPaid", SqlDbType.Decimal, thePolicySurrender.SurrenderBonusPaid));
                InsertCommand.Parameters.Add(GetParameter("@SurrenderPrincipalDeductions", SqlDbType.Decimal, thePolicySurrender.SurrenderPrincipalDeductions));
                InsertCommand.Parameters.Add(GetParameter("@SurrenderPrincipalDeductionsRemarks", SqlDbType.VarChar, thePolicySurrender.SurrenderPrincipalDeductionsRemarks));
                InsertCommand.Parameters.Add(GetParameter("@SurrenderTotalPayable", SqlDbType.Decimal, thePolicySurrender.SurrenderTotalPayable));
                InsertCommand.Parameters.Add(GetParameter("@SurrenderTotalPaid ", SqlDbType.Decimal, thePolicySurrender.SurrenderTotalPaid));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_Surrenders_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        #endregion
    }
}
