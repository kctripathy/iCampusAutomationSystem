using System;

namespace Micro.Commons
{
	public class DateTimeAdapter
	{
		public static DateTime Parse(string dateTime)
		{
			return DateTime.Parse(dateTime);
		}

		public static string SqlDateFormat(DateTime dateTime)
		{
			return DateTime.Parse(dateTime.ToString()).ToString(MicroConstants.DateSqlFormat);
		}

		public static string SystemDateFormat(DateTime dateTime)
		{
			return DateTime.Parse(dateTime.ToString()).ToString(MicroConstants.DateSystemFormat);
		}

		public static string SqlDateTimeFormat(DateTime dateTime)
		{
			return DateTime.Parse(dateTime.ToString()).ToString(MicroConstants.DateTimeSqlFormat);
		}

		public static string SystemDateTimeFormat(DateTime dateTime)
		{
			return DateTime.Parse(dateTime.ToString()).ToString(MicroConstants.DateTimeSystemFormat);
		}

		public static bool IsDate(string dateTime)
		{
			bool ReturnValue = true;
			DateTime TheDateTime;

			try
			{
				TheDateTime = DateTime.Parse(dateTime);
			}
			catch
			{
				ReturnValue = false;
			}

			return ReturnValue;
		}
	}
}




