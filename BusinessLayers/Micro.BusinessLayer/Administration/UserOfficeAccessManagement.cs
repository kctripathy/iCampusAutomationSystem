using System.Collections.Generic;
using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
    public partial class UserOfficeAccessManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static UserOfficeAccessManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static UserOfficeAccessManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UserOfficeAccessManagement();
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
        public string DefaultColumn = "UserName,UserType,OfficeName,CompanyName,CompanyAliasName,CanAccessAllOffices";
        public string DisplayMember = "UserName";
        public string ValueMember = "UserOfficewiseID";

        #endregion

        #region Methods & Implementation

        public List<UserOfficeAccess> GetUserListOfficewiseByUserID(int UserID)
        {
            return UserOfficeAccessIntegration.GetUserListOfficewiseByUserID(UserID);
        }

        public int InsertUserOfficeAccess(UserOfficeAccess theUserOfficeAccess)
        {
            return UserOfficeAccessIntegration.InsertUserOfficeAccess(theUserOfficeAccess);
        }
        #endregion


    }
}
