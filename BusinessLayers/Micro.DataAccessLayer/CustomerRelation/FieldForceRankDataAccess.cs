using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.CustomerRelation
{
	public partial class FieldForceRankDataAccess :AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static FieldForceRankDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static FieldForceRankDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new FieldForceRankDataAccess();
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
		public DataTable GetFieldForceRanks(int fieldForceRankID = 0)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@FieldForceRankID", SqlDbType.Int, fieldForceRankID));
				SelectCommand.CommandText = "pCRM_FieldForceRanks_SelectAll";

				return ExecuteGetDataTable(SelectCommand);
			}
		}
		#endregion
	}
}
