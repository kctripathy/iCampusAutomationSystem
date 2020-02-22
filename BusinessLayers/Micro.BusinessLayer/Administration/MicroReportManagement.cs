using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
	public partial class MicroReportManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static MicroReportManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static MicroReportManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new MicroReportManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

		public MicroReport GetReportByName(string reportDisplayName)
		{
			return MicroReportIntegration.GetReportByName(reportDisplayName);
		}
	}
}
