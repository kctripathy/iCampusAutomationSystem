using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Framework.ReadXML;

namespace Micro.WebApplication.MicroERP.FINANCE
{
    /// <summary>
    /// Remittance Page
    /// </summary>
    /// <author> Syed Ameer </author>
    /// <date> 20-Jan-2012 </date>

    public partial class AccountRemittances : BasePage
    {
        #region Declaration
        public static class PageVariables
        {
            public static AccountRemittances ThisRemittance;
            public static List<AccountRemittances> RemittanceList;
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            ctrl_Search.OnButtonClick += ctrl_Search_ButtonClick;

            if (!IsPostBack)
            {

                multiView_Remittances.SetActiveView(view_InputControls);
            }
        }

        protected void radio_RemittanceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radio_RemittanceType.SelectedItem.Text.Equals(MicroEnums.RemittanceType.Receipt.GetStringValue()))
            {
                ul_RemittanceReceipt.Visible = true;
                ul_RemittancePayments.Visible = false;
            }
            else
            {
                ul_RemittanceReceipt.Visible = false;
                ul_RemittancePayments.Visible = true;
            }
        }

        protected void btn_RemittancePaidTo_Click(object sender, EventArgs e)
        {

        }

        protected void radioRemittanceMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddl_BankBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gview_Remittances_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gview_Remittances_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        private void ctrl_Search_ButtonClick(object sender, System.EventArgs e)
        {

        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void btn_New_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {

        }

        protected void btn_View_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methods & Implementation
        private void SetValidationMessages()
        {
            requiredFieldValidator_BankBranch.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_BankAccount.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;

            regularExpressionValidator_TransactionDate.ValidationExpression = MicroConstants.REGEX_DATE;

            requiredFieldValidator_TransactionDate.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_DATE_FIELD");
            requiredFieldValidator_RemittancePaidTo.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Office");
            requiredFieldValidator_BankBranch.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Bank Branch");
            requiredFieldValidator_BankAccount.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Bank Account Number");

            regularExpressionValidator_TransactionDate.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");

            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_TransactionDate.CssClass = theClassName;
            requiredFieldValidator_RemittancePaidTo.CssClass = theClassName;
            requiredFieldValidator_BankBranch.CssClass = theClassName;
            requiredFieldValidator_BankAccount.CssClass = theClassName;

            regularExpressionValidator_TransactionDate.CssClass = theClassName;
        }

        private void BindDropDown()
        {

        }

        private void BindDropDown_BankBranches()
        {
            ClearListItems(ddl_BankBranch, false);

            //List<BankBranch>

        }
        #endregion
    }
}