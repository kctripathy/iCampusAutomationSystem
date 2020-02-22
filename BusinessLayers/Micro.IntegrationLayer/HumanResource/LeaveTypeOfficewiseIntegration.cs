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
    public partial class LeaveTypeOfficewiseIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertLeaveTypeOfficewise(LeaveTypeOfficewise _LeaveTypeOfficewise)
        {
            try
            {
                return LeaveTypeOfficewiseDataAccess.GetInstance.InsertLeaveTypeOfficewise(_LeaveTypeOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateLeaveTypeOfficewise(LeaveTypeOfficewise _LeaveTypeOfficewise)
        {
            try
            {
                return LeaveTypeOfficewiseDataAccess.GetInstance.UpdateLeaveTypeOfficewise(_LeaveTypeOfficewise);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteLeaveTypeOfficewise(int LeaveTypeOfficewiseID)
        {
            try
            {
                return LeaveTypeOfficewiseDataAccess.GetInstance.DeleteLeaveTypeOfficewise(LeaveTypeOfficewiseID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static List<LeaveTypeOfficewise> GetLeaveTypeOfficewiseByOfficeID(int OfficeID = -1)
        {
            try
            {
                DataTable LeaveTypeOfficewiseRows = LeaveTypeOfficewiseDataAccess.GetInstance.GetLeaveTypeOfficewiseByOfficeID();

                List<LeaveTypeOfficewise> _LeaveTypeOfficewiseList = new List<LeaveTypeOfficewise>();

                foreach (DataRow dr in LeaveTypeOfficewiseRows.Rows)
                {
                    LeaveTypeOfficewise _LeaveTypeOfficewise = new LeaveTypeOfficewise();

                    _LeaveTypeOfficewise.LeaveTypeOfficewiseID = int.Parse(dr["LeaveTypeOfficewiseID"].ToString());
                    _LeaveTypeOfficewise.LeaveTypeID = int.Parse(dr["LeaveTypeID"].ToString());
                    _LeaveTypeOfficewise.LeaveTypeDescription = dr["LeaveTypeDescription"].ToString();
                    _LeaveTypeOfficewise.LeaveTypeAlias = dr["LeaveTypeAlias"].ToString();
                    _LeaveTypeOfficewise.Office.OfficeID = int.Parse(dr["OfficeID"].ToString());

                    _LeaveTypeOfficewise.IsActive = Boolean.Parse(dr["IsActive"].ToString());
                    _LeaveTypeOfficewise.IsDeleted = Boolean.Parse(dr["IsDeleted"].ToString());

                    _LeaveTypeOfficewiseList.Add(_LeaveTypeOfficewise);

                }

                return _LeaveTypeOfficewiseList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
