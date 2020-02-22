using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.IntegrationLayer;
using Micro.Objects.InventoryControl;

namespace Micro.BusinessLayer.InventoryControl
{
    public partial class AssetManagement
    {
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static AssetManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static AssetManagement GetInstance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new AssetManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion
    }
}
