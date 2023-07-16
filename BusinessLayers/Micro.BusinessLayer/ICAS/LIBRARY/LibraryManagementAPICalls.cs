using Micro.IntegrationLayer.ICAS.LIBRARY;
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
    }
}
