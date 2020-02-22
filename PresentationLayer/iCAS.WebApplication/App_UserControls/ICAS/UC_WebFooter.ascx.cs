using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;

namespace LTPL.ICAS.WebApplication.App_UserControls.ICAS
{
    public partial class UC_WebFooter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lit_CopyrightSignature.Text = "Copyright @ 2013, Tentulia Sasan Devasthan College, BD Pur (Sasan), Ganjam, Odisha, India - 761120";
            if (!IsPostBack)
            {
                string AppVer = Micro.WebApplication.App_MasterPages.Micro_Website.AssemblyVersion;
                if (Connection.LoggedOnUser != null)
                {
                    lit_CopyrightSignature.Text = string.Format(@"Copyright @ {0} - {1}  |  All Rights Reserverd. | {4} v{5} ] <span id='accessFlag'>accessFLAG={3}</span>",
                                                                        DateTime.Today.Year.ToString(),
                                                                        Connection.LoggedOnUser.CompanyName,
                                                                        Connection.LoggedOnUser.OfficeName,
                                                                        Connection.LoggedOnUser.CanAccessAllOffices,
                                                                        ConfigurationManager.AppSettings["ApplicationName"].ToString(), 
                                                                        AppVer);
                }
                else
                {
                    lit_CopyrightSignature.Text = string.Format(@"Copyright @ {0} - {1} | All Rights Reserverd | {2}",
                                                    DateTime.Today.Year.ToString(),
                                                    ConfigurationManager.AppSettings["ApplicationName"].ToString(), 
                                                    AppVer);
                }
                lit_CopyrightSignature.Text = string.Concat(lit_CopyrightSignature.Text, "<span id='accessFlag'>Developed By: Kishor Tripathy & Team. email : kctripathy@gmail.com , phone: +91 94375-22845 </span>");
            }

        }
    }
}