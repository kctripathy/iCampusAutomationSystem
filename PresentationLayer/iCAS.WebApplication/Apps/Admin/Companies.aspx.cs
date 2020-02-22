using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Framework.ReadXML;


namespace Micro.WebApplication.MicroERP.ADMIN
{
    /// <summary>
    /// Edit  Office
    /// </summary>
	
	public partial class Companies :BasePage
	{

		#region Declaration

		protected static class PageVariables
		{
			public static string TheCompanyID; 
		}

		#endregion


		#region Event

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
				BasePage.ShowHidePagePermissions(gv_Company, btn_AddCompanies, this.Page);
				multiView_Companydetails.SetActiveView(view_GridView);
				BindGridView();
				SetFormMessage();
			}
			////((UC_Menu)Master.FindControl("ctrl_Menu")).SetActiveIndex = 5;
			RegularExpressionValidator_EstablishmentDate.ValidationExpression = MicroConstants.REGEX_DATE;
			RegularExpressionValidator_CompanyEPFRegistrationNumber.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
			RegularExpressionValidator_CompanyMailingName.ValidationExpression = MicroConstants.REGEX_EMAILID;
			RegularExpressionValidator_CompanyRegistrationNumber.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
		}

		protected void btn_AddCompanies_Click(object sender, EventArgs e)
		{
			multiView_Companydetails.SetActiveView(view_InputControls);
		}

		protected void btn_Top_View_Click(object sender, EventArgs e)
		{
			BindGridView();
			multiView_Companydetails.SetActiveView(view_GridView);
		}

		protected void btn_Top_Save_Click(object sender, EventArgs e)
		{
			int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
			if (btn_Top_Save.Text == MicroEnums.DataOperation.Save.GetStringValue() && btn_bottom_Save.Text == MicroEnums.DataOperation.Save.GetStringValue())
			{
				ProcReturnValue = SaveCompanyDetails();
				dialog_Message.Show();
				lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Company", MicroEnums.DataOperation.AddNew);
			}
			else
			{
				ProcReturnValue = UpdateCompanyRecord();
				dialog_Message.Show();
				lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Company", MicroEnums.DataOperation.Edit);

			}
			if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
			{
				BindGridView();
				ResetPageFields();
			}
		}

		public void gv_Company_RowEditing(object sender, GridViewEditEventArgs e)
		{
			e.Cancel = true;
		}

		protected void btn_Top_Reset_Click(object sender, EventArgs e)
		{
			ResetPageFields();
		}

		protected void gv_Company_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					BasePage.GridViewOnDelete(e, 9);
					BasePage.GridViewOnClientMouseOver(e);
					BasePage.GridViewOnClientMouseOut(e);
					BasePage.GridViewToolTips(e, 8, 9);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		protected void gv_Company_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			e.Cancel = true;
			
		}

		protected void gv_Company_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName != "Page")
			{
				int RowIndex = Convert.ToInt32(e.CommandArgument);
				PageVariables.TheCompanyID = ((Label)gv_Company.Rows[RowIndex].FindControl("lbl_CompanyID")).Text;
			}



			if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
			{
				multiView_Companydetails.SetActiveView(view_InputControls);
				btn_Top_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Update.GetStringValue());
				btn_bottom_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Update.GetStringValue());
				PopulatePageField(int.Parse(PageVariables.TheCompanyID));
			}

			if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
			{
				int ProcReturnValue= DeleteRecord();
				dialog_Message.Show();
				lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Company", MicroEnums.DataOperation.Delete);
				BindGridView();
			}
		}

		protected void gv_Company_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gv_Company.PageIndex = e.NewPageIndex;
			BindGridView();
		}

		#endregion


		#region Methods & Implimentation

		private void BindGridView()
		{
			List<Company> CompanyList = new List<Company>();
			CompanyList = CompanyManagement.GetInstance.GetMicroCompanyList();
			gv_Company.DataSource = CompanyList;
			gv_Company.DataBind();
		}

		public static int DeleteRecord()
		{
			Company theCompany = new Company();
			theCompany.CompanyID = int.Parse(PageVariables.TheCompanyID);
			int ProcReturnValue = CompanyManagement.GetInstance.DeleteCompany(theCompany);
			return ProcReturnValue;
		}

		private int SaveCompanyDetails()
		{
			int ProcReturnValue = 0;
			Company TheCompany = new Company();
			TheCompany.CompanyName = txt_CompanyName.Text.ToString();
			TheCompany.CompanyAliasName = txt_CompanyAliasName.Text.ToString();
			TheCompany.CompanyMailingName = txt_CompanyMailingName.Text.ToString();
			//TheCompany.CompanyRegisteredOfficeID = int.Parse(txt_CompanyRegisteredOfficeID.Text);
			//TheCompany.CompanyHeadOfficeID = int.Parse(txt_CompanyHeadOfficeID.Text);
			TheCompany.CompanyRegistrationNumber = txt_CompanyRegistrationNumber.Text.ToString();
			TheCompany.CompanyEPFRegistrationNumber = txt_CompanyEPFRegistrationNumber.Text.ToString();
			TheCompany.EstablishmentDate = DateTime.Parse(txt_EstablishmentDate.Text);
			//if (chk_IsActive.Checked == true)
			//{
			//    TheCompany.IsActive = true;
			//}
			//else
			//{
			//    TheCompany.IsActive = false;
			//}
			ProcReturnValue = CompanyManagement.GetInstance.InsertCompany(TheCompany);
			return ProcReturnValue;
			
		}

		private int UpdateCompanyRecord()
		{
			int ProcReturnValue = 0;
			Company TheCompany = new Company();
			TheCompany.CompanyID = int.Parse(PageVariables.TheCompanyID);
			TheCompany.CompanyName = txt_CompanyName.Text.ToString();
			TheCompany.CompanyAliasName = txt_CompanyAliasName.Text.ToString();
			TheCompany.CompanyMailingName = txt_CompanyMailingName.Text.ToString();
			//TheCompany.CompanyRegisteredOfficeID = int.Parse(txt_CompanyRegisteredOfficeID.Text);
			//TheCompany.CompanyHeadOfficeID = int.Parse(txt_CompanyHeadOfficeID.Text);
			TheCompany.CompanyRegistrationNumber = txt_CompanyRegistrationNumber.Text.ToString();
			TheCompany.CompanyEPFRegistrationNumber = txt_CompanyEPFRegistrationNumber.Text.ToString();
			//TheCompany.EstablishmentDate = DateTime.Parse(txt_EstablishmentDate.Text);

			//if (chk_IsActive.Checked == true)
			//{
			//    TheCompany.IsActive = true;
			//}
			//else
			//{
			//    TheCompany.IsActive = false;
			//}
			ProcReturnValue = CompanyManagement.GetInstance.UpdateCompany(TheCompany);
			return ProcReturnValue;
			
		}

		private void PopulatePageField(int TheCompanyID)
		{
			Company ObjCompany = CompanyManagement.GetInstance.GetCompanyByComapnyID(TheCompanyID);
			txt_CompanyName.Text = ObjCompany.CompanyName.ToString();
			txt_CompanyAliasName.Text = ObjCompany.CompanyAliasName.ToString();
			txt_CompanyMailingName.Text = ObjCompany.CompanyMailingName.ToString();
			txt_CompanyRegistrationNumber.Text = ObjCompany.CompanyRegistrationNumber.ToString();
			txt_CompanyEPFRegistrationNumber.Text = ObjCompany.CompanyEPFRegistrationNumber.ToString();
			txt_EstablishmentDate.Text = ObjCompany.EstablishmentDate.ToString(MicroConstants.DateFormat);
			//if (ObjCompany.IsActive == true)
			//{
			//    chk_IsActive.Checked = true;
			//}
			//else
			//{
			//    chk_IsActive.Checked = false;
			
			//}
			ChangeBackColor(view_InputControls);
		
		}


		private void ResetPageFields()
		{
			txt_CompanyName.Text = string.Empty;
			txt_CompanyAliasName.Text = string.Empty;
			txt_CompanyMailingName.Text = string.Empty;
			txt_CompanyRegistrationNumber.Text = string.Empty;
			txt_CompanyEPFRegistrationNumber.Text = string.Empty;
			txt_EstablishmentDate.Text = string.Empty;
			//chk_IsActive.Checked = false;
			btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
			btn_bottom_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
			ResetBackColor(view_InputControls);
		}

		private void SetFormMessage()
		{
			RequiredFieldValidator_CompanyName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "CompanyName");
			RequiredFieldValidator_CompanyAliasName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "CompanyAliasName");
			RequiredFieldValidator_CompanyMailingName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "CompanyMailingName");
			RequiredFieldValidator_CompanyRegistrationNumber.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "CompanyRegistrationNumber");
			RequiredFieldValidator_CompanyEPFRegistrationNumber.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "CompanyEPFRegistrationNumber");
			RequiredFieldValidator_EstablishmentDate.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "EstablishmentDate");

			RegularExpressionValidator_CompanyName.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_ALPHANUMERIC_SPACE_DOT");
			RegularExpressionValidator_CompanyAliasName.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
			RegularExpressionValidator_CompanyMailingName.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_EMAIL_FIELD");
			RegularExpressionValidator_CompanyRegistrationNumber.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_NUMBER_FIELD");
			RegularExpressionValidator_CompanyEPFRegistrationNumber.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_NUMBER_FIELD");
			RegularExpressionValidator_EstablishmentDate.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_VALID_DATE");

			SetFormMessageCSSClass("ValidateMessage");
		
		}


		private void SetFormMessageCSSClass(string theClassName)
		{
			RequiredFieldValidator_CompanyName.CssClass = theClassName;
			RequiredFieldValidator_CompanyAliasName.CssClass = theClassName;
			RequiredFieldValidator_CompanyMailingName.CssClass = theClassName;
			RequiredFieldValidator_CompanyRegistrationNumber.CssClass = theClassName;
			RequiredFieldValidator_CompanyEPFRegistrationNumber.CssClass = theClassName;
			RequiredFieldValidator_EstablishmentDate.CssClass = theClassName;

			RegularExpressionValidator_CompanyName.CssClass = theClassName;
			RegularExpressionValidator_CompanyAliasName.CssClass = theClassName;
			RegularExpressionValidator_CompanyMailingName.CssClass = theClassName;
			RegularExpressionValidator_CompanyRegistrationNumber.CssClass = theClassName;
			RegularExpressionValidator_CompanyEPFRegistrationNumber.CssClass = theClassName;
			RegularExpressionValidator_EstablishmentDate.CssClass = theClassName;

		}


		#endregion


	}
}