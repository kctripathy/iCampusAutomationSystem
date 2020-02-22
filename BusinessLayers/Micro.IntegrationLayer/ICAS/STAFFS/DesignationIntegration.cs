using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using Micro.DataAccessLayer.ICAS.STAFFS;
using System.Reflection;
using System.Data;

namespace Micro.IntegrationLayer.ICAS.STAFFS
{
  public  class DesignationIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertDesignation(Designation Desg)
        {
            try
            {
                return DesignationDataAccess.GetInstance.InsertDesignation(Desg);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateDesignation(Designation Desg)
        {
            try
            {
                return DesignationDataAccess.GetInstance.UpdateDesignation(Desg);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteDesignation(int DesignationID)
        {
            try
            {
                return DesignationDataAccess.GetInstance.DeleteDesignation(DesignationID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static List<Designation> GetDesignationsList(System.String searchText = null, bool showDeleted = false)
        {
            try
            {
                DataTable DesignationsTable = DesignationDataAccess.GetInstance.GetDesignationsAll(searchText, showDeleted);
                List<Designation> DesignationList = new List<Designation>();
                foreach (DataRow dr in DesignationsTable.Rows)
                {
                    Designation _Desingation = new Designation();
                    _Desingation.DesignationID = int.Parse(dr["DesignationID"].ToString());
                    _Desingation.DesignationDescription = dr["DesignationDescription"].ToString();

                    _Desingation.RoleID = int.Parse(dr["RoleID"].ToString());
                    _Desingation.RoleDescription = dr["RoleDescription"].ToString();

                    if (dr["ReportingToDesignationID"].ToString() != "")
                    {
                        _Desingation.ReportingToDesignationID = int.Parse(dr["ReportingToDesignationID"].ToString());
                    }

                    _Desingation.ReportingToDesignationDescription = dr["ReportingToDesignationDescription"].ToString();

                    _Desingation.IsActive = Boolean.Parse(dr["IsActive"].ToString());
                    _Desingation.IsDeleted = Boolean.Parse(dr["IsDeleted"].ToString());

                    DesignationList.Add(_Desingation);
                }
                return DesignationList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<Designation> GetDesignationsListByOffice(int OfficeID = -1, String searchText = null, bool showDeleted = false)
        {
            try
            {
                DataTable DesignationsTable = DesignationDataAccess.GetInstance.GetDesignationsAllByOffice(OfficeID, searchText, showDeleted);
                List<Designation> DesignationList = new List<Designation>();
                foreach (DataRow dr in DesignationsTable.Rows)
                {
                    Designation _Desingation = new Designation();
                    _Desingation.DesignationID = int.Parse(dr["DesignationID"].ToString());
                    _Desingation.DesignationDescription = dr["DesignationDescription"].ToString();

                    _Desingation.RoleID = int.Parse(dr["RoleID"].ToString());
                    _Desingation.RoleDescription = dr["RoleDescription"].ToString();

                    if (dr["ReportingToDesignationID"].ToString() != "")
                    {
                        _Desingation.ReportingToDesignationID = int.Parse(dr["ReportingToDesignationID"].ToString());
                        _Desingation.ReportingToDesignationDescription = dr["ReportingToDesignationDescription"].ToString();
                    }

                    else
                    {
                        _Desingation.ReportingToDesignationID = -1;
                        _Desingation.ReportingToDesignationDescription = "";
                    }

                    _Desingation.IsActive = Boolean.Parse(dr["IsActive"].ToString());
                    _Desingation.IsDeleted = Boolean.Parse(dr["IsDeleted"].ToString());

                    if (_Desingation.IsActive == true)
                    {
                        DesignationList.Add(_Desingation);
                    }
                }
                return DesignationList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static Designation GetDesignationById(int DesignationID)
        {
            try
            {
                Designation Dept = new Designation();
                DataRow DtRow = DesignationDataAccess.GetInstance.GetDesignationByDesignationID(DesignationID);
                if (DtRow != null)
                {
                    Dept.DesignationID = DesignationID;
                    Dept.DesignationDescription = DtRow["DesignationDescription"].ToString();
                    Dept.RoleID = int.Parse(DtRow["RoleID"].ToString());
                    Dept.RoleDescription = DtRow["RoleDescription"].ToString();

                    if (DtRow["ReportingToDesignationID"].ToString() != "")
                    {
                        Dept.ReportingToDesignationID = int.Parse(DtRow["ReportingToDesignationID"].ToString());
                        Dept.ReportingToDesignationDescription = DtRow["ReportingToDesignationDescription"].ToString();
                    }

                    Dept.IsActive = Boolean.Parse(DtRow["IsActive"].ToString());
                    Dept.IsDeleted = Boolean.Parse(DtRow["IsDeleted"].ToString());
                }
                return Dept;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
