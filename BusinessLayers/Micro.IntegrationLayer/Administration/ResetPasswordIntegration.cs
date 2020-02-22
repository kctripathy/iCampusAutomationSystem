using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.IntegrationLayer.Administration
{
	public partial class ResetPasswordIntegration
	{
		#region Methods & Implementation
		public static int ChangePassword(User theUser)
		{
			return ResetPasswordDataAccess.GetInstance.ChangePassword(theUser);
		}

		public static string GeneratePassword()
		{
			return ResetPasswordDataAccess.GetInstance.GeneratePassword()[0].ToString();
		}

		public static int ResetPassword(User theUser)
		{
			return ResetPasswordDataAccess.GetInstance.ResetPassword(theUser);
		}
		#endregion
	}
}
