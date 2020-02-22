#region System Namespace

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

#endregion

#region Micro Namespaces

using Micro.Objects.HumanResource;
using Micro.DataAccessLayer.HumanResource;


#endregion

namespace Micro.IntegrationLayer.HumanResource
{
    public partial class HolidayOfficewiseIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertHolidayOfficewise(HolidayOfficewise _HolidayOfficewise)
        {
            try
            {
                return HolidayOfficewiseDataAccess.GetInstance.InsertHolidayOfficewise(_HolidayOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateHolidayOfficewise(HolidayOfficewise _HolidayOfficewise)
        {
            try
            {
                return HolidayOfficewiseDataAccess.GetInstance.UpdateHolidayOfficewise(_HolidayOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteHolidayOfficewise(int HolidayOfficewiseID)
        {
            try
            {
                return HolidayOfficewiseDataAccess.GetInstance.DeleteHolidayOfficewise(HolidayOfficewiseID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static List<HolidayOfficewise> GetHolidayOfficewiseByOfficeIDandCalenderYear(int CalenderYear, int OfficeID , string searchText="a" ,bool showDeleted = false)
        {
            try
            {
                DataTable HolidayOfficewiseRows = HolidayOfficewiseDataAccess.GetInstance.GetHolidayOfficewiseByOfficeIDandCalenderYear(CalenderYear, OfficeID, searchText, showDeleted);

                List<HolidayOfficewise> _HolidayOfficewiseList = new List<HolidayOfficewise>();

                foreach (DataRow dr in HolidayOfficewiseRows.Rows)
                {
                    HolidayOfficewise _HolidayOfficewise = new HolidayOfficewise();
                    _HolidayOfficewise.HolidayOfficewiseID = int.Parse(dr["HolidaysOfficewiseID"].ToString());
                    _HolidayOfficewise.HolidayID = int.Parse(dr["HolidayID"].ToString());
                    
                    _HolidayOfficewise.DateOfOccasion = DateTime.Parse(dr["DateOfOccasion"].ToString());
                    _HolidayOfficewise.WeekDayOfOccasion = _HolidayOfficewise.DateOfOccasion.DayOfWeek.ToString();
                    _HolidayOfficewise.Occasion = dr["Occasion"].ToString();

                    _HolidayOfficewise.Office.OfficeID = int.Parse(dr["OfficeID"].ToString());

                    _HolidayOfficewise.IsActive = Boolean.Parse(dr["IsActive"].ToString());
                    _HolidayOfficewise.IsDeleted = Boolean.Parse(dr["IsDeleted"].ToString());

                    _HolidayOfficewiseList.Add(_HolidayOfficewise);
                }

                return _HolidayOfficewiseList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
