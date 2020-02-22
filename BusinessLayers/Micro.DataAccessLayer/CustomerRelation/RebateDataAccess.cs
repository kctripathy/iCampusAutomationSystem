using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
	public partial class RebateDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static RebateDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static RebateDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new RebateDataAccess();
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

        public DataTable GetRebateList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pCRM_Rebates_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertRebate(Rebate theRebate)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@PolicyTypeID", SqlDbType.Int, theRebate.PolicyTypeID));
                //InsertCommand.Parameters.Add(GetParameter("@PolicyName", SqlDbType.VarChar, theRebate.PolicyName));
                InsertCommand.Parameters.Add(GetParameter("@InstallmentMode", SqlDbType.VarChar, theRebate.InstallmentMode));
                InsertCommand.Parameters.Add(GetParameter("@RebatePer", SqlDbType.Decimal, theRebate.RebatePer));
                InsertCommand.Parameters.Add(GetParameter("@RebateValue", SqlDbType.Decimal, theRebate.RebateValue));
                InsertCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, theRebate.EffectiveDateFrom));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_Rebates_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int UpdateRebate(Rebate theRebate)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@RebateID",SqlDbType.Int,theRebate.RebateID));
                UpdateCommand.Parameters.Add(GetParameter("@PolicyTypeID", SqlDbType.Int, theRebate.PolicyTypeID));
                //UpdateCommand.Parameters.Add(GetParameter("@PolicyName", SqlDbType.VarChar, theRebate.PolicyName));
                UpdateCommand.Parameters.Add(GetParameter("@InstallmentMode", SqlDbType.VarChar, theRebate.InstallmentMode));
                UpdateCommand.Parameters.Add(GetParameter("@RebatePer", SqlDbType.Decimal, theRebate.RebatePer));
                UpdateCommand.Parameters.Add(GetParameter("@RebateValue", SqlDbType.Decimal, theRebate.RebateValue));
                UpdateCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, theRebate.EffectiveDateFrom));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_Rebates_Update";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int DeleteRebate(Rebate theRebate)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@RebateID", SqlDbType.Int,theRebate.RebateID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pCRM_Rebates_Delete";

                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public DataRow GetRebateByID(int RebateID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@RebateID", SqlDbType.Int, RebateID));
                SelectCommand.CommandText = "pCRM_Rebates_SelectByRebateID";

                return ExecuteGetDataRow(SelectCommand);
            }

        }

        public decimal GetRebateAmount(int policyTypeID, string installmentMode, decimal installmentAmount)
		{
			decimal ReturnValue = 0; 

			SqlCommand SelectCommand = new SqlCommand();

			SelectCommand.CommandType = CommandType.StoredProcedure;
			SelectCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Decimal, ReturnValue)).Direction = ParameterDirection.Output;
			SelectCommand.Parameters.Add(GetParameter("@PolicyTypeID", SqlDbType.Int, policyTypeID));
			SelectCommand.Parameters.Add(GetParameter("@InstallmentMode", SqlDbType.VarChar, installmentMode));
			SelectCommand.Parameters.Add(GetParameter("@InstallmentAmount", SqlDbType.Decimal, installmentAmount));
			SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));

			SelectCommand.CommandText = "pCRM_Rebates_SelectRebateAmount";

			ExecuteStoredProcedure(SelectCommand);
			ReturnValue = int.Parse(SelectCommand.Parameters[0].Value.ToString());

			return ReturnValue;
        }
        #endregion
    }
}
