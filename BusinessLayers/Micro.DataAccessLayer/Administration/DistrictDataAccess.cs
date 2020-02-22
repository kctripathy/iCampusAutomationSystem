using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.Administration
{
	public partial class DistrictDataAccess : AbstractData_SQLClient
    {
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static DistrictDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static DistrictDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new DistrictDataAccess();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

		#region Methods and Implementations
		public DataTable GetDistrictListByStateId(int stateId, bool showDeleted = false)
		{
			SqlCommand SelectCommand=new SqlCommand();

			SelectCommand.CommandType = CommandType.StoredProcedure;
			SelectCommand.Parameters.Add(GetParameter("@StateId", SqlDbType.Int, stateId));
			SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
			SelectCommand.CommandText = "pADM_District_SelectByStateId";

			return ExecuteGetDataTable(SelectCommand);
		}

		public DataTable GetAllDistricts()
		{
			SqlCommand SelectCommand=new SqlCommand();

			SelectCommand.CommandType = CommandType.StoredProcedure;
			SelectCommand.CommandText = "pADM_Districts_SelectByDistrictID";

			return ExecuteGetDataTable(SelectCommand);
		}
		
		public DataTable GetDistrictStateCountryByDistrictId()
		{
			SqlCommand SelectCommand=new SqlCommand();

			SelectCommand.CommandType = CommandType.StoredProcedure;
			SelectCommand.CommandText = "pADM_Districts_SelectByDistrictID";
			
			return ExecuteGetDataTable(SelectCommand);
		}

		public DataRow GetDistrictStateCountryByDistrictId(int districtId)
		{
			SqlCommand SelectCommand=new SqlCommand();

			SelectCommand.CommandType = CommandType.StoredProcedure;
			SelectCommand.Parameters.Add(GetParameter("@DistrictID", SqlDbType.Int, districtId));
			SelectCommand.CommandText = "pADM_Districts_SelectByDistrictID";

			return ExecuteGetDataRow(SelectCommand);
		}
		#endregion
    }
}
