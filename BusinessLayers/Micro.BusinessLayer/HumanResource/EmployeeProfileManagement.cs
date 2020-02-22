using System.Collections.Generic;
using Micro.IntegrationLayer.HumanResource;
using Micro.Objects.HumanResource;
using Micro.Commons;

namespace Micro.BusinessLayer.HumanResource
{
    public partial class EmployeeProfileManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static EmployeeProfileManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static EmployeeProfileManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EmployeeProfileManagement();
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
		public string DefaultColumns = "EmployeeCode, EmployeeName, SettingKeyName, SettingKeyDescription, SettingKeyReference,SettingKeyValue";
		public string DisplayMember = "EmployeeName";
		public string ValueMember = "EmployeeProfileID";
		#endregion

		#region Methods & Implementation

		public List<EmployeeProfile> GetEmployeeProfilesList()
		{
			return EmployeeProfileIntegration.GetEmployeeProfilesList();
		}
	
		public EmployeeProfile GetEmployeeProfileByID(int employeeProfileID)
		{
			return EmployeeProfileIntegration.GetEmployeeProfileByID(employeeProfileID);
		}
		
		public List<EmployeeProfile> GetEmployeeProfileByEmployeeID(int employeeID)
		{
			return EmployeeProfileIntegration.GetEmployeeProfileByEmployeeID(employeeID);
		}

		public List<EmployeeProfile> GetEmployeeProfileImageByEmployeeID(int EmployeeID)
		{
			List<EmployeeProfile> EmployeeProfileList = GetEmployeeProfileByEmployeeID(EmployeeID);

			foreach (EmployeeProfile EachProfile in EmployeeProfileList)
			{
				EachProfile.ImageUrl = BasePage.GetProfileImageUrl(EachProfile.EmployeeID.ToString(), EachProfile.SettingKeyName, EachProfile.CommonKeyValue);
			}

			return EmployeeProfileList;
		}

		public EmployeeProfile GetEmployeeProfileBySettingKeyID(int employeeID, int settingKeyID)
		{
			return EmployeeProfileIntegration.GetEmployeeProfileBySettingKeyID(employeeID, settingKeyID);
		}

		public int InsertEmployeeProfile(EmployeeProfile theEmployeeProfile)
		{
			return EmployeeProfileIntegration.InsertEmployeeProfile(theEmployeeProfile);
		}

		public int UpdateEmployeeProfile(EmployeeProfile theEmployeeProfile)
		{
			return EmployeeProfileIntegration.UpdateEmployeeProfile(theEmployeeProfile);
		}

		public int DeleteEmployeeProfile(EmployeeProfile theEmployeeProfile)
		{
			return EmployeeProfileIntegration.DeleteEmployeeProfile(theEmployeeProfile);
		}

		#endregion
    }
}
