using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;


namespace Micro.BusinessLayer.HumanResource
{
    public partial class AttendanceApplicationManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AttendanceApplicationManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AttendanceApplicationManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AttendanceApplicationManagement();
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
       
        public static int InsertAttendanceApplication(AttendanceApplication _AttendanceApplication)
        {
            try
            {
                return AttendanceApplicationIntegration.InsertAttendanceApplication(_AttendanceApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateAttendanceApplication(AttendanceApplication _AttendanceApplication)
        {
            try
            {
                return AttendanceApplicationIntegration.UpdateAttendanceApplication(_AttendanceApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int ApproveOrRejectAttendanceApplication(AttendanceApplication _AttendanceApplication)
        {
            try
            {
                return AttendanceApplicationIntegration.ApproveOrRejectAttendanceApplication(_AttendanceApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeletetAttendanceApplication(AttendanceApplication _AttendanceApplication)
        {
            try
            {
                return AttendanceApplicationIntegration.DeletetAttendanceApplication(_AttendanceApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static AttendanceApplication GetAttendanceApplicationByAttendanceApplicationID(int AttendanceApplicationID)
        {
            try
            {
                return AttendanceApplicationIntegration.GetAttendanceApplicationByAttendanceApplicationID(AttendanceApplicationID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<AttendanceApplication> GetAttendanceApplicationsByEmployee(int EmployeeID, string searchText = "", bool showDeleted = false)
        {
            try
            {
                return AttendanceApplicationIntegration.GetAttendanceApplicationsByEmployee(EmployeeID, searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<AttendanceApplication> GetPendingAttendanceApplicationsByEmployee(int EmployeeID)
        {
            try
            {
                return AttendanceApplicationIntegration.GetPendingAttendanceApplicationsByEmployee(EmployeeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<AttendanceApplication> GetPendingAttendanceApplicationsAll()
        {
            try
            {

                return AttendanceApplicationIntegration.GetPendingAttendanceApplicationsAll();
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<AttendanceApplication> GetAttendanceApplicationsAll(string searchText = "", bool showDeleted = false)
        {
            try
            {
                return AttendanceApplicationIntegration.GetAttendanceApplicationsAll(searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// ReportingOfficer wise
        /// </summary>
        public static List<AttendanceApplication> GetPeningAttendanceApplicationsByReportingEmployee(int EmployeeID = -1)
        {
            try
            {
                return AttendanceApplicationIntegration.GetPeningAttendanceAmendmentApplicationsByReportingEmployee(EmployeeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        //#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)

        //public static Boolean FillAttendanceApplicationsByEmployee(int EmployeeID, Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = AttendanceApplicationManagement.GetAttendanceApplicationsByEmployee(EmployeeID);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = AttendanceApplicationManagement.GetAttendanceApplicationsByEmployee(EmployeeID);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillPendingAttendanceApplicationsByEmployee(int EmployeeID, Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = AttendanceApplicationManagement.GetPendingAttendanceApplicationsByEmployee(EmployeeID);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = AttendanceApplicationManagement.GetPendingAttendanceApplicationsByEmployee(EmployeeID);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillPendingAttendanceApplicationsAll(Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = AttendanceApplicationManagement.GetPendingAttendanceApplicationsAll();
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = AttendanceApplicationManagement.GetPendingAttendanceApplicationsAll();
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillAttendanceApplicationsAll(Control Cnt, string searchText = "", bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = AttendanceApplicationManagement.GetAttendanceApplicationsAll(searchText, showDeleted);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = AttendanceApplicationManagement.GetAttendanceApplicationsAll(searchText, showDeleted);
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
