using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using Micro.IntegrationLayer.ICAS.STAFFS;
using System.Reflection;
using System.Windows.Forms;

namespace Micro.BusinessLayer.ICAS.STAFFS
{
   public partial class DepartmentManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DepartmentManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DepartmentManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DepartmentManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        public string DisplayMember = "DepartmentDescription";
        public string ValueMember = "DepartmentId";
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertDepartment(Department theDepartment)
        {
            return DepartmentIntegration.InsertDepartment(theDepartment);
        }

        public int UpdateDepartment(Department TheDepartment)
        {
            return DepartmentIntegration.UpdateDepartment(TheDepartment);
        }

        public int DeleteDepartment(Department theDepartment)
        {
            return DepartmentIntegration.DeleteDepartment(theDepartment);
        }

        public Department GetDepartmentById(int DepartmentId)
        {
            try
            {
                return DepartmentIntegration.GetDepartmentById(DepartmentId);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }


        #endregion

        #region Data Retrive Mathods

        public List<Department> GetDepartmentsList(string searchText = null, bool showDeleted = false)
        {
            try
            {
                return DepartmentIntegration.GetDepartmentsList(searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<Department> GetDepartmentsListByOffice(int OfficeID = -1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                //TODO: cache the departments
                return DepartmentIntegration.GetDepartmentsListByOffice(OfficeID, searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        //#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)

        //public Boolean FillDepartmentList(Control Cnt, string searchText = null, bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = DepartmentManagement.GetInstance.GetDepartmentsList(); ; ;
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "DepartmentDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "DepartmentDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = DepartmentManagement.GetInstance.GetDepartmentsList(); ; ;
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public Boolean FillDepartmentListByOffice(Control Cnt, string searchText = null, bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = DepartmentManagement.GetInstance.GetDepartmentsListByOffice(); ; ;
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "DepartmentDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "DepartmentDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = DepartmentManagement.GetInstance.GetDepartmentsListByOffice(); ; ;
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //#endregion
    }
}
