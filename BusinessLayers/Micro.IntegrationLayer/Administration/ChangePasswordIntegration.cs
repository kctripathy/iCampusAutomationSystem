using Micro.Objects.Administration;
using System.Data;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
   public partial class ChangePasswordIntegration
   {
       #region Methods & Implementation
        public static User GetUserByName(string UserName)
        {
            DataRow TheUserRow = ChangePasswordDataAccess.GetInstance.GetUserByName(UserName);
            User TheUser = DataRowToObject(TheUserRow);
            return TheUser;
        }

        public static User DataRowToObject(DataRow dr)
        {
            User TheUser = new User();

            TheUser.UserID = int.Parse(dr["UserID"].ToString());
            TheUser.UserName = dr["UserName"].ToString();
            TheUser.Password = dr["Password"].ToString();
            return TheUser;
        }

        public static int UpdateChangePassword(User theUser)
        {
            return ChangePasswordDataAccess.GetInstance.UpdateChangePassword(theUser);
        }

       #endregion
   }
}
