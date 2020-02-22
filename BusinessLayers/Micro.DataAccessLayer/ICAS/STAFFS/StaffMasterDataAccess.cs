using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.ICAS.STAFFS;
using System.Reflection;
using Micro.Commons;


namespace Micro.DataAccessLayer.ICAS.STAFFS
{
    public partial class StaffMasterDataAccess:AbstractData_SQLClient
    {

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static StaffMasterDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StaffMasterDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StaffMasterDataAccess();
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

        public int InsertEmployee(StaffMaster theStaffMaster, string CourseIDs, string Boards, string PassingYears, string Divisions, string PercentageMarks)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand InsertCommand = new SqlCommand();
                InsertCommand.CommandType = CommandType.StoredProcedure;

                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValueEmp", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                
                //InsertCommand.Parameters.Add(GetParameter("@EmployeeCode", SqlDbType.VarChar, theEmployee.EmployeeCode));
                InsertCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theStaffMaster.Salutation));
                InsertCommand.Parameters.Add(GetParameter("@EmployeeName", SqlDbType.VarChar, theStaffMaster.EmployeeName));
                InsertCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theStaffMaster.FatherName));
                InsertCommand.Parameters.Add(GetParameter("@SpouseName", SqlDbType.VarChar, theStaffMaster.SpouseName));

                InsertCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.VarChar, theStaffMaster.DateOfBirth==string.Empty?Convert.DBNull:theStaffMaster.DateOfBirth));

                InsertCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theStaffMaster.Gender));
                InsertCommand.Parameters.Add(GetParameter("@BloodGroup", SqlDbType.VarChar, theStaffMaster.BloodGroup));
                InsertCommand.Parameters.Add(GetParameter("@Religion", SqlDbType.VarChar, theStaffMaster.Religion));
                InsertCommand.Parameters.Add(GetParameter("@Nationality", SqlDbType.VarChar, theStaffMaster.Nationality));
                InsertCommand.Parameters.Add(GetParameter("@MaritalStatus", SqlDbType.VarChar, theStaffMaster.MaritalStatus));
                InsertCommand.Parameters.Add(GetParameter("@KnownAilments", SqlDbType.VarChar, theStaffMaster.KnownAilments));
                InsertCommand.Parameters.Add(GetParameter("@IdentificationMark", SqlDbType.VarChar, theStaffMaster.IdentificationMark));

                InsertCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theStaffMaster.Address_Present_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theStaffMaster.Address_Present_LandMark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theStaffMaster.Address_Present_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theStaffMaster.Address_Present_Pincode));

                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theStaffMaster.Address_Permanent_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theStaffMaster.Address_Permanent_LandMark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theStaffMaster.Address_Permanent_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theStaffMaster.Address_Permanent_Pincode));

                InsertCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theStaffMaster.PhoneNumber));
                InsertCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theStaffMaster.Mobile));
                InsertCommand.Parameters.Add(GetParameter("@EMailID", SqlDbType.VarChar, theStaffMaster.EmailID));
                InsertCommand.Parameters.Add(GetParameter("@PHStatus", SqlDbType.VarChar, theStaffMaster.PHStatus));
                InsertCommand.Parameters.Add(GetParameter("@EPAndGPFAcNo", SqlDbType.VarChar, theStaffMaster.EPAndGPFAcNo));

                InsertCommand.Parameters.Add(GetParameter("@Refmail", SqlDbType.VarChar, theStaffMaster.PersonalEMailID));
                InsertCommand.Parameters.Add(GetParameter("@ReferenceMobile", SqlDbType.VarChar, theStaffMaster.ReferenceMobile));
                InsertCommand.Parameters.Add(GetParameter("@ReferenceName", SqlDbType.VarChar, theStaffMaster.ReferenceName));
                InsertCommand.Parameters.Add(GetParameter("@ReferencePhone", SqlDbType.VarChar, theStaffMaster.ReferencePhone));

                InsertCommand.Parameters.Add(GetParameter("@PanNo", SqlDbType.VarChar, theStaffMaster.PanNo));
                InsertCommand.Parameters.Add(GetParameter("@SbiAccountNo", SqlDbType.VarChar, theStaffMaster.SbiAccountNo));
                InsertCommand.Parameters.Add(GetParameter("@ScaleOfPay", SqlDbType.VarChar, theStaffMaster.ScaleOfPay));
                InsertCommand.Parameters.Add(GetParameter("@GpOrAGP", SqlDbType.VarChar, theStaffMaster.GpOrAGP));
                InsertCommand.Parameters.Add(GetParameter("@DateOfNextIncrement", SqlDbType.DateTime, theStaffMaster.DateOfNextIncrement == string.Empty ? Convert.DBNull : theStaffMaster.DateOfNextIncrement));
                InsertCommand.Parameters.Add(GetParameter("@ChseRegdNo", SqlDbType.VarChar, theStaffMaster.ChseRegdNo));
                InsertCommand.Parameters.Add(GetParameter("@UnivRegdNo", SqlDbType.VarChar, theStaffMaster.UnivRegdNo));

               
                InsertCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, theStaffMaster.UserID));

                InsertCommand.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, theStaffMaster.DepartmentID));
                InsertCommand.Parameters.Add(GetParameter("@DesignationID", SqlDbType.Int, theStaffMaster.DesignationID));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, theStaffMaster.OfficeID));
                ////////New///////////
                InsertCommand.Parameters.Add(GetParameter("@JoiningDateInOffice", SqlDbType.DateTime, theStaffMaster.JoiningDateInOffice == string.Empty ? Convert.DBNull : theStaffMaster.JoiningDateInOffice));
                InsertCommand.Parameters.Add(GetParameter("@JoiningDateInService", SqlDbType.DateTime, theStaffMaster.JoiningDateInService == string.Empty ? Convert.DBNull : theStaffMaster.JoiningDateInService));
                InsertCommand.Parameters.Add(GetParameter("@Employeetype1", SqlDbType.VarChar, theStaffMaster.Employeetype1));
                InsertCommand.Parameters.Add(GetParameter("@Employeetype2", SqlDbType.VarChar, theStaffMaster.Employeetype2));
                InsertCommand.Parameters.Add(GetParameter("@Employeetype3", SqlDbType.VarChar, theStaffMaster.Employeetype3));
                InsertCommand.Parameters.Add(GetParameter("@Employeetype4", SqlDbType.VarChar, theStaffMaster.Employeetype4));
                InsertCommand.Parameters.Add(GetParameter("@ServiceStatusChangeRequestDate", SqlDbType.DateTime, theStaffMaster.ServiceStatusChangeRequestDate == string.Empty ? Convert.DBNull : theStaffMaster.ServiceStatusChangeRequestDate));
                InsertCommand.Parameters.Add(GetParameter("@ServiceStatusLastWorkingDate", SqlDbType.DateTime, theStaffMaster.ServiceStatusLastWorkingDate == string.Empty ? Convert.DBNull : theStaffMaster.ServiceStatusLastWorkingDate));
             

                InsertCommand.Parameters.Add(GetParameter("@CourseIDs", SqlDbType.VarChar, CourseIDs));
                InsertCommand.Parameters.Add(GetParameter("@PassingYears", SqlDbType.VarChar,PassingYears));
                InsertCommand.Parameters.Add(GetParameter("@Boards", SqlDbType.VarChar,Boards));
                InsertCommand.Parameters.Add(GetParameter("@Divisions", SqlDbType.VarChar,Divisions));
                InsertCommand.Parameters.Add(GetParameter("@PercentageMarks", SqlDbType.VarChar,PercentageMarks));
                //////////////////



                //InsertCommand.Parameters.Add(GetParameter("@ReferenceName", SqlDbType.VarChar, theStaffMaster.ReferenceName));
                //InsertCommand.Parameters.Add(GetParameter("@ReferencePhone", SqlDbType.VarChar, theStaffMaster.ReferencePhone));
                //InsertCommand.Parameters.Add(GetParameter("@ReferenceMobile", SqlDbType.VarChar, theStaffMaster.ReferenceMobile));
                InsertCommand.Parameters.Add(GetParameter("@BioDeviceEmployeeID", SqlDbType.VarChar, theStaffMaster.BioDeviceEmployeeID));
                if (theStaffMaster.Picture != null)
                {
                    InsertCommand.Parameters.Add(GetParameter("@EmployeeImage", SqlDbType.VarBinary, theStaffMaster.Picture));
                }
                if (theStaffMaster.Signature != null)
                {
                    InsertCommand.Parameters.Add(GetParameter("@EmployeeSignature", SqlDbType.VarBinary, theStaffMaster.Signature));
                }

                if (theStaffMaster.ReportingToEmployeeID > 0)
                {
                    InsertCommand.Parameters.Add(GetParameter("@ReportingToEmployeeID", SqlDbType.Int, theStaffMaster.ReportingToEmployeeID));
                    InsertCommand.Parameters.Add(GetParameter("@ReportingToEffectiveDateFrom", SqlDbType.VarChar, theStaffMaster.ReportingToEffectiveDateFrom == string.Empty ? Convert.DBNull : theStaffMaster.ReportingToEffectiveDateFrom));
                }

                //InsertCommand.Parameters.Add(GetParameter("@TeachingOrNonTeaching", SqlDbType.VarChar, theStaffMaster.TeachingOrNonTeaching));
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

        public int UpdateEmployee(StaffMaster theStaffMaster,string CourseIDs, string Boards, string PassingYears, string Divisions, string PercentageMarks)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand UpdateCommand = new SqlCommand();

                UpdateCommand.CommandType = CommandType.StoredProcedure;

                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                UpdateCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, theStaffMaster.EmployeeID));

                UpdateCommand.Parameters.Add(GetParameter("@EmployeeCode", SqlDbType.VarChar, theStaffMaster.EmployeeCode));
                UpdateCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theStaffMaster.Salutation));
                UpdateCommand.Parameters.Add(GetParameter("@EmployeeName", SqlDbType.VarChar, theStaffMaster.EmployeeName));
                UpdateCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theStaffMaster.FatherName));
                UpdateCommand.Parameters.Add(GetParameter("@SpouseName", SqlDbType.VarChar, theStaffMaster.SpouseName));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.VarChar, theStaffMaster.DateOfBirth));
                UpdateCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theStaffMaster.Gender));
                UpdateCommand.Parameters.Add(GetParameter("@BloodGroup", SqlDbType.VarChar, theStaffMaster.BloodGroup));
                UpdateCommand.Parameters.Add(GetParameter("@Religion", SqlDbType.VarChar, theStaffMaster.Religion));
                UpdateCommand.Parameters.Add(GetParameter("@Nationality", SqlDbType.VarChar, theStaffMaster.Nationality));
                UpdateCommand.Parameters.Add(GetParameter("@MaritalStatus", SqlDbType.VarChar, theStaffMaster.MaritalStatus));
                UpdateCommand.Parameters.Add(GetParameter("@KnownAilments", SqlDbType.VarChar, theStaffMaster.KnownAilments));
                UpdateCommand.Parameters.Add(GetParameter("@IdentificationMark", SqlDbType.VarChar, theStaffMaster.IdentificationMark));

                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theStaffMaster.Address_Present_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_LandMark", SqlDbType.VarChar, theStaffMaster.Address_Present_LandMark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theStaffMaster.Address_Present_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_Pincode", SqlDbType.VarChar, theStaffMaster.Address_Present_Pincode));

                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theStaffMaster.Address_Permanent_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_LandMark", SqlDbType.VarChar, theStaffMaster.Address_Permanent_LandMark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theStaffMaster.Address_Permanent_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_Pincode", SqlDbType.VarChar, theStaffMaster.Address_Permanent_Pincode));

                UpdateCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theStaffMaster.PhoneNumber));
                UpdateCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theStaffMaster.Mobile));
                UpdateCommand.Parameters.Add(GetParameter("@EmailID", SqlDbType.VarChar, theStaffMaster.EmailID));

                UpdateCommand.Parameters.Add(GetParameter("@Reffmail", SqlDbType.VarChar, theStaffMaster.PersonalEMailID));
                UpdateCommand.Parameters.Add(GetParameter("@ReferenceMobile", SqlDbType.VarChar, theStaffMaster.ReferenceMobile));
                UpdateCommand.Parameters.Add(GetParameter("@ReferenceName", SqlDbType.VarChar, theStaffMaster.ReferenceName));
                UpdateCommand.Parameters.Add(GetParameter("@ReferencePhone", SqlDbType.VarChar, theStaffMaster.ReferencePhone));

                UpdateCommand.Parameters.Add(GetParameter("@PHStatus", SqlDbType.VarChar, theStaffMaster.PHStatus));
                UpdateCommand.Parameters.Add(GetParameter("@EPAndGPFAcNo", SqlDbType.VarChar, theStaffMaster.EPAndGPFAcNo));
                UpdateCommand.Parameters.Add(GetParameter("@ChseRegdNo", SqlDbType.VarChar, theStaffMaster.ChseRegdNo));
                UpdateCommand.Parameters.Add(GetParameter("@UnivRegdNo", SqlDbType.VarChar, theStaffMaster.UnivRegdNo));

                UpdateCommand.Parameters.Add(GetParameter("@PanNo", SqlDbType.VarChar, theStaffMaster.PanNo));
                UpdateCommand.Parameters.Add(GetParameter("@SbiAccountNo", SqlDbType.VarChar, theStaffMaster.SbiAccountNo));
                UpdateCommand.Parameters.Add(GetParameter("@ScaleOfPay", SqlDbType.VarChar, theStaffMaster.ScaleOfPay));
                UpdateCommand.Parameters.Add(GetParameter("@GpOrAGP", SqlDbType.VarChar, theStaffMaster.GpOrAGP));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfNextIncrement", SqlDbType.DateTime, theStaffMaster.DateOfNextIncrement));






                UpdateCommand.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, theStaffMaster.DepartmentID));
                UpdateCommand.Parameters.Add(GetParameter("@DesignationID", SqlDbType.Int, theStaffMaster.DesignationID));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, theStaffMaster.OfficeID));
                UpdateCommand.Parameters.Add(GetParameter("@JoiningDateInOffice", SqlDbType.DateTime, theStaffMaster.JoiningDateInOffice));
                UpdateCommand.Parameters.Add(GetParameter("@JoiningDateInService", SqlDbType.DateTime, theStaffMaster.JoiningDateInService));
                UpdateCommand.Parameters.Add(GetParameter("@Employeetype1", SqlDbType.VarChar, theStaffMaster.Employeetype1));
                UpdateCommand.Parameters.Add(GetParameter("@Employeetype2", SqlDbType.VarChar, theStaffMaster.Employeetype2));
                UpdateCommand.Parameters.Add(GetParameter("@Employeetype3", SqlDbType.VarChar, theStaffMaster.Employeetype3));
                UpdateCommand.Parameters.Add(GetParameter("@Employeetype4", SqlDbType.VarChar, theStaffMaster.Employeetype4));
                UpdateCommand.Parameters.Add(GetParameter("@ServiceStatusChangeRequestDate", SqlDbType.DateTime, theStaffMaster.ServiceStatusChangeRequestDate));
                UpdateCommand.Parameters.Add(GetParameter("@ServiceStatusLastWorkingDate", SqlDbType.DateTime, theStaffMaster.ServiceStatusLastWorkingDate));


               
                UpdateCommand.Parameters.Add(GetParameter("@EmployeeServiceDetailsID", SqlDbType.Int, theStaffMaster.EmployeeServiceDetailsID));

               // UpdateCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theStaffMaster.Remarks));

                UpdateCommand.Parameters.Add(GetParameter("@BioDeviceEmployeeID", SqlDbType.VarChar, theStaffMaster.BioDeviceEmployeeID));

                if (theStaffMaster.Picture != null)
                    UpdateCommand.Parameters.Add(GetParameter("@EmployeeImage", SqlDbType.VarBinary, theStaffMaster.Picture));
                if (theStaffMaster.Signature != null)
                    UpdateCommand.Parameters.Add(GetParameter("@EmployeeSignature", SqlDbType.VarBinary, theStaffMaster.Signature));

                if (theStaffMaster.ReportingToEmployeeID > -1)
                {
                    UpdateCommand.Parameters.Add(GetParameter("@ReportingToEmployeeID", SqlDbType.Int, theStaffMaster.ReportingToEmployeeID));
                    UpdateCommand.Parameters.Add(GetParameter("@ReportingToEffectiveDateFrom", SqlDbType.DateTime, theStaffMaster.ReportingToEffectiveDateFrom));
                }
                  UpdateCommand.Parameters.Add(GetParameter("@CourseIDs", SqlDbType.VarChar, CourseIDs));
                UpdateCommand.Parameters.Add(GetParameter("@PassingYears", SqlDbType.VarChar,PassingYears));
                UpdateCommand.Parameters.Add(GetParameter("@Boards", SqlDbType.VarChar,Boards));
                UpdateCommand.Parameters.Add(GetParameter("@Divisions", SqlDbType.VarChar,Divisions));
                UpdateCommand.Parameters.Add(GetParameter("@PercentageMarks", SqlDbType.VarChar,PercentageMarks));
              
                //UpdateCommand.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, theEmployee.IsDeleted));
                //UpdateCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, theEmployee.IsActive));

                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                UpdateCommand.CommandText = "[pHRM_Employees_Update_1]";
                ExecuteStoredProcedure(UpdateCommand);
                if (UpdateCommand.Parameters[0].Value == null)
                {
                    ReturnValue = -1;
                }
                else
                {
                    ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                }
                

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateEmployeeContactInfo(StaffMaster theStaffMaster)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand UpdateCommand = new SqlCommand();

                UpdateCommand.CommandType = CommandType.StoredProcedure;

                UpdateCommand.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                UpdateCommand.Parameters.Add(GetParameter("EmployeeID", SqlDbType.Int, theStaffMaster.EmployeeID));

                UpdateCommand.Parameters.Add(GetParameter("PhoneNumber", SqlDbType.VarChar, theStaffMaster.PhoneNumber));
                UpdateCommand.Parameters.Add(GetParameter("Mobile", SqlDbType.VarChar, theStaffMaster.Mobile));
                UpdateCommand.Parameters.Add(GetParameter("EmailID", SqlDbType.VarChar, theStaffMaster.EmailID));
                UpdateCommand.Parameters.Add(GetParameter("PersonalEMailID", SqlDbType.VarChar, theStaffMaster.PersonalEMailID));
                UpdateCommand.Parameters.Add(GetParameter("EmergencyContactNumber", SqlDbType.VarChar, theStaffMaster.EmergencyContactNumber));

                UpdateCommand.Parameters.Add(GetParameter("IsActive", SqlDbType.Int, theStaffMaster.IsActive));

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

        public int DeleteEmployee(StaffMaster theStaffMaster)
        {

            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, theStaffMaster.EmployeeID));
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

        public DataTable GetEmployeesAll(bool allOffices = false, bool showDeleted = false)
        {
            try
            {                
                using (SqlCommand SelectCommand = new SqlCommand())
                {
                    SelectCommand.CommandType = CommandType.StoredProcedure;
                    SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                    SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                    SelectCommand.Parameters.Add(GetParameter("@UserType", SqlDbType.VarChar,"Employee"));

					SelectCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8)); //Micro.Commons.Connection.LoggedOnUser.CompanyID
                    SelectCommand.CommandText = "pHRM_Employees_SelectAll";

                    return ExecuteGetDataTable(SelectCommand);
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public DataTable GetPolicyEmployeesAll(bool allOffices = false, bool showDeleted = false)
        {
            try
            {
                using (SqlCommand SelectCommand = new SqlCommand())
                {
                    SelectCommand.CommandType = CommandType.StoredProcedure;
                    SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                    SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                    SelectCommand.Parameters.Add(GetParameter("@UserType", SqlDbType.VarChar, "Employee"));

                    SelectCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                    SelectCommand.CommandText = "pHRM_Policy_Employees_SelectAll";

                    return ExecuteGetDataTable(SelectCommand);
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public DataTable GetEmployeesSearchAll(string SearchText)
        {
            try
            {
                //SqlCommand GetCommandName = new SqlCommand();
                //GetCommandName.CommandType = CommandType.StoredProcedure;

                //GetCommandName.CommandText = "pHRM_Employees_SelectAll";

                //return ExecuteGetDataTable(GetCommandName);
                using (SqlCommand SelectCommand = new SqlCommand())
                {
                    SelectCommand.CommandType = CommandType.StoredProcedure;                  
                    SelectCommand.Parameters.Add(GetParameter("@UserType", SqlDbType.VarChar, "Employee"));
                    SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, SearchText));
                    SelectCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));
                    SelectCommand.CommandText = "pHRM_Employees_Search_SelectAll";

                    return ExecuteGetDataTable(SelectCommand);
                }
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

                GetCommandName.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                 //(OfficeID == -1 ? Micro.Commons.Connection.LoggedOnUser.OfficeID : OfficeID)));

                GetCommandName.CommandText = "pHRM_Employees_SelectByOfficeID";

                return ExecuteGetDataTable(GetCommandName);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetEmployeesAllByCompany(int CompanyID = -1)
        {
            try
            {
                SqlCommand GetCommandName = new SqlCommand();
                GetCommandName.CommandType = CommandType.StoredProcedure;

                GetCommandName.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int,
                            (CompanyID == -1 ? Micro.Commons.Connection.LoggedOnUser.CompanyID : CompanyID)));

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

        public DataTable GetEmployeeAllByOfficeDepartment(int DepartmentID, int OfficeID = 44)
        {
            try
            {
                SqlCommand GetCommandName = new SqlCommand();
                GetCommandName.CommandType = CommandType.StoredProcedure;

                GetCommandName.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                GetCommandName.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID == 44 ? Micro.Commons.Connection.LoggedOnUser.OfficeID : OfficeID)));

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
