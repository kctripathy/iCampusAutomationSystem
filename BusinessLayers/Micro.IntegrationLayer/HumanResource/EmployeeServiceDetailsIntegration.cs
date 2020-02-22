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
    public partial class EmployeeServiceDetailsIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertEmployeeServiceDetails(EmployeeServiceDetails _EmployeeServiceDetails)
        {
            try
            {
                return EmployeeServiceDetailsDataAccess.GetInstance.InsertEmployeeServiceDetails(_EmployeeServiceDetails);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateEmployeeServiceDetails(EmployeeServiceDetails _EmployeeServiceDetails)
        {
            try
            {
                return EmployeeServiceDetailsDataAccess.GetInstance.UpdateEmployeeServiceDetails(_EmployeeServiceDetails);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteEmployeeServiceDetails(EmployeeServiceDetails _EmployeeServiceDetails)
        {
            try
            {
                return EmployeeServiceDetailsDataAccess.GetInstance.DeleteEmployeeServiceDetails(_EmployeeServiceDetails);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static List<EmployeeServiceDetails> GetEmployeeServiceDetailsByEmployee(int EmployeeID)
        {
            try
            {
                return SetEmployeeServiceDetails(EmployeeServiceDetailsDataAccess.GetInstance.GetEmployeeSeviceDetailsByEmployee(EmployeeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<EmployeeServiceDetails> GetReportingEmployeeListByReportingToEmployee(int EmployeeID)
        {
            try
            {
                return SetEmployeeServiceDetails(EmployeeServiceDetailsDataAccess.GetInstance.GetEmployeeListByReportingToEmployee(EmployeeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<EmployeeServiceDetails> GetEmployeeServiceDetailsAll(string searchText, bool showDeleted = false)
        {
            try
            {
                return SetEmployeeServiceDetails(EmployeeServiceDetailsDataAccess.GetInstance.GetEmployeeSeviceDetailsAll(searchText, showDeleted));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<EmployeeServiceDetails> SetEmployeeServiceDetails(DataTable DtTable)
        {
            try
            {
                List<EmployeeServiceDetails> _EmployeeList = new List<EmployeeServiceDetails>();

                foreach (DataRow DtRow in DtTable.Rows)
                {
                    EmployeeServiceDetails EmployeeServiceDetails = new EmployeeServiceDetails();

                    EmployeeServiceDetails.EmployeeServiceDetailsID = int.Parse(DtRow["EmployeeServiceDetailsID"].ToString());

                    EmployeeServiceDetails.Employee.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());
                    EmployeeServiceDetails.Employee.EmployeeName = DtRow["EmployeeName"].ToString();

                    EmployeeServiceDetails.Employee.DepartmentID = int.Parse(DtRow["DepartmentID"].ToString());
                    EmployeeServiceDetails.Employee.DepartmentDescription  = DtRow["DepartmentDescription"].ToString();

                    EmployeeServiceDetails.Employee.DesignationID = int.Parse(DtRow["DesignationID"].ToString());
                    EmployeeServiceDetails.Employee.DesignationDescription = DtRow["DesignationDescription"].ToString();


                    if (DtRow["PostingDate"].ToString() + "" != "")
                    {
                        EmployeeServiceDetails.PostingDate = DateTime.Parse(DtRow["PostingDate"].ToString()); ;
                    }

                    //EmployeeServiceDetails.PostingOffice = MicroOfficeIntegration.GetMicroOfficesById(int.Parse(DtRow["OfficeID"].ToString()));

                    EmployeeServiceDetails.PostingOffice.OfficeID = int.Parse(DtRow["PostingOfficeID"].ToString());
                    EmployeeServiceDetails.PostingOffice.OfficeName = DtRow["OfficeName"].ToString();

                    EmployeeServiceDetails.ReferenceLetterNumber = DtRow["ReferenceLetterNumber"].ToString();
                    EmployeeServiceDetails.Remarks = DtRow["Remarks"].ToString();

                    if (DtRow["ReportingToEffectiveDateFrom"].ToString() + "" != "")
                    {
                        EmployeeServiceDetails.ReportingToEffectiveDateFrom = DateTime.Parse(DtRow["ReportingToEffectiveDateFrom"].ToString());
                    }

                    if (DtRow["ReportingToEmployeeID"].ToString() + "" != "")
                    {
                        EmployeeServiceDetails.ReportingToEmployee = EmployeeIntegration.GetEmployeeDetailsByID(int.Parse(DtRow["ReportingToEmployeeID"].ToString()));
                    }

                    EmployeeServiceDetails.ServiceStatus = DtRow["ServiceStatus"].ToString();
                    EmployeeServiceDetails.ServiceType = DtRow["ServiceType"].ToString();

                    EmployeeServiceDetails.IsActive = Boolean.Parse(DtRow["IsActive"].ToString());
                    EmployeeServiceDetails.IsDeleted = Boolean.Parse(DtRow["IsDeleted"].ToString());

                    _EmployeeList.Add(EmployeeServiceDetails);
                }
                return _EmployeeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

    }
}
