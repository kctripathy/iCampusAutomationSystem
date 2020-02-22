#region System Namespace

using System;
using System.Data;
using System.Reflection;

#endregion

#region Micro Namespaces

using Micro.DataAccessLayer.HumanResource;


#endregion

namespace Micro.IntegrationLayer.HumanResource
{
    public class BioMetricDeviceIntegration
    {
        #region Declaration
        #endregion

        #region Data Import Mathods

        public static DataTable ImportDataFromBioMetricDeviceViaAccess()
        {
            try
            {
                return BioMetricDeviceDataAccess.GetInstance.ImportDataFromBioMetricDeviceViaAccess();
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static DataTable ImportDataFromBioMetricDeviceViaExcel()
        {
            try
            {
                return BioMetricDeviceDataAccess.GetInstance.ImportDataFromBioMetricDeviceViaExcel();
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertBioDeviceData(string BioDeviceEmployeeID, DateTime PunchDateTime)
        {
            try
            {
                return BioMetricDeviceDataAccess.GetInstance.InsertBioDeviceData(BioDeviceEmployeeID, PunchDateTime);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int InsertAttendance(string EmployeeID, DateTime PunchDateTime)
        {
            try
            {
                return BioMetricDeviceDataAccess.GetInstance.InsertBioDeviceData(EmployeeID, PunchDateTime);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Attendance Prepare Mathods

        public static int PrepareMonthAttendanceRegister(string BioDeviceEmployeeID, int Month, int Year)
        {
            try
            {
                return BioMetricDeviceDataAccess.GetInstance.PrepareMonthAttendanceRegister(BioDeviceEmployeeID, Month, Year);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int PrepareMonthAttendanceRegisterForOffice(int Month, int Year)
        {
            try
            {
                return BioMetricDeviceDataAccess.GetInstance.PrepareMonthAttendanceRegisterForOffice(Month, Year);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int PrepareMusterSheetByOffice(int Month, int Year, int OfficeID = -1, Boolean IncludeReportingOffice = false)
        {
            try
            {
                return BioMetricDeviceDataAccess.GetInstance.PrepareMusterSheetByOffice(Month, Year, OfficeID, IncludeReportingOffice);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        
        #endregion

        #region Data Retrive Mathods
        #endregion
    }
}
