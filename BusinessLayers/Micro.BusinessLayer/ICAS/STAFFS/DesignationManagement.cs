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
   public partial class DesignationManagement
    {
        #region Declaration
        public string DisplayMember = "DesignationDescription";
        public string ValueMember = "DesignationID";
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DesignationManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DesignationManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DesignationManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertDesignation(Designation theDesignation)
        {
            return DesignationIntegration.InsertDesignation(theDesignation);
        }

        public int UpdateDesignation(Designation theDesignation)
        {
            return DesignationIntegration.UpdateDesignation(theDesignation);
        }

        public int DeleteDesignation(int DesignationID)
        {
            return DesignationIntegration.DeleteDesignation(DesignationID);
        }

        #endregion

        #region Data Retrive Mathods

        public List<Designation> GetDesignationsList(string searchText = null, bool showDeleted = false)
        {
            try
            {
                return DesignationIntegration.GetDesignationsList(searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<Designation> GetDesignationsListByOffice(int OfficeID = -1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                return DesignationIntegration.GetDesignationsListByOffice(OfficeID, searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public Designation GetDesignationById(int DesignationID)
        {
            try
            {
                return DesignationIntegration.GetDesignationById(DesignationID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        //#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)

        //public Boolean FillDesignationList(Control Cnt, string searchText = null, bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = DesignationManagement.GetInstance.GetDesignationsList(); ; ;
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "DesignationDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "DesignationDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = DesignationManagement.GetInstance.GetDesignationsList(); ; ;
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public Boolean FillDesignationListByOffice(Control Cnt, string searchText = null, bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = DesignationManagement.GetInstance.GetDesignationsListByOffice(); ; ;
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "DesignationDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "DesignationDescription";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = DesignationManagement.GetInstance.GetDesignationsListByOffice(); ; ;
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
