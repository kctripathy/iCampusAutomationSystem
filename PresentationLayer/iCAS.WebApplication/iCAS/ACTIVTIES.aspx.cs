using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace LTPL.ICAS.WebApplication.iCAS
{
    public partial class ACTIVTIES : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lit_About.Text = GetHtmlTemplateCode();
            }
        }


        private string GetHtmlTemplateCode()
        {
            string htmlCode = string.Empty;
            string sFileName = Request.QueryString["Page"];
            string sFileNameWithPath = string.Concat(Server.MapPath("~"), @"App_Data\ICAS\html\", sFileName, @".htm");
            if (System.IO.File.Exists(sFileNameWithPath))
            {
                WebClient client = new WebClient();
                htmlCode = client.DownloadString(sFileNameWithPath);
                //htmlCode = htmlCode.Substring(5, htmlCode.Length-1);
            }
            else
            {
                htmlCode = @"<h1 class=""PageTitle"">Content preparation on progress! ...</h1>";
            }
            return htmlCode;
        }
        
    }
}