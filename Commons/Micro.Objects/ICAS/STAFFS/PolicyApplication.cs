using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STAFFS
{
     [Serializable]

    public class PolicyApplication
    {
         public int PolicyApplicationID
         {
             get;
             set;
         }

         public int PolicyID
        {
            get;
            set;
        }

         public string PolicyTypeDescriptions
        {
            get;
            set;
        }

         public int SessionID
        {
            get;
            set;
        }

         public string PolicyDate
        {
            get;
            set;
        }
       
         public int EmployeeID
        {
            get;
            set;
        }
        
         public string EmployeeName
         {
             get;
             set;
         }

         public decimal PolicyAmount
         {
             get;
             set;
         }

         public bool PolicyStatus
         {
             get;
             set;
         }
         
         public int TotalNoInstallment
         {
             get;
             set;
         }
       
         public decimal EMI
        {
            get;
             set;
        }

         public string Comment
        {
            get;
             set;
        }
        
         public int SanctionedByID
         {
             get;
             set;
         }
         
         public int OfficeID
         {
             get;
             set;
         }

         public string OfficeName
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
