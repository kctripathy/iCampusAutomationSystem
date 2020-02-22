using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Micro.Commons;
using Micro.Objects.HumanResource;

namespace Micro.DataAccessLayer.HumanResource
{
	public partial class EmployeeDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static EmployeeDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static EmployeeDataAccess GetInstance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new EmployeeDataAccess();
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

		public int InsertEmployee(Employee theEmployee)
		{
			try
			{
				int ReturnValue = 0;

				SqlCommand InsertCommand = new SqlCommand();
				InsertCommand.CommandType = CommandType.StoredProcedure;

				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

				//InsertCommand.Parameters.Add(GetParameter("@EmployeeCode", SqlDbType.VarChar, theEmployee.EmployeeCode));
				InsertCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theEmployee.Salutation));
				InsertCommand.Parameters.Add(GetParameter("@EmployeeName", SqlDbType.VarChar, theEmployee.EmployeeName));
				InsertCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theEmployee.FatherName));
				InsertCommand.Parameters.Add(GetParameter("@SpouseName", SqlDbType.VarChar, theEmployee.SpouseName));

                InsertCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.VarChar, theEmployee.DateOfBirth));

				InsertCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theEmployee.Gender));
				InsertCommand.Parameters.Add(GetParameter("@BloodGroup", SqlDbType.VarChar, theEmployee.BloodGroup));
				InsertCommand.Parameters.Add(GetParameter("@Religion", SqlDbType.VarChar, theEmployee.Religion));
				InsertCommand.Parameters.Add(GetParameter("@Nationality", SqlDbType.VarChar, theEmployee.Nationality));
				InsertCommand.Parameters.Add(GetParameter("@MaritalStatus", SqlDbType.VarChar, theEmployee.MaritalStatus));
				InsertCommand.Parameters.Add(GetParameter("@KnownAilments", SqlDbType.VarChar, theEmployee.KnownAilments));
				InsertCommand.Parameters.Add(GetParameter("@IdentificationMark", SqlDbType.VarChar, theEmployee.IdentificationMark));

				InsertCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theEmployee.Address_Present_TownOrCity));
				InsertCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theEmployee.Address_Present_LandMark));
				InsertCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theEmployee.Address_Present_DistrictID));
				InsertCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theEmployee.Address_Present_Pincode));

				InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theEmployee.Address_Permanent_TownOrCity));
				InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theEmployee.Address_Permanent_LandMark));
				InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theEmployee.Address_Permanent_DistrictID));
				InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theEmployee.Address_Permanent_Pincode));

				InsertCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theEmployee.PhoneNumber));
				InsertCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theEmployee.Mobile));
				InsertCommand.Parameters.Add(GetParameter("@EMailID", SqlDbType.VarChar, theEmployee.EmailID));
				InsertCommand.Parameters.Add(GetParameter("@EmergencyContactNumber", SqlDbType.VarChar, theEmployee.EmergencyContactNumber));

				InsertCommand.Parameters.Add(GetParameter("@IsMatriculate", SqlDbType.Int, theEmployee.IsMatriculate));
				InsertCommand.Parameters.Add(GetParameter("@LastQualification", SqlDbType.VarChar, theEmployee.LastQualification));
				InsertCommand.Parameters.Add(GetParameter("@YearOfPassing", SqlDbType.Int, theEmployee.YearOfPassing));
				InsertCommand.Parameters.Add(GetParameter("@Institution", SqlDbType.VarChar, theEmployee.Institution));
				InsertCommand.Parameters.Add(GetParameter("@BoardOrUniversity", SqlDbType.VarChar, theEmployee.BoardOrUniversity));
				InsertCommand.Parameters.Add(GetParameter("@ProfessionalQualification", SqlDbType.VarChar, theEmployee.ProfessionalQualification));
				InsertCommand.Parameters.Add(GetParameter("@ProfessionalInstitution", SqlDbType.VarChar, theEmployee.ProfessionalInstitution));

				InsertCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, theEmployee.UserID));

				InsertCommand.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, theEmployee.DepartmentID));
				InsertCommand.Parameters.Add(GetParameter("@DesignationID", SqlDbType.Int, theEmployee.DesignationID));
				InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, theEmployee.OfficeID));

				InsertCommand.Parameters.Add(GetParameter("@JoiningDate", SqlDbType.DateTime, theEmployee.PostingDate.ToString(MicroConstants.DateFormat)));


				InsertCommand.Parameters.Add(GetParameter("@ServiceType", SqlDbType.VarChar, theEmployee.ServiceType));
				InsertCommand.Parameters.Add(GetParameter("@ServiceStatus", SqlDbType.VarChar, theEmployee.ServiceStatus));
				InsertCommand.Parameters.Add(GetParameter("@ReferenceLetterNumber", SqlDbType.VarChar, theEmployee.ReferenceLetterNumber));
				InsertCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theEmployee.Remarks));

				InsertCommand.Parameters.Add(GetParameter("@ReferenceName", SqlDbType.VarChar, theEmployee.ReferenceName));
				InsertCommand.Parameters.Add(GetParameter("@ReferencePhone", SqlDbType.VarChar, theEmployee.ReferencePhone));
				InsertCommand.Parameters.Add(GetParameter("@ReferenceMobile", SqlDbType.VarChar, theEmployee.ReferenceMobile));
				InsertCommand.Parameters.Add(GetParameter("@BioDeviceEmployeeID", SqlDbType.VarChar, theEmployee.BioDeviceEmployeeID));
				if (theEmployee.Picture != null)
				{
					InsertCommand.Parameters.Add(GetParameter("@EmployeeImage", SqlDbType.VarBinary, theEmployee.Picture));
				}
				if (theEmployee.Signature != null)
				{
					InsertCommand.Parameters.Add(GetParameter("@EmployeeSignature", SqlDbType.VarBinary, theEmployee.Signature));
				}

				if (theEmployee.ReportingToEmployeeID > 0)
				{
					InsertCommand.Parameters.Add(GetParameter("@ReportingToEmployeeID", SqlDbType.Int, theEmployee.ReportingToEmployeeID));
					InsertCommand.Parameters.Add(GetParameter("@ReportingToEffectiveDateFrom", SqlDbType.DateTime, theEmployee.ReportingToEffectiveDateFrom.ToString(MicroConstants.DateFormat)));
				}

				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				InsertCommand.CommandText = "pHRM_Employees_Insert";

				ExecuteStoredProcedure(InsertCommand);

				return int.Parse(InsertCommand.Parameters[0].Value.ToString());
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public int UpdateEmployee(Employee theEmployee)
		{
			try
			{
				int ReturnValue = 0;

				SqlCommand UpdateCommand = new SqlCommand();

				UpdateCommand.CommandType = CommandType.StoredProcedure;

				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

				UpdateCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, theEmployee.EmployeeID));

				UpdateCommand.Parameters.Add(GetParameter("@EmployeeCode", SqlDbType.VarChar, theEmployee.EmployeeCode));
				UpdateCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theEmployee.Salutation));
				UpdateCommand.Parameters.Add(GetParameter("@EmployeeName", SqlDbType.VarChar, theEmployee.EmployeeName));
				UpdateCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theEmployee.FatherName));
				UpdateCommand.Parameters.Add(GetParameter("@SpouseName", SqlDbType.VarChar, theEmployee.SpouseName));
				UpdateCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.VarChar, theEmployee.DateOfBirth));
				UpdateCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theEmployee.Gender));
				UpdateCommand.Parameters.Add(GetParameter("@BloodGroup", SqlDbType.VarChar, theEmployee.BloodGroup));
				UpdateCommand.Parameters.Add(GetParameter("@Religion", SqlDbType.VarChar, theEmployee.Religion));
				UpdateCommand.Parameters.Add(GetParameter("@Nationality", SqlDbType.VarChar, theEmployee.Nationality));
				UpdateCommand.Parameters.Add(GetParameter("@MaritalStatus", SqlDbType.VarChar, theEmployee.MaritalStatus));
				UpdateCommand.Parameters.Add(GetParameter("@KnownAilments", SqlDbType.VarChar, theEmployee.KnownAilments));
				UpdateCommand.Parameters.Add(GetParameter("@IdentificationMark", SqlDbType.VarChar, theEmployee.IdentificationMark));

				UpdateCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theEmployee.Address_Present_TownOrCity));
				UpdateCommand.Parameters.Add(GetParameter("@Address_Present_LandMark", SqlDbType.VarChar, theEmployee.Address_Present_LandMark));
				UpdateCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theEmployee.Address_Present_DistrictID));
				UpdateCommand.Parameters.Add(GetParameter("@Address_Present_Pincode", SqlDbType.VarChar, theEmployee.Address_Present_Pincode));

				UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theEmployee.Address_Permanent_TownOrCity));
				UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_LandMark", SqlDbType.VarChar, theEmployee.Address_Permanent_LandMark));
				UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theEmployee.Address_Permanent_DistrictID));
				UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_Pincode", SqlDbType.VarChar, theEmployee.Address_Permanent_Pincode));

				UpdateCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theEmployee.PhoneNumber));
				UpdateCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theEmployee.Mobile));
				UpdateCommand.Parameters.Add(GetParameter("@EmailID", SqlDbType.VarChar, theEmployee.EmailID));
				UpdateCommand.Parameters.Add(GetParameter("@PersonalEMailID", SqlDbType.VarChar, theEmployee.PersonalEMailID));
				UpdateCommand.Parameters.Add(GetParameter("@EmergencyContactNumber", SqlDbType.VarChar, theEmployee.EmergencyContactNumber));

				UpdateCommand.Parameters.Add(GetParameter("@IsMatriculate", SqlDbType.Int, theEmployee.IsMatriculate));
				UpdateCommand.Parameters.Add(GetParameter("@LastQualification", SqlDbType.VarChar, theEmployee.LastQualification));
				UpdateCommand.Parameters.Add(GetParameter("@YearOfPassing", SqlDbType.Int, theEmployee.YearOfPassing));
				UpdateCommand.Parameters.Add(GetParameter("@Institution", SqlDbType.VarChar, theEmployee.Institution));
				UpdateCommand.Parameters.Add(GetParameter("@BoardOrUniversity", SqlDbType.VarChar, theEmployee.BoardOrUniversity));
				UpdateCommand.Parameters.Add(GetParameter("@ProfessionalQualification", SqlDbType.VarChar, theEmployee.ProfessionalQualification));
				UpdateCommand.Parameters.Add(GetParameter("@ProfessionalInstitution", SqlDbType.VarChar, theEmployee.ProfessionalInstitution));

				UpdateCommand.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, theEmployee.DepartmentID));
				UpdateCommand.Parameters.Add(GetParameter("@DesignationID", SqlDbType.Int, theEmployee.DesignationID));
				UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, theEmployee.OfficeID));
				UpdateCommand.Parameters.Add(GetParameter("@PostingDate", SqlDbType.DateTime, DateTime.Parse(theEmployee.PostingDate.ToString(MicroConstants.DateFormat))));
				UpdateCommand.Parameters.Add(GetParameter("@ServiceType", SqlDbType.VarChar, theEmployee.ServiceType));
				UpdateCommand.Parameters.Add(GetParameter("@ServiceStatus", SqlDbType.VarChar, theEmployee.ServiceStatus));
				UpdateCommand.Parameters.Add(GetParameter("ReferenceLetterNumber", SqlDbType.VarChar, theEmployee.ReferenceLetterNumber));

				UpdateCommand.Parameters.Add(GetParameter("@ReferenceName", SqlDbType.VarChar, theEmployee.ReferenceName));
				UpdateCommand.Parameters.Add(GetParameter("@ReferencePhone", SqlDbType.VarChar, theEmployee.ReferencePhone));
				UpdateCommand.Parameters.Add(GetParameter("@ReferenceMobile", SqlDbType.VarChar, theEmployee.ReferenceMobile));
				UpdateCommand.Parameters.Add(GetParameter("@EmployeeServiceDetailsID", SqlDbType.Int, theEmployee.EmployeeServiceDetailsID));

				UpdateCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theEmployee.Remarks));

				UpdateCommand.Parameters.Add(GetParameter("@BioDeviceEmployeeID", SqlDbType.VarChar, theEmployee.BioDeviceEmployeeID));

				if (theEmployee.Picture != null)
					UpdateCommand.Parameters.Add(GetParameter("@EmployeeImage", SqlDbType.VarBinary, theEmployee.Picture));
				if (theEmployee.Signature != null)
					UpdateCommand.Parameters.Add(GetParameter("@EmployeeSignature", SqlDbType.VarBinary, theEmployee.Signature));

				if (theEmployee.ReportingToEmployeeID > -1)
				{
					UpdateCommand.Parameters.Add(GetParameter("@ReportingToEmployeeID", SqlDbType.Int, theEmployee.ReportingToEmployeeID));
					UpdateCommand.Parameters.Add(GetParameter("@ReportingToEffectiveDateFrom", SqlDbType.DateTime, theEmployee.ReportingToEffectiveDateFrom));
				}

				//UpdateCommand.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, theEmployee.IsDeleted));
				//UpdateCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, theEmployee.IsActive));

				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				UpdateCommand.CommandText = "pHRM_Employees_Update";
				ExecuteStoredProcedure(UpdateCommand);

				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public int UpdateEmployeeContactInfo(Employee theEmployee)
		{
			try
			{
				int ReturnValue = 0;

				SqlCommand UpdateCommand = new SqlCommand();

				UpdateCommand.CommandType = CommandType.StoredProcedure;

				UpdateCommand.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

				UpdateCommand.Parameters.Add(GetParameter("EmployeeID", SqlDbType.Int, theEmployee.EmployeeID));

				UpdateCommand.Parameters.Add(GetParameter("PhoneNumber", SqlDbType.VarChar, theEmployee.PhoneNumber));
				UpdateCommand.Parameters.Add(GetParameter("Mobile", SqlDbType.VarChar, theEmployee.Mobile));
				UpdateCommand.Parameters.Add(GetParameter("EmailID", SqlDbType.VarChar, theEmployee.EmailID));
				UpdateCommand.Parameters.Add(GetParameter("PersonalEMailID", SqlDbType.VarChar, theEmployee.PersonalEMailID));
				UpdateCommand.Parameters.Add(GetParameter("EmergencyContactNumber", SqlDbType.VarChar, theEmployee.EmergencyContactNumber));

				UpdateCommand.Parameters.Add(GetParameter("IsActive", SqlDbType.Int, theEmployee.IsActive));

				UpdateCommand.Parameters.Add(GetParameter("ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				UpdateCommand.CommandText = "pHRM_Employees_Update_ContactInfo";
				ExecuteStoredProcedure(UpdateCommand);

				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

        public int DeleteEmployee(Employee theEmployee)
		{

            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, theEmployee.EmployeeID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pHRM_Employees_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
				
		}

		#endregion

		#region Data Retrive Mathods
		public DataTable GetEmployeesListByOfficeID()
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pHRM_Employees_SelectByOfficeID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable GetEmployeesAll()
		{
			try
			{
				SqlCommand GetCommandName = new SqlCommand();
				GetCommandName.CommandType = CommandType.StoredProcedure;

				GetCommandName.CommandText = "pHRM_Employees_SelectAll";

				return ExecuteGetDataTable(GetCommandName);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public DataTable GetEmployeesAllByOffice(int OfficeID = -1)
		{
			try
			{
				SqlCommand GetCommandName = new SqlCommand();
				GetCommandName.CommandType = CommandType.StoredProcedure;

                //GetCommandName.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int,Micro.Commons.Connection.LoggedOnUser.OfficeID));
                GetCommandName.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                GetCommandName.CommandText = "pHRM_Employees_SelectByOfficeID";

				return ExecuteGetDataTable(GetCommandName);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public DataTable GetEmployeesAllByCompany(int CompanyID=-1 )
		{
			try
			{
				SqlCommand GetCommandName = new SqlCommand();
				GetCommandName.CommandType = CommandType.StoredProcedure;

				GetCommandName.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int,Micro.Commons.Connection.LoggedOnUser.CompanyID ));

				GetCommandName.CommandText = "pHRM_Employees_SelectByComapnyID";

				return ExecuteGetDataTable(GetCommandName);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public DataTable GetEmployeesListByCompany(int CompanyID = -1)
		{
			try
			{
				SqlCommand GetCommandName = new SqlCommand();
				GetCommandName.CommandType = CommandType.StoredProcedure;

				GetCommandName.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int,
							(CompanyID == -1 ? Micro.Commons.Connection.LoggedOnUser.CompanyID : CompanyID)));

				GetCommandName.CommandText = "pHRM_Employees_SelectListByComapnyID";

				return ExecuteGetDataTable(GetCommandName);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public DataTable GetEmployeeAllByOfficeDepartment(int DepartmentID, int OfficeID = -1)
		{
			try
			{
				SqlCommand GetCommandName = new SqlCommand();
				GetCommandName.CommandType = CommandType.StoredProcedure;

				GetCommandName.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
				GetCommandName.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int,
							(OfficeID == -1 ? Micro.Commons.Connection.LoggedOnUser.OfficeID : OfficeID)));

				GetCommandName.CommandText = "pHRM_Employees_SelectByOfficeIDandDepartmentID";

				return ExecuteGetDataTable(GetCommandName);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public DataRow GetEmployeeDetailsByEmployeeID(int EmployeeID)
		{
			try
			{
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));

				SqlCmd.CommandText = "pHRM_Employees_SelectByEmployeeID";

				return ExecuteGetDataRow(SqlCmd);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public DataRow GetEmployeeByEmployeeCode(string employeeCode)
		{
			try
			{
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add(GetParameter("@EmployeeCode", SqlDbType.VarChar, employeeCode));

				SqlCmd.CommandText = "pHRM_Employees_SelectByEmployeeCode";

				return ExecuteGetDataRow(SqlCmd);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public DataTable GetReportingEmployeesAllByEmployee(int EmployeeID)
		{
			try
			{
				SqlCommand GetCommandName = new SqlCommand();
				GetCommandName.CommandType = CommandType.StoredProcedure;

				GetCommandName.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));

				GetCommandName.CommandText = "pHRM_Employees_SelectReportingEmployeesByEmployeeID";

				return ExecuteGetDataTable(GetCommandName);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public DataTable GetReportingEmployeesEmailAllByEmployee(int EmployeeID)
		{
			try
			{
				SqlCommand GetCommandName = new SqlCommand();
				GetCommandName.CommandType = CommandType.StoredProcedure;

				GetCommandName.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));

				GetCommandName.CommandText = "pHRM_Employees_SelectManagersByEmployeeID";

				return ExecuteGetDataTable(GetCommandName);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}
		//For GuarantorLoan Reports

		public DataTable GetEmployeeDetailsByGuarantorLoan(string OfficeIDs, string DateFrom, string DateTo, string ApprovalStatus)
		{
			SqlCommand SelectCommand = new SqlCommand();

			SelectCommand.CommandType = CommandType.StoredProcedure;
			SelectCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.VarChar, OfficeIDs));
			SelectCommand.Parameters.Add(GetParameter("@DateFrom", SqlDbType.VarChar, DateFrom));
			SelectCommand.Parameters.Add(GetParameter("@DateTo", SqlDbType.VarChar, DateTo));
			SelectCommand.Parameters.Add(GetParameter("@ApprovalStatus", SqlDbType.VarChar, ApprovalStatus));
			SelectCommand.CommandText = "pHRM_Employees_SelectByGuarantorLoanApproval";

			return ExecuteGetDataTable(SelectCommand);
		}

		//For FieldForcePromotion Reports

		public DataTable GetEmployeeDetailsByFieldForce(string OfficeIDs, string DateFrom, string DateTo, string ApprovalStatus)
		{
			SqlCommand SelectCommand = new SqlCommand();

			SelectCommand.CommandType = CommandType.StoredProcedure;
			SelectCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.VarChar, OfficeIDs));
			SelectCommand.Parameters.Add(GetParameter("@DateFrom", SqlDbType.VarChar, DateFrom));
			SelectCommand.Parameters.Add(GetParameter("@DateTo", SqlDbType.VarChar, DateTo));
			SelectCommand.Parameters.Add(GetParameter("@ApprovalStatus", SqlDbType.VarChar, ApprovalStatus));
			SelectCommand.CommandText = "pHRM_Employees_SelectByFieldForcePromotionApproval";

			return ExecuteGetDataTable(SelectCommand);
		}
		//Employee Details 
		public DataTable GetEmployeesListbyofficeid(int OfficeID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, OfficeID));
				SelectCommand.CommandText = "pHRM_Employees_SelectByOfficeID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}
		#endregion
	}
}
