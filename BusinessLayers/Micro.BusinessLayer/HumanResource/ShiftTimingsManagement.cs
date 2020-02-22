using System;
using System.Collections.Generic;
using System.Reflection;
using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;

namespace Micro.BusinessLayer.HumanResource
{
    public partial class ShiftTimingsManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ShiftTimingsManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ShiftTimingsManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ShiftTimingsManagement();
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
        public string DisplayMember = "ShiftAlias";
        public string ValueMember = "ShiftTimingID";
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertShiftTimings(ShiftTiming _ShiftTimings)
        {
            try
            {
                return ShiftTimingsIntegration.InsertShiftTimings(_ShiftTimings);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateShiftTimings(ShiftTiming _ShiftTimings)
        {
            try
            {
                return ShiftTimingsIntegration.UpdateShiftTimings(_ShiftTimings);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteShiftTimings(int HolidayOfficwiseID)
        {
            try
            {
                return ShiftTimingsIntegration.DeleteShiftTimings(HolidayOfficwiseID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public List<ShiftTiming> GetShiftTimingsByOfficeID(int OfficeID, string searchText = null, bool showDeleted = false)
        {
            try
            {
                return ShiftTimingsIntegration.GetShiftTimingsByOfficeID(OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<ShiftTiming> GetShiftTimingsByOfficeIDandDepartmentID(int DepartmentID, string searchText = null, bool showDeleted = false)
        {
            try
            {
                return ShiftTimingsIntegration.GetShiftTimingsByOfficeIDandDepartmentID(DepartmentID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        //public List<ShiftTimings> GetShiftTimingsByOfficeIDandDepartmentID(int DepartmentID, int OfficeID,string searchText = null, bool showDeleted = false)
        //{
        //    try
        //    {
        //        return ShiftTimingsIntegration.GetShiftTimingsByOfficeIDandDepartmentID(DepartmentID,OfficeID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}
        public List<ShiftTiming> GetCompanyShiftTimings()
        {
            try
            {
                return ShiftTimingsIntegration.GetCompanyShiftTimings();
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
