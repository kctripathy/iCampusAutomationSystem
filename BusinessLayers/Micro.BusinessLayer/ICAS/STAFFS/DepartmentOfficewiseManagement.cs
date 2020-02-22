using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using Micro.IntegrationLayer.ICAS.STAFFS;
using System.Reflection;

namespace Micro.BusinessLayer.ICAS.STAFFS
{
    public partial class DepartmentOfficewiseManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DepartmentOfficewiseManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DepartmentOfficewiseManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DepartmentOfficewiseManagement();
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

        public int InsertDepartmentOfficewise(DepartmentOfficewise _DepartmentOfficewise)
        {
            try
            {
                return DepartmentOfficewiseIntegration.InsertDepartmentOfficewise(_DepartmentOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateDepartmentOfficewise(DepartmentOfficewise _DepartmentOfficewise)
        {
            try
            {
                return DepartmentOfficewiseIntegration.UpdateDepartmentOfficewise(_DepartmentOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteDepartmentOfficewise(int DepartmentOfficwiseID)
        {
            try
            {
                return DepartmentOfficewiseIntegration.DeleteDepartmentOfficewise(DepartmentOfficwiseID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        #endregion

        #region Data Retrive Mathods

        public List<DepartmentOfficewise> GetDepartmentOfficewiseByOfficeID(int OfficeID = -1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                return DepartmentOfficewiseIntegration.GetDepartmentOfficewiseByOfficeID(OfficeID);
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
