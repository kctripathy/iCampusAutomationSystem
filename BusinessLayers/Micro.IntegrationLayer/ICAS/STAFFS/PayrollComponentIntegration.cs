using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using System.Data;
using System.Reflection;
using Micro.DataAccessLayer.ICAS.STAFFS;

namespace Micro.IntegrationLayer.ICAS.STAFFS
{
    public partial class PayrollComponentIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

        public static Payrollcomponent DataRowToObject(DataRow dr)
        {
            Payrollcomponent TheComponent = new Payrollcomponent();
            TheComponent.PayComponentID = int.Parse(dr["PayComponentID"].ToString());
            TheComponent.PayComponentDescription = dr["PayComponentDescription"].ToString();
            TheComponent.PayComponentType = dr["PayComponentType"].ToString();
            TheComponent.AddedByName = dr["AddedByName"].ToString();
            TheComponent.AddedByCode = dr["AddedByCode"].ToString();

            return TheComponent;
        }
        public static EmpPayrollcomponent EmpPayComponentRowToObject(DataRow dr)
        {
            EmpPayrollcomponent ThePayComponent = new EmpPayrollcomponent();
            ThePayComponent.RecordNo = int.Parse(dr["RecordNumber"].ToString());
            ThePayComponent.PayComponentID = int.Parse(dr["PayComponentID"].ToString());
            ThePayComponent.PayComponentName = dr["PayComponentName"].ToString();
            ThePayComponent.PayComponentType = dr["PayComponentType"].ToString();
            ThePayComponent.PayComponentCategory = dr["PayComponentCategory"].ToString();   
            ThePayComponent.PayComponentDesc = dr["PayComponentType"].ToString() + "||" + dr["PayComponentID"].ToString();
            ThePayComponent.PayComponentAmount = dr["PayAmount"].ToString();           
            ThePayComponent.SessionID = int.Parse(dr["SessionID"].ToString());
            ThePayComponent.AddedByName = dr["AddedByName"].ToString();
            ThePayComponent.AddedByCode = dr["AddedByCode"].ToString();

            return ThePayComponent;
        }
        public static int InsertEmpPayRollComponent(DataTable dt,EmpPayrollcomponent theComponent)
        {
            try
            {
                return PayrollComponentDataAccess.GetInstance.InsertEmployeeComponent(dt,theComponent);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static int InsertSingleEmployeeComponent(EmpPayrollcomponent theComponent)
        {
            try
            {
                return PayrollComponentDataAccess.GetInstance.InsertSingleEmployeeComponent(theComponent);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static int UpdateSingleEmployeeComponent(EmpPayrollcomponent theComponent)
        {
            try
            {
                return PayrollComponentDataAccess.GetInstance.UpdateSingleEmployeeComponent(theComponent);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static int DeleteSingleEmployeeComponent(EmpPayrollcomponent theComponent)
        {
            try
            {
                return PayrollComponentDataAccess.GetInstance.DeleteSingleEmployeeComponent(theComponent);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static List<Payrollcomponent> GetPayrollComponentList()
        {
            List<Payrollcomponent> ComponentList = new List<Payrollcomponent>();
            DataTable ComponentTable = PayrollComponentDataAccess.GetInstance.GetPayrollComponentList();

            foreach (DataRow dr in ComponentTable.Rows)
            {
                Payrollcomponent TheComponent = DataRowToObject(dr);
                ComponentList.Add(TheComponent);
            }
            return ComponentList;
        }
        public static List<EmpPayrollcomponent> GetEmployeePayrollComponentList(int EmployeeID)
        {
            List<EmpPayrollcomponent> EmployeeComponentList = new List<EmpPayrollcomponent>();
            DataTable EmployeeComponentTable = PayrollComponentDataAccess.GetInstance.GetEmployeePayrollComponentList(EmployeeID);
            foreach (DataRow dr in EmployeeComponentTable.Rows)
            {
                EmpPayrollcomponent TheComponent = EmpPayComponentRowToObject(dr);
                EmployeeComponentList.Add(TheComponent);
            }
            return EmployeeComponentList;
        }
    }
}
#endregion
    
