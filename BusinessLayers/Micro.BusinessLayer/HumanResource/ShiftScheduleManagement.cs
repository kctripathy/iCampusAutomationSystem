using System;
using System.Collections.Generic;
using System.Reflection;
using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;

namespace Micro.BusinessLayer.HumanResource
{
    public class ShiftScheduleManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ShiftScheduleManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ShiftScheduleManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ShiftScheduleManagement();
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

        public int InsertShiftSchedule(ShiftSchedule _ShiftSchedule, Boolean AllowRescheduleOfPastShiftSchedules = false)
        {
            try
            {
                return ShiftScheduleIntegration.InsertShiftSchedule(_ShiftSchedule, AllowRescheduleOfPastShiftSchedules);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateShiftSchedule(ShiftSchedule _ShiftSchedule, Boolean AllowRescheduleOfPastShiftSchedules = false)
        {
            try
            {
                return ShiftScheduleIntegration.UpdateShiftSchedule(_ShiftSchedule, AllowRescheduleOfPastShiftSchedules);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteShiftSchedule(ShiftSchedule _ShiftSchedule)
        {
            try
            {
                return ShiftScheduleIntegration.DeleteShiftSchedule(_ShiftSchedule);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public List<ShiftSchedule> GetShiftSchedulesAll(int OfficeID = -1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                return ShiftScheduleIntegration.GetShiftSchedulesAll();
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<ShiftSchedule> GetShiftSchedulesByDepartment(int DeparmentID, string Date, int OfficeID=-1 )
        {
            try
            {
                return ShiftScheduleIntegration.GetShiftSchedulesByDepartment(DeparmentID, Date, OfficeID);
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
