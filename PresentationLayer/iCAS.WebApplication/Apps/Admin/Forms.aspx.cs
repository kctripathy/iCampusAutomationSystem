using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Objects.Administration;
using System.Data;
using Micro.Framework.ReadXML;

namespace Micro.WebApplication.MicroERP.ADMIN
{
    /// <summary>
    /// Edit Forms
    /// </summary>
   public partial class Forms : BasePage
    {
        #region Declaration
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                PopulateFormName();
                SetFormMessage();
            }
			////((UC_Menu)Master.FindControl("ctrl_Menu")).SetActiveIndex = 4;
        }

       
        #endregion

        #region Methods & Implementation
        private void BindDropDown()
        {
            ddl_Roles.DataSource = RolesManagement.GetInstance.GetRolesList();
            ddl_Roles.DataTextField = RolesManagement.GetInstance.DisplayMember;
            ddl_Roles.DataValueField = RolesManagement.GetInstance.ValueMember;
            ddl_Roles.DataBind();
            ddl_Roles.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }
        //private void BindGridView()
        //{
        //    List<WebForm> MicroFormList = new List<WebForm>();
        //    MicroFormList = WebFormManagement.GetInstance.GetWebFormsAll();
        //    gview_Forms.DataSource = MicroFormList;
        //    gview_Forms.DataBind();
        //}

        private void PopulateFormName()
        {
            DataTable objDataTable = new DataTable();
            DataColumn objDatacolumn = new DataColumn("WebFormName", typeof(string));
            objDataTable.Columns.Add(objDatacolumn);
            List<WebForm> WebFormList = new List<WebForm>();
            WebFormList = WebFormManagement.GetInstance.GetWebFormsAll();
            foreach (WebForm webform in WebFormList)
            {
                DataRow objDataRow = objDataTable.NewRow();
                objDataRow["WebFormName"] = webform.WebFormName;
                objDataTable.Rows.Add(objDataRow);
            }
            gview_Forms.DataSource = objDataTable;
            gview_Forms.DataBind();
        }
        private void SetFormMessage()
        {
			requiredFieldValidator_Roles.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY","Role");
            requiredFieldValidator_Roles.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            SetFormMessageCssClass("ValidateMessage");
        }
        private void SetFormMessageCssClass(string theClassName)
        {
            requiredFieldValidator_Roles.CssClass = theClassName;
        }
        #endregion
    }
}