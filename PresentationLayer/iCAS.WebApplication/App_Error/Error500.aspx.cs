using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;

namespace Micro.WebApplication.App_Error
{
    public partial class Error500 : System.Web.UI.Page
    {
        public string RedirectPage
        {
            get
            {
                string PageReturn = string.Empty;
                if (Request["errorpath"] != null)
                {
                    PageReturn = Request["errorpath"].ToString();
                }
                return PageReturn;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Title = "Error 500";

            if (!Page.IsPostBack)
            {
                Exception ex = (Exception)Session["LastError"];
                try
                {
                    LabelError.Text = (string)ex.Message;
                    LabelTime.Text = string.Format("{0}  {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
                    LabelTarget.Text = ((string)ex.StackTrace).ToString().Replace("Micro", ConfigurationManager.AppSettings["DefaultCompanyAlias"].ToString());
                    LabelErrorPage.Text = RedirectPage;
                    lbl_Reason.Text = String.Format("Some error occured while executing the code of {0}", ConfigurationManager.AppSettings["ApplicationName"].ToString());

                    string EmailTechSupport = (string)ConfigurationManager.AppSettings["EmailTechSupportCompany"];
                    string EmailTechSupportPerson = (string)ConfigurationManager.AppSettings["EmailTechSupportPerson"];
                    string Creator = (string)ConfigurationManager.AppSettings["Creator"];
                    string CreatorWebsite = (string)ConfigurationManager.AppSettings["CreatorWebsite"];
                    //string CreatorWebsite = (string)ConfigurationManager.AppSettings["CreatorWebsite"];


                    lit_ErrorMessage.Text = String.Format(
                                    @"<a href='mailto:{2}?subject=IncidentNumber_{4}&amp;body=Incident_{5}' class='btn btn-success btn-xs'>Click here to send a mail</a> regarding this issue to <b><a href='{1}' target='_blank'>{0}</a></b> to fix this issue as soon as possible.
                                    <br/><br/>
                                    Kindly note this reference number (<b><u>{4}</u></b>). It will be in use while all communications to service provider regarding this matter.
                                    <br/><br/>
                                    Warm Regards & Thanking you,
                                    <br/><br/>
                                    <a href='mailto:{3}?subject=IncidentNumber_{4}&amp;body=Incident_{5}'>Kishor Tripathy & Team</a>
                                    ", Creator,
                                    CreatorWebsite,
                                    EmailTechSupport,
                                    EmailTechSupportPerson,
                                    (string)Session["ExceptionID"],
                                    LabelError.Text);

                }
                catch (Exception exp)
                {
                    LabelError.Text = exp.Message;
                    LabelTarget.Text = (string)exp.StackTrace;
                }
            }
        }
    }
}