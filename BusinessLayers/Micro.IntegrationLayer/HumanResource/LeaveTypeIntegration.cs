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
    public partial class LeaveTypeIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertLeaveType(LeaveType theLeaveType)
        {
            try
            {
                return LeaveTypeDataAccess.GetInstance.InsertLeaveType(theLeaveType);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateLeaveType(LeaveType theLeaveType)
        {
            try
            {
                return LeaveTypeDataAccess.GetInstance.UpdateLeaveType(theLeaveType);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public static int DeleteLeaveType(int LeaveTypeID)
        {
            try
            {
                return LeaveTypeDataAccess.GetInstance.DeleteLeaveType(LeaveTypeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static List<LeaveTypeSettings> GetLeaveBalanceByEmployee(int EmployeeID)
        {
            try
            {
                DataTable _LeaveBalance = LeaveBalanceDataAccess.GetInstance.GetLeaveBalanceByEmployee(EmployeeID);

                List<LeaveTypeSettings> _LeaveBalanceList = new List<LeaveTypeSettings>();

                foreach (DataRow DtRow in _LeaveBalance.Rows)
                {
                    LeaveTypeSettings _LeaveTypeSettings = new LeaveTypeSettings();

                    _LeaveTypeSettings.LeaveTypeID = int.Parse(DtRow["LeaveTypeID"].ToString());
                    _LeaveTypeSettings.LeaveTypeDescription = DtRow["LeaveTypeDescription"].ToString();
                    _LeaveTypeSettings.LeaveTypeAlias = DtRow["LeaveTypeAlias"].ToString();
                    _LeaveTypeSettings.TotalNumberOfLeavesElligibleToAvail = int.Parse(DtRow["TotalNumberOfLeavesElligibleToAvail"].ToString());

                    _LeaveTypeSettings.NumberOfConsecutiveDaysAllowed = int.Parse(DtRow["NumberOfConsecutiveDaysAllowed"].ToString());
                    _LeaveTypeSettings.AccountingYear = DtRow["AccountingYear"].ToString();
                    _LeaveTypeSettings.Quarter = DtRow["Quarter"].ToString();

                    _LeaveBalanceList.Add(_LeaveTypeSettings);
                }
                return _LeaveBalanceList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<LeaveType> GetLeaveTypeList(string searchText = null, bool showDeleted = false)
        {
            try
            {
                List<LeaveType> LeaveTypeList = new List<LeaveType>();

                DataTable LeaveTypeTable = new DataTable();
                LeaveTypeTable = LeaveTypeDataAccess.GetInstance.GetLeaveTypeList(searchText, showDeleted);

                foreach (DataRow dr in LeaveTypeTable.Rows)
                {
                    LeaveType _LeaveType = new LeaveType();

                    _LeaveType.LeaveTypeID = int.Parse(dr["LeaveTypeID"].ToString());
                    _LeaveType.LeaveTypeDescription = dr["LeaveTypeDescription"].ToString();
                    _LeaveType.LeaveTypeAlias = dr["LeaveTypeAlias"].ToString();
                    _LeaveType.IsActive = Boolean.Parse(dr["IsActive"].ToString());

                    LeaveTypeList.Add(_LeaveType);
                }

                return LeaveTypeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static LeaveType GetLeaveTypeByID(int LeaveTypeID)
        {
            try
            {
                DataRow LeaveTypeRow = LeaveTypeDataAccess.GetInstance.GetLeaveTypeByID(LeaveTypeID);

                LeaveType _LeaveType = new LeaveType();

                _LeaveType.LeaveTypeID = int.Parse(LeaveTypeRow["LeaveTypeID"].ToString());
                _LeaveType.LeaveTypeDescription = LeaveTypeRow["LeaveTypeDescription"].ToString();
                _LeaveType.LeaveTypeAlias = LeaveTypeRow["LeaveTypeAlias"].ToString();
                //TheLeaveType.NumberOfDaysAllowed = int.Parse(LeaveTypeRow["NumberOfDaysAllowed"].ToString());
                //TheLeaveType.NumberOfConsecutiveDaysAllowed = int.Parse(LeaveTypeRow["NumberOfConsecutiveDaysAllowed"].ToString());
                //TheLeaveType.ForGender = LeaveTypeRow["ForGender"].ToString();

                _LeaveType.IsActive = bool.Parse(LeaveTypeRow["IsActive"].ToString());
                _LeaveType.IsDeleted = bool.Parse(LeaveTypeRow["IsDeleted"].ToString());

                return _LeaveType;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
