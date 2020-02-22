using System.Collections.Generic;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;

namespace Micro.BusinessLayer.Administration
{
	public partial class MicroModuleManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static MicroModuleManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static MicroModuleManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new MicroModuleManagement();
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
        public string DefaultColumns = "ModuleName, ModuleMenuText";
        public string DisplayMember = "ModuleName";
        public string ValueMember = "ModuleID";
		#endregion

		#region Methods & Implementation
		public List<MicroModule> GetMicroModules()
		{
			return MicroModuleIntegration.GetMicroModules();
		}

		public MicroModule GetMicroModuleByName(string moduleName)
		{
			return MicroModuleIntegration.GetMicroModuleByName(moduleName);
		}
		#endregion
	}
}
