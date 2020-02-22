using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Micro.Objects.Administration;
using System.Text;
using Micro.BusinessLayer.Administration;
using Micro.Framework.ReadXML;
using Micro.Commons;
using Micro.WebApplication.MicroERP;

namespace Micro.WebApplication.App_UserControls
{
    public partial class UC_Login : System.Web.UI.UserControl
    {
        public static string IsLoginSuccess
        {
            get
            {
                string strIsLoginSuccess = HttpContext.Current.Session["IsLoginSuccess"].ToString();
                return strIsLoginSuccess;
            }
            set
            {
                HttpContext.Current.Session.Add("IsLoginSuccess", value);
            }
        }


        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!(Micro.Commons.Connection.LoggedOnUser == null))
                {
                    DoAfterLoginSuccess();
                    multiView_Login.SetActiveView(view_LoginSuccees);
                }
                else
                {
                    multiView_Login.SetActiveView(view_LoginLink);
                }
            }
        }

        private void DoAfterLoginSuccess()
        {
            
            //if (Connection.LoggedOnUser.RoleID.Equals((int)MicroEnums.UserRole.Administrator) ||
            //    Connection.LoggedOnUser.RoleID.Equals((int)MicroEnums.UserRole.SuperAdmin))
            //{
            //    lbl_NameLabel.Text = string.Concat("Admin's Name :");
            //    lbl_UserType.Text = string.Concat("Admin");
            //}
            //else
            //{
            //    lbl_NameLabel.Text = string.Concat(Connection.LoggedOnUser.UserType.ToString(), "'s Name:- ");
            //    lbl_CodeValue.Text = Connection.LoggedOnUser.UserReferenceID.ToString();
            //}

            //WELCOME
            //lit_WelcomeText.Text = string.Format("Welcome <b>{0}</b>,  to <b>{1}</b>", Connection.LoggedOnUser.UserFirstName, Connection.LoggedOnUser.CompanyAliasName);
            lit_WelcomeText.Text = string.Format("Hello <b>{0}</b>,", Connection.LoggedOnUser.UserFirstName);
            
            //LOGIN ID
            lbl_CodeLabel.Text = string.Concat(Connection.LoggedOnUser.UserType.ToString(), " LoginID: ");
            lbl_CodeValue.Text = Connection.LoggedOnUser.UserName.ToString();
            
            
            //ROLE
            if (Connection.LoggedOnUser.RoleDescription.Length >8)
            {
                lbl_Role.Text = string.Concat(Connection.LoggedOnUser.RoleDescription.Substring(0, 9), ".");
            }
            else
            {
                lbl_Role.Text = Connection.LoggedOnUser.RoleDescription;
            }

            //NAME
            lbl_NameLabel.Text = string.Concat(Connection.LoggedOnUser.UserType.ToString(), "'s Full Name:- ");
            lbl_NameValue.Text = Connection.LoggedOnUser.UserReferenceName.ToString();
            
            
            //PHOTO
            string bgImageURL = string.Format("url(../Themes/ICAS/USER_PHOTO/{0}/{1})", Connection.LoggedOnUser.UserType.ToString(), Connection.LoggedOnUser.UserPhoto_SmallSize);
            img_LoggedOnUser.Style.Add("background", bgImageURL);
            img_LoggedOnUser.Visible = true;
            img_LoggedOnUser.Width = 80;
            img_LoggedOnUser.Height = 80;

            lbl_CurrentDayDateTime.Text = DateTime.Now.ToLongDateString(); //.ToString("DDD, DD-MMM-yyyy HH:MM:SS");
            lbl_LastLoginDateTime.Text = Connection.LoggedOnUser.LoginDateTime;


            //MESSAGES TO USER
            lnk_UserMessages.Text = "30";
            lnk_EditPicture.PostBackUrl = "EditPicture.aspx";
        }

        protected void lnkBtn_SignOut_OnClick(object sender, EventArgs e)
        {

            //this.Session.Abandon;
            //this.Session.Clear;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.RemoveAll();

            multiView_Login.SetActiveView(view_LoginLink);

        }

        protected void btn_UCLogin_Click(object sender, EventArgs e)
        {
            bool LoginSuccessFlag = false;
            User TheCurentUser = null;

            //----------------------------------------------------------------------------------------------------
            LoginSuccessFlag = CheckLoginCredentials(txt_UCLoginId.Text, txt_UCPassword.Text, out TheCurentUser);

            UserLoginSuccess(LoginSuccessFlag, TheCurentUser);

            if (HttpContext.Current.Session["IsLoginSuccess"].Equals("YES"))
            {
                lit_Message.Text = "Login Success";
                lbl_NameValue.Text =Connection.LoggedOnUser.UserReferenceName;

                multiView_Login.SetActiveView(view_LoginSuccees);
            }
            //----------------------------------------------------------------------------------------------------

        }

        public static void UserLoginSuccess(bool LoginSuccessFlag, User TheCurentUser)
        {
            if (LoginSuccessFlag)
            {
                //lit_Message.Text = "Y";
                //lbl_Code.Text = TheCurentUser.UserName;
                //lbl_Name.Text = TheCurentUser.UserReferenceName;
                //lbl_Class.Text = TheCurentUser.UserType;
                //lbl_Role.Text = TheCurentUser.RoleDescription;

                //Micro.WebApplication.MicroERP.Login.IsLoginSuccess = "YES";
                TCon.iCAS.WebApplication.APPS.UserLogin.IsLoginSuccess = "YES";

                // A VALID USER : RETURN TRUE FOR SUCCESS
                HttpContext.Current.Session["IsLoginSuccess"] = "YES";

                // MAINTAIN THE USERS INFORMATION 

                //Micro.WebApplication.MicroERP.Login.SetLoggedOnUserDetails(TheCurentUser);
                TCon.iCAS.WebApplication.APPS.UserLogin.SetLoggedOnUserDetails(TheCurentUser);

                // LOAD PERMISSION/RIGHTS
                //Micro.WebApplication.MicroERP.Login.SetUserRolePermissions(TheCurentUser.RoleID);
                TCon.iCAS.WebApplication.APPS.UserLogin.SetUserRolePermissions(TheCurentUser.RoleID);

                // LOAD USER SETTINGS
                //Micro.WebApplication.MicroERP.Login.GetAndSetUserSettings(TheCurentUser.UserID);
                TCon.iCAS.WebApplication.APPS.UserLogin.GetAndSetUserSettings(TheCurentUser.UserID);


            }
            else
            {
                //Micro.WebApplication.MicroERP.Login.IsLoginSuccess = "NO";
                TCon.iCAS.WebApplication.APPS.UserLogin.IsLoginSuccess = "NO";
                HttpContext.Current.Session["IsLoginSuccess"] = "NO";
            }
        }

        protected void lnkBtn_ForgotPassword_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Check the user supplied login credentials. 
        /// </summary>
        /// <returns>True if user supplies valid user name and password else returns false</returns>
        public bool CheckLoginCredentials(string uid, string pwd, out User currUser)
        {
            bool ReturnValue = false;
            bool LoginSuccess = true;
            User UserInfo = new User();
            StringBuilder sbFormMessage;

            try
            {

                // Collect the user supplied information
                UserInfo.UserName = uid; //"MLFAdmin";
                UserInfo.Password = pwd; //"Mukul";

                //UserInfo.CompanyID = ctrl_SelectDatabase.SelectedCompanyID;
                UserInfo.CompanyCode = ConfigurationManager.AppSettings["DefaultCompanyCode"].ToString();// "HO0001";

                // Get the record of the user from the database to validate against supplied data
                User CurrentUser;
                CurrentUser = UserManagement.GetInstance.GetUserByLoginName(UserInfo.UserName);
                currUser = CurrentUser;

                sbFormMessage = new StringBuilder();

                // -----------------------------------------------------------------------------------------------
                if (CurrentUser.UserID.Equals(0) || CurrentUser == null)
                //"Login Failed! The user name doesn't exists.";
                {
                    sbFormMessage.Append("User not found");
                    LoginSuccess = false;
                    
                }
                else if (!CurrentUser.Password.Equals(MicroSecurity.Encrypt(UserInfo.Password)))
                //"Login Failed! Incorrect password.";
                {
                    sbFormMessage.Append("Incorrect password");
                    LoginSuccess = false;
                }
                else if (string.IsNullOrEmpty(CurrentUser.CompanyID.ToString()))
                //"This user doesn't havae a company code";
                {
                    sbFormMessage.Append("No Company Identity");
                    LoginSuccess = false;
                }
                else if (CurrentUser.CompanyID.Equals(0))
                //"This user doesn't belongs to any company.";
                {
                    sbFormMessage.Append("Not associated with any company");
                    LoginSuccess = false;
                }
                // -----------------------------------------------------------------------------------------------
                else
                {
                    // A VALID USER : RETURN TRUE FOR SUCCESS
                    sbFormMessage.Append("A VALID USER");
                    LoginSuccess = true; 
                    
                }

                //// RETURN THE VALUE
                //if (!LoginSuccess)
                //{
                //    ReturnValue = false;
                //    Micro.WebApplication.MicroERP.Login.IsLoginSuccess = "NO";
                //}
                //else
                //{
                //    ReturnValue = true;
                //     Micro.WebApplication.MicroERP.Login.IsLoginSuccess = "YES";
                //}
             
                ReturnValue = LoginSuccess;

                return ReturnValue;
            }
            catch (Exception ex)
            {
                currUser = null;
                return false;
            }
            finally
            {

            }
        }

    }
}
