using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using Micro.BusinessLayer.HumanResource;
using Micro.BusinessLayer.CustomerRelation;
using Micro.Commons;
using Micro.Framework.ReadXML;
using System.Web;
namespace Micro.WebApplication.MicroERP.ADMIN
{
	/// <summary>
	/// Manages User
	/// </summary>
	public partial class Users : BasePage
	{
		#region Declaration
		protected static class PageVariables
		{
            //TODO Exclude Session Variable for List Type
            public static List<User> UserList
            {

                get
                {
                    List<User> TheUserList = HttpContext.Current.Session["UserList"] as List<User>;
                    return TheUserList;
                }

                set
                {
                    HttpContext.Current.Session.Add("UserList", value);
                }
            }
			public static string TheUserID
            {
                get
                {
                string ThisUserID = HttpContext.Current.Session["TheUserID"].ToString();
                return ThisUserID;
                }
                set
                {
                HttpContext.Current.Session.Add("TheUserID", value);
                }
            }
			public static string TheUserReferenceID
            {
                get
                {
                    string ThisUserReferenceID = HttpContext.Current.Session["TheUserReferenceID"].ToString();
                    return ThisUserReferenceID;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheUserReferenceID", value);
                }
        }
			public static User ThisUser
            {
                get 
                {
                User TheUser = HttpContext.Current.Session["ThisUser"] as User;
                return TheUser;
                }
                set
                {
                HttpContext.Current.Session.Add("ThisUser", value);
                }
            }
        

		}


		#endregion

		#region Events

		protected void Page_Load(object sender, EventArgs e)
		{
			BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
			if (!IsPostBack && !IsCallback)
			{
				SetFormMessge();
				BindDropDownList();
				if (HasAddPermission() && IsDefaultModeAdd())
				{
					multiView_User.SetActiveView(view_InputControl);
					ResetBackColor(view_InputControl);
				}
				else
				{
					BindGridUsers();
					BasePage.ShowHidePagePermissions(gview_Users, btn_AddNewUser, this.Page);
					multiView_User.SetActiveView(view_GridView);
				}
			}
		}

		protected void btn_ViewTop_Click(object sender, EventArgs e)
		{
			BindGridUsers();
			BasePage.ShowHidePagePermissions(gview_Users, btn_AddNewUser, this.Page);
			multiView_User.SetActiveView(view_GridView);
		}

		protected void btn_AddNewUser_Click(object sender, EventArgs e)
		{
			multiView_User.SetActiveView(view_InputControl);
			ResetPageFields();
		}

		protected void ddl_UserType_SelectedIndexChanged(object sender, EventArgs e)
		{
			BindEmployee();
		}


