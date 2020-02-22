using System;
using System.Collections.Generic;
using System.Web.UI;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;

namespace Micro.WebApplication.MicroERP.ADMIN
{
    public partial class Roles : Page
    {

		
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
				FillGrid_Roles();
        }

		private void FillGrid_Roles()
		{
			List<Role> RolesList = new List<Role>();
			RolesList = RolesManagement.GetInstance.GetRoleList();
			
			gview_Roles.DataSource = RolesList;
			gview_Roles.DataBind();

		}
		protected void UpdateButton_Click(object sender, EventArgs e)
		{
			FillGrid_Roles();
			System.Threading.Thread.Sleep(1000);
		}

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Role r = new Role();
                r.RoleDescription = txt_RoleDesc.Text.ToString().ToUpper();
                int RetVal = RolesManagement.GetInstance.InsertRoles(r);
                lbl_TheMessage.Text = "Role Inserted Successfully";
                FillGrid_Roles();
                dialog_Message.Show();
            }
            catch (Exception ex)
            {

                lbl_TheMessage.Text =  string.Format("Failed to insert because: <br/>{0}", ex.Message.ToString());
                dialog_Message.Show();
            }
            
        }

    }
}