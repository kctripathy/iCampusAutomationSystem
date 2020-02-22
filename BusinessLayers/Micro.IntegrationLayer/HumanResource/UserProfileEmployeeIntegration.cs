#region System Namespace

using System;
using System.Reflection;

#endregion

#region Micro Namespaces

using Micro.Objects.HumanResource;
using Micro.DataAccessLayer.HumanResource;


#endregion

namespace Micro.IntegrationLayer.HumanResource
{
public partial	class UserProfileEmployeeIntegration
	{
    #region Declaration

    #endregion

    #region Transactionl Methods(Insert,Update,Delete)

    public static int UpdateUserProfileEmployee(UserProfileEmployee emp)
    {
        try
        {
            return UserProfileEmployeeDataAccess.GetInstance.UpdateUserProfileEmployee(emp);
        }
        catch (Exception ex)
        {
            throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        }
    }
    #endregion

}
}
