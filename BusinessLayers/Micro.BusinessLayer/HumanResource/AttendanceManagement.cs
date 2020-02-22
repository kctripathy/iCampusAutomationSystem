using System;
using System.Data;
using System.Reflection;

using Micro.IntegrationLayer.HumanResource;
using Micro.Objects.HumanResource;
using System.Collections.Generic;



namespace Micro.BusinessLayer.HumanResource
{
    public partial class AttendanceManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary> 
        private static AttendanceManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AttendanceManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AttendanceManagement();
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

        public void InsertAttendance(int EmployeeID, DateTime PunchDateTime)
        {
            try
            {
                AttendanceIntegration.InsertAttendance(EmployeeID, PunchDateTime);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public void InsertAttendance(int EmployeeID, DateTime PunchDateTime, Micro.Commons.MicroEnums.AttendanceType AttendanceType)
        {
            try
            {
                AttendanceIntegration.InsertAttendance  (EmployeeID, PunchDateTime,AttendanceType);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion


        #region Data Retrive Mathods

        //public DataTable GetEmployeeDetailsAttendanceRegister(int EmployeeID, int _Month, int _Year)
        //{
        //    try
        //    {
        //        return AttendanceIntegration.GetEmployeeDetailsAttendanceRegister(EmployeeID, _Month, _Year);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        public List<Attendance> GetEmployeeDetailsAttendanceRegister(int EmployeeID, int _Month, int _Year)
        {
            return AttendanceIntegration.GetEmployeeDetailsAttendanceRegister(EmployeeID, _Month, _Year);
        }

        public Attendance GetEmployeeAttendanceByDate(int EmployeeID, DateTime DateOfAttendance)
        {
            try
            {
                return AttendanceIntegration.GetEmployeeAttendanceByDate(EmployeeID, DateOfAttendance);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        
        #endregion

        #region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)
        #endregion


        public List<Attendance> GetEmployeeDetailsAttendanceRegisterSummaryByDepartmentID(int DepartmentID, int _Month, int _Year)
        {
            return AttendanceIntegration.GetEmployeeDetailsAttendanceRegisterSummaryByDepartmentID(DepartmentID, _Month, _Year);
        }
    
    }
}
