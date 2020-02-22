using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCon.iCAS.WebApplication.App_UserControls.Library
{
    public partial class UC_LibraryBookAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lbl_TheMessage.Text = "btnSave_Click";
            dialog_Message.Show();
        }
    }
}