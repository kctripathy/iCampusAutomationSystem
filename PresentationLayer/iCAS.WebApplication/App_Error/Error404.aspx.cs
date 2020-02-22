using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Micro.WebApplication.App_Error
{
	public partial class Error404 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                string filePath =string.Empty;
				if (Request.QueryString["aspxerrorpath"] != null)
				{
					filePath = Request.QueryString["aspxerrorpath"].ToString();
					lit_FilePath.Text = filePath;
				}

                string EmailTechSupport = (string)ConfigurationManager.AppSettings["EmailTechSupportCompany"];
                string EmailTechSupportPerson = (string)ConfigurationManager.AppSettings["EmailTechSupportPerson"];
                string Creator = (string)ConfigurationManager.AppSettings["Creator"];
                string CreatorWebsite = (string)ConfigurationManager.AppSettings["CreatorWebsite"];
                string ErrorCODE = "404-FILE-NOT-FOUND";
               

                lit_Message.Text = String.Format(
                                @"<br/><br/>
                                    Please <a href='mailto:{2}?subject=IncidentNumber_{4}&amp;body=Incident_{5}' class='btn btn-success btn-xs'>Click here</a>, to report this.
                                    <br/><br/>
                                    <b><a href='{1}' target='_blank'>{0}</a></b> will leave no stones unturned to solve this as soon as possible.
                                    <br/><br/>
                                    Kindly note this reference number (<b><u>{3}</u></b>), for communication with us.
                                    <br/><br/>
                                    Warm Regards & Thanking you,
                                    <br/><br/>
                                    <a href='mailto:{3}?subject=IncidentNumber_{4}&amp;body=Incident_{5}'>Kishor Tripathy & Team</a>
                                    ", Creator,
                                CreatorWebsite,
                                EmailTechSupport,
                                EmailTechSupportPerson,
                                ErrorCODE,
                               filePath);
			}


		}
	}
}