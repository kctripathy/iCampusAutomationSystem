using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.IntegrationLayer.ICAS.STAFFS;
using Micro.Objects.ICAS.STAFFS;
using System.Reflection;

namespace Micro.BusinessLayer.ICAS.STAFFS
{
  public partial  class LoanApplicationManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
      private static LoanApplicationManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
      public static LoanApplicationManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoanApplicationManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

         public int InsertLoanApplication(LoanApplication theLoanMaster)
      {
          try
          {
              return LoanApplicationIntegration.InsertLoanApplication(theLoanMaster);
          }
          catch (Exception ex)
          {
              throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
          }
      }


         public int UpdateLoanApplication(LoanApplication theLoanMaster)
         {
             try
             {
                 return LoanApplicationIntegration.UpdateLoanApplication(theLoanMaster);
             }
             catch (Exception ex)
             {
                 throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
             }
         }
        
        #endregion

        #region Data Retrive Mathods
        public List<LoanApplication> GetLoanEmployeeList()
        {
            return LoanApplicationIntegration.GetLoanEmployeeList();
        }

        public LoanApplication GetEmployeeLoanDetailsByLoanApplicationID(int loanApplicationID)
        {
            //TODO: 
            return LoanApplicationIntegration.GetEmployeeLoanDetailsByLoanApplicationID(loanApplicationID);
        }


        public List<LoanApplication> GetEmployeeActiveLoanList(bool allOffices = false, bool showDeleted = false)
        {
            return LoanApplicationIntegration.GetEmployeeActiveLoanList(allOffices, showDeleted);
        }


        public LoanApplication GetEmployeeLoanDetailsByEmployeeID(int employeeID)
        {
            //TODO: 
            return LoanApplicationIntegration.GetActiveEmployeeLoanByEmployeeID(employeeID);

        }

        public LoanApplication GetActiveEmployeeLoanByEmployeeID(int employeeID)
        {
            return LoanApplicationIntegration.GetActiveEmployeeLoanByEmployeeID(employeeID);
            
        }

       

        #endregion
    }
}
