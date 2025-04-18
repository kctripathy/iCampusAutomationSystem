﻿using Micro.IntegrationLayer.ICAS.LIBRARY;
using Micro.Objects.ICAS.LIBRARY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.BusinessLayer.ICAS.LIBRARY
{
    public partial class LibraryManagement
    {
        public LibrarySummary GetLibrarySummary()
        {
            return LibraryIntegration.GetLibrarySummary();
        }

        public LibraryBook GetBookByID(long id)
        {
            return LibraryIntegration.GetBookByID(id);
        }

        public BookViewModel GetBookByAccessionNo(int acno)
        {
            return LibraryIntegration.GetLibraryBookByAccessionNumber(acno);
        }

        public long SaveBook(LibraryBook payload, int userId)
        {
            return LibraryIntegration.SaveBook(payload, userId);
        }

        public long DeleteBook(long id)
        {
            return LibraryIntegration.DeleteBook(id);
        }

        public long UpdateImageOrPDF(long id, string fileType = "pdf")
        {
            return LibraryIntegration.UpdateImageOrPDF(id, fileType);
        }
    }
}
