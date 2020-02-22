using System;
using System.Reflection;
using Micro.IntegrationLayer.HumanResource;
using Micro.Objects.HumanResource;


namespace Micro.BusinessLayer.HumanResource
{
public partial	class UserProfileEmployeeManagement
	{
        #region Code to make this as a Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static UserProfileEmployeeManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static UserProfileEmployeeManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UserProfileEmployeeManagement();
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
        #endregion

        #region Transactional Methods(Insert,Update,Delete)

        public int UpdateUserProfileEmployee(UserProfileEmployee emp)
        {
            try
            {
                return UserProfileEmployeeIntegration.UpdateUserProfileEmployee(emp);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        #endregion
	}
}
