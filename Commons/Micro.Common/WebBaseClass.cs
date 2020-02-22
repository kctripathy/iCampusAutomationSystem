using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Micro.Objects;
using Micro.Objects.Administration;

namespace Micro.Commons
{
	 //public  class WebBaseClass : System.Web.UI.Page
	 //{
	 //    #region Declarations
	 //    #endregion

	 //    #region Variables
	 //    public bool AddNewMode = false;

	 //    public static Micro.Objects.Language CurrentLanguage;
	 //    public static User CurrentUser = new User();
	 //    public static MicroForm CurrentForm = new MicroForm();
	 //    public static int UserSelectedTabIndex;
	 //    public static List<Routine> RoutineList;
	 //    public static List<UserSetting> CurrentUserSettings;
	 //    public static List<RolePermission> FormPermissionList = new List<RolePermission>();
	 //    public static List<RolePermission> MenuPermissionList = new List<RolePermission>();
	 //    public static AutoCompleteStringCollection StringCollection = new AutoCompleteStringCollection();

	 //    public  string LogoNameWithPath;
	 //    public string MICRO_FONT_NAME = "Tahoma";
	 //    public float MICRO_FONT_SIZE = 9;
	 //    public Color MICRO_FONT_FORECOLOR = Color.Navy;
	 //    public Color MICRO_FONT_BACKCOLOR = Color.Transparent;
	 //    public Color MICRO_FONT_HOVER_FORECOLOR = Color.Red;
	 //    public Color MICRO_FONT_HOVER_BACKCOLOR = Color.White;

	 //    #endregion

	 //    #region Constants
	 //    // Moved to Micro.Commons.Constants (MicroConstants.cs)
	 //    #endregion

	 //    #region Enums
	 //    // All enums moved to Micro.Commons.Enums (MicroEnums.cs)
	 //    #endregion

	 //    #region Properties
	 //    public ContentAlignment ButtonImageAlignment
	 //    {
	 //        get
	 //        {
	 //            return ContentAlignment.MiddleLeft;
	 //        }
	 //    }

	 //    public ContentAlignment ButtonTextAlignment
	 //    {
	 //        get
	 //        {
	 //            return ContentAlignment.MiddleRight;
	 //        }
	 //    }
	 //    #endregion

	 //    #region Application Security
	 //    public static bool IsAuthorisedUser()
	 //    {
	 //        bool bRetVal = false;

	 //        return bRetVal;
	 //    }

	 //    //public static bool WillAllowToOperate(Enums.DataOperation operationMode)
	 //    //{
	 //    //    bool ReturnValue = false;

	 //    //    var Result = from p in FormPermissionList
	 //    //                 where(
	 //    //                        (p.PermissionID == (int)operationMode) 
	 //    //                        && 
	 //    //                        p.FormID == CurrentForm.FormID

	 //    //                 ) select p;
	 //    //    foreach(RoleFormPermission rfp in Result)
	 //    //    {
	 //    //        ReturnValue = rfp.WillPermitted;
	 //    //    }
	 //    //    return ReturnValue;
	 //    //}
	 //    #endregion

	 //    #region Common Messages
	 //    public void ShowInvalidInputMessage(string errMessage, System.Windows.Forms.Control inputControl)
	 //    {
	 //        inputControl.BackColor = System.Drawing.Color.Red;
	 //        MessageBox.Show(errMessage, MicroMessages.MSG_APPLICATION_TITLE + MicroMessages.MSG_TITLE_INVALID_INPUT, MessageBoxButtons.OK, MessageBoxIcon.Warning);
	 //        inputControl.BackColor = System.Drawing.Color.White;
	 //        inputControl.Focus();
	 //    }

	 //    public static void ShowInfoMessage(string infoMessage)
	 //    {
	 //        MessageBox.Show(infoMessage, MicroMessages.MSG_APPLICATION_TITLE + MicroMessages.MSG_TITLE_INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Information);
	 //    }

	 //    public static void ShowInfoMessage(string infoMessage, NotifyIcon n)
	 //    {
	 //        n.Icon = new Icon("info.ico");
	 //        n.ContextMenuStrip = new ContextMenuStrip();
	 //        n.ShowBalloonTip(500, MicroMessages.MSG_APPLICATION_TITLE, infoMessage, ToolTipIcon.Info);
	 //    }

	 //    public static void ShowInfoMessage(string infoMessage, NotifyIcon notify, MicroEnums.DataOperation DataOperationMode)
	 //    {
	 //        notify.Visible = true;
	 //        notify.ShowBalloonTip(500, MicroMessages.MSG_APPLICATION_TITLE, infoMessage, ToolTipIcon.Info);

	 //        // Check if the user setting permits to display message in alert window.
	 //        if (WillShowMessage(DataOperationMode).Equals(true))
	 //        {
	 //            MessageBox.Show(infoMessage, MicroMessages.MSG_APPLICATION_TITLE + MicroMessages.MSG_TITLE_INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Information);
	 //        }
	 //    }

	 //    public void ShowErrorMessage(Exception ex)
	 //    {
	 //        //MessageBox.Show(ex.Message.ToString(), MicroMessages.MSG_TITLE + MicroMessages.MSG_TITLE_EXCEPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
	 //        Log.Error(ex);
	 //    }

	 //    public void ShowErrorMessage(string theMessage)
	 //    {
	 //        //MessageBox.Show(theMessage, MicroMessages.MSG_TITLE + MicroMessages.MSG_TITLE_EXCEPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
	 //        Log.Error(theMessage);
	 //    }

	 //    public DialogResult AskQuestionGetAnswer(string infoMessage)
	 //    {
	 //        return MessageBox.Show(infoMessage, MicroMessages.MSG_APPLICATION_TITLE + MicroMessages.MSG_TITLE_INFORMATION, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
	 //    }

	 //    /// <summary>
	 //    /// Decides if it will display the message after success of a data operation
	 //    /// If there is no records in the user settings table. it returns true to display messages to users as default
	 //    /// </summary>
	 //    /// <param name="DataOperation">Add / Update / Delete Operation</param>
	 //    /// <returns>true if the message will be displayed to user or else it will return false</returns>
	 //    public static bool WillShowMessage(MicroEnums.DataOperation DataOperationMode)
	 //    {
	 //        bool ReturnValue = true;
	 //        string SettingKey = string.Empty;
	 //        if (CurrentUserSettings.Count.Equals(0))
	 //        {
	 //            // no specific settings has fetched for this user after successful login. 
	 //            // so return true to display all the message to the user by default
	 //            ReturnValue = true;
	 //        }
	 //        else
	 //        {
	 //            switch (DataOperationMode)
	 //            {
	 //                case MicroEnums.DataOperation.AddNew:
	 //                    SettingKey = MicroConstants.MICRO_KEY_WILL_SHOW_INSERT_SUCCESS_MESSAGE;
	 //                    break;
	 //                case MicroEnums.DataOperation.Edit:
	 //                    SettingKey = MicroConstants.MICRO_KEY_WILL_SHOW_UPDATE_SUCCESS_MESSAGE;
	 //                    break;
	 //                case MicroEnums.DataOperation.Delete:
	 //                    SettingKey = MicroConstants.MICRO_KEY_WILL_CONFIRM_BEFORE_DELETE;
	 //                    break;
	 //            }

	 //            // Get the specific user setting(s) for the key using LINQ
	 //            var TheUserSettings = from ust in CurrentUserSettings
	 //                                  where ust.SettingKey.Equals(SettingKey)
	 //                                  select ust;

	 //            foreach (Micro.Objects.UserSetting userSetting in TheUserSettings)
	 //            {
	 //                if (userSetting.SettingValue.Equals(MicroConstants.MICRO_VALUE_YES))
	 //                {
	 //                    ReturnValue = true;         // Yes, display the message
	 //                }
	 //                else
	 //                {
	 //                    ReturnValue = false;       // No, don't display the message to the user
	 //                }
	 //                break;
	 //            }

	 //        }
	 //        return ReturnValue;
	 //    }

	 //    /// <summary>
	 //    /// This procedure will prepare a message depending upon the data operation and will alert to the end user.
	 //    /// </summary>
	 //    /// <param name="procReturnValue">The return value of the data operation done by stored procedure. a positive value is for success, -1 for duplicate and -2 for failure</param>
	 //    /// <param name="DataOperationMode">Data operation mode, if we display the message after ADD or EDIT </param>
	 //    public void ShowDataOperationResultMessage(int procReturnValue, MicroEnums.DataOperation DataOperationMode)
	 //    {
	 //        string Operation = string.Empty;
	 //        if (DataOperationMode == MicroEnums.DataOperation.AddNew)
	 //        {
	 //            Operation = "Inserted ";
	 //        }
	 //        else if (DataOperationMode == MicroEnums.DataOperation.Edit)
	 //        {
	 //            Operation = "Updated ";
	 //        }


	 //        if (procReturnValue > (int)MicroEnums.DataOperationResult.Success) // MicroConstants.MICRO_DATA_OPERATION_OK_SUCCESS) // Success
	 //        {
	 //            // Check if the user setting permits to display message.
	 //            if (WillShowMessage(DataOperationMode).Equals(true))
	 //            {
	 //                ShowInfoMessage("Record " + Operation + " Successfully.");
	 //            }
	 //        }
	 //        if (procReturnValue.Equals((int)MicroEnums.DataOperationResult.Failure)) //MicroConstants.MICRO_DATA_OPERATION_KO_FAILURE))
	 //        {
	 //            ShowInfoMessage("Failed to " + (AddNewMode == true ? "insert" : "update") + " the record.");
	 //        }
	 //        if (procReturnValue.Equals((int)MicroEnums.DataOperationResult.Duplicate)) //MicroConstants.MICRO_DATA_OPERATION_DUPLICATE))
	 //        {
	 //            ShowInfoMessage("Duplicate! This record already exists in database.");
	 //        }
	 //    }

	 //    public void ShowDataOperationResultMessage(int procReturnValue, MicroEnums.DataOperation DataOperationMode, NotifyIcon notifyResult)
	 //    {
	 //        string Operation = string.Empty;

	 //        if (DataOperationMode == MicroEnums.DataOperation.AddNew)
	 //        {
	 //            Operation = "Inserted";
	 //        }
	 //        else if (DataOperationMode == MicroEnums.DataOperation.Edit)
	 //        {
	 //            Operation = "Updated";
	 //        }
	 //        else if (DataOperationMode == MicroEnums.DataOperation.Delete)
	 //        {
	 //            Operation = "Deleted";
	 //        }

	 //        if (procReturnValue > (int)MicroEnums.DataOperationResult.Success) // Success
	 //        {
	 //            if (DataOperationMode == MicroEnums.DataOperation.AddNew)
	 //            {
	 //                ShowInfoMessage(MicroEnums.DataOperationResult.Success.GetStringValue().Replace("[REPLACE_STRING]", "inserted"), notifyResult, DataOperationMode);
	 //            }
	 //            if (DataOperationMode == MicroEnums.DataOperation.Edit)
	 //            {
	 //                ShowInfoMessage(MicroEnums.DataOperationResult.Success.GetStringValue().Replace("[REPLACE_STRING]", "updated"), notifyResult, DataOperationMode);
	 //            }
	 //        }
	 //        if (procReturnValue.Equals((int)MicroEnums.DataOperationResult.Failure))
	 //        {
	 //            ShowInfoMessage(MicroEnums.DataOperationResult.Failure.GetStringValue(), notifyResult, DataOperationMode);
	 //        }
	 //        if (procReturnValue.Equals((int)MicroEnums.DataOperationResult.Duplicate))
	 //        {
	 //            ShowInfoMessage(MicroEnums.DataOperationResult.Duplicate.GetStringValue(), notifyResult, DataOperationMode);
	 //        }
	 //    }

	 //    #endregion

	 //    #region User Interface Design Mode
	 //    //public void ChangeLabelColor(Label theLabel)
	 //    //{
	 //    //    theLabel.ForeColor = MICRO_FONT_HOVER_FORECOLOR;
	 //    //    theLabel.BackColor = MICRO_FONT_HOVER_BACKCOLOR;
	 //    //    theLabel.Font = new Font(MICRO_FONT_NAME, MICRO_FONT_SIZE);
	 //    //}

	 //    //public void ChangeLabelColor(Label theLabel, Panel thePanel)
	 //    //{
	 //    //    theLabel.Font = new Font(MICRO_FONT_NAME, MICRO_FONT_SIZE);
	 //    //    foreach (Control ctrl in thePanel.Controls)
	 //    //    {
	 //    //        ctrl.BackColor = Color.Transparent;
	 //    //        ctrl.ForeColor = MICRO_FONT_FORECOLOR;
	 //    //    }
	 //    //    theLabel.ForeColor = MICRO_FONT_HOVER_FORECOLOR; // Color.DarkGray;
	 //    //    theLabel.BackColor = MICRO_FONT_HOVER_BACKCOLOR;
	 //    //}

	 //    //public void ResetLabelColor(Label theLabel)
	 //    //{
	 //    //    if (theLabel.BackColor != MICRO_FONT_BACKCOLOR)
	 //    //    {
	 //    //        theLabel.ForeColor = MICRO_FONT_FORECOLOR;
	 //    //        theLabel.BackColor = MICRO_FONT_BACKCOLOR;
	 //    //    }
	 //    //    theLabel.Font = new Font(MICRO_FONT_NAME, MICRO_FONT_SIZE, FontStyle.Regular);

	 //    //    //theLabel.ForeColor = MICRO_FONT_FORECOLOR;
	 //    //    //theLabel.BackColor = Color.Transparent;
	 //    //    //theLabel.Font = new Font ( MICRO_FONT_NAME, MICRO_FONT_SIZE );

	 //    //}

	 //    //public void SetFont(Form theForm)
	 //    //{
	 //    //    foreach (Control ctrl in theForm.Controls)
	 //    //    {
	 //    //        ctrl.ForeColor = MICRO_FONT_FORECOLOR;
	 //    //        ctrl.Font = new Font(MICRO_FONT_NAME, MICRO_FONT_SIZE);
	 //    //    }
	 //    //}

	 //    public void SelectLebelMenus(System.Windows.Forms.Control parentControl, System.Windows.Forms.Label menuLabel)
	 //    {
	 //        string LabelName = menuLabel.Name.ToString();

	 //        foreach (System.Windows.Forms.Label MyLabel in parentControl.Controls)
	 //        {
	 //            if (MyLabel.Name.Equals(LabelName))
	 //            {
	 //                MyLabel.BackColor = System.Drawing.Color.Turquoise;
	 //            }
	 //            else
	 //            {
	 //                MyLabel.BackColor = System.Drawing.Color.Transparent;
	 //            }
	 //        }
	 //    }
	 //    #endregion

	 //    #region Methods & Implementation
	 //    //public bool IsLeftBlank(params System.Windows.Forms.Control[] CurrentControl)
	 //    //{
	 //    //    bool ReturnValue = true;
	 //    //    foreach (System.Windows.Forms.Control MyControl in CurrentControl)
	 //    //    {
	 //    //        if (MyControl is TextBox || MyControl is ComboBox)
	 //    //        {
	 //    //            if (string.IsNullOrWhiteSpace(MyControl.Text.ToString()))
	 //    //            {
	 //    //                string FieldName = (MyControl.Tag == null ? MyControl.Name.ToString().Replace("txt_", "").ToString() : MyControl.Tag.ToString());
	 //    //                ShowInvalidInputMessage(FieldName + MicroMessages.MSG_ERR_FIELD_LEFT_BLANK, MyControl);
	 //    //                MicroMessages.ErrorMessages.AppendLine("» " + FieldName + MicroMessages.MSG_ERR_FIELD_LEFT_BLANK);
	 //    //                MyControl.Focus();
	 //    //                ReturnValue = false;
	 //    //            }
	 //    //        }
	 //    //    }
	 //    //    return ReturnValue;
	 //    //}

	 //    //public bool IsEMailID(string eMailID)
	 //    //{
	 //    //    bool ReturnValue = true;

	 //    //    Regex EmailExpression = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

	 //    //    if (!string.IsNullOrEmpty(eMailID))
	 //    //    {
	 //    //        ReturnValue = EmailExpression.IsMatch(eMailID);
	 //    //    }

	 //    //    return ReturnValue;
	 //    //}

	 //    //public bool ValidateEMailID(System.Windows.Forms.Control parentTextBox)
	 //    //{
	 //    //    bool ReturnValue = true;

	 //    //    if (!IsEMailID(parentTextBox.Text))
	 //    //    {
	 //    //        MessageBox.Show("Enter a valid email id");
	 //    //        parentTextBox.Focus();
	 //    //        ReturnValue = false;
	 //    //        //TODO: Hardcode
	 //    //    }

	 //    //    return ReturnValue;
	 //    //}
	 //    #endregion

	 //    #region Command Button and control Operations
	 //    //public void EnableDisableControls(Panel panelUserInput, Panel panelButtons, bool enableFlag, MicroEnums.DataOperation operationMode)
	 //    //{
	 //    //    panelUserInput.Enabled = !enableFlag;
	 //    //    foreach (Control ctrl in panelButtons.Controls)
	 //    //    {
	 //    //        if (ctrl is Button)
	 //    //        {
	 //    //            if (ctrl.Text.Equals(MicroEnums.CommandButton.Save.GetStringValue()) || ctrl.Text.Equals(MicroEnums.CommandButton.Update.GetStringValue()))
	 //    //            {
	 //    //                ctrl.Enabled = !enableFlag;
	 //    //                if (operationMode == MicroEnums.DataOperation.AddNew)
	 //    //                {
	 //    //                    ctrl.Text = MicroEnums.CommandButton.Save.GetStringValue();
	 //    //                }
	 //    //                else
	 //    //                {
	 //    //                    ctrl.Text = MicroEnums.CommandButton.Update.GetStringValue();
	 //    //                }

	 //    //            }
	 //    //            else if (ctrl.Text.Equals(MicroEnums.CommandButton.Exit.GetStringValue()))
	 //    //            {
	 //    //                ctrl.Text = MicroEnums.CommandButton.Cancel.GetStringValue();
	 //    //                ctrl.Enabled = true;
	 //    //            }
	 //    //            else if (ctrl.Text.Equals(MicroEnums.CommandButton.Cancel.GetStringValue()))
	 //    //            {
	 //    //                ctrl.Text = MicroEnums.CommandButton.Exit.GetStringValue();
	 //    //                ctrl.Enabled = true;
	 //    //            }
	 //    //            else
	 //    //            {
	 //    //                ctrl.Enabled = enableFlag;
	 //    //            }
	 //    //        }
	 //    //    }
	 //    //}

	 //    //public void AssignCommandButtonDefaults(Button btnAdd, Button btnEdit, Button btnDelete, Button btnSearch, Button btnSave, Button btnExit, ImageList imgList)
	 //    //{

	 //    //    btnAdd.Text = MicroEnums.CommandButton.AddNew.GetStringValue(); //BTN_CAPTION_ADD;
	 //    //    btnAdd.Image = imgList.Images[(int)MicroEnums.CommandButton.AddNew];
	 //    //    btnAdd.ImageAlign = ButtonImageAlignment;
	 //    //    btnAdd.TextAlign = ButtonTextAlignment;
	 //    //    //btnAdd.Click += new System.EventHandler(btn_Add_Click);

	 //    //    btnEdit.Text = MicroEnums.CommandButton.Edit.GetStringValue(); //BTN_CAPTION_EDIT;
	 //    //    btnEdit.Image = imgList.Images[(int)MicroEnums.CommandButton.Edit];
	 //    //    btnEdit.ImageAlign = ButtonImageAlignment;
	 //    //    btnEdit.TextAlign = ButtonTextAlignment;
	 //    //    //btnEdit.Click += new System.EventHandler(btn_Edit_Click);

	 //    //    btnDelete.Text = MicroEnums.CommandButton.Delete.GetStringValue(); //BTN_CAPTION_DELETE;
	 //    //    btnDelete.Image = imgList.Images[(int)MicroEnums.CommandButton.Delete];
	 //    //    btnDelete.ImageAlign = ButtonImageAlignment;
	 //    //    btnDelete.TextAlign = ButtonTextAlignment;
	 //    //    //btnDelete.Click += new System.EventHandler(btn_Delete_Click);

	 //    //    btnSave.Text = MicroEnums.CommandButton.Save.GetStringValue(); //BTN_CAPTION_SAVE;
	 //    //    btnSave.Image = imgList.Images[(int)MicroEnums.CommandButton.Save];
	 //    //    btnSave.ImageAlign = ButtonImageAlignment;
	 //    //    btnSave.TextAlign = ButtonTextAlignment;
	 //    //    //btnSave.Click += new System.EventHandler(btn_Save_Click);

	 //    //    btnExit.Text = MicroEnums.CommandButton.Exit.GetStringValue(); //BTN_CAPTION_EXIT;
	 //    //    btnExit.Image = imgList.Images[(int)MicroEnums.CommandButton.Exit];
	 //    //    btnExit.ImageAlign = ButtonImageAlignment;
	 //    //    btnExit.TextAlign = ButtonTextAlignment;
	 //    //    //btnExit.Click += new System.EventHandler(btn_Exit_Click);

	 //    //    btnSearch.Text = MicroEnums.CommandButton.Search.GetStringValue(); //BTN_CAPTION_SEARCH;
	 //    //    btnSearch.Image = imgList.Images[(int)MicroEnums.CommandButton.Search];
	 //    //    btnSearch.ImageAlign = ButtonImageAlignment;
	 //    //    btnSearch.TextAlign = ButtonTextAlignment;
	 //    //    //btnSearch.Click += new System.EventHandler(btn_Search_Click);
	 //    //}

	 //    ///// <summary>
	 //    ///// Enables and Disables the command buttons of the form
	 //    ///// </summary>
	 //    ///// <param name="panelButtons">The name of the panel where the command buttons locates</param>
	 //    ///// <param name="enableFlag">the flag that toggles the add new & save button </param>
	 //    ///// <param name="operationMode">Which mode of operation is currently being processed</param>
	 //    //public void EnableDisableCommandButtons(Panel panelButtons, bool enableFlag, MicroEnums.DataOperation operationMode, ImageList imgList)
	 //    //{

	 //    //    foreach (Control ctrl in panelButtons.Controls)
	 //    //    {
	 //    //        if (ctrl is Button)
	 //    //        {
	 //    //            if (ctrl.Text.Equals(MicroEnums.CommandButton.Save.GetStringValue()) || ctrl.Text.Equals(MicroEnums.CommandButton.Update.GetStringValue()))
	 //    //            {
	 //    //                ctrl.Enabled = !enableFlag;
	 //    //                if (operationMode == MicroEnums.DataOperation.AddNew)
	 //    //                {
	 //    //                    ctrl.Text = MicroEnums.CommandButton.Save.GetStringValue();
	 //    //                    ((Button)ctrl).Image = imgList.Images[(int)MicroEnums.CommandButton.Save];
	 //    //                }
	 //    //                else
	 //    //                {
	 //    //                    ctrl.Text = MicroEnums.CommandButton.Update.GetStringValue();
	 //    //                    ((Button)ctrl).Image = imgList.Images[(int)MicroEnums.CommandButton.Update];
	 //    //                }

	 //    //            }
	 //    //            else if (ctrl.Text.Equals(MicroEnums.CommandButton.Exit.GetStringValue()))
	 //    //            {
	 //    //                ctrl.Enabled = true;
	 //    //                ctrl.Text = MicroEnums.CommandButton.Cancel.GetStringValue();
	 //    //                ((Button)ctrl).Image = imgList.Images[(int)MicroEnums.CommandButton.Cancel];
	 //    //            }
	 //    //            else if (ctrl.Text.Equals(MicroEnums.CommandButton.Cancel.GetStringValue()))
	 //    //            {
	 //    //                ctrl.Enabled = true;
	 //    //                ctrl.Text = MicroEnums.CommandButton.Exit.GetStringValue();
	 //    //                ((Button)ctrl).Image = imgList.Images[(int)MicroEnums.CommandButton.Exit];
	 //    //            }
	 //    //            else
	 //    //            {
	 //    //                ctrl.Enabled = enableFlag;
	 //    //            }
	 //    //        }
	 //    //    }
	 //    //}

	 //    /// <summary>
	 //    /// Enables and Disables the command buttons of the form
	 //    /// </summary>
	 //    /// <param name="panelButtons">The name of the panel where the command buttons locates</param>
	 //    /// <param name="enableFlag">the flag that toggles the add new & save button </param>
	 //    /// <param name="operationMode">Which mode of operation is currently being processed</param>
	 //    //public void EnableDisableCommandButtons(Panel panelButtons, bool enableFlag, MicroEnums.DataOperation operationMode)
	 //    //{

	 //    //    foreach (Control ctrl in panelButtons.Controls)
	 //    //    {
	 //    //        if (ctrl is Button)
	 //    //        {
	 //    //            if (ctrl.Text.Equals(MicroEnums.CommandButton.Save.GetStringValue()) || ctrl.Text.Equals(MicroEnums.CommandButton.Update.GetStringValue()))
	 //    //            {
	 //    //                ctrl.Enabled = !enableFlag;
	 //    //                //ctrl.Visible = !enableFlag;
	 //    //                if (operationMode == MicroEnums.DataOperation.AddNew)
	 //    //                {
	 //    //                    ctrl.Text = MicroEnums.CommandButton.Save.GetStringValue();
	 //    //                }
	 //    //                else
	 //    //                {
	 //    //                    ctrl.Text = MicroEnums.CommandButton.Update.GetStringValue();
	 //    //                }

	 //    //            }
	 //    //            else if (ctrl.Text.Equals(MicroEnums.CommandButton.Exit.GetStringValue()))
	 //    //            {
	 //    //                ctrl.Text = MicroEnums.CommandButton.Cancel.GetStringValue();
	 //    //                ctrl.Enabled = true;
	 //    //            }
	 //    //            else if (ctrl.Text.Equals(MicroEnums.CommandButton.Cancel.GetStringValue()))
	 //    //            {
	 //    //                ctrl.Text = MicroEnums.CommandButton.Exit.GetStringValue();
	 //    //                ctrl.Enabled = true;
	 //    //            }
	 //    //            else
	 //    //            {
	 //    //                ctrl.Enabled = enableFlag;
	 //    //            }
	 //    //        }
	 //    //    }
	 //    //}

	 //    ///// <summary>
	 //    ///// Enables and Disables the command button group being used for data operation
	 //    ///// </summary>
	 //    ///// <param name="panelButtons"></param>
	 //    ///// <param name="enableFlag"></param>
	 //    ///// <param name="operationMode"></param>
	 //    ///// <param name="theForm"></param>
	 //    //public void EnableDisableCommandButtons(Panel panelButtons, bool enableFlag, DataOperation operationMode, Form theForm)
	 //    //{

	 //    //    foreach(Control ctrl in panelButtons.Controls)
	 //    //    {
	 //    //        if(ctrl is Button)
	 //    //        {
	 //    //            if(ctrl.Text.Equals(BTN_CAPTION_SAVE) || ctrl.Text.Equals(BTN_CAPTION_UPDATE))
	 //    //            {
	 //    //                ctrl.Enabled = !enableFlag;
	 //    //                if(operationMode == DataOperation.AddNew)
	 //    //                {
	 //    //                    //theForm.Text = (string)DataOperation.AddNew.ToString();
	 //    //                    ctrl.Text = BTN_CAPTION_SAVE;
	 //    //                }
	 //    //                else
	 //    //                {
	 //    //                    //theForm.Text = (string)DataOperation.Edit.ToString();
	 //    //                    ctrl.Text = BTN_CAPTION_UPDATE;
	 //    //                }

	 //    //            }
	 //    //            else if(ctrl.Text.Equals(BTN_CAPTION_EXIT))
	 //    //            {
	 //    //                ctrl.Text = BTN_CAPTION_CANCEL;
	 //    //                ctrl.Enabled = true;

	 //    //            }
	 //    //            else if(ctrl.Text.Equals(BTN_CAPTION_CANCEL))
	 //    //            {
	 //    //                ctrl.Text = BTN_CAPTION_EXIT;
	 //    //                ctrl.Enabled = true;
	 //    //            }
	 //    //            else
	 //    //            {
	 //    //                ctrl.Enabled = enableFlag;
	 //    //            }
	 //    //        }
	 //    //    }
	 //    //}
	 //    #endregion

	 //    #region Error Handling Methods

	 //    /// <summary>
	 //    /// Removes the name of the routine from the stack/list using LIFO (Last in First Out)
	 //    /// </summary>
	 //    public void PopName()
	 //    {
	 //        RoutineList.RemoveAt(RoutineList.Count - 1);
	 //    }

	 //    /// <summary>
	 //    /// Push the name of the routine to the list/stack
	 //    /// </summary>
	 //    /// <param name="formName"></param>
	 //    /// <param name="methodName"></param>
	 //    public static void PushName(string formName, string methodName = "")
	 //    {
	 //        Routine r = new Routine(formName, methodName);
	 //        RoutineList.Add(r);
	 //    }

	 //    public static void PushName()
	 //    {
	 //        ///string formName = "";
	 //        //string Context = this.GetType().FullName.ToString();
	 //        // Routine r = new Routine(formName, methodName);
	 //        //RoutineList.Add(r);
	 //    }
	 //    /// <summary>
	 //    /// This routines will be called from every catch block
	 //    /// It will collect the exception and form the error message accordingly and will 
	 //    /// display the created message to the user depending upon the second parameter 'skipUserPrompt'
	 //    /// </summary>
	 //    /// <param name="theException">The exception details</param>
	 //    /// <param name="skipUserPrompt">Optional parameter, true if you don't want to display the message to the user</param>
	 //    public void CallGlobalErrorRoutine(Exception theException, bool skipUserPrompt = false)
	 //    {
	 //        try
	 //        {
	 //            string FormName, RoutineName, ErrorDescription;
	 //            StringBuilder TheErrorMessage = new StringBuilder();

	 //            // Display the Form Name at the messasge where the error occured
	 //            FormName = RoutineList[RoutineList.Count - 1].FormName.ToString();
	 //            TheErrorMessage.Append("An Error occurred in\t:- ");
	 //            TheErrorMessage.Append(FormName);


	 //            // Display the name of the Routine where the error occured
	 //            // Check if there is something in the list or call stack
	 //            RoutineName = RoutineList[RoutineList.Count - 1].MethodName.ToString();
	 //            if (!RoutineName.Equals(string.Empty))
	 //            {
	 //                TheErrorMessage.Append("." + RoutineName + " ()");
	 //            }

	 //            // Error description from the  Exception being received as parameter
	 //            ErrorDescription = theException.Message.ToString();
	 //            TheErrorMessage.Append("\n\nError Description\t:- " + ErrorDescription);

	 //            // Also show the source of the error and inner exception, if exists
	 //            if (!(theException.InnerException == null))
	 //            {
	 //                TheErrorMessage.Append("\n\nSource \t\t:- " + theException.InnerException.Source.ToString());
	 //                TheErrorMessage.Append("\nInner Message\t:- " + theException.InnerException.Message.ToString());
	 //            }
	 //            TheErrorMessage.Append("");

	 //            // Show / Alert the error message
	 //            ShowErrorMessage(TheErrorMessage.ToString());
	 //            //this.UseWaitCursor = false;
	 //        }
	 //        catch (Exception ex)
	 //        {
	 //            ShowErrorMessage(ex.ToString());
	 //        }

	 //    }

	 //    #endregion

	 //    #region Form Handling Methods


	 //    public void ShowFormDialog(Form f, int recordId = 0)
	 //    {
	 //        f.Text = (recordId == 0 ? "Add New " : "Edit ") + f.Text;
	 //        f.ShowInTaskbar = false;
	 //        f.MaximizeBox = false;
	 //        f.FormBorderStyle = FormBorderStyle.FixedToolWindow;
	 //        f.StartPosition = FormStartPosition.CenterScreen;
	 //        f.ShowDialog();
	 //        f.Dispose();
	 //        System.GC.Collect();
	 //    }

	 //    private Form GetFormByName(Form f, string formName)
	 //    {
	 //        System.Reflection.Assembly FormAssembly = System.Reflection.Assembly.GetExecutingAssembly();
	 //        f = (Form)FormAssembly.CreateInstance(formName);
	 //        return f;
	 //    }

	 //    public Form GetFormByName(string formName)
	 //    {
	 //        Form childForm;
	 //        System.Reflection.Assembly FormAssembly = System.Reflection.Assembly.GetExecutingAssembly();
	 //        childForm = (Form)FormAssembly.CreateInstance(formName);
	 //        return childForm;
	 //    }
	 //    #endregion

	 //    #region Grid Handling Methods
	 //    public void SetGridViewStandard(DataGridView gridView)
	 //    {
	 //        gridView.ForeColor = Color.Navy;
	 //        gridView.BackgroundColor = Color.Silver;
	 //        gridView.RowHeadersVisible = false;
	 //        gridView.MultiSelect = false;
	 //        gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
	 //        //gridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
	 //    }

	 //    public int GetSelectedRecordID(DataGridView gridView)
	 //    {
	 //        int RecordID = -1;
	 //        foreach (DataGridViewRow dr in gridView.SelectedRows)
	 //        {
	 //            RecordID = int.Parse(dr.Cells[0].Value.ToString());
	 //        }
	 //        return RecordID;
	 //    }
	 //    #endregion

	 //    #region DataOperation Event Handlers
	 //    private void btn_Add_Click(object sender, EventArgs e)
	 //    {
	 //        try
	 //        {
	 //            //PushName(this.Name, System.Reflection.MethodBase.GetCurrentMethod().Name);


	 //        }
	 //        catch (Exception ex)
	 //        {
	 //            CallGlobalErrorRoutine(ex);
	 //        }
	 //        finally
	 //        {
	 //            PopName();
	 //        }
	 //    }

	 //    private void btn_Edit_Click(object sender, EventArgs e)
	 //    {
	 //        try
	 //        {
	 //            //PushName(this.Name, System.Reflection.MethodBase.GetCurrentMethod().Name);


	 //        }
	 //        catch (Exception ex)
	 //        {
	 //            CallGlobalErrorRoutine(ex);
	 //        }
	 //        finally
	 //        {
	 //            PopName();
	 //        }
	 //    }

	 //    private void btn_Delete_Click(object sender, EventArgs e)
	 //    {
	 //        try
	 //        {
	 //            //PushName(this.Name, System.Reflection.MethodBase.GetCurrentMethod().Name);


	 //        }
	 //        catch (Exception ex)
	 //        {
	 //            CallGlobalErrorRoutine(ex);
	 //        }
	 //        finally
	 //        {
	 //            PopName();
	 //        }
	 //    }

	 //    private void btn_Save_Click(object sender, EventArgs e)
	 //    {
	 //        try
	 //        {
	 //            //PushName(this.Name, System.Reflection.MethodBase.GetCurrentMethod().Name);


	 //        }
	 //        catch (Exception ex)
	 //        {
	 //            CallGlobalErrorRoutine(ex);
	 //        }
	 //        finally
	 //        {
	 //            PopName();
	 //        }
	 //    }

	 //    private void btn_Exit_Click(object sender, EventArgs e)
	 //    {
	 //        try
	 //        {
	 //            //PushName(this.Name, System.Reflection.MethodBase.GetCurrentMethod().Name);


	 //        }
	 //        catch (Exception ex)
	 //        {
	 //            CallGlobalErrorRoutine(ex);
	 //        }
	 //        finally
	 //        {
	 //            PopName();
	 //        }
	 //    }

	 //    private void btn_Search_Click(object sender, EventArgs e)
	 //    {
	 //        try
	 //        {
	 //            //PushName(this.Name, System.Reflection.MethodBase.GetCurrentMethod().Name);


	 //        }
	 //        catch (Exception ex)
	 //        {
	 //            CallGlobalErrorRoutine(ex);
	 //        }
	 //        finally
	 //        {
	 //            PopName();
	 //        }
	 //    }
	 //    #endregion

	 //    #region ComboBox
	 //    private int GetComboBoxIndex(string selectedValue, ComboBox cmbBox)
	 //    {
	 //        //int Counter;
	 //        //for(Counter = 0;Counter <= cmbBox.Items.Count;Counter++)
	 //        //{
	 //        //    if(((Employee)(cmbBox.Items[Counter])).Id.ToString() == selectedValue)
	 //        //    {
	 //        //        break;
	 //        //    }
	 //        //}
	 //        //return Counter;
	 //        return 0;
	 //    }

	 //    public static int GetComboBoxSelectedIndex(string countryName, List<Country> countryList)
	 //    {
	 //        int ReturnValue = -1;

	 //        foreach (Country c in countryList)
	 //        {
	 //            ReturnValue++;
	 //            if (c.CountryName.ToString().ToUpper().Equals(countryName.ToUpper()))
	 //            {
	 //                break;
	 //            }
	 //        }

	 //        return ReturnValue;
	 //    }

	 //    public static int GetComboBoxSelectedIndexbyId(int countryCode, List<Country> countryList)
	 //    {
	 //        int ReturnValue = -1;

	 //        foreach (Country c in countryList)
	 //        {
	 //            ReturnValue++;
	 //            if (c.CountryID == countryCode)
	 //            {
	 //                break;
	 //            }
	 //        }

	 //        return ReturnValue;
	 //    }

	 //    public static int GetStateComboSelectedIndex(string stateName, List<State> stateList)
	 //    {
	 //        int ReturnValue = -1;

	 //        foreach (State s in stateList)
	 //        {
	 //            ReturnValue++;
	 //            if (s.StateName.ToString().ToUpper().Equals(stateName.ToUpper()))
	 //            {
	 //                break;
	 //            }
	 //        }

	 //        return ReturnValue;
	 //    }

	 //    public static int GetStateComboSelectedIndexbyId(int stateCode, List<State> stateList)
	 //    {
	 //        int ReturnValue = -1;

	 //        foreach (State s in stateList)
	 //        {
	 //            ReturnValue++;
	 //            if (s.StateID == stateCode)
	 //            {
	 //                break;
	 //            }
	 //        }

	 //        return ReturnValue;
	 //    }

	 //    public static int GetDistrictComboSelectedIndex(string districtName, List<District> districtList)
	 //    {
	 //        int ReturnValue = -1;

	 //        foreach (District s in districtList)
	 //        {
	 //            ReturnValue++;
	 //            if (s.CountryName.ToString().ToUpper().Equals(districtName.ToUpper()))
	 //            {
	 //                break;
	 //            }
	 //        }

	 //        return ReturnValue;
	 //    }

	 //    public static int GetDistrictComboSelectedIndexbyId(int districtCode, List<District> districtList)
	 //    {
	 //        int ReturnValue = -1;

	 //        foreach (District s in districtList)
	 //        {
	 //            ReturnValue++;
	 //            if (s.DistrictID == districtCode)
	 //            {
	 //                break;
	 //            }
	 //        }

	 //        return ReturnValue;
	 //    }
	 //    #endregion

	 //    /// <summary>
	 //    /// Reads image from Disk and converts the same to byte[] i.e., VarBinary in SQL
	 //    /// </summary>
	 //    /// <param name="imagePath">A string value specifying image path.</param>
	 //    /// <returns>Byte[] i.e., VarBinary in SQL</returns>
	 //    //public byte[] WriteImageToSQL(string imagePath)
	 //    //{
	 //    //    byte[] ImageData = null;

	 //    //    try
	 //    //    {
	 //    //        PushName(this.Name, MethodBase.GetCurrentMethod().Name);

	 //    //        if (string.IsNullOrEmpty(imagePath))
	 //    //        {
	 //    //            //TODO: Remove hard code
	 //    //            MessageBox.Show("You don't have any image selected. Browse any Image", "", MessageBoxButtons.OK);
	 //    //        }
	 //    //        else
	 //    //        {
	 //    //            long FileLengthInBytes = new FileInfo(imagePath).Length;

	 //    //            FileStream ThisFileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
	 //    //            BinaryReader TheBinaryReader = new BinaryReader(ThisFileStream);

	 //    //            ImageData = TheBinaryReader.ReadBytes((int)FileLengthInBytes);
	 //    //        }
	 //    //    }
	 //    //    catch (Exception ex)
	 //    //    {
	 //    //        CallGlobalErrorRoutine(ex);
	 //    //    }
	 //    //    finally
	 //    //    {
	 //    //        PopName();
	 //    //    }

	 //    //    return ImageData;
	 //    //}

	 //    /// <summary>
	 //    /// Reads any Image and converts the same to byte[] i.e., VarBinary in SQL
	 //    /// </summary>
	 //    /// <param name="image">A value specifying System.Drawing.Image.</param>
	 //    /// <returns>Byte[] i.e., VarBinary in SQL</returns>
	 //    //public byte[] WriteImageToSQL(Image image)
	 //    //{
	 //    //    byte[] ImageData = null;

	 //    //    try
	 //    //    {
	 //    //        PushName(this.Name, MethodBase.GetCurrentMethod().Name);

	 //    //        MemoryStream ImageStream = new MemoryStream();
	 //    //        image.Save(ImageStream, ImageFormat.Jpeg);

	 //    //        ImageData = ImageStream.ToArray();
	 //    //    }
	 //    //    catch (Exception ex)
	 //    //    {
	 //    //        CallGlobalErrorRoutine(ex);
	 //    //    }
	 //    //    finally
	 //    //    {
	 //    //        PopName();
	 //    //    }

	 //    //    return ImageData;
	 //    //}

	 //    /// <summary>
	 //    /// Reads image from VarBinary in SQL and converts the same to Image 
	 //    /// </summary>
	 //    /// <param name="imageStreamValue">A byte[] specifying image value stored in SQL.</param>
	 //    /// <returns>Returns an Image</returns>
	 //    //public Image ReadImageFromSQL(byte[] imageStreamValue)
	 //    //{
	 //    //    Image TheImage = null;

	 //    //    try
	 //    //    {
	 //    //        PushName(this.Name, MethodBase.GetCurrentMethod().Name);

	 //    //        byte[] ImageData = imageStreamValue;

	 //    //        MemoryStream TheMemoryStream = new MemoryStream(ImageData, 0, ImageData.Length);
	 //    //        TheMemoryStream.Write(ImageData, 0, ImageData.Length);

	 //    //        TheImage = Image.FromStream(TheMemoryStream, true);
	 //    //    }
	 //    //    catch (Exception ex)
	 //    //    {
	 //    //        CallGlobalErrorRoutine(ex);
	 //    //    }
	 //    //    finally
	 //    //    {
	 //    //        PopName();
	 //    //    }

	 //    //    return TheImage;
	 //    //}

	 //    /// <summary>
	 //    /// Opens File Dialog Box.
	 //    /// </summary>
	 //    /// <returns>Returns image path.</returns>
	 //    public string BrowseImage()
	 //    {
	 //        string FilePath = string.Empty;

	 //        OpenFileDialog TheOpenFileDialog = new OpenFileDialog();

	 //        TheOpenFileDialog.Filter = "Windows Bitmap|*.bmp|JPEG Format|*.jpg";
	 //        TheOpenFileDialog.Title = "Select your profile image...";

	 //        DialogResult TheDialogResult = TheOpenFileDialog.ShowDialog();

	 //        if (TheDialogResult == DialogResult.OK)
	 //        {
	 //            FilePath = TheOpenFileDialog.FileName;
	 //        }

	 //        return FilePath;
	 //    }
	 //}
}
