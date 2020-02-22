using System;
using System.Data;
using System.Reflection;

using Micro.IntegrationLayer.HumanResource;


namespace Micro.BusinessLayer.HumanResource
{
    public partial class BioMetricDeviceManagement
    {
        #region Code to make this as Singleton Class
        
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static BioMetricDeviceManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static BioMetricDeviceManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BioMetricDeviceManagement();
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

        public int InsertBioDeviceData(string BioDeviceEmployeeID, DateTime PunchDateTime)
        {
            try
            {
                return BioMetricDeviceIntegration.InsertBioDeviceData(BioDeviceEmployeeID, PunchDateTime);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods
        #endregion

        #region Data Import Mathods
        public DataTable ImportDataFromBioMetricDeviceViaAccess()
        {
            try
            {
                return BioMetricDeviceIntegration.ImportDataFromBioMetricDeviceViaAccess();
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable ImportDataFromBioMetricDeviceViaExcel()
        {
            try
            {
                return BioMetricDeviceIntegration.ImportDataFromBioMetricDeviceViaExcel();
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Attendance Prepare Mathods

        public int PrepareMonthAttendanceRegister(string BioDeviceEmployeeID, int Month,int Year)
        {
            try
            {
                return BioMetricDeviceIntegration.PrepareMonthAttendanceRegister(BioDeviceEmployeeID, Month,Year);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int PrepareMonthAttendanceRegisterForOffice(int Month,int Year)
        {
            try
            {
                return BioMetricDeviceIntegration.PrepareMonthAttendanceRegisterForOffice(Month,Year);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int PrepareMusterSheetByOffice(int Month, int Year,int OfficeID=-1, Boolean IncludeReportingOffice = false)
        {
            try
            {
                return BioMetricDeviceIntegration.PrepareMusterSheetByOffice(Month, Year,OfficeID , IncludeReportingOffice);
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
