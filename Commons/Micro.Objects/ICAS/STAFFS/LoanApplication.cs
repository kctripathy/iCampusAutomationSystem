using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STAFFS
{
     [Serializable]

   public class LoanApplication
    {
         public int LoanApplicationID
         {
             get;
             set;
         }

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

         public int SessionID
        {
            get;
            set;
        }
        
         public string LoanApplicationDate
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

         public decimal LoanAmount
         {
             get;
             set;
         }
        
         public bool LoanStatus
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
         
         public string RequiredFor
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
