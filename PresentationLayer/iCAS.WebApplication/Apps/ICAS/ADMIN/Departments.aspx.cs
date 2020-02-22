using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.HumanResource;
using Micro.Objects.HumanResource;
using Micro.Framework.ReadXML;
using System.Web;
using Micro.Objects.Administration;
namespace Micro.WebApplication.MicroERP.HRMS
{
	/// <summary>
	///View,Add,Edit & Delete Departments.
	/// </summary>
	public partial class Departments : BasePage
	{
		#region Declaration
		public MicroEnums.DataOperation DataOperationMode;
		protected static class PageVariables
		{
			//PageVariables modified on Dt:19/2/2013
			public static Department ThisDepartment
			{
				get 
				{
					Department TheDepartment = HttpContext.Current.Session["ThisDepartment"] as Department;
					return TheDepartment;
				}
				set
				{
					HttpContext.Current.Session.Add("ThisDepartment",value);
				}
			}
			
			public static List<Department> DepartmentList
			{
				get 
				{
					List<Department> TheDepartment = HttpContext.Current.Session["DepartmentList"] as List<Department>;
					return TheDepartment;
				}
				set
				{
					HttpContext.Current.Session.Add("DepartmentList",value);
				}
			}
		
		}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
			ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
			ctrl_Search.SearchWhat = MicroEnums.SearchForm.Department.ToString();
			if (!IsPostBack && !IsCallback)
			{
				SetValidationMessages();
				ResetPageVariables();
				BindDropdown();
				if (HasAddPermission() && IsDefaultModeAdd())
				{
					multiView_DepartmentDetails.SetActiveView(view_InputControls);
					ResetBackColor(view_InputControls);
				}
				else
				{
					BindGridView();
					//multiView_DepartmentDetails.SetActiveView(view_GridView);
					BasePage.ShowHidePagePermissions(gview_Department, btn_AddDepartment, this.Page);
                    tab_Departments_ActiveTabChanged(sender, e);
				}
			}
		}

        protected void tab_Departments_ActiveTabChanged(object sender, EventArgs e)
        {
            if (tab_Departments.ActiveTab == tab_DepartmentAll)
            {

                 multiView_DepartmentDetails.SetActiveView(view_GridView);
            }
            else
            {
                Multiview_Desig.SetActiveView(view_GridViewDepart);
                BindGridViewOfficeDepartments();
            }
        }

       

		protected void gview_Department_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gview_Department.PageIndex = e.NewPageIndex;
			BindGridView();
		}

		protected void gview_Department_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int RowIndex = Convert.ToInt32(e.CommandArgument);
			int RecordID = int.Parse(((Label)gview_Department.Rows[RowIndex].FindControl("lbl_DepartmentID")).Text);
			lbl_DataOperationMode.Text = String.Format("EDIT DEPARTMENT : {0} [{1}]", gview_Department.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
			PageVariables.ThisDepartment = DepartmentManagement.GetInstance.GetDepartmentById(RecordID);

			if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
			{
				btn_Top_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
				Btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();

				multiView_DepartmentDetails.SetActiveView(view_InputControls);
				EnableControls(view_InputControls, true);
				PopulatePageFields(PageVariables.ThisDepartment);
				ChangeBackColor(view_InputControls);
				Btn_Save.Visible = true;
				btn_Top_Save.Visible = true;
			}
			else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
			{
				int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

				ProcReturnValue = DeleteRecord();
				lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Department", MicroEnums.DataOperation.Delete);
				if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
				{
					BindGridView();
				}

				dialog_Message.Show();
			}
			else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
			{
				multiView_DepartmentDetails.SetActiveView(view_InputControls);
				PopulatePageFields(PageVariables.ThisDepartment);
				lbl_DataOperationMode.Text = String.Format("VIEW DEPARTMENT : {0} [{1}]", gview_Department.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
                bool EnableFlag = false;
                EnableControls(view_InputControls, false);
                Btn_Save.Visible = EnableFlag;
                btn_Top_Save.Visible = EnableFlag;
                btn_Cancel.Visible = EnableFlag;

                btn_Cancel_Top.Visible = EnableFlag;
            }
			
		}

		protected void gview_Department_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					BasePage.GridViewOnDelete(e, 4);
					BasePage.GridViewOnClientMouseOver(e);
					BasePage.GridViewOnClientMouseOut(e);
					BasePage.GridViewToolTips(e, 3, 4);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}
		
		protected void gview_Department_RowEditing(object sender, GridViewEditEventArgs e)
		{
			e.Cancel = true;
		}

		protected void gview_Department_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			e.Cancel = true;
			
		}

		private void searchCtrl_ButtonClicked(object sender, System.EventArgs e)
		{
			SearchDepartmentBindGridView();
		}

		protected void btn_Cancel_Click(object sender, EventArgs e)
		{
			ResetTextBoxes();
		}

		protected void Btn_Save_Click(object sender, EventArgs e)
		{
			int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

			if (ValidateFormFields())
			{
				if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
				{
					ProcReturnValue = InsertRecord();
					lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Department", MicroEnums.DataOperation.AddNew);
				}
				else
				{
					ProcReturnValue = UpdateRecord();
					lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Department", MicroEnums.DataOperation.Edit);
				}
				if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
				{
					BindGridView();
                    BindGridViewOfficeDepartments();
					ResetTextBoxes();
				}
			}
			if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
				dialog_Message.Show();
		}

		protected void btn_ViewDepartment_Click(object sender, EventArgs e)
		{
			BindGridView();
			BasePage.ShowHidePagePermissions(gview_Department, btn_AddDepartment, this.Page);
			multiView_DepartmentDetails.SetActiveView(view_GridView);
		}
		
		protected void btn_AddDepartment_Click(object sender, EventArgs e)
		{
			ResetTextBoxes();
			multiView_DepartmentDetails.SetActiveView(view_InputControls);
			if (!(BasePage.HasAddPermission(this.Page)))
			{
				multiView_DepartmentDetails.SetActiveView(view_GridView);
			}
		}
        protected void chkSelectAll_Add_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkAll = (CheckBox)gview_DepartmentSelect.HeaderRow.FindControl("chkSelectAll_Add");
            if (chkAll.Checked == true)
            {
                foreach (GridViewRow gvRow in gview_DepartmentSelect.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
                    chkSel.Checked = true;

                }
            }
            else
            {
                foreach (GridViewRow gvRow in gview_DepartmentSelect.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chk_Add");
                    chkSel.Checked = false;

                }
            }
        }

        protected void gview_DepartmentSelect_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_DepartmentSelect.PageIndex = e.NewPageIndex;
            BindGridViewOfficeDepartments();
        }

        protected void btn_Apply_Click(object sender, EventArgs e)
        {

            int result = (int)MicroEnums.DataOperationResult.Failure;

            DepartmentOfficewise theDepartmentOfficewise = new DepartmentOfficewise();
            List<DepartmentOfficewise> thisDepartmentOfficewiseList = new List<DepartmentOfficewise>();
            foreach (GridViewRow therow in gview_DepartmentSelect.Rows)
            {

                DepartmentOfficewise thisDepartmentOfficewise = new DepartmentOfficewise();
                CheckBox chkb = (CheckBox)therow.FindControl("chk_Add");
                Label theOfficelabel = (Label)therow.FindControl("lbl_DepartmentOfficeId");

                if (int.Parse(theOfficelabel.Text) == 0)
                {
                    if (chkb.Checked)
                    {
                        theDepartmentOfficewise.DepartmentID = int.Parse(therow.Cells[2].Text);

                        result = DepartmentOfficewiseManagement.GetInstance.InsertDepartmentOfficewise(theDepartmentOfficewise);
                        lbl_TheMessage.Text = GetDataOperationResult(result, "Department", MicroEnums.DataOperation.AddNew);

                    }
                }
                else if (int.Parse(theOfficelabel.Text) != 0)
                {
                    theDepartmentOfficewise.DepartmentID = int.Parse(therow.Cells[2].Text);
                    if (!chkb.Checked)
                    {
                        theDepartmentOfficewise.IsActive = false;
                    }
                    else
                    {
                        theDepartmentOfficewise.IsActive = true;
                    }
                    theDepartmentOfficewise.DepartmentOfficewiseID = int.Parse(theOfficelabel.Text);

                    result = DepartmentOfficewiseManagement.GetInstance.UpdateDepartmentOfficewise(theDepartmentOfficewise);
                    lbl_TheMessage.Text = GetDataOperationResult(result, "Department", MicroEnums.DataOperation.Edit);
                }
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
        }
        
        
        #endregion

		#region Methods & Implementation
		
		private void SetValidationMessages()
		{
			requiredFieldValidator_DepartmentDescription.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "DepartmentsName");
			regularExpressionValidator_DepartmentDescription.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
			RequiredFieldValidator_ddl_ParentDepartment.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
			RequiredFieldValidator_ddl_ParentDepartment.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "ParentDepartment");
			SetFormMessageCSSClass("ValidateMessage");
		}

		private void SetFormMessageCSSClass(string theClassName)
		{
			requiredFieldValidator_DepartmentDescription.CssClass = theClassName;
			regularExpressionValidator_DepartmentDescription.CssClass = theClassName;
			RequiredFieldValidator_ddl_ParentDepartment.CssClass = theClassName;
		}

		private void BindDropdown()
		{
			BindDropdown_ParentDepartment();

			BindDropdown_AppendSelectToFirst();
		}

		private void BindDropdown_ParentDepartment()
		{
			ddl_ParentDepartment.DataSource = DepartmentManagement.GetInstance.GetDepartmentsList();
			ddl_ParentDepartment.DataTextField = DepartmentManagement.GetInstance.DisplayMember;
			ddl_ParentDepartment.DataValueField = DepartmentManagement.GetInstance.ValueMember;
			ddl_ParentDepartment.DataBind();

		}

		private void BindDropdown_AppendSelectToFirst()
		{
			ddl_ParentDepartment.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
		}
		private void BindGridView()
		{
			gview_Department.DataSource = null;
			gview_Department.DataBind();

			PageVariables.DepartmentList = DepartmentManagement.GetInstance.GetDepartmentsList();

			if (PageVariables.DepartmentList.Count > 0)
			{
				gview_Department.DataSource = PageVariables.DepartmentList;
				gview_Department.DataBind();
			}


		}

		private void SearchDepartmentBindGridView()
		{
			string searchText = ctrl_Search.SearchText;
			string searchOperator = ctrl_Search.SearchOperator;
			string searchField = ctrl_Search.SearchField;

			List<Department> SearchList = new List<Department>();
			// Search by name
			if (PageVariables.DepartmentList.Count > 0)
			{
				if (searchField == MicroEnums.SearchDepartment.DepartmentName.ToString())
				{
					if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
					{
						SearchList = (from depname in PageVariables.DepartmentList
									  where depname.DepartmentDescription.ToUpper().StartsWith(searchText.ToUpper())
									  select depname).ToList();
					}

					if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
					{
						SearchList = (from depname in PageVariables.DepartmentList
									  where depname.DepartmentDescription.ToUpper().Contains(searchText.ToUpper())
									  select depname).ToList();
					}
				}
			}
			
			// Dispaly the search result
			ctrl_Search.SearchResultCount = SearchList.Count.ToString();
			gview_Department.DataSource = SearchList;
			gview_Department.DataBind();
		}

		private void BindSearchFields()
		{
			foreach (MicroEnums.SearchDepartment x in Enum.GetValues(typeof(MicroEnums.SearchDepartment)))
			{
				string xyz = x.ToString();
			}
		}

		private void PopulatePageFields(Department theDepartment)
		{
			txt_DepartmentDescription.Text = theDepartment.DepartmentDescription;
            ddl_ParentDepartment.SelectedIndex = GetDropDownSelectedIndex(ddl_ParentDepartment, Convert.ToString(theDepartment.ParentDepartmentId));
		}
		
		private bool ValidateFormFields()
		{
			bool ReturnValue = true;
			return ReturnValue;
		}

		private int InsertRecord()
		{
			int ProcReturnValue = 0;
			Department TheDepartments = new Department();

			TheDepartments.DepartmentDescription = txt_DepartmentDescription.Text;
			TheDepartments.ParentDepartmentId = int.Parse(ddl_ParentDepartment.SelectedValue);

			ProcReturnValue = DepartmentManagement.GetInstance.InsertDepartment(TheDepartments);

			return ProcReturnValue;
		}

		private void ResetTextBoxes()
		{
			ddl_ParentDepartment.SelectedIndex = 0;
			txt_DepartmentDescription.Text = string.Empty;

			PageVariables.ThisDepartment = null;
			lbl_DataOperationMode.Text = "ADD NEW DEPARTMENT";
			Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
			btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();

			Btn_Save.Visible = true;
			btn_Top_Save.Visible = true;
			EnableControls(view_InputControls, true);
			ResetBackColor(view_InputControls);

            if (tab_Departments.ActiveTab == tab_DepartmentAll)
            {
                multiView_DepartmentDetails.SetActiveView(view_InputControls);
            }
		}

		private static void ResetPageVariables()
		{
			PageVariables.ThisDepartment = null;
			PageVariables.DepartmentList = null;
		}

		private int UpdateRecord()
		{
			PageVariables.ThisDepartment.DepartmentDescription = txt_DepartmentDescription.Text;
			PageVariables.ThisDepartment.ParentDepartmentId = int.Parse(ddl_ParentDepartment.SelectedValue);

			int ProcReturnValue = DepartmentManagement.GetInstance.UpdateDepartment(PageVariables.ThisDepartment);
			return ProcReturnValue;
		}

		public static int DeleteRecord()
		{
			int ProcReturnValue = DepartmentManagement.GetInstance.DeleteDepartment(PageVariables.ThisDepartment);
			return ProcReturnValue;
		}




        private void FillOfficeDesignations(int officeID)
        {
            try
            {

                List<DepartmentOfficewise> DepartmentOfficewiseList = DepartmentOfficewiseManagement.GetInstance.GetDepartmentOfficewiseByOfficeID(officeID);
                List<DepartmentOfficewise> BindDepartmentItems = (from m in DepartmentOfficewiseList
                                                                    where m.DepartmentOfficewiseID != -1
                                                                  orderby m.DepartmentOfficewiseID
                                                                  select m).ToList<DepartmentOfficewise>();

                // Bind the GridView for the forms

                gview_DepartmentSelect.DataSource = BindDepartmentItems;
                gview_DepartmentSelect.DataBind();

                //All checked ITEMS in GridView
                CheckUncheckGridItems();

            }

            catch (Exception ex)
            {

            }
        }

        private void CheckUncheckGridItems()
        {

            int OfficeID = ((User)Session["CurrentUser"]).OfficeID;
            List<DepartmentOfficewise> TheDepartmentByoffice = DepartmentOfficewiseManagement.GetInstance.GetDepartmentOfficewiseByOfficeID(OfficeID);

            foreach (GridViewRow gvRow in gview_DepartmentSelect.Rows)
            {
                int TheOfficeID = ((User)Session["CurrentUser"]).OfficeID;
                CheckBox chkSelAdd = (CheckBox)gvRow.FindControl("chk_Add");


                Label lbl_DepartmentId = (Label)gvRow.FindControl("lbl_DepartmentId");

                int DepartmentIdd = int.Parse(lbl_DepartmentId.Text);

                chkSelAdd.Checked = WillSelectCheckBox(TheDepartmentByoffice, DepartmentIdd, BasePage.IsActive, TheOfficeID);
            }
        }

        private bool WillSelectCheckBox(List<DepartmentOfficewise> TheDepartmentByoffice, int departmentIdd, bool IsActive, int theofficeid)
        {
            bool ReturnValue;
            var result = TheDepartmentByoffice.Find
                        (mm =>
                            mm.OfficeID == theofficeid &&
                            mm.DepartmentID == departmentIdd &&
                            mm.IsActive == IsActive);

            if (result == null)
            {
                ReturnValue = false;
            }
            else
            {
                ReturnValue = true;
            }
            return ReturnValue;
        }

        public void BindGridViewOfficeDepartments()
        {
            List<Department> AllDepartments = new List<Department>();
            AllDepartments = DepartmentManagement.GetInstance.GetDepartmentsList();
            //DesignationManagement.GetInstance.GetDesignationsList();

            List<DepartmentOfficewise> CurrentOfficeDepartments = new List<DepartmentOfficewise>();
            CurrentOfficeDepartments = DepartmentOfficewiseManagement.GetInstance.GetDepartmentOfficewiseByOfficeID();

            gview_DepartmentSelect.DataSource = AllDepartments;
            gview_DepartmentSelect.DataBind();


            int counter = 0;
            if (CurrentOfficeDepartments.Count > 0)
            {
                foreach (DepartmentOfficewise thedepartmentofficewise in CurrentOfficeDepartments)
                {
                    counter++;
                    foreach (GridViewRow therow in gview_DepartmentSelect.Rows)
                    {
                        Label thedepartmentlabel = (Label)therow.FindControl("lbl_DepartmentId");
                        Label theOfficelabel = (Label)therow.FindControl("lbl_DepartmentOfficeId");
                        CheckBox theCheckBox = (CheckBox)therow.FindControl("chk_Add");

                        if (thedepartmentlabel.Text.Equals(thedepartmentofficewise.DepartmentID.ToString()))
                        {
                            if (thedepartmentofficewise.IsActive.Equals(true))
                                theCheckBox.Checked = true;
                            theOfficelabel.Text = thedepartmentofficewise.DepartmentOfficewiseID.ToString();

                            if (CurrentOfficeDepartments.Count > 1 && counter == CurrentOfficeDepartments.Count)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (counter == 1)
                            {
                                theOfficelabel.Text = "0";
                            }
                        }
                    }
                }
            }

            else
            {
                foreach (GridViewRow therow in gview_DepartmentSelect.Rows)
                {
                    Label thedesiglabel = (Label)therow.FindControl("lbl_DepartmentId");
                    Label theOfficelabel = (Label)therow.FindControl("lbl_DepartmentOfficeId");
                    CheckBox theCheckBox = (CheckBox)therow.FindControl("chk_Add");

                    theOfficelabel.Text = "0";
                }

            }
            BasePage.HideGridViewColumn(gview_DepartmentSelect, "DepartmentOfficeID");
            BasePage.HideGridViewColumn(gview_DepartmentSelect, "DepartmentID");
        }


		
		#endregion
	}
}