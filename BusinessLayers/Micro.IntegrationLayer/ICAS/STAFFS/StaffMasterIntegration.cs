using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using System.Data;
using Micro.DataAccessLayer.ICAS.STAFFS;
using System.Reflection;
using Micro.Commons;
 

namespace Micro.IntegrationLayer.ICAS.STAFFS
{
    public partial class StaffMasterIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertEmployee(StaffMaster theStaffMaster, string CourseIDs, string Boards, string PassingYears, string Divisions, string PercentageMarks)
        {
            return StaffMasterDataAccess.GetInstance.InsertEmployee(theStaffMaster, CourseIDs, Boards, PassingYears, Divisions, PercentageMarks);
        }

        public static int UpdateEmployee(StaffMaster theStaffMaster, string CourseIDs, string Boards, string PassingYears, string Divisions, string PercentageMarks)
        {
            return StaffMasterDataAccess.GetInstance.UpdateEmployee(theStaffMaster, CourseIDs, Boards, PassingYears, Divisions, PercentageMarks);
        }

        public static int UpdateEmployeeContactInfo(StaffMaster theStaffMaster)
        {
            return StaffMasterDataAccess.GetInstance.UpdateEmployeeContactInfo(theStaffMaster);
        }

        public static int DeleteEmployee(StaffMaster theStaffMaster)
        {
            return StaffMasterDataAccess.GetInstance.DeleteEmployee(theStaffMaster);
        }

        #endregion

        #region Data Retrive Mathods

