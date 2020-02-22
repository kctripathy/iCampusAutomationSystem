using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;


namespace Micro.BusinessLayer.HumanResource
{
    public partial class LeaveTypeOfficewiseManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static LeaveTypeOfficewiseManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static LeaveTypeOfficewiseManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LeaveTypeOfficewiseManagement();
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

        public int InsertLeaveTypeOfficewise(LeaveTypeOfficewise _LeaveTypeOfficewise)
        {
            try
            {
                return LeaveTypeOfficewiseIntegration.InsertLeaveTypeOfficewise(_LeaveTypeOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateLeaveTypeOfficewise(LeaveTypeOfficewise _LeaveTypeOfficewise)
        {
            try
            {
                return LeaveTypeOfficewiseIntegration.UpdateLeaveTypeOfficewise(_LeaveTypeOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteLeaveTypeOfficewise(int HolidayOfficwiseID)
        {
            try
            {
                return LeaveTypeOfficewiseIntegration.DeleteLeaveTypeOfficewise(HolidayOfficwiseID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public List<LeaveTypeOfficewise> GetLeaveTypeOfficewise(int OfficeID = -1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                return LeaveTypeOfficewiseIntegration.GetLeaveTypeOfficewiseByOfficeID();
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        //#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)

        //public Boolean FillLeaveTypeofficewise(Control Cnt, string searchText = null, bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = GetLeaveTypeOfficewise(); ; ;
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = GetLeaveTypeOfficewise(); 
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //#endregion
    }
}
