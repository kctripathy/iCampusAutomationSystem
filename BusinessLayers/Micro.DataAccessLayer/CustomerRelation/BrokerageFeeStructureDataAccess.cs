using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;
namespace Micro.DataAccessLayer.CustomerRelation
{
	public partial class BrokerageFeeStructureDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static BrokerageFeeStructureDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static BrokerageFeeStructureDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new BrokerageFeeStructureDataAccess();
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
        public DataTable GetBrokerageFeeStructureList(bool allOffices = false, bool showDeleted = false)
		{
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_BrokerageFeeStructures_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
		}

        public DataRow GetBrokerageFeeStructuresById(int BrokerageFeeStructureID)
		{
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@BrokerageFeeStructureID", SqlDbType.Int, BrokerageFeeStructureID));
                SelectCommand.CommandText = "pCRM_BrokerageFeeStructures_SelectByBrokerageFeeStructureID";
                return ExecuteGetDataRow(SelectCommand);
            }
		}

        public int InsertBrokerageFeeStructure(BrokerageFeeStructure theBrokerageFeeStructure)
        {
            int Returnvalue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, Returnvalue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@PolicyTypeID", SqlDbType.Int, theBrokerageFeeStructure.PolicyTypeID));
                InsertCommand.Parameters.Add(GetParameter("@BrokerageType", SqlDbType.VarChar, theBrokerageFeeStructure.BrokerageType));
                InsertCommand.Parameters.Add(GetParameter("@DatabaseTableName", SqlDbType.VarChar, theBrokerageFeeStructure.DatabaseTableName));
                InsertCommand.Parameters.Add(GetParameter("@StoredProcedureName", SqlDbType.VarChar, theBrokerageFeeStructure.StoredProcedureName));
                InsertCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, theBrokerageFeeStructure.EffectiveDateFrom));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_BrokerageFeeStructures_Insert";
                ExecuteStoredProcedure(InsertCommand);
                Returnvalue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return Returnvalue;
            }
        }

        public int UpdateBrokerageFeeStructure(BrokerageFeeStructure theBrokerageFeeStructure)
        {
            int Returnvalue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, Returnvalue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@BrokerageFeeStructureID", SqlDbType.Int, theBrokerageFeeStructure.BrokerageFeeStructureID));
                UpdateCommand.Parameters.Add(GetParameter("@PolicyTypeID", SqlDbType.Int, theBrokerageFeeStructure.PolicyTypeID));
                UpdateCommand.Parameters.Add(GetParameter("@BrokerageType", SqlDbType.VarChar, theBrokerageFeeStructure.BrokerageType));
                UpdateCommand.Parameters.Add(GetParameter("@DatabaseTableName", SqlDbType.VarChar, theBrokerageFeeStructure.DatabaseTableName));
                UpdateCommand.Parameters.Add(GetParameter("@StoredProcedureName", SqlDbType.VarChar, theBrokerageFeeStructure.StoredProcedureName));
                UpdateCommand.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.VarChar, theBrokerageFeeStructure.EffectiveDateFrom));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_BrokerageFeeStructures_Update";
                ExecuteStoredProcedure(UpdateCommand);
                Returnvalue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return Returnvalue;
            }
        }

		public int DeletBrokerageFeeStructure(BrokerageFeeStructure theBrokerageFeeStructure)
		{
			int ReturnValue = 0;
            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@BrokerageFeeStructureID", SqlDbType.Int, theBrokerageFeeStructure.BrokerageFeeStructureID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pCRM_BrokerageFeeStructures_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
		}
		#endregion
	}
}
