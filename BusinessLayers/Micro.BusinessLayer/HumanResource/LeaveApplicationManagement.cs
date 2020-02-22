using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;


namespace Micro.BusinessLayer.HumanResource
{
    public partial class LeaveApplicationManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static LeaveApplicationManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static LeaveApplicationManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LeaveApplicationManagement();
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

        public static int InsertLeaveApplication(LeaveApplication _LeaveApplication)
        {
            try
            {
                return LeaveApplicationIntegration.InsertLeaveApplication(_LeaveApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public static int UpdateLeaveApplication(LeaveApplication _LeaveApplication)
        {
            try
            {
                return LeaveApplicationIntegration.UpdateLeaveApplication(_LeaveApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int ApproveOrRejectLeaveApplication(LeaveApplication _LeaveApplication)
        {
            try
            {
                return LeaveApplicationIntegration.ApproveOrRejectLeaveApplication(_LeaveApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeletetLeaveApplication(LeaveApplication _LeaveApplication)
        {
            try
            {
                return LeaveApplicationIntegration.DeletetLeaveApplication(_LeaveApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        /// <summary>
        /// Leave Applicationwise
        /// </summary>
        public static LeaveApplication GetLeaveApplicationByLeaveApplicationID(int LeaveApplicationID)
        {
            try
            {
                return LeaveApplicationIntegration.GetLeaveApplicationByLeaveApplicationID(LeaveApplicationID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Employeewise
        /// </summary>
        public static List<LeaveApplication> GetEmployeeLeaveApplicationsAll(int EmployeeID)
        {
            try
            {
                return LeaveApplicationIntegration.GetEmployeeLeaveApplicationsAll(EmployeeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetEmployeeLeaveApplicationsAll(int EmployeeID, DateTime DateFrom)
        {
            try
            {
                return LeaveApplicationIntegration.GetEmployeeLeaveApplicationsAll(EmployeeID, DateFrom);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetEmployeeLeaveApplicationsAll(int EmployeeID, DateTime DateFrom,DateTime DateTo)
        {
            try
            {
                return LeaveApplicationIntegration.GetEmployeeLeaveApplicationsAll(EmployeeID, DateFrom,DateTo);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Employee Pending
        /// </summary>
        public static List<LeaveApplication> GetEmployeePendingLeaveApplicationsAll(int EmployeeID)
        {
            try
            {
                return LeaveApplicationIntegration.GetEmployeePendingLeaveApplicationsAll(EmployeeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetEmployeePendingLeaveApplicationsAll(int EmployeeID, DateTime DateFrom)
        {
            try
            {

                return LeaveApplicationIntegration.GetEmployeePendingLeaveApplicationsAll(EmployeeID, DateFrom);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetEmployeePendingLeaveApplicationsAll(int EmployeeID, DateTime DateFrom, DateTime DateTo)
        {
            try
            {

                return LeaveApplicationIntegration.GetEmployeePendingLeaveApplicationsAll(EmployeeID, DateFrom, DateTo);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Officewise Pending Applications
        /// </summary>
        public static List<LeaveApplication> GetOfficePendingLeaveApplicationsAll(int OfficeID=-1)
        {
            try
            {
                return LeaveApplicationIntegration.GetOfficePendingLeaveApplicationsAll(OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetOfficePendingLeaveApplicationsAll(DateTime DateFrom, int OfficeID = -1)
        {
            try
            {
                return LeaveApplicationIntegration.GetOfficePendingLeaveApplicationsAll(DateFrom,OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetOfficePendingLeaveApplicationsAll(DateTime DateFrom, DateTime DateTo, int OfficeID = -1)
        {
            try
            {
                return LeaveApplicationIntegration.GetOfficePendingLeaveApplicationsAll(DateFrom, DateTo,OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Officewise Applications
        /// </summary>

        public static List<LeaveApplication> GetOfficeLeaveApplicationsAll(int OfficeID=-1)
        {
            try
            {
                return LeaveApplicationIntegration.GetOfficeLeaveApplicationsAll(OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetOfficeLeaveApplicationsAll(DateTime DateFrom, int OfficeID = -1)
        {
            try
            {
                return LeaveApplicationIntegration.GetOfficeLeaveApplicationsAll(DateFrom,OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetOfficeLeaveApplicationsAll(DateTime DateFrom, DateTime DateTo, int OfficeID = -1)
        {
            try
            {
                return LeaveApplicationIntegration.GetOfficeLeaveApplicationsAll(DateFrom, DateTo,OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Departmentwise Pending Applications
        /// </summary>
        public static List<LeaveApplication> GetDepartmentPendingLeaveApplicationsAll(int DepartmenID, int OfficeID = -1)
        {
            try
            {
                return LeaveApplicationIntegration.GetDepartmentPendingLeaveApplicationsAll(DepartmenID, OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetDepartmentPendingLeaveApplicationsAll(int DepartmenID,DateTime DateFrom, int OfficeID = -1)
        {
            try
            {
                return LeaveApplicationIntegration.GetDepartmentPendingLeaveApplicationsAll(DepartmenID,DateFrom, OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetDepartmentPendingLeaveApplicationsAll(int DepartmenID,DateTime DateFrom, DateTime DateTo, int OfficeID = -1)
        {
            try
            {
                return LeaveApplicationIntegration.GetDepartmentPendingLeaveApplicationsAll(DepartmenID,DateFrom, DateTo, OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }


        /// <summary>
        /// Departmentwise Leave Applications
        /// </summary>
        public static List<LeaveApplication> GetDepartmentLeaveApplicationsAll(int DepartmenID, int OfficeID = -1)
        {
            try
            {
                return LeaveApplicationIntegration.GetDepartmentLeaveApplicationsAll(DepartmenID, OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetDepartmentLeaveApplicationsAll(int DepartmenID, DateTime DateFrom, int OfficeID = -1)
        {
            try
            {
                return LeaveApplicationIntegration.GetDepartmentLeaveApplicationsAll(DepartmenID, DateFrom, OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetDepartmentLeaveApplicationsAll(int DepartmenID, DateTime DateFrom, DateTime DateTo, int OfficeID = -1)
        {
            try
            {
                return LeaveApplicationIntegration.GetDepartmentLeaveApplicationsAll(DepartmenID, DateFrom, DateTo, OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// ReportingOfficer wise
        /// </summary>
        public static List<LeaveApplication> GetPeningApplicationsAllByReportingEmployee(int EmployeeID = -1)
        {
            try
            {
                return LeaveApplicationIntegration.GetPeningApplicationsByReportingEmployee(EmployeeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        //#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)

        //public static Boolean FillEmployeeLeaveApplicationsAll(int EmployeeID, Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = LeaveApplicationManagement.GetEmployeeLeaveApplicationsAll(EmployeeID);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = LeaveApplicationManagement.GetEmployeeLeaveApplicationsAll(EmployeeID);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillEmployeeLeaveApplicationsAll(int EmployeeID, DateTime DateFrom, Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = LeaveApplicationManagement.GetEmployeeLeaveApplicationsAll(EmployeeID, DateFrom);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = LeaveApplicationManagement.GetEmployeeLeaveApplicationsAll(EmployeeID, DateFrom);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillEmployeeLeaveApplicationsAll(int EmployeeID, DateTime DateFrom, DateTime DateTo, Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = LeaveApplicationManagement.GetEmployeeLeaveApplicationsAll(EmployeeID, DateFrom, DateTo);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = LeaveApplicationManagement.GetEmployeeLeaveApplicationsAll(EmployeeID, DateFrom, DateTo);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillPendingLeaveApplicationsByEmployee(int EmployeeID, DateTime DateFrom, DateTime DateTo, Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = LeaveApplicationManagement.GetEmployeePendingLeaveApplicationsAll(EmployeeID, DateFrom, DateTo);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = LeaveApplicationManagement.GetEmployeePendingLeaveApplicationsAll(EmployeeID, DateFrom, DateTo);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillPendingLeaveApplicationsAll(DateTime DateFrom, DateTime DateTo, Control Cnt)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = LeaveApplicationManagement.GetOfficePendingLeaveApplicationsAll(DateFrom, DateTo);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = LeaveApplicationManagement.GetOfficePendingLeaveApplicationsAll(DateFrom, DateTo);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillPeningApplicationsAllByReportingEmployee(Control Cnt, int EmployeeID = -1)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = LeaveApplicationManagement.GetPeningApplicationsAllByReportingEmployee(EmployeeID);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = LeaveApplicationManagement.GetPeningApplicationsAllByReportingEmployee(EmployeeID);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public static Boolean FillLeaveApplicationsAll(Control Cnt, DateTime DateFrom, DateTime DateTo)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = LeaveApplicationManagement.GetOfficeLeaveApplicationsAll(DateFrom, DateTo);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "LeaveTypeDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = LeaveApplicationManagement.GetOfficeLeaveApplicationsAll(DateFrom, DateTo);
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
