using System;
using System.Collections.Generic;
using System.Reflection;
using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;

namespace Micro.BusinessLayer.HumanResource
{
    public partial class HolidayOfficewiseManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static HolidayOfficewiseManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static HolidayOfficewiseManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HolidayOfficewiseManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertHolidayOfficewise(HolidayOfficewise _HolidayOfficewise)
        {
            try
            {
                return HolidayOfficewiseIntegration.InsertHolidayOfficewise(_HolidayOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateHolidayOfficewise(HolidayOfficewise _HolidayOfficewise)
        {
            try
            {
                return HolidayOfficewiseIntegration.UpdateHolidayOfficewise(_HolidayOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteHolidayOfficewise(int HolidayOfficwiseID)
        {
            try
            {
                return HolidayOfficewiseIntegration.DeleteHolidayOfficewise(HolidayOfficwiseID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public List<HolidayOfficewise> GetHolidayOfficewiseByOfficeIDandCalenderYear(int CalenderYear, int OfficeID= -1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                return HolidayOfficewiseIntegration.GetHolidayOfficewiseByOfficeIDandCalenderYear(CalenderYear, OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)
        #endregion
    }
}
