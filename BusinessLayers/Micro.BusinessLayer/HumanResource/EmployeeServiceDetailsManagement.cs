using System;
using System.Collections.Generic;
using System.Reflection;

using Micro.IntegrationLayer.HumanResource;
using Micro.Objects.HumanResource;


namespace Micro.BusinessLayer.HumanResource
{
    public partial class EmployeeServiceDetailsManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static EmployeeServiceDetailsManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static EmployeeServiceDetailsManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EmployeeServiceDetailsManagement();
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

        public int InsertEmployeeServiceDetais(EmployeeServiceDetails _EmployeeServiceDetails)
        {
            try
            {
                return EmployeeServiceDetailsIntegration.InsertEmployeeServiceDetails(_EmployeeServiceDetails);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateEmployeeServiceDetais(EmployeeServiceDetails _EmployeeServiceDetails)
        {
            try
            {
                return EmployeeServiceDetailsIntegration.UpdateEmployeeServiceDetails(_EmployeeServiceDetails);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteEmployeeServiceDetais(EmployeeServiceDetails _EmployeeServiceDetails)
        {
            try
            {
                return EmployeeServiceDetailsIntegration.DeleteEmployeeServiceDetails(_EmployeeServiceDetails);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public List<EmployeeServiceDetails> GetEmployeeListByReportingToEmployee(int EmployeeID)
        {
            try
            {
                return EmployeeServiceDetailsIntegration.GetReportingEmployeeListByReportingToEmployee(EmployeeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<EmployeeServiceDetails> GetEmployeeServiceDetailsAll(string searchText, bool showDeleted = false)
        {
            try
            {
                return EmployeeServiceDetailsIntegration.GetEmployeeServiceDetailsAll(searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<EmployeeServiceDetails> GetEmployeeServiceDetaisByEmployee(int EmployeeID)
        {
            try
            {
                return EmployeeServiceDetailsIntegration.GetEmployeeServiceDetailsByEmployee(EmployeeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)
        #endregion
    }
}
