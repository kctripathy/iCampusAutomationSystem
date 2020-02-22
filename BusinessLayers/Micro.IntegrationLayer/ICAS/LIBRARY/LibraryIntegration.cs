using Micro.Commons;
using Micro.DataAccessLayer.ICAS.LIBRARY;
using Micro.Objects.ICAS.LIBRARY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Micro.IntegrationLayer.ICAS.LIBRARY
{
    public class LibraryIntegration
    {

        public static Book DataRowToObject(DataRow dRow)
        {

            Book theBookObj = new Book();
            theBookObj.BookID = (dRow["BookID"] == null ? 0 : int.Parse(dRow["BookID"].ToString()));

            
            theBookObj.BookType = dRow["BookType"].ToString();
            if (dRow["CategoryID"] != null) theBookObj.CategoryID = int.Parse(dRow["CategoryID"].ToString());
            theBookObj.CategoryCode = dRow["CategoryCode"].ToString();
            theBookObj.CategoryName = dRow["CategoryName"].ToString();
            theBookObj.SegmentID = ((dRow["SegmentID"] == null) ? 0 : (dRow["SegmentID"].ToString().Trim() == string.Empty ? 0 : int.Parse(dRow["SegmentID"].ToString())));
            theBookObj.SegmentName = dRow["SegmentName"].ToString();

            theBookObj.AuthorID = ((dRow["AuthorID"] == null) ? 0 : (dRow["AuthorID"].ToString().Trim() == string.Empty ? 0 : int.Parse(dRow["AuthorID"].ToString())));
            theBookObj.AuthorName = dRow["AuthorName"].ToString();
            theBookObj.PublisherID = ((dRow["PublisherID"] == null) ? 0 : (dRow["PublisherID"].ToString().Trim() == string.Empty ? 0 : int.Parse(dRow["PublisherID"].ToString())));
            theBookObj.PublisherName = dRow["PublisherName"].ToString();
            theBookObj.SupplierID = ((dRow["SupplierID"] == null) ? 0 : (dRow["SupplierID"].ToString().Trim() == string.Empty ? 0 : int.Parse(dRow["SupplierID"].ToString())));
            theBookObj.SupplierName = dRow["SupplierName"].ToString();
            theBookObj.Title = dRow["Title"].ToString();
            theBookObj.Pages = ((dRow["Pages"] == null) ? 0 : (dRow["Pages"].ToString().Trim() == string.Empty ? 0 : int.Parse(dRow["Pages"].ToString())));
            theBookObj.Edition = dRow["Edition"].ToString();
            theBookObj.AccessionNo = int.Parse(dRow["AccessionNo"].ToString());
            if (dRow["AccessionDate"] != null)
            {
                theBookObj.AccessionDate = DateTime.Parse(DateTime.Parse(dRow["AccessionDate"].ToString()).ToString(MicroConstants.DateFormat));
            }
            if (dRow["BookYear"] != null) theBookObj.BookYear = int.Parse(dRow["BookYear"].ToString());
            if (dRow["BookPrice"] != null) theBookObj.BookPrice = float.Parse(dRow["BookPrice"].ToString());
            theBookObj.VolumeNo = dRow["VolumeNo"].ToString();
            theBookObj.ClassNo = dRow["ClassNo"].ToString();
            theBookObj.Remarks = dRow["Remarks"].ToString();
            theBookObj.IBNNumber = dRow["IBNNo"].ToString();
            theBookObj.Remarks = dRow["Remarks"].ToString();
            theBookObj.BillNo = dRow["BillNo"].ToString();
            if (dRow["BillDate"] != null)
            {
                theBookObj.BillDate = DateTime.Parse(DateTime.Parse(dRow["BillDate"].ToString()).ToString(MicroConstants.DateFormat));
            }
            theBookObj.IsBookIssued = dRow["IsBookIssued"].ToString();
            theBookObj.Issued2UserID = ((dRow["Issued2UserID"] == null) ? 0 : (dRow["Issued2UserID"].ToString().Trim() == string.Empty ? 0 : int.Parse(dRow["Issued2UserID"].ToString())));
            theBookObj.Issued2UserReferenceID = ((dRow["UserReferenceID"] == null) ? 0 : (dRow["UserReferenceID"].ToString().Trim() == string.Empty ? 0 : int.Parse(dRow["UserReferenceID"].ToString())));
            theBookObj.IssuedToUserName = dRow["UserName"].ToString();
            theBookObj.Book_ImageURL_Small = dRow["Book_ImageURL_Small"].ToString();
            theBookObj.Book_ImageURL_Medium = dRow["Book_ImageURL_Medium"].ToString();
            theBookObj.Book_Image_URL_Big = dRow["Book_Image_URL_Big"].ToString();
            theBookObj.Book_PDF_URL = dRow["Book_PDF_URL"].ToString();
            theBookObj.BookStatus = dRow["BookStatus"].ToString();
            //theBookObj.IsActive = dRow["BookStatus"].ToString();
            //theBookObj.IsDeleted = dRow["BookStatus"].ToString();


            return theBookObj;
        }

        public static List<Book> GetBooksList()
        {
            List<Book> theBooksList = new List<Book>();
            DataTable theBooksTable = LibraryDataAccess.GetInstance.GetLibraryBooksList(false);
            foreach (DataRow dr in theBooksTable.Rows)
            {
                Book theBookObject = DataRowToObject(dr);
                theBooksList.Add(theBookObject);


            }
            return theBooksList;
        }

        public static List<Book> GetBooksList_Distinct()
        {
            List<Book> theBooksList = new List<Book>();
            DataTable theBooksTable = LibraryDataAccess.GetInstance.GetLibraryBooksList_Distinct();
            foreach (DataRow dr in theBooksTable.Rows)
            {
                Book theBookObject = DataRowToObject(dr);
                theBooksList.Add(theBookObject);


            }
            return theBooksList;
        }

        public static int GetBooks_Count()
        {
            int BookCount = 0;
            DataTable theBooksTable = LibraryDataAccess.GetInstance.GetLibraryBooks_Count();
            foreach (DataRow dr in theBooksTable.Rows)
            {
                BookCount = int.Parse(dr["TotalBooks"].ToString());
            }
            return BookCount;
        }

        public static void PopulateBookCategory(ref Book theBookObj)
        {
            DataTable dt = LibraryDataAccess.GetInstance.GetBookCategoryByID(theBookObj.CategoryID);
            foreach (DataRow dr in dt.Rows)
            {
                theBookObj.CategoryName = dr["CategoryDescription"].ToString();
                theBookObj.CategoryCode = dr["CategoryCode"].ToString();
            }
        }

        public static int InsertBook(Book b)
        {
            return LibraryDataAccess.GetInstance.InsertNewBook(b);
        }

        public static int UpdateBook(Book b)
        {
            return LibraryDataAccess.GetInstance.UpdateBook(b);
        }
        public static List<BookCategory> GetBook_Categories()
        {
            List<BookCategory> bookList = new List<BookCategory>();
            DataTable dt = LibraryDataAccess.GetInstance.GetBook_Categories();
            foreach (DataRow item in dt.Rows)
            {
                BookCategory b = new BookCategory();
                b.ID = int.Parse(item["CategoryID"].ToString());
                b.Name = item["CategoryName"].ToString();
                b.Code = item["CategoryCode"].ToString();
                bookList.Add(b);
            }
            return bookList;
        }


        public static List<Author> GetBook_Authors()
        {
            List<Author> bookAuthorList = new List<Author>();
            DataTable dt = LibraryDataAccess.GetInstance.GetBook_Authors();
            foreach (DataRow item in dt.Rows)
            {
                Author b = new Author();
                b.ID = int.Parse(item["AuthorID"].ToString());
                b.Name = item["Name"].ToString();
                bookAuthorList.Add(b);
            }
            return bookAuthorList;
        }

        public static List<Publisher> GetBook_Publishers()
        {
            List<Publisher> bookPublisherList = new List<Publisher>();
            DataTable dt = LibraryDataAccess.GetInstance.GetBook_Publishers();
            foreach (DataRow item in dt.Rows)
            {
                Publisher b = new Publisher();
                b.ID = int.Parse(item["PublisherID"].ToString());
                b.Name = item["Name"].ToString();
                bookPublisherList.Add(b);
            }
            return bookPublisherList;
        }

        public static List<Supplier> GetBook_Suppliers()
        {
            List<Supplier> bookSupplierList = new List<Supplier>();
            DataTable dt = LibraryDataAccess.GetInstance.GetBook_Suppliers();
            foreach (DataRow item in dt.Rows)
            {
                Supplier b = new Supplier();
                b.ID = int.Parse(item["SupplierID"].ToString());
                b.Name = item["Name"].ToString();
                bookSupplierList.Add(b);
            }
            return bookSupplierList;
        }

        public static List<BookSegment> GetBook_Segments()
        {
            //throw new NotImplementedException();
            List<BookSegment> BookSegmentList = new List<BookSegment>();
            DataTable dt = LibraryDataAccess.GetInstance.GetBook_BookSegments();
            foreach (DataRow item in dt.Rows)
            {
                BookSegment b = new BookSegment();
                b.ID = int.Parse(item["SegmentID"].ToString());
                b.Name = item["SegmentName"].ToString();
                BookSegmentList.Add(b);
            }
            return BookSegmentList;
        }


		public static int InsertBookTransaction_ISSUE(BookTransaction b)
		{
			return LibraryDataAccess.GetInstance.InsertBookTransaction_Issue(b);
		}
		public static int InsertBookTransaction_RECEIVE(BookTransaction b)
		{
			return LibraryDataAccess.GetInstance.InsertBookTransaction_Receive(b);
		}

		public static int InsertBookTransaction_MISSING(BookTransaction b)
		{
			return LibraryDataAccess.GetInstance.InsertBookTransaction_Missing(b);
		}

		public static int InsertBookTransaction_DAMAGED(BookTransaction b)
		{
			return LibraryDataAccess.GetInstance.InsertBookTransaction_Damaged(b);
		}
	}
}
