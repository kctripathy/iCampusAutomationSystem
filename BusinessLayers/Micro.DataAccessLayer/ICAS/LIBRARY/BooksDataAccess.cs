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

		public DataTable GetBook_BookSegments()
		{
			//throw new NotImplementedException();
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.CommandText = "[pICAS_Library_BookSegments_SelectAll]";
				return ExecuteGetDataTable(Selectcommand);
			}
		}
		public DataTable GetBook_Categories()
		{
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.CommandText = "[pICAS_Library_BookCategories_SelectAll]";
				return ExecuteGetDataTable(Selectcommand);
			}
		}
		public DataTable GetBook_Authors()
		{
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.CommandText = "[pICAS_Library_Authors_SelectAll]";
				return ExecuteGetDataTable(Selectcommand);
			}
		}
		public DataTable GetBook_Publishers()
		{
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.CommandText = "[pICAS_Library_BookPublishers_SelectAll]";
				return ExecuteGetDataTable(Selectcommand);
			}
		}
		public DataTable GetBook_Suppliers()
		{
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.CommandText = "[pICAS_Library_BookSuppliers_SelectAll]";
				return ExecuteGetDataTable(Selectcommand);
			}
		}
		public DataTable GetLibraryBooksList_Distinct()
		{
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.CommandText = "[pICAS_Library_Books_SelectAllUnique]";
				return ExecuteGetDataTable(Selectcommand);
			}
		}
		public DataTable GetLibraryBooks_Count()
		{
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.CommandText = "[pICAS_Library_Books_Count]";
				return ExecuteGetDataTable(Selectcommand);
			}
		}
		public DataTable GetLibraryBooksList(bool showDeleted = false)
		{
			using (SqlCommand Selectcommand = new SqlCommand())
			{
				Selectcommand.CommandType = CommandType.StoredProcedure;
				Selectcommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //TODO:  Micro.Commons.Connection.LoggedOnUser.OfficeID));
				Selectcommand.CommandText = "pICAS_Library_Books_SelectAllByOfficeID";
				return ExecuteGetDataTable(Selectcommand);
			}
		}
		public int UpdateBook(Book b)
		{

			int ReturnValue = 0;
			using (SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@BOOK_ID", SqlDbType.BigInt, b.BookID));
				UpdateCommand.Parameters.Add(GetParameter("@AccessionNo", SqlDbType.Int, b.AccessionNo));
				UpdateCommand.Parameters.Add(GetParameter("@AccessionDate", SqlDbType.DateTime, b.AccessionDate));
				UpdateCommand.Parameters.Add(GetParameter("@BookType", SqlDbType.VarChar, b.BookType));
				UpdateCommand.Parameters.Add(GetParameter("@SegmentID", SqlDbType.Int, b.SegmentCode));
				UpdateCommand.Parameters.Add(GetParameter("@SegmentName", SqlDbType.VarChar, b.SegmentName));
				UpdateCommand.Parameters.Add(GetParameter("@AuthorID", SqlDbType.Int, b.AuthorID));
				UpdateCommand.Parameters.Add(GetParameter("@AuthorName", SqlDbType.VarChar, b.AuthorName));
				UpdateCommand.Parameters.Add(GetParameter("@PublisherID", SqlDbType.Int, b.PublisherID));
				UpdateCommand.Parameters.Add(GetParameter("@PublisherName", SqlDbType.VarChar, b.PublisherName));
				UpdateCommand.Parameters.Add(GetParameter("@SupplierID", SqlDbType.Int, b.SupplierID));
				UpdateCommand.Parameters.Add(GetParameter("@SupplierName", SqlDbType.VarChar, b.SupplierName));
				UpdateCommand.Parameters.Add(GetParameter("@Title", SqlDbType.VarChar, b.Title));
				UpdateCommand.Parameters.Add(GetParameter("@Edition", SqlDbType.VarChar, b.Edition));
				UpdateCommand.Parameters.Add(GetParameter("@BookYear", SqlDbType.Int, b.BookYear));
				UpdateCommand.Parameters.Add(GetParameter("@VolumeNo", SqlDbType.VarChar, b.VolumeNo));
				UpdateCommand.Parameters.Add(GetParameter("@Pages", SqlDbType.Int, b.Pages));
				UpdateCommand.Parameters.Add(GetParameter("@BookPrice", SqlDbType.Money, b.BookPrice));
				UpdateCommand.Parameters.Add(GetParameter("@ClassNo", SqlDbType.VarChar, b.ClassNo));
				UpdateCommand.Parameters.Add(GetParameter("@BillNo", SqlDbType.VarChar, b.BillNo));
				UpdateCommand.Parameters.Add(GetParameter("@BillDate", SqlDbType.DateTime, b.BillDate));
				UpdateCommand.Parameters.Add(GetParameter("@CategoryID", SqlDbType.Int, b.CategoryID));
				UpdateCommand.Parameters.Add(GetParameter("@CategoryName", SqlDbType.VarChar, b.CategoryName));
				UpdateCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, b.Remarks));
				UpdateCommand.Parameters.Add(GetParameter("@IBNNo", SqlDbType.VarChar, b.IBNNumber));
				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, b.AddedByUserID));
				UpdateCommand.Parameters.Add(GetParameter("@Book_ImageURL_Small", SqlDbType.VarChar, b.Book_ImageURL_Small));
				UpdateCommand.Parameters.Add(GetParameter("@Book_ImageURL_Medium", SqlDbType.VarChar, b.Book_ImageURL_Medium));
				UpdateCommand.Parameters.Add(GetParameter("@Book_Image_URL_Big", SqlDbType.VarChar, b.Book_Image_URL_Big));
				UpdateCommand.Parameters.Add(GetParameter("@Book_PDF_URL", SqlDbType.VarChar, b.Book_PDF_URL));
				UpdateCommand.Parameters.Add(GetParameter("@BookStatus", SqlDbType.VarChar, b.BookStatus));

				UpdateCommand.CommandText = "pICAS_Library_Book_Update";

				ExecuteStoredProcedure(UpdateCommand);

				if (UpdateCommand.Parameters[0].Value.ToString().Equals(string.Empty))
				{
					ReturnValue = 0;
				}
				else
				{
					ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
				}
			}

			return ReturnValue;
		}
		public int InsertNewBook(Book b)
		{

			int ReturnValueNewBookID = 0;
			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValueNewBookID)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@AccessionNo", SqlDbType.Int, b.AccessionNo));
				InsertCommand.Parameters.Add(GetParameter("@AccessionDate", SqlDbType.DateTime, b.AccessionDate));
				InsertCommand.Parameters.Add(GetParameter("@BookType", SqlDbType.VarChar, b.BookType));
				InsertCommand.Parameters.Add(GetParameter("@SegmentID", SqlDbType.Int, b.SegmentCode));
				InsertCommand.Parameters.Add(GetParameter("@SegmentName", SqlDbType.VarChar, b.SegmentName));
				InsertCommand.Parameters.Add(GetParameter("@AuthorID", SqlDbType.Int, b.AuthorID));
				InsertCommand.Parameters.Add(GetParameter("@AuthorName", SqlDbType.VarChar, b.AuthorName));
				InsertCommand.Parameters.Add(GetParameter("@PublisherID", SqlDbType.Int, b.PublisherID));
				InsertCommand.Parameters.Add(GetParameter("@PublisherName", SqlDbType.VarChar, b.PublisherName));
				InsertCommand.Parameters.Add(GetParameter("@SupplierID", SqlDbType.Int, b.SupplierID));
				InsertCommand.Parameters.Add(GetParameter("@SupplierName", SqlDbType.VarChar, b.SupplierName));
				InsertCommand.Parameters.Add(GetParameter("@BookPrice", SqlDbType.Money, b.BookPrice));
				InsertCommand.Parameters.Add(GetParameter("@Title", SqlDbType.VarChar, b.Title));
				InsertCommand.Parameters.Add(GetParameter("@Edition", SqlDbType.VarChar, b.Edition));
				InsertCommand.Parameters.Add(GetParameter("@BookYear", SqlDbType.Int, b.BookYear));
				InsertCommand.Parameters.Add(GetParameter("@VolumeNo", SqlDbType.VarChar, b.VolumeNo));
				InsertCommand.Parameters.Add(GetParameter("@Pages", SqlDbType.Int, b.Pages));
				InsertCommand.Parameters.Add(GetParameter("@ClassNo", SqlDbType.VarChar, b.ClassNo));
				InsertCommand.Parameters.Add(GetParameter("@BillNo", SqlDbType.VarChar, b.BillNo));
				InsertCommand.Parameters.Add(GetParameter("@BillDate", SqlDbType.DateTime, b.BillDate));
				InsertCommand.Parameters.Add(GetParameter("@CategoryID", SqlDbType.Int, b.CategoryID));
				InsertCommand.Parameters.Add(GetParameter("@CategoryName", SqlDbType.VarChar, b.CategoryName));
				InsertCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, b.Remarks));
				InsertCommand.Parameters.Add(GetParameter("@IBNNo", SqlDbType.VarChar, b.IBNNumber));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, b.AddedByUserID));
				InsertCommand.Parameters.Add(GetParameter("@Book_ImageURL_Small", SqlDbType.VarChar, b.Book_ImageURL_Small));
				InsertCommand.Parameters.Add(GetParameter("@Book_ImageURL_Medium", SqlDbType.VarChar, b.Book_ImageURL_Medium));
				InsertCommand.Parameters.Add(GetParameter("@Book_Image_URL_Big", SqlDbType.VarChar, b.Book_Image_URL_Big));
				InsertCommand.Parameters.Add(GetParameter("@Book_PDF_URL", SqlDbType.VarChar, b.Book_PDF_URL));

				InsertCommand.CommandText = "pICAS_Library_Book_InsertNew";

				ExecuteStoredProcedure(InsertCommand);

				if (InsertCommand.Parameters[0].Value.ToString().Equals(string.Empty))
				{
					ReturnValueNewBookID = 0;
				}
				else
				{
					ReturnValueNewBookID = int.Parse(InsertCommand.Parameters[0].Value.ToString());
				}
			}

			return ReturnValueNewBookID;
		}

		public int InsertBookTransaction_Issue(BookTransaction bTran)
		{

			int RetValue = 0;
			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, RetValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@TransactionDate", SqlDbType.DateTime, bTran.TransactionDate));
				InsertCommand.Parameters.Add(GetParameter("@TransactionType", SqlDbType.VarChar, bTran.TransactionType));
				InsertCommand.Parameters.Add(GetParameter("@Transaction2UserID", SqlDbType.Int, bTran.UserID));
				InsertCommand.Parameters.Add(GetParameter("@Transaction2UserType", SqlDbType.VarChar, bTran.UserType));
				InsertCommand.Parameters.Add(GetParameter("@TransactionFlag", SqlDbType.VarChar, "ISSUED"));
				InsertCommand.Parameters.Add(GetParameter("@TransactionBookID", SqlDbType.BigInt, bTran.BookID));
				InsertCommand.Parameters.Add(GetParameter("@ExpectedReceiveDate", SqlDbType.DateTime, bTran.ExpetedReturnDate));
				InsertCommand.CommandText = "[pICAS_Library_Book_Transactions_ISSUE]";
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

		public int InsertBookTransaction_Receive(BookTransaction bTran)
		{

			int ReturnValue = 0;
			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@TransactionID", SqlDbType.Int, bTran.TransactionID));
				//InsertCommand.Parameters.Add(GetParameter("@TransactionType", SqlDbType.VarChar, bTran.TransactionType));
				InsertCommand.Parameters.Add(GetParameter("@TransactionDate", SqlDbType.DateTime, bTran.TransactionDate));
				InsertCommand.Parameters.Add(GetParameter("@BookID", SqlDbType.Int, bTran.BookID));
				InsertCommand.Parameters.Add(GetParameter("@ReceivedFromUserID", SqlDbType.Int, bTran.UserID));
				InsertCommand.Parameters.Add(GetParameter("@UserType", SqlDbType.VarChar, bTran.UserType));
				InsertCommand.Parameters.Add(GetParameter("@ExpetedReturnDate", SqlDbType.DateTime, bTran.ExpetedReturnDate));
				InsertCommand.Parameters.Add(GetParameter("@ActualReturnDate", SqlDbType.DateTime, bTran.ActualReturnDate));
				InsertCommand.Parameters.Add(GetParameter("@FineAmount", SqlDbType.Money, bTran.FineAmount));
				InsertCommand.Parameters.Add(GetParameter("@FineAmount", SqlDbType.Money, bTran.FineAmount));
				InsertCommand.CommandText = "pICAS_Library_Book_Transactions_RECEIVE";
				ExecuteStoredProcedure(InsertCommand);
				if (InsertCommand.Parameters[0].Value.ToString().Equals(string.Empty))
				{
					ReturnValue = 0;
				}
				else
				{
					ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
				}
			}

			return ReturnValue;
		}

		public int InsertBookTransaction_Missing(BookTransaction b)
		{
			//throw new NotImplementedException();
			return 1;
		}

		public int InsertBookTransaction_Damaged(BookTransaction b)
		{
			//throw new NotImplementedException();
			return 1;
		}
	}
}
