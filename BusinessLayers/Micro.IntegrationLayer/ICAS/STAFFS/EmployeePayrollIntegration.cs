using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using System.Data;
using System.Reflection;
using Micro.DataAccessLayer.ICAS.STAFFS;

namespace Micro.IntegrationLayer.ICAS.STAFFS
{
    public partial class EmployeePayrollIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        
        public static EmployeePayroll EmpPayRollToObject(DataRow dr)
        {
            EmployeePayroll ThePayroll = new EmployeePayroll();
            //ThePayroll.RecordNo =int.Parse(dr["RecordNo"].ToString();
            ThePayroll.EmployeeID =int.Parse(dr["EmployeeID"].ToString());
            ThePayroll.EmployeeName = dr["EmployeeName"].ToString();
            ThePayroll.EmployeeCode = dr["EmployeeCode"].ToString();
            ThePayroll.PhoneNumber = dr["PhoneNumber"].ToString();
            ThePayroll.ScaleOFPay = dr["ScaleOfPay"].ToString();
            ThePayroll.DesignationDescription = dr["DesignationDescription"].ToString();
            ThePayroll.Pay = dr["Pay"].ToString();
            ThePayroll.GP_AGP = dr["GP_AGP"].ToString();
            ThePayroll.PayWithGP_AGP = dr["PayWithGP_AGP"].ToString();

            ThePayroll.DA_Perchantage = dr["DA_Perchantage"].ToString();
            ThePayroll.DAmount = dr["DAmount(Pay+GP_AGP@Da%)"].ToString();
            ThePayroll.Total_Pay = dr["Total_Pay(Pay+GP_AGP+DAmount)"].ToString();
            ThePayroll.GPF = dr["GPF"].ToString() ;
            ThePayroll.EPF = dr["EPF"].ToString();
            ThePayroll.GPF_Recovery = dr["GPF_Recovery"].ToString();
            ThePayroll.Total_GPF = dr["Total_GPF(GPF+EPF+GR)"].ToString();
            ThePayroll.ProffessionalTax = dr["ProffessionalTax"].ToString();

            ThePayroll.I_Tax = dr["I_Tax"].ToString();
            ThePayroll.Total_Tax_Deduction = dr["Total_Tax_Deduction(PT+IT)"].ToString();
            ThePayroll.Total_Deduction = dr["Total_Deduction[(Total_GPF)+(Total_Tax)]"].ToString();
            ThePayroll.Total_Pay_Of_The_Month = dr["NetBalance(Tot_Pay-Tot_Ded)"].ToString();
            
            return ThePayroll;
        }

        public static List<EmployeePayroll> GetEmployeePayrollList()
        {
            List<EmployeePayroll> EmployeePayrollList = new List<EmployeePayroll>();
            DataTable EmployeeComponentTable = EmployeePayrollDataAccess.GetInstance.GetEmployeePayrollList();
            foreach (DataRow dr in EmployeeComponentTable.Rows)
            {
                EmployeePayroll ThePayroll = EmpPayRollToObject(dr);
                EmployeePayrollList.Add(ThePayroll);
            }
            return EmployeePayrollList;
        }
    }
}
#endregion
    
