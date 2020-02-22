using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class CrmPremiumDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CrmPremiumDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CrmPremiumDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CrmPremiumDataAccess();
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

        public DataTable GetPolicy()
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.CommandText = "pCRM_Policies_SelectAll";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataTable GetPremium()
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.CommandText = "pCRM_PremiumTables_SelectAll";

            return ExecuteGetDataTable(SelectCommand);
        }

        public int InsertPremium(CRMPremium theCrmPremium)
        {
            int ReturnValue = 0;

            SqlCommand InsertCommand = new SqlCommand();

            InsertCommand.CommandType = CommandType.StoredProcedure;

            InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

            InsertCommand.Parameters.Add(GetParameter("PolicyID", SqlDbType.Int, theCrmPremium.PolicyID));

            InsertCommand.Parameters.Add(GetParameter("PremiumTableReferenceName", SqlDbType.VarChar, theCrmPremium.PremiumTableReferenceName));
            InsertCommand.Parameters.Add(GetParameter("PremiumTableDescriptiveName", SqlDbType.VarChar, theCrmPremium.PremiumTableDescriptiveName));
            InsertCommand.Parameters.Add(GetParameter("TenureInYears", SqlDbType.Decimal, theCrmPremium.TenureInYears));
            InsertCommand.Parameters.Add(GetParameter("EffectiveDateFrom", SqlDbType.VarChar, theCrmPremium.EffectiveDateFrom));

           

            InsertCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

            InsertCommand.CommandText = "pCRM_PremiumTables_Insert";

            ExecuteStoredProcedure(InsertCommand);
            ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int UpdatePremium(CRMPremium theCrmPremium)
        {
            int ReturnValue = 0;

            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;

            UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            UpdateCommand.Parameters.Add(GetParameter("PremiumTableID", SqlDbType.Int, theCrmPremium.PremiumTableID));

            UpdateCommand.Parameters.Add(GetParameter("PremiumTableReferenceName", SqlDbType.VarChar, theCrmPremium.PremiumTableReferenceName));
            UpdateCommand.Parameters.Add(GetParameter("PremiumTableDescriptiveName", SqlDbType.VarChar, theCrmPremium.PremiumTableDescriptiveName));
            UpdateCommand.Parameters.Add(GetParameter("TenureInYears", SqlDbType.Decimal, theCrmPremium.TenureInYears));
            UpdateCommand.Parameters.Add(GetParameter("EffectiveDateFrom", SqlDbType.VarChar, theCrmPremium.EffectiveDateFrom));

            UpdateCommand.Parameters.Add(GetParameter("PolicyID", SqlDbType.Int, theCrmPremium.PolicyID));

            UpdateCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
           
            UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));


            UpdateCommand.CommandText = "pCRM_PremiumTables_Update";

            ExecuteStoredProcedure(UpdateCommand);
            ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int DeletePremium(CRMPremium theCrmPremium)
        {
            int ReturnValue = 0;

            SqlCommand DeleteCommand = new SqlCommand();

            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

            DeleteCommand.Parameters.Add(GetParameter("@PremiumTableID", SqlDbType.Int, theCrmPremium.PremiumTableID));
            DeleteCommand.CommandText = "pCRM_PremiumTables_Delete";

            ExecuteStoredProcedure(DeleteCommand);
            ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public DataRow GetPremiumById(int recordId)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@PremiumTableID", SqlDbType.Int, recordId));
            SelectCommand.CommandText = "pCRM_PremiumTables_SelectByPremiumTableID";

            return ExecuteGetDataRow(SelectCommand);
        }

        #endregion


    }
}

