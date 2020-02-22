using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.IntegrationLayer.ICAS.STAFFS;
using Micro.Objects.ICAS.STAFFS;
using System.Reflection;

namespace Micro.BusinessLayer.ICAS.STAFFS
{
    public partial class PolicyApplicationManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PolicyApplicationManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PolicyApplicationManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PolicyApplicationManagement();
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

         public int InsertPolicyApplication(PolicyApplication thePolicyMaster)
      {
          try
          {
              return PolicyApplicationIntegration.InsertPolicyApplication(thePolicyMaster);
          }
          catch (Exception ex)
          {
              throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
          }
      }


         public int UpdatePolicyApplication(PolicyApplication thePolicyMaster)
         {
             try
             {
                 return PolicyApplicationIntegration.UpdatePolicyApplication(thePolicyMaster);
             }
             catch (Exception ex)
             {
                 throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
             }
         }
        
        #endregion

        #region Data Retrive Mathods
         public List<PolicyApplication> GetPolicyEmployeeList()
         {
             return PolicyApplicationIntegration.GetPolicyEmployeeList();
         }
         public List<StaffPolicyByEmployee> GetPolicySelectAll_By_Employee(int EmployeeID)
         {
             return PolicyApplicationIntegration.GetPolicySelectAll_By_Employee(EmployeeID);
         }
        //public LoanApplication GetEmployeeLoanDetailsByLoanApplicationID(int loanApplicationID)
        //{
        //    //TODO: 
        //    return LoanApplicationIntegration.GetEmployeeLoanDetailsByLoanApplicationID(loanApplicationID);
        //}


        //public List<LoanApplication> GetEmployeeActiveLoanList(bool allOffices = false, bool showDeleted = false)
        //{
        //    return LoanApplicationIntegration.GetEmployeeActiveLoanList(allOffices, showDeleted);
        //}


        //public LoanApplication GetEmployeeLoanDetailsByEmployeeID(int employeeID)
        //{
        //    //TODO: 
        //    return LoanApplicationIntegration.GetActiveEmployeeLoanByEmployeeID(employeeID);

        //}

         //public PolicyApplication GetActiveEmployeeLoanByEmployeeID(int employeeID)
         //{
         //    return LoanApplicationIntegration.GetActiveEmployeeLoanByEmployeeID(employeeID);

         //}

       

        #endregion
    }
}