        public static List<StaffMaster> GetCompanyEmployeeList()
        {
            try
            {
                return ConvertDatarowToObject(StaffMasterDataAccess.GetInstance.GetEmployeesAllByCompany());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static DataTable GetEmployeesSearchAll(string searchText)
        {
            DataTable StffTable = StaffMasterDataAccess.GetInstance.GetEmployeesSearchAll(searchText);
            return StffTable;
        }

        public static List<StaffMaster> GetEmployeesListByOfficeID()
        {
            DataTable EmployeeTable = StaffMasterDataAccess.GetInstance.GetEmployeesListByOfficeID();
            List<StaffMaster> EmployeeList = ConvertDatarowToObject(EmployeeTable);

            return EmployeeList;
        }

        public static List<StaffMaster> GetEmployeeList()
        {
            try
            {
                return ConvertDatarowToObject(StaffMasterDataAccess.GetInstance.GetEmployeesAll());
            }
            catch (Exception ex)
            {
                 throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static List<StaffMaster> GetPolicyEmployeesAll()
        {
            try
            {
                return ConvertDatarowToObject(StaffMasterDataAccess.GetInstance.GetPolicyEmployeesAll());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static List<StaffMaster> GetOfficeEmployeeList()
        {
            try
            {
                return ConvertDatarowToObject(StaffMasterDataAccess.GetInstance.GetEmployeesAllByOffice());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<StaffMaster> GetEmployeeListByCompany(int CompanyID = -1)
        {
            try
            {
                return ConvertDatarowToObject(StaffMasterDataAccess.GetInstance.GetEmployeesListByCompany(CompanyID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<StaffMaster> GetEmployeesAllByCompany(int CompanyID = -1)
        {
            try
            {
                return ConvertDatarowToObject(StaffMasterDataAccess.GetInstance.GetEmployeesAllByCompany(CompanyID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<StaffMaster> GetDuplicateEmployeeList(string employeeName, string fatherName, string dateofBirth, bool allOffices = false, bool showDeleted = false)
        {
            List<StaffMaster> TheEmployeeList = GetEmployeeList();


            List<StaffMaster> TheDuplicateEmployeeList = new List<StaffMaster>();

            if (TheEmployeeList.Count > 0)
            {
                var DuplicateEmployeeList = (from EmployeeList in TheEmployeeList
                                             where EmployeeList.EmployeeName.ToUpper() == employeeName.ToUpper()
                                             && EmployeeList.FatherName.ToUpper() == fatherName.ToUpper()
                                             && EmployeeList.DateOfBirth.ToUpper() == dateofBirth.ToUpper()
                                             select EmployeeList).ToList();

                foreach (StaffMaster EachEmployee in DuplicateEmployeeList)
                {
                    StaffMaster TheEmployee = (StaffMaster)EachEmployee;
                    TheDuplicateEmployeeList.Add(TheEmployee);

                }
            }

            return TheDuplicateEmployeeList;
        }


        public static List<StaffMaster> GetCompanyEmployeeListByOfficeandDepartment(int DepartmentID, int OfficeID = -1)
        {
            try
            {
                return ConvertDatarowToObject(StaffMasterDataAccess.GetInstance.GetEmployeeAllByOfficeDepartment(DepartmentID, OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        private static List<StaffMaster> ConvertDatarowToObject(DataTable EmployeeTable)
        {
            try
            {
                //TODO: SUBRAT: handle null of this part to 
                List<StaffMaster> EmployeeList = new List<StaffMaster>();

                foreach (DataRow dr in EmployeeTable.Rows)
                {

                    StaffMaster ObjEmployee = new StaffMaster();

                    ObjEmployee.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                    ObjEmployee.EmployeeCode = dr["EmployeeCode"].ToString();

                    ObjEmployee.Salutation = dr["Salutation"].ToString().ToUpper().Trim();
                    ObjEmployee.EmployeeName = dr["EmployeeName"].ToString().ToUpper().Trim();

                    string eName = ObjEmployee.EmployeeName;
                    ObjEmployee.EmployeeFirstName = (eName.Contains(" ") == true ? eName.Substring(0, eName.IndexOf(" ")) : eName);
                    ObjEmployee.EmployeeLastName = (eName.Contains(" ") == true ? eName.Substring(eName.IndexOf(" "), eName.Length - eName.IndexOf(" ")) : eName);
                    ObjEmployee.FatherName = dr["FatherName"].ToString();

                    ObjEmployee.Gender = dr["Gender"].ToString();
                    if (dr["DateOfBirth"] != null)
                    {
                        ObjEmployee.DateOfBirth = (dr["DateOfBirth"].ToString().Length > 0 ? DateTime.Parse(dr["DateOfBirth"].ToString()).ToString(MicroConstants.DateFormat) : null);
                    }
                    //JoiningDateInOffice
                    if (dr["JoiningDateInOffice"] != null)
                    {
                        ObjEmployee.JoiningDateInOffice = (dr["JoiningDateInOffice"].ToString().Length > 0 ? DateTime.Parse(dr["JoiningDateInOffice"].ToString()).ToString(MicroConstants.DateFormat) : null);
                    }
                    

                    //ObjEmployee.EmployeeServiceDetailsID = int.Parse(dr["EmployeeServiceDetailsID"].ToString());
                    ObjEmployee.DepartmentID = (dr["DepartmentID"].ToString() != "" ? int.Parse(dr["DepartmentID"].ToString()) : 0);
                    ObjEmployee.DepartmentDescription = dr["DepartmentDescription"].ToString().ToUpper();

                    ObjEmployee.DesignationID = (dr["DesignationID"].ToString() != "" ? int.Parse(dr["DesignationID"].ToString()) : 0);
                    ObjEmployee.DesignationDescription = dr["DesignationDescription"].ToString().ToUpper();

                    ObjEmployee.OfficeID = (string.IsNullOrEmpty(dr["OfficeID"].ToString()) ? 0 : int.Parse(dr["OfficeId"].ToString()));
                    ObjEmployee.OfficeName = dr["OfficeName"].ToString();

                    ObjEmployee.Mobile = dr["Mobile"].ToString();
                   // ObjEmployee.PersonalEMailID = dr["PersonalEMailID"].ToString();
                    ObjEmployee.EmailID = dr["EmailID"].ToString();
                   // ObjEmployee.ServiceStatus = dr["ServiceStatus"].ToString();
                   // ObjEmployee.ServiceType = dr["ServiceType"].ToString();
                  //  ObjEmployee.ReferenceLetterNumber = dr["ReferenceLetterNumber"].ToString();

                  //  ObjEmployee.Remarks = dr["Remarks"].ToString();
                    if (dr["ReportingToEmployeeName"].ToString() != "")
                    {
                        ObjEmployee.ReportingToEmployeeID = int.Parse(dr["ReportingToEmployeeID"].ToString());
                        ObjEmployee.ReportingToEmployeeName = dr["ReportingToEmployeeName"].ToString();
                    }
                    else
                    {
                        ObjEmployee.ReportingToEmployeeID = -1;
                        ObjEmployee.ReportingToEmployeeName = "";
                    }


                    if (dr["RoleDescription"].ToString() != "")
                    {
                        ObjEmployee.RoleID = int.Parse(dr["RoleID"].ToString());
                        ObjEmployee.RoleDescription = dr["RoleDescription"].ToString();
                    }
                    else
                    {
                        ObjEmployee.RoleID = -1;
                        ObjEmployee.RoleDescription = "";
                    }

                    if (dr["UserID"].ToString() != "")
                        ObjEmployee.UserID = int.Parse(dr["UserID"].ToString());

                    if (dr["Employeetype1"].ToString() != "")
                    {
                        ObjEmployee.Employeetype1 = dr["Employeetype1"].ToString();
                    }
                    if (dr["Employeetype2"].ToString() != "")
                    {
                        ObjEmployee.Employeetype2 = dr["Employeetype2"].ToString();
                    }
                    if (dr["Employeetype3"].ToString() != "")
                    {
                        ObjEmployee.Employeetype3 = dr["Employeetype3"].ToString();
                    }
                    if (dr["Employeetype4"].ToString() != "")
                    {
                        ObjEmployee.Employeetype4 = dr["Employeetype4"].ToString();
                    }

                    //LastQualification
                    //if (dr["LastQualification"].ToString() != "")
                    //{
                    //    ObjEmployee.LastQualification = dr["LastQualification"].ToString();
                    //}
                    //LastQualification
                    try
                    {
                        if (dr["TeachingOrNonTeaching"] == null)
                        {
                            ObjEmployee.TeachingOrNonTeaching = "";
                        }
                        else if (dr["TeachingOrNonTeaching"].ToString() != "")
                        {
                            ObjEmployee.TeachingOrNonTeaching = dr["TeachingOrNonTeaching"].ToString();
                        }
                    }
                    catch
                    {
                        ObjEmployee.TeachingOrNonTeaching = "T";
                    }
                    EmployeeList.Add(ObjEmployee);
                }
                return EmployeeList;
            }
            catch (Exception ex)
            {

                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static StaffMaster GetEmployeeDetailsByID(int EmployeeID)
        {
            try
            {
                DataRow DtRow = StaffMasterDataAccess.GetInstance.GetEmployeeDetailsByEmployeeID(EmployeeID);

                StaffMaster ObjEmployee = new StaffMaster();
                ObjEmployee.EmployeeID = int.Parse(DtRow["EmployeeID"].ToString());
                ObjEmployee.EmployeeCode = DtRow["EmployeeCode"].ToString();
                ObjEmployee.Salutation = DtRow["Salutation"].ToString().Trim();
                ObjEmployee.EmployeeName = DtRow["EmployeeName"].ToString().Trim();
                string eName = ObjEmployee.EmployeeName;
                ObjEmployee.EmployeeFirstName = (eName.Contains(" ") == true ? eName.Substring(0, eName.IndexOf(" ")) : eName);
                ObjEmployee.EmployeeLastName = (eName.Contains(" ") == true ? eName.Substring(eName.IndexOf(" "), eName.Length - eName.IndexOf(" ")) : eName);
                ObjEmployee.FatherName = DtRow["FatherName"].ToString();
                ObjEmployee.SpouseName = DtRow["SpouseName"].ToString();
                if (DtRow["DateOfBirth"].ToString() + "" != "")
                {
                    ObjEmployee.DateOfBirth = DateTime.Parse(DtRow["DateOfBirth"].ToString()).ToString(MicroConstants.DateFormat);

                }
                ObjEmployee.Gender = DtRow["Gender"].ToString();
                ObjEmployee.BloodGroup = DtRow["BloodGroup"].ToString();
                ObjEmployee.Religion = DtRow["Religion"].ToString();
                ObjEmployee.Nationality = DtRow["Nationality"].ToString();
                ObjEmployee.MaritalStatus = DtRow["MaritalStatus"].ToString();
                ObjEmployee.KnownAilments = DtRow["KnownAilments"].ToString();
                ObjEmployee.IdentificationMark = DtRow["IdentificationMark"].ToString();
                ObjEmployee.Address_Present_TownOrCity = DtRow["Address_Present_TownOrCity"].ToString();
                ObjEmployee.Address_Present_LandMark = DtRow["Address_Present_LandMark"].ToString();
                if (DtRow["Address_Present_DistrictID"].ToString() != "")
                {
                    ObjEmployee.Address_Present_DistrictID = int.Parse(DtRow["Address_Present_DistrictID"].ToString());
                    ObjEmployee.Address_Present_DistrictName = DtRow["Address_Present_DistrictName"].ToString();
                }
                ObjEmployee.Address_Present_StateName = DtRow["Address_Present_StateName"].ToString();
                ObjEmployee.Address_Present_CountryName = DtRow["Address_Present_CountryName"].ToString();
                ObjEmployee.Address_Present_Pincode = DtRow["Address_Present_Pincode"].ToString();
                ObjEmployee.Address_Permanent_TownOrCity = DtRow["Address_Permanent_TownOrCity"].ToString();
                ObjEmployee.Address_Permanent_LandMark = DtRow["Address_Permanent_LandMark"].ToString();
                if (DtRow["Address_Permanent_DistrictID"].ToString() != "")
                {
                    ObjEmployee.Address_Permanent_DistrictID = int.Parse(DtRow["Address_Permanent_DistrictID"].ToString());
                    ObjEmployee.Address_Permanent_DistrictName = DtRow["Address_Permanent_DistrictName"].ToString();
                }
                ObjEmployee.Address_Permanent_StateName = DtRow["Address_Permanent_StateName"].ToString();
                ObjEmployee.Address_Permanent_CountryName = DtRow["Address_Permanent_CountryName"].ToString();
                ObjEmployee.Address_Permanent_Pincode = DtRow["Address_Permanent_Pincode"].ToString();
                ObjEmployee.PhoneNumber = DtRow["PhoneNumber"].ToString();
                ObjEmployee.Mobile = DtRow["Mobile"].ToString();
                //ObjEmployee.EmergencyContactNumber = DtRow["EmergencyContactNumber"].ToString();
                ObjEmployee.EmailID = DtRow["EmailID"].ToString();
                ObjEmployee.PersonalEMailID = DtRow["Refmail"].ToString();
                ObjEmployee.ReferenceName = DtRow["ReferenceName"].ToString();
                ObjEmployee.ReferenceMobile = DtRow["ReferenceMobile"].ToString();
                ObjEmployee.ReferencePhone = DtRow["ReferencePhone"].ToString();
                ObjEmployee.PHStatus = DtRow["PHStatus"].ToString();
                ObjEmployee.EPAndGPFAcNo = DtRow["EPAndGPFAcNo"].ToString();
                ObjEmployee.PanNo = DtRow["PanNo"].ToString();
                ObjEmployee.SbiAccountNo = DtRow["SbiAccountNo"].ToString();
                ObjEmployee.ScaleOfPay = DtRow["ScaleOfPay"].ToString();
                ObjEmployee.GpOrAGP = DtRow["GpOrAGP"].ToString();
                if (DtRow["DateOfNextIncrement"].ToString() + "" != "")
                {
                    ObjEmployee.DateOfNextIncrement = DateTime.Parse(DtRow["DateOfNextIncrement"].ToString()).ToString(MicroConstants.DateFormat);

                }
              

                ObjEmployee.ChseRegdNo = DtRow["ChseRegdNo"].ToString();
                ObjEmployee.UnivRegdNo = DtRow["UnivRegdNo"].ToString();
                

               

                if (DtRow["JoiningDateInOffice"].ToString() + "" != "")
                {
                    ObjEmployee.JoiningDateInOffice = DateTime.Parse(DtRow["JoiningDateInOffice"].ToString()).ToString(MicroConstants.DateFormat);

                }
                if (DtRow["JoiningDateInService"].ToString() + "" != "")
                {
                    ObjEmployee.JoiningDateInService = DateTime.Parse(DtRow["JoiningDateInService"].ToString()).ToString(MicroConstants.DateFormat);

                }

                ObjEmployee.Employeetype1 = DtRow["Employeetype1"].ToString();
                ObjEmployee.Employeetype2 = DtRow["Employeetype2"].ToString();
                ObjEmployee.Employeetype3 = DtRow["Employeetype3"].ToString();
                ObjEmployee.Employeetype4 = DtRow["Employeetype4"].ToString();
                if (DtRow["ServiceStatusLastWorkingDate"].ToString() + "" != "")
                {
                    ObjEmployee.ServiceStatusLastWorkingDate = DateTime.Parse(DtRow["ServiceStatusLastWorkingDate"].ToString()).ToString(MicroConstants.DateFormat);

                }

                if (DtRow["ServiceStatusChangeRequestDate"].ToString() + "" != "")
                {
                    ObjEmployee.ServiceStatusChangeRequestDate = DateTime.Parse(DtRow["ServiceStatusChangeRequestDate"].ToString()).ToString(MicroConstants.DateFormat);

                }
               

               

                if ((DtRow["DepartmentID"] != null))
                {
                    if (!string.IsNullOrEmpty(DtRow["DepartmentID"].ToString()))
                    {
                        ObjEmployee.DepartmentID = int.Parse(DtRow["DepartmentID"].ToString());
                    }
                    else
                    {
                        ObjEmployee.DepartmentID = -1;
                    }
                }

                ObjEmployee.DepartmentDescription = DtRow["DepartmentDescription"].ToString();

                if ((DtRow["DesignationID"] != null))
                {
                    if (!string.IsNullOrEmpty(DtRow["DesignationID"].ToString()))
                    {
                        ObjEmployee.DesignationID = int.Parse(DtRow["DesignationID"].ToString());
                    }
                    else
                    {
                        ObjEmployee.DesignationID = -1;
                    }
                }
                ObjEmployee.DesignationDescription = DtRow["DesignationDescription"].ToString();
                ObjEmployee.OfficeID = (string.IsNullOrEmpty(DtRow["OfficeId"].ToString()) ? 0 : int.Parse(DtRow["OfficeId"].ToString()));
                ObjEmployee.OfficeName = DtRow["OfficeName"].ToString();
               // ObjEmployee.ReferenceLetterNumber = DtRow["ReferenceLetterNumber"].ToString();
               // ObjEmployee.ServiceStatus = DtRow["ServiceStatus"].ToString();
               // ObjEmployee.ServiceType = DtRow["ServiceType"].ToString();
               // ObjEmployee.Remarks = DtRow["Remarks"].ToString();
                ObjEmployee.BioDeviceEmployeeID = DtRow["BioDeviceEmployeeID"].ToString();
                ObjEmployee.EmployeeServiceDetailsID = (DtRow["EmployeeServiceDetailsID"].ToString() + "" != "" ? int.Parse(DtRow["EmployeeServiceDetailsID"].ToString()) : -1);
                if (DtRow["EmployeePhoto"].ToString() != "")
                {
                    ObjEmployee.Picture = (byte[])DtRow["EmployeePhoto"];

                }

                if (DtRow["EmployeeSignature"].ToString() != "")
                {
                    ObjEmployee.Signature = (byte[])DtRow["EmployeeSignature"];
                }

                ObjEmployee.ModifiedBy = (DtRow["ModifiedBy"].ToString() + "" != "" ? int.Parse(DtRow["ModifiedBy"].ToString()) : -1);

                if (DtRow["DateModified"].ToString() + "" != "")
                {
                    ObjEmployee.DateOfModify = DateTime.Parse(DtRow["DateModified"].ToString());
                }

                ObjEmployee.AddedBy = (DtRow["AddedBy"].ToString() + "" != "" ? int.Parse(DtRow["AddedBy"].ToString()) : -1);

                if (DtRow["DateAdded"].ToString() != "")
                {
                    ObjEmployee.DateOfCreate = DateTime.Parse(DtRow["DateAdded"].ToString());

                }

                if (DtRow["ReportingToEmployeeID"].ToString() != "")
                {
                    ObjEmployee.ReportingToEmployeeID = int.Parse(DtRow["ReportingToEmployeeID"].ToString());
                    if (DtRow["ReportingToEffectiveDateFrom"].ToString() != "")
                    {

                        ObjEmployee.ReportingToEffectiveDateFrom = DtRow["ReportingToEffectiveDateFrom"].ToString() == "" ? "" : DateTime.Parse(DtRow["ReportingToEffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat);
                    }
                }
                else
                {
                    ObjEmployee.ReportingToEmployeeID = -1;
                }

                ObjEmployee.UserID = int.Parse(DtRow["UserID"].ToString());
                ObjEmployee.UserName = "";

                return ObjEmployee;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static StaffMaster GetEmployeeByEmployeeCode(string employeeCode)
        {
            try
            {
                DataRow EmployeeRow = StaffMasterDataAccess.GetInstance.GetEmployeeByEmployeeCode(employeeCode);
                StaffMaster ObjEmployee = new StaffMaster();

                if (EmployeeRow != null)
                {
                    ObjEmployee.EmployeeID = int.Parse(EmployeeRow["EmployeeID"].ToString());
                    ObjEmployee.EmployeeCode = EmployeeRow["EmployeeCode"].ToString();

                    ObjEmployee.Salutation = EmployeeRow["Salutation"].ToString().Trim();
                    ObjEmployee.EmployeeName = EmployeeRow["EmployeeName"].ToString().Trim();

                    string eName = ObjEmployee.EmployeeName;
                    ObjEmployee.EmployeeFirstName = (eName.Contains(" ") == true ? eName.Substring(0, eName.IndexOf(" ")) : eName);
                    ObjEmployee.EmployeeLastName = (eName.Contains(" ") == true ? eName.Substring(eName.IndexOf(" "), eName.Length - eName.IndexOf(" ")) : eName);

                    ObjEmployee.FatherName = EmployeeRow["FatherName"].ToString();
                    ObjEmployee.SpouseName = EmployeeRow["SpouseName"].ToString();

                    if (EmployeeRow["DateOfBirth"].ToString() + "" != "")
                    {
                        ObjEmployee.DateOfBirth = DateTime.Parse(EmployeeRow["DateOfBirth"].ToString()).ToString(MicroConstants.DateFormat);

                    }

                    ObjEmployee.Gender = EmployeeRow["Gender"].ToString();
                    ObjEmployee.BloodGroup = EmployeeRow["BloodGroup"].ToString();
                    ObjEmployee.Religion = EmployeeRow["Religion"].ToString();
                    ObjEmployee.Nationality = EmployeeRow["Nationality"].ToString();
                    ObjEmployee.MaritalStatus = EmployeeRow["MaritalStatus"].ToString();
                    ;
                    ObjEmployee.KnownAilments = EmployeeRow["KnownAilments"].ToString();
                    ObjEmployee.IdentificationMark = EmployeeRow["IdentificationMark"].ToString();

                    ObjEmployee.Address_Present_TownOrCity = EmployeeRow["Address_Present_TownOrCity"].ToString();
                    ObjEmployee.Address_Present_LandMark = EmployeeRow["Address_Present_LandMark"].ToString();
                    if (EmployeeRow["Address_Present_DistrictID"].ToString() != "")
                    {
                        ObjEmployee.Address_Present_DistrictID = int.Parse(EmployeeRow["Address_Present_DistrictID"].ToString());
                        ObjEmployee.Address_Present_DistrictName = EmployeeRow["Address_Present_DistrictName"].ToString();
                    }
                    ObjEmployee.Address_Present_Pincode = EmployeeRow["Address_Present_Pincode"].ToString();
                    ;

                    ObjEmployee.Address_Permanent_TownOrCity = EmployeeRow["Address_Permanent_TownOrCity"].ToString();
                    ObjEmployee.Address_Permanent_LandMark = EmployeeRow["Address_Permanent_LandMark"].ToString();
                    if (EmployeeRow["Address_Permanent_DistrictID"].ToString() != "")
                    {
                        ObjEmployee.Address_Permanent_DistrictID = int.Parse(EmployeeRow["Address_Permanent_DistrictID"].ToString());
                        ObjEmployee.Address_Permanent_DistrictName = EmployeeRow["Address_Permanent_DistrictName"].ToString();
                    }
                    ObjEmployee.Address_Permanent_Pincode = EmployeeRow["Address_Permanent_Pincode"].ToString();
                    ;

                    ObjEmployee.PhoneNumber = EmployeeRow["PhoneNumber"].ToString();
                    ;
                    ObjEmployee.Mobile = EmployeeRow["Mobile"].ToString();
                    ObjEmployee.EmailID = EmployeeRow["EmailID"].ToString();
                    ObjEmployee.PersonalEMailID = EmployeeRow["PersonalEMailID"].ToString();
                    ObjEmployee.EmergencyContactNumber = EmployeeRow["EmergencyContactNumber"].ToString();

                    ObjEmployee.ReferenceName = EmployeeRow["ReferenceName"].ToString();
                    ObjEmployee.ReferencePhone = EmployeeRow["ReferencePhone"].ToString();
                    ObjEmployee.ReferenceMobile = EmployeeRow["ReferenceMobile"].ToString();

                    ObjEmployee.IsMatriculate = (EmployeeRow["IsMatriculate"].ToString() == "True" ? 1 : 0);
                    ObjEmployee.LastQualification = EmployeeRow["LastQualification"].ToString();
                    ;
                    ObjEmployee.YearOfPassing = int.Parse(EmployeeRow["YearOfPassing"].ToString());
                    ObjEmployee.Institution = EmployeeRow["Institution"].ToString();
                    ;
                    ObjEmployee.BoardOrUniversity = EmployeeRow["BoardOrUniversity"].ToString();
                    ObjEmployee.ProfessionalQualification = EmployeeRow["ProfessionalQualification"].ToString();
                    ObjEmployee.ProfessionalInstitution = EmployeeRow["ProfessionalInstitution"].ToString();

                    if (EmployeeRow["JoiningDate"].ToString() + "" != "")
                    {
                        ObjEmployee.PostingDate = DateTime.Parse(EmployeeRow["JoiningDate"].ToString());
                        ;
                    }

                    ObjEmployee.DepartmentID = int.Parse(EmployeeRow["DepartmentID"].ToString());
                    ObjEmployee.DepartmentDescription = EmployeeRow["DepartmentDescription"].ToString();

                    ObjEmployee.DesignationID = int.Parse(EmployeeRow["DesignationID"].ToString());
                    ObjEmployee.DesignationDescription = EmployeeRow["DesignationDescription"].ToString();

                    ObjEmployee.OfficeID = (string.IsNullOrEmpty(EmployeeRow["OfficeId"].ToString()) ? 0 : int.Parse(EmployeeRow["OfficeId"].ToString()));
                    ObjEmployee.OfficeName = EmployeeRow["OfficeName"].ToString();

                    ObjEmployee.ReferenceLetterNumber = EmployeeRow["ReferenceLetterNumber"].ToString();
                    ObjEmployee.ServiceStatus = EmployeeRow["ServiceStatus"].ToString();
                    ObjEmployee.ServiceType = EmployeeRow["ServiceType"].ToString();
                    ObjEmployee.Remarks = EmployeeRow["Remarks"].ToString();

                    ObjEmployee.BioDeviceEmployeeID = EmployeeRow["BioDeviceEmployeeID"].ToString();

                    ObjEmployee.EmployeeServiceDetailsID = (EmployeeRow["EmployeeServiceDetailsID"].ToString() + "" != "" ? int.Parse(EmployeeRow["EmployeeServiceDetailsID"].ToString()) : -1);

                    if (EmployeeRow["EmployeePhoto"].ToString() != "")
                    {
                        ObjEmployee.Picture = (byte[])EmployeeRow["EmployeePhoto"];
                    }

                    if (EmployeeRow["EmployeeSignature"].ToString() != "")
                    {
                        ObjEmployee.Signature = (byte[])EmployeeRow["EmployeeSignature"];
                    }

                    ObjEmployee.ModifiedBy = (EmployeeRow["ModifiedBy"].ToString() + "" != "" ? int.Parse(EmployeeRow["ModifiedBy"].ToString()) : -1);

                    if (EmployeeRow["DateModified"].ToString() + "" != "")
                    {
                        ObjEmployee.DateOfModify = DateTime.Parse(EmployeeRow["DateModified"].ToString());
                    }

                    ObjEmployee.AddedBy = (EmployeeRow["AddedBy"].ToString() + "" != "" ? int.Parse(EmployeeRow["AddedBy"].ToString()) : -1);

                    if (EmployeeRow["AddedBy"].ToString() + "" == "")
                    {
                        ObjEmployee.DateOfCreate = DateTime.Parse(EmployeeRow["AddedBy"].ToString());
                    }

                    if (EmployeeRow["ReportingToEmployeeID"].ToString() != "")
                    {
                        ObjEmployee.ReportingToEmployeeID = int.Parse(EmployeeRow["ReportingToEmployeeID"].ToString());
                        if (EmployeeRow["ReportingToEffectiveDateFrom"].ToString() != "")
                        {
                            ObjEmployee.ReportingToEffectiveDateFrom = EmployeeRow["ReportingToEffectiveDateFrom"].ToString();
                        }
                    }
                    else
                    {
                        ObjEmployee.ReportingToEmployeeID = -1;
                    }
                    ObjEmployee.UserID = int.Parse(EmployeeRow["UserID"].ToString());
                    ObjEmployee.UserName = "";

                }
                else
                {
                    ObjEmployee = null;
                }
                return ObjEmployee;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<StaffMaster> GetReportingEmployeesAllByEmployee(int EmployeeID)
        {
            try
            {
                DataTable EmployeeTable = new DataTable();
                EmployeeTable = StaffMasterDataAccess.GetInstance.GetReportingEmployeesAllByEmployee(EmployeeID);

                List<StaffMaster> EmployeeList = new List<StaffMaster>();

                foreach (DataRow dr in EmployeeTable.Rows)
                {
                    StaffMaster ObjStaffMaster = new StaffMaster();

                    ObjStaffMaster.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                    ObjStaffMaster.EmployeeCode = dr["EmployeeCode"].ToString();
                    ObjStaffMaster.EmployeeName = dr["EmployeeName"].ToString().Trim();
                    EmployeeList.Add(ObjStaffMaster);
                }
                return EmployeeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<StaffMaster> GetReportingEmployeesEmailAllByEmployee(int EmployeeID)
        {
            try
            {
                DataTable EmployeeTable = new DataTable();
                EmployeeTable = StaffMasterDataAccess.GetInstance.GetReportingEmployeesEmailAllByEmployee(EmployeeID);

                List<StaffMaster> EmployeeList = new List<StaffMaster>();

                foreach (DataRow dr in EmployeeTable.Rows)
                {
                    StaffMaster ObjStaffMaster = new StaffMaster();

                    ObjStaffMaster.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                    //ObjEmployee.EmployeeName = dr["EmployeeName"].ToString().Trim();
                    ObjStaffMaster.EmailID = dr["EmailID"].ToString().Trim();



                    ObjStaffMaster.ReportingToEmployeeID = int.Parse(dr["ReportingToEmployeeID"].ToString());
                    //ObjEmployee.ReportingToEmployeeName = dr["ReportingToEmployeeName"].ToString();



                    ObjStaffMaster = GetEmployeeDetailsByID(int.Parse(dr["EmployeeID"].ToString()));
                    EmployeeList.Add(ObjStaffMaster);
                }
                return EmployeeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        //For GuarantorLoan Reports

        public static List<StaffMaster> GetEmployeeDetailsByGuarantorLoan(string OfficeIDs, string DateFrom, string DateTo, string ApprovalStatus)
        {
            List<StaffMaster> GetEmployeeList = new List<StaffMaster>();

            DataTable GetFieldForceChain = new DataTable();
            GetFieldForceChain = StaffMasterDataAccess.GetInstance.GetEmployeeDetailsByGuarantorLoan(OfficeIDs, DateFrom, DateTo, ApprovalStatus);

            foreach (DataRow dr in GetFieldForceChain.Rows)
            {
                StaffMaster TheStaffMaster = new StaffMaster();
                TheStaffMaster.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                TheStaffMaster.EmployeeCode = dr["EmployeeCode"].ToString();
                TheStaffMaster.EmployeeName = dr["EmployeeName"].ToString();
                TheStaffMaster.DepartmentDescription = dr["DepartmentDescription"].ToString();
                TheStaffMaster.DesignationDescription = dr["DesignationDescription"].ToString();

                GetEmployeeList.Add(TheStaffMaster);
            }
            return GetEmployeeList;
        }

        public static List<StaffMaster> GetEmployeeDetailsByFieldForce(string OfficeIDs, string DateFrom, string DateTo, string ApprovalStatus)
        {
            List<StaffMaster> GetEmployeeList = new List<StaffMaster>();

            DataTable GetFieldForceChain = new DataTable();
            GetFieldForceChain = StaffMasterDataAccess.GetInstance.GetEmployeeDetailsByFieldForce(OfficeIDs, DateFrom, DateTo, ApprovalStatus);

            foreach (DataRow dr in GetFieldForceChain.Rows)
            {
                StaffMaster TheStaffMaster = new StaffMaster();
                TheStaffMaster.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                TheStaffMaster.EmployeeCode = dr["EmployeeCode"].ToString();
                TheStaffMaster.EmployeeName = dr["EmployeeName"].ToString();
                TheStaffMaster.DepartmentDescription = dr["DepartmentDescription"].ToString();
                TheStaffMaster.DesignationDescription = dr["DesignationDescription"].ToString();

                GetEmployeeList.Add(TheStaffMaster);
            }
            return GetEmployeeList;
        }
        //Employee Details 
        public static List<StaffMaster> GetEmployeesListbyofficeid(int OfficeID)
        {
            DataTable EmployeeTable = StaffMasterDataAccess.GetInstance.GetEmployeesListbyofficeid(OfficeID);
            List<StaffMaster> EmployeeList = ConvertDatarowToObject(EmployeeTable);

            return EmployeeList;
        }
        #endregion
    }
}
