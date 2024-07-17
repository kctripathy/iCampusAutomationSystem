using Micro.Commons;
using Micro.DataAccessLayer.ICAS.LIBRARY;
using Micro.Objects.ICAS;
using Micro.Objects.ICAS.LIBRARY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Micro.IntegrationLayer.ICAS.LIBRARY
{
    public partial class LibraryIntegration
    {

        public static LibrarySummary GetLibrarySummary()
        {
            LibrarySummary librarySummary = new LibrarySummary();
            DataSet ds = LibraryDataAccess.GetInstance.GetLibrarySummary();
            if (ds == null) return librarySummary;

            //total records
            librarySummary.totalBooks = Int32.Parse(ds.Tables[0].Rows[0]["TotalBooks"].ToString());

            //segments
            List<LibrarySummarySegment> list = new List<LibrarySummarySegment>(); 
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                LibrarySummarySegment ls = new LibrarySummarySegment();
                ls.ID = Int32.Parse(dr["ID"].ToString());
                ls.Name = dr["Name"].ToString();
                ls.Count = Int32.Parse(dr["Total"].ToString());
                list.Add(ls);
            }
            librarySummary.countBooksBySegment = list;

            //segments
            List<LibrarySummaryCategory> list1 = new List<LibrarySummaryCategory>();
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                LibrarySummaryCategory ls = new LibrarySummaryCategory();
                ls.ID = Int32.Parse(dr["ID"].ToString());
                ls.Name = dr["Name"].ToString();
                ls.Count = Int32.Parse(dr["Total"].ToString());
                list1.Add(ls);
            }
            librarySummary.countBooksByCategory = list1;

            return librarySummary;
        }

        public static LibraryBook GetBookByID(long id)
        {
            DataRow dr = LibraryDataAccess.GetInstance.GetLibraryBookById(id);
            if (dr == null) return new LibraryBook();
            return DataRowToLibraryBookModel(dr);
        }


        public static BookViewModel GetLibraryBookByAccessionNumber(int acno)
        {
            DataRow dr = LibraryDataAccess.GetInstance.GetLibraryBookByAccessionNumber(acno);
            if (dr == null) return new BookViewModel();
            return DataRowToBookViewModelObject(dr);
        }

        public static long SaveBook(LibraryBook payload, int userId)
        {
            return LibraryDataAccess.GetInstance.SaveBook(payload, userId);
        }

        public static long DeleteBook(long id)
        {
            return LibraryDataAccess.GetInstance.DeleteBook(id);
        }

        public static long UpdateImageOrPDF(long id, string fileType = "pdf")
        {
            return LibraryDataAccess.GetInstance.UpdateImageOrPDF(id, fileType);
        }

        public static LibraryBook DataRowToLibraryBookModel(DataRow dRow)
        {

            LibraryBook lb = new LibraryBook();

            lb.BookID = (dRow["BookID"] == null ? 0 : int.Parse(dRow["BookID"].ToString()));
            lb.BookType = dRow["BookType"].ToString();
            lb.AccessionNo = dRow["AccessionNo"].ToString();
            lb.AccessionDate = dRow["AccessionDate"] == null? DateTime.Parse("1/1/1000") : DateTime.Parse(dRow["AccessionDate"].ToString());
            lb.Title = dRow["Title"].ToString();
            lb.BookStatus = dRow["BookStatus"].ToString();
            lb.BookPrice = float.Parse(dRow["BookPrice"].ToString());
            lb.AuthorID = int.Parse(dRow["AuthorID"].ToString());
            lb.PublisherID = int.Parse(dRow["PublisherID"].ToString());
            lb.SupplierID = int.Parse(dRow["SupplierID"].ToString());
            lb.SegmentID = int.Parse(dRow["SegmentID"].ToString());
            lb.CategoryID = int.Parse(dRow["CategoryID"].ToString());
            lb.SubjectID = (dRow["SubjectID"] == null || dRow["SubjectID"].ToString() == "") ? -1: int.Parse(dRow["SubjectID"].ToString());
            lb.ClassNo = dRow["ClassNo"].ToString();
            lb.Edition = dRow["Edition"].ToString();
            lb.BookYear = dRow["BookYear"].ToString();
            lb.IBNNo = dRow["IBNNo"].ToString();
            lb.VolumeNo = dRow["VolumeNo"] == null? "" : dRow["VolumeNo"].ToString();
            lb.Remarks = dRow["Remarks"].ToString();
            lb.Book_ImageURL_Small = dRow["Book_ImageURL_Small"].ToString();
            lb.Book_ImageURL_Medium = dRow["Book_ImageURL_Medium"].ToString();
            lb.Book_Image_URL_Big = dRow["Book_Image_URL_Big"].ToString();
            lb.Book_PDF_URL = dRow["Book_PDF_URL"].ToString();
            lb.Pages = dRow["Pages"] == null? 0: int.Parse(dRow["Pages"].ToString());
            lb.BookPrice = dRow["BookPrice"] == null? 0: float.Parse(dRow["BookPrice"].ToString());
            lb.BillNo = dRow["BillNo"].ToString();
            lb.BillDate = dRow["BillDate"] == null? DateTime.Parse("1/1/1000") : DateTime.Parse(dRow["BillDate"].ToString());
            lb.BookStatus = dRow["BookStatus"].ToString();
            lb.Issued2UserID = (dRow["Issued2UserID"] == null || dRow["Issued2UserID"].ToString() == "")? -1 : int.Parse(dRow["Issued2UserID"].ToString());
            lb.IsActive = Boolean.Parse(dRow["IsActive"].ToString());

            return lb;
        }


    }
}
