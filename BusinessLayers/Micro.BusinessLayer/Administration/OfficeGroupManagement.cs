using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;


namespace Micro.BusinessLayer.Administration
{
    public class OfficeGroupManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static OfficeGroupManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static OfficeGroupManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new OfficeGroupManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Office Group
        #region Declaration
        public string DisplayMember = "OfficeGroupDescription";
        public string ValueMember = "OfficeGroupID";
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertOfficeGroup(OfficeGroup Dept)
        {
            try
            {
                return OfficeGroupIntegration.InsertOfficeGroup(Dept);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateOfficeGroup(OfficeGroup TheOfficeGroup)
        {
            try
            {
                return OfficeGroupIntegration.UpdateOfficeGroup(TheOfficeGroup);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteOfficeGroup(int OfficeGroupId)
        {
            try
            {
                return OfficeGroupIntegration.DeleteOfficeGroup(OfficeGroupId);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public OfficeGroup GetOfficeGroupByOfficeGroupID(int OfficeGroupID)
        {
            try
            {
                return OfficeGroupIntegration.GetOfficeGroupByOfficeGroupID(OfficeGroupID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<OfficeGroup> GetOfficeGroupsAll(bool showDeleted = false)
        {
            try
            {
                return OfficeGroupIntegration.GetOfficeGroupsAll(showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<OfficeGroup> GetOfficeGroupsByCompanyID(int ComapnyID = -1)
        {
            try
            {
                return OfficeGroupIntegration.GetOfficeGroupsByCompanyID(ComapnyID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        //#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)

        //public Boolean FillOfficeGroupsAll(Control Cnt, bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = GetOfficeGroupsAll();
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "OfficeGroupName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "OfficeGroupName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = GetOfficeGroupsAll(); ; ;
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public Boolean FillOfficeGroupsByComapnyID(Control Cnt, int CompanyID = -1)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = GetOfficeGroupsByCompanyID(CompanyID);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "OfficeGroupName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "OfficeGroupName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = GetOfficeGroupsByCompanyID(CompanyID);
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
        #endregion


        #region Office Group Template
        #region Declaration
        //public string DisplayMember = "OfficeGroupDescription";
        //public string ValueMember = "OfficeGroupID";
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertOfficeGroupTemplate(OfficeGroupTemplate officeGroupTemplate)
        {
            try
            {
                return OfficeGroupIntegration.InsertOfficeGroupTemplate(officeGroupTemplate);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateOfficeGroupTemplate(OfficeGroupTemplate officeGroupTemplate)
        {
            try
            {
                return OfficeGroupIntegration.UpdateOfficeGroupTemplate(officeGroupTemplate);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteOfficeGroupTemplate(int OfficeGroupTemplateID)
        {
            try
            {
                return OfficeGroupIntegration.DeleteOfficeGroupTemplate(OfficeGroupTemplateID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public OfficeGroupTemplate GetOfficeGroupTemplateByOfficeGroupTemplateID(int OfficeGroupTemplateID)
        {
            try
            {
                return OfficeGroupIntegration.GetOfficeGroupTemplateByOfficeGroupTemplateID(OfficeGroupTemplateID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<OfficeGroupTemplate> GetOfficeGroupTemplatesByOfficeGroupID(int OfficeGroupID)
        {
            try
            {
                return OfficeGroupIntegration.GetOfficeGroupTemplatesByOfficeGroupID(OfficeGroupID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)

        #endregion
        #endregion
    }
}
