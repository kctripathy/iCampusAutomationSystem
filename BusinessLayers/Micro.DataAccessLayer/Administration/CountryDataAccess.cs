using System;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
	public partial class CountryDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Private static member to implement Singleton Desing Pattern
		/// </summary>
		private static CountryDataAccess instance = new CountryDataAccess();

		/// <summary>
		/// Static property of the class which will provide the singleton instance of it
		/// </summary>
		public static CountryDataAccess GetInstance
		{
			get
			{
				return instance;
			}
		}
		#endregion

		#region Methods & Implementation
		public DataTable GetCountryList(string searchText, bool showDeleted = false)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
				SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
				SelectCommand.CommandText = "pADM_Countries_SelectAll";
				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataRow GetCountryById(int countryId)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@CountryId", SqlDbType.Int, countryId));
				SelectCommand.CommandText = "pADM_Countries_SelectByCountryId";
				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public int InsertCountry(Country theCountry)
		{
			int ReturnValue = 0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@CountryName", SqlDbType.VarChar, theCountry.CountryName));
				InsertCommand.Parameters.Add(GetParameter("@CapitalName", SqlDbType.VarChar, theCountry.CapitalName));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pADM_Countries_Insert";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
				return ReturnValue;
			}
		}

		public int UpdateCountry(Country theCountry)
		{
			int ReturnValue = 0;

			using(SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@CountryID", SqlDbType.Int, theCountry.CountryID));
				UpdateCommand.Parameters.Add(GetParameter("@CountryName", SqlDbType.VarChar, theCountry.CountryName));
				UpdateCommand.Parameters.Add(GetParameter("@CapitalName", SqlDbType.VarChar, theCountry.CapitalName));
				UpdateCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, theCountry.IsActive));
				UpdateCommand.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, theCountry.IsDeleted));
				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				UpdateCommand.CommandText = "pADM_Countries_Update";

				ExecuteStoredProcedure(UpdateCommand);

				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public int DeleteCountry(int countryId)
		{
			int ReturnValue = 0;

			using(SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@CountryID", SqlDbType.Int, countryId));
				UpdateCommand.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, 1));
				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				UpdateCommand.CommandText = "pADM_Countries_Update";
				
				ExecuteStoredProcedure(UpdateCommand);
				
				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
				
				return ReturnValue;
			}
		}
		#endregion
	}
}
