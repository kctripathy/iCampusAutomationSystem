#region System Namespace

using System.Collections.Generic;
using System.Data;
using System;
using System.Reflection;

#endregion

#region Micro Namespaces

using Micro.Objects.HumanResource;
using Micro.DataAccessLayer.HumanResource;

#endregion

namespace Micro.IntegrationLayer.HumanResource
{
    public partial class HolidayIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertHoliday(Holiday _Holiday)
        {
            try
            {
                return HolidayDataAccess.GetInstance.InsertHoliday(_Holiday);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateHoliday(Holiday _Holiday)
        {
            try
            {
                return HolidayDataAccess.GetInstance.UpdateHoliday(_Holiday);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteHoliday(int HolidayID)
        {
            try
            {
                return HolidayDataAccess.GetInstance.DeleteHoliday(HolidayID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static List<Holiday> SetHolidays(DataTable HolidayTable)
        {
            try
            {
                List<Holiday> HolidayList = new List<Holiday>();

                foreach (DataRow dr in HolidayTable.Rows)
                {
                    Holiday _Holiday = new Holiday();

                    _Holiday.HolidayID = int.Parse(dr["HolidayID"].ToString());
                    _Holiday.Occasion = dr["Occasion"].ToString();
                    _Holiday.DateOfOccasion = DateTime.Parse(dr["DateOfOccasion"].ToString());
                    _Holiday.WeekDayOfOccasion = _Holiday.DateOfOccasion.DayOfWeek.ToString();

                    _Holiday.IsDateFixed = Boolean.Parse(dr["IsDateFixed"].ToString());
                    _Holiday.IsActive = Boolean.Parse(dr["IsActive"].ToString());

                    HolidayList.Add(_Holiday);
                }
                return HolidayList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<Holiday> GetAllHolidays(string searchText, bool showDeleted = false)
        {
            try
            {
                return SetHolidays(HolidayDataAccess.GetInstance.GetAllHolidays(searchText, showDeleted));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<Holiday> GetAllHolidaysByCalenderYear(int CalenderYear, string searchText, bool showDeleted = false)
        {
            try
            {
                return SetHolidays(HolidayDataAccess.GetInstance.GetAllHolidaysByCalenderYear(CalenderYear, searchText, showDeleted));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static Holiday GetHolidayByID(int HolidayID)
        {
            try
            {

                DataRow HolidayRow = HolidayDataAccess.GetInstance.GetHolidayByID(HolidayID);

                Holiday _Holiday = new Holiday();

                _Holiday.HolidayID = int.Parse(HolidayRow["HolidayID"].ToString());
                _Holiday.Occasion = HolidayRow["Occasion"].ToString();
                _Holiday.DateOfOccasion = System.DateTime.Parse(HolidayRow["DateOfOccasion"].ToString());
                _Holiday.WeekDayOfOccasion = _Holiday.DateOfOccasion.DayOfWeek.ToString();

                _Holiday.IsDateFixed = Boolean.Parse(HolidayRow["IsDateFixed"].ToString());
                _Holiday.IsActive = Boolean.Parse(HolidayRow["IsActive"].ToString());

                return _Holiday;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
