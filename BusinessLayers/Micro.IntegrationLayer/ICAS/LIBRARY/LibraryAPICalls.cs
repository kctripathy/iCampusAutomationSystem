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



        //public static LibrarySummary GetLibrarySummary()
        //{
        //    LibrarySummary librarySummary = new LibrarySummary();
        //    SqlDataReader reader = LibraryDataAccess.GetInstance.GetLibrarySummary();
        //    if (reader == null) return librarySummary;
        //    while (reader.Read())
        //    {
        //        librarySummary.totalBooks = (int)reader["TotalBooks"];
        //    }

        //    //Segment
        //    reader.NextResult();
        //    while (reader.Read())
        //    {
        //        librarySummary.countBooksBySegment.Add(new LibrarySummarySegment()
        //        {
        //            ID = (int)reader["ID"],
        //            Name = (string)reader["Name"],
        //            Count = (int)reader["Total"]
        //        });
        //    }

        //    //Category
        //    reader.NextResult();
        //    while (reader.Read())
        //    {
        //        librarySummary.countBooksByCategory.Add(new LibrarySummaryCategory()
        //        {
        //            ID = (int)reader["Id"],
        //            Name = (string)reader["Name"],
        //            Count = (int)reader["Total"]
        //        });
        //    }

        //    return librarySummary;
        //}
    }
}
