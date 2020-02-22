using System;
using System.Collections.Generic;
using System.Reflection;
using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;


namespace Micro.BusinessLayer.HumanResource
{
    public partial class LeaveTypeSettingsManagement
    {

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static LeaveTypeSettingsManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static LeaveTypeSettingsManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LeaveTypeSettingsManagement();
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

        public int InsertLeaveTypeSettings(LeaveTypeSettings _LeaveTypeSettings)
        {
            try
            {
                return LeaveTypeSettingIntegration.InsertLeaveTypeSettings(_LeaveTypeSettings);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateLeaveTypeSettings(LeaveTypeSettings _LeaveTypeSettings)
        {
            try
            {
                return LeaveTypeSettingIntegration.UpdateLeaveTypeSettings(_LeaveTypeSettings);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteLeaveTypeSettings(int LeaveTypeSettingID)
        {
            try
            {
                return LeaveTypeSettingIntegration.DeleteLeaveTypeSettings(LeaveTypeSettingID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public List<LeaveTypeSettings> GetLeaveTypeSettingsList(string searchText = null, bool showDeleted = false)
        {
            try
            {
                return LeaveTypeSettingIntegration.GetLeaveTypeSettingsList(searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public LeaveTypeSettings GetLeaveTypeSettingsByLeaveTypeSettingId(int LeaveTypeSettingID)
        {
            try
            {
                return LeaveTypeSettingIntegration.GetLeaveTypeSettingsByLeaveTypeSettingID(LeaveTypeSettingID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public LeaveTypeSettings GetLeaveTypeSettingsByOfficeIDandLeaveTypeID(int LeaveTypeID, int OfficeID = -1)
        {
            try
            {
                return LeaveTypeSettingIntegration.GetLeaveTypeSettingsByOfficeIDandLeaveTypeID(LeaveTypeID);
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
