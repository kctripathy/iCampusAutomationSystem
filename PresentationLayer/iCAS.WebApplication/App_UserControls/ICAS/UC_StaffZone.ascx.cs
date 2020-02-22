using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using System.Configuration;

namespace LTPL.ICAS.WebApplication.App_UserControls.ICAS
{
    public partial class UC_StaffZone : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Micro.Commons.Connection.LoggedOnUser != null)
            {
                if (Connection.LoggedOnUser.RoleDescription.ToUpper().Contains("STAFF") ||
                    Connection.LoggedOnUser.RoleDescription.ToUpper().Contains("ADMIN"))
                {
					lit_Welcome.Text = string.Format("<a href='http://{1}/icas/staffs.aspx?Page=View&ID={0}'>My Profile</a>", Micro.Commons.Connection.LoggedOnUser.UserReferenceID,ConfigurationManager.AppSettings["WebServerIP"]);
					lit_Welcome.Text += String.Format(@"&nbsp;:: &nbsp;<a href='http://{0}/APPS/Logout.aspx'><i class='fa fa-sign-out'></i>&nbsp;Log Out</a>", ConfigurationManager.AppSettings["WebServerIP"]);
                }
            }
            else
            {
				lit_Welcome.Text = string.Format("<a href='http://{0}/apps/Userlogin.aspx'><i class='fa fa-sign-in'></i>&nbsp;Login&nbsp;</a>", ConfigurationManager.AppSettings["WebServerIP"]);

            }
        }
    }
}