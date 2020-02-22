using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.UI;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;

namespace TCon.iCAS.WebApplication.APPS
{
    public partial class UserRegister : System.Web.UI.Page
    {
        #region Declarations
        public static User CurrentUser = new User();
        public static string EmpCodePrefix = string.Empty;

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
        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            //SetValidationExpressions();

            //CheckForWebsiteMaintanaceFlag();
            string userType = string.Empty;
            try
            {
                userType = Request.QueryString["UserType"].ToString();
                
            }
            catch 
            {
                userType = "User";
            }
            lit_PageTitle.Text = string.Format("New {0} Registration:", userType);
            TextBoxWatermarkExtender1.WatermarkText = string.Format("PLEASE ENTER THE FULL NAME OF NEW {0}", userType.ToUpper());
            TextBoxWatermarkExtender2.WatermarkText = string.Format("{0}'S PHONE NUMBER", userType.ToUpper());
            TextBoxWatermarkExtender3.WatermarkText = string.Format("EMAIL ID OF THE {0}", userType.ToUpper());

            if (!IsPostBack)
            {
                SetDefaultValues();

            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(18000);
            SetConnection();
            //SetUserNameField();

            if (CheckLoginCredentials().Equals(true))
            {
                WriteCookies();
                RedirectLoggedOnUser();
            }
        }

        protected void lnkBtn_ForgotPassword_Click(object sender, EventArgs e)
        {
            RedirectLoggedOnUser("/APPS/ADMIN/ForgotPassword.aspx");
        }

