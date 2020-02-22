using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Micro.Objects.ICAS.STAFFS;
using Micro.IntegrationLayer.ICAS.STAFFS;

namespace Micro.BusinessLayer.ICAS.STAFFS
{
    public partial class EmployeePayrollManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static EmployeePayrollManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static EmployeePayrollManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EmployeePayrollManagement();
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
        
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)
        
        #endregion

        #region Data Retrive Mathods
        public List<EmployeePayroll> GetEmployeePayrollList()
        {
            return EmployeePayrollIntegration.GetEmployeePayrollList();
        }        
        #endregion
    }
}
