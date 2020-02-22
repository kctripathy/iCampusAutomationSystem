using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Micro.Commons
{
	public class Helpers
	{
		public static string GetLanguage()
		{
			return Thread.CurrentThread.CurrentCulture.Name;
		}

		public static CultureInfo GetCulture()
		{
			return Thread.CurrentThread.CurrentCulture;
		}

		public static string GetPageName(Page CurrentPage)
		{
			return CurrentPage.Request.Path.Substring(CurrentPage.Request.Path.LastIndexOf("/") + 1, (CurrentPage.Request.Path.LastIndexOf("aspx") - CurrentPage.Request.Path.LastIndexOf("/") + 3));
		}

		public static string GetFullPathPageName(Page CurrentPage)
		{
			return CurrentPage.Request.AppRelativeCurrentExecutionFilePath.Substring(2).Trim();
		}


		public static string ExtractFileName(string FullPath)
		{
			return FullPath.Substring(FullPath.LastIndexOf(@"\") + 1, (FullPath.LastIndexOf(".") - FullPath.LastIndexOf(@"\") + 3));
		}

		public static string GetApplicationPath(Page CurrentPage)
		{
			if(CurrentPage.Request.ApplicationPath.Length == 1)
			{
				return CurrentPage.Request.ApplicationPath;
			}
			else
			{
				return CurrentPage.Request.ApplicationPath + "/";
			}
		}

		public static string GetApplicationPath(HttpRequest CurrentRequest)
		{
			if(CurrentRequest.ApplicationPath.Length == 1)
			{
				return CurrentRequest.ApplicationPath;
			}
			else
			{
				return CurrentRequest.ApplicationPath + "/";
			}
		}

		#region Display Methods
		/// <summary>
		/// Returns a formatted date like "dd MMM yyyy"
		/// </summary>
		/// <param name="CurrentDateTime"></param>
		/// <returns></returns>
		public static string DisplayDate(DateTime CurrentDateTime)
		{
			return CurrentDateTime.ToString("dd MMM yyyy");
		}

		/// <summary>
		/// Returns a formatted date like "MM yyyy"
		/// </summary>
		/// <param name="CurrentDateTime"></param>
		/// <returns></returns>
		public static string DisplayMonthDate(DateTime CurrentDateTime)
		{
			return ToUpperLowerCase(CurrentDateTime.ToString("MMMM yyyy"));
		}

		/// <summary>
		/// Returns a formatted date like "dd MMM yyyy HH:mm"
		/// </summary>
		/// <param name="CurrentDateTime"></param>
		/// <returns></returns>
		public static string DisplayDateTime(DateTime CurrentDateTime)
		{
			return CurrentDateTime.ToString("dd MMM yyyy HH:mm");
		}

		/// <summary>
		/// Returns a formatted date like "ddd dd MMM yy"
		/// </summary>
		/// <param name="CurrentDateTime"></param>
		/// <returns></returns>
		public static string DisplaySchedulesDate(DateTime CurrentDateTime)
		{
			return CurrentDateTime.ToString("ddd dd MMM yy");
		}

		/// <summary>
		/// Returns a formatted date like "ddd dd MMM yy HH:mm"
		/// </summary>
		/// <param name="CurrentDateTime"></param>
		/// <returns></returns>
		public static string DisplayCutoffDateTime(DateTime CurrentDateTime)
		{
			return CurrentDateTime.ToString("ddd dd MMM yy HH:mm");
		}

		/// <summary>
		/// Returns a formatted date like "MMM dd, HH:mm"
		/// </summary>
		/// <param name="CurrentDateTime"></param>
		/// <returns></returns>
		public static string DisplayShortDateTime(DateTime CurrentDateTime)
		{
			return CurrentDateTime.ToString("MMM dd, HH:mm");
		}

		public static string DisplayDateFormat()
		{
			return (string)HttpContext.GetGlobalResourceObject("Common", "DateFormat", Helpers.GetCulture());
		}
		#endregion Display Methods

		#region Strings Methods
		public static string ToUpperLowerCase(string CurrentString)
		{
			if(CurrentString.Length > 0)
			{
				if(CurrentString.Length == 1)
				{
					return CurrentString.ToUpper();
				}
				else
				{
					return CurrentString.Substring(0, 1).ToUpper() + CurrentString.Substring(1, CurrentString.Length - 1).ToLower();
				}
			}
			else
			{
				return "";
			}
		}

		public static string ToCapitalize(string CurrentString)
		{
			string NewString = string.Empty;

			Regex regSepar = new Regex("[ ]");
			string[] tabMots = regSepar.Split(CurrentString.ToLower());

			foreach(string mot in tabMots)
			{
				if(NewString != string.Empty)
				{
					NewString += " ";
				}
				NewString += ToUpperLowerCase(mot);
			}

			return (NewString);
		}

		public static string ReplaceQuote(string strText)
		{
			return strText.Replace("'", "&#34");
		}
		#endregion

		#region Dropdownlist values
		public static List<string> GetDropdownlistValueYears()
		{
			List<string> yearList = new List<string>();
			yearList.Add("----");
			for(int x = 1950;x <= DateTime.Now.Year;x++)
			{
				yearList.Add(x.ToString());
			}
			return yearList;
		}

		public static List<string> GetDropdownlistValueMonths()
		{
			List<string> monthList = new List<string>();
			monthList.Add("--");
			monthList.Add("1");
			monthList.Add("2");
			monthList.Add("3");
			monthList.Add("4");
			monthList.Add("5");
			monthList.Add("6");
			monthList.Add("7");
			monthList.Add("8");
			monthList.Add("9");
			monthList.Add("10");
			monthList.Add("11");
			monthList.Add("12");
			return monthList;
		}

		public static List<string> GetDropdownlistValueDays()
		{
			List<string> daysList = new List<string>();
			daysList.Add("--");
			for(int y = 1;y <= 31;y++)
			{
				daysList.Add(y.ToString());
			}
			return daysList;
		}

		public static int GetSelectedIndex(string valueToCompare, ref DropDownList ddList)
		{
			int ctr = 0;
			foreach(ListItem l in ddList.Items)
			{
				if(l.Value == valueToCompare)
				{
					break;
				}
				ctr++;
			}
			return ctr;
		}

		public static string SplitCamelCase(string str)
		{
			return Regex.Replace(Regex.Replace(str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
		}


		public static string ResolveURL(string link)
		{
			string TheFullLinkURL = string.Empty;
			if (link.Trim().Equals(string.Empty))
			{
				TheFullLinkURL = @"Javascript:alert(""Page under construction."");";
			}
			else
			{
				TheFullLinkURL = string.Format("http://{0}/{1}", ConfigurationManager.AppSettings["WebServerIP"].ToString(), link);
			}
			return TheFullLinkURL;
		}

		public static string RedirectURL(string redirectURL)
		{
			string TheFullLinkURL = string.Empty;
			if (redirectURL.Trim().Equals(string.Empty))
			{
				TheFullLinkURL = @"Javascript:alert(""Link not available."");";
			}
			else
			{
				TheFullLinkURL = string.Format("~/{0}", redirectURL);
			}
			return TheFullLinkURL;
		}
		public static string GetCompanyAlias()
		{
			if (Micro.Commons.Connection.LoggedOnUser == null)
				return string.Empty;
			else
				return Micro.Commons.Connection.LoggedOnUser.CompanyAliasName.ToString();
		}
		public static string GetCompanyAlias(Page CurrentPage)
		{
			return CurrentPage.Request.AppRelativeCurrentExecutionFilePath.Substring(2).Trim().Substring(11, 4);
		}
		public static string GetCurrentCompanyCode()
		{
			return Micro.Commons.Connection.LoggedOnUser.CompanyCode;
		}
		public static string GetFullPathCompanyAlias(Page CurrentPage)
		{
			return CurrentPage.Request.AppRelativeCurrentExecutionFilePath.Substring(2).Trim().Substring(0, 15);
		}

		#endregion
	}
}