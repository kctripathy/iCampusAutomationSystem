using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using Micro.BusinessLayer.HumanResource;
using Micro.Framework.ReadXML;
using System.Web;

namespace Micro.WebApplication.MicroERP.ADMIN
{
    /// <summary>
    /// Edits on Office
    /// <author>
    /// Premananda Routray
    /// </author>
    /// </summary>
	public partial class Offices : BasePage
    {
        #region Declaration
        
        protected static class PageVariables
        {
            //Modified on  date Dt.19-Feb-2013
            public static string TheOfficeId
            {
                get 
                {
                    string ThisOfficeID = HttpContext.Current.Session["TheOfficeId"].ToString();
                    return ThisOfficeID;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheOfficeId",value);
                }
            }
            //Modified on  date Dt.19-Feb-2013
            public static List<Office> TheOfficeList
            {
                get
                {
                List<Office> TheOffice = HttpContext.Current.Session["TheOfficeList"] as List<Office>;
                return TheOffice;
                }
                set
                {
                HttpContext.Current.Session.Add("TheOfficeList", value);
                }
            }
        }
        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
		{
			BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
			ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
			ctrl_Search.SearchWhat = MicroEnums.SearchForm.Office.ToString();
            if (!IsPostBack && !IsCallback)
            {
                BindDropDown();
				ResetPageVariables();
                SetFormMessage();
				if (HasAddPermission() && IsDefaultModeAdd())
				{
					multiView_Offices.SetActiveView(view_InputControls);
					ResetBackColor(view_InputControls);
				}
				else
				{
					BindGridView();
					BasePage.ShowHidePagePermissions(gview_Office, btn_Offices, this.Page);
					multiView_Offices.SetActiveView(view_GridView);
				}
            }
		}

        protected void btn_Offices_Click(object sender, EventArgs e)
        {
            multiView_Offices.SetActiveView(view_InputControls);
            ResetPageFields();
			if (!(BasePage.HasAddPermission(this.Page)))
			{
				multiView_Offices.SetActiveView(view_GridView);
			}
        }

        protected void btn_ViewOffice_Click(object sender, EventArgs e)
        {
			BindGridView();
			BasePage.ShowHidePagePermissions(gview_Office, btn_Offices, this.Page);
			multiView_Offices.SetActiveView(view_GridView);
        }

        private void searchCtrl_ButtonClicked(object sender, System.EventArgs e)
        {
            SearchOfficetBindGridView();
        }

        protected void btn_Save_Top_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            if (btn_Save_Top.Text == MicroEnums.DataOperation.Save.GetStringValue() && btn_Save.Text == MicroEnums.DataOperation.Save.GetStringValue())
            {
                ProcReturnValue = SaveOfficeRecord();
                dialog_Message.Show();
                lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Office", MicroEnums.DataOperation.AddNew);
            }
            else
            {
                ProcReturnValue = UpdateRecord();
                dialog_Message.Show();
                lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Office", MicroEnums.DataOperation.Edit);
            }
            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                BindGridView();
                ResetPageFields();
            }
        }

        protected void btn_Reset_Top_Click(object sender, EventArgs e)
        {
            ResetPageFields();
        }

        protected void ddl_OfficeDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            District TheDistrict = DistrictManagement.GetInstance.GetDistrictStateCountryByDistrictId(int.Parse(ddl_OfficeDistrict.SelectedValue));
            txt_OfficeState.Text = TheDistrict.StateName;
        }

        protected void gview_Office_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                PageVariables.TheOfficeId = ((Label)gview_Office.Rows[RowIndex].FindControl("lbl_OfficeID")).Text;
                lbl_DataOperationMode.Text = String.Format("EDIT OFFICE : {0} [{1}]", gview_Office.Rows[RowIndex].Cells[2].Text.ToUpper(), PageVariables.TheOfficeId);
            }

            if (e.CommandName == MicroEnums.DataOperation.Edit.GetStringValue())
            {
                btn_Save_Top.Text = MicroEnums.DataOperation.Update.GetStringValue();
                btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
                multiView_Offices.SetActiveView(view_InputControls);
                ChangeBackColor(view_InputControls);
				EnableControls(view_InputControls, true);
				btn_Save.Visible = true;
				btn_Save_Top.Visible = true;
                PoupulatePageFieldsData(int.Parse(PageVariables.TheOfficeId));
            }
            if (e.CommandName == MicroEnums.DataOperation.Delete.GetStringValue())
            {
                int ProcReturnValue = DeleteRecord();
                dialog_Message.Show();
                lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Office", MicroEnums.DataOperation.Delete);
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    BindGridView();
                }

            }
			else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
			{
				multiView_Offices.SetActiveView(view_InputControls);
				PoupulatePageFieldsData(int.Parse(PageVariables.TheOfficeId));
				EnableControls(view_InputControls, false);
				btn_Save.Visible = false;
				btn_Save_Top.Visible = false;
			}
        }

        protected void gview_Office_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_Office_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_Office_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_Office.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void gview_Office_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridViewOnDelete(e, 5);
                    GridViewOnClientMouseOver(e);
                    GridViewOnClientMouseOut(e);
                    GridViewToolTips(e, 4, 5);
                }
            }
            catch
            { 
            
            }

        }

        #endregion

        #region Methods & Implementation

        private void BindGridView()
        {
            gview_Office.DataSource = null;
            gview_Office.DataBind();

            PageVariables.TheOfficeList = OfficeManagement.GetInstance.GetOfficeList();
            if (PageVariables.TheOfficeList.Count > 0)
            {
                gview_Office.DataSource = PageVariables.TheOfficeList;
                gview_Office.DataBind();
            }
        }

        private void BindDropDown()
        { 
            BindOfficeType();
            BindReportingOffice();
            BindOfficeInCharge();
            BindDistrict();
        }

        private void BindOfficeType()
        {
            ddl_OfficeType.DataSource = OfficeTypeManagement.GetInstance.GetOfficeTypesAll();
            ddl_OfficeType.DataTextField = OfficeTypeManagement.GetInstance.DisplayMember;
            ddl_OfficeType.DataValueField = OfficeTypeManagement.GetInstance.ValueMember;
            ddl_OfficeType.DataBind();
            ddl_OfficeType.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        private void BindReportingOffice()
        {
            ddl_ReportingOffice.DataSource = OfficeManagement.GetInstance.GetOfficeList();
            ddl_ReportingOffice.DataTextField = OfficeManagement.GetInstance.DisplayMember;
            ddl_ReportingOffice.DataValueField = OfficeManagement.GetInstance.ValueMember;
            ddl_ReportingOffice.DataBind();
            ddl_ReportingOffice.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
                
        }

        private void BindOfficeInCharge()
        {
            ddl_OfficeInCharge.DataSource = EmployeeManagement.GetInstance.GetEmployeeList();
            ddl_OfficeInCharge.DataTextField = EmployeeManagement.GetInstance.DisplayMember;
            ddl_OfficeInCharge.DataValueField = EmployeeManagement.GetInstance.ValueMember;
            ddl_OfficeInCharge.DataBind();
            ddl_OfficeInCharge.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        private void BindDistrict()
        {
            ddl_OfficeDistrict.DataSource = DistrictManagement.GetInstance.GetAllDistricts();
            ddl_OfficeDistrict.DataTextField = DistrictManagement.GetInstance.DisplayMember;
            ddl_OfficeDistrict.DataValueField = DistrictManagement.GetInstance.ValueMember;
            ddl_OfficeDistrict.DataBind();
            ddl_OfficeDistrict.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));

        }

        private int SaveOfficeRecord()
        {
            Office objOffice = new Office();
            objOffice.OfficeName = txt_OfficeName.Text;
            objOffice.OfficeTypeID = int.Parse(ddl_OfficeType.SelectedValue);
            objOffice.EstablishmentDate = DateTime.Parse(txt_EstablishmentDate.Text);
            objOffice.ParentOfficeID = int.Parse(ddl_ReportingOffice.SelectedValue);
            objOffice.ManagerEmployeeID = int.Parse(ddl_OfficeInCharge.SelectedValue);
            objOffice.Address_TownOrCity = txt_OfficeStreet.Text;
            objOffice.Address_Landmark = txt_OfficeLandMark.Text;
            objOffice.Address_DistrictID = int.Parse(ddl_OfficeDistrict.SelectedValue);
            objOffice.Address_PinCode = txt_OfficePincode.Text;
            objOffice.StdCodePhone = txt_StdCode.Text;
            objOffice.Phone1 = txt_PhoneNumber1.Text;
            objOffice.Phone2 = txt_PhoneNumber2.Text;
            objOffice.Phone3 = txt_PhoneNumber3.Text;
            objOffice.StdCodeFax = txt_StdCodeFax.Text;
            objOffice.Fax1 = txt_FaxNumber1.Text;
            objOffice.Fax2 = txt_FaxNumber2.Text;
            objOffice.Fax3 = txt_FaxNumber3.Text;
            objOffice.ContactPerson1 = txt_PersonName1.Text;
            objOffice.Mobile1 = txt_PersonMobile1.Text;
            objOffice.Email1 = txt_PersonEmail1.Text;
            objOffice.Extension1 = txt_PersonExtension1.Text;
            objOffice.ContactPerson2 = txt_PersonName2.Text;
            objOffice.Mobile2 = txt_PersonMobile2.Text;
            objOffice.Email2 = txt_PersonEmail2.Text;
            objOffice.Extension2 = txt_PersonExtension2.Text;
            objOffice.ContactPerson3 = txt_PersonName3.Text;
            objOffice.Mobile3 = txt_PersonMobile3.Text;
            objOffice.Email3 = txt_PersonEmail3.Text;
            objOffice.Extension3 = txt_PersonExtension3.Text;
            //if (chk_IsHavingShift.Checked == true)
            //{
            //    objOffice.IsHavingShift = true;
            //}
            //else
            //{
            //    objOffice.IsHavingShift = false;
            //}
            int ProcReturnValue = OfficeManagement.GetInstance.InsertOffice(objOffice);
            return ProcReturnValue;


        }

        private int UpdateRecord()
        { 
        Office objOffice = new Office();
            objOffice.OfficeID = int.Parse(PageVariables.TheOfficeId);
            objOffice.OfficeName = txt_OfficeName.Text;
            objOffice.OfficeTypeID = int.Parse(ddl_OfficeType.SelectedValue);
            objOffice.EstablishmentDate = DateTime.Parse(txt_EstablishmentDate.Text);
            objOffice.ParentOfficeID = int.Parse(ddl_ReportingOffice.SelectedValue);
            objOffice.ManagerEmployeeID = int.Parse(ddl_OfficeInCharge.SelectedValue);
            objOffice.Address_TownOrCity = txt_OfficeStreet.Text;
            objOffice.Address_Landmark = txt_OfficeLandMark.Text;
            objOffice.Address_DistrictID = int.Parse(ddl_OfficeDistrict.SelectedValue);
            objOffice.Address_PinCode = txt_OfficePincode.Text;
            objOffice.StdCodePhone = txt_StdCode.Text;
            objOffice.Phone1 = txt_PhoneNumber1.Text;
            objOffice.Phone2 = txt_PhoneNumber2.Text;
            objOffice.Phone3 = txt_PhoneNumber3.Text;
            objOffice.StdCodeFax = txt_StdCodeFax.Text;
            objOffice.Fax1 = txt_FaxNumber1.Text;
            objOffice.Fax2 = txt_FaxNumber2.Text;
            objOffice.Fax3 = txt_FaxNumber3.Text;
            objOffice.ContactPerson1 = txt_PersonName1.Text;
            objOffice.Mobile1 = txt_PersonMobile1.Text;
            objOffice.Email1 = txt_PersonEmail1.Text;
            objOffice.Extension1 = txt_PersonExtension1.Text;
            objOffice.ContactPerson2 = txt_PersonName2.Text;
            objOffice.Mobile2 = txt_PersonMobile2.Text;
            objOffice.Email2 = txt_PersonEmail2.Text;
            objOffice.Extension2 = txt_PersonExtension2.Text;
            objOffice.ContactPerson3 = txt_PersonName3.Text;
            objOffice.Mobile3 = txt_PersonMobile3.Text;
            objOffice.Email3 = txt_PersonEmail3.Text;
            objOffice.Extension3 = txt_PersonExtension3.Text;
            //if (chk_IsHavingShift.Checked == true)
            //{
            //    objOffice.IsHavingShift = true;
            //}
            //else
            //{
            //    objOffice.IsHavingShift = false;
            //}
            int ProcReturnValue = OfficeManagement.GetInstance.UpdateOffice(objOffice);
            return ProcReturnValue;
        }

        private void PoupulatePageFieldsData(int theOfficeID)
        {
            Office theOffice = OfficeManagement.GetInstance.GetOfficeByID(theOfficeID);
            txt_OfficeName.Text = theOffice.OfficeName;
            ddl_OfficeType.SelectedIndex = GetSelecteIndex(ddl_OfficeType, theOffice.OfficeTypeID);
            txt_EstablishmentDate.Text = theOffice.EstablishmentDate.ToString(MicroConstants.DateFormat);
            ddl_ReportingOffice.SelectedIndex = GetSelecteIndex(ddl_ReportingOffice,theOffice.ParentOfficeID);
            ddl_OfficeInCharge.SelectedIndex = GetSelecteIndex(ddl_OfficeInCharge,theOffice.ManagerEmployeeID);
            txt_OfficeStreet.Text = theOffice.Address_TownOrCity;
            txt_OfficeLandMark.Text= theOffice.Address_Landmark ;
			ddl_OfficeDistrict.SelectedIndex = GetSelecteIndex(ddl_OfficeDistrict, theOffice.Address_DistrictID);
			txt_OfficeState.Text = theOffice.Address_StateName;
            txt_OfficePincode.Text =  theOffice.Address_PinCode;
            txt_StdCode.Text = theOffice.StdCodePhone ;
            txt_PhoneNumber1.Text = theOffice.Phone1;
            txt_PhoneNumber2.Text = theOffice.Phone2;
            txt_PhoneNumber3.Text = theOffice.Phone3;
            txt_StdCodeFax.Text = theOffice.StdCodeFax;
            txt_FaxNumber1.Text =  theOffice.Fax1;
            txt_FaxNumber2.Text = theOffice.Fax2;
            txt_FaxNumber3.Text = theOffice.Fax3;
            txt_PersonName1.Text = theOffice.ContactPerson1;
            txt_PersonMobile1.Text = theOffice.Mobile1;
            txt_PersonEmail1.Text = theOffice.Email1;
            txt_PersonExtension1.Text = theOffice.Extension1;
            txt_PersonName2.Text = theOffice.ContactPerson2;
            txt_PersonMobile2.Text = theOffice.Mobile2;
            txt_PersonEmail2.Text = theOffice.Email2;
            txt_PersonExtension2.Text = theOffice.Extension2;
            txt_PersonName3.Text = theOffice.ContactPerson3;
            txt_PersonMobile3.Text = theOffice.Mobile3;
            txt_PersonEmail3.Text = theOffice.Email3;
            txt_PersonExtension3.Text = theOffice.Extension3;
            //if (theOffice.IsHavingShift == true)
            //{
            //    chk_IsHavingShift.Checked = true;
            //}
            //else
            //{
            //    chk_IsHavingShift.Checked = false;
            //}
        }

        private int DeleteRecord()
        {
            int ProcReturnValue=0;
            Office theOffice = new Office();
            theOffice.OfficeID =int.Parse( PageVariables.TheOfficeId);
            ProcReturnValue = OfficeManagement.GetInstance.DeleteOffice(theOffice.OfficeID);
          return ProcReturnValue;
            
        }

        private int GetSelecteIndex(DropDownList ddl, int TheID)
        {
            int ReturnValue=0;
            for (int ctr = 0; ctr < ddl.Items.Count; ctr++)
            { 
                
            if(ddl.Items[ctr].Value==TheID.ToString())
            {
                    ReturnValue=ctr;
                    break;
                }
             }
           return ReturnValue; 
        }

        private void SetFormMessage()
        {
            regularExpressionValidator_EstablishmentDate.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_StdCodeFax.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_StdCode.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_PhoneNo3.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_PhoneNo2.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_PhoneNo1.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_PersonName2.ValidationExpression = MicroConstants.REGEX_NAME;
            regularExpressionValidator_PersonMobile3.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_Personmobile2.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_PersonMobile1.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_PersonExtnsion3.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_PersonExtension2.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_PersonExtension1.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_PersonEmail3.ValidationExpression = MicroConstants.REGEX_EMAILID;
            regularExpressionValidator_PersonEmail2.ValidationExpression = MicroConstants.REGEX_EMAILID;
            regularExpressionValidator_PersonEmail1.ValidationExpression = MicroConstants.REGEX_EMAILID;
            regularExpressionValidator_Person3.ValidationExpression = MicroConstants.REGEX_NAME;
            regularExpressionValidator_Person1.ValidationExpression = MicroConstants.REGEX_NAME;
            RegularExpressionValidator_OfficePinCode.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_FaxNo3.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_FaxNo2.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_FaxNo1.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;

            requiredFieldValidator_OfficeName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "OfficeName");
            requiredFieldValidator_OfficeType.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_OfficeType.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Office Type");
            requiredFieldValidator_ReportingOffice.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_ReportingOffice.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Reporting Office");
            requiredFieldValidator_OfficeInCharge.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Office In Charge");
            requiredFieldValidator_OfficeInCharge.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_OfficeDistrict.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_OfficeDistrict.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "District");
            requiredFieldValidator_OfficeStreet.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Street/Town");
            requiredFieldValidator_EstablishmentDate.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "EstablishmentDate");

            regularExpressionValidator_EstablishmentDate.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_VALID_DATE");
            regularExpressionValidator_FaxNo1.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_FaxNo2.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_FaxNo3.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            RegularExpressionValidator_OfficePinCode.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE"); ;
            regularExpressionValidator_Person1.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
            regularExpressionValidator_Person3.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
            regularExpressionValidator_PersonEmail1.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_EMAIL_FIELD");
            regularExpressionValidator_PersonEmail2.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_EMAIL_FIELD");
            regularExpressionValidator_PersonEmail3.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_EMAIL_FIELD");
            regularExpressionValidator_PersonExtension1.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_PersonExtension2.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_PersonExtnsion3.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_PersonMobile1.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_Personmobile2.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_PersonMobile3.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_PersonName2.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
            regularExpressionValidator_PhoneNo1.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_PhoneNo2.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_PhoneNo3.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_StdCode.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_StdCodeFax.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");

            SetFormMessageCssClass("ValidateMessage");
           
        }
      
        private void SetFormMessageCssClass(string theCssClass)
        {
            foreach (Control ctrl in view_InputControls.Controls)
            {
                if (ctrl.GetType().Name == "RequiredFieldValidator")
                {
                    RequiredFieldValidator ReqFieldVal = ctrl as RequiredFieldValidator;
                    ReqFieldVal.CssClass = theCssClass;
                }
            }
           
            foreach (Control ctrl in view_InputControls.Controls)
            {
                if (ctrl.GetType().Name == "RegularExpressionValidator")
                {
                    RegularExpressionValidator RegxVal = ctrl as RegularExpressionValidator;
                    RegxVal.CssClass = theCssClass;
                }
            }
        }

        private void ResetPageFields()
        {
            foreach (Control ctrl in view_InputControls.Controls)
            {
                if (ctrl.GetType().Name == "TextBox")
                {
                    TextBox tb = ctrl as TextBox;
                    tb.Text = "";
                }
                if (ctrl.GetType().Name == "DropDownList")
                {
                    DropDownList ddl = ctrl as DropDownList;
                    ddl.SelectedIndex = 0;
                }
            }
            ResetBackColor(view_InputControls);
            btn_Save_Top.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
            lbl_DataOperationMode.Text = "ADD NEW OFFICE";
			btn_Save_Top.Visible = true;
			btn_Save.Visible = true;
			EnableControls(view_InputControls, true);
        }

        private void SearchOfficetBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            List<Office> SearchList = new List<Office>();
            // Search by name
            if (PageVariables.TheOfficeList.Count > 0)
            {
                if (searchField == MicroEnums.SearchOffice.OfficeName.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        SearchList = (from offName in PageVariables.TheOfficeList
                                      where offName.OfficeName.ToUpper().StartsWith(searchText.ToUpper())
                                      select offName).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from offName in PageVariables.TheOfficeList
                                      where offName.OfficeName.ToUpper().Contains(searchText.ToUpper())
                                      select offName).ToList();
                    }
                }
            }
            // Dispaly the search result
            ctrl_Search.SearchResultCount = SearchList.Count.ToString();
            gview_Office.DataSource = SearchList;
            gview_Office.DataBind();
        }

        private void BindSearchFields()
        {
            foreach (MicroEnums.SearchOffice x in Enum.GetValues(typeof(MicroEnums.SearchOffice)))
            {
                string xyz = x.ToString();
            }
        }

        private void ResetPageVariables()
        {
            PageVariables.TheOfficeList = null;
            //PageVariables.TheOfficeId = null;
        }

        #endregion
    }
}