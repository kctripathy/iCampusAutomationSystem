using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;

namespace Micro.WebApplication.App_UserControls.Common
{
	public partial class UC_Address : BaseUserControl
	{
		#region Declaration

		public int SelectedCountryID
		{
			get
			{
				int RetVal = int.Parse(ddl_Country.SelectedValue.ToString());
				return RetVal;
			}
		}

		public int SelectedStateID
		{
			get
			{
				int RetVal = int.Parse(ddl_State.SelectedValue.ToString());
				return RetVal;
			}
		}
		public int StateID;

		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindCountryList();
			}
		}

		protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (int.Parse(ddl_Country.SelectedValue) > 0)
				{
					BindStateListByCountryID(int.Parse(ddl_Country.SelectedValue));
				}
			}
			catch
			{
				ResetControls();
			}
		}

		protected void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (int.Parse(ddl_State.SelectedValue) > 0)
				{
					StateID = ddl_State.SelectedIndex;
				}
				

			}
			catch
			{
				
			}
		}

		protected void txt_District_TextChanged(object sender, EventArgs e)
		{
		}

		#endregion

		#region Methods & Implementation

		private void BindCountryList()
		{
			List<Country> thisCountryList = CountryManagement.GetInstance.GetCountryList();

			if (thisCountryList.Count > 0)
			{
				ddl_Country.DataSource = thisCountryList;
				ddl_Country.DataValueField = CountryManagement.GetInstance.ValueMember;
				ddl_Country.DataTextField = CountryManagement.GetInstance.DisplayMember;
				ddl_Country.DataBind();
				ddl_Country.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
			}
		}

		private void BindStateListByCountryID(int CountryID)
		{
			List<State> ThisStateList = StateManagement.GetInstance.GetAllStatesByCountryId(CountryID);

			if (ThisStateList.Count > 0)
			{
				ddl_State.DataSource = ThisStateList;
				ddl_State.DataValueField = "StateID";
				ddl_State.DataTextField = "StateName";
				ddl_State.DataBind();
				ddl_State.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_ALL_ITEMTEXT));
			}
		}

		private void ResetControls()
		{
			ddl_State.DataSource = string.Empty;
			ddl_State.DataBind();
		}
		#endregion

		
	}
}