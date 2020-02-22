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
    public partial class ShiftIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertShift(Shift theShift)
        {
            try
            {
                return ShiftDataAccess.GetInstance.InsertShift(theShift);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateShift(Shift theShift)
        {
            try
            {
                return ShiftDataAccess.GetInstance.UpdateShift(theShift);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteShift(Shift theShift)
        {
            return ShiftDataAccess.GetInstance.DeleteShift(theShift);
        }

        #endregion

        #region Data Retrive Mathods

        public static List<Shift> GetShiftList(string searchText = null, bool showDeleted = false)
        {
            try
            {
                List<Shift> ShiftList = new List<Shift>();

                DataTable ShiftTable = new DataTable();
                ShiftTable = ShiftDataAccess.GetInstance.GetShiftsList(searchText, showDeleted);

                foreach (DataRow dr in ShiftTable.Rows)
                {
                    Shift _Shift = new Shift();

                    _Shift.ShiftID = int.Parse(dr["ShiftID"].ToString());
                    _Shift.ShiftDescription = dr["ShiftDescription"].ToString();
                    _Shift.ShiftAlias = dr["ShiftAlias"].ToString();
                    _Shift.IsActive = Boolean.Parse(dr["IsActive"].ToString());

                    ShiftList.Add(_Shift);
                }

                return ShiftList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static Shift GetShiftByID(int ShiftID)
        {
            try
            {
                DataRow ShiftRow = ShiftDataAccess.GetInstance.GetShiftByID(ShiftID);

                Shift _Shift = new Shift();

                _Shift.ShiftID = int.Parse(ShiftRow["ShiftID"].ToString());
                _Shift.ShiftDescription = ShiftRow["ShiftDescription"].ToString();
                _Shift.ShiftAlias = ShiftRow["ShiftAlias"].ToString();

                _Shift.IsActive = bool.Parse(ShiftRow["IsActive"].ToString());
                _Shift.IsDeleted = bool.Parse(ShiftRow["IsDeleted"].ToString());

                return _Shift;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
