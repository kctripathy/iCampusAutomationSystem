using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using System.Text;

public partial class UC_MenuDynamic : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			lit_Menu.Text = GetMenuByParentMenu();
            lit_Menu.Text = string.Concat(lit_Menu.Text, GetMenuByParentMenuAdmin());
			//lit_Menu.Text = GenerateMenuByRoleID(1);
			//lit_Transaction.Text = GetMenuByRoleAndModule(1);
			//lit_Customer.Text = GetMenuByRoleAndModule(47);
			//lit_Administration.Text = GetMenuByRoleAndModule(46);
			//lit_Finance.Text = GetMenuByRoleAndModule(48);
			//lit_User.Text = GetMenuByRoleAndModule(17);
			//lit_Human.Text = GetMenuByRoleAndModule(215);
		}
	}

	//private string GenerateMenuByRoleAndModule(int roleId, int moduleId)
	//{
	//    System.Text.StringBuilder TheMenuItems = new System.Text.StringBuilder();
	//    List<WebMenu> MenuItemList = new List<WebMenu>();
	//    MenuItemList = WebMenuManagement.GetInstance.GetWebMenusByRoleID(1);

	//    TheMenuItems.Append("<ul class='MenuItems'>");
	//    for (int ctr = 1; ctr < 15; ctr++)
	//    {
	//        string WebLinkURL = "WebLinkURL.aspx" + ctr.ToString();
	//        string WebLinkText = "Link - " + ctr.ToString();

	//        string TheMenuItemHTML = String.Format("<li><a href='{0}'>{1}</a> </li>", WebLinkURL, WebLinkText);

	//        TheMenuItems.Append(TheMenuItemHTML);
	//    }
	//    TheMenuItems.Append("</ul>");

	//    return TheMenuItems.ToString();
	//}


	///// <summary>
	///// This function dynamically generates its menu items from database and returns the html tag.
	///// </summary>
	///// <param name="roleID"></param>
	///// <returns></returns>
	//private string GenerateMenuByRoleID(int roleID)
	//{

	//    // lit_MicroTransactions. Text =
	//    //    <ul class='MenuItems'>
	//    //    <li class='MenuSubHeading'>Customer Account:</li>
	//    //    <li><a href='/APPS/CRMS/CRMScrolls.aspx'>Manage Scrolls</a></li>
	//    //    <li><a href='/APPS/CRMS/CRMScrollManager.aspx'>Scroll Viewer</a></li>
	//    //    <li><a href='/APPS/CRMS/CustomerAccounts.aspx'>Customer Accounts</a></li>
	//    //    <li><a href='#'>Customer Account Receipts</a></li>
	//    //    <li class='MenuSubHeading'>Loan:</li>
	//    //    <li><a href='/APPS/CRMS/CustomerLoanPayments.aspx'>Customer Loan Payment</a></li>
	//    //    <li><a href='/APPS/CRMS/CustomerLoanReceipts.aspx'>Customer Loan Recovery</a></li>
	//    //    <li><a href='/APPS/CRMS/GuarantorLoanApplications.aspx'>Guarantor Loan Application</a></li>
	//    //    <li><a href='/APPS/CRMS/GuarantorLoanApprovals.aspx'>Guarantor Loan Approval</a></li>
	//    //    <li><a href='/APPS/CRMS/GuarantorLoanPayments.aspx'>Guarantor Loan Payment</a></li>
	//    //    <li><a href='/APPS/CRMS/GuarantorLoanReceipts.aspx'>Guarantor Loan Recovery</a></li>
	//    //    <li class="MenuSubHeading">Collection:</li>
	//    //    <li><a href="#">Record Daily Collection</a></li>
	//    //    <li><a href="#">New Application</a></li>
	//    //    <li><a href="#">Renew Application</a></li>
	//    //    <li><a href="#">Testing Link 2</a></li>
	//    //    <li class="MenuSubHeading">Payments:</li>
	//    //    <li><a href="/APPS/CRMS/MISInterestPayments.aspx">MIS Payment</a></li>
	//    //    <li><a href="/APPS/CRMS/PolicySurrenders.aspx">Policy Surrenders</a> </li>
	//    //    <li class="MenuSubHeading">Brokerage Fees:</li>
	//    //    <li><a href="/APPS/CRMS/CalculateBrokerageFee.aspx">Brokerage Fee Calculation</a> </li>
	//    //    <li><a href="/APPS/CRMS/BrokerageFeePayments.aspx">Brokerage Fee Payment</a></li>
	//    //</ul>";

	//    System.Text.StringBuilder TheMenuItems = new System.Text.StringBuilder();

	//    TheMenuItems.Append("<ul class='MenuItems'>");
	//    for (int ctr = 1; ctr < 15; ctr++)
	//    {
	//        string WebLinkURL = "WebLinkURL.aspx" + ctr.ToString();
	//        string WebLinkText = "Link - " + ctr.ToString();

	//        string TheMenuItemHTML = String.Format("<li><a href='{0}'>{1}</a> </li>", WebLinkURL, WebLinkText);

	//        TheMenuItems.Append(TheMenuItemHTML);
	//    }
	//    TheMenuItems.Append("</ul>");

	//    return TheMenuItems.ToString();

	//}


	//public string GetMenuByRoleAndModule(int TheParentWebMenuId)
	//{
	//    StringBuilder menuItem = new StringBuilder();
	//    int RoleId = Connection.LoggedOnUser.RoleID;
	//    List<WebMenu> WebMenuList = new List<WebMenu>();
	//    WebMenuList = WebMenuManagement.GetInstance.GetWebMenusByRoleID(RoleId);
	//    menuItem.Append("<ul class='MenuItems'>");
	//    foreach (WebMenu menu in WebMenuList)
	//    {
	//        string WebLinkURL = menu.NavigationURL.ToString();
	//        int parentWebMenuId = menu.ParentWebMenuID;
	//        string WebLinkText = menu.MenuDisplayText.ToString();


	//        if (menu.ParentWebMenuID == TheParentWebMenuId)
	//        {
	//            string TheMenuItemHTML = String.Format("<li ><a href='{0}'>{1}</a> </li><br/>", GetURLPath() + WebLinkURL, WebLinkText, parentWebMenuId);

	//            menuItem.Append(TheMenuItemHTML);

	//        }

	//    }
	//    menuItem.Append("</ul class='MenuItems' >");
	//    return menuItem.ToString();
	//}


	private string GetMenuByParentMenu()
	{
		int RoleID = 0;
		StringBuilder sbMenu = new StringBuilder();
		try
		{
			RoleID = Micro.Commons.Connection.LoggedOnUser.RoleID;
			List<WebMenu> theParentWebMenuList = WebMenuManagement.GetInstance.GetParentWebMenuAll();

			sbMenu.Append("<ul id='DropDownMenu'>");
			foreach (WebMenu theWebMenu in theParentWebMenuList)
			{
				string ParentWebMenu = theWebMenu.MenuDisplayText;
				int ParentWebMenuID = theWebMenu.WebMenuID;
				sbMenu.Append("<li>");
				string TheParentMenuDisplayText = String.Format("<a href='#'>{0}</a>", ParentWebMenu);
				sbMenu.Append(TheParentMenuDisplayText);
				List<WebMenu> theWebMenuList = new List<WebMenu>();
				theWebMenuList = WebMenuManagement.GetInstance.GetWebMenusByRoleID(RoleID);
				sbMenu.Append("<ul>");
				foreach (WebMenu objWebMenu in theWebMenuList)
				{

					string TheMenuDisplayText = objWebMenu.MenuDisplayText;
					string TheWebLinkURL = objWebMenu.NavigationURL;
					int TheParentWebMenuId = objWebMenu.ParentWebMenuID;
					if (TheParentWebMenuId == ParentWebMenuID)
					{
						string TheMenuItemHTML = String.Format("<li><a href='{0}'>{1}</a> </li>", GetURLPath() + TheWebLinkURL, TheMenuDisplayText, ParentWebMenuID);
						sbMenu.Append(TheMenuItemHTML);

						List<WebMenu> ChildMenuList = WebMenuManagement.GetInstance.GetWebMenuAllByParentWebMenuID(objWebMenu.FormOrMenuID);
						if (ChildMenuList.Count > 0 )
						{
							sbMenu.Append("<ul class='SubSubMenu'>");
							foreach (WebMenu objWebChildMenu in ChildMenuList)
							{
								string TheMenuDisplayText2 = objWebChildMenu.MenuDisplayText;
								string TheWebLinkURL2 = objWebChildMenu.NavigationURL;
								int TheParentWebMenuId2 = objWebChildMenu.ParentWebMenuID;
								//if (TheParentWebMenuId2 == TheParentWebMenuId)
								//{
								string TheMenuItemHTML2 = String.Format("<li><a href='{0}'>{1}</a> </li>", GetURLPath() + TheWebLinkURL2, TheMenuDisplayText2, TheParentWebMenuId2);
									sbMenu.Append(TheMenuItemHTML2);
								//}
							}
							sbMenu.Append("</ul>");
							
						}
					}


				}
				sbMenu.Append("</ul>");
			}
			sbMenu.Append("</li>");
			sbMenu.Append("</ul>");
		}

		catch
		{

		}
		return sbMenu.ToString();

	}

    private string GetMenuByParentMenuAdmin()
    {
        int RoleID = 0;
        StringBuilder sbMenu = new StringBuilder();
        try
        {
            RoleID = 1;
            List<WebMenu> theParentWebMenuList = WebMenuManagement.GetInstance.GetParentWebMenuAll();
            //List<WebMenu> theParentWebMenuListAdmin = (from abc in theParentWebMenuList
            //                                           where abc.RoleID == 1
            //                                           select abc).ToList();
            sbMenu.Append("<ul id='DropDownMenu'>");
            foreach (WebMenu theWebMenu in theParentWebMenuList)
            {
                string ParentWebMenu = theWebMenu.MenuDisplayText;
                int ParentWebMenuID = theWebMenu.WebMenuID;
                sbMenu.Append("<li>");
                string TheParentMenuDisplayText = String.Format("<a href='#'>{0}</a>", ParentWebMenu);
                sbMenu.Append(TheParentMenuDisplayText);
                List<WebMenu> theWebMenuList = new List<WebMenu>();
                theWebMenuList = WebMenuManagement.GetInstance.GetWebMenusByRoleID(RoleID);
                sbMenu.Append("<ul>");
                foreach (WebMenu objWebMenu in theWebMenuList)
                {

                    string TheMenuDisplayText = objWebMenu.MenuDisplayText;
                    string TheWebLinkURL = objWebMenu.NavigationURL;
                    int TheParentWebMenuId = objWebMenu.ParentWebMenuID;
                    if (TheParentWebMenuId == ParentWebMenuID)
                    {
                        string TheMenuItemHTML = String.Format("<li><a href='{0}'>{1}</a> </li>", GetURLPath() + TheWebLinkURL, TheMenuDisplayText, ParentWebMenuID);
                        sbMenu.Append(TheMenuItemHTML);

                        List<WebMenu> ChildMenuList = WebMenuManagement.GetInstance.GetWebMenuAllByParentWebMenuID(objWebMenu.FormOrMenuID);
                        if (ChildMenuList.Count > 0)
                        {
                            sbMenu.Append("<ul class='SubSubMenu'>");
                            foreach (WebMenu objWebChildMenu in ChildMenuList)
                            {
                                string TheMenuDisplayText2 = objWebChildMenu.MenuDisplayText;
                                string TheWebLinkURL2 = objWebChildMenu.NavigationURL;
                                int TheParentWebMenuId2 = objWebChildMenu.ParentWebMenuID;
                                //if (TheParentWebMenuId2 == TheParentWebMenuId)
                                //{
                                string TheMenuItemHTML2 = String.Format("<li><a href='{0}'>{1}</a> </li>", GetURLPath() + TheWebLinkURL2, TheMenuDisplayText2, TheParentWebMenuId2);
                                sbMenu.Append(TheMenuItemHTML2);
                                //}
                            }
                            sbMenu.Append("</ul>");

                        }
                    }


                }
                sbMenu.Append("</ul>");
            }
            sbMenu.Append("</li>");
            sbMenu.Append("</ul>");
        }

        catch
        {

        }
        return sbMenu.ToString();

    }
	public string GetURLPath()
	{
		String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
		String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
		return strUrl;
	}

}

