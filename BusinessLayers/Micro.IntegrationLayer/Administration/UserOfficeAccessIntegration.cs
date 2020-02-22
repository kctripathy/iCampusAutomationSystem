using System;
using System.Collections.Generic;
using Micro.Objects.Administration;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
    public partial class UserOfficeAccessIntegration
    {
        public static UserOfficeAccess DataRowToObject(DataRow dr)
        {
            UserOfficeAccess TheUserOfficeAccess = new UserOfficeAccess();

            TheUserOfficeAccess.UserOfficewiseID = int.Parse(dr["UserOfficewiseID"].ToString());
            TheUserOfficeAccess.UserID = int.Parse(dr["UserID"].ToString());
            TheUserOfficeAccess.UserName = dr["UserName"].ToString();
            TheUserOfficeAccess.UserType = dr["UserType"].ToString();
            TheUserOfficeAccess.UserReferenceID = int.Parse(dr["UserReferenceID"].ToString());
            TheUserOfficeAccess.UserReferenceName = dr["UserReferenceName"].ToString();
            TheUserOfficeAccess.OfficeID = int.Parse(dr["OfficeID"].ToString());
            TheUserOfficeAccess.OfficeName = dr["OfficeName"].ToString();
            TheUserOfficeAccess.CompanyID = int.Parse(dr["CompanyID"].ToString());
            TheUserOfficeAccess.CompanyName = dr["CompanyName"].ToString();
            TheUserOfficeAccess.CompanyAliasName = dr["CompanyAliasName"].ToString();
            TheUserOfficeAccess.CanAccessAllOffices = bool.Parse(dr["CanAccessAllOffices"].ToString());
            TheUserOfficeAccess.EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat);
            if (!string.IsNullOrEmpty(dr["EffectiveDateTo"].ToString()))
                TheUserOfficeAccess.EffectiveDateTo = DateTime.Parse(dr["EffectiveDateTo"].ToString()).ToString(MicroConstants.DateFormat);

            return TheUserOfficeAccess;
        }

        public static List<UserOfficeAccess> GetUserListOfficewiseByUserID(int UserID)
        {
            List<UserOfficeAccess> UserOfficeList = new List<UserOfficeAccess>();
            DataTable UserOfficeTable = UserOfficeAccessDataAccess.GetInstance.GetUserListOfficewiseByUserID(UserID);

            foreach (DataRow dr in UserOfficeTable.Rows)
            {
                UserOfficeAccess TheUserOffice = DataRowToObject(dr);

                UserOfficeList.Add(TheUserOffice);
            }

            return UserOfficeList;
        }

        public static int InsertUserOfficeAccess(UserOfficeAccess theUserOfficeAccess)
        {
            return UserOfficeAccessDataAccess.GetInstance.InsertUserOfficeAccess(theUserOfficeAccess);
        }

    }
}
