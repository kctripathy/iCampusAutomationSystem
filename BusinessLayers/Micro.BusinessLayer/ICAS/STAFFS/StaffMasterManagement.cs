using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using Micro.IntegrationLayer.ICAS.STAFFS;
using System.Web;

namespace Micro.BusinessLayer.ICAS.STAFFS
{
    public partial class StaffMasterManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static StaffMasterManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StaffMasterManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StaffMasterManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        public string DefaultColumns = "EmployeeName, EmployeeCode, DesignationDescription, DepartmentDescription";
        public string DisplayMember = "EmployeeName";
        public string ValueMember = "EmployeeID";
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertEmployee(StaffMaster theStaffMaster, string CourseIDs, string Boards, string PassingYears, string Divisions, string PercentageMarks)
        {
            return StaffMasterIntegration.InsertEmployee(theStaffMaster, CourseIDs, Boards, PassingYears, Divisions, PercentageMarks);
        }

        public int UpdateEmployee(StaffMaster theStaffMaster, string CourseIDs, string Boards, string PassingYears, string Divisions, string PercentageMarks)
        {
            return StaffMasterIntegration.UpdateEmployee(theStaffMaster, CourseIDs, Boards, PassingYears, Divisions, PercentageMarks);
        }

        public int UpdateEmployeeContactInfo(StaffMaster theStaffMaster)
        {
            return StaffMasterIntegration.UpdateEmployeeContactInfo(theStaffMaster);
        }

        public int DeleteEmployee(StaffMaster theStaffMaster)
        {
            return StaffMasterIntegration.DeleteEmployee(theStaffMaster);
        }


        #endregion

        #region Data Retrive Mathods

        public List<StaffMaster> GetEmployeesListByOfficeID()
        {
            return StaffMasterIntegration.GetEmployeesListByOfficeID();
        }

		public List<StaffMaster> GetEmployeeListForLibrary()
		{
			List<StaffMaster> StaffMasterList = StaffMasterIntegration.GetEmployeeList();
			List<StaffMaster> StaffMasterList_Filter = (from x in StaffMasterList														
														where !x.EmployeeName.Contains("ADMIN")
														select x).OrderBy(a=>a.EmployeeName).ToList();
			return StaffMasterList_Filter;
		}
        public List<StaffMaster> GetEmployeeList()
        {
            //return StaffMasterIntegration.GetEmployeeList();

			string UniqueKey = "GetEmployeeList";
			if (HttpRuntime.Cache[UniqueKey] == null)
			{
				List<StaffMaster> StaffMasterList = StaffMasterIntegration.GetEmployeeList();
				HttpRuntime.Cache[UniqueKey] = StaffMasterList;
			}
			return (List<StaffMaster>)(HttpRuntime.Cache[UniqueKey]);


        }
        public List<StaffMaster> GetPolicyEmployeesAll()
        {
            return StaffMasterIntegration.GetPolicyEmployeesAll();

        }
        public DataTable GetEmployeesSearchAll(string searchText)
        {
            DataTable StffTable = StaffMasterIntegration.GetEmployeesSearchAll(searchText);
            return StffTable;
        }
        public List<StaffMaster> GetDuplicateEmployeeList(string employeeName, string fatherName, string dateofBirth, bool allOffices = false, bool showDeleted = false)
        {
            return StaffMasterIntegration.GetDuplicateEmployeeList(employeeName, fatherName, dateofBirth, allOffices, showDeleted);
        }
        public List<StaffMaster> GetOfficeEmployeeList()
        {
            return StaffMasterIntegration.GetOfficeEmployeeList();
        }

        public List<StaffMaster> GetEmployeeListByCompany(int CompanyID = -1)
        {
            return StaffMasterIntegration.GetEmployeeListByCompany(CompanyID);
        }

        public List<StaffMaster> GetEmployeesAllByCompany(int CompanyID = -1)
        {
            return StaffMasterIntegration.GetEmployeesAllByCompany(CompanyID);
        }

        public List<StaffMaster> GetEmployeeListByOfficeandDepartment(int DepartmentID)
        {
            return StaffMasterIntegration.GetCompanyEmployeeListByOfficeandDepartment(DepartmentID);

        }

        public List<StaffMaster> GetEmployeeListByOfficeandDepartment(int DepartmentID, int OfficeID)
        {
            return StaffMasterIntegration.GetCompanyEmployeeListByOfficeandDepartment(DepartmentID, OfficeID);

        }

        public StaffMaster GetEmployeeByID(int EmployeeID)
        {
            return StaffMasterIntegration.GetEmployeeDetailsByID(EmployeeID);
        }

        public StaffMaster GetEmployeeByEmployeeCode(string employeeCode)
        {
            return StaffMasterIntegration.GetEmployeeByEmployeeCode(employeeCode);
        }

        public List<StaffMaster> GetReportingEmployeesEmailAllByEmployee(int EmployeeID)
        {
            return StaffMasterIntegration.GetReportingEmployeesEmailAllByEmployee(EmployeeID);
        }

        public List<StaffMaster> GetReportingEmployeesAllByEmployee(int EmployeeID)
        {
            return StaffMasterIntegration.GetReportingEmployeesAllByEmployee(EmployeeID);
        }

        public List<StaffMaster> GetEmployeeDetailsByGuarantorLoan(string OfficeIDs, string DateFrom, string DateTo, string ApprovalStatus)
        {
            return StaffMasterIntegration.GetEmployeeDetailsByGuarantorLoan(OfficeIDs, DateFrom, DateTo, ApprovalStatus);
        }

        public List<StaffMaster> GetEmployeeDetailsByFieldFoce(string OfficeIDs, string DateFrom, string DateTo, string ApprovalStatus)
        {
            return StaffMasterIntegration.GetEmployeeDetailsByFieldForce(OfficeIDs, DateFrom, DateTo, ApprovalStatus);

        }

        public List<StaffMaster> GetEmployeesListbyofficeid(int OfficeID)
        {
            return StaffMasterIntegration.GetEmployeesListbyofficeid(OfficeID);
        }

        public List<StaffMaster> GetCompanyEmployeeList()
        {
            return StaffMasterIntegration.GetCompanyEmployeeList();
        }
        #endregion


		public List<StaffMaster> GetEmployeeListByDepartment(string dept_name="MANAGEMENT")
		{
			List<StaffMaster> sList = StaffMasterManagement.GetInstance.GetOfficeEmployeeList();
			List<StaffMaster> sListByDept = sList.FindAll(y => y.DepartmentDescription == dept_name.ToUpper());
			return sListByDept;

			//List<StaffMaster> sListByDept1 = new List<StaffMaster>();
			//foreach (StaffMaster item in sList)
			//{
			//	if (item.DepartmentDescription.ToUpper().Trim() == dept_name.ToUpper() || item.DepartmentDescription.ToUpper().StartsWith(dept_name))
			//	{
			//		sListByDept1.Add(item);
			//	}
			//}
			//return sListByDept1;
		}
	}
}
