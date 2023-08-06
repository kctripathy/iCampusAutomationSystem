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
			string statuses = "";
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
			if (payload.status.Length > 0 && payload.status.Length != 4)
			{
				var and2join = payload.segments.Length == 0 && payload.categories.Length == 0 ? " " : " AND ";
				StringBuilder sbStatus = new StringBuilder(and2join + " b.BookStatus IN (");
				foreach (string item in payload.status)
				{
					sbStatus.Append("'" +item + "',");
				}
				statuses = sbStatus.ToString().Substring(0, sbStatus.Length - 1) + ") ";
			}

			sb.Append(segments);
			sb.Append(categories);
			sb.Append(statuses);

			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.Parameters.Add(GetParameter("@searchText", SqlDbType.VarChar, payload.searchText));
				Selectcommand.Parameters.Add(GetParameter("@searchCriteria", SqlDbType.VarChar, sb.ToString()));
				Selectcommand.Parameters.Add(GetParameter("@pageNo", SqlDbType.Int, payload.pageNo));
				Selectcommand.Parameters.Add(GetParameter("@pageSize", SqlDbType.Int, payload.pageSize));
				Selectcommand.CommandText = "pAPI_GET_LIBRARY_BOOKS_NEW";
				return ExecuteGetDataTable(Selectcommand);
			}
		}

		public DataRow GetLibraryBookById(long id)
        {
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@id", SqlDbType.BigInt, id));
				SelectCommand.CommandText = "[pAPI_LIBRARY_BOOKS_GET_BY_ID]";
				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public DataRow GetLibraryBookByAccessionNumber(int acno)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@accessionNo", SqlDbType.Int, acno));
				SelectCommand.CommandText = "[pAPI_LIBRARY_BOOKS_GET_BY_ACNO]";
				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public long SaveBook(LibraryBook payload, int userId)
		{
			long RetValue = 0;

			using (SqlCommand Command = new SqlCommand())
			{
				Command.CommandType = CommandType.StoredProcedure;
				Command.Parameters.Add(GetParameter("@returnValue", SqlDbType.Int, RetValue)).Direction = ParameterDirection.Output;
				Command.Parameters.Add(GetParameter("@BookID", SqlDbType.BigInt, payload.BookID));
				Command.Parameters.Add(GetParameter("@BookType", SqlDbType.VarChar, payload.BookType));
				Command.Parameters.Add(GetParameter("@Title", SqlDbType.VarChar, payload.Title));
				Command.Parameters.Add(GetParameter("@SegmentID", SqlDbType.Int, payload.SegmentID));
				Command.Parameters.Add(GetParameter("@AuthorID", SqlDbType.Int, payload.AuthorID));
				Command.Parameters.Add(GetParameter("@PublisherID", SqlDbType.Int, payload.PublisherID));
				Command.Parameters.Add(GetParameter("@SupplierID", SqlDbType.Int, payload.SupplierID));
				Command.Parameters.Add(GetParameter("@SubjectID", SqlDbType.Int, payload.SubjectID));
				Command.Parameters.Add(GetParameter("@CategoryID", SqlDbType.Int, payload.CategoryID));
				Command.Parameters.Add(GetParameter("@Issued2UserID", SqlDbType.Int, payload.Issued2UserID));
				Command.Parameters.Add(GetParameter("@AccessionNo", SqlDbType.Int, int.Parse(payload.AccessionNo)));
				Command.Parameters.Add(GetParameter("@AccessionDate", SqlDbType.DateTime, payload.AccessionDate));
				Command.Parameters.Add(GetParameter("@ClassNo", SqlDbType.VarChar, payload.ClassNo));
				Command.Parameters.Add(GetParameter("@Edition", SqlDbType.VarChar, payload.Edition));
				Command.Parameters.Add(GetParameter("@BookYear", SqlDbType.Int, int.Parse(payload.BookYear)));
				Command.Parameters.Add(GetParameter("@VolumeNo", SqlDbType.VarChar, payload.VolumeNo));
				Command.Parameters.Add(GetParameter("@Pages", SqlDbType.Int, payload.Pages));
				Command.Parameters.Add(GetParameter("@BookPrice", SqlDbType.Money, payload.BookPrice));
				Command.Parameters.Add(GetParameter("@BillNo", SqlDbType.VarChar, payload.BillNo));
				Command.Parameters.Add(GetParameter("@BillDate", SqlDbType.DateTime, payload.BillDate));
				Command.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, payload.Remarks));
				Command.Parameters.Add(GetParameter("@IBNNo", SqlDbType.VarChar, payload.IBNNo));
				Command.Parameters.Add(GetParameter("@Book_ImageURL_Small", SqlDbType.VarChar, payload.Book_ImageURL_Small));
				Command.Parameters.Add(GetParameter("@Book_ImageURL_Medium", SqlDbType.VarChar, payload.Book_ImageURL_Medium));
				Command.Parameters.Add(GetParameter("@Book_Image_URL_Big", SqlDbType.VarChar, payload.Book_Image_URL_Big));
				Command.Parameters.Add(GetParameter("@Book_PDF_URL", SqlDbType.VarChar, payload.Book_PDF_URL));
				Command.Parameters.Add(GetParameter("@BookStatus", SqlDbType.VarChar, payload.BookStatus));
				Command.Parameters.Add(GetParameter("@IsActive", SqlDbType.Int, payload.IsActive? 1: 0));
				Command.Parameters.Add(GetParameter("@userId", SqlDbType.Int, userId));

				Command.CommandText = "[pAPI_LIBRARY_BOOK_SAVE]";
				ExecuteStoredProcedure(Command);
				if (Command.Parameters[0].Value.ToString().Equals(string.Empty))
				{
					RetValue = -2;
				}
				else
				{
					RetValue = long.Parse(Command.Parameters[0].Value.ToString());
				}
			}

			return RetValue;
		}

		public long DeleteBook(long id)
		{
			try
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = string.Concat("DELETE FROM [LIB_Master_Books] WHERE [BookID]=", id.ToString());
					ExecuteSqlStatement(cmd);
				}
				return id;
			}
			catch (Exception)
			{
				return -1;
			}
		}

		public long UpdateImageOrPDF(long id, string fileType = "pdf")
		{
			string SQL_STMT = string.Concat("UPDATE [LIB_Master_Books] SET Book_PDF_URL='Y' WHERE [BookID]=", id.ToString());

			if (fileType == "image") SQL_STMT = string.Concat("UPDATE [LIB_Master_Books] SET Book_ImageURL_Small='Y' WHERE [BookID]=", id.ToString());

			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = SQL_STMT;
				ExecuteSqlStatement(cmd);
			}
			return id;
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


		public int SaveCategory(dynamic payload)
		{
			int RetValue = 0;
			int ID = int.Parse(payload.categoryID.ToString());
			string Code = payload.categoryCode.ToString();
			string Name = payload.categoryName.ToString();

			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@returnValue", SqlDbType.Int, RetValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@id", SqlDbType.Int, ID));
				InsertCommand.Parameters.Add(GetParameter("@code", SqlDbType.VarChar, Code));
				InsertCommand.Parameters.Add(GetParameter("@name", SqlDbType.VarChar, Name));
				InsertCommand.CommandText = "[pAPI_LIBRARY_CATEGORY_SAVE]";
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

		public int DeleteCategory(int id)
		{
			try
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = string.Concat("DELETE FROM [LIB_MasterCategories] WHERE [CategoryID]=", id.ToString());
					ExecuteSqlStatement(cmd);
				}
				return id;
			}
			catch (Exception)
			{
				return -1;
			}
		}



		public int SaveAuthor(dynamic payload)
		{
			int RetValue = 0;
			int ID = int.Parse(payload.ID.ToString());
			string Name = payload.Name.ToString();
			string Address = payload.Address.ToString();
			string City = payload.City.ToString();
			int StateId = int.Parse(payload.StateId.ToString());
			string Email = payload.Email.ToString();
			string Phone = payload.Phone.ToString();


			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@returnValue", SqlDbType.Int, RetValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@id", SqlDbType.Int, ID));
				InsertCommand.Parameters.Add(GetParameter("@name", SqlDbType.VarChar, Name));
				InsertCommand.Parameters.Add(GetParameter("@address", SqlDbType.VarChar, Address));
				InsertCommand.Parameters.Add(GetParameter("@city", SqlDbType.VarChar, City));
				InsertCommand.Parameters.Add(GetParameter("@stateId", SqlDbType.Int, StateId));
				InsertCommand.Parameters.Add(GetParameter("@email", SqlDbType.VarChar, Email));
				InsertCommand.Parameters.Add(GetParameter("@phone", SqlDbType.VarChar, Phone));
				InsertCommand.CommandText = "[pAPI_LIBRARY_AUTHOR_SAVE]";
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

		public int DeleteAuthor(int id)
		{
			try
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = string.Concat("DELETE FROM [LIB_MasterAuthors] WHERE [AuthorID]=", id.ToString());
					ExecuteSqlStatement(cmd);
				}
				return id;
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("conflicted with the REFERENCE constraint"))
					return -1;
				else
					return -2;
			}
		}



		public int SavePublisher(dynamic payload)
		{
			int RetValue = 0;
			int ID = int.Parse(payload.ID.ToString());
			string Name = payload.Name.ToString();
			string Address = payload.Address.ToString();
			string City = payload.City.ToString();
			int StateId = int.Parse(payload.StateId.ToString());
			string Email = payload.Email.ToString();
			string Phone = payload.Phone.ToString();
			string ContactPersonName = payload.ContactPersonName.ToString();


			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@returnValue", SqlDbType.Int, RetValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@id", SqlDbType.Int, ID));
				InsertCommand.Parameters.Add(GetParameter("@name", SqlDbType.VarChar, Name));
				InsertCommand.Parameters.Add(GetParameter("@address", SqlDbType.VarChar, Address));
				InsertCommand.Parameters.Add(GetParameter("@city", SqlDbType.VarChar, City));
				InsertCommand.Parameters.Add(GetParameter("@stateId", SqlDbType.Int, StateId));
				InsertCommand.Parameters.Add(GetParameter("@email", SqlDbType.VarChar, Email));
				InsertCommand.Parameters.Add(GetParameter("@phone", SqlDbType.VarChar, Phone));
				InsertCommand.Parameters.Add(GetParameter("@contactPersonaName", SqlDbType.VarChar, ContactPersonName));
				InsertCommand.CommandText = "[pAPI_LIBRARY_PUBLISHER_SAVE]";
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

		public int DeletePublisher(int id)
		{
			try
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = string.Concat("DELETE FROM [LIB_MasterPublishers] WHERE [PublisherId]=", id.ToString());
					ExecuteSqlStatement(cmd);
				}
				return id;
			}
			catch (Exception)
			{
				return -1;
			}
		}


		public int SaveSupplier(dynamic payload)
		{
			int RetValue = 0;
			int ID = int.Parse(payload.ID.ToString());
			string Name = payload.Name.ToString();
			string Address = payload.Address.ToString();
			string City = payload.City.ToString();
			int StateId = int.Parse(payload.StateId.ToString());
			string Email = payload.Email.ToString();
			string Phone = payload.Phone.ToString();
			string ContactPersonName = payload.ContactPersonName.ToString();


			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@returnValue", SqlDbType.Int, RetValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@id", SqlDbType.Int, ID));
				InsertCommand.Parameters.Add(GetParameter("@name", SqlDbType.VarChar, Name));
				InsertCommand.Parameters.Add(GetParameter("@address", SqlDbType.VarChar, Address));
				InsertCommand.Parameters.Add(GetParameter("@city", SqlDbType.VarChar, City));
				InsertCommand.Parameters.Add(GetParameter("@stateId", SqlDbType.Int, StateId));
				InsertCommand.Parameters.Add(GetParameter("@email", SqlDbType.VarChar, Email));
				InsertCommand.Parameters.Add(GetParameter("@phone", SqlDbType.VarChar, Phone));
				InsertCommand.Parameters.Add(GetParameter("@contactPersonaName", SqlDbType.VarChar, ContactPersonName));
				InsertCommand.CommandText = "[pAPI_LIBRARY_SUPPLIER_SAVE]";
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

		public int DeleteSupplier(int id)
		{
			try
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = string.Concat("DELETE FROM [LIB_MasterSuppliers] WHERE [SupplierId]=", id.ToString());
					ExecuteSqlStatement(cmd);
				}
				return id;
			}
			catch (Exception)
			{
				return -1;
			}
		}




		public DataTable GetLibrarySettings()
		{
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.CommandText = "pAPI_LIBRARY_SETTINGS_GET_ALL";
				return ExecuteGetDataTable(Selectcommand);
			}
		}

		public int SaveLibrarySettings(List<LibrarySettingInput> payload)
		{
			int RetValue = 0;
			
			string effective_date = payload.First(s => s.key == "rule_effective_from_date").value;
			var newList = payload.Where(s => s.key != "rule_effective_from_date");

            foreach (LibrarySettingInput item in newList)
            {
				using (SqlCommand InsertCommand = new SqlCommand())
				{
					InsertCommand.CommandType = CommandType.StoredProcedure;
					InsertCommand.Parameters.Add(GetParameter("@key_name", SqlDbType.VarChar, item.key));
					InsertCommand.Parameters.Add(GetParameter("@key_value", SqlDbType.VarChar, item.value));
					InsertCommand.Parameters.Add(GetParameter("@effective_date", SqlDbType.Date, DateTime.Parse(effective_date)));
					InsertCommand.CommandText = "[pAPI_LIBRARY_SETTINGS_SAVE]";
					ExecuteStoredProcedure(InsertCommand);
					RetValue++;
				}
			}
			return RetValue;
		}


		public int SaveLibraryTransaction(LibraryTransactionInputPayLoad payload)
		{
			int RetValue = 0;
            foreach (Int64 BOOK_ID in payload.BOOK_ID_LIST)
            {
				using (SqlCommand InsertCommand = new SqlCommand())
				{
					InsertCommand.CommandType = CommandType.StoredProcedure;
					InsertCommand.Parameters.Add(GetParameter("@RETURN_VALUE", SqlDbType.Int, RetValue)).Direction = ParameterDirection.Output;
					InsertCommand.Parameters.Add(GetParameter("@TRAN_ID", SqlDbType.Int, payload.TRAN_ID));
					InsertCommand.Parameters.Add(GetParameter("@USER_REF_ID", SqlDbType.Int, payload.USER_REF_ID));
					InsertCommand.Parameters.Add(GetParameter("@BOOK_ID", SqlDbType.BigInt, BOOK_ID));
					InsertCommand.Parameters.Add(GetParameter("@BOOK_ISSUE_DATE", SqlDbType.DateTime, payload.BOOK_ISSUE_DATE));
					InsertCommand.Parameters.Add(GetParameter("@BOOK_RETURN_DATE", SqlDbType.DateTime, payload.BOOK_RETURN_DATE));
					InsertCommand.Parameters.Add(GetParameter("@FINE_AMOUNT_PER_DAY", SqlDbType.Decimal, payload.FINE_AMOUNT_PER_DAY));
					InsertCommand.Parameters.Add(GetParameter("@FINE_AMOUNT_PAID", SqlDbType.Decimal, payload.FINE_AMOUNT_PAID));
					InsertCommand.Parameters.Add(GetParameter("@RECEIPT_NO", SqlDbType.VarChar, payload.RECEIPT_NO));
					InsertCommand.Parameters.Add(GetParameter("@NO_OF_DAYS_CAN_KEEP", SqlDbType.Int, payload.NO_OF_DAYS_CAN_KEEP));
					InsertCommand.Parameters.Add(GetParameter("@TRAN_BY_USER_ID", SqlDbType.Int, payload.TRANSACTION_BY_USER_ID));

					InsertCommand.CommandText = "[pAPI_LIBRARY_TRANSACTION_SAVE]";
					ExecuteStoredProcedure(InsertCommand);
					if (InsertCommand.Parameters[0].Value.ToString().Equals(string.Empty))
					{
						RetValue = -1;
					}
					else
					{
						RetValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
					}
				}
			}
			return RetValue;
		}

		public DataTable GetLibraryTransactions(DateTime? fromDate = null, DateTime? toDate = null, int? userId = null)
		{
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				if (fromDate != null)
                {
					Selectcommand.Parameters.Add(GetParameter("@FROM_DATE", SqlDbType.DateTime, fromDate));
                }
				if (toDate != null)
				{
					Selectcommand.Parameters.Add(GetParameter("@TO_DATE", SqlDbType.DateTime, toDate));
				}
				if (userId != null)
				{
					Selectcommand.Parameters.Add(GetParameter("@USER_ID", SqlDbType.Int, userId));
				}

				Selectcommand.CommandText = "pAPI_LIBRARY_TRANSACTION_GET";
				return ExecuteGetDataTable(Selectcommand);
			}
		}
	}
}
