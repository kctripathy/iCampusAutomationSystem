using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STAFFS
{
    [Serializable]
    public class EmployeePayroll
    {
        
        public int EmployeeID
        {
            get;
            set;
        }
        public string EmployeeCode
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string ScaleOFPay
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get;
            set;
        }
        public string DesignationDescription
        {
            get;
            set;
        }
        public string Pay
        {
            get;
            set;
        }
        public string GP_AGP
        {
            get;
            set;
        }
        public string PayWithGP_AGP
        {
            get;
            set;
        }
        public string DA_Perchantage
        {
            get;
            set;
        }
        public string DAmount
        {
            get;
            set;
        }
        public string Total_Pay
        {
            get;
            set;
        }
        public string GPF
        {
            get;
            set;
        }
        public string EPF
        {
            get;
            set;
        }
        public string GPF_Recovery
        {
            get;
            set;
        }
        public string Total_GPF
        {
            get;
            set;
        }
        public string ProffessionalTax
        {
            get;
            set;
        }
        public string I_Tax
        {
            get;
            set;
        }
        public string Total_Tax_Deduction
        {
            get;
            set;
        }
        public string Total_Deduction
        {
            get;
            set;
        }
        public string Total_Pay_Of_The_Month
        {
            get;
            set;
        }
    }
}
