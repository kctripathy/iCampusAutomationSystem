using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;

namespace Micro.WebApplication.MicroERP.FINANCE
{
    public partial class FinancialYears : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            multiView_FinancialYear.SetActiveView(view_InputControls);
        }

        protected void gview_FinancialYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_View_Click(object sender, EventArgs e)
        {

        }
    }
    }