using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using Micro.DataAccessLayer.ICAS.STAFFS;
using System.Reflection;
using System.Data;
using Micro.Commons;

namespace Micro.IntegrationLayer.ICAS.STAFFS
{
    public partial class PolicyApplicationIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

       public static int InsertPolicyApplication(PolicyApplication thePolicyMaster)
       {
           try
           {
               return StaffLICDataAccess.GetInstance.InsertPolicyApplication(thePolicyMaster);
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }


       public static int UpdatePolicyApplication(PolicyApplication thePolicyMaster)
       {
           try
           {
               return StaffLICDataAccess.GetInstance.UpdatePolicyApplication(thePolicyMaster);
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }      
        #endregion

       public static List<PolicyApplication> GetEmployeeActivePolicyList(bool allOffices = false, bool showDeleted = false)
       {
           List<PolicyApplication> EmployeeActiveLoanList = new List<PolicyApplication>();
           List<PolicyApplication> EmployeeLoanList = GetPolicyEmployeeList(allOffices, showDeleted);

           if (EmployeeLoanList.Count > 0)
           {
               var ActiveLoanList = (from ThepolicyList in EmployeeLoanList
                                     where ThepolicyList.PolicyStatus == false
                                     select ThepolicyList);
               foreach (PolicyApplication EachLoan in ActiveLoanList)
               {
                   PolicyApplication TheEmployeeLoanApplication = (PolicyApplication)EachLoan;

                   EmployeeActiveLoanList.Add(TheEmployeeLoanApplication);
               }
           }
           return EmployeeActiveLoanList;
       }

       //public static PolicyApplication GetActiveEmployeeLoanByEmployeeID(int employeeID)
       //{
       //    PolicyApplication ActiveEmployeeLoan = new PolicyApplication();
       //    List<PolicyApplication> EmployeeLoanList = GetEmployeeLoanDetailsByEmployeeID(employeeID);
             

       //    if (EmployeeLoanList.Count > 0)
       //    {
       //        var TheActiveEmployeeLoan = (from TheLoanList in EmployeeLoanList
       //                                     where TheLoanList.LoanStatus == true && TheLoanList.LoanID == TheLoanList.LoanID 
       //                                     select TheLoanList).LastOrDefault();

       //        if (TheActiveEmployeeLoan != null)
       //            ActiveEmployeeLoan = TheActiveEmployeeLoan;
       //    }

       //    return ActiveEmployeeLoan;
       //}


       public static PolicyApplication DataRowToObject(DataRow dr)
       {
           PolicyApplication ThePplicyApplication = new PolicyApplication();
           ThePplicyApplication.PolicyApplicationID = int.Parse(dr["PolicyApplicationID"].ToString());
           ThePplicyApplication.SessionID = int.Parse(dr["SessionID"].ToString());
           ThePplicyApplication.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
           ThePplicyApplication.EmployeeName = dr["EmployeeName"].ToString();
           ThePplicyApplication.PolicyDate = DateTime.Parse(dr["PolicyDate"].ToString()).ToString(MicroConstants.DateFormat);
           ThePplicyApplication.PolicyID = int.Parse(dr["PolicyID"].ToString());
           ThePplicyApplication.PolicyTypeDescriptions = dr["PolicyTypeDescriptions"].ToString();
           ThePplicyApplication.PolicyAmount = decimal.Parse(dr["PolicyAmount"].ToString());
           ThePplicyApplication.TotalNoInstallment = int.Parse(dr["TotalNoInstallment"].ToString());
           ThePplicyApplication.EMI = decimal.Parse(dr["EMI"].ToString());
           ThePplicyApplication.Comment = dr["Comment"].ToString();
           ThePplicyApplication.PolicyStatus = bool.Parse(dr["PolicyStatus"].ToString());
           ThePplicyApplication.OfficeID = int.Parse(dr["OfficeID"].ToString());
           ThePplicyApplication.OfficeName = dr["OfficeName"].ToString();
           return ThePplicyApplication;
       }


       public static List<PolicyApplication> GetPolicyEmployeeList(bool allOffices = false, bool showDeleted = false)
       {
           List<PolicyApplication> PolicyMasterList = new List<PolicyApplication>();
           DataTable PolicyApplicatioTable = StaffLICDataAccess.GetInstance.GetLICEmployeeList(allOffices, showDeleted);

           foreach (DataRow dr in PolicyApplicatioTable.Rows)
           {
               PolicyApplication ThepolicyAppilication = DataRowToObject(dr);

               PolicyMasterList.Add(ThepolicyAppilication);
           }

           return PolicyMasterList;
       }
       public static List<StaffPolicyByEmployee> GetPolicySelectAll_By_Employee(int EmployeeID)
       {
           try
           {
               return ConvertDatarowToObject(StaffLICDataAccess.GetInstance.GetPolicySelectAll_By_Employee(EmployeeID));
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }

       private static List<StaffPolicyByEmployee> ConvertDatarowToObject(DataTable dataTable)
       {
           try
           {
               //TODO: SUBRAT: handle null of this part to 
               List<StaffPolicyByEmployee> EmployeeList = new List<StaffPolicyByEmployee>();

               foreach (DataRow dr in dataTable.Rows)
               {

                   StaffPolicyByEmployee ObjEmployee = new StaffPolicyByEmployee();

                   ObjEmployee.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                   ObjEmployee.EmployeeCode = dr["EmployeeCode"].ToString();

                   ObjEmployee.Salutation = dr["Salutation"].ToString().Trim();
                   ObjEmployee.EmployeeName = dr["EmployeeName"].ToString().Trim();

                   string eName = ObjEmployee.EmployeeName;
                  
                   if (dr["DateOfBirth"] != null)
                   {
                       ObjEmployee.DateOfBirth = (dr["DateOfBirth"].ToString().Length > 0 ? DateTime.Parse(dr["DateOfBirth"].ToString()).ToString(MicroConstants.DateFormat) : null);
                   }
                   ObjEmployee.FatherName = dr["FatherName"].ToString();
                   ObjEmployee.Mobile = dr["Mobile"].ToString();
                   ObjEmployee.EMailID = dr["EMailID"].ToString();
                   ObjEmployee.PolicyApplicationID = int.Parse(dr["PolicyApplicationID"].ToString());
                   ObjEmployee.PolicyID = int.Parse(dr["PolicyID"].ToString());
                   ObjEmployee.PolicyAmount = decimal.Parse(dr["PolicyAmount"].ToString());
                   if (dr["DateOfBirth"] != null)
                   {
                       ObjEmployee.PolicyDate = (dr["PolicyDate"].ToString().Length > 0 ? DateTime.Parse(dr["PolicyDate"].ToString()).ToString(MicroConstants.DateFormat) : null);
                   }                  
                   ObjEmployee.PolicyStatus = dr["PolicyStatus"].ToString();
                   ObjEmployee.Comment = dr["Comment"].ToString();
                   ObjEmployee.EMI = dr["EMI"].ToString();
                   ObjEmployee.SanctionedByID = int.Parse(dr["SanctionedByID"].ToString());            
                   EmployeeList.Add(ObjEmployee);
               }
               return EmployeeList;
           }
           catch (Exception ex)
           {

               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }

       //public static LoanApplication GetEmployeeLoanDetailsByLoanApplicationID(int loanApplicationID)
       //{
       //    DataRow TheLoanApplicationRow = LoanApplicationDataAccess.GetInstance.GetEmployeeLoanDetailsByLoanApplicationID(loanApplicationID);

       //    LoanApplication TheLoanApplication = DataRowToObject(TheLoanApplicationRow);

       //    return TheLoanApplication;
       //}
     

       //public static List<LoanApplication> GetEmployeeLoanDetailsByEmployeeID(int employeeID)
       //{
       //    List<LoanApplication> EmployeeLoanList = new List<LoanApplication>();
       //    DataTable CustomerLoanTable = LoanApplicationDataAccess.GetInstance.GetEmployeeLoanListByEmployeeID(employeeID);

       //    foreach (DataRow dr in CustomerLoanTable.Rows)
       //    {
       //        LoanApplication TheEmployeeLoan = DataRowToObject(dr);

       //        EmployeeLoanList.Add(TheEmployeeLoan);
       //    }

       //    return EmployeeLoanList;
       //}

      

   }
}
