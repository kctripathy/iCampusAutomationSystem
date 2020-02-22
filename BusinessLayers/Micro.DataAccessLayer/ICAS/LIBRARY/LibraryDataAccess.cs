using Micro.Commons;
using Micro.Objects.Administration;
using Micro.Objects.HumanResource;
using Micro.Objects.ICAS.LIBRARY;
using Micro.Objects.ICAS.STUDENT;
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

        #region code to make this as singleton class

        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static LibraryDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static LibraryDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LibraryDataAccess();
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

        public int LibraryBookTransactions(Transaction t)
        {
            int RetValue = 0;

            return RetValue;
        }



        public DataTable GetBookCategoryByID(int categoryId)
        {
            using (SqlCommand Selectcommand = new SqlCommand())
            {
                Selectcommand.CommandType = CommandType.StoredProcedure;
                Selectcommand.Parameters.Add(GetParameter("@CategoryID", SqlDbType.Int, categoryId));
                Selectcommand.CommandText = "pICAS_Library_GetBookCategoryByID";
                return ExecuteGetDataTable(Selectcommand);
            }
        }
        public int InsertAuthor(Author a)
        {
            int NewId = 0;

            return NewId;
        }
        public int InsertPublisher(Publisher p)
        {
            int NewID = 0;

            return NewID;
        }
        public int InsertSupplier(Supplier p)
        {
            int NewID = 0;

            return NewID;
        }
        public int UpdateAuthor(Author a)
        {
            int NewId = 0;

            return NewId;
        }
        public int UpdatePublisher(Publisher p)
        {
            int NewID = 0;

            return NewID;
        }
        public int UpdateSupplier(Supplier p)
        {
            int NewID = 0;

            return NewID;
        }
        public int DeleteBook(Book b)
        {
            int RetValue = 0;

            return RetValue;
        }
        public int DeletePublisher(Publisher p)
        {
            int NewID = 0;

            return NewID;
        }
        public int DeleteSupplier(Supplier p)
        {
            int NewID = 0;

            return NewID;
        }
        
        #endregion

    }
}
