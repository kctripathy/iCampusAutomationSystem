using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.Testing
{
    [Serializable]
    public class Ameer
    {
        public int PayCategoryID
        {
            get;
            set;
        }

        public string PayCategoryDescription
        {
            get;
            set;
        }

        public int OfficeID
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
    }
}
