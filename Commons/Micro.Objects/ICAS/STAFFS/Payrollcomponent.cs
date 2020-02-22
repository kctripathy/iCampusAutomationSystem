using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STAFFS
{
    [Serializable]
    public class Payrollcomponent
    {
        public int PayComponentID
        {
            get;
            set;
        }
        public string PayComponentDescription
        {
            get;
            set;
        }
        public string PayComponentType
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
        public int CompanyID
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public string AddedByName
        {
            get;
            set;
        }
        public string AddedByCode
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
    }
}
