using System.Collections.Generic;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;

namespace Micro.BusinessLayer.Administration
{
   public partial class UserCompanyAccessManagement
   {
       #region Declaration
       public string DefaultColumn = "UserName,UserType,UserReferenceName,CompanyName,CompanyAliasName,CompanyCode,RoleDescription";
       public string DisplayMember = "UserName";
       public string ValueMember = "UserCompanywiseID";

       #endregion

       #region Code to make this as Singleton Class
       /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static UserCompanyAccessManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static UserCompanyAccessManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UserCompanyAccessManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Methods & Implementation

       public List<UserCompanyAccess> GetUserCompanyWiseByUserID(int UserID)
       {
           return UserCompanyAccessIntegration.GetUserCompanyWiseByUserID(UserID);
       }

       public int UpdateUserCompanyAccess(UserCompanyAccess theUserCompanyAccess)
       {
           return UserCompanyAccessIntegration.UpdateUserCompanyAccess(theUserCompanyAccess);
       }
        #endregion
    }
}