		protected void btn_SaveTop_Click(object sender, EventArgs e)
		{
			int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
			if (btn_SaveTop.Text == MicroEnums.DataOperation.Save.GetStringValue() && btn_SaveBottom.Text == MicroEnums.DataOperation.Save.GetStringValue())
			{
				ProcReturnValue = SaveUser();
				dialog_Message.Show();
				lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "User", MicroEnums.DataOperation.AddNew);
			}
			else
			{
				ProcReturnValue = UpdateUser();
				dialog_Message.Show();
				lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "User", MicroEnums.DataOperation.Edit);
			}
			if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
			{
				BindGridUsers();
                ResetPageFields();
			}
		}

		protected void gview_Users_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
			{
				int RowIndex = Convert.ToInt32(e.CommandArgument);
				PageVariables.TheUserID = ((Label)gview_Users.Rows[RowIndex].FindControl("lbl_UserId")).Text;
				PageVariables.TheUserReferenceID = ((Label)gview_Users.Rows[RowIndex].FindControl("lbl_UserReferenceId")).Text;
				int RecordID = int.Parse(((Label)gview_Users.Rows[RowIndex].FindControl("lbl_UserId")).Text);
				lbl_DataOperationMode.Text = String.Format("EDIT USER : {0} [{1}]", gview_Users.Rows[RowIndex].Cells[3].Text.ToUpper(), RecordID);
				//lbl_UserRefName.Text = String.Format("{0}", gview_Users.Rows[RowIndex].Cells[3].Text.ToUpper());

			}


			if (e.CommandName == MicroEnums.DataOperation.Edit.GetStringValue())
			{

				multiView_User.SetActiveView(view_InputControl);
				PopulatePageFields(int.Parse(PageVariables.TheUserID));
				ChangeBackColor(view_InputControl);
				btn_SaveTop.Text = MicroEnums.DataOperation.Update.GetStringValue();
				btn_SaveBottom.Text = MicroEnums.DataOperation.Update.GetStringValue();

			}
			if (e.CommandName == MicroEnums.DataOperation.Delete.GetStringValue())
			{
				int ProcReturnValue = DeleteUser();
				dialog_Message.Show();
				lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "User", MicroEnums.DataOperation.Delete);
				if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
				{
					BindGridUsers();
				}

			}

		}

		protected void gview_Users_RowEditing(object sender, GridViewEditEventArgs e)
		{
			e.Cancel = true;
		}

		protected void gview_Users_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gview_Users.PageIndex = e.NewPageIndex;
			BindGridUsers();
		}

		protected void gview_Users_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			e.Cancel = true;
		}

		protected void gview_Users_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
                //GridViewOnDelete(e, 6);
                //GridViewOnClientMouseOver(e);
                //GridViewOnClientMouseOut(e);
                //GridViewToolTips(e, 5, 6);
			}
		}

		protected void btn_ResetTop_Click(object sender, EventArgs e)
		{
			ResetPageFields();
           
		}

		#endregion

		#region Methods & Implementation

		private void BindGridUsers()
		{
			gview_Users.Columns[0].Visible = false;
			gview_Users.DataSource = null;
			gview_Users.DataBind();
			PageVariables.UserList = UserManagement.GetInstance.GetUserList();
			if (PageVariables.UserList.Count > 0)
			{
				gview_Users.DataSource = PageVariables.UserList;
				gview_Users.DataBind();
			}
		}

		private void BindDropDownList()
		{

			BindRole();
			//BindEmployee();
			BindUserType();
		}

		private void BindEmployee()
		{
			if (ddl_UserType.SelectedIndex != 0 && ddl_UserType.SelectedIndex != 2 && ddl_UserType.SelectedIndex != 3)
			{
				ddl_UserReferenceName.Enabled = true;
				ddl_UserReferenceName.DataSource = EmployeeManagement.GetInstance.GetEmployeeList();
				ddl_UserReferenceName.DataTextField = EmployeeManagement.GetInstance.DisplayMember;
				ddl_UserReferenceName.DataValueField = EmployeeManagement.GetInstance.ValueMember;
				ddl_UserReferenceName.DataBind();
			}

			if (ddl_UserType.SelectedIndex != 0 && ddl_UserType.SelectedIndex != 1 && ddl_UserType.SelectedIndex != 3)
			{
				ddl_UserReferenceName.Enabled = true;
				ddl_UserReferenceName.DataSource = FieldForceManagement.GetInstance.GetFieldForceList();
				ddl_UserReferenceName.DataTextField = FieldForceManagement.GetInstance.DisplayMember;
				ddl_UserReferenceName.DataValueField = FieldForceManagement.GetInstance.ValueMember;
				ddl_UserReferenceName.DataBind();
			}


			if (ddl_UserType.SelectedIndex != 0 && ddl_UserType.SelectedIndex != 1 && ddl_UserType.SelectedIndex != 2)
			{
				ddl_UserReferenceName.Enabled = true;
				ddl_UserReferenceName.DataSource = GuestManagement.GetInstance.GetGuestList();
				ddl_UserReferenceName.DataTextField = GuestManagement.GetInstance.DisplayMember;
				ddl_UserReferenceName.DataValueField = GuestManagement.GetInstance.ValueMember;
				ddl_UserReferenceName.DataBind();
			}
			if (ddl_UserType.SelectedIndex != 1 && ddl_UserType.SelectedIndex != 2 && ddl_UserType.SelectedIndex != 3)
			{

				ddl_UserReferenceName.Enabled = false;
			}
		}

		private void BindRole()
		{
			ddl_Role.DataSource = RolesManagement.GetInstance.GetRolesList();
			ddl_Role.DataTextField = RolesManagement.GetInstance.DisplayMember;
			ddl_Role.DataValueField = RolesManagement.GetInstance.ValueMember;
			ddl_Role.DataBind();
			ddl_Role.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
		}

		//private void BindEmployee()
		//{
		//    //ddl_UserReferenceName.DataSource = UserManagement.GetInstance.GetUserList();
		//    //ddl_UserReferenceName.DataTextField = "UserReferenceName";
		//    //ddl_UserReferenceName.DataValueField = "UserReferenceID";
		//    //ddl_UserReferenceName.DataBind();
		//    ddl_UserReferenceName.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
		//}

		private void BindUserType()
		{
			ddl_UserType.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
			ddl_UserType.Items.Insert(1, new ListItem("Employee"));
			ddl_UserType.Items.Insert(2, new ListItem("FieldForce"));
			ddl_UserType.Items.Insert(3, new ListItem("Guest"));
		}

		private int SaveUser()
		{
			User objUser = new User();
			objUser.UserName = txt_UserLogInName.Text;
			objUser.UserType = ddl_UserType.SelectedValue;
			objUser.UserReferenceID = int.Parse(ddl_UserReferenceName.SelectedValue);
			objUser.RoleID = int.Parse(ddl_Role.SelectedValue);
			objUser.Password = MicroSecurity.Encrypt(txt_ConfirmPassword.Text);
			int ProcReturnValue = UserManagement.GetInstance.InsertUser(objUser);
			return ProcReturnValue;
		}

		private int UpdateUser()
		{
			int ProcReturnValue = 0;
			User ThisUser = new User();
			ThisUser.UserID = int.Parse(PageVariables.TheUserID);
			ThisUser.Password = MicroSecurity.Encrypt(txt_ConfirmPassword.Text);
			ProcReturnValue = UserManagement.GetInstance.UpdateUser(ThisUser);
			return ProcReturnValue;


		}

		private void PopulatePageFields(int theUserId)
		{
			User objUser = UserManagement.GetInstance.GetUserByID(theUserId);
			txt_UserLogInName.Text = objUser.UserName;
			ddl_UserType.SelectedIndex = GetSelectedValue(ddl_UserType, objUser.UserType);
			BindEmployee();
			ddl_UserReferenceName.SelectedIndex = GetSelectedIndex(ddl_UserReferenceName, objUser.UserReferenceID);
			ddl_Role.SelectedIndex = GetSelectedIndex(ddl_Role, objUser.RoleID);
			txt_LogInPassword.Text = objUser.Password;
		}

		//private int UpdateUser()
		//{
		//    User objUser = new User();
		//    objUser.UserID = int.Parse(PageVariables.TheUserID);
		//    //objUser.UserType = ddl_UserType.SelectedValue;
		//    //objUser.UserName = txt_UserLogInName.Text;
		//    //objUser.UserReferenceID = int.Parse(ddl_UserReferenceName.SelectedValue);
		//    objUser.Password = MicroSecurity.Encrypt(txt_ConfirmPassword.Text);
		//    int ProcReturnValue = UserManagement.GetInstance.UpdateUserPassword(objUser);
		//    return ProcReturnValue;



		//}

		private int GetSelectedIndex(DropDownList ddl, int theID)
		{
			int RetValue = 0;
			for (int ctr = 0; ctr < ddl.Items.Count; ctr++)
			{
				if (ddl.Items[ctr].Value == theID.ToString())
				{
					RetValue = ctr;
					break;
				}
			}
			return RetValue;
		}

		private int GetSelectedValue(DropDownList ddl, string theValue)
		{
			int RetValue = 0;
			for (int ctr = 0; ctr < ddl.Items.Count; ctr++)
			{
				if (ddl.Items[ctr].Value == theValue)
				{
					RetValue = ctr;
				}
			}
			return RetValue;
		}

		private int DeleteUser()
		{

			int ProcReturnValue = UserManagement.GetInstance.DeleteUser(int.Parse(PageVariables.TheUserID));
			return ProcReturnValue;


		}

		private void SetFormMessge()
		{
			requiredFieldValidator_ConfirmPassword.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Confirm Password");
			requiredFieldValidator_Role.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
			requiredFieldValidator_Role.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Role");
			requiredFieldValidator_UserLogInName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "");
			requiredFieldValidator_UserName.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "User Nmae");
			requiredFieldValidator_UserType.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
			requiredFieldValidator_UserType.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "User Type");
			requiredFieldValiddator_LogInPassword.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", " Password");
			compareValidator_ConfirmPassword.ErrorMessage = ReadXML.GetFailureMessage("PASSWORD_MISMATCH");
			SetCssClass("ValidateMessage");
		}

		private void SetCssClass(string theCssClass)
		{
			foreach (Control ctrl in view_InputControl.Controls)
			{
				if (ctrl.GetType().Name == "RequiredFieldValidator")
				{

					RequiredFieldValidator reqFieldVal = ctrl as RequiredFieldValidator;
					reqFieldVal.CssClass = theCssClass;
				}
			}

		}

		private void ResetPageFields()
		{
			foreach (Control ctrl in view_InputControl.Controls)
			{
				if (ctrl.GetType().Name == "TextBox")
				{
					TextBox tb = ctrl as TextBox;
					tb.Text = string.Empty;
				}
				if (ctrl.GetType().Name == "DropDownList")
				{
					DropDownList ddl = ctrl as DropDownList;
					if (!string.IsNullOrEmpty(ddl.SelectedValue))
					{
						ddl.SelectedIndex = 0;
					}
				}
			}
			lbl_DataOperationMode.Text = string.Empty;
			//lbl_UserRefName.Text = string.Empty;
			btn_SaveTop.Text = MicroEnums.DataOperation.Save.GetStringValue();
			btn_SaveBottom.Text = MicroEnums.DataOperation.Save.GetStringValue();
			ResetBackColor(view_InputControl);
		}


		#endregion

	}
}