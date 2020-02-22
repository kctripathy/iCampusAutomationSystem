using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
	public partial class ResetPasswordManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static ResetPasswordManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static ResetPasswordManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new ResetPasswordManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion.

		#region Methods & Implementation
		public int ChangePassword(User theUser)
		{
			return ResetPasswordIntegration.ChangePassword(theUser);
		}

		public string GeneratePassword()
		{
			return ResetPasswordIntegration.GeneratePassword();
		}

		public int ResetPassword(User theUser)
		{
			return ResetPasswordIntegration.ResetPassword(theUser);
		}
		#endregion
	}
}
