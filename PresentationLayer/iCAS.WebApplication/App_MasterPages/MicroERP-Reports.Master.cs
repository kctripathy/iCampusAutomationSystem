using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Micro.WebApplication.App_MasterPages
{
	public partial class MicroERP_Reports : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string WebName = ConfigurationManager.AppSettings["ApplicationName"].ToString();
			lbl_Version.Text = String.Format("{0} v.{1}]", WebName, Micro.WebApplication.App_MasterPages.Micro_Website.AssemblyVersion);
			this.Page.Title = lbl_Version.Text;
			lit_OfficeValue.Text = Micro.WebApplication.App_MasterPages.MicroERP_MasterPage.DisplayCompanyOfficeInformation();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Page.Header.DataBind();
		}
	}
}