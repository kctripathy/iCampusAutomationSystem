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
   public partial class LoanApplicationIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

       public static int InsertLoanApplication(LoanApplication theLoanMaster)
       {
           try
           {
               return LoanApplicationDataAccess.GetInstance.InsertLoanApplication(theLoanMaster);
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }


       public static int UpdateLoanApplication(LoanApplication theLoanMaster)
       {
           try
           {
               return LoanApplicationDataAccess.GetInstance.UpdateLoanApplication(theLoanMaster);
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }

      
        #endregion


       public static List<LoanApplication> GetEmployeeActiveLoanList(bool allOffices = false, bool showDeleted = false)
       {
           List<LoanApplication> EmployeeActiveLoanList = new List<LoanApplication>();
           List<LoanApplication> EmployeeLoanList = GetLoanEmployeeList(allOffices, showDeleted);

           if (EmployeeLoanList.Count > 0)
           {
               var ActiveLoanList = (from TheLoanList in EmployeeLoanList
                                     where TheLoanList.LoanStatus == false
                                     select TheLoanList);

               foreach (LoanApplication EachLoan in ActiveLoanList)
               {
                   LoanApplication TheEmployeeLoanApplication = (LoanApplication)EachLoan;

                   EmployeeActiveLoanList.Add(TheEmployeeLoanApplication);
               }
           }

           return EmployeeActiveLoanList;
       }

       public static LoanApplication GetActiveEmployeeLoanByEmployeeID(int employeeID)
       {
           LoanApplication ActiveEmployeeLoan = new LoanApplication();
           List<LoanApplication> EmployeeLoanList = GetEmployeeLoanDetailsByEmployeeID(employeeID);
             

           if (EmployeeLoanList.Count > 0)
           {
               var TheActiveEmployeeLoan = (from TheLoanList in EmployeeLoanList
                                            where TheLoanList.LoanStatus == true && TheLoanList.LoanID == TheLoanList.LoanID 
                                            select TheLoanList).LastOrDefault();

               if (TheActiveEmployeeLoan != null)
                   ActiveEmployeeLoan = TheActiveEmployeeLoan;
           }

           return ActiveEmployeeLoan;
       }


       public static LoanApplication DataRowToObject(DataRow dr)
       {
           LoanApplication TheLoanApplication = new LoanApplication();
           
               TheLoanApplication.LoanApplicationID = int.Parse(dr["LoanApplicationID"].ToString());
               TheLoanApplication.SessionID = int.Parse(dr["SessionID"].ToString());
               TheLoanApplication.EmployeeID= int.Parse(dr["EmployeeID"].ToString());
               TheLoanApplication.EmployeeName = dr["EmployeeName"].ToString();
               TheLoanApplication.LoanApplicationDate = DateTime.Parse(dr["LoanApplicationDate"].ToString()).ToString(MicroConstants.DateFormat);
               TheLoanApplication.LoanID = int.Parse(dr["LoanID"].ToString());
               TheLoanApplication.LoanTypeDescriptions= dr["LoanTypeDescriptions"].ToString();
               TheLoanApplication.LoanAmount = decimal.Parse(dr["LoanAmount"].ToString());
           TheLoanApplication.TotalNoInstallment = int.Parse(dr["TotalNoInstallment"].ToString());
            TheLoanApplication.EMI= decimal.Parse(dr["EMI"].ToString());
           TheLoanApplication.RequiredFor= dr["RequiredFor"].ToString();
           TheLoanApplication.LoanStatus= bool.Parse(dr["LoanStatus"].ToString());
             TheLoanApplication. OfficeID = int.Parse(dr["OfficeID"].ToString());
             TheLoanApplication.OfficeName = dr["OfficeName"].ToString();
          

           return TheLoanApplication;
       }


       public static List<LoanApplication> GetLoanEmployeeList(bool allOffices = false, bool showDeleted = false)
       {
           List<LoanApplication> LoanMasterList = new List<LoanApplication>();
           DataTable LoanApplicatioTable = LoanApplicationDataAccess.GetInstance.GetLoanEmployeeList(allOffices, showDeleted);

           foreach (DataRow dr in LoanApplicatioTable.Rows)
           {
               LoanApplication TheLoanAppilication = DataRowToObject(dr);

               LoanMasterList.Add(TheLoanAppilication);
           }

           return LoanMasterList;
       }


       public static LoanApplication GetEmployeeLoanDetailsByLoanApplicationID(int loanApplicationID)
       {
           DataRow TheLoanApplicationRow = LoanApplicationDataAccess.GetInstance.GetEmployeeLoanDetailsByLoanApplicationID(loanApplicationID);

           LoanApplication TheLoanApplication = DataRowToObject(TheLoanApplicationRow);

           return TheLoanApplication;
       }


       //public static LoanApplication GetEmployeeLoanDetailsByEmployeeID(int employeeID)
       //{
       //    DataRow TheLoanApplicationRow = LoanApplicationDataAccess.GetInstance.GetEmployeeLoanDetailsByEmployeeID(employeeID);

       //    LoanApplication TheLoanApplication = DataRowToObject(TheLoanApplicationRow);

       //    return TheLoanApplication;
       //}

       public static List<LoanApplication> GetEmployeeLoanDetailsByEmployeeID(int employeeID)
       {
           List<LoanApplication> EmployeeLoanList = new List<LoanApplication>();
           DataTable CustomerLoanTable = LoanApplicationDataAccess.GetInstance.GetEmployeeLoanListByEmployeeID(employeeID);

           foreach (DataRow dr in CustomerLoanTable.Rows)
           {
               LoanApplication TheEmployeeLoan = DataRowToObject(dr);

               EmployeeLoanList.Add(TheEmployeeLoan);
           }

           return EmployeeLoanList;
       }

      

   }
}
