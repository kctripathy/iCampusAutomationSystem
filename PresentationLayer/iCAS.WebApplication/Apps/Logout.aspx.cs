using System;
using System.Configuration;
using System.Web;

namespace Micro.WebApplication.MicroERP
{
    /// <summary>
    /// Log Out Logged on User
    /// </summary>
	public partial class Logout : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			HttpContext.Current.Session.Clear();
			HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();


			string theDefaultpage = string.Format("http://{0}/", ConfigurationManager.AppSettings["WebServerIP"]);
			Response.Redirect(theDefaultpage);
		}
	}
}