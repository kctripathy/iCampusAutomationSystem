using System;
using Micro.Commons;
using Micro.Framework.ReadXML;


namespace Micro.WebApplication.App_UserControls.Common
{
    public partial class UC_DateWithAge : BaseUserControl
    {
        #region Declaration

        public string DateOfBirth
        {
            set
            {
                txt_DateOfBirth.Text = value;
            }
            get
            {
                return txt_DateOfBirth.Text;
            }
        }

        public string Age
        {
            set
            {
                txt_Age.Text = value;
            }
            get
            {
                return txt_Age.Text;
            }
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                SetValidationMessages();
            }
		}

        protected void txt_DateOfBirth_TextChanged(object sender, EventArgs e)
        {
            txt_Age.Text = string.Empty;

            if (BasePage.IsValidDate(txt_DateOfBirth.Text))
            {
                txt_DateOfBirth.Text = DateTime.Parse(txt_DateOfBirth.Text).ToString(MicroConstants.DateFormat);
                txt_Age.Text = BasePage.CalculateAge(DateTime.Parse(txt_DateOfBirth.Text)).ToString();
            }
        }

        protected void txt_Age_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_DateOfBirth.Text = BasePage.CalculateDateOfBirth(txt_Age.Text).ToString(MicroConstants.DateFormat);
            }
            catch
            {
            }
        }

        #endregion

        #region Methods

        private void SetValidationMessages()
        {
            requiredFieldValidator_DateOfBirth.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_DATE_FIELD");
            requiredFieldValidator_Age.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Age");
            regularExpressionValidator_DateOfBirth.ErrorMessage = MicroConstants.REGEX_DATE;
            rangeValidator_Age.MinimumValue = "1";
            rangeValidator_Age.MaximumValue = "250";
            rangeValidator_Age.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_VALID_AGE");

            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_DateOfBirth.CssClass = theClassName;
            requiredFieldValidator_Age.CssClass = theClassName;
            regularExpressionValidator_DateOfBirth.CssClass = theClassName;
            rangeValidator_Age.CssClass = theClassName;
        }

        #endregion
    }
}