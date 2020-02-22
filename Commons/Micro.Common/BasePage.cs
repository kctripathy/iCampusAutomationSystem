using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Objects.Administration;
using System.Collections.Generic;
using Micro.Objects;
using System.Configuration;

namespace Micro.Commons
{
    public class BasePage : Page
    {
        #region Declaration
        /// <summary>
        /// Class is written to facilitate the returns from UploadImage() method
        /// </summary>
        public class ProfileImage
        {
            public string ImageUrl;
            public byte[] ImageBinaries;
        }



        public class EstbFile
        {
            public string strFileName;
            public byte[] arrByteEstb;
        }

        /// <summary>
        /// Default Image File Extension is ".jpg"
        /// </summary>
        public const string DefaultImageFileExtension = ".jpg";
        private bool _ViewStateCompressionDisabled = false;
        protected User UserProfile;
        //public static bool WillShowAllChildBranchRecords = false;
        public static int AddPermissionId, EdiPermissionId, DelPermissionId, ViewPermissionId;

        public static bool IsActive = true;

        public class CurrentLoggedOnUser
        {
            public static User TheUser;
            public static Page ClientPage;
            public static Company TheCompany;
            public static Office TheOffice;
            public static string TheUserTheme;
            public static List<Permission> PermissionList;
            public static List<RolePermission> UserRolePermissions = null;
            public static List<UserSetting> UserSettings = null;
        }

        public enum UserSettingEnum
        {
            [StringValue("Default Mode")]
            DEFAULT_MODE,

            [StringValue("Default Page")]
            DEFAULT_PAGE,

            [StringValue("Menu Style")]
            MENU_STYLE
        }
        #endregion

        #region Properties
        public bool ViewStateCompressionDisabled
        {
            get
            {
                return _ViewStateCompressionDisabled;
            }
            set
            {
                _ViewStateCompressionDisabled = value;
            }
        }
        #endregion

        #region Events
        public BasePage()
        {
            PreInit += BasePage_PreInit;
        }


        void BasePage_PreInit(object sender, EventArgs e)
        {
            this.Page.Theme = (CurrentLoggedOnUser.TheUserTheme == null ? "Default" : CurrentLoggedOnUser.TheUserTheme);
            ////Check if the application is available to user or not

            if (ConfigurationManager.AppSettings["UnavailableDateTime"] != null && ConfigurationManager.AppSettings["UnavailableDateTimeDisplay"]=="YES")
            {
                Response.Redirect("~/App_Error/Maintenance.aspx");
            }
            //Check if the current session has expired or not
            else if (Micro.Commons.Connection.LoggedOnUser == null)
            {
                Response.Redirect("~/App_Error/AccessDenied.aspx");
            }


            //if (ConfigurationManager.AppSettings["UnavailableDateTime"] != null)
            //{
            //    Response.Redirect("~/App_Error/Maintenance.aspx");
            //}
            ////Check if the current session has expired or not
            //else if (Micro.Commons.Connection.LoggedOnUser == null)
            //{
            //    Response.Redirect("~/App_Error/AccessDenied.aspx");
            //}
            //else
            {
                //if (HasAddPermission(this.Page).Equals(false) && HasEditPermission(this.Page).Equals(false) && HasViewPermission(this.Page).Equals(false))
                //{
                //    Response.Redirect("~/App_Error/PermissionNeeded.aspx");
                //}
                //if ((((User)Session["CurrentUser"]).RoleDescription.ToLower().Equals("super administrator")) ||
                //    (((User)Session["CurrentUser"]).RoleDescription.ToLower().Equals("administrator")) ||
                //    (((User)Session["CurrentUser"]).RoleDescription.ToLower().Equals("top-management")) ||
                //    (((User)Session["CurrentUser"]).RoleDescription.ToUpper().Equals("MANAGING DIRECTOR")) ||
                //    (((User)Session["CurrentUser"]).RoleDescription.ToUpper().Equals("DIRECTOR")) ||
                //    (((User)Session["CurrentUser"]).RoleDescription.ToUpper().Equals("CHIEF EXECUTIVE OFFICER")) ||
                //    (((User)Session["CurrentUser"]).RoleDescription.ToUpper().Equals("GENERAL MANAGER")) ||
                //    (((User)Session["CurrentUser"]).RoleDescription.ToUpper().Equals("UNIT MANAGER"))
                //    )
                //{
                //    CurrentLoggedOnUser.IsAdministrator = true;
                //    WillShowAllChildBranchRecords = true;
                //}
                //else
                //{
                //    CurrentLoggedOnUser.IsAdministrator = false;
                //    WillShowAllChildBranchRecords = false;
                //}
            }
        }


        protected override void InitializeCulture()
        {
            ViewStateCompressionDisabled = true;
            base.InitializeCulture();
        }