        protected void txt_UserName_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                //EmpCodePrefix = radioBtnListCompany.SelectedValue;
                //int TheDigit = int.Parse(txt_UserName.Text.Trim().ToString());
                //txt_UserName.Text = string.Format("{0}{1}", EmpCodePrefix, TheDigit.ToString("000000"));
                //txt_Password.Focus();
            }
            catch
            {
                //txt_UserName.Text = txt_UserName.Text.ToUpper();
            }
        }
        #endregion

        #region Methods & Implementations
        /// <summary>
        /// Setting the connection strings for the database
        /// </summary>
        public static void SetConnection()
        {
            Connection.ConnectionKeyName = ConfigurationManager.AppSettings["DefaultDatabaseEnviroment"].ToString();
            Connection.ConnectionKeyValue = ConfigurationManager.ConnectionStrings[Connection.ConnectionKeyName].ToString();
            //Connection.ConnectionString = Micro.Commons.MicroSecuritty.DecryptStringAES(Connection.ConnectionKeyValue,"micro");
            Connection.ConnectionString = Connection.ConnectionKeyValue;

            // Uncomment below code to user the Select Database control 
            //Connection.ConnectionKeyName = ctrl_SelectDatabase.ConnectionName;
            //Connection.ConnectionKeyValue = ctrl_SelectDatabase.ConnectionValue;
        }

        public void ShowHideMasterPageUserControls(bool value)
        {
            // Hide the menu items during login process
            //((UC_CustomisedMenu)Master.FindControl("ctrl_CustomisedMenu")).Visible = value;
            //((UC_LeftColumn)Master.FindControl("ctrl_LeftColumn")).Visible = value;
            //((UC_UserLoggedOn)Master.FindControl("ctrl_LoggedOnUser")).Visible = value;
        }

        /// <summary>
        /// Set the default values which should be used across the application
        /// It sets the path for the xml files, where we kept all the messages being shown in the application
        /// </summary>
        public void SetDefaultValues()
        {

            // Hide the menu items during login process
            ShowHideMasterPageUserControls(false);

            // Set the employee code prefix for the current company/website.
            EmpCodePrefix = radioBtnListCompany.SelectedValue; //ConfigurationManager.AppSettings["EmpCodeInitializer"].ToString();

            //Generate the water mark text for the username as per the company code prefix	
            //watermarkExtender_UserName.WatermarkText = string.Format("E.g: 1 for {0}000001", EmpCodePrefix);

            // The current file path where the messages.xml exists
            Micro.Commons.LocalPath.XMLFiles = Request.MapPath(".");
            Micro.Commons.LocalPath.XMLFileChartData = Server.MapPath("~") + ConfigurationManager.AppSettings["XMLFilePath_ChartData"].ToString();

        }

        /// <summary>
        /// This method will write the Username and password in a cookie
        /// </summary>
        private void WriteCookies()
        {
            //// Check if remember me checkbox is checked on login
            //if (chk_Remember.Checked)
            //{
            //    //Check if the browser support cookies
            //    if (Request.Browser.Cookies.Equals(true))
            //    {
            //        //Check if the cookies with name USERNAME exist on user's machine
            //        //if (Request.Cookies["USERNAME"] == null)
            //        //{
            //        //Cookied for User Name
            //        HttpCookie userCookie = new HttpCookie("USERNAME")
            //        {
            //            Value = txt_UserName.Text,
            //            Expires = DateTime.Now.AddDays(30)
            //        };
            //        Response.Cookies.Add(userCookie);

            //        //Cookied for Password
            //        HttpCookie userPasswordCookie = new HttpCookie("USERPWD")
            //        {
            //            Value = txt_Password.Text,
            //            Expires = DateTime.Now.AddDays(30)
            //        };
            //        Response.Cookies.Add(userPasswordCookie);
            //    }
            //}
            //else
            //{
            //    if (Request.Browser.Cookies.Equals(true))
            //    {
            //        //Check if the cookies with name USERNAME exist on user's machine
            //        if (Request.Cookies["USERNAME"] != null)
            //        {
            //            Response.Cookies.Remove("USERNAME");
            //            Response.Cookies["USERNAME"].Expires = DateTime.Now.AddDays(-30);

            //            Response.Cookies.Remove("USERPWD");
            //            Response.Cookies["USERPWD"].Expires = DateTime.Now.AddDays(-30);

            //            Response.Clear();
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Check the user supplied login credentials. 
        /// </summary>
        /// <returns>True if user supplies valid user name and password else returns false</returns>
        public bool CheckLoginCredentials()
        {
            bool ReturnValue = false;
            bool LoginSuccess = true;
            User UserInfo = new User();
            StringBuilder FormMessage;

            try
            {

                // Collect the user supplied information
                UserInfo.UserName = "Admin";
                UserInfo.Password = "1234";

                //Declare Login Success Global Variable and set it to false
                HttpContext.Current.Session["IsLoginSuccess"] = "NO";

                //UserInfo.CompanyID = ctrl_SelectDatabase.SelectedCompanyID;
                UserInfo.CompanyCode = ConfigurationManager.AppSettings["DefaultCompanyCode"].ToString();// "HO0001";

                // Get the record of the user from the database to validate against supplied data
                CurrentUser = UserManagement.GetInstance.GetUserByLoginName(UserInfo.UserName);
                //ThisUserOfficeTree = OfficeManagement.GetInstance.GetOfficeTreeByUserID(CurrentUser.UserID);

                // Show a message to the user after generating and HTML code in div, ul, li tag
                FormMessage = new StringBuilder("<div id='LoginErrors'><ul class='LoginFormMessage'>");

                // -----------------------------------------------------------------------------------------------
                if (CurrentUser.UserID.Equals(0) || CurrentUser == null)
                //"Login Failed! The user name doesn't exists.";
                {
                    Exception exp = Server.GetLastError();

                    LoginSuccess = false;
                    FormMessage.Append("<li>");
                    FormMessage.Append(string.Format(ReadXML.GetFailureMessage("KO_USER_NOT_EXIST"), UserInfo.UserName));
                    if (exp != null)
                    {
                        FormMessage.Append(" or ");
                        FormMessage.Append(exp.ToString());
                    }
                    FormMessage.Append("</li>");
                }
                else if (!CurrentUser.Password.Equals(MicroSecurity.Encrypt(UserInfo.Password)))
                //"Login Failed! Incorrect password.";
                {
                    LoginSuccess = false;
                    FormMessage.Append("<li>");
                    FormMessage.Append(ReadXML.GetFailureMessage("KO_PWD_MISMATCH"));
                    FormMessage.Append("</li>");
                }
                else if (string.IsNullOrEmpty(CurrentUser.CompanyID.ToString()))
                //"This user doesn't havae a company code";
                {
                    LoginSuccess = false;
                    FormMessage.Append("<li>");
                    FormMessage.Append(ReadXML.GetFailureMessage("KO_USER_NO_COMP_CODE"));
                    FormMessage.Append("</li>");
                }
                else if (CurrentUser.CompanyID.Equals(0))
                //"This user doesn't belongs to any company.";
                {
                    LoginSuccess = false;
                    FormMessage.Append("<li>");
                    FormMessage.Append(ReadXML.GetFailureMessage("KO_USER_NO_COMPANY"));
                    FormMessage.Append("</li>");
                }
                // -----------------------------------------------------------------------------------------------
                else
                {
                    // A VALID USER : RETURN TRUE FOR SUCCESS
                    LoginSuccess = true;

                    ReturnValue = true;
                    HttpContext.Current.Session["IsLoginSuccess"] = "YES";

                    // DO THE NEEDFUL AFTER SUCCESSFUL LOGIN TO THE APPLICATION
                    Micro.WebApplication.App_UserControls.UC_Login.UserLoginSuccess(true, CurrentUser);

                    //// MAINTAIN THE USERS INFORMATION 
                    //SetLoggedOnUserDetails(CurrentUser);

                    //// LOAD PERMISSION/RIGHTS
                    //SetUserRolePermissions();

                    //// LOAD USER SETTINGS
                    //GetAndSetUserSettings();
                }
                FormMessage.Append("</ul></div>");

                //Show the reason 
                if (!LoginSuccess)
                {
                    lit_Message.Text = FormMessage.ToString();
                    lit_TheDialogMessage.Text = FormMessage.ToString();
                    dialog_Message.Title = "Login Error";
                    dialog_Message.Show();
                }
                return ReturnValue;
            }
            catch (Exception ex)
            {

                //Response.Write(ex.Message.ToString());
                lit_Message.Text = ex.Message.ToString();
                lit_TheDialogMessage.Text = ex.Message.ToString();
                dialog_Message.Title = "Login Error";
                dialog_Message.Show();
                //throw (new Exception("Login Error" + ex.Message.ToString()));
                return false;
            }
            finally
            {

            }
        }



        public static void SetLoggedOnUserDetails(User currentUser)
        {
            Connection.LoggedOnUser = null;
            Connection.LoggedOnUser = currentUser;

            //UC_Login.CheckLoginCredentials
            //Micro.WebApplication.App_UserControls.UC_Login l = new UC_Login();
            //l.UserLoginSuccess(true, currentUser);
            //l.Dispose();


            BasePage.CurrentLoggedOnUser.TheUser = currentUser;
            BasePage.CurrentLoggedOnUser.TheCompany = Micro.BusinessLayer.Administration.CompanyManagement.GetInstance.GetCompanyByComapnyID(currentUser.CompanyID);
            BasePage.CurrentLoggedOnUser.TheOffice = Micro.BusinessLayer.Administration.OfficeManagement.GetInstance.GetOfficeByID(currentUser.OfficeID);
        }

        /// <summary>
        /// Gets the settings being recorded for the current user
        /// </summary>
        public static void GetAndSetUserSettings()
        {
            BasePage.CurrentLoggedOnUser.UserSettings = UserManagement.GetInstance.GetUserSettingListByUserID(CurrentUser.UserID);


            string UserMenuStyle = "Default";
            var TheCurrentMenuStyle = Micro.Commons.BasePage.CurrentLoggedOnUser.UserSettings.Find(s => s.UserSettingKeyName.ToUpper().Trim().Equals(MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString()));

            if (TheCurrentMenuStyle != null)
            {
                UserSetting s = (UserSetting)TheCurrentMenuStyle;
                UserMenuStyle = s.UserSettingValue;
                if (UserMenuStyle == "")
                    UserMenuStyle = "Default";
            }

            BasePage.CurrentLoggedOnUser.TheUserTheme = UserMenuStyle.Replace("Micro_", "").ToString();
        }


        public static void GetAndSetUserSettings(int userId)
        {
            BasePage.CurrentLoggedOnUser.UserSettings = UserManagement.GetInstance.GetUserSettingListByUserID(userId);


            string UserMenuStyle = "Default";
            var TheCurrentMenuStyle = Micro.Commons.BasePage.CurrentLoggedOnUser.UserSettings.Find(s => s.UserSettingKeyName.ToUpper().Trim().Equals(MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString()));

            if (TheCurrentMenuStyle != null)
            {
                UserSetting s = (UserSetting)TheCurrentMenuStyle;
                UserMenuStyle = s.UserSettingValue;
                if (UserMenuStyle == "")
                    UserMenuStyle = "Default";
            }

            BasePage.CurrentLoggedOnUser.TheUserTheme = UserMenuStyle.Replace("Micro_", "").ToString();
        }

        /// <summary>
        /// This method gets the permission value of Add, Edit, Delete and View from the database and sets into the static variable at base page, which will be compared in each and every page load
        /// </summary>
        public static void SetUserRolePermissions()
        {

            List<Permission> thePermissionList = RolePermissionManagement.GetInstance.GetPermissions();

            BasePage.CurrentLoggedOnUser.PermissionList = thePermissionList;
            BasePage.CurrentLoggedOnUser.UserRolePermissions = RolePermissionManagement.GetInstance.SelectAllRolePermissionsByRoleID(CurrentUser.RoleID);

            var AddPermissionId = thePermissionList.Find(p => p.PermissionDescription.Equals(MicroEnums.PermissionDescription.Add.ToString()));
            var EdiPermissionId = thePermissionList.Find(p => p.PermissionDescription.Equals(MicroEnums.PermissionDescription.Edit.ToString()));
            var DelPermissionId = thePermissionList.Find(p => p.PermissionDescription.Equals(MicroEnums.PermissionDescription.Delete.ToString()));
            var ViewPermissionId = thePermissionList.Find(p => p.PermissionDescription.Equals(MicroEnums.PermissionDescription.View.ToString()));
            if (AddPermissionId != null)
            {
                BasePage.AddPermissionId = AddPermissionId.PermissionID;
            }
            if (EdiPermissionId != null)
            {
                BasePage.EdiPermissionId = EdiPermissionId.PermissionID;
            }
            if (DelPermissionId != null)
            {
                BasePage.DelPermissionId = DelPermissionId.PermissionID;
            }
            if (ViewPermissionId != null)
            {
                BasePage.ViewPermissionId = ViewPermissionId.PermissionID;
            }
        }


        public static void SetUserRolePermissions(int roleId)
        {

            List<Permission> thePermissionList = RolePermissionManagement.GetInstance.GetPermissions();

            BasePage.CurrentLoggedOnUser.PermissionList = thePermissionList;
            BasePage.CurrentLoggedOnUser.UserRolePermissions = RolePermissionManagement.GetInstance.SelectAllRolePermissionsByRoleID(roleId);

            var AddPermissionId = thePermissionList.Find(p => p.PermissionDescription.Equals(MicroEnums.PermissionDescription.Add.ToString()));
            var EdiPermissionId = thePermissionList.Find(p => p.PermissionDescription.Equals(MicroEnums.PermissionDescription.Edit.ToString()));
            var DelPermissionId = thePermissionList.Find(p => p.PermissionDescription.Equals(MicroEnums.PermissionDescription.Delete.ToString()));
            var ViewPermissionId = thePermissionList.Find(p => p.PermissionDescription.Equals(MicroEnums.PermissionDescription.View.ToString()));
            if (AddPermissionId != null)
            {
                BasePage.AddPermissionId = AddPermissionId.PermissionID;
            }
            if (EdiPermissionId != null)
            {
                BasePage.EdiPermissionId = EdiPermissionId.PermissionID;
            }
            if (DelPermissionId != null)
            {
                BasePage.DelPermissionId = DelPermissionId.PermissionID;
            }
            if (ViewPermissionId != null)
            {
                BasePage.ViewPermissionId = ViewPermissionId.PermissionID;
            }
        }

        /// <summary>
        /// Depending upon the user setting redirect the user to the specified page. if user has no settings then redierct to default page
        /// </summary>
        private void RedirectLoggedOnUser()
        {
            string WebServerIP = @"http://" + ConfigurationManager.AppSettings["WebServerIP"].ToString();
            string RedirectURL = string.Concat(WebServerIP, "/Default.aspx");
            var TheDefaultPage = BasePage.CurrentLoggedOnUser.UserSettings.Find(s => s.UserSettingKeyName.Equals(MicroEnums.UserSettingKey.USER_DEFAULT_PAGE.ToString()));
            if (TheDefaultPage != null)
            {
                if (((UserSetting)TheDefaultPage).UserSettingValue.Trim() != "")
                {
                    RedirectURL = string.Concat(WebServerIP, "/", TheDefaultPage.UserSettingValue);
                }
                else
                {
                    if (Micro.Commons.Connection.LoggedOnUser.RoleDescription.ToUpper().Contains("ADMIN"))
                    {
                        RedirectURL = string.Concat(WebServerIP, "/APPS/Default.aspx");
                    }
					else if (Micro.Commons.Connection.LoggedOnUser.RoleDescription.ToUpper().Contains("STUDENT"))
                    {
                        RedirectURL = string.Concat(WebServerIP, "/APPS/ICAS/Student/Default.aspx");
                    }
					else if (Micro.Commons.Connection.LoggedOnUser.RoleDescription.ToUpper().Contains("STAFF"))
					{
						RedirectURL = string.Concat(WebServerIP, "/APPS/ICAS/Staffs/Default.aspx");
					}
					else if (Micro.Commons.Connection.LoggedOnUser.RoleDescription.ToUpper().Contains("ALUMNI"))
					{
						RedirectURL = string.Concat("alumni.tsdcollege.in");
					}
					else
					{
						RedirectURL = string.Concat(WebServerIP, "/Default.aspx");
					}
                }
            }
            else
            {
                RedirectURL = string.Concat(WebServerIP, "/Default.aspx");
                }

                Response.Redirect(RedirectURL);
        }

        private void RedirectLoggedOnUser(string thePageUrl)
        {
            string WebServerIP = @"http://" + ConfigurationManager.AppSettings["WebServerIP"].ToString();
            string RedirectURL = string.Concat(WebServerIP, thePageUrl);
            Response.Redirect(RedirectURL);
        }

        /// <summary>
        /// Insert a session record for the user has logged into the system.
        /// </summary>
        /// <param name="theUser"></param>
        private void InsertUserSessionLog(User theUser)
        {
            try
            {
                UserLog usrLog = new UserLog();
                usrLog.UserID = theUser.UserID;
                usrLog.OfficeID = theUser.OfficeID;
                usrLog.LoggedOnFromSystemIP = Request.ServerVariables["REMOTE_HOST"].ToString();
                usrLog.SessionID = Session.SessionID;
                //string[] computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
                //String ecn = System.Environment.MachineName;
                usrLog.ClientComputerName = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName; // computer_name[0].ToString();
                int UserLogID = Micro.BusinessLayer.LoginManagement.GetInstance.InsertUserSessionLog(usrLog);
                Session["UserLogID"] = UserLogID;
            }
            catch
            {
            }
        }

        /// <summary>
        /// This method checked the user name and appends necessary item to the code if required
        /// </summary>
        //private void SetUserNameField()
        //{
        //    string UserName = txt_UserName.Text.ToString().Trim();
        //    string UserCode;
        //    if (UserName.Length > 4)
        //    {
        //        if (UserName.Substring(0, 4).ToString().ToUpper() == "MLFL")
        //        {
        //            UserCode = UserName.Substring(4);
        //        }
        //        else
        //        {
        //            UserCode = UserName;
        //        }
        //        int TempUser1;
        //        try
        //        {
        //            TempUser1 = int.Parse(UserCode);
        //            txt_UserName.Text = string.Format(UserCode.ToString(), "######");
        //        }
        //        catch
        //        {
        //        }
        //    }
        //    else
        //    {
        //        if (UserName.Length > 0)
        //        {
        //            int TempUser;
        //            try
        //            {
        //                TempUser = int.Parse(UserName);
        //                txt_UserName.Text = string.Format(TempUser.ToString(), "######");
        //            }
        //            catch
        //            {
        //            }
        //        }
        //    }
        //}



        private void CheckForWebsiteMaintanaceFlag()
        {
             
        }



        #endregion

        protected void btn_RegisterNewUser_Click(object sender, EventArgs e)
        {
            string theOTP = SendOTP(txt_UserPhone.Text);
            
            //ASK FOR OTP
            if (ValidateFormFields() && ValidateOTP(theOTP))
            {
                //success
                bool isSuccss = InsertUserRecord4Registration();
                if (isSuccss)
                {

                    ShowSuccessOrWelcomeMessage2User();
                }
                else
                {
                    //failure
                    ShowErrorMessage2User();
                }
            }
            else
            {
                //failure
                ShowErrorMessage2User();
            }
        }

        private bool ValidateFormFields()
        {
            bool retValue = true;
            StringBuilder sbText = new StringBuilder("<ul>");
            if (txt_UserFullName.Text.Equals(string.Empty))
            {
                sbText.AppendLine("<li>Please enter name, it can't be blank.</li>");
                txt_UserFullName.Focus();
                retValue = false;
            }
            if (txt_UserPhone.Text.Equals(string.Empty))
            {
                sbText.AppendLine("<li>Please provide the name, it can't be blank.</li>");
                txt_UserFullName.Focus();
                retValue = false;
            }
            if (txt_UserEmail.Text.Equals(string.Empty))
            {
                sbText.AppendLine("<li>Please provide the email name, it can't be blank.</li>");
                txt_UserFullName.Focus();
                retValue = false;
            }
            else
            {
                
            }
            return retValue;
        }

        private void ShowSuccessOrWelcomeMessage2User()
        {
            //throw new NotImplementedException();
            lit_TheDialogMessage.Text = String.Format(ReadXML.GetSuccessMessage("OK_USER_REGISTER_DONE"), rbList_UserType.SelectedItem.Text);
            dialog_Message.Show();
        }

        private void ShowErrorMessage2User()
        {
            //throw new NotImplementedException();
            lit_TheDialogMessage.Text = String.Format(ReadXML.GetFailureMessage("KO_USER_REGISTER_FAILED"), rbList_UserType.SelectedItem.Text);
            dialog_Message.Show();
        }

        private bool InsertUserRecord4Registration()
        {
            //throw new NotImplementedException();
            User objUser = new User();
            objUser.UserName = txt_UserPhone.Text;
            objUser.PhoneNumber = txt_UserPhone.Text;
            objUser.EmailAddress = txt_UserEmail.Text;
            objUser.UserReferenceName = txt_UserFullName.Text;
            objUser.UserType = rbList_UserType.SelectedItem.Text.ToString();
            //objUser.UserReferenceID = -4; // int.Parse(ddl_UserReferenceName.SelectedValue);
            objUser.RoleID = int.Parse(rbList_UserType.SelectedItem.Value.ToString());
            objUser.Password = MicroSecurity.Encrypt(txt_UserPhone.Text.ToString());
            int ProcReturnValue = UserManagement.GetInstance.Insert4Registration(objUser);

            if (ProcReturnValue > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool ValidateOTP(string theOTP)
        {
            //throw new NotImplementedException();
            return true;
        }

        private string SendOTP(string p)
        {
            //throw new NotImplementedException();

            return "NA";
        }

        private void SetValidationExpressions()
        {

            //regularExpressionValidator_UserName4Login.ValidationExpression = MicroConstants.REGEX_ALPHANUMERIC;
            //regularExpressionValidator_UserName4Login.ErrorMessage = "Invlid Input! Only aplhanumeric please!";

            regularExpressionValidator_MobileNo.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_EmailId.ValidationExpression = MicroConstants.REGEX_EMAILID;
            regularExpressionValidator_Name.ValidationExpression = MicroConstants.REGEX_NAME;
            
            string userType = rbList_UserType.SelectedItem.Text.ToString();
            regularExpressionValidator_Name.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_VALID_NAME", userType);
        }

        protected void rbList_UserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_RegisterNewUser.Text = string.Format("Register As {0}", rbList_UserType.SelectedItem.Text.ToString());
            //if (rbList_UserType.SelectedItem.Text.ToString().Equals("Alumni"))
            //{
            //    Server.TransferRequest("~/Alumni.aspx");
            //}
            //else
            //{
            //    btn_RegisterNewUser.Text = string.Format("Submit To Register As New :-{0}", rbList_UserType.SelectedItem.Text.ToString());
            //}
        }

        protected void btn_VerifyOTP_Click(object sender, EventArgs e)
        {

        }

        protected void txt_UserEmail_Unload(object sender, EventArgs e)
        {

        }

        protected void txt_UserPhone_Load(object sender, EventArgs e)
        {

        }

        protected void txt_UserCaptcha_Unload(object sender, EventArgs e)
        {

        }


    }
}