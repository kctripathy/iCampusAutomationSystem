#region System Namespace

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

#endregion

#region Micro Namespaces

using Micro.Objects.HumanResource;
using Micro.DataAccessLayer.HumanResource;



#endregion

namespace Micro.IntegrationLayer.HumanResource
{
    public partial class ShiftScheduleIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertShiftSchedule(ShiftSchedule _ShiftSchedule, Boolean AllowRescheduleOfPastShiftSchedules = false)
        {
            try
            {
                return ShiftScheduleDataAccess.GetInstance.InsertShiftSchedule(_ShiftSchedule, AllowRescheduleOfPastShiftSchedules);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateShiftSchedule(ShiftSchedule _ShiftSchedule, Boolean AllowRescheduleOfPastShiftSchedules = false)
        {
            try
            {
                return ShiftScheduleDataAccess.GetInstance.UpdateShiftSchedule(_ShiftSchedule, AllowRescheduleOfPastShiftSchedules);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteShiftSchedule(ShiftSchedule _ShiftScheduleID)
        {
            try
            {
                return ShiftScheduleDataAccess.GetInstance.DeleteShiftSchedule(_ShiftScheduleID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static List<ShiftSchedule> SetShiftSchedulesList(DataTable ShiftScheduleTable)
        {
            try
            {
                List<ShiftSchedule> _ShiftScheduleOfficewiseList = new List<ShiftSchedule>();

                foreach (DataRow dr in ShiftScheduleTable.Rows)
                {
                    ShiftSchedule _ShiftSchedule = new ShiftSchedule();

                    _ShiftSchedule.ShiftScheduleID = int.Parse(dr["ShiftScheduleID"].ToString());
                    _ShiftSchedule.ShiftScheduleForWeekDay = int.Parse(dr["ShiftScheduleForWeekDay"].ToString());
                    _ShiftSchedule.ShiftScheduleForDate = DateTime.Parse(dr["ShiftScheduleForDate"].ToString());
                    _ShiftSchedule.ShiftScheduleForWeekDayName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[_ShiftSchedule.ShiftScheduleForWeekDay - 1];

                    _ShiftSchedule.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                    _ShiftSchedule.EmployeeName = dr["EmployeeName"].ToString();

                    _ShiftSchedule.ShiftTimingID = int.Parse(dr["ShiftTimingID"].ToString());
                    _ShiftSchedule.ShiftTiming.ShiftID = int.Parse(dr["ShiftID"].ToString());
                    _ShiftSchedule.ShiftTiming.ShiftDescription = dr["ShiftDescription"].ToString();
                    _ShiftSchedule.ShiftTiming.ShiftAlias = dr["ShiftAlias"].ToString();
                    _ShiftSchedule.ShiftTiming.InTime = DateTime.Parse(dr["InTime"].ToString());
                    _ShiftSchedule.ShiftTiming.OutTime = DateTime.Parse(dr["OutTime"].ToString());

                    _ShiftSchedule.Office.OfficeID = int.Parse(dr["OfficeID"].ToString());
                    _ShiftSchedule.Office.OfficeName = dr["OfficeName"].ToString();

                    _ShiftScheduleOfficewiseList.Add(_ShiftSchedule);
                }

                return _ShiftScheduleOfficewiseList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<ShiftSchedule> GetShiftSchedulesAll(int OfficeID = -1)
        {
            try
            {
                return SetShiftSchedulesList(ShiftScheduleDataAccess.GetInstance.GetShiftScheduledsAll(OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<ShiftSchedule> GetShiftSchedulesByDepartment(int DepartmentID, string Date, int OfficeID)
        {
            try
            {
                return SetShiftSchedulesList(ShiftScheduleDataAccess.GetInstance.GetShiftScheduledsByDeparment(DepartmentID, Date, OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
