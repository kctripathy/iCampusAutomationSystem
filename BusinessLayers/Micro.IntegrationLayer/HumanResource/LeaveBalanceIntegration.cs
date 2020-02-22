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
    public partial class LeaveBalanceIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)
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

                    _LeaveTypeSettings.NumberOfConsecutiveDaysAllowed = int.Parse(DtRow["NoOfConsecutiveDaysAllowed"].ToString());
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

        #endregion
    }
}
