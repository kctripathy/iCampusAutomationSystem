using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;


namespace Micro.BusinessLayer.HumanResource
{
    public partial class LeaveTypeManagement

    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static LeaveTypeManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static LeaveTypeManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LeaveTypeManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertLeaveType(LeaveType theLeaveType)
        {
            try
            {
                return LeaveTypeIntegration.InsertLeaveType(theLeaveType);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
          }

        public int UpdateLeaveType(LeaveType theLeaveType)
        {
            try
            {
                return LeaveTypeIntegration.UpdateLeaveType(theLeaveType);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteLeaveType(int LeaveTypeID)
        {
            try
            {
                return LeaveTypeIntegration.DeleteLeaveType(LeaveTypeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }  
        }

        #endregion

        #region Data Retrive Mathods

        public LeaveType GetLeaveTypeById(int LeaveTypeID)
        {
            try
            {
                return LeaveTypeIntegration.GetLeaveTypeByID(LeaveTypeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<LeaveType> GetLeaveTypeList(string searchText = null, bool showDeleted = false)
        {
            try
            {
                return LeaveTypeIntegration.GetLeaveTypeList(searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        //#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)

        //public Boolean FillLeaveTypeList(Control Cnt, string searchText = null, bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = LeaveTypeManagement.GetInstance.GetLeaveTypeList();
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = LeaveTypeManagement.GetInstance.GetLeaveTypeList();
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
