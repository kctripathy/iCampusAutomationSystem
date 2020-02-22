using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using Micro.IntegrationLayer.ICAS.STAFFS;
using System.Reflection;
using System.Windows.Forms;

namespace Micro.BusinessLayer.ICAS.STAFFS
{
  public partial  class LeaveBalanceManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static LeaveBalanceManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static LeaveBalanceManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LeaveBalanceManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Data Retrive Mathods

        public static List<LeaveTypeSettings> GetLeaveBalanceByEmployee(int EmployeeID)
        {
            try
            {
                return LeaveBalanceIntegration.GetLeaveBalanceByEmployee(EmployeeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        #endregion

        //#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)

        //public static Boolean FillLeaveBalanceByEmployee(int EmployeeID, Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = LeaveBalanceManagement.GetLeaveBalanceByEmployee(EmployeeID);
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
