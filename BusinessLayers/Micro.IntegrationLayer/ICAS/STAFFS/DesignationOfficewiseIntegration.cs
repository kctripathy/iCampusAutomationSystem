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
   public partial class DesignationOfficewiseIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        //public static int InsertDesignationOfficewise(string DesignationIds)
        //{
        //    try
        //    {
        //        return DesignationOfficewiseDataAccess.GetInstance.InsertDesignationOfficewise(DesignationIds);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }

        //}


        public static int InsertDesignationOfficewise(DesignationOfficewise _DesignationOfficewise)
        {
            try
            {
                return DesignationOfficewiseDataAccess.GetInstance.InsertDesignationOfficewise(_DesignationOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public static int UpdateDesignationOfficewise(DesignationOfficewise _DesignationOfficewise)
        {
            try
            {
                return DesignationOfficewiseDataAccess.GetInstance.UpdateDesignationOfficewise(_DesignationOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteDesignationOfficewise(int DesignationOfficewiseID)
        {
            try
            {
                return DesignationOfficewiseDataAccess.GetInstance.DeleteDesignationOfficewise(DesignationOfficewiseID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static List<DesignationOfficewise> GetDesignationOfficewiseByOfficeID(int OfficeID = -1)
        {
            try
            {
                DataTable DesignationOfficewiseRows = DesignationOfficewiseDataAccess.GetInstance.GetDesignationOfficewiseByOffice(OfficeID);

                List<DesignationOfficewise> _DesignationOfficewiseList = new List<DesignationOfficewise>();

                foreach (DataRow dr in DesignationOfficewiseRows.Rows)
                {
                    DesignationOfficewise _DesignationOfficewise = new DesignationOfficewise();

                    _DesignationOfficewise.DesignationOfficewiseID = int.Parse(dr["DesignationOfficewiseID"].ToString());
                    _DesignationOfficewise.DESIGNATION.DesignationID = int.Parse(dr["DesignationID"].ToString());
                    _DesignationOfficewise.DESIGNATION.DesignationDescription = (dr["DesignationDescription"].ToString());
                    _DesignationOfficewise.Office.OfficeID = int.Parse(dr["OfficeID"].ToString());

                    _DesignationOfficewise.IsActive = Boolean.Parse(dr["IsActive"].ToString());
                    _DesignationOfficewise.IsDeleted = Boolean.Parse(dr["IsDeleted"].ToString());

                    _DesignationOfficewiseList.Add(_DesignationOfficewise);
                }

                return _DesignationOfficewiseList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
