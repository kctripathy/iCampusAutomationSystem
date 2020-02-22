using System;
using System.Configuration;


namespace Micro.WebApplication
{
	public partial class GoverningBody : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack && !IsCallback)
			{
				string theURL = ConfigurationManager.AppSettings["WebServerIP"].ToString() +"/about-governing-body";
				Response.Redirect(theURL);
			}

		}
	}
 
}