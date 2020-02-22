using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.HumanResource;
using Micro.Objects.HumanResource;
using Micro.Commons;

namespace Micro.WebApplication.MicroERP.HRMS
{
    /// <summary>
    /// view details of Employee.
    /// </summary>
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        #region Declaration
        protected class PageVariables
        {
            public static int TheEmployeeID;
            public static List<Employee> TheEmployeeList;
            public static Micro.Commons.BasePage.ProfileImage TheProfileImage;

            public static EmployeeProfile ThisEmployeeProfile;
            public static List<Employee> EmployeeList;
            public static int EmployeeID;
            public static string EmployeeName;
            public static string SettingKeyName = MicroEnums.CommonKeyNames.EmployeeProfile.GetStringValue();
            public static string SettingKeyDescription;
            public static int officeID;

        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            UC_SelectMicroOffice.TheUserId = Micro.Commons.Connection.LoggedOnUser.UserID;
            UC_SelectMicroOffice.OnSelectedIndexChanged += Bind_Employee;
            ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
            if (!IsPostBack)
            {
                ctrl_Search.SearchWhat = MicroEnums.SearchForm.Employee.GetStringValue();
                PageVariables.TheEmployeeList = null;
            }
            
        }
        protected void gView_EmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                int EmployeeID = int.Parse(((Label)gView_EmployeeList.Rows[RowIndex].FindControl("lbl_EmployeeID")).Text);

                if (e.CommandName.Equals("Select"))
                {
                    PopulateEmployeeDetails(EmployeeID);
                    PopulateProfileDetails(EmployeeID.ToString());
                }

            }
            catch
            {

            }
        }

        protected void gView_EmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gView_EmployeeList.PageIndex = e.NewPageIndex;
            BindGridView(PageVariables.EmployeeList);
        }

        protected void searchCtrl_ButtonClicked(object sender, EventArgs e)
        {
            try
            {
                PageVariables.EmployeeList = SearchEmployeetBindGridView();
                ctrl_Search.SearchResultCount = PageVariables.EmployeeList.Count.ToString();
            }
            catch
            {
            }
        }
        #endregion

        #region Methods & Implementation

        private void FillGridView(int OfficeID)
        {
            gView_EmployeeList.DataSource = null;
            gView_EmployeeList.DataBind();
            PageVariables.TheEmployeeList = EmployeeManagement.GetInstance.GetEmployeesListbyofficeid(OfficeID);
            if (PageVariables.TheEmployeeList.Count > 0)
            {
                gView_EmployeeList.DataSource = PageVariables.TheEmployeeList;
                gView_EmployeeList.DataBind();
            }
        }

        private void PopulateEmployeeDetails(int TheEmployeeID)
        {
            Employee theEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(TheEmployeeID);
            if (theEmployee.EmployeeFirstName != "")
            {
                lbl_EmployeeNameText.Text = theEmployee.EmployeeFirstName + theEmployee.EmployeeLastName;
            }
            else
            {
                lbl_EmployeeNameText.Text = "N/A";
            }
            if (theEmployee.EmployeeCode != "")
            {
                lbl_EmployeeCodeText.Text = theEmployee.EmployeeCode;
            }
            else
            {
                lbl_EmployeeCodeText.Text = "N/A";
            }
            if (theEmployee.FatherName != "")
            {
                lbl_FatherNameText.Text = theEmployee.FatherName;
            }
            else
            {
                lbl_FatherNameText.Text = "N/A";
            }
            if (theEmployee.Gender != "")
            {
                lbl_GenderText.Text = theEmployee.Gender;
            }
            else
            {
                lbl_GenderText.Text = "N/A";
            }
            if (theEmployee.Mobile != "")
            {
                lbl_MobileText.Text = theEmployee.Mobile;
            }
            else
            {
                lbl_MobileText.Text = "N/A";
            }
            if (theEmployee.Address_Present_TownOrCity != "")
            {
                lbl_PresentAddressText.Text = theEmployee.Address_Present_TownOrCity;
            }
            else
            {
                lbl_PresentAddressText.Text = "N/A";
            }
        }

        private void PopulateProfileDetails(string EmployeeID)
        {
            string SettingKeyName = "Customer Profile Policy";
            string SettingKeyDescription = "Photo";
            string SettingKeyDescriptionSignature = "Signature";

            PageVariables.TheProfileImage = new Micro.Commons.BasePage.ProfileImage();
            PageVariables.TheProfileImage.ImageUrl = Micro.Commons.BasePage.GetProfileImageUrl("1", SettingKeyName, SettingKeyDescription);

            img_ProfileImage.ImageUrl = PageVariables.TheProfileImage.ImageUrl;
            PageVariables.TheProfileImage.ImageUrl = Micro.Commons.BasePage.GetProfileImageUrl("1", SettingKeyName, SettingKeyDescriptionSignature);
            img_Signature.ImageUrl = PageVariables.TheProfileImage.ImageUrl;

            img_ProfileImage.ImageUrl = PageVariables.TheProfileImage.ImageUrl;
        }

        private void Bind_Employee(object sender, System.EventArgs e)
        {
            ResetEmployeeGridView();
            ResetLabels();
            PageVariables.officeID = UC_SelectMicroOffice.SelectedOfficeID;
            if (PageVariables.officeID > 0)
            {
                FillGridView(PageVariables.officeID);
            }
            else
            {
                ResetEmployeeGridView();
                ResetLabels();
            }
        }

        private List<Employee> SearchEmployeetBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            List<Employee> SearchList = new List<Employee>();
            // Search by name
            if (PageVariables.TheEmployeeList != null)
            {
                if (PageVariables.TheEmployeeList.Count > 0)
                {
                    if (searchField == MicroEnums.SearchEmployee.EmployeeName.ToString())
                    {
                        if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                        {
                            SearchList = (from empName in PageVariables.TheEmployeeList
                                          where empName.EmployeeName.ToUpper().StartsWith(searchText.ToUpper())
                                          select empName).ToList();
                        }

                        if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                        {
                            SearchList = (from empName in PageVariables.TheEmployeeList
                                          where empName.EmployeeName.ToUpper().Contains(searchText.ToUpper())
                                          select empName).ToList();
                        }
                    }
                    // Search by code
                    if (searchField == MicroEnums.SearchEmployee.EmployeeCode.ToString())
                    {
                        if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                        {
                            SearchList = (from empCode in PageVariables.TheEmployeeList
                                          where empCode.EmployeeCode.ToUpper().StartsWith(searchText.ToUpper())
                                          select empCode).ToList();
                        }

                        if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                        {
                            SearchList = (from empCode in PageVariables.TheEmployeeList
                                          where empCode.EmployeeCode.ToUpper().Contains(searchText.ToUpper())
                                          select empCode).ToList();
                        }
                    }
                }

            }
            // Dispaly the search result
            ctrl_Search.SearchResultCount = SearchList.Count.ToString();
            gView_EmployeeList.DataSource = SearchList;
            gView_EmployeeList.DataBind();
            return SearchList;
        }

        private void ResetEmployeeGridView()
        {
            gView_EmployeeList.DataSource = null;
            gView_EmployeeList.DataBind();
        }

        private void ResetLabels()
        {
            lbl_EmployeeNameText.Text = "N/A";
            lbl_EmployeeCodeText.Text = "N/A";
            lbl_FatherNameText.Text = "N/A";
            lbl_GenderText.Text = "N/A";
            lbl_MobileText.Text = "N/A";
            lbl_PresentAddressText.Text = "N/A";
            lbl_DOBText.Text = "N/A";
            lbl_AgeText.Text = "N/A";
        }

        private void BindGridView(List<Employee> EmployeeList = null)
        {
            gView_EmployeeList.DataSource = null;
            gView_EmployeeList.DataBind();

            if (EmployeeList == null)
            {
                PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetEmployeeList();
                EmployeeList = PageVariables.EmployeeList;
            }

            if (EmployeeList.Count > 0)
            {
                gView_EmployeeList.DataSource = EmployeeList;
                gView_EmployeeList.DataBind();
            }
        }
        #endregion
    }
}