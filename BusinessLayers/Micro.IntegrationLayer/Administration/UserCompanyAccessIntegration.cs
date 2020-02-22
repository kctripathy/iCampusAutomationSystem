using System;
using System.Collections.Generic;
using Micro.Commons;
using Micro.Objects.Administration;
using System.Data;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
  public partial class UserCompanyAccessIntegration
    {
      public static UserCompanyAccess DataRowToObject(DataRow dr)
      {
          UserCompanyAccess TheUserCompanyAccess = new UserCompanyAccess();

          TheUserCompanyAccess.UserCompanywiseID = int.Parse(dr["UserCompanywiseID"].ToString());

          TheUserCompanyAccess.UserID = int.Parse(dr["UserID"].ToString());
          TheUserCompanyAccess.UserName = dr["UserName"].ToString();
          TheUserCompanyAccess.UserType = dr["UserType"].ToString();
          TheUserCompanyAccess.UserReferenceID = int.Parse(dr["UserReferenceID"].ToString());
          TheUserCompanyAccess.UserReferenceName = dr["UserReferenceName"].ToString();
          TheUserCompanyAccess.CompanyID = int.Parse(dr["CompanyID"].ToString());
          TheUserCompanyAccess.CompanyName = dr["CompanyName"].ToString();
          TheUserCompanyAccess.CompanyAliasName = dr["CompanyAliasName"].ToString();
          TheUserCompanyAccess.CompanyCode = dr["CompanyCode"].ToString();
          TheUserCompanyAccess.RoleID = int.Parse(dr["RoleID"].ToString());
          TheUserCompanyAccess.RoleDescription = dr["RoleDescription"].ToString();
          TheUserCompanyAccess.EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat);
          if (!string.IsNullOrEmpty(dr["EffectiveDateTo"].ToString()))
          {
              TheUserCompanyAccess.EffectiveDateTo = DateTime.Parse(dr["EffectiveDateTo"].ToString()).ToString(MicroConstants.DateFormat);
          }
          TheUserCompanyAccess.DateAdded = DateTime.Parse(dr["DateAdded"].ToString()).ToString(MicroConstants.DateFormat);

          return TheUserCompanyAccess;
      }

      public static List<UserCompanyAccess> GetUserCompanyWiseByUserID(int UserID)
      {
          List<UserCompanyAccess> UserCompanyAccessList = new List<UserCompanyAccess>();

          DataTable UserCompanyAccessTable = UserCompanyAccessDataAccess.GetInstance.GetUserCompanyWiseByUserID(UserID);

          foreach (DataRow dr in UserCompanyAccessTable.Rows)
          {
              UserCompanyAccess TheUserCompanyAccessList = DataRowToObject(dr);

              UserCompanyAccessList.Add(TheUserCompanyAccessList);
          }

          return UserCompanyAccessList;
      }

      public static int UpdateUserCompanyAccess(UserCompanyAccess theUserCompanyAccess)
      {
          return UserCompanyAccessDataAccess.GetInstance.UpdateUserCompanyAccess(theUserCompanyAccess);
      }
    }
}
