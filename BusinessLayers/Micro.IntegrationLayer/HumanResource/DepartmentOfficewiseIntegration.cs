#region System Namespace

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

#endregion

#region Micro Namespaces

using Micro.Objects.HumanResource;
using Micro.DataAccessLayer.HumanResource;


#endregion

namespace Micro.IntegrationLayer.HumanResource
{
    public partial class DepartmentOfficewiseIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertDepartmentOfficewise(DepartmentOfficewise _DepartmentOfficewise)
        {
            try
            {
                return DepartmentOfficewiseDataAccess.GetInstance.InsertDepartmentOfficewise(_DepartmentOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateDepartmentOfficewise(DepartmentOfficewise _DepartmentOfficewise)
        {
            try
            {
                return DepartmentOfficewiseDataAccess.GetInstance.UpdateDepartmentOfficewise(_DepartmentOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteDepartmentOfficewise(int DepartmentOfficewiseID)
        {
            try
            {
                return DepartmentOfficewiseDataAccess.GetInstance.DeleteDepartmentOfficewise(DepartmentOfficewiseID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static List<DepartmentOfficewise> GetDepartmentOfficewiseByOfficeID(int OfficeID = -1)
        {
            try
            {
                DataTable DepartmentOfficewiseRows = DepartmentOfficewiseDataAccess.GetInstance.GetDepartmentOfficewiseByOffice(OfficeID);

                List<DepartmentOfficewise> _DepartmentOfficewiseList = new List<DepartmentOfficewise>();

                foreach (DataRow dr in DepartmentOfficewiseRows.Rows)
                {
                    DepartmentOfficewise _DepartmentOfficewise = new DepartmentOfficewise();

                    _DepartmentOfficewise.DepartmentOfficewiseID = int.Parse(dr["DepartmentOfficewiseID"].ToString());
                    _DepartmentOfficewise.DEPARTMENT.DepartmentID = int.Parse(dr["DepartmentID"].ToString());
                    _DepartmentOfficewise.Office.OfficeID = int.Parse(dr["OfficeID"].ToString());

                    _DepartmentOfficewise.IsActive = (dr["IsActive"].ToString() == "True" ? true : false);
                    _DepartmentOfficewise.IsDeleted = (dr["IsDeleted"].ToString() == "True" ? true : false);

                    _DepartmentOfficewiseList.Add(_DepartmentOfficewise);
                }

                return _DepartmentOfficewiseList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
