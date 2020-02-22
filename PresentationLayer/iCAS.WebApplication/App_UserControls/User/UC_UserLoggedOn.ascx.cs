using System;
using Micro.BusinessLayer.CustomerRelation;
using Micro.BusinessLayer.HumanResource;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.Objects.CustomerRelation;
using Micro.Objects.HumanResource;
using System.Collections.Generic;
using System.Configuration;

namespace Micro.WebApplication.App_UserControls
{
	public partial class UC_UserLoggedOn : System.Web.UI.UserControl
	{
		#region Declarations
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                lit_today.Text = string.Format("Today: {0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
                
				PopulateLoggedOnUserInformation();
			}
		}

		#endregion

		#region Methods & Implementations
		private void PopulateLoggedOnUserInformation()
		{
			User TheLoggedOnUser = Micro.Commons.Connection.LoggedOnUser;
			string UserName, FullName, Designation, Location;
			UserName = MicroConstants.LABEL_DEFAULT_TEXT;
			FullName = MicroConstants.LABEL_DEFAULT_TEXT;
			Designation = MicroConstants.LABEL_DEFAULT_TEXT;
			Location = MicroConstants.LABEL_DEFAULT_TEXT;

			if (TheLoggedOnUser == null)
			{
				// DO NOTHING
				// REDIRECT TO LOGIN PAGE
			}
			else
			{
				//TheLoggedOnUser = (User)Session["CurrentUser"];

				UserName = String.Format("{0} ({1})", TheLoggedOnUser.UserName, TheLoggedOnUser.RoleDescription);
				FullName = TheLoggedOnUser.UserReferenceName;

				if (TheLoggedOnUser.UserType == MicroEnums.UserType.FieldForce.GetStringValue())
				{
					FieldForce f = FieldForceManagement.GetInstance.GetFieldForceById(TheLoggedOnUser.UserReferenceID);
					Designation = f.FieldForceRankDescription;
					Location = f.OfficeName;
				}
				else if (TheLoggedOnUser.UserType == MicroEnums.UserType.Employee.GetStringValue())
				{
					Employee emp = EmployeeManagement.GetInstance.GetEmployeeByID(TheLoggedOnUser.UserReferenceID);
					Designation = emp.DesignationDescription;
					Location = emp.OfficeName;
				}

				lbl_UserNameValue.Text = UserName.ToUpper();
				lbl_FullNameValue.Text = FullName.ToUpper();
				lbl_DesignationValue.Text = Helpers.ToCapitalize(Designation);
				lbl_OfficeValue.Text = Location;

				//List<Office> TheOfficeList = Micro.BusinessLayer.Administration.OfficeManagement.GetInstance.GetOfficeTreeByUserID(TheLoggedOnUser.UserID);
				//if (TheOfficeList != null)
				//{
				//    if (TheOfficeList.Count > 0)
				//    {
				//        lbl_OfficeValue.Text = String.Format("{0} / {1}", TheOfficeList[0].OfficeName, TheOfficeList[0].ParentOfficeName);
				//    }
				//}

			}
		#endregion
		}
	}
}