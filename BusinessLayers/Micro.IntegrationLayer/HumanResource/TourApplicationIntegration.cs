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
    public class TourApplicationIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertTourApplication(TourApplication _TourApplication)
        {
            try
            {
                return TourApplicationDataAccess.GetInstance.InsertTourApplication(_TourApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public static int UpdateTourApplication(TourApplication _TourApplication)
        {
             try
            {
                return TourApplicationDataAccess.GetInstance.UpdateTourApplication(_TourApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int ApproveOrRejectTourApplication(TourApplication _TourApplication)
        {
            try
            {
                return TourApplicationDataAccess.GetInstance.ApproveOrRejectTourApplication(_TourApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeletetTourApplication(TourApplication _TourApplication)
        {
            try
            {
                return TourApplicationDataAccess.GetInstance.DeleteTourApplication(_TourApplication);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }
        
        #endregion

        #region Data Retrive Mathods

        public static TourApplication GetTourApplicationByTourApplicationID(int TourApplicationID)
        {
            try
            {
                DataRow DtRow = TourApplicationDataAccess.GetInstance.GetTourApplicationByTourApplicationID(TourApplicationID);

                TourApplication _TourApplication = new TourApplication();

                _TourApplication.TourApplicationID = int.Parse(DtRow["TourApplicationID"].ToString());
                _TourApplication.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());
                _TourApplication.EmployeeCode = DtRow["EmployeeCode"].ToString();
                _TourApplication.EmployeeName = DtRow["EmployeeName"].ToString();
                _TourApplication.DepartmentDescription = DtRow["DepartmentDescription"].ToString();
                _TourApplication.DesignationDescription = DtRow["DesignationDescription"].ToString();

                _TourApplication.DateFrom = DateTime.Parse(DtRow["DateFrom"].ToString());
                _TourApplication.DateTo = DateTime.Parse(DtRow["DateTo"].ToString());
                _TourApplication.TourPurpose = DtRow["TourPurpose"].ToString();

                _TourApplication.Status = DtRow["Status"].ToString();

                if (DtRow["Status"].ToString() != "Pending")
                {
                    _TourApplication.ApprovedBy.EmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());

                    _TourApplication.ApprovedByEmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());
                    _TourApplication.ApproveDate = DateTime.Parse(DtRow["ApprovedOn"].ToString());
                    _TourApplication.ApprovalOrRejectionReason = DtRow["ApprovalOrRejectionReason"].ToString();
                }
                else
                {
                    _TourApplication.ApprovalOrRejectionReason = "-";
                }

                _TourApplication.IsActive = Boolean.Parse(DtRow["IsActive"].ToString());
                _TourApplication.IsDeleted = Boolean.Parse(DtRow["IsDeleted"].ToString());

                return _TourApplication;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<TourApplication> SetTourApplicationList(DataTable TourApplicationTable)
        {
            try
            {
                List<TourApplication> TourApplicationList = new List<TourApplication>();

                foreach (DataRow DtRow in TourApplicationTable.Rows)
                {
                    TourApplication _TourApplication = new TourApplication();

                    _TourApplication.TourApplicationID = int.Parse(DtRow["TourApplicationID"].ToString());
                    _TourApplication.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());
                    _TourApplication.EmployeeCode = DtRow["EmployeeCode"].ToString();
                    _TourApplication.EmployeeName = DtRow["EmployeeName"].ToString();
                    _TourApplication.DepartmentDescription = DtRow["DepartmentDescription"].ToString();
                    _TourApplication.DesignationDescription = DtRow["DesignationDescription"].ToString();

                    _TourApplication.DateFrom = DateTime.Parse(DtRow["DateFrom"].ToString());
                    _TourApplication.DateTo = DateTime.Parse(DtRow["DateTo"].ToString());
                    _TourApplication.TourPurpose = DtRow["TourPurpose"].ToString();

                    _TourApplication.Status = DtRow["Status"].ToString();


                    if (DtRow["Status"].ToString() != "Pending")
                    {
                        _TourApplication.ApprovedBy.EmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());

                        _TourApplication.ApprovedByEmployeeID = int.Parse(DtRow["ApprovedBy"].ToString());
                        //_TourApplication.ApproveDate = DateTime.Parse(DtRow["ApprovedOn"].ToString());
                        _TourApplication.ApprovalOrRejectionReason = DtRow["ApprovalOrRejectionReason"].ToString();
                    }
                    else
                    {
                        _TourApplication.ApprovalOrRejectionReason = "-";
                    }
                    _TourApplication.IsActive = Boolean.Parse(DtRow["IsActive"].ToString());
                    _TourApplication.IsDeleted = Boolean.Parse(DtRow["IsDeleted"].ToString());

                    TourApplicationList.Add(_TourApplication);
                }

                return TourApplicationList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<TourApplication> GetTourApplicationsByEmployee(int EmployeeID)
        {
            try
            {
                return SetTourApplicationList(TourApplicationDataAccess.GetInstance.GetTourApplicationsByEmployee(EmployeeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<TourApplication> GetPendingTourApplicationsByEmployee(int EmployeeID)
        {
            try
            {
                return SetTourApplicationList(TourApplicationDataAccess.GetInstance.GetPendingTourApplicationsByEmployee(EmployeeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<TourApplication> GetPendingTourApplicationsAll()
        {
            try
            {
                return SetTourApplicationList(TourApplicationDataAccess.GetInstance.GetPendingTourApplicationsAll());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<TourApplication> GetTourApplicationsAll(string searchText, bool showDeleted = false)
        {
            try
            {
                return SetTourApplicationList(TourApplicationDataAccess.GetInstance.GetTourApplicationsAll(searchText, showDeleted));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
