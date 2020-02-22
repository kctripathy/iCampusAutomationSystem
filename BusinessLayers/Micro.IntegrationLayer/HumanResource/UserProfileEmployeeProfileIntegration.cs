#region System Namespace

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;

#endregion

#region Micro Namespaces
using Micro.DataAccessLayer.HumanResource;
using Micro.Objects.HumanResource;
using Micro.Commons;
using System.IO;
#endregion


namespace Micro.IntegrationLayer.HumanResource
{
   public partial class UserProfileEmployeeProfileIntegration
   {
       #region Declaration

       #endregion

       #region Transactional Mathods(Insert,Update,Delete)
       public static int UpdateUserProfileEmployeeProfile(UserProfileEmployeeProfile objUserProfileEmployeeProfile)
       {
           try
           {
               return UserProfileEmployeeProfileDataAccess.GetInstance.UpdateUserProfileEmployeeProfile(objUserProfileEmployeeProfile);
           }
           catch(Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }
       //public static List<UserProfileEmployeeProfile> GetInstance.GetEmployeePhotoByUserID(int EmployeeID)
       //{

       //    try
       //    {
       //        DataRow DtRow = UserProfileEmployeeProfileDataAccess.GetInstance.GetEmployeePhotoByUserID(EmployeeID);
       //        UserProfileEmployeeProfile objEmployeeProfile = new UserProfileEmployeeProfile();
       //        objEmployeeProfile.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());

       //    }
       //    catch (Exception ex)
       //    {
       //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
       //    }

       //}
       public static List<UserProfileEmployeeProfile> GetPhotoByEmployeeID(int theEmployeeID)
       {
           try
           {
               return SetPhotoByEmployeeID(UserProfileEmployeeProfileDataAccess.GetInstance.GetPhotoByEmployeeID(theEmployeeID));
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }

       public static UserProfileEmployeeProfile GetEmployeePhotoByUserID(int EmployeeID)
        {
            try
            {
                DataRow DtRow = UserProfileEmployeeProfileDataAccess.GetInstance.GetPhotoByUserID(EmployeeID);
                UserProfileEmployeeProfile objEmployeeProfile = new UserProfileEmployeeProfile();
                objEmployeeProfile.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());
                objEmployeeProfile.SettingKeyValue =Base64ToImage(DtRow["SettingKeyValue"].ToString());
                return objEmployeeProfile;

            }
            catch(Exception ex)
                    {
                        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
                    }
        }

       public static List<UserProfileEmployeeProfile> SetPhotoByEmployeeID(DataTable EmployeeProfileDataTable)
       {
           try
           {
               List<UserProfileEmployeeProfile> EmployeeList = new List<UserProfileEmployeeProfile>();
               foreach (DataRow dr in EmployeeProfileDataTable.Rows)
               {
                   UserProfileEmployeeProfile theEmployeeProfile = new UserProfileEmployeeProfile();
                   theEmployeeProfile.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                   theEmployeeProfile.SettingKeyValue = ImageFunctions.ByteToImage((Byte[])(dr["SettingKeyValue"]));

                   //theWebForm.ModuleID = int.Parse(dr["ModuleID"].ToString());
                   //theWebForm.WebFormName = dr["WebFormName"].ToString();
                   //theWebForm.WebFormURL = dr["WebFormURL"].ToString();
                   //theWebForm.WebFormImageURL = dr["WebFormImageURL"].ToString();
                   //theWebForm.ModuleName = dr["ModuleName"].ToString();
                   //theWebForm.CompanyCode = dr["CompanyCode"].ToString();
                   //theWebForm.IsActive = bool.Parse(dr["IsActive"].ToString());
                   //theWebForm.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());
                   //theWebForm.WebFormDescription = dr["WebFormDescription"].ToString();

                   EmployeeList.Add(theEmployeeProfile);

               }
               return EmployeeList;
           }

           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }

       public static Image Base64ToImage(string base64String)
       {
           // Convert Base64 String to byte[]
           byte[] imageBytes = Convert.FromBase64String(base64String);
           MemoryStream ms = new MemoryStream(imageBytes, 0,
             imageBytes.Length);

           // Convert byte[] to Image
           ms.Write(imageBytes, 0, imageBytes.Length);
           Image image = Image.FromStream(ms, true);
           return image;
       }
       #endregion
       
   }
}
