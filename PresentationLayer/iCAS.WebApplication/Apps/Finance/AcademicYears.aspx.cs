using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.Administration;

namespace Micro.WebApplication.APPS.FINANCE
{
    public partial class AcademicYears : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
         

            if (!IsPostBack )
            {
                BindDropdown();
                //SetFormMessages();
                if (HasAddPermission() && IsDefaultModeAdd())
                {

                    multiView_AcademicYear.SetActiveView(view_InputControls);
                    ResetBackColor(view_InputControls);
                }
                else
                {
                   // FillGridView();


                    multiView_AcademicYear.SetActiveView(view_GridView);
                }

            }
        }
        protected void btn_AcademicYears_Click(object sender, EventArgs e)
        {
            try
            {





                multiView_AcademicYear.SetActiveView(view_InputControls);
            }
            catch
            {
            }
        }
        private void BindDropdown()
        {
           


            ddl_Catagory.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.AnalasisFlag.GetStringValue());
            ddl_Catagory.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Catagory.DataBind();
            ddl_Catagory.Items.Insert(0, new ListItem("--Select--"));
          
        }
    }
}