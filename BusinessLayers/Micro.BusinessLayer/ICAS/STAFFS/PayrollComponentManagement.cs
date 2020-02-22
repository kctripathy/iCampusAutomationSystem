using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Micro.Objects.ICAS.STAFFS;
using Micro.IntegrationLayer.ICAS.STAFFS;

namespace Micro.BusinessLayer.ICAS.STAFFS
{
    public partial class PayrollComponentManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PayrollComponentManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PayrollComponentManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PayrollComponentManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        public string DefaultColumns = "PayComponentType";
        public string DisplayMember = "PayComponentDescription";
        public string ValueMember = "PayComponentID";
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)
        public int InsertEmpPayRollComponent(DataTable dt, EmpPayrollcomponent theComponent)
        {
            return PayrollComponentIntegration.InsertEmpPayRollComponent(dt,theComponent);
        }
        public int InsertSingleEmployeeComponent(EmpPayrollcomponent theComponent)
        {
            return PayrollComponentIntegration.InsertSingleEmployeeComponent(theComponent);
        }
        public int UpdateSingleEmployeeComponent(EmpPayrollcomponent theComponent)
        {
            return PayrollComponentIntegration.UpdateSingleEmployeeComponent(theComponent);
        }
        public int DeleteSingleEmployeeComponent(EmpPayrollcomponent theComponent)
        {
            return PayrollComponentIntegration.DeleteSingleEmployeeComponent(theComponent);
        }
        #endregion

        #region Data Retrive Mathods
        public List<Payrollcomponent> GetPayrollComponentList()
        {
            return PayrollComponentIntegration.GetPayrollComponentList();
        }
        public List<EmpPayrollcomponent> GetEmployeePayrollComponentList(int EmployeeID)
        {
            return PayrollComponentIntegration.GetEmployeePayrollComponentList(EmployeeID);
        }
        #endregion
    }
}
