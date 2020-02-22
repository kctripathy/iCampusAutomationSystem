using System;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using System.Collections.Generic;
using System.Web.UI;

namespace Micro.WebApplication.MicroERP
{
	public partial class Default : Page //BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			//if (!IsPostBack)
			//{
			//	List<WebMenu> CustomisedMenuList = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId((int)MicroEnums.UserRole.Administrator, (int)MicroEnums.UserCompany.TSDC);

			//	foreach (WebMenu item in CustomisedMenuList)
			//	{
			//		if (item.MenuDisplayText == "ICAS-ADMIN")
			//		{
			//			List<WebMenu> CustomisedMenuListAdmin = WebMenuManagement.GetInstance.GetWebMenuAllByParentWebMenuID(item.WebMenuID);
			//			break;                        
			//		}
			//	} 

               
			//}
        }

		protected void btnGO_Click(object sender, EventArgs e)
		{
			//lit_CustomerDetails.Text = ctrl_Customers.CustomerName;

			//List<Customer> theCustList = ctrl_Customers.TheCustomerList;
		}

		protected void btn_Refresh_OnClick(object sender, EventArgs e)
		{
			//System.Threading.Thread.Sleep(4000);
			//ctrl_Chart_Finance.TheOfficeId = ctrl_SelectOffice.SelectedOfficeID;
			//ctrl_Chart_Finance.PopulateChartData();
		}
    }
}