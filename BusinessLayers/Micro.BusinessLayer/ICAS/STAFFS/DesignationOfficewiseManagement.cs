using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using Micro.IntegrationLayer.ICAS.STAFFS;
using System.Reflection;

namespace Micro.BusinessLayer.ICAS.STAFFS
{
  public partial  class DesignationOfficewiseManagement
    {

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DesignationOfficewiseManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DesignationOfficewiseManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DesignationOfficewiseManagement();
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

        //public int InsertDesignationOfficewise(string DesignationIds)
        //{
        //    try
        //    {
        //        return DesignationOfficewiseIntegration.InsertDesignationOfficewise(DesignationIds);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}
        public int InsertDesignationOfficewise(DesignationOfficewise _DesignationOfficewise)
        {
            try
            {
                return DesignationOfficewiseIntegration.InsertDesignationOfficewise(_DesignationOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public int UpdateDesignationOfficewise(DesignationOfficewise _DesignationOfficewise)
        {
            try
            {
                return DesignationOfficewiseIntegration.UpdateDesignationOfficewise(_DesignationOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteDesignationOfficewise(int HolidayOfficwiseID)
        {
            try
            {
                return DesignationOfficewiseIntegration.DeleteDesignationOfficewise(HolidayOfficwiseID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public List<DesignationOfficewise> GetDesignationOfficewiseByOfficeID(int OfficeID = -1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                return DesignationOfficewiseIntegration.GetDesignationOfficewiseByOfficeID(OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

       
    }
}
