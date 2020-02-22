using System;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;
using System.Data;
using Micro.Commons;

namespace Micro.IntegrationLayer.Administration
{
   public partial class USerProxyIntegration
   {
       #region Methods & Implementation

       public static UserIncharge DataRowToObject(DataRow dr)
       {
           UserIncharge TheUserIncharge = new UserIncharge();

           TheUserIncharge.UserInchargeID = int.Parse(dr["UserInchargeID"].ToString());
           TheUserIncharge.ParentUserID = int.Parse(dr["ParentUserID"].ToString());
           TheUserIncharge.InChargeUserID = int.Parse(dr["InChargeUserID"].ToString());
           TheUserIncharge.EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat);
           TheUserIncharge.EffectiveDateTo = DateTime.Parse(dr["EffectiveDateTo"].ToString()).ToString(MicroConstants.DateFormat);
           TheUserIncharge.ReferenceLetterNumber=dr["ReferenceLetterNumber"].ToString();
           TheUserIncharge.ReferenceLetterDate = DateTime.Parse(dr["ReferenceLetterDate"].ToString()).ToString(MicroConstants.DateFormat);

           return TheUserIncharge;
       } 

       public static int InsertUserIncharge(UserIncharge theUserIncharge)
       {
           return USerProxyDataAccess.GetInstance.InsertUserIncharge(theUserIncharge);
       }
       #endregion


   }
}
