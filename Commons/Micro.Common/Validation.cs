using System;
using System.Text.RegularExpressions;

namespace Micro.Commons
{
    /// <summary>
    /// Contains Useful Validation Functions
    /// </summary>
    /// <author> TULU S. JENA </author>
    /// <Date> 01-01-2012 </Date>

    public static class Validation
    {
        public static bool IsNull(object Val)
        {
            return (Val == null) ? true : false;
        }

        public static bool IsInteger(string Value)
        {
            try
            {
                Convert.ToInt64(Value);
                return true;
            }
            catch
            {
                return false;
            }
        }

		public static bool IsEmail(string Value)
		{
			string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" +
			   @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
			   @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";

			Match match =
                Regex.Match(Value, pattern, RegexOptions.IgnoreCase);

			if(match.Success)
				return true;
			else
				return false;
		}

        public static bool IsTextOnly(string Value)
        {
            bool tmp = true;
            for (int i = 0; i < Value.Length; i++)
            {
                if (IsInteger(Value.Substring(i, 1)) == true)
                {
                    tmp = false;
                    break;
                }
            }
            return tmp;
        }
    }
}