        /// <summary>
        /// Manage Error on the web site :
        ///		- log the error
        ///		- redirect to error page
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError(System.EventArgs e)
        {
            try
            {
                Exception ex = Server.GetLastError();
                HttpContext.Current.Session["LastError"] = ex;
                Log.Error(ex);
                Response.Redirect("~/App_Error/Error500.aspx?errorpath=" + Request.RawUrl);
            }
            catch
            {
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            //TODO: KISHOR: UNCOMMENT THIS LINE FOR APPLYING THE PERMISSION
            //var TheCurrentPage = CurrentLoggedOnUser.UserRolePermissions.Find(rp => rp.NavigationURL.ToUpper().Equals(Helpers.GetFullPathPageName(this.Page).ToUpper()) && rp.FormOrMenu.Equals("F"));
            //Micro.ErrorLogger.UserPageVisits.Record(this.Page.ToString());
        }
        #endregion

        #region Methods & Implementation

        public static bool HasAddPermission(Page thePage)
        {
            var canAdd = CurrentLoggedOnUser.UserRolePermissions.Find(rp => rp.NavigationURL.ToUpper().Equals(Helpers.GetFullPathPageName(thePage).ToUpper()) && rp.PermissionID == AddPermissionId);
            if (canAdd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool HasEditPermission(Page thePage)
        {
            var canEdit = CurrentLoggedOnUser.UserRolePermissions.Find(rp => rp.NavigationURL.ToUpper().Equals(Helpers.GetFullPathPageName(thePage).ToUpper()) && rp.PermissionID == EdiPermissionId);
            if (canEdit == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool HasViewPermission(Page thePage)
        {
            var canView = CurrentLoggedOnUser.UserRolePermissions.Find(rp => rp.NavigationURL.ToUpper().Equals(Helpers.GetFullPathPageName(thePage).ToUpper()) && rp.PermissionID == ViewPermissionId && rp.FormOrMenu.Equals("F"));
            if (canView == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static bool HasAddPermission()
        {
            var canAdd = CurrentLoggedOnUser.UserRolePermissions.Find(rp => rp.NavigationURL.ToUpper().Trim().Equals(Helpers.GetFullPathPageName(CurrentLoggedOnUser.ClientPage).ToUpper()) && rp.PermissionID == AddPermissionId);
            if (canAdd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool HasEditPermission()
        {
            var canEdit = CurrentLoggedOnUser.UserRolePermissions.Find(rp => rp.NavigationURL.ToUpper().Equals(Helpers.GetFullPathPageName(CurrentLoggedOnUser.ClientPage).ToUpper()) && rp.PermissionID == EdiPermissionId);
            if (canEdit == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool HasViewPermission()
        {
            var canView = CurrentLoggedOnUser.UserRolePermissions.Find(rp => rp.NavigationURL.ToUpper().Equals(Helpers.GetFullPathPageName(CurrentLoggedOnUser.ClientPage).ToUpper()) && rp.PermissionID == ViewPermissionId && rp.FormOrMenu.Equals("F"));
            if (canView == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if the default setting for all pages is Add or not
        /// </summary>
        /// <returns>True if Add else returns False</returns>
        public static bool IsDefaultModeAdd()
        {
            var DefaultMode = CurrentLoggedOnUser.UserSettings.Find(s => s.UserSettingKeyName.ToUpper().Trim().Equals(MicroEnums.UserSettingKey.USER_DEFAULT_MODE.ToString()));

            if (DefaultMode == null)
            {
                return false;
            }
            else
            {
                UserSetting s = (UserSetting)DefaultMode;
                if (s.UserSettingValue.ToLower().Equals(MicroEnums.PermissionDescription.Add.ToString().ToLower()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsDefaultModeView()
        {
            var DefaultMode = CurrentLoggedOnUser.UserSettings.Find(s => s.UserSettingKeyName.ToUpper().Trim().Equals(MicroEnums.UserSettingKey.USER_DEFAULT_MODE));

            if (DefaultMode == null)
            {
                return false;
            }
            else
            {
                UserSetting s = (UserSetting)DefaultMode;
                if (s.UserSettingValue.ToLower().Equals(MicroEnums.PermissionDescription.View.ToString().ToLower()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #region Validation-Type
        public static bool IsValidDate(string dateValue)
        {
            bool ReturnValue = true;

            try
            {
                DateTime.Parse(dateValue);
            }
            catch
            {
                ReturnValue = false;
            }

            return ReturnValue;
        }

        public static bool IsValidEmailID(string emailID)
        {
            bool ReturnValue = true;

            try
            {
                System.Net.Mail.MailAddress TheMailAddress = new System.Net.Mail.MailAddress(emailID);
                ReturnValue = true;
            }
            catch
            {
                ReturnValue = false;
            }

            return ReturnValue;
        }

        /// <summary>
        /// Filters only *.gif, *.jpb, *.jpeg, *.png
        /// </summary>
        /// <param name="imageFileExtension"></param>
        /// <returns>Returns True, if File Extension is  *.gif, *.jpb, *.jpeg, *.png</returns>
        public static bool IsImageFile(string imageFileExtension)
        {
            bool ReturnValue = true;

            switch (imageFileExtension.ToUpper())
            {
                case ".GIF":
                    ReturnValue = true;
                    break;

                case ".JPG":
                    ReturnValue = true;
                    break;

                case ".JPEG":
                    ReturnValue = true;
                    break;

                case ".PNG":
                    ReturnValue = true;
                    break;

                default:
                    ReturnValue = false;
                    break;
            }

            return ReturnValue;
        }

        /// <summary>
        /// Replaces invalid Characters (Not acceptable by Windows while renaming a file or Path) with '_' underscore. 
        /// </summary>
        /// <param name="fileName">File Name</param>
        /// <returns>Returns Valid Windows File Name.</returns>
        public static string GetValidFileName(string fileName)
        {
            string ReturnValue = fileName;

            foreach (char InvalidFileNameChar in Path.GetInvalidFileNameChars())
            {
                ReturnValue = ReturnValue.Replace(InvalidFileNameChar, '_');
            }

            foreach (char InvalidPathChar in Path.GetInvalidPathChars())
            {
                ReturnValue = ReturnValue.Replace(InvalidPathChar.ToString(), string.Empty);
            }

            return ReturnValue;
        }
        #endregion

        #region Profile-Image
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUpload_ProfileImage"></param>
        /// <param name="img_ProfileImage"></param>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public static ProfileImage UploadImage(ProfileImage theProfileImage, FileUpload fileUpload_ProfileImage, System.Web.UI.WebControls.Image img_ProfileImage, string imageUrl)
        {
            if (theProfileImage == null)
                theProfileImage = new ProfileImage();

            ProfileImage TheProfileImage = theProfileImage;
            Page CurrentPage = fileUpload_ProfileImage.Page;

            if (fileUpload_ProfileImage.HasFile)
            {
                try
                {
                    string ImageUrl = imageUrl;

                    if (!string.IsNullOrEmpty(ImageUrl))
                    {

                        fileUpload_ProfileImage.SaveAs(HttpContext.Current.Server.MapPath(imageUrl));
                        img_ProfileImage.ImageUrl = ImageUrl;

                        TheProfileImage.ImageUrl = ImageUrl;
                        TheProfileImage.ImageBinaries = WriteImageToSQL(fileUpload_ProfileImage);
                    }
                    else
                    {
                        TheProfileImage.ImageUrl = null;
                        TheProfileImage.ImageBinaries = null;

                        ScriptManager.RegisterStartupScript(CurrentPage, CurrentPage.GetType(), "Error :", "alert('Upload only .gif, .jpg, .jpeg, .png');", true);
                    }
                }
                catch
                {
                    TheProfileImage.ImageUrl = null;
                    TheProfileImage.ImageBinaries = null;
                    ScriptManager.RegisterStartupScript(CurrentPage, CurrentPage.GetType(), "Error :", "alert('File not found.');", true);
                }
            }

            return TheProfileImage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUpload_ProfileImage"></param>
        /// <param name="recordID"></param>
        /// <param name="settingKeyName"></param>
        /// <param name="settingKeyDescription"></param>
        /// <returns></returns>
        public static string SetProfileImageUrl(string recordID, string settingKeyName, string settingKeyDescription, FileUpload fileUpload_ProfileImage)
        {
            string ReturnValue = string.Empty;
            string ImageFileName = fileUpload_ProfileImage.FileName;
            // string ProfileUrl = MicroConstants.PROFILE_IMAGE_TEMP;
            string ProfileUrl = MicroConstants.PROFILE_IMAGE_URL + "Temp\\";
            ReturnValue = SetProfileImageUrl(recordID, settingKeyName, settingKeyDescription, ProfileUrl, ImageFileName);

            return ReturnValue;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="settingKeyName"></param>
        /// <param name="settingKeyDescription"></param>
        /// <returns></returns>
        public static string GetProfileImageUrl(string recordID, string settingKeyName, string settingKeyDescription)
        {
            string ReturnValue = string.Empty;
            string ProfileUrl = MicroConstants.PROFILE_IMAGE_URL;

            ReturnValue = GetProfileImageUrl(recordID, settingKeyName, settingKeyDescription, ProfileUrl);

            return ReturnValue;
        }

        /// <summary>
        /// Set Profile Image Url
        /// </summary>
        /// <param name="profileUrl">Virtual directory path to store the profile image file</param>
        /// <param name="recordID">Profile-holder ID. Such as FieldForceID, CustomerID, EmployeeID</param>
        /// <param name="settingKeyName">Setting Key Name. Such as Field Force Profile, Customer Profile Policy, Customer KYC</param>
        /// <param name="settingKeyDescription">Setting Key Description. Such as Photo, Signature, Thumb Impression</param>
        /// <param name="imageFileName">Image file name</param>
        /// <returns>ImageUrl</returns>
        private static string SetProfileImageUrl(string recordID, string settingKeyName, string settingKeyDescription, string profileUrl, string imageFileName)
        {
            string ReturnValue = string.Empty;

            string ValidImageFileName = GetValidFileName(settingKeyDescription);
            string ImageFileExtension = Path.GetExtension(imageFileName);

            if (IsImageFile(ImageFileExtension))
            {
                ImageFileExtension = DefaultImageFileExtension;
                ReturnValue = Path.Combine(profileUrl, string.Format("{0}-{1}-{2}{3}", settingKeyName, recordID, ValidImageFileName, ImageFileExtension));
            }

            return ReturnValue;
        }

        /// <summary>
        /// Get Profile Image Url
        /// </summary>
        /// <param name="profileUrl">Virtual directory path to store the profile image file.</param>
        /// <param name="recordID">Profile-holder ID. Such as FieldForceID, CustomerID, EmployeeID</param>
        /// <param name="settingKeyName">Setting Key Name. Such as Field Force Profile, Customer Profile Policy, Customer KYC</param>
        /// <param name="settingKeyDescription">Setting Key Description. Such as Photo, Signature, Thumb Impression</param>
        /// <returns>ImageUrl</returns>
        private static string GetProfileImageUrl(string recordID, string settingKeyName, string settingKeyDescription, string profileUrl)
        {
            string ReturnValue = string.Empty;

            string ValidImageFileName = GetValidFileName(settingKeyDescription);
            string ImageFileExtension = DefaultImageFileExtension;

            ReturnValue = Path.Combine(profileUrl, string.Format("{0}-{1}-{2}{3}", settingKeyName, recordID, ValidImageFileName, ImageFileExtension));

            return ReturnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageUrl"></param>
        public static void MoveImageFile(string imageUrl)
        {
            if (imageUrl != null)
            {
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    string SourceFile = imageUrl;
                    string DestinationFile = SourceFile.Replace("Temp\\", string.Empty);

                    if (File.Exists(HttpContext.Current.Server.MapPath(SourceFile)))
                    {
                        if (!SourceFile.Equals(DestinationFile))
                        {
                            File.Copy(HttpContext.Current.Server.MapPath(SourceFile), HttpContext.Current.Server.MapPath(DestinationFile), true);
                            RemoveImageFile(imageUrl);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageUrl"></param>
        public static void RemoveImageFile(string imageUrl)
        {
            if (imageUrl != null)
            {
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    string SourceFile = imageUrl;

                    if (File.Exists(HttpContext.Current.Server.MapPath(SourceFile)))
                    {
                        File.Delete(HttpContext.Current.Server.MapPath(SourceFile));
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUploader"></param>
        /// <returns></returns>
        public static byte[] WriteImageToSQL(FileUpload fileUploader)
        {
            byte[] Image = null;

            if (fileUploader.PostedFile != null)
            {
                if (!string.IsNullOrEmpty(fileUploader.PostedFile.FileName))
                {
                    HttpPostedFile img = fileUploader.PostedFile;
                    Image = new byte[fileUploader.PostedFile.ContentLength];
                    img.InputStream.Read(Image, 0, (int)fileUploader.PostedFile.ContentLength);
                }
            }
            return Image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUploader"></param>
        /// <returns></returns>
        public static byte[] WritePdfToSQL(FileUpload fileUploader)
        {
            byte[] thePdf = null;

            if (fileUploader.PostedFile != null)
            {
                if (!string.IsNullOrEmpty(fileUploader.PostedFile.FileName))
                {
                    HttpPostedFile postedPDF = fileUploader.PostedFile;
                    thePdf = new byte[fileUploader.PostedFile.ContentLength];
                    postedPDF.InputStream.Read(thePdf, 0, (int)fileUploader.PostedFile.ContentLength);
                }
            }
            return thePdf;
        }
        #endregion

        /// <summary>
        /// Gets Data Operation Result.
        /// </summary>
        /// <param name="procReturnValue">Record ID</param>
        /// <param name="recordName">Name of the record. E.g. Customer, Field Force</param>
        /// <param name="DataOperationMode">MicroEnums.DataOperation type</param>
        /// <returns>String. Data Operation Result.</returns>
        public static string GetDataOperationResult(int procReturnValue, string recordName, MicroEnums.DataOperation DataOperationMode = MicroEnums.DataOperation.None)
        {
            string TheMessage = string.Empty;

            if (procReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                string SuccessMessage = MicroEnums.DataOperationResult.Success.GetStringValue();

                if (DataOperationMode == MicroEnums.DataOperation.AddNew)
                    TheMessage = string.Format(SuccessMessage, "inserted");

                if (DataOperationMode == MicroEnums.DataOperation.Edit)
                    TheMessage = string.Format(SuccessMessage, "updated");

                if (DataOperationMode == MicroEnums.DataOperation.Delete)
                    TheMessage = string.Format(SuccessMessage, "deleted");

                TheMessage = string.Format("<div class='SuccessDialogBox'>&nbsp;{0}</div>", TheMessage);

            }
            else if (procReturnValue.Equals((int)MicroEnums.DataOperationResult.Failure))
            {
                string FailureMessage = MicroEnums.DataOperationResult.Failure.GetStringValue();

                if (DataOperationMode == MicroEnums.DataOperation.AddNew)
                    TheMessage = string.Format(FailureMessage, "insert");

                if (DataOperationMode == MicroEnums.DataOperation.Edit)
                    TheMessage = string.Format(FailureMessage, "update");

                if (DataOperationMode == MicroEnums.DataOperation.Delete)
                    TheMessage = string.Format(FailureMessage, "delete");

                TheMessage = string.Format("<div class='FailureDialogBox'>&nbsp;{0}</div>", TheMessage);

            }
            else if (procReturnValue.Equals((int)MicroEnums.DataOperationResult.Duplicate))
            {
                TheMessage = MicroEnums.DataOperationResult.Duplicate.GetStringValue();
                TheMessage = string.Format("<div class='FailureDialogBox'>&nbsp;{0}</div>", TheMessage);

            }
            else if (procReturnValue.Equals((int)MicroEnums.DataOperationResult.RecordNotFound))
            {
                TheMessage = MicroEnums.DataOperationResult.RecordNotFound.GetStringValue();
                TheMessage = string.Format("<div class='FailureDialogBox'>&nbsp;<div class='DialogMessage'>{0}</div>", TheMessage);

            }
            else
            {
                TheMessage = MicroEnums.DataOperationResult.OperationNotPossible.GetStringValue();
                TheMessage = string.Format("<div class='FailureDialogBox'>&nbsp;{0}</div>", TheMessage);

            }

            if (!string.IsNullOrEmpty(recordName))
            {
                TheMessage = TheMessage.Replace("Record", recordName);
                TheMessage = TheMessage.Replace("record", recordName);
            }

            return TheMessage;
        }

        public static DateTime CalculateDateOfBirth(string age)
        {
            DateTime ReturnValue;

            if (string.IsNullOrEmpty(age))
                age = MicroConstants.DEFAULT_MIN_AGE;

            int TheAge = int.Parse(age);


            if (TheAge > 0)
                ReturnValue = DateTime.Today.AddYears(TheAge * -1);
            else
                ReturnValue = DateTime.Today;

            return ReturnValue;
        }

        public static int CalculateAge(DateTime dateOfBirth)
        {
            int ReturnValue = DateTime.Now.Year - dateOfBirth.Year;

            if (DateTime.Now.Month < dateOfBirth.Month || (DateTime.Now.Month == dateOfBirth.Month && DateTime.Now.Day < dateOfBirth.Day))
                --ReturnValue;

            return ReturnValue;
        }

        public static void ChangeSalutation(DropDownList theSalutation, DropDownList theGender, DropDownList theMaritalStatus, TextBox theHusbandName)
        {
            string TheGender = MicroEnums.Gender.Male.GetStringValue();
            theHusbandName.ReadOnly = true;

            string TheSalutation = theSalutation.SelectedItem.Text;

            if (TheSalutation.Equals(MicroEnums.Salutations.Dr.GetStringValue()))
            {
                theGender.Text = TheGender;
                theGender.Enabled = true;
            }
            else
            {
                if (TheSalutation.Equals(MicroEnums.Salutations.Mr.GetStringValue()))
                {
                    TheGender = MicroEnums.Gender.Male.GetStringValue();
                    theHusbandName.ReadOnly = true;
                    theHusbandName.Text = string.Empty;
                }
                else
                {
                    TheGender = MicroEnums.Gender.Female.GetStringValue();

                    if (TheSalutation.Equals(MicroEnums.Salutations.Miss.GetStringValue()))
                    {
                        theMaritalStatus.Text = MicroEnums.MaritalStatus.Unmarried.GetStringValue();
                        theHusbandName.ReadOnly = true;
                        theHusbandName.Text = string.Empty;
                    }
                    else
                    {
                        theMaritalStatus.Text = MicroEnums.MaritalStatus.Married.GetStringValue();
                        theHusbandName.ReadOnly = false;
                    }
                }

                theGender.Text = TheGender;
                theGender.Enabled = false;
            }
            ChangeMartialStatus(theSalutation, theGender, theMaritalStatus, theHusbandName);
        }

        public static void ChangeMartialStatus(DropDownList theSalutation, DropDownList theGender, DropDownList theMaritalStatus, TextBox theHusbandName)
        {
            string TheSalutation = theSalutation.SelectedItem.Text;

            //if (TheSalutation.Equals(MicroEnums.GetStringValue(MicroEnums.Salutations.Mr)))
            //{
            //    theHusbandName.ReadOnly = true;
            //    theHusbandName.Text = string.Empty;
            //}
            //else if (TheSalutation.Equals(MicroEnums.GetStringValue(MicroEnums.Salutations.Miss)))
            //{
            //    theMaritalStatus.Text = MicroEnums.GetStringValue(MicroEnums.MaritalStatus.Unmarried);
            //    theHusbandName.ReadOnly = true;
            //    theHusbandName.Text = string.Empty;
            //}
            //else if (TheSalutation.Equals(MicroEnums.GetStringValue(MicroEnums.Salutations.Mrs)))
            //{
            //    theMaritalStatus.Text = MicroEnums.GetStringValue(MicroEnums.MaritalStatus.Married);
            //    theHusbandName.ReadOnly = false;
            //}
            //else if (TheSalutation.Equals(MicroEnums.GetStringValue(MicroEnums.Salutations.Dr)))
            //{
            //    string TheGender = theGender.SelectedItem.Text;
            //    string TheMaritalStatus = theMaritalStatus.SelectedItem.Text;

            //    if (TheGender.Equals(MicroEnums.Gender.Female.GetStringValue()) && TheMaritalStatus.Equals(MicroEnums.MaritalStatus.Married.GetStringValue()))
            //    {
            //        theHusbandName.ReadOnly = false;
            //    }
            //    else
            //    {
            //        theHusbandName.ReadOnly = true;
            //        theHusbandName.Text = string.Empty;
            //    }
            //}

            theHusbandName.ReadOnly = !(theMaritalStatus.Text.ToString().Equals(MicroEnums.GetStringValue(MicroEnums.MaritalStatus.Married)));
            if (theHusbandName.ReadOnly)
            {
                theHusbandName.BackColor = Color.LightGray;
                theHusbandName.Text = string.Empty;
            }
            else
            {
                theHusbandName.BackColor = Color.White;
            }

        }

        public static void EnableControls(View theView, bool enableFlag = true)
        {
            Color theSelectModeColor = Color.White;
            Color Fontcolor = Color.Black;
            foreach (Control ctrl in theView.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).BackColor = theSelectModeColor;
                    ((TextBox)ctrl).Enabled = enableFlag;
                    ((TextBox)ctrl).ForeColor = Fontcolor;
                    ((TextBox)ctrl).Style.Add("border", "solid 1px #ccc;");
                }
                if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).BackColor = theSelectModeColor;
                    ((DropDownList)ctrl).Enabled = enableFlag;
                    ((DropDownList)ctrl).ForeColor = Fontcolor;
                    ((DropDownList)ctrl).Style.Add("border", "solid 1px #ccc;");
                }
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).BackColor = theSelectModeColor;
                    ((CheckBox)ctrl).Enabled = enableFlag;
                    ((CheckBox)ctrl).ForeColor = Fontcolor;
                }
                if (ctrl is AjaxControlToolkit.CalendarExtender)
                {
                    ((AjaxControlToolkit.CalendarExtender)ctrl).Enabled = enableFlag;
                }
            }
        }

        public static void ChangeBackColor(View theView)
        {
            //Color theEditModeColor = Color.FromArgb(0xFF, 0xFF, 0x66);
            Color theEditModeColor = Color.Honeydew;

            foreach (Control ctrl in theView.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).BackColor = theEditModeColor;
                }

                if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).BackColor = theEditModeColor;
                }
            }
        }

        public static void ChangeBackColor(Panel thePanel)
        {
            //Color theEditModeColor = Color.FromArgb(0xFF, 0xFF, 0x99);
            Color theEditModeColor = Color.Honeydew;

            foreach (Control ctrl in thePanel.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).BackColor = theEditModeColor;
                }

                if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).BackColor = theEditModeColor;
                }
            }
        }

        public static void ResetBackColor(View theView)
        {
            Color theDefaultColor = Color.White;
            Color theDefaultForeColor = Color.Black;
            foreach (Control ctrl in theView.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).BackColor = theDefaultColor;
                    ((TextBox)ctrl).ForeColor = theDefaultForeColor;
                }

                if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).BackColor = theDefaultColor;
                    ((DropDownList)ctrl).ForeColor = theDefaultForeColor;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gview"></param>
        /// <param name="columns"></param>
        public static void HideGridViewColumns(GridView gview, int[] columns)
        {
            foreach (int ctr in columns)
            {
                gview.Columns[ctr].Visible = false;
            }
        }

        public static void ShowHidePagePermissions(GridView gview, Button btn, Page thePage)
        {

            // Check for Add Button
            bool ReturnValue;
            var canAdd = CurrentLoggedOnUser.UserRolePermissions.Find(rp =>
                    rp.NavigationURL.ToUpper().Equals(Helpers.GetFullPathPageName(thePage).ToUpper()) &&
                    rp.PermissionID == BasePage.AddPermissionId);
            if (canAdd == null)
            {
                ReturnValue = false;
            }
            else
            {
                ReturnValue = true;
            }
            ShowHideCommandButton(thePage, ReturnValue);


            // Check for Edit Button
            var canEdit = CurrentLoggedOnUser.UserRolePermissions.Find(rp =>
                    rp.NavigationURL.ToUpper().Equals(Helpers.GetFullPathPageName(thePage).ToUpper()) &&
                    rp.PermissionID == BasePage.EdiPermissionId);
            if (canEdit == null)
            {
                HideGridViewEditColumns(gview);
            }


            // Check for Delete Button
            var canDelete = CurrentLoggedOnUser.UserRolePermissions.Find(rp =>
                    rp.NavigationURL.ToUpper().Equals(Helpers.GetFullPathPageName(thePage).ToUpper()) &&
                    rp.PermissionID == BasePage.DelPermissionId);
            if (canDelete == null)
            {
                HideGridViewDeleteColumns(gview);
            }




        }

        //public static void ShowHidePagePermissions(GridView gview, Page thePage)
        //{

        //    // Check for Add Button
        //    bool ReturnValue;
        //    var canAdd = CurrentLoggedOnUser.UserRolePermissions.Find(rp =>
        //            rp.NavigationURL.Equals(Helpers.GetFullPathPageName(thePage)) &&
        //            rp.PermissionID == BasePage.AddPermissionId);
        //    if (canAdd == null)
        //    {
        //        ReturnValue = false;
        //    }
        //    else
        //    {
        //        ReturnValue = true;
        //    }
        //    ShowHideCommandButton("AddNew", thePage, ReturnValue);


        //    // Check for Edit Button
        //    var canEdit = CurrentLoggedOnUser.UserRolePermissions.Find(rp =>
        //            rp.NavigationURL.Equals(Helpers.GetFullPathPageName(thePage)) &&
        //            rp.PermissionID == BasePage.EdiPermissionId);
        //    if (canEdit == null)
        //    {
        //        HideGridViewEditColumns(gview);
        //    }


        //    // Check for Delete Button
        //    var canDelete = CurrentLoggedOnUser.UserRolePermissions.Find(rp =>
        //            rp.NavigationURL.Equals(Helpers.GetFullPathPageName(thePage)) &&
        //            rp.PermissionID == BasePage.DelPermissionId);
        //    if (canDelete == null)
        //    {
        //        HideGridViewDeleteColumns(gview);
        //    }




        //}

        public static void ShowHideCommandButton(Page thePage, bool showHideFlag)
        {
            ContentPlaceHolder cph = (ContentPlaceHolder)thePage.Master.FindControl("ContentPlaceHolderMicroERP");
            Button theBtn1 = ((Button)cph.FindControl("btn_AddNew"));
            if (theBtn1 != null)
            {
                theBtn1.Visible = showHideFlag;
            }
            Button theBtn2 = ((Button)cph.FindControl("btn_Add"));
            if (theBtn2 != null)
            {
                theBtn2.Visible = showHideFlag;
            }
            Button theBtn3 = ((Button)cph.FindControl("btn_New"));
            if (theBtn3 != null)
            {
                theBtn3.Visible = showHideFlag;
            }
            cph = null;
        }

        public static void HideGridViewColumn(GridView gview, string columnName)
        {
            int TotalColumns = gview.Columns.Count;

            for (int ctr = 0; ctr < TotalColumns; ctr++)
            {
                if (gview.Columns[ctr].HeaderText.ToUpper().Equals(columnName.ToUpper()))
                {
                    gview.Columns[ctr].Visible = false;
                }

            }
        }

        public static void HideGridViewEditColumns(GridView gview)
        {
            int TotalColumns = gview.Columns.Count;

            for (int ctr = 0; ctr < TotalColumns; ctr++)
            {
                if (gview.Columns[ctr].HeaderText.ToUpper().Equals("EDIT"))
                {
                    gview.Columns[ctr].Visible = false;
                }

            }
        }

        public static void HideGridViewDeleteColumns(GridView gview)
        {
            int TotalColumns = gview.Columns.Count;

            for (int ctr = 0; ctr < TotalColumns; ctr++)
            {
                if (gview.Columns[ctr].HeaderText.Length > 2)
                {
                    if (gview.Columns[ctr].HeaderText.ToUpper().Substring(0, 3).Equals("DEL"))
                    {
                        gview.Columns[ctr].Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if SelectedItem.Text of DropDownList is MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT
        /// </summary>
        /// <param name="sender">Must be a DropDownList control</param>
        /// <returns>Returns True, if SelectedItem.Text of DropDownList is MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT</returns>
        public static bool IsDefaultItemText(DropDownList sender)
        {
            bool ReturnValue = true;

            if (sender.SelectedItem != null)
                ReturnValue = sender.SelectedItem.Text.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            else
                ReturnValue = sender.Text.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);

            return ReturnValue;
        }

        /// <summary>
        /// Clears ListItems and sets SelectedItem.Text of DropDownList to MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT
        /// </summary>
        /// <param name="sender">Must be a DropDownList control</param>
        public static void ClearListItems(DropDownList sender, bool insertItem = true)
        {
            sender.DataSource = null;
            sender.DataBind();

            sender.Items.Clear();

            if (insertItem)
            {
                sender.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        public static void SetDefaultItemText(DropDownList sender)
        {
            if (sender.Items.Count > 0)
            {
                if (sender.Items.Count == 2)
                {
                    if (sender.Items.IndexOf(sender.Items.FindByText(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT)).Equals(0))
                        sender.SelectedIndex = 1;
                    else
                        sender.SelectedIndex = 0;
                }
                else
                {
                    sender.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        public static void SetDefaultItemText(params DropDownList[] sender)
        {
            foreach (DropDownList EachSender in sender)
            {
                SetDefaultItemText(EachSender);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        public static void ClearListItems(GridView sender)
        {
            sender.DataSource = null;
            sender.DataBind();
        }

        public static void GridViewToolTips(GridViewRowEventArgs e, int editCellIndex = 0, int deleteCellIndex = 0)
        {
            if (editCellIndex > 0)
                e.Row.Cells[editCellIndex].ToolTip = "Click here to edit.";

            if (deleteCellIndex > 0)
                e.Row.Cells[deleteCellIndex].ToolTip = "Click here to delete.";
        }

        public static void GridViewOnDelete(GridViewRowEventArgs e, int cellIndex)
        {
            object DeleteButton;

            if (e.Row.Cells[cellIndex].Controls[0] is LinkButton)
            {
                DeleteButton = (LinkButton)e.Row.Cells[cellIndex].Controls[0];
                if (DeleteButton != null)
                    ((LinkButton)DeleteButton).OnClientClick = "if (!confirm('Are you sure you want to delete this record?')) return;";
            }
            else
            {
                DeleteButton = (ImageButton)e.Row.Cells[cellIndex].Controls[0];
                if (DeleteButton != null)
                    ((ImageButton)DeleteButton).OnClientClick = "if (!confirm('Are you sure you want to delete this record?')) return;";
            }
        }

        public static void GridViewOnClientMouseOver(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "GridViewMouseEvents(this, event)");
        }

        public static void GridViewOnClientMouseOut(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseout", "GridViewMouseEvents(this, event)");
        }

        public static string GetDefaultPrinter()
        {
            string ReturnValue = string.Empty;
            PrinterSettings ThePrinterSettings = new PrinterSettings();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                ThePrinterSettings.PrinterName = printer;

                if (ThePrinterSettings.IsDefaultPrinter)
                    ReturnValue = printer;
            }

            return ReturnValue;
        }

        public static string ToProper(string str)
        {
            string ReturnValue;

            CultureInfo TheCultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo TheTextInfo = TheCultureInfo.TextInfo;

            ReturnValue = TheTextInfo.ToTitleCase(str.ToLower());

            return ReturnValue;
        }

        public static int GetDropDownSelectedIndex(DropDownList ddl, string Value)
        {
            int ReturnValue = 0;

            if (!string.IsNullOrEmpty(Value))
            {
                for (int index = 0; ddl.Items.Count > index; index++)
                {
                    if (ddl.Items[index].Value == Value.ToString())
                    {
                        ReturnValue = index;
                        break;
                    }
                }
            }

            return ReturnValue;
        }

        public static int GetDropDownSelectedIndex(DropDownList ddl, int Value)
        {
            int ReturnValue = 0;

            if (!string.IsNullOrEmpty(Value.ToString()))
            {
                for (int index = 0; ddl.Items.Count > index; index++)
                {
                    if (ddl.Items[index].Value == Value.ToString())
                    {
                        ReturnValue = index;
                        break;
                    }
                }
            }

            return ReturnValue;
        }




        public static int GetRadioButtonSelectedIndex(RadioButtonList radioBtnList, string Value)
        {
            int ReturnValue = 0;

            if (!string.IsNullOrEmpty(Value))
            {
                for (int index = 0; radioBtnList.Items.Count > index; index++)
                {
                    if (radioBtnList.Items[index].Value == Value.ToString())
                    {
                        ReturnValue = index;
                        break;
                    }
                }
            }

            return ReturnValue;
        }
        #endregion
    }
}
