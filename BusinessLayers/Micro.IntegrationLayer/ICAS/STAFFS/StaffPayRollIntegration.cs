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
   public class StaffPayRollIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertLeaveApplication(StaffPayRoll StaffPayrollObj)
        {
            try
            {
                return StaffPayrollDataAccess.GetInstance.InsertStaffPayRoll(StaffPayrollObj);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }        

        #endregion

        #region Data Retrive Mathods

        /// <summary>
        /// Convert DataTable Into List<LeaveApplications>
        /// </summary>
        public static List<StaffPayRoll> SetLeaveApplicationList(DataTable DT)
        {
            try
            {
                List<StaffPayRoll> StaffPayrollList = new List<StaffPayRoll>();

                foreach (DataRow DtRow in DT.Rows)
                {
                    StaffPayRoll ObjStaffPAyRoll = new StaffPayRoll();

                    ObjStaffPAyRoll.Year =DtRow["Year"].ToString();
                    ObjStaffPAyRoll.TvNo = int.Parse(DtRow["TvNo"].ToString());
                    ObjStaffPAyRoll.TotalWorkingDays = int.Parse(DtRow["TotalWorkingDays"].ToString());
                    ObjStaffPAyRoll.TotalPresentWorkingDays = int.Parse(DtRow["TotalPresentWorkingDays"].ToString());

                    ObjStaffPAyRoll.SessionID = int.Parse(DtRow["SessionID"].ToString());
                    ObjStaffPAyRoll.PresentDay = int.Parse(DtRow["PresentDay"].ToString());
                    ObjStaffPAyRoll.OtherDeduction =decimal.Parse(DtRow["LeaveTypeDescription"].ToString());
                    ObjStaffPAyRoll.NetPayable = decimal.Parse(DtRow["LeaveTypeAlias"].ToString());

                    ObjStaffPAyRoll.Month= DtRow["DateFrom"].ToString();
                    ObjStaffPAyRoll.GrossPay=decimal.Parse(DtRow["DateTo"].ToString());
                    ObjStaffPAyRoll.FixedDeduction = decimal.Parse(DtRow["LeaveApplicationReason"].ToString());
                    ObjStaffPAyRoll.EmployeeID = int.Parse(DtRow["TotalPresentWorkingDays"].ToString());
                    ObjStaffPAyRoll.BillNo = int.Parse(DtRow["TotalPresentWorkingDays"].ToString());

                    ObjStaffPAyRoll.BillDate = DateTime.Parse(DtRow["DateAdded"].ToString());
                    ObjStaffPAyRoll.BankLoanEMI = decimal.Parse(DtRow["BankLoanEMI"].ToString());               
                    ObjStaffPAyRoll.IsActive = Boolean.Parse(DtRow["IsActive"].ToString());
                    ObjStaffPAyRoll.IsDeleted = Boolean.Parse(DtRow["IsDeleted"].ToString());
                    StaffPayrollList.Add(ObjStaffPAyRoll);
                }

                return StaffPayrollList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Employeewise Applications
        /// </summary>

        public static List<StaffPayRoll> GetPayRollAll(int OfficeID = -1)
        {
            try
            {
                return SetLeaveApplicationList(StaffPayrollDataAccess.GetInstance.GetPayRollAll(OfficeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }       
        #endregion
    }
}
