using System;
using System.Collections.Generic;
using System.Reflection;
using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;

namespace Micro.BusinessLayer.HumanResource
{
    public partial class ShiftOfficewiseManagement
    {

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ShiftOfficewiseManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ShiftOfficewiseManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ShiftOfficewiseManagement();
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

        public int InsertShiftOfficewise(ShiftOfficewise _ShiftOfficewise)
        {
            try
            {
                return ShiftOfficewiseIntegration.InsertShiftOfficewise(_ShiftOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateShiftOfficewise(ShiftOfficewise _ShiftOfficewise)
        {
            try
            {
                return ShiftOfficewiseIntegration.UpdateShiftOfficewise(_ShiftOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteShiftOfficewise(int HolidayOfficwiseID)
        {
            try
            {
                return ShiftOfficewiseIntegration.DeleteShiftOfficewise(HolidayOfficwiseID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        #endregion

        #region Data Retrive Mathods

        public List<ShiftOfficewise> GetShiftOfficewiseByOfficeID(int OfficeID = -1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                return ShiftOfficewiseIntegration.GetShiftOfficewiseByOfficeID(OfficeID);
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
