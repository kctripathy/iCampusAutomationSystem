using System;

namespace Micro.DataAccessLayer.CustomerRelation
{
	public partial class LoanEMIDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static LoanEMIDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static LoanEMIDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new LoanEMIDataAccess();
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
