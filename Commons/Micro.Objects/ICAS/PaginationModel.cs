using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Objects.ICAS
{
    public class PagingParameterModel
    {
        const int maxPageSize = 50;

        public int pageNumber { get; set; } = 1;

        private int _pageSize { get; set; } = 50;

        public int pageSize
        {

            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }

    internal class PaginationModel
    {
    }
}
