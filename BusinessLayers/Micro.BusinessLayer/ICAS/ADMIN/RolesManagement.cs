using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Micro.IntegrationLayer.ICAS.ADMIN;
using Micro.Objects.ICAS.ADMIN;

namespace Micro.BusinessLayer.ICAS.ADMIN
{
	public partial class RolesManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static RolesManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static RolesManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new RolesManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

		#region Declaration
		public string DefaultColumns = "RoleDescription, RolePosition";
		public string DisplayMember = "RoleDescription";
		public string ValueMember = "RoleID";
		#endregion

		#region Methods and Implementations

		public int InsertRoles(Role TheRole)
		{
			string Context = this.GetType().FullName.ToString();
			try
			{
				return RoleIntegration.InsertRoles(TheRole);
			}
			catch (Exception ex)
			{
				throw (new Exception(Context, ex));
			}
		}

		public int UpdateRole(Role TheRole)
		{
			string Context = this.GetType().FullName.ToString();
			try
			{
				return (RoleIntegration.UpdateRole(TheRole));
			}
			catch (Exception ex)
			{
				throw (new Exception(Context, ex));
			}
		}

		public List<Role> GetRolesList(System.String searchText = null, bool showDeleted = false)
		{
			string Context = this.GetType().FullName.ToString();
			try
			{
				return RoleIntegration.GetRolesList(searchText, showDeleted);
			}
			catch (Exception ex)
			{
				throw (new Exception(Context, ex));
			}
		}


		//public Boolean FillRoleList(Control theControl, bool showDeleted = false)
		//{
		//	try
		//	{
		//		if(theControl is DevExpress.XtraEditors.LookUpEdit)
		//		{
		//			((DevExpress.XtraEditors.LookUpEdit)theControl).Properties.DataSource = RolesManagement.GetInstance.GetRoleList(showDeleted);
		//			((DevExpress.XtraEditors.LookUpEdit)theControl).Properties.DisplayMember = DisplayMember;
		//			((DevExpress.XtraEditors.LookUpEdit)theControl).Properties.ValueMember = ValueMember;
		//			((DevExpress.XtraEditors.LookUpEdit)theControl).EditValue = "";
		//		}
		//		else if(theControl is DevExpress.XtraGrid.GridControl)
		//		{
		//			((DevExpress.XtraGrid.GridControl)theControl).DataSource = RolesManagement.GetInstance.GetRoleList(showDeleted);
		//		}

		//		return true;
		//	}
		//	catch
		//	{
		//		return false;
		//	}
		//}

		public List<Role> GetRoleList(bool showDeleted = false)
		{
			return RoleIntegration.GetRoleList(showDeleted);
		}

		public Role GetRoleById(int roleId)
		{
			return RoleIntegration.GetRoleById(roleId);
		}


		public int DeleteRoles(int roleId)
		{
			return RoleIntegration.DeleteRoles(roleId);
		}
		#endregion

        public string SendMicroSMS(string phoneNumber, string messageText)
        {
            return RoleIntegration.SendMicroSMS(phoneNumber, messageText);
        }
	}
}
