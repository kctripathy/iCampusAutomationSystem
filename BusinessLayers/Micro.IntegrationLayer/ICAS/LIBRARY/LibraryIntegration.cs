using Micro.Commons;
using Micro.DataAccessLayer.ICAS.LIBRARY;
using Micro.Objects.ICAS;
using Micro.Objects.ICAS.LIBRARY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Micro.IntegrationLayer.ICAS.LIBRARY
{
    public partial class LibraryIntegration
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

        public static List<BookViewModel> GetLibraryBooksList(payload payload)
        {
            List<BookViewModel> theBooksList = new List<BookViewModel>();
            DataTable theBooksTable = LibraryDataAccess.GetInstance.GetLibraryBooksList(payload);
            foreach (DataRow dr in theBooksTable.Rows)
            {
                BookViewModel theBookObject = DataRowToBookViewModelObject(dr);
                theBooksList.Add(theBookObject);
            }
            return theBooksList;
        }

        public static int SaveSegment(dynamic payload)
        {
            return LibraryDataAccess.GetInstance.SaveSegment(payload);
        }

        public static int DeleteSegment(int id)
        {
            return LibraryDataAccess.GetInstance.DeleteSegment(id);
        }




        public static int SaveCategory(dynamic payload)
        {
            return LibraryDataAccess.GetInstance.SaveCategory(payload);
        }

        public static int DeleteCategory(int id)
        {
            return LibraryDataAccess.GetInstance.DeleteCategory(id);
        }



        public static int SaveAuthor(dynamic payload)
        {
            return LibraryDataAccess.GetInstance.SaveAuthor(payload);
        }

        public static int DeleteAuthor(int id)
        {
            return LibraryDataAccess.GetInstance.DeleteAuthor(id);
        }


        public static int SavePublisher(dynamic payload)
        {
            return LibraryDataAccess.GetInstance.SavePublisher(payload);
        }

        public static int DeletePublisher(int id)
        {
            return LibraryDataAccess.GetInstance.DeletePublisher(id);
        }

        public static int SaveSupplier(dynamic payload)
        {
            return LibraryDataAccess.GetInstance.SaveSupplier(payload);
        }

        public static int DeleteSupplier(int id)
        {
            return LibraryDataAccess.GetInstance.DeleteSupplier(id);
        }

        public static BookViewModel DataRowToBookViewModelObject(DataRow dRow)
        {
            
            BookViewModel theBookObj = new BookViewModel();

            theBookObj.BookID = (dRow["BookID"] == null ? 0 : int.Parse(dRow["BookID"].ToString()));
            theBookObj.BookType = dRow["BookType"].ToString();
            theBookObj.AccessionNo = dRow["AccessionNo"].ToString();
            theBookObj.AccessionDate = DateTime.Parse(dRow["AccessionDate"].ToString());
            theBookObj.Title = dRow["Title"].ToString();
            theBookObj.BookStatus = dRow["BookStatus"].ToString();
            theBookObj.BookPrice = float.Parse(dRow["BookPrice"].ToString());

            theBookObj.AuthorID = int.Parse(dRow["AuthorID"].ToString());
            theBookObj.Author = dRow["Author"].ToString();

            theBookObj.PublisherID = int.Parse(dRow["PublisherID"].ToString());
            theBookObj.Publisher = dRow["Publisher"].ToString();

            theBookObj.SupplierID = int.Parse(dRow["SupplierID"].ToString());
            theBookObj.Supplier = dRow["Supplier"].ToString();

            theBookObj.CategoryID = int.Parse(dRow["CategoryID"].ToString());
            theBookObj.CategoryCode = dRow["CategoryCode"].ToString();
            theBookObj.Category = dRow["CategoryName"].ToString();

            theBookObj.SegmentID = int.Parse(dRow["SegmentID"].ToString());
            theBookObj.Segment = dRow["SegmentName"].ToString();
             
            theBookObj.IsActive = Boolean.Parse(dRow["IsActive"].ToString());
            
            return theBookObj;
        }

        public static List<BookViewModel> GetBooksListPage(PagingParameterModel pagingParameterModel)
        {
            List<BookViewModel> theBooksList = new List<BookViewModel>();
            DataTable theBooksTable = LibraryDataAccess.GetInstance.GetBooksListPage(pagingParameterModel);
            foreach (DataRow dr in theBooksTable.Rows)
            {
                BookViewModel theBookObject = DataRowToBookViewModelObject(dr);
                theBooksList.Add(theBookObject);
            }
            return theBooksList;
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
        public static List<BookCategory> GetBook_Categories(bool havingBooks)
        {
            DataTable dt;
            List<BookCategory> list = new List<BookCategory>();
            
            if (havingBooks)
                dt = LibraryDataAccess.GetInstance.GetLibraryBookCategoriesHavingBooks();
            else
                dt = LibraryDataAccess.GetInstance.GetBook_Categories();

            foreach (DataRow item in dt.Rows)
            {
                BookCategory b = new BookCategory();
                b.ID = int.Parse(item["CategoryID"].ToString());
                b.Name = item["CategoryName"].ToString();
                b.Code = item["CategoryCode"].ToString();
                list.Add(b);
            }
            return list;
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
            List<Author> list = new List<Author>();
            DataTable dt = LibraryDataAccess.GetInstance.GetBook_Authors();
            foreach (DataRow item in dt.Rows)
            {
                Author b = new Author();
                b.ID = int.Parse(item["AuthorID"].ToString());
                b.Name = item["Name"].ToString();
                b.Address = item["Address"]==null? "" : item["Address"].ToString();
                b.City = item["City"] == null? "" : item["City"].ToString();
                b.State = item["State"] == null? "" : item["State"].ToString();
                b.Email = item["Email"] == null? "" : item["Email"].ToString();
                b.Phone = item["Phone"] == null? "" : item["Phone"].ToString();
                b.IsActive = item["isActive"].ToString() == "" ? true : bool.Parse(item["isActive"].ToString());
                list.Add(b);
            }
            return list;
        }

        public static List<Publisher> GetBook_Publishers()
        {
            List<Publisher> list = new List<Publisher>();
            DataTable dt = LibraryDataAccess.GetInstance.GetBook_Publishers();
            foreach (DataRow item in dt.Rows)
            {
                Publisher b = new Publisher();
                b.ID = int.Parse(item["PublisherID"].ToString());
                b.Name = item["Name"].ToString();
                b.Address = item["Address"] == null ? "" : item["Address"].ToString();
                b.City = item["City"] == null ? "" : item["City"].ToString();
                b.State = item["State"] == null ? "" : item["State"].ToString();
                b.Email = item["Email"] == null ? "" : item["Email"].ToString();
                b.Phone = item["Phone"] == null ? "" : item["Phone"].ToString();
                b.ContactPersonName = item["ContactPersonName"] == null ? "" : item["ContactPersonName"].ToString();
                b.IsActive = item["isActive"].ToString() == ""? true :  bool.Parse(item["isActive"].ToString());
                list.Add(b);
            }
            return list;
        }

        public static List<Supplier> GetBook_Suppliers()
        {
            List<Supplier> list = new List<Supplier>();
            DataTable dt = LibraryDataAccess.GetInstance.GetBook_Suppliers();
            foreach (DataRow item in dt.Rows)
            {
                Supplier b = new Supplier();
                b.ID = int.Parse(item["SupplierID"].ToString());
                b.Name = item["Name"].ToString();
                b.Address = item["Address"] == null ? "" : item["Address"].ToString();
                b.City = item["City"] == null ? "" : item["City"].ToString();
                b.State = item["State"] == null ? "" : item["State"].ToString();
                b.Email = item["Email"] == null ? "" : item["Email"].ToString();
                b.Phone = item["Phone"] == null ? "" : item["Phone"].ToString();
                b.ContactPersonName = item["ContactPersonName"] == null ? "" : item["ContactPersonName"].ToString();
                b.IsActive = item["isActive"].ToString() == "" ? true : bool.Parse(item["isActive"].ToString());
                list.Add(b);
            }
            return list;
        }

        public static List<BookSegment> GetBook_Segments(bool onlyBooksHavingSegment)
        {
            //throw new NotImplementedException();
            List<BookSegment> BookSegmentList = new List<BookSegment>();


            DataTable dt = LibraryDataAccess.GetInstance.GetBook_BookSegments(onlyBooksHavingSegment);
            

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
