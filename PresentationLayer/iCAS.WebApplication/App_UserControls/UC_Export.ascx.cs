using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCon.iCAS.WebApplication.App_UserControls
{
    public partial class UC_Export : System.Web.UI.UserControl
    {
        public string TheSource
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1Excel_Click(object sender, EventArgs e)
        {
            string theSourceText = TheSource;

        }
    }
}