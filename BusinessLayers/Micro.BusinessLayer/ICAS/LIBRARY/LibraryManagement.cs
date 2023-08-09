using Micro.IntegrationLayer.ICAS.LIBRARY;
using Micro.Objects.ICAS;
using Micro.Objects.ICAS.LIBRARY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Micro.BusinessLayer.ICAS.LIBRARY
{
    public partial class LibraryManagement
    {
        #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static LibraryManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static LibraryManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LibraryManagement();
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


        #region Methods & Implementation
        public List<Book> GetBooksList(bool willRefresh = false)
        {
            string UniqueKey = "GetBooksList";
            List<Book> ListOfBooks;
            if (willRefresh.Equals(true))
            {
                ListOfBooks = LibraryIntegration.GetBooksList();
                HttpRuntime.Cache[UniqueKey] = ListOfBooks;
                return (List<Book>)(HttpRuntime.Cache[UniqueKey]);
            }
            if (HttpRuntime.Cache[UniqueKey] == null)
            {
                ListOfBooks = LibraryIntegration.GetBooksList();
                HttpRuntime.Cache[UniqueKey] = ListOfBooks;
            }
            return (List<Book>)(HttpRuntime.Cache[UniqueKey]);

        }

        public List<BookViewModel> GetBooksListPage(PagingParameterModel pagingParameterModel)
        {
            return LibraryIntegration.GetBooksListPage(pagingParameterModel);
        }

        public List<Book> GetBooksList_DistinctRecords()
        {
            List<Book> ListOfUniqueBooks =  this.GetBooksList();

            List<Book> xyz = (from abc in ListOfUniqueBooks
                       select abc).Distinct().ToList();

            return xyz; // as List<Book>;

        }

        public int GetBooks_NewAccessionNumber(ref Book lastAddedBook )
        {
            int NewAccessionNo = 0;
            var newObj = LibraryIntegration.GetBooksList().OrderBy(a=>a.AccessionNo).LastOrDefault();
            if (newObj==null)
            {
                NewAccessionNo = 1;
            }
            else
            {
                NewAccessionNo = ((Book)newObj).AccessionNo + 1;
                lastAddedBook.CategoryCode = ((Book)newObj).CategoryCode;
                lastAddedBook.CategoryID = ((Book)newObj).CategoryID;
                lastAddedBook.CategoryName = ((Book)newObj).CategoryName;
                lastAddedBook.SegmentCode = ((Book)newObj).SegmentCode;
            }           
            return NewAccessionNo;
        }

        public List<BookViewModel> GetLibraryBooksList(payload payload)
        {
            return LibraryIntegration.GetLibraryBooksList(payload);
        }

        public int GetBooks_Count()
        {
            return LibraryIntegration.GetBooks_Count();
        }
        public int InsertBook(Book b)
        {
            return LibraryIntegration.InsertBook(b);
        }
        public int UpdateBook(Book b)
        {
            return LibraryIntegration.UpdateBook(b);
        }
        #endregion

        public List<BookCategory> GetBook_Categories(bool havingBooks = false)
        {
            return LibraryIntegration.GetBook_Categories(havingBooks);
        }

        public List<Author> GetBook_Authors()
        {
            return LibraryIntegration.GetBook_Authors();
        }

        public List<Supplier> GetBook_Suppliers()
        {
            return LibraryIntegration.GetBook_Suppliers();
        }

        public List<Publisher> GetBook_Publishers()
        {
            return LibraryIntegration.GetBook_Publishers();
        }

        public List<BookSegment> GetBook_BookSegments(bool onlyBooksHavingSegment = false)
        {
            return LibraryIntegration.GetBook_Segments(onlyBooksHavingSegment);
        }
		public int InsertBookTransaction_ISSUE(BookTransaction b)
		{
			return LibraryIntegration.InsertBookTransaction_ISSUE(b);
		}

        public int SaveSegment(dynamic payload)
        {
            return LibraryIntegration.SaveSegment(payload);
        }

        public int DeleteSegment(int id)
        {
            return LibraryIntegration.DeleteSegment(id);
        }


        public int SaveCategory(dynamic payload)
        {
            return LibraryIntegration.SaveCategory(payload);
        }

        public int DeleteCategory(int id)
        {
            return LibraryIntegration.DeleteCategory(id);
        }


        public int SaveAuthor(dynamic payload)
        {
            return LibraryIntegration.SaveAuthor(payload);
        }
        public int DeleteAuthor(int id)
        {
            return LibraryIntegration.DeleteAuthor(id);
        }


        public int SavePublisher(dynamic payload)
        {
            return LibraryIntegration.SavePublisher(payload);
        }
        public int DeletePublisher(int id)
        {
            return LibraryIntegration.DeletePublisher(id);
        }

        public int SaveSupplier(dynamic payload)
        {
            return LibraryIntegration.SaveSupplier(payload);
        }
        public int DeleteSupplier(int id)
        {
            return LibraryIntegration.DeleteSupplier(id);
        }


        public int InsertBookTransaction_RECEIVE(BookTransaction b)
		{
			return LibraryIntegration.InsertBookTransaction_RECEIVE(b);
		}
		public int InsertBookTransaction_MISSING(BookTransaction b)
		{
			return LibraryIntegration.InsertBookTransaction_MISSING(b);
		}
		public int InsertBookTransaction_DAMAGED(BookTransaction b)
		{
			return LibraryIntegration.InsertBookTransaction_DAMAGED(b);
		}

		public List<BookTransaction> GetBookTransactionList()
		{
			throw new NotImplementedException();
		}

        public List<LibrarySettings> GetLibrarySettings()
        {
            return LibraryIntegration.GetLibrarySettings();
        }

        public int SaveLibrarySettings(List<LibrarySettingInput> payload)
        {
            return LibraryIntegration.SaveLibrarySettings(payload);
        }


        public int SaveLibraryTransaction(LibraryTransactionInputPayLoad payload)
        {
            return LibraryIntegration.SaveLibraryTransaction(payload);
        }

        public List<LibraryTransaction> GetLibraryTransactions(DateTime? fromDate = null, DateTime? toDate = null, int? userId = null, string tranType = "I", int pageNo = 1, int pageSize = 50)
        {
            return LibraryIntegration.GetLibraryTransactions(fromDate, toDate, userId, tranType, pageNo, pageSize);
        }

    }
}
