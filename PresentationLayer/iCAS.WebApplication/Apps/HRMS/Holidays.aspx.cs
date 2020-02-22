using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.HumanResource;
using Micro.BusinessLayer.HumanResource;
using Micro.Framework.ReadXML;
using System.Web;
using Micro.BusinessLayer.Administration;

namespace Micro.WebApplication.MicroERP.HRMS
{
	/// <summary>
	/// view,add,edit & delete in holidays
	/// </summary>
	
	public partial class Holidays : BasePage
	{
		# region Events
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                BindGridViewOfficeHolidays();

            }

        }
        #endregion

        #region Methods & Implementation

        public void BindGridViewOfficeHolidays()
        {
            List<Holiday> AllHolidays = new List<Holiday>();
            AllHolidays = HolidayManagement.GetInstance.GetAllHolidays();
            int year = System.DateTime.Now.Year;

            List<HolidayOfficewise> CurrentOfficeHolidays = new List<HolidayOfficewise>();
            CurrentOfficeHolidays = HolidayOfficewiseManagement.GetInstance.GetHolidayOfficewiseByOfficeIDandCalenderYear(year);

            gview_HolidayDetails.DataSource = CurrentOfficeHolidays;
            gview_HolidayDetails.DataBind();

        }
        #endregion
    }
}