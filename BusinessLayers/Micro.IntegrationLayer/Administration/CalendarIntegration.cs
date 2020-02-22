using System;
using System.Collections.Generic;
using System.Data;
using Micro.Objects.Administration;
using System.Reflection;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
	public partial class CalendarIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

        public static List<MicroCalendar> SetHolidays(DataTable HolidayTable)
        {
            try
            {
                List<MicroCalendar> HolidayList = new List<MicroCalendar>();

                foreach (DataRow dr in HolidayTable.Rows)
                {
                    MicroCalendar _Holiday = new MicroCalendar();

                    _Holiday.TheDateID = int.Parse(dr["TheDateID"].ToString());
                    _Holiday.CalendarDate = DateTime.Parse(dr["CalendarDate"].ToString());
                    _Holiday.CalendarDateDesc = dr["CalendarDateDesc"].ToString();
					if (!string.IsNullOrEmpty(dr["IsGovtHoliday"].ToString()))
					{
						_Holiday.IsGovtHoliday = char.Parse(dr["IsGovtHoliday"].ToString());
					}
					if (!string.IsNullOrEmpty(dr["IsLocalHoliday"].ToString()))
					{
						_Holiday.IsLocalHoliday = char.Parse(dr["IsLocalHoliday"].ToString());
					}
                    if (!string.IsNullOrEmpty(dr["IsMicroHoliday"].ToString()))
                    {
                        _Holiday.IsMicroHoliday = char.Parse(dr["IsMicroHoliday"].ToString());
                    }

                    HolidayList.Add(_Holiday);
                }
                return HolidayList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<MicroCalendar> GetAllMicroHoliday()
        {
            return SetHolidays(CalendarDataAccess.GetInstance.GetAllMicroHoliday());
        }

        public static List<MicroCalendar> GetAllLocalHoliday()
        {
            return SetHolidays(CalendarDataAccess.GetInstance.GetAllLocalHoliday());
        }

        public static List<MicroCalendar> GetAllGovtHoliday()
        {
            return SetHolidays(CalendarDataAccess.GetInstance.GetAllGovtHoliday());
        }

        public static List<MicroCalendar> GetAllDates()
        {
            return SetHolidays(CalendarDataAccess.GetInstance.GetAllDates());
        }

        public static List<MicroCalendar> GetAllByDate(int TheDate)
        {
            return SetHolidays(CalendarDataAccess.GetInstance.GetAllByDate(TheDate));
        }

        public static MicroCalendar GetAllDateByID(int TheDateID)
        {
            try
            {

                DataRow HolidayRow = CalendarDataAccess.GetInstance.GetAllDateByID(TheDateID);

                MicroCalendar _Holiday = new MicroCalendar();

                _Holiday.TheDateID = int.Parse(HolidayRow["TheDateID"].ToString());
                _Holiday.CalendarDate = DateTime.Parse(HolidayRow["CalendarDate"].ToString());
                _Holiday.CalendarDateDesc = HolidayRow["DateOfOccasion"].ToString();
                _Holiday.IsLocalHoliday = char.Parse(HolidayRow["IsLocalHoliday"].ToString());
                _Holiday.IsGovtHoliday = char.Parse(HolidayRow["IsGovtHoliday"].ToString());
                _Holiday.IsMicroHoliday = char.Parse(HolidayRow["IsMicroHoliday"].ToString());

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
