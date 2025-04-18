﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using Micro.DataAccessLayer.ICAS.STAFFS;
using System.Data;
using System.Reflection;

namespace Micro.IntegrationLayer.ICAS.STAFFS
{
  public partial  class DepartmentIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertDepartment(Department theDepartment)
        {
            return DepartmentDataAccess.GetInstance.InsertDepartment(theDepartment);
        }

        public static int UpdateDepartment(Department theDepartment)
        {
            return DepartmentDataAccess.GetInstance.UpdateDepartment(theDepartment);
        }

        public static Department GetDepartmentById(int DepartmentID)
        {
            try
            {
                Department Dept = new Department();
                DataRow DtRow = DepartmentDataAccess.GetInstance.GetDepartmentsByDepartmentID(DepartmentID);
                if (DtRow != null)
                {
                    Dept.DepartmentID = DepartmentID;
                    Dept.DepartmentDescription = DtRow["DepartmentDescription"].ToString();
                    Dept.DepartmentContent1 = DtRow["DeptContent1"].ToString();
                    Dept.DepartmentContent2 = DtRow["DeptContent2"].ToString();
                    Dept.DepartmentContent3 = DtRow["DeptContent3"].ToString();
                    Dept.DepartmentHeadId = int.Parse(DtRow["DeptHeadEmployeeId"].ToString());
                    Dept.ParentDepartmentId = int.Parse(DtRow["ParentDepartmentId"].ToString());
                    Dept.ParentDepartmentDescription = DtRow["ParentDepartmentDescription"].ToString();

                    if (DtRow["IsActive"].ToString() == "True")
                    {
                        Dept.IsActive = true;
                    }
                    else
                    {
                        Dept.IsActive = false;
                    }

                    if (DtRow["IsDeleted"].ToString() == "True")
                    {
                        Dept.IsDeleted = true;
                    }
                    else
                    {
                        Dept.IsDeleted = false;
                    }
                }
                return Dept;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteDepartment(Department theDepartment)
        {
            return DepartmentDataAccess.GetInstance.DeleteDepartment(theDepartment);
        }

        #endregion

        #region Data Retrive Mathods

        public static List<Department> GetDepartments()
        {
            try
            {
                DataTable DepartmentsTable = DepartmentDataAccess.GetInstance.GetDepartments();
                List<Department> DepartmentList = new List<Department>();
                foreach (DataRow dr in DepartmentsTable.Rows)
                {
                    Department ObjDepartment = new Department();
                    ObjDepartment.DepartmentID = int.Parse(dr["DepartmentID"].ToString());
                    ObjDepartment.DepartmentName = dr["DepartmentDescription"].ToString();

                    ObjDepartment.DepartmentHeadId = int.Parse(dr["DepartmentHeadId"].ToString());
                    ObjDepartment.DepartmentHeadName = dr["DepartmentHeadName"].ToString();
                    
                    ObjDepartment.DepartmentContent1 = dr["DepartmentContent1"].ToString();
                    ObjDepartment.DepartmentContent2 = dr["DepartmentContent2"].ToString();
                    ObjDepartment.DepartmentContent3 = dr["DepartmentContent3"].ToString();

                    ObjDepartment.IsActive = (Boolean)dr["IsActive"];
                    ObjDepartment.IsDeleted = (Boolean)dr["IsDeleted"];

                    ObjDepartment.DepartmentHeadId = int.Parse(dr["DepartmentHeadId"].ToString());

                    ObjDepartment.Staffs = StaffMasterIntegration.GetStaffs().Where((dept) => dept.DepartmentDescription == ObjDepartment.DepartmentName).ToList();
                    DepartmentList.Add(ObjDepartment);
                }
                return DepartmentList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }


        public static List<Department> GetDepartmentsList(String searchText = null, bool showDeleted = false)
        {
            try
            {
                DataTable DepartmentsTable = DepartmentDataAccess.GetInstance.GetDepartmentsAll(searchText, showDeleted);
                List<Department> DepartmentList = new List<Department>();
                foreach (DataRow dr in DepartmentsTable.Rows)
                {
                    Department ObjDepartment = new Department();
                    ObjDepartment.DepartmentID = int.Parse(dr["DepartmentID"].ToString());
                    ObjDepartment.DepartmentName = dr["DepartmentDescription"].ToString();
                    ObjDepartment.DepartmentDescription = dr["DepartmentDescription"].ToString();
                    ObjDepartment.ParentDepartmentId = int.Parse(dr["ParentDepartmentID"].ToString());
                    ObjDepartment.ParentDepartmentDescription = dr["ParentDepartmentDescription"].ToString();
                    ObjDepartment.DepartmentContent1 = dr["DepartmentContent1"].ToString();
                    ObjDepartment.DepartmentContent2 = dr["DepartmentContent2"].ToString();
                    ObjDepartment.DepartmentContent3 = dr["DepartmentContent3"].ToString();
                    ObjDepartment.DepartmentHeadId = int.Parse(dr["DepartmentHeadId"].ToString());
                    ObjDepartment.DepartmentHeadName = dr["DepartmentHeadName"].ToString();
                    ObjDepartment.IsActive = (Boolean)dr["IsActive"];

                    DepartmentList.Add(ObjDepartment);
                }
                return DepartmentList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<Department> GetDepartmentsListByOffice(int OfficeID = -1, String searchText = null, bool showDeleted = false)
        {
            try
            {
                DataTable DepartmentsTable = DepartmentDataAccess.GetInstance.GetDepartmentsAllByOffice(OfficeID, searchText, showDeleted);
                List<Department> DepartmentList = new List<Department>();

                foreach (DataRow dr in DepartmentsTable.Rows)
                {
                    Department ObjDepartment = new Department();
                    ObjDepartment.DepartmentID = int.Parse(dr["DepartmentID"].ToString());
                    ObjDepartment.DepartmentDescription = dr["DepartmentDescription"].ToString();
                    //_Dept.ParentDepartmentId = int.Parse(dr["ParentDepartmentID"].ToString());
                    //_Dept.ParentDepartmentDescription = dr["ParentDepartmentDescription"].ToString();
                    ObjDepartment.IsActive = (Boolean)dr["IsActive"];
                    if (ObjDepartment.IsActive == true)
                    {
                        DepartmentList.Add(ObjDepartment);
                    }


                }
                return DepartmentList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
