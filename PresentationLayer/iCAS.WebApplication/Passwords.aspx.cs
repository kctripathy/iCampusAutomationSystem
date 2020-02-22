using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCon.iCAS.WebApplication
{
    public partial class Passwords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            if (ddlOption.SelectedValue=="E") //if user wants text to encrypt
            {
                str = Micro.Commons.MicroSecuritty.EncryptString(txt_Source.Text);
            }
            else if (ddlOption.SelectedValue == "D") // if user want a encrypted text to decrypt
            {
                str = Micro.Commons.MicroSecuritty.DecryptString(txt_Source.Text);
            }
            txt_Result.Text = str;
        }
    }
}