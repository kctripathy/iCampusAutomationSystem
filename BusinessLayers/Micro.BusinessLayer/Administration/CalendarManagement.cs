using System.Collections.Generic;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;
using System.Web;



namespace Micro.BusinessLayer.Administration
{
	public partial class CalendarManagement
	{
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CalendarManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CalendarManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CalendarManagement();
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

        #region Method & Implementation

        public List<MicroCalendar> GetAllMicroHoliday()
        {
			string UniqueKey = "Get_All_MicroHoliday";
			if (HttpRuntime.Cache[UniqueKey] == null)
			{
				List<MicroCalendar> MicroHolidayList = CalendarIntegration.GetAllMicroHoliday();
				HttpRuntime.Cache[UniqueKey] = MicroHolidayList;
			}
			return (List<MicroCalendar>)(HttpRuntime.Cache[UniqueKey]);

			//return CalendarIntegration.GetAllMicroHoliday();
        }

        public List<MicroCalendar> GetAllLocalHoliday()
        {
            return CalendarIntegration.GetAllLocalHoliday();
        }

        public List<MicroCalendar> GetAllGovtHoliday()
        {
            return CalendarIntegration.GetAllGovtHoliday();
        }

        public List<MicroCalendar> GetAllByDate(int TheDate)
        {
            return CalendarIntegration.GetAllByDate(TheDate);
        }

        public List<MicroCalendar> GetAllDates()
        {
            return CalendarIntegration.GetAllDates();
        }

        public static MicroCalendar GetAllDateByID(int TheDateID)
        {
            return CalendarIntegration.GetAllDateByID(TheDateID);
        }

        #endregion

    }
}
