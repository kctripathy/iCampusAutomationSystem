using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Micro.WebApplication.App_Error
{
	public partial class AccessDenied : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string EmailSupport = (string)ConfigurationManager.AppSettings["EmailSupport"];
				lbl_SupportMessage.Text = "<br><br>For any problem, contact us and refer the incident number " + (string)Session["ExceptionID"] + " at <a href=\"mailto:" + EmailSupport + "?subject=Incident number " + (string)Session["ExceptionID"] + " &amp;body=Incident number " + (string)Session["ExceptionID"] + "\">" + EmailSupport + "</a>.";

                string EmailTechSupport = (string)ConfigurationManager.AppSettings["EmailTechSupportCompany"];
                string EmailTechSupportPerson = (string)ConfigurationManager.AppSettings["EmailTechSupportPerson"];
                string Creator = (string)ConfigurationManager.AppSettings["Creator"];
                string CreatorWebsite = (string)ConfigurationManager.AppSettings["CreatorWebsite"];
                //string CreatorWebsite = (string)ConfigurationManager.AppSettings["CreatorWebsite"];


                lbl_SupportMessage.Text = String.Format(
                                @"Should you need any further information, please feel free to
<a href='mailto:{2}?subject=IncidentNumber_{4}&amp;body=Incident_{5}'>send us a mail</a> 
or
<a href='tel:{6}'>call us over phone</a> to serve you even better.
                                    <br/><br/>
                                    Thanking you,
                                    <br/><br/>
                                    <a href='mailto:{3}?subject=IncidentNumber_{4}&amp;body=Incident_{4}'>
                                    Kishor Tripathy & Team
                                    </a>
                                    <br/>
                                    <a href='http://{1}'>{0}</a>
                                    <br/>
                                    <a href='tel:{6}'>{5}</a>
                                    ", Creator,
                                CreatorWebsite,
                                EmailTechSupport,
                                EmailTechSupportPerson,
                                (string)Session["ExceptionID"],
                                "+91-99380-46866", "9938046866");

			}
		}
	}
}