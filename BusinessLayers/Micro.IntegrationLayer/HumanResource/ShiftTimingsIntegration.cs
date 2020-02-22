#region System Namespace

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

#endregion

#region Micro Namespaces

using Micro.Objects.HumanResource;
using Micro.DataAccessLayer.HumanResource;
using Micro.Commons;


#endregion

namespace Micro.IntegrationLayer.HumanResource
{
    public partial class ShiftTimingsIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertShiftTimings(ShiftTiming _ShiftTimings)
        {
            try
            {
                return ShiftTimingsDataAccess.GetInstance.InsertShiftTimings(_ShiftTimings);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateShiftTimings(ShiftTiming _ShiftTimings)
        {
            try
            {
                return ShiftTimingsDataAccess.GetInstance.UpdateShiftTimings(_ShiftTimings);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteShiftTimings(int ShiftTimingsID)
        {
            try
            {
                return ShiftTimingsDataAccess.GetInstance.DeleteShiftTimings(ShiftTimingsID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        #endregion

        #region Data Retrive Mathods

        public static List<ShiftTiming> SetShiftTimingsList(DataTable ShiftTimingsTable)
        {
            try
            {
                List<ShiftTiming> _ShiftTimingsList = new List<ShiftTiming>();

                foreach (DataRow dr in ShiftTimingsTable.Rows)
                {
                    ShiftTiming _ShiftTimings = new ShiftTiming();
                    _ShiftTimings.ShiftTimingID = int.Parse(dr["ShiftTimingID"].ToString());
                    _ShiftTimings.ShiftID = int.Parse(dr["ShiftID"].ToString());
                    _ShiftTimings.ShiftOfficewiseID = int.Parse(dr["ShiftOfficewiseID"].ToString());
                    _ShiftTimings.ShiftDescription = dr["ShiftDescription"].ToString();
                    _ShiftTimings.ShiftAlias = dr["ShiftAlias"].ToString();
                    _ShiftTimings.OfficeID = int.Parse(dr["OfficeID"].ToString());


                    _ShiftTimings.InTime = DateTime.Parse(dr["InTime"].ToString());


                    _ShiftTimings.OutTime = DateTime.Parse(dr["OutTime"].ToString());
                    _ShiftTimings.WeeklyOffDay = dr["WeeklyOffDay"].ToString();
                    _ShiftTimings.CalculationMode = dr["CalculationMode"].ToString();
                    _ShiftTimings.EffectiveDate = DateTime.Parse(dr["EffectiveDate"].ToString());

                    _ShiftTimings.IsActive = Boolean.Parse(dr["IsActive"].ToString());
                    _ShiftTimings.IsDeleted = Boolean.Parse(dr["IsDeleted"].ToString());

                    _ShiftTimingsList.Add(_ShiftTimings);
                }

                return _ShiftTimingsList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<ShiftTiming> GetShiftTimingsByOfficeID(int OfficeID)
        {
            try
            {
                return SetShiftTimingsList(ShiftTimingsDataAccess.GetInstance.GetShiftTimingsByOfficeID(OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<ShiftTiming> GetShiftTimingsByOfficeIDandDepartmentID(int DepartmentID)
        {
            try
            {
                return SetShiftTimingsList(ShiftTimingsDataAccess.GetInstance.GetShiftTimingsByOfficeIDandDepartmentID(DepartmentID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static List<ShiftTiming> GetShiftTimingsByOfficeIDandDepartmentID(int DepartmentID, int OfficeID)
        {
            try
            {
                return SetShiftTimingsList(ShiftTimingsDataAccess.GetInstance.GetShiftTimingsByOfficeIDandDepartmentID(DepartmentID, OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static List<ShiftTiming> GetCompanyShiftTimings()
        {
            try
            {
                return SetShiftTimingsList(ShiftTimingsDataAccess.GetInstance.GetCompanyShiftTimings());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
