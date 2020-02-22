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
    public partial class UC_StudentZone : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
			string login_url = string.Format(@"<a href='http://{0}/apps/Userlogin.aspx'><i class='fa fa-sign-in'></i>&nbsp;Login</a>", ConfigurationManager.AppSettings["WebServerIP"]);
			string register_url = string.Format(@"<a href='http://{0}/Students.aspx'><i class='fa fa-sign-in'></i>&nbsp;Registration</a>", ConfigurationManager.AppSettings["WebServerIP"]);

			lit_BeforeLogin.Text = login_url + "   " + register_url;

            //li_StudentZoneLinkWelcome.Visible = false;
            if (Micro.Commons.Connection.LoggedOnUser != null)
            {
                if (Connection.LoggedOnUser.RoleID == 4 &&  Connection.LoggedOnUser.RoleDescription.ToUpper().Contains("STUDENT"))
                {
					string after_login_html = string.Format(@"<a href='http://{0}/Apps/Logout.aspx'><b>Logout</b></a>&nbsp;| &nbsp;" +
															"<a href='http://{0}/APPS/ICAS/ADMIN/StudentFeedBack.aspx'>Submit Feedback</a>" +
															"<a href='http://{0}/Students.aspx?Page=View&ID={1}' class='view_profile'>My Profile</a>", ConfigurationManager.AppSettings["WebServerIP"],
																																						Micro.Commons.Connection.LoggedOnUser.UserReferenceID);

					lit_Welcome.Text = after_login_html;
                    after_login.Visible = true;
                    before_login.Visible = false;
                }
            }
            else
            {
				
                after_login.Visible = false;
                before_login.Visible = true;
				 
            }
        }

        //protected void lnk_ViewProfile_Click(object sender, EventArgs e)
        //{
        //    //string url = string.Format("<b><a href='/Students.aspx?Page=View&ID={0}'
        //}
    }
}