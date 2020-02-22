using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.Administration
{
	public partial class CurrencyDataAccess:AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Private static member to implement Singleton Desing Pattern
		/// </summary>
		private static CurrencyDataAccess instance = new CurrencyDataAccess();

		/// <summary>
		/// Static property of the class which will provide the singleton instance of it
		/// </summary>
		public static CurrencyDataAccess GetInstance
		{
			get
			{
				return instance;
			}
		}
		#endregion

		#region Methods & Implementation
		public DataTable GetCurrencyList()
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.CommandText = "pADM_Currency_SelectAll";

				return ExecuteGetDataTable(SelectCommand);
			}
		}
		#endregion
	}
}
