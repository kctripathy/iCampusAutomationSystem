using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.HumanResource;
using Micro.BusinessLayer.Administration;
using Micro.Framework.ReadXML;

namespace Micro.WebApplication.App_UserControls.Common
{
	public partial class UC_Name : BaseUserControl
    {
        #region Declaration

        public int CommonKeyID
        {
            get
            {
                int TheID = ((ddl_Salutation.SelectedIndex == 0) ? 0 : int.Parse(ddl_Salutation.SelectedItem.Value.ToString()));
                return TheID;
            }
        }

        public string Salutation
        {
            set
            {
                ddl_Salutation.Text = value;
            }
            get
            {
                return ddl_Salutation.SelectedValue;
            }
            
        }

        public int SelectedIndex
        {
            set
            {
                ddl_Salutation.SelectedIndex = value;
            }
        }

        public string Name
        {
            set
            {
                txt_Name.Text = value;
            }
            get
            {
                return txt_Name.Text;
            }
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                BindDropdown_Salutation();
                SetValidationMessages();
            }
		}

        #endregion

        #region Methods

        private void BindDropdown_Salutation()
        {
            ddl_Salutation.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Salutation.GetStringValue());
            ddl_Salutation.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            //ddl_Salutation.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Salutation.DataBind();
            ddl_Salutation.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        private void SetValidationMessages()
        {
            requiredFieldValidator_Salutation.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Salutation");
            requiredFieldValidator_Name.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "EmployeeName");

            regularExpressionValidator_Name.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");

            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_Salutation.CssClass = theClassName;
            requiredFieldValidator_Name.CssClass = theClassName;

            regularExpressionValidator_Name.CssClass = theClassName;
        }

        #endregion
    }
}