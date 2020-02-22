using System.Collections.Generic;
using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
	public partial class MicroMenuManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static MicroMenuManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static MicroMenuManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new MicroMenuManagement();
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
		public string DefaultColumn = "MenuItemName, ShortCutDisplayString, ActualFormClassName, DisplayOrder";
		public string DisplayMember= "MenuItemName";
		public string ValueMember = "MenuID";
		#endregion

		#region Methods & Implementation
		public List<MicroMenu> GetMicroMenus(bool showOnlyPermitted)
		{
			return MicroMenuIntegration.GetMicroMenus(showOnlyPermitted);
		}

		public MicroMenu GetMicroMenuByID(int menuID)
		{
			return MicroMenuIntegration.GetMicroMenuByID(menuID);
		}

		public List<MicroMenu> GetMicroMenusByParentID(int parentMenuID, bool showOnlyPermitted = true)
		{
			return MicroMenuIntegration.GetMicroMenusByParentID(parentMenuID,showOnlyPermitted);
		}

		public int InsertMenu(MicroMenu theMenu)
		{
			return MicroMenuIntegration.InsertMenu(theMenu);
		}

		public int UpdateMenu(MicroMenu theMenu)
		{
			return MicroMenuIntegration.UpdateMenu(theMenu);
		}

		public int DeleteMenu(int menuID)
		{
			return MicroMenuIntegration.DeleteMenu(menuID);
		}
		#endregion
	}
}
