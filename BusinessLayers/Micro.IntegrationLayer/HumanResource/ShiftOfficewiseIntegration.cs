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
    public partial class ShiftOfficewiseIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertShiftOfficewise(ShiftOfficewise _ShiftOfficewise)
        {
            try
            {
                return ShiftOfficewiseDataAccess.GetInstance.InsertShiftOfficewise(_ShiftOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public static int UpdateShiftOfficewise(ShiftOfficewise _ShiftOfficewise)
        {
            try
            {
                return ShiftOfficewiseDataAccess.GetInstance.UpdateShiftOfficewise(_ShiftOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteShiftOfficewise(int ShiftOfficewiseID)
        {
            try
            {
                return ShiftOfficewiseDataAccess.GetInstance.DeleteShiftOfficewise(ShiftOfficewiseID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static List<ShiftOfficewise> GetShiftOfficewiseByOfficeID(int OfficeID )
        {
            try
            {
                DataTable ShiftOfficewiseRows = ShiftOfficewiseDataAccess.GetInstance.GetShiftOfficewiseByOfficeID(OfficeID);

                List<ShiftOfficewise> _ShiftOfficewiseList = new List<ShiftOfficewise>();

                foreach (DataRow dr in ShiftOfficewiseRows.Rows)
                {
                    ShiftOfficewise _ShiftOfficewise = new ShiftOfficewise();

                    _ShiftOfficewise.ShiftOfficewiseID = int.Parse(dr["ShiftOfficewiseID"].ToString());
                    _ShiftOfficewise.ShiftID = int.Parse(dr["ShiftID"].ToString());
                    _ShiftOfficewise.ShiftDescription = dr["ShiftDescription"].ToString();
                    _ShiftOfficewise.ShiftAlias = dr["ShiftAlias"].ToString();
                   // _ShiftOfficewise.InTime = Convert.ToDateTime(dr["InTime"].ToString()).ToShortTimeString();
                  //  _ShiftOfficewise.OutTime = Convert.ToDateTime(dr["OutTime"].ToString()).ToShortTimeString();
                   
                    _ShiftOfficewise.Office.OfficeID = int.Parse(dr["OfficeID"].ToString());

                    _ShiftOfficewise.IsActive = Boolean.Parse(dr["IsActive"].ToString());
                    //_ShiftOfficewise.IsDeleted = Boolean.Parse(dr["IsDeleted"].ToString());

                    _ShiftOfficewiseList.Add(_ShiftOfficewise);
                }

                return _ShiftOfficewiseList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
