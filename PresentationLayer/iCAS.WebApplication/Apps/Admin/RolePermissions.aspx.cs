using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using System.Text;
using Micro.Commons;
using System.Drawing;
namespace Micro.WebApplication.MicroERP.ADMIN
{
    /// <summary>
    /// Edit Form & Menu Permission by role
    /// </summary>
	public partial class RolePermissions : BasePage
	{
		#region Events

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				PopulateRoles();
				PopulatePermissions();
				BindTreeview_Menus(Micro.Commons.Connection.LoggedOnUser.RoleID);
				lit_MenuOrForm.Text = SayPageTitle();
			}
		}

		protected void btn_Submit_Click(object sender, EventArgs e)
		{
			if (chk_MenuOrForm.SelectedItem.Value.ToString().ToUpper().Equals("F"))
			{
				RecordPermissionForForms();
			}

			if (chk_MenuOrForm.SelectedItem.Value.ToString().Equals("M"))
			{
				RecordPermissionForMenuItems();
			}
		}

		protected void chkListRoles_SelectedIndexChanged(object sender, EventArgs e)
		{
			//int TheRoleId = int.Parse(chkList_Roles.SelectedValue.ToString());

			//lit_MenuOrForm.Text = SayPageTitle();
			//if (chk_MenuOrForm.SelectedItem.Value.Equals("F"))
			//{
			//    BindGridView_Forms(TheRoleId);
			//}
			//else
			//{
			//    BindTreeview_Menus(TheRoleId);
			//}
			chk_MenuOrForm_SelectedIndexChanged(null, null);
		}

		protected void chk_MenuOrForm_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool TrueFalse = true;
			lit_MenuOrForm.Text = SayPageTitle();
			int TheRoleId = int.Parse(chkList_Roles.SelectedValue.ToString());
			if (chk_MenuOrForm.SelectedItem.Value.ToString().ToUpper().Equals("F"))
			{
				BindGridView_Forms(TheRoleId);
				TrueFalse = true;
				 

			}
			else
			{
				TrueFalse = false;
				BindTreeview_Menus(TheRoleId);
			}

			li_Forms.Visible = TrueFalse;
			//li_Roles.Visible = !TrueFalse;
			li_Menus.Visible = !(TrueFalse);

		}

		protected void chkSelectAll_Add_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chkAll = (CheckBox)gview_FormPermissions.HeaderRow.FindControl("chkSelectAll_Add");
			if (chkAll.Checked == true)
			{
				foreach (GridViewRow gvRow in gview_FormPermissions.Rows)
				{
					CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
					chkSel.Checked = true;

				}
			}
			else
			{
				foreach (GridViewRow gvRow in gview_FormPermissions.Rows)
				{
					CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
					chkSel.Checked = false;

				}
			}
		}

		protected void chkSelectAll_Edit_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chkAll = (CheckBox)gview_FormPermissions.HeaderRow.FindControl("chkSelectAll_Edit");
			if (chkAll.Checked == true)
			{
				foreach (GridViewRow gvRow in gview_FormPermissions.Rows)
				{
					CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Edit");
					chkSel.Checked = true;

				}
			}
			else
			{
				foreach (GridViewRow gvRow in gview_FormPermissions.Rows)
				{
					CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Edit");
					chkSel.Checked = false;

				}
			}
		}

		protected void chkSelectAll_Del_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chkAll = (CheckBox)gview_FormPermissions.HeaderRow.FindControl("chkSelectAll_Del");
			if (chkAll.Checked == true)
			{
				foreach (GridViewRow gvRow in gview_FormPermissions.Rows)
				{
					CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Del");
					chkSel.Checked = true;

				}
			}
			else
			{
				foreach (GridViewRow gvRow in gview_FormPermissions.Rows)
				{
					CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Del");
					chkSel.Checked = false;

				}
			}
		}

		protected void chkSelectAll_View_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chkAll = (CheckBox)gview_FormPermissions.HeaderRow.FindControl("chkSelectAll_View");
			if (chkAll.Checked == true)
			{
				foreach (GridViewRow gvRow in gview_FormPermissions.Rows)
				{
					CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_View");
					chkSel.Checked = true;

				}
			}
			else
			{
				foreach (GridViewRow gvRow in gview_FormPermissions.Rows)
				{
					CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_View");
					chkSel.Checked = false;

				}
			}
		}

		protected void gview_FormPermissions_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					string navUrl = e.Row.Cells[2].Text;
					e.Row.ForeColor = SetFormGridForeColor(navUrl);
					e.Row.BackColor = SetFormGridBackColor(navUrl);
				}
			}
			catch (Exception ex)
			{
				string msg = ex.Message.ToString();
			}
		}
		#endregion

		#region Methods

		private void PopulatePermissions()
		{
			//chkList_Permission.Items.Clear();
			//chkList_Permission.DataSource = BasePage.CurrentLoggedOnUser.PermissionList;
			//chkList_Permission.DataTextField = "PermissionDescription";
			//chkList_Permission.DataValueField = "PermissionId";
			//chkList_Permission.DataBind();
		}

		private void PopulateRoles()
		{
			List<Role> RolesList = RolesManagement.GetInstance.GetRolesList();

			chkList_Roles.DataSource = RolesList;
			chkList_Roles.DataTextField = "RoleDescription";
			chkList_Roles.DataValueField = "RoleID";
			chkList_Roles.DataBind();
			chkList_Roles.RepeatDirection = RepeatDirection.Vertical;

			foreach (ListItem li in chkList_Roles.Items)
			{
				if (li.Value == Micro.Commons.Connection.LoggedOnUser.RoleID.ToString())
				{
					li.Selected = true;
				}
				else
				{
					li.Selected = false;
				}
			}
		}

		private void BindTreeview_Menus(int roleId)
		{
			TreeNode MyParentNode;
			TreeNode MyChildNode;

			try
			{
				List<WebMenu> CustomisedMenuList = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(0);
				List<WebMenu> CustomisedMenuListByRole = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(roleId);


				List<WebMenu> ParentMenuItems = (from m in CustomisedMenuList
												 where m.ParentWebMenuID == -1
												 orderby m.DisplayOrder
												 select m).ToList<WebMenu>();


				tview_RolePermissions.Nodes.Clear();
				foreach (WebMenu objParentMenu in ParentMenuItems)
				{
					string ParentWebMenu = objParentMenu.MenuDisplayText;
					int ParentWebMenuID = objParentMenu.WebMenuID;
					string ParentWebImage = objParentMenu.ImageURL;

					MyParentNode = new TreeNode(ParentWebMenu, ParentWebMenuID.ToString());
					MyParentNode.Checked = WillSelectCheckBox(ParentWebMenuID, CustomisedMenuListByRole);

					tview_RolePermissions.Nodes.Add(MyParentNode);

					List<WebMenu> ChildMenuItems = (from mm in CustomisedMenuList
													where mm.ParentWebMenuID == objParentMenu.WebMenuID //&& mm.IsDeleted == false && mm.IsActive == true
													orderby mm.DisplayOrder
													select mm).ToList<WebMenu>();

					if (ChildMenuItems.Count > 0)
					{

						foreach (WebMenu objChildMenu in ChildMenuItems)
						{
							string ChildWebMenu = objChildMenu.MenuDisplayText;
							int ChildWebMenuID = objChildMenu.WebMenuID;

							MyChildNode = new TreeNode();
							MyChildNode.Text = ChildWebMenu;
							MyChildNode.Value = ChildWebMenuID.ToString();
							MyChildNode.Checked = WillSelectCheckBox(ChildWebMenuID, CustomisedMenuListByRole);

							MyParentNode.ChildNodes.Add(MyChildNode);


							List<WebMenu> ChildSubMenuItems = (from mmm in CustomisedMenuList
															   where mmm.ParentWebMenuID == objChildMenu.WebMenuID //&& mmm.IsDeleted == false && mmm.IsActive == true
															   orderby mmm.DisplayOrder
															   select mmm).ToList<WebMenu>();
							if (ChildSubMenuItems.Count > 0)
							{
								foreach (WebMenu objChildSubMenu in ChildSubMenuItems)
								{
									string ChildWebSubMenu = objChildSubMenu.MenuDisplayText;

									TreeNode ChildNode2 = new TreeNode();
									ChildNode2 = new TreeNode();
									ChildNode2.Text = ChildWebSubMenu;
									ChildNode2.Value = objChildSubMenu.WebMenuID.ToString();
									ChildNode2.Checked = WillSelectCheckBox(objChildSubMenu.WebMenuID, CustomisedMenuListByRole);

									MyChildNode.ChildNodes.Add(ChildNode2);
								}
							}

						}
						MyParentNode.CollapseAll();

					}

				}
				if (tview_RolePermissions.Nodes.Count > 1)
				{
					tview_RolePermissions.Nodes[1].ExpandAll();
				}
			}
			catch (Exception ex)
			{

			}
			//sbMenu.Append("</ul>");

		}

		private void BindGridView_Forms(int roleId)
		{
			try
			{
				List<WebMenu> CustomisedMenuList = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(roleId);

				List<WebMenu> BindMenuItems = (from m in CustomisedMenuList
											   where
												  m.ParentWebMenuID != -1 &&
												  m.NavigationURL.Trim().Length > 0 &&
												  !m.NavigationURL.ToLower().Contains("reports") ||
												  m.MenuDisplayText.Trim().ToLower().Contains("home")
											   orderby m.ParentWebMenuID, m.DisplayOrder
											   select m).ToList<WebMenu>();


				// Bind the GridView for the forms
				gview_FormPermissions.DataSource = BindMenuItems;
				gview_FormPermissions.DataBind();




				CheckUncheckGridItems();

			}

			catch (Exception ex)
			{

			}
			//sbMenu.Append("</ul>");

		}

		private void CheckUncheckGridItems()
		{

			int TheRoleId = int.Parse(chkList_Roles.SelectedValue.ToString());
			List<RolePermission> ThePermissionListByRole = RolePermissionManagement.GetInstance.SelectAllRolePermissionsByRoleID(TheRoleId);


			foreach (GridViewRow gvRow in gview_FormPermissions.Rows)
			{
				CheckBox chkSelAdd = (CheckBox)gvRow.FindControl("chk_Add");
				CheckBox chkSelEdit = (CheckBox)gvRow.FindControl("chk_Edit");
				CheckBox chkSelDel = (CheckBox)gvRow.FindControl("chk_Del");
				CheckBox chkSelView = (CheckBox)gvRow.FindControl("chk_View");
				Label lbl_WebMenuID = (Label)gvRow.FindControl("lbl_WebMenuId");
				int FormId = int.Parse(lbl_WebMenuID.Text);

				chkSelAdd.Checked = WillSelectCheckBox(ThePermissionListByRole, FormId, BasePage.AddPermissionId, 'F');
				chkSelEdit.Checked = WillSelectCheckBox(ThePermissionListByRole, FormId, BasePage.EdiPermissionId, 'F');
				chkSelDel.Checked = WillSelectCheckBox(ThePermissionListByRole, FormId, BasePage.DelPermissionId, 'F');
				chkSelView.Checked = WillSelectCheckBox(ThePermissionListByRole, FormId, BasePage.ViewPermissionId, 'F');

			}
		}

		private bool WillSelectCheckBox(List<RolePermission> thePermissionListByRole, int webFormId, int permmisionId, char formOrMenu = 'M')
		{
			bool ReturnValue;
			int TheRoleId = int.Parse(chkList_Roles.SelectedValue.ToString());
			var result = thePermissionListByRole.Find
						(mm =>
							mm.RoleID == TheRoleId &&
							mm.FormOrMenuID == webFormId &&
							mm.PermissionID == permmisionId);

			if (result == null)
			{
				ReturnValue = false;
			}
			else
			{
				ReturnValue = true;
			}
			return ReturnValue;
		}

		private bool WillSelectCheckBox(int menuId, List<WebMenu> MenuListByRole)
		{
			bool ReturnValue;
			var result = MenuListByRole.Find(mm => mm.WebMenuID == menuId);

			if (result == null)
			{
				ReturnValue = false;
			}
			else
			{
				ReturnValue = true;
			}
			return ReturnValue;
		}


		private void RecordPermissionForForms()
		{
			try
			{
				//StringBuilder sbMenuItemIDs = new StringBuilder();

				int TotRecEffected = 0;
				StringBuilder FormIDs_Add = new StringBuilder();
				StringBuilder FormIDs_Edit = new StringBuilder();
				StringBuilder FormIDs_Del = new StringBuilder();
				StringBuilder FormIDs_View = new StringBuilder();

				foreach (GridViewRow gvRow in gview_FormPermissions.Rows)
				{
					CheckBox chkSelAdd = (CheckBox)gvRow.FindControl("chk_Add");
					Label lbl_WebMenuID = (Label)gvRow.FindControl("lbl_WebMenuId");
					if (chkSelAdd.Checked == true)
					{
						FormIDs_Add.Append(string.Format(",{0}", lbl_WebMenuID.Text));
					}

					CheckBox chkSelEdit = (CheckBox)gvRow.FindControl("chk_Edit");
					if (chkSelEdit.Checked == true)
					{
						FormIDs_Edit.Append(string.Format(",{0}", lbl_WebMenuID.Text));
					}

					CheckBox chkSelDel = (CheckBox)gvRow.FindControl("chk_Del");
					if (chkSelDel.Checked == true)
					{
						FormIDs_Del.Append(string.Format(",{0}", lbl_WebMenuID.Text));
					}

					CheckBox chkSelView = (CheckBox)gvRow.FindControl("chk_View");
					if (chkSelView.Checked == true)
					{
						FormIDs_View.Append(string.Format(",{0}", lbl_WebMenuID.Text));
					}

				}
				if (FormIDs_Add.ToString().Length > 1)
				{
					FormIDs_Add.Remove(0, 1);
				}
				if (FormIDs_Edit.ToString().Length > 1)
				{
					FormIDs_Edit.Remove(0, 1);
				}
				if (FormIDs_Del.ToString().Length > 1)
				{
					FormIDs_Del.Remove(0, 1);
				}
				if (FormIDs_View.ToString().Length > 1)
				{
					FormIDs_View.Remove(0, 1);
				}

				int x = 0;
				int RoleId = int.Parse(chkList_Roles.SelectedItem.Value.ToString());

				RolePermissionManagement.GetInstance.DeleteRolePermissions_Web(RoleId,"F");

				TotRecEffected = WebMenuManagement.GetInstance.UpdateWebRolePermissions(RoleId, FormIDs_Add.ToString(), BasePage.AddPermissionId, "F");
				TotRecEffected = WebMenuManagement.GetInstance.UpdateWebRolePermissions(RoleId, FormIDs_Edit.ToString(), BasePage.EdiPermissionId, "F");
				TotRecEffected = WebMenuManagement.GetInstance.UpdateWebRolePermissions(RoleId, FormIDs_Del.ToString(), BasePage.DelPermissionId, "F");
				TotRecEffected = WebMenuManagement.GetInstance.UpdateWebRolePermissions(RoleId, FormIDs_View.ToString(), BasePage.ViewPermissionId, "F");
				//TotRecEffected = WebMenuManagement.GetInstance.UpdateWebRolePermissions(RoleId, FormIDs_View.ToString(), BasePage.ViewPermissionId, "M");


				////foreach (TreeNode parentNode in tview_RolePermissions.Nodes)
				////{
				////    bool WillRecordParentNode = false;
				////    if (parentNode.Checked == true)
				////    {
				////        FormMenuIDs = FormMenuIDs + parentNode.Value + ",";
				////        //sbMenuItemIDs.Append(parentNode.Value + ",");

				////        foreach (TreeNode theChildNode1 in parentNode.ChildNodes)
				////        {
				////            if (theChildNode1.Checked)
				////            {
				////                FormMenuIDs = FormMenuIDs + theChildNode1.Value + ",";
				////            }
				////            if (theChildNode1.ChildNodes.Count > 0)
				////            {
				////                foreach (TreeNode theChildNode2 in theChildNode1.ChildNodes)
				////                {
				////                    if (theChildNode2.Checked)
				////                    {
				////                        FormMenuIDs = FormMenuIDs + theChildNode2.Value + ",";
				////                    }
				////                }
				////            }
				////        }
				////    }
				////    else
				////    {
				////        // If the root node has not selected but some of the child nodes has selected	
				////        if (parentNode.ChildNodes.Count > 0)
				////        {
				////            foreach (TreeNode theChildNode3 in parentNode.ChildNodes)
				////            {
				////                if (theChildNode3.Checked == true)
				////                {
				////                    WillRecordParentNode = true;
				////                    FormMenuIDs = FormMenuIDs + theChildNode3.Value + ",";
				////                    foreach (TreeNode theChildNode4 in theChildNode3.ChildNodes)
				////                    {
				////                        if (theChildNode4.Checked)
				////                        {
				////                            FormMenuIDs = FormMenuIDs + theChildNode4.Value + ",";
				////                        }
				////                    }
				////                }
				////                else
				////                {
				////                    if (theChildNode3.ChildNodes.Count > 0)
				////                    {
				////                        bool AppendParentNode = false;
				////                        foreach (TreeNode theChildNode5 in theChildNode3.ChildNodes)
				////                        {
				////                            if (theChildNode5.Checked)
				////                            {
				////                                AppendParentNode = true;
				////                                FormMenuIDs = FormMenuIDs + theChildNode5.Value + ",";
				////                            }
				////                        }
				////                        if (AppendParentNode)
				////                        {
				////                            FormMenuIDs = FormMenuIDs + theChildNode3.Value + ",";
				////                        }
				////                    }
				////                }
				////            }
				////            if (WillRecordParentNode)
				////            {
				////                FormMenuIDs = FormMenuIDs + parentNode.Value + ",";
				////            }
				////        }
				////    }
				////}
				////if (FormMenuIDs.Length > 1)
				////{
				////    FormMenuIDs = FormMenuIDs.Substring(0, FormMenuIDs.Length - 1);
				////}

				////string RoleIDs = "";
				////foreach (ListItem li in chkList_Roles.Items)
				////{
				////    if (li.Selected == true)
				////    {
				////        int RoleId = int.Parse(li.Value.ToString());
				////        RolePermissionManagement.GetInstance.DeleteRolePermissions_Web(RoleId);

				////        foreach (ListItem liPermission in chkList_Permission.Items)
				////        {
				////            if (liPermission.Selected == true)
				////            {
				////                int permissionId = int.Parse(liPermission.Value.ToString());
				////                TotRecEffected = WebMenuManagement.GetInstance.UpdateWebRolePermissions(RoleId, FormMenuIDs, permissionId, "F");
				////            }
				////        }
				////    }
				////}
				////if (RoleIDs.Length > 1)
				////{
				////    RoleIDs = RoleIDs.Substring(0, RoleIDs.Length - 1);
				////}

				lbl_Msg.Text = string.Format("Permission updated successfully, {0} records updated", TotRecEffected);

			}
			catch (Exception ex)
			{
				lbl_Msg.Text = "Failed to update the permission because " + ex.Message.ToString();
			}
		}

		private void RecordPermissionForMenuItems()
		{
			try
			{
				//StringBuilder sbMenuItemIDs = new StringBuilder();

				int TotRecEffected = 0;
				string MenuIDs = string.Empty;
				foreach (TreeNode parentNode in tview_RolePermissions.Nodes)
				{
					bool WillRecordParentNode = false;
					if (parentNode.Checked == true)
					{
						MenuIDs = MenuIDs + parentNode.Value + ",";
						//sbMenuItemIDs.Append(parentNode.Value + ",");

						foreach (TreeNode theChildNode1 in parentNode.ChildNodes)
						{
							if (theChildNode1.Checked)
							{
								MenuIDs = MenuIDs + theChildNode1.Value + ",";
							}
							if (theChildNode1.ChildNodes.Count > 0)
							{
								foreach (TreeNode theChildNode2 in theChildNode1.ChildNodes)
								{
									if (theChildNode2.Checked)
									{
										MenuIDs = MenuIDs + theChildNode2.Value + ",";
									}
								}
							}
						}
					}
					else
					{
						// If the root node has not selected but some of the child nodes has selected	
						if (parentNode.ChildNodes.Count > 0)
						{
							foreach (TreeNode theChildNode3 in parentNode.ChildNodes)
							{
								if (theChildNode3.Checked == true)
								{
									WillRecordParentNode = true;
									MenuIDs = MenuIDs + theChildNode3.Value + ",";
									foreach (TreeNode theChildNode4 in theChildNode3.ChildNodes)
									{
										if (theChildNode4.Checked)
										{
											MenuIDs = MenuIDs + theChildNode4.Value + ",";
										}
									}
								}
								else
								{
									if (theChildNode3.ChildNodes.Count > 0)
									{
										bool AppendParentNode = false;
										foreach (TreeNode theChildNode5 in theChildNode3.ChildNodes)
										{
											if (theChildNode5.Checked)
											{
												AppendParentNode = true;
												MenuIDs = MenuIDs + theChildNode5.Value + ",";
											}
										}
										if (AppendParentNode)
										{
											MenuIDs = MenuIDs + theChildNode3.Value + ",";
										}
									}
								}
							}
							if (WillRecordParentNode)
							{
								MenuIDs = MenuIDs + parentNode.Value + ",";
							}
						}
					}
				}
				if (MenuIDs.Length > 1)
				{
					MenuIDs = MenuIDs.Substring(0, MenuIDs.Length - 1);
				}


				string RoleIDs = "";
				foreach (ListItem li in chkList_Roles.Items)
				{
					if (li.Selected == true)
					{
						int RoleId = int.Parse(li.Value.ToString());
						//RolePermissionManagement.GetInstance.DeleteRolePermissions_Web(RoleId,"M");

						TotRecEffected = WebMenuManagement.GetInstance.UpdateWebRolePermissions(RoleId, MenuIDs, BasePage.ViewPermissionId,"M");
					}
				}
				if (RoleIDs.Length > 1)
				{
					RoleIDs = RoleIDs.Substring(0, RoleIDs.Length - 1);
				}

				lbl_Msg.Text = string.Format("Permission updated successfully, {0} records updated", TotRecEffected);

			}
			catch (Exception ex)
			{
				lbl_Msg.Text = "Failed to update the permission because " + ex.Message.ToString();
			}
		}

		private string SayPageTitle()
		{
			string TheTitle = String.Format("{0} to Role ({1})", chk_MenuOrForm.SelectedItem.Text.ToString().Trim(), chkList_Roles.SelectedItem.Text.ToString().ToUpper());
			return TheTitle;
		}

		private Color SetFormGridForeColor(string navUrl)
		{
			Color theColor = Color.Blue;
			if (navUrl.ToUpper().Contains("CRMS"))
			{
				theColor = Color.DarkBlue;
			}
			else if (navUrl.ToUpper().Contains("FINANCE"))
			{
				theColor = Color.DarkViolet;
			}
			else if (navUrl.ToUpper().Contains("HRMS"))
			{
				theColor = Color.DarkGreen;
			}
			else if (navUrl.ToUpper().Contains("TRANSACTIONS"))
			{
				theColor = Color.Black;
			}
			else if (navUrl.ToUpper().Contains("ADMIN"))
			{
				theColor = Color.MediumBlue;
			}
			return theColor;
		}

		private Color SetFormGridBackColor(string navUrl)
		{
			Color theColor = Color.SeaShell;
			if (navUrl.ToUpper().Contains("CRMS"))
			{
				theColor = Color.White;
			}
			else if (navUrl.ToUpper().Contains("FINANCE"))
			{
				theColor = Color.LavenderBlush;
			}
			else if (navUrl.ToUpper().Contains("HRMS"))
			{
				theColor = Color.FromArgb(0xCC, 0xFF, 0x99);
			}
			else if (navUrl.ToUpper().Contains("TRANSACTIONS"))
			{
				theColor = Color.FromArgb(0xFF, 0xFF, 0xCC);
			}
			else if (navUrl.ToUpper().Contains("ADMIN"))
			{
				theColor = Color.LemonChiffon;
			}
			return theColor;
		}
		#endregion

	}
}