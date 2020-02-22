using System;
using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;
using System.Reflection;

namespace Micro.BusinessLayer.CustomerRelation
{
 public partial   class UserProfileFieldForceProfileManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
     private static UserProfileFieldForceProfileManagement _Instance;

     public static UserProfileFieldForceProfileManagement GetInstance
     {
         get 
         {
             if (_Instance == null)
             {
                 _Instance = new UserProfileFieldForceProfileManagement();
             }
             return _Instance;
         }
         set
         {
             _Instance = value;
         }
     }
        #endregion

        #region Transactionl Methods (Insert,Update,Delete)
     public int UpdateUserProfileFieldForceProfile(UserProfileFieldForceProfile objUserProfileFiledForceProfile)
     {
         try
         {
             return UserProfileFieldForceProfileIntegration.UpdateUserProfileFieldForceProfile(objUserProfileFiledForceProfile);
         }
         catch(Exception ex)
         {
             throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
         }
     }
        #endregion

    }
}
