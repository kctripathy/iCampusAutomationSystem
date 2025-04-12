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
                Exception ex = (Exception)Session["LastError"];
                litError.Text = ex?.Message.ToString();
            }
        }
    }
}