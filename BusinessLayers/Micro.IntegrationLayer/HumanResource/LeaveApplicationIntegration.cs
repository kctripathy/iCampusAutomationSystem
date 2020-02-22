#region System Namespace

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

#endregion

#region Micro Namespaces

using Micro.DataAccessLayer.HumanResource;
using Micro.Objects.HumanResource;

#endregion

namespace Micro.IntegrationLayer.HumanResource
{
    public class LeaveApplicationIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertLeaveApplication(LeaveApplication _LeaveApplication)
        {
            try
            {
                return LeaveApplicationDataAccess.GetInstance.InsertLeaveApplication(_LeaveApplication);
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
                return LeaveApplicationDataAccess.GetInstance.UpdateLeaveApplication(_LeaveApplication);
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
                return LeaveApplicationDataAccess.GetInstance.ApproveOrRejectLeaveApplication(_LeaveApplication);
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
                return LeaveApplicationDataAccess.GetInstance.DeleteLeaveApplication(_LeaveApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        #endregion

        #region Data Retrive Mathods

        /// <summary>
        /// Convert DataTable Into List<LeaveApplications>
        /// </summary>
        public static List<LeaveApplication> SetLeaveApplicationList(DataTable DT)
        {
            try
            {
                List<LeaveApplication> LeaveApplicationList = new List<LeaveApplication>();

                foreach (DataRow DtRow in DT.Rows)
                {
                    LeaveApplication ObjLeaveApplication = new LeaveApplication();

                    ObjLeaveApplication.LeaveApplicationID = int.Parse(DtRow["LeaveApplicationID"].ToString());
                    ObjLeaveApplication.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());
                    ObjLeaveApplication.EmployeeCode = DtRow["EmployeeCode"].ToString();
                  ObjLeaveApplication.EmployeeName = DtRow["EmployeeName"].ToString();
				
                   // ObjLeaveApplication.DepartmentDescription = DtRow["DepartmentDescription"].ToString();
                   // ObjLeaveApplication.DesignationDescription = DtRow["DesignationDescription"].ToString();

                    ObjLeaveApplication.DateApplied = DateTime.Parse(DtRow["DateApplied"].ToString());
                    ObjLeaveApplication.LeaveTypeID = int.Parse(DtRow["LeaveTypeID"].ToString());
                    ObjLeaveApplication.LeaveTypeDescription = DtRow["LeaveTypeDescription"].ToString();
                    ObjLeaveApplication.LeaveTypeAlias = DtRow["LeaveTypeAlias"].ToString();

                    ObjLeaveApplication.DateFrom = DateTime.Parse(DtRow["DateFrom"].ToString());
                    ObjLeaveApplication.DateTo = DateTime.Parse(DtRow["DateTo"].ToString());
                    ObjLeaveApplication.ApplicationReason = DtRow["LeaveApplicationReason"].ToString();
                    ObjLeaveApplication.DateAdded = DateTime.Parse(DtRow["DateAdded"].ToString());
                    ObjLeaveApplication.Status = DtRow["Status"].ToString();

                    if (DtRow["Status"].ToString() != "Pending" && DtRow["Status"].ToString() != "Cancelled")
                    {
                        ObjLeaveApplication.ApprovedBy.UserID = int.Parse(DtRow["ApprovedBy"].ToString());

                        ObjLeaveApplication.ApprovedByUserID = int.Parse(DtRow["ApprovedBy"].ToString());

                        ObjLeaveApplication.ApprovedBy.EmployeeName = DtRow["ApprovedByName"].ToString();

                        ObjLeaveApplication.ApprovedByEmployeeName = DtRow["ApprovedByName"].ToString();
                        ObjLeaveApplication.ApproveDate = DateTime.Parse(DtRow["ApprovedOn"].ToString());
                        ObjLeaveApplication.ApprovalOrRejectionReason = DtRow["ApprovalOrRejectionReason"].ToString();
                    }
                    else
                    {
                        ObjLeaveApplication.ApprovalOrRejectionReason = "-";
                    }
                    ObjLeaveApplication.IsActive = Boolean.Parse(DtRow["IsActive"].ToString());
                    ObjLeaveApplication.IsDeleted = Boolean.Parse(DtRow["IsDeleted"].ToString());

                    LeaveApplicationList.Add(ObjLeaveApplication);
                }

                return LeaveApplicationList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Employeewise Applications
        /// </summary>
        public static List<LeaveApplication> GetEmployeeLeaveApplicationsAll(int EmployeeID)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetEmployeeLeaveApplicationsAll(EmployeeID));
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
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetEmployeeLeaveApplicationsAll(EmployeeID, DateFrom));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        
        public static List<LeaveApplication> GetEmployeeLeaveApplicationsAll(int EmployeeID, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetEmployeeLeaveApplicationsAll(EmployeeID, DateFrom, DateTo));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Employeewise Pending Applications
        /// </summary>
        public static List<LeaveApplication> GetEmployeePendingLeaveApplicationsAll(int EmployeeID)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetEmployeePendingLeaveApplicationsAll(EmployeeID));
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
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetEmployeePendingLeaveApplicationsAll(EmployeeID, DateFrom));
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
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetEmployeePendingLeaveApplicationsAll(EmployeeID, DateFrom, DateTo));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// OFFICEWISE
        /// </summary>
        public static List<LeaveApplication> GetOfficeLeaveApplicationsAll(int OfficeID = -1)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetOfficeLeaveApplicationsAll(OfficeID));
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
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetOfficeLeaveApplicationsAll(DateFrom, OfficeID));
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
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetOfficeLeaveApplicationsAll(DateFrom, DateTo, OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// OFFICEWISE PENDINGS
        /// </summary>
        public static List<LeaveApplication> GetOfficePendingLeaveApplicationsAll(int OfficeID = -1)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetOfficePeningLeaveApplicationsAll(OfficeID));
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
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetOfficePeningLeaveApplicationsAll(DateFrom, OfficeID));
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
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetOfficePeningLeaveApplicationsAll(DateFrom, DateTo, OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// DEPARTMENTWISE PENDINGS
        /// </summary>
        public static List<LeaveApplication> GetDepartmentPendingLeaveApplicationsAll(int DepartmentID, int OfficeID = -1)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetDepartmentPendingLeaveApplicationsAll(DepartmentID, OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetDepartmentPendingLeaveApplicationsAll(int DepartmentID, DateTime DateFrom, int OfficeID = -1)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetDepartmentPendingLeaveApplicationsAll(DepartmentID, DateFrom, OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetDepartmentPendingLeaveApplicationsAll(int DepartmentID, DateTime DateFrom, DateTime DateTo, int OfficeID = -1)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetDepartmentPendingLeaveApplicationsAll(DepartmentID, DateFrom, DateTo, OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// DEPARTMENTWISE
        /// </summary>
        public static List<LeaveApplication> GetDepartmentLeaveApplicationsAll(int DepartmentID, int OfficeID = -1)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetDepartmentLeaveApplicationsAll(DepartmentID, OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetDepartmentLeaveApplicationsAll(int DepartmentID, DateTime DateFrom, int OfficeID = -1)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetDepartmentLeaveApplicationsAll(DepartmentID, DateFrom, OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveApplication> GetDepartmentLeaveApplicationsAll(int DepartmentID, DateTime DateFrom, DateTime DateTo, int OfficeID = -1)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetDepartmentLeaveApplicationsAll(DepartmentID, DateFrom, DateTo, OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// ReportinOfficerwise
        /// </summary>

        public static List<LeaveApplication> GetPeningApplicationsByReportingEmployee(int EmployeeID = -1)
        {
            try
            {
                return SetLeaveApplicationList(LeaveApplicationDataAccess.GetInstance.GetPendingLeaveApplicationsByReportingEmployee(EmployeeID)); ;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Leave Applicationwise
        /// </summary>
        public static LeaveApplication GetLeaveApplicationByLeaveApplicationID(int LeaveApplicationID)
        {
            try
            {
                DataRow DtRow = LeaveApplicationDataAccess.GetInstance.GetLeaveApplicationByLeaveApplicationID(LeaveApplicationID);

                LeaveApplication _LeaveApplication = new LeaveApplication();

                _LeaveApplication.LeaveApplicationID = int.Parse(DtRow["LeaveApplicationID"].ToString());
                _LeaveApplication.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());
                _LeaveApplication.EmployeeName = DtRow["EmployeeName"].ToString();

                _LeaveApplication.DateApplied = DateTime.Parse(DtRow["DateApplied"].ToString());

                _LeaveApplication.LeaveTypeID = int.Parse(DtRow["LeaveTypeID"].ToString());
                _LeaveApplication.LeaveTypeDescription = DtRow["LeaveTypeDescription"].ToString();
                _LeaveApplication.LeaveTypeAlias = DtRow["LeaveTypeAlias"].ToString();

                _LeaveApplication.DateFrom = DateTime.Parse(DtRow["DateFrom"].ToString());
                _LeaveApplication.DateTo = DateTime.Parse(DtRow["DateTo"].ToString());
                _LeaveApplication.ApplicationReason = DtRow["LeaveApplicationReason"].ToString();

                _LeaveApplication.Status = DtRow["Status"].ToString();

                if (DtRow["Status"].ToString() != "Pending" && DtRow["Status"].ToString() != "Cancelled")
                {
                    _LeaveApplication.ApprovedBy.UserID = int.Parse(DtRow["ApprovedBy"].ToString());

                    _LeaveApplication.ApprovedByUserID = int.Parse(DtRow["ApprovedBy"].ToString());

                    _LeaveApplication.ApprovedByName.EmployeeName = DtRow["ApprovedByName"].ToString();
                    _LeaveApplication.ApprovedByEmployeeName = DtRow["ApprovedByName"].ToString();
                    _LeaveApplication.ApproveDate = DateTime.Parse(DtRow["ApprovedOn"].ToString());
                    _LeaveApplication.ApprovalOrRejectionReason = DtRow["ApprovalOrRejectionReason"].ToString();
                }

                _LeaveApplication.IsActive = Boolean.Parse(DtRow["IsActive"].ToString());
                _LeaveApplication.IsDeleted = Boolean.Parse(DtRow["IsDeleted"].ToString());

                return _LeaveApplication;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        #endregion

    }
}
