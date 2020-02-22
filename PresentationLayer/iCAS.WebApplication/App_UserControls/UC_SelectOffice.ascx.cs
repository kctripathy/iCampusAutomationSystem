using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Objects.CustomerRelation;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using Micro.Commons;

namespace Micro.WebApplication.App_UserControls
{
    public partial class UC_SelectOffice : System.Web.UI.UserControl
    {
        #region Declaration
        protected static class PageVariables
        {
            public static List<OfficeType> TheOfficeTypeList;
            public static List<Office> ThisUserOfficeList;
            public static List<OfficeType> ThisUserOfficeTypeList;
        }
        public int TheUserId
        {
            get;
            set;
        }

        public int SelectedOfficeID
        {
			get
			{
				int RetVal = int.Parse(ddl_OfficeName.SelectedValue.ToString());
				return RetVal;
			}
        }

		public int SelectedOfficeTypeID
		{
			get
			{
				int RetVal = int.Parse(ddl_OfficeType.SelectedValue.ToString());
				return RetVal;
			}
		}

		public string TheLabel
		{
			get
			{
				return lbl_OfficeType.Text;
			}
			set
			{
				lbl_OfficeType.Text = value;
			}

		}
		
        public event EventHandler OnSelectedIndexChanged;

        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserOfficeTypeList();
            }
        }

        protected void ddl_OfficeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
				if (int.Parse(ddl_OfficeType.SelectedValue) > 0)
				{
					BindUserOfficeListByOfficeType(int.Parse(ddl_OfficeType.SelectedValue));
				}
            }
            catch
            {
				ResetOfficeName();
            }
        }

		protected void ddl_OfficeName_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddl_OfficeName.SelectedIndex > 0)
			{
				//SelectedOfficeID = int.Parse(ddl_OfficeName.SelectedItem.Value);
				SelectedIndexedChange(sender, e);
			}
			else
			{
				//SelectedOfficeID = 0;
				SelectedIndexedChange(sender, e);
			}
		}

		protected virtual void SelectedIndexedChange(object sender, EventArgs e)
		{
			if (this.OnSelectedIndexChanged != null)
			{
				this.OnSelectedIndexChanged(sender, e);
			}
		}
        #endregion

        #region Methods & Implementation
        private List<OfficeType> GetUserOfficeTypeList()
        {
            int UserID = Connection.LoggedOnUser.UserID;
            PageVariables.ThisUserOfficeList = OfficeManagement.GetInstance.GetOfficeListByUserID(UserID);
			
            List<OfficeType> OfficeTypeList = OfficeTypeManagement.GetInstance.GetOfficeTypesByCompanyID(Micro.Commons.Connection.LoggedOnUser.CompanyID);


            if (OfficeTypeList.Count > 0)
            {
                PageVariables.ThisUserOfficeTypeList = (from OfficeList in OfficeTypeList
                                                        where (PageVariables.ThisUserOfficeList.Select(TheOffice => TheOffice.OfficeTypeID).Distinct()).Contains(OfficeList.OfficeTypeID)
                                                        select OfficeList).ToList();

            }
            else
            {
                PageVariables.ThisUserOfficeTypeList = new List<OfficeType>();
            }

            return PageVariables.ThisUserOfficeTypeList;
        }

        private void BindUserOfficeTypeList()
        {
            List<OfficeType> thisUserOfficeTypeList = GetUserOfficeTypeList();

            if (thisUserOfficeTypeList.Count > 0)
            {
                ddl_OfficeType.DataSource = GetUserOfficeTypeList();
                ddl_OfficeType.DataValueField = OfficeTypeManagement.GetInstance.ValueMember;
                ddl_OfficeType.DataTextField = OfficeTypeManagement.GetInstance.DisplayMember;
                ddl_OfficeType.DataBind();
				ddl_OfficeType.Items.RemoveAt(0);
				//ddl_OfficeType.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
				ddl_OfficeType.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_ALL_ITEMTEXT));
            }
        }

        private void BindUserOfficeListByOfficeType(int thisUserOfficeTypeID)
        {
            if (thisUserOfficeTypeID > 0)
            {
                ddl_OfficeName.DataSource = GetUserOfficeList(thisUserOfficeTypeID);
                ddl_OfficeName.DataValueField = OfficeManagement.GetInstance.ValueMember;
                ddl_OfficeName.DataTextField = OfficeManagement.GetInstance.DisplayMember;
                ddl_OfficeName.DataBind();
				ddl_OfficeName.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_ALL_ITEMTEXT));
            }
        }

        private List<Office> GetUserOfficeList(int thisUserOfficeTypeID)
        {
            List<Office> TheUserOfficeList;

            if (PageVariables.ThisUserOfficeList.Count > 0)
            {
                TheUserOfficeList = PageVariables.ThisUserOfficeList.Where(OfficeList => OfficeList.OfficeTypeID == thisUserOfficeTypeID).ToList();
            }
            else
            {
                TheUserOfficeList = new List<Office>();
            }

            return TheUserOfficeList;
        }

		private void ResetOfficeName()
		{
			ddl_OfficeName.DataSource = "";
			ddl_OfficeName.DataBind();
		}
        #endregion
    }
}