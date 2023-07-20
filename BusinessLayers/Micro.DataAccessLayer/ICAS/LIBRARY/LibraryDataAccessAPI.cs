using Micro.Objects.ICAS;
using Micro.Objects.ICAS.LIBRARY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Micro.DataAccessLayer.ICAS.LIBRARY
{
    public partial class LibraryDataAccess : AbstractData_SQLClient
    {
		public DataSet GetLibrarySummary()
		{
			DataSet ds = new DataSet();
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.CommandText = "[pAPI_GET_LIBRARY_SUMMARY]";
				ds = ExecuteGetDataset(Selectcommand);
			}
			return ds;
		}

		public DataTable GetLibraryBookCategoriesHavingBooks()
		{
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.CommandText = "[pAPI_GET_LIBRARY_CATEGORIES_HAVING_BOOKS]";
				return ExecuteGetDataTable(Selectcommand);
			}
		}

		public DataTable GetBook_BookSegments(bool onlyBooksHavingSegment)
		{
			//throw new NotImplementedException();
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				if (onlyBooksHavingSegment)
					Selectcommand.CommandText = "[pAPI_GET_LIBRARY_SEGMENTS_HAVING_BOOKS]";
				else
					Selectcommand.CommandText = "[pICAS_Library_BookSegments_SelectAll]";

				return ExecuteGetDataTable(Selectcommand);
			}
		}
		
		public DataTable GetLibraryBooksList(payload payload)
		{
			string segments = "";
			string categories = "";
			StringBuilder sb = new StringBuilder();
			if (payload.segments.Length > 0)
			{
				StringBuilder sbSegments = new StringBuilder(" s.SegmentID IN (");
				foreach (string item in payload.segments)
				{
					sbSegments.Append(item + ",");
				}
				segments = sbSegments.ToString().Substring(0, sbSegments.Length - 1) + ") ";
			}
			if (payload.categories.Length > 0)
			{
				var and2join = payload.segments.Length == 0 ? " " : " AND ";
				StringBuilder sbCategories = new StringBuilder(and2join + "c.CategoryID IN (");
				foreach (string item in payload.categories)
				{
					sbCategories.Append(item + ",");
				}
				categories = sbCategories.ToString().Substring(0, sbCategories.Length - 1) + ") ";
			}
			sb.Append(segments);
			sb.Append(categories);

			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.Parameters.Add(GetParameter("@searchText", SqlDbType.VarChar, payload.searchText));
				Selectcommand.Parameters.Add(GetParameter("@searchCriteria", SqlDbType.VarChar, sb.ToString()));
				Selectcommand.Parameters.Add(GetParameter("@pageNo", SqlDbType.Int, payload.pageNo));
				Selectcommand.Parameters.Add(GetParameter("@pageSize", SqlDbType.Int, payload.pageSize));
				Selectcommand.CommandText = "pAPI_GET_LIBRARY_BOOKS";
				return ExecuteGetDataTable(Selectcommand);
			}
		}


		public int SaveSegment(dynamic payload)
		{
			int RetValue = 0;
			int ID = int.Parse(payload.segmentID.ToString());
			string Name = payload.segmentName.ToString();

			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@returnValue", SqlDbType.Int, RetValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@id", SqlDbType.Int, ID));
				InsertCommand.Parameters.Add(GetParameter("@name", SqlDbType.VarChar, Name));
				InsertCommand.CommandText = "[pAPI_LIBRARY_SEGMENT_SAVE]";
				ExecuteStoredProcedure(InsertCommand);
				if (InsertCommand.Parameters[0].Value.ToString().Equals(string.Empty))
				{
					RetValue = 0;
				}
				else
				{
					RetValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
				}
			}

			return RetValue;
		}

		public int DeleteSegment(int id)
		{
            try
            {
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = string.Concat("DELETE FROM [LIB_MasterSegments] WHERE [SegmentID]=", id.ToString());
					ExecuteSqlStatement(cmd);
				}
				return id;
			}
            catch (Exception)
            {
				return -1;
            }
			
		}
	}
}
