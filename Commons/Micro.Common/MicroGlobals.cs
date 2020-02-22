using System;
using System.Linq;

namespace Micro.Commons
{
    public static class MicroGlobals
    {
        public static string ClickedMenuName = "";

        public static string ReturnZeroIfNull(string val)
        {
            string ReturnValue = string.Empty;

            if (string.IsNullOrEmpty(val))
            {
                ReturnValue = "0";
            }
            else
            {
                ReturnValue = val;
            }

            return ReturnValue;
        }

        public static object ByteDefaultIfNull(object val)
        {
            object ReturnValue;

            if (!string.IsNullOrEmpty(val.ToString()))
                ReturnValue = ((byte[])val).DefaultIfEmpty();
            else
                ReturnValue = null;

            return ReturnValue;
        }

        public static int GetDateDifferenceInMonths(DateTime newestDate, DateTime oldestDate)
        {
            int ReturnValue = int.Parse(Microsoft.VisualBasic.DateAndTime.DateDiff("m", oldestDate, newestDate).ToString());

            if (newestDate.Day < oldestDate.Day)
            {
                if (DateTime.DaysInMonth(oldestDate.Year, oldestDate.Month) != oldestDate.Day)
                {
                    --ReturnValue;
                }
            }

            return ReturnValue;
        }

        public static string GetFilePath(string pathType, string filePath)
        {
            string ReturnValue = string.Empty;

            if (pathType.Equals(MicroEnums.PathType.Absolute.GetStringValue()))
                ReturnValue = filePath;
            else
                ReturnValue = string.Concat(AppDomain.CurrentDomain.BaseDirectory, filePath);

            return ReturnValue;
        }
    }
}
