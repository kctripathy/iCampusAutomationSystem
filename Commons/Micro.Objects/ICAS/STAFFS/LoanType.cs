using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STAFFS
{
     [Serializable]

   public class LoanType
    {
        

        public int LoanID
        {
            get;
            set;
        }

        
        public string LoanTypeDescriptions
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

        public int AddedBy
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
