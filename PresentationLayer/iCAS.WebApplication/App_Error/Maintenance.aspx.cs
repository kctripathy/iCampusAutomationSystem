using Micro.WebApplication.App_UserControls;
using System;
using System.Configuration;
using System.Text.RegularExpressions;


namespace Micro.WebApplication.App_Error
{
	public partial class Maintenance : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (ConfigurationManager.AppSettings["UnavailableDateTime"] != null)
			{
				// Hide the menu items during login process
                ((WebUserControlMenu)Master.FindControl("WebUserControlMenu1")).Visible = false;
				//((UC_LeftColumn)Master.FindControl("ctrl_LeftColumn")).Visible = false;
				//((UC_UserLoggedOn)Master.FindControl("ctrl_LoggedOnUser")).Visible = false;


				string StrUnavailableDateTimeList = (string)ConfigurationManager.AppSettings["UnavailableDateTime"];
				
				Regex RegRangeTime = new Regex("[;]");
				string[] TabRangeTime = RegRangeTime.Split(StrUnavailableDateTimeList);
				
				if (TabRangeTime.Length == 1)
				{
					LabelEnglishDateTime.Text = String.Format("date {0}", DateTime.Parse(TabRangeTime[0].Replace("-", " ")).ToString("dd MMMM yy  -  HH:mm"));

				}
				if (TabRangeTime.Length == 2)
				{
					LabelEnglishDateTime.Text = String.Format("date {0} to {1}", 
														DateTime.Parse(TabRangeTime[0].Replace("-", " ")).ToString("dd MMMM yyyy - HH:mm"),
														DateTime.Parse(TabRangeTime[1].Replace("-", " ")).ToString("dd MMMM yyyy - HH:mm"));
				}
			//    foreach (string RangeTime in TabRangeTime)
			//    {
			//        Regex RegSplitDateTime = new Regex("[-]");
			//        string[] TabDateTime = RegSplitDateTime.Split(RangeTime);

			//        if (TabDateTime.Length == 2)
			//        {
			//            DateTime DateTimeNow = DateTime.Now;
			//            DateTime BeginDateTime = DateTime.ParseExact((string)TabDateTime[0], "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);
			//            DateTime EndDateTime = DateTime.ParseExact((string)TabDateTime[1], "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);

			//            if ((BeginDateTime <= DateTimeNow) && (DateTimeNow <= EndDateTime))
			//            {
			//                CultureInfo CiUS = new CultureInfo("en-US");
			//                LabelEnglishDateTime.Text += String.Format("{0} to {1}", BeginDateTime.ToString("dddd, dd MMMM h:mm tt", CiUS), EndDateTime.ToString("dddd, dd MMMM h:mm tt", CiUS));
			//            }
			//        }
			//    }
			}
		}
	}
}