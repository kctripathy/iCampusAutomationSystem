using System;
using System.Web;

namespace Micro.WebApplication
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            //Declare Login Success Global Variable and set it to false
			HttpContext.Current.Session["IsLoginSuccess"] = string.Empty;
			;

		}
	}
}