using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;


namespace Micro.BusinessLayer.HumanResource
{
    public partial class AttendanceAmendmentManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AttendanceAmendmentManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AttendanceAmendmentManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AttendanceAmendmentManagement();
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

        public static int InsertAttendanceAmendment(AttendanceAmendment _AttendanceAmendment)
        {
            try
            {
                return AttendanceAmendmentIntegration.InsertAttendanceAmendment(_AttendanceAmendment);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateAttendanceAmendment(AttendanceAmendment _AttendanceAmendment)
        {
            try
            {
                return AttendanceAmendmentIntegration.UpdateAttendanceAmendment(_AttendanceAmendment);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int ApproveOrRejectAttendanceAmendment(AttendanceAmendment _AttendanceAmendment)
        {
            try
            {
                return AttendanceAmendmentIntegration.ApproveOrRejectAttendanceAmendment(_AttendanceAmendment);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeletetAttendanceAmendment(AttendanceAmendment _AttendanceAmendment)
        {
            try
            {
                return AttendanceAmendmentIntegration.DeletetAttendanceAmendment(_AttendanceAmendment);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
      
        #endregion

        #region Data Retrive Mathods

        public static AttendanceAmendment GetAttendanceAmendmentByAttendanceAmendmentID(int AttendanceAmendmentID)
        {
            try
            {
                return AttendanceAmendmentIntegration.GetAttendanceAmendmentByAttendanceAmendmentID(AttendanceAmendmentID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<AttendanceAmendment> GetAttendanceAmendmentsByEmployee(int EmployeeID)
        {
            try
            {
                return AttendanceAmendmentIntegration.GetAttendanceAmendmentsByEmployee(EmployeeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<AttendanceAmendment> GetPendingAttendanceAmendmentsByEmployee(int EmployeeID)
        {
            try
            {
                return AttendanceAmendmentIntegration.GetPendingAttendanceAmendmentsByEmployee(EmployeeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<AttendanceAmendment> GetPendingAttendanceAmendmentsAll()
        {
            try
            {
                return AttendanceAmendmentIntegration.GetPendingAttendanceAmendmentsAll();
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<AttendanceAmendment> GetAttendanceAmendmentsAll(string searchText = "", bool showDeleted = false)
        {
            try
            {
                return AttendanceAmendmentIntegration.GetAttendanceAmendmentsAll(searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }


        /// <summary>
        /// ReportingOfficer wise
        /// </summary>
        public static List<AttendanceAmendment> GetPeningAttendanceAmendmentApplicationsByReportingEmployee(int EmployeeID = -1)
        {
            try
            {
                return AttendanceAmendmentIntegration.GetPeningAttendanceAmendmentApplicationsByReportingEmployee(EmployeeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

         #endregion

        //#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)

        //public static Boolean FillAttendanceAmendmentsByEmployee(int EmployeeID, Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = AttendanceAmendmentManagement.GetAttendanceAmendmentsByEmployee(EmployeeID);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = AttendanceAmendmentManagement.GetAttendanceAmendmentsByEmployee(EmployeeID);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillPendingAttendanceAmendmentsByEmployee(int EmployeeID, Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = AttendanceAmendmentManagement.GetPendingAttendanceAmendmentsByEmployee(EmployeeID);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = AttendanceAmendmentManagement.GetPendingAttendanceAmendmentsByEmployee(EmployeeID);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillPendingAttendanceAmendmentsAll(Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = AttendanceAmendmentManagement.GetPendingAttendanceAmendmentsAll();
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = AttendanceAmendmentManagement.GetPendingAttendanceAmendmentsAll();
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillAttendanceAmendmentsAll(Control Cnt, string searchText = "", bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = AttendanceAmendmentManagement.GetAttendanceAmendmentsAll(searchText, showDeleted);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "AttendanceTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = AttendanceAmendmentManagement.GetAttendanceAmendmentsAll(searchText, showDeleted);
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
