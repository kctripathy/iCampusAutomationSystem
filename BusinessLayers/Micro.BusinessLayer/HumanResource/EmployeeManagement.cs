using System.Collections.Generic;
using Micro.IntegrationLayer.HumanResource;
using Micro.Objects.HumanResource;

namespace Micro.BusinessLayer.HumanResource
{
    public partial class EmployeeManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static EmployeeManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static EmployeeManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EmployeeManagement();
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
        public string DisplayMember="EmployeeName";
        public string ValueMember = "EmployeeID";
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

		public int InsertEmployee(Employee theEmployee)
        {
			return EmployeeIntegration.InsertEmployee(theEmployee);
        }

		public int UpdateEmployee(Employee theEmployee)
        {
			return EmployeeIntegration.UpdateEmployee(theEmployee);
        }

		public int UpdateEmployeeContactInfo(Employee theEmployee)
        {
			return EmployeeIntegration.UpdateEmployeeContactInfo(theEmployee);
        }

        public int DeleteEmployee(Employee theEmployee)
        {
            return EmployeeIntegration.DeleteEmployee(theEmployee);
        }
       

        #endregion

        #region Data Retrive Mathods
	
		public List<Employee> GetEmployeesListByOfficeID()
		{
			return EmployeeIntegration.GetEmployeesListByOfficeID();
		}

		public List<Employee> GetEmployeeList()
		{
			return EmployeeIntegration.GetEmployeeList();

		}
        public List<Employee> GetDuplicateEmployeeList(string employeeName, string fatherName, string dateofBirth, bool allOffices = false, bool showDeleted = false)
        {
            return EmployeeIntegration.GetDuplicateEmployeeList(employeeName, fatherName, dateofBirth, allOffices, showDeleted);
        }
        public List<Employee> GetOfficeEmployeeList()
        {
             return EmployeeIntegration.GetOfficeEmployeeList();
        }

        public List<Employee> GetEmployeeListByCompany(int CompanyID=-1)
        {
		   return EmployeeIntegration.GetEmployeeListByCompany(CompanyID);
        }

        public List<Employee> GetEmployeesAllByCompany(int CompanyID = -1)
        {
              return EmployeeIntegration.GetEmployeesAllByCompany(CompanyID);
        }

        public List<Employee> GetEmployeeListByOfficeandDepartment(int DepartmentID)
        {
            return EmployeeIntegration.GetCompanyEmployeeListByOfficeandDepartment(DepartmentID);
           
        }

        public List<Employee> GetEmployeeListByOfficeandDepartment( int DepartmentID,int OfficeID)
        {
            return EmployeeIntegration.GetCompanyEmployeeListByOfficeandDepartment(DepartmentID,OfficeID);
           
        }

        public Employee GetEmployeeByID(int EmployeeID)
        {
             return EmployeeIntegration.GetEmployeeDetailsByID(EmployeeID);
         }

        public Employee GetEmployeeByEmployeeCode(string employeeCode)
        {
              return EmployeeIntegration.GetEmployeeByEmployeeCode(employeeCode);
        }

        public List<Employee> GetReportingEmployeesEmailAllByEmployee(int EmployeeID)
        {
            return EmployeeIntegration.GetReportingEmployeesEmailAllByEmployee(EmployeeID);
        }

        public List<Employee> GetReportingEmployeesAllByEmployee(int EmployeeID)
        {
            return EmployeeIntegration.GetReportingEmployeesAllByEmployee(EmployeeID);
        }

        public List<Employee> GetEmployeeDetailsByGuarantorLoan(string OfficeIDs, string DateFrom, string DateTo, string ApprovalStatus)
        {
          return EmployeeIntegration.GetEmployeeDetailsByGuarantorLoan(OfficeIDs,DateFrom,DateTo,ApprovalStatus);
        }

        public List<Employee> GetEmployeeDetailsByFieldFoce(string OfficeIDs, string DateFrom, string DateTo, string ApprovalStatus)
        {
            return EmployeeIntegration.GetEmployeeDetailsByFieldForce(OfficeIDs, DateFrom, DateTo, ApprovalStatus);

        }

		public List<Employee> GetEmployeesListbyofficeid(int OfficeID)
		{
			return EmployeeIntegration.GetEmployeesListbyofficeid(OfficeID);
		}

        public List<Employee> GetCompanyEmployeeList()
        {
            return EmployeeIntegration.GetCompanyEmployeeList();
        }
        #endregion

		


		//#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)
        
		
		

		//public Boolean FillEmployeeListByOfficeandDepartment(Control Cnt, int DepartmentID)
		//{
		//    try
		//    {
		//        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
		//        {
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = EmployeeManagement.GetInstance.GetEmployeeListByOfficeandDepartment(DepartmentID);
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "EmployeeName";
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "EmployeeName";
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
		//        }
		//        else if (Cnt is DevExpress.XtraGrid.GridControl)
		//        {
		//            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = EmployeeManagement.GetInstance.GetEmployeeListByOfficeandDepartment(DepartmentID);
		//        }

		//        return true;
		//    }
		//    catch (Exception ex)
		//    {
		//        return false;
		//        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
		//    }
		//}
		//public List<Employee> FillOfficeEmployeeList()
		//{
		//    return EmployeeManagement.GetInstance.GetOfficeEmployeeList();
		//}
		//public Boolean FillOfficeEmployeeList(Control Cnt)
		//{
		//    try
		//    {
		//        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
		//        {
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "FullName";
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "FullName";
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
		//        }
		//        else if (Cnt is DevExpress.XtraGrid.GridControl)
		//        {
		//            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
		//        }

		//        return true;
		//    }
		//    catch (Exception ex)
		//    {
		//        return false;
		//        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
		//    }
		//}

		//public List<Employee> FillEmployeeListByCompany(int CompanyID=-1)
		//{
		//      return  EmployeeManagement.GetInstance.GetEmployeeListByCompany(CompanyID);
		//}

		//public Boolean FillEmployeesAllByCompany(Control Cnt, int CompanyID = -1)
		//{
		//    try
		//    {
		//        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
		//        {
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = EmployeeManagement.GetInstance.GetEmployeesAllByCompany(CompanyID);
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "EmployeeName";
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "EmployeeName";
		//            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
		//        }
		//        else if (Cnt is DevExpress.XtraGrid.GridControl)
		//        {
		//            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = EmployeeManagement.GetInstance.GetEmployeesAllByCompany(CompanyID);
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
