#region System Namespace

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

#endregion

#region Micro Namespaces

using Micro.DataAccessLayer.HumanResource;
using Micro.Objects.HumanResource;
using Micro.Commons;
using System.Globalization;

#endregion

namespace Micro.IntegrationLayer.HumanResource
{
    public class AttendanceApplicationIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertAttendanceApplication(AttendanceApplication _AttendanceApplication)
        {
            try
            {
                return AttendanceApplicationDataAccess.GetInstance.InsertAttendanceApplication(_AttendanceApplication);
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
                return AttendanceApplicationDataAccess.GetInstance.UpdateAttendanceApplication(_AttendanceApplication);
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
                return AttendanceApplicationDataAccess.GetInstance.ApproveOrRejectAttendanceApplication(_AttendanceApplication);
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
                return AttendanceApplicationDataAccess.GetInstance.DeleteAttendanceApplication(_AttendanceApplication);
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
                DataRow DtRow = AttendanceApplicationDataAccess.GetInstance.GetAttendanceApplicationByAttendanceApplicationID(AttendanceApplicationID);

                AttendanceApplication _AttendanceApplication = new AttendanceApplication();

                _AttendanceApplication.AttendanceApplicationID = int.Parse(DtRow["AttendanceApplicationID"].ToString());

                _AttendanceApplication.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());
                _AttendanceApplication.EmployeeName = DtRow["EmployeeName"].ToString();
                _AttendanceApplication.EmployeeCode = DtRow["EmployeeCode"].ToString();
                _AttendanceApplication.DepartmentDescription = DtRow["DepartmentDescription"].ToString();
                _AttendanceApplication.DesignationDescription = DtRow["DesignationDescription"].ToString();

                _AttendanceApplication.DateOfAttendance = DateTime.Parse(DtRow["DateOfAttendance"].ToString());

                if (DtRow["InTime"].ToString() != "")
                {
                    _AttendanceApplication.InTime = DateTime.Parse(DtRow["InTime"].ToString());
                }

                if (DtRow["OutTime"].ToString() != "")
                {
                    _AttendanceApplication.OutTime = DateTime.Parse(DtRow["OutTime"].ToString());
                }
                _AttendanceApplication.ApplicationReason = DtRow["Reason"].ToString();

                _AttendanceApplication.Status = DtRow["Status"].ToString();

                if (DtRow["Status"].ToString() != "Pending")
                {
                    _AttendanceApplication.ApprovedBy.EmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());

                    _AttendanceApplication.ApprovedByEmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());
                    _AttendanceApplication.ApproveDate = DateTime.Parse(DtRow["ApprovedOn"].ToString());
                    _AttendanceApplication.ApprovalOrRejectionReason = DtRow["ApprovalOrRejectionReason"].ToString();
                }
                {
                    _AttendanceApplication.ApprovalOrRejectionReason = "-";
                }

                _AttendanceApplication.IsActive = Boolean.Parse(DtRow["IsActive"].ToString());
                _AttendanceApplication.IsDeleted = Boolean.Parse(DtRow["IsDeleted"].ToString());

                return _AttendanceApplication;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<AttendanceApplication> SetAttendanceApplicationList(DataTable AttendanceApplicationTable)
        {
            try
            {
                List<AttendanceApplication> AttendanceApplicationList = new List<AttendanceApplication>();

                foreach (DataRow DtRow in AttendanceApplicationTable.Rows)
                {
                    AttendanceApplication _AttendanceApplication = new AttendanceApplication();

                    _AttendanceApplication.AttendanceApplicationID = int.Parse(DtRow["AttendanceApplicationID"].ToString());
                    _AttendanceApplication.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());
                    _AttendanceApplication.EmployeeName = DtRow["EmployeeName"].ToString();
                    _AttendanceApplication.EmployeeCode = DtRow["EmployeeCode"].ToString();
                    _AttendanceApplication.DepartmentDescription = DtRow["DepartmentDescription"].ToString();
                    _AttendanceApplication.DesignationDescription = DtRow["DesignationDescription"].ToString();

                    _AttendanceApplication.DateOfAttendance = DateTime.Parse(DtRow["DateOfAttendance"].ToString());

                    if (DtRow["InTime"].ToString() != "")
                    {
                        _AttendanceApplication.InTime = DateTime.Parse(DtRow["InTime"].ToString());
                        
                    }

                    if (DtRow["OutTime"].ToString() != "")
                    {
                        _AttendanceApplication.OutTime = DateTime.Parse(DtRow["OutTime"].ToString());
                    }

                    _AttendanceApplication.ApplicationReason = DtRow["Reason"].ToString();

                    _AttendanceApplication.Status = DtRow["Status"].ToString();

                    if (DtRow["Status"].ToString() != "Pending")
                    {
                        _AttendanceApplication.ApprovedBy.EmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());

                        _AttendanceApplication.ApprovedByEmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());
                        //_AttendanceApplication.ApproveDate = DateTime.Parse(DtRow["ApprovedOn"].ToString());
                        _AttendanceApplication.ApprovalOrRejectionReason = DtRow["ApprovalOrRejectionReason"].ToString();
                    }
					else if (DtRow["Status"].ToString() == "Pending")
                    {
						_AttendanceApplication.ApprovalOrRejectionReason = DtRow["ApprovalOrRejectionReason"].ToString();
                    }

                    _AttendanceApplication.IsActive = Boolean.Parse(DtRow["IsActive"].ToString());
                    _AttendanceApplication.IsDeleted = Boolean.Parse(DtRow["IsDeleted"].ToString());

                    AttendanceApplicationList.Add(_AttendanceApplication);
                }

                return AttendanceApplicationList;
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
                return SetAttendanceApplicationList(AttendanceApplicationDataAccess.GetInstance.GetAttendanceApplicationsByEmployee(EmployeeID, searchText, showDeleted));
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
                return SetAttendanceApplicationList(AttendanceApplicationDataAccess.GetInstance.GetPeningApplicationsByEmployee(EmployeeID));
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
                return SetAttendanceApplicationList(AttendanceApplicationDataAccess.GetInstance.GetPeningApplicationsAll());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<AttendanceApplication> GetAttendanceApplicationsAll(string searchText, bool showDeleted = false)
        {
            try
            {
                return SetAttendanceApplicationList(AttendanceApplicationDataAccess.GetInstance.GetAttendanceApplicationsAll(searchText, showDeleted));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }



        /// <summary>
        /// ReportinOfficerwise
        /// </summary>

        public static List<AttendanceApplication> GetPeningAttendanceAmendmentApplicationsByReportingEmployee(int EmployeeID = -1)
        {
            try
            {
                return SetAttendanceApplicationList(AttendanceApplicationDataAccess.GetInstance.GetPendingAttendanceApplicationsByReportingEmployee(EmployeeID)); ;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        #endregion
    }
}