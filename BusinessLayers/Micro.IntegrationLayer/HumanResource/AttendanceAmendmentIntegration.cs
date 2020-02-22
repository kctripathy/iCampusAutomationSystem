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

#endregion

namespace Micro.IntegrationLayer.HumanResource
{
    public class AttendanceAmendmentIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertAttendanceAmendment(AttendanceAmendment _AttendanceAmendment)
        {
            try
            {
                return AttendanceAmendmentDataAccess.GetInstance.InsertAttendanceAmendment(_AttendanceAmendment);
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
                return AttendanceAmendmentDataAccess.GetInstance.UpdateAttendanceAmendment(_AttendanceAmendment);
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
                return AttendanceAmendmentDataAccess.GetInstance.ApproveOrRejectAttendanceAmendment(_AttendanceAmendment);
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
                return AttendanceAmendmentDataAccess.GetInstance.DeleteAttendanceAmendment(_AttendanceAmendment);
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
                DataRow DtRow = AttendanceAmendmentDataAccess.GetInstance.GetAttendanceAmendmentByAttendanceAmendmentID(AttendanceAmendmentID);

                AttendanceAmendment _AttendanceAmendment = new AttendanceAmendment();

                _AttendanceAmendment.AttendanceAmendmentID = int.Parse(DtRow["AttendanceAmendmentID"].ToString());
                _AttendanceAmendment.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());
                _AttendanceAmendment.EmployeeName = DtRow["EmployeeName"].ToString();
                _AttendanceAmendment.EmployeeCode = DtRow["EmployeeCode"].ToString();
                _AttendanceAmendment.DepartmentDescription = DtRow["DepartmentDescription"].ToString();
                _AttendanceAmendment.DesignationDescription = DtRow["DesignationDescription"].ToString();

                _AttendanceAmendment.DateOfAttendance = DateTime.Parse(DtRow["DateOfAttendance"].ToString());
                _AttendanceAmendment.AttendanceType = DtRow["AttendanceType"].ToString();
                _AttendanceAmendment.OldTime = DateTime.Parse(DtRow["OldTime"].ToString());
                _AttendanceAmendment.NewTime = DateTime.Parse(DtRow["NewTime"].ToString());
                _AttendanceAmendment.Reason = DtRow["Reason"].ToString();

                _AttendanceAmendment.Status = DtRow["Status"].ToString();

                if (DtRow["Status"].ToString() != "Pending")
                {
                    _AttendanceAmendment.ApprovedBy.EmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());

                    _AttendanceAmendment.ApprovedByEmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());
                    //_AttendanceAmendment.ApproveDate = DateTime.Parse(DtRow["ApprovedOn"].ToString());
                    _AttendanceAmendment.ApprovalOrRejectionReason = DtRow["ApprovalOrRejectionReason"].ToString();
                }

                _AttendanceAmendment.IsActive = (Boolean)DtRow["IsActive"];
                _AttendanceAmendment.IsDeleted = (Boolean)DtRow["IsDeleted"];

                return _AttendanceAmendment;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        private static List<AttendanceAmendment> SetAttendaneAmendmentList(DataTable AttendanceAmendmentDataTable)
        {
            try
            {
                List<AttendanceAmendment> AttendanceAmendmentList = new List<AttendanceAmendment>();

                foreach (DataRow DtRow in AttendanceAmendmentDataTable.Rows)
                {
                    AttendanceAmendment ObjAttendanceAmendment = new AttendanceAmendment();

                    ObjAttendanceAmendment.AttendanceAmendmentID = int.Parse(DtRow["AttendanceAmendmentID"].ToString());

                    ObjAttendanceAmendment.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());
                    ObjAttendanceAmendment.EmployeeName = DtRow["EmployeeName"].ToString();
                    ObjAttendanceAmendment.EmployeeCode = DtRow["EmployeeCode"].ToString();
                    ObjAttendanceAmendment.DepartmentDescription = DtRow["DepartmentDescription"].ToString();
                    ObjAttendanceAmendment.DesignationDescription = DtRow["DesignationDescription"].ToString();

                    ObjAttendanceAmendment.DateOfAttendance = DateTime.Parse(DtRow["DateOfAttendance"].ToString());
                    ObjAttendanceAmendment.AttendanceType = DtRow["AttendanceType"].ToString();
                   // ObjAttendanceAmendment.OldTime = DateTime.Parse(DtRow["OldTime"].ToString()).ToString(MicroConstants.TimeFormat);
                  //  ObjAttendanceAmendment.NewTime = DateTime.Parse(DtRow["NewTime"].ToString()).ToString(MicroConstants.TimeFormat);
                    ObjAttendanceAmendment.OldTime = DateTime.Parse(DtRow["OldTime"].ToString());
                    ObjAttendanceAmendment.NewTime = DateTime.Parse(DtRow["NewTime"].ToString());
                    ObjAttendanceAmendment.Reason = DtRow["Reason"].ToString();

                    ObjAttendanceAmendment.Status = DtRow["Status"].ToString();

                    if (DtRow["Status"].ToString() != "Pending")
                    {
                        ObjAttendanceAmendment.ApprovedBy.EmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());

                        ObjAttendanceAmendment.ApprovedByEmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());
                        //ObjAttendanceAmendment.ApproveDate = DateTime.Parse(DtRow["ApprovedOn"].ToString());
                        ObjAttendanceAmendment.ApprovalOrRejectionReason = DtRow["ApprovalOrRejectionReason"].ToString();
                    }
                    else
                    {
                        ObjAttendanceAmendment.ApprovalOrRejectionReason = "-";
                    }

                    ObjAttendanceAmendment.IsActive = (Boolean)DtRow["IsActive"];
                    ObjAttendanceAmendment.IsDeleted = (Boolean)DtRow["IsDeleted"];

                    AttendanceAmendmentList.Add(ObjAttendanceAmendment);
                }

                return AttendanceAmendmentList;
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
                return SetAttendaneAmendmentList(AttendanceAmendmentDataAccess.GetInstance.GetAttendanceAmendmentsByEmployee(EmployeeID));
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
                return SetAttendaneAmendmentList(AttendanceAmendmentDataAccess.GetInstance.GetPendingAttendanceAmendmentsByEmployee(EmployeeID));
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
                return SetAttendaneAmendmentList(AttendanceAmendmentDataAccess.GetInstance.GetPendingAttendanceAmendmentsAll());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<AttendanceAmendment> GetAttendanceAmendmentsAll(string searchText, bool showDeleted = false)
        {
            try
            {
                return SetAttendaneAmendmentList(AttendanceAmendmentDataAccess.GetInstance.GetAttendanceAmendmentsAll(searchText, showDeleted));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }


        /// <summary>
        /// ReportinOfficerwise
        /// </summary>

        public static List<AttendanceAmendment> GetPeningAttendanceAmendmentApplicationsByReportingEmployee(int EmployeeID = -1)
        {
            try
            {
                return SetAttendaneAmendmentList(AttendanceAmendmentDataAccess.GetInstance.GetPendingAttendanceAmendmentApplicationsByReportingEmployee(EmployeeID)); ;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
