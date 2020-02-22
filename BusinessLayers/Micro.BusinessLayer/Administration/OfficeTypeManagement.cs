using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;
using System.Web;

namespace Micro.BusinessLayer.Administration
{
    public class OfficeTypeManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static OfficeTypeManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static OfficeTypeManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new OfficeTypeManagement();
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
        public string DefaultColumns = "HierarchyIndex, OfficeTypeDescription, OfficeTypeAbbreviation";
        public string DisplayMember = "OfficeTypeDescription";
        public string ValueMember = "OfficeTypeID";
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertOfficeType(OfficeType Dept)
        {
            try
            {
                return OfficeTypeIntegration.InsertOfficeType(Dept);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateOfficeType(OfficeType TheOfficeType)
        {
            try
            {
                return OfficeTypeIntegration.UpdateOfficeType(TheOfficeType);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteOfficeType(int OfficeTypeId)
        {
            try
            {
                return OfficeTypeIntegration.DeleteOfficeType(OfficeTypeId);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public OfficeType GetOfficeTypeByOfficeTypeID(int OfficeTypeID)
        {
            try
            {
                return OfficeTypeIntegration.GetOfficeTypeByOfficeTypeID(OfficeTypeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public OfficeType GetOfficeTypesAbbreviation(string OfficeTypeAbbreviation)
        {
            try
            {
                return OfficeTypeIntegration.GetOfficeTypeByOfficeTypeAbbreviation(OfficeTypeAbbreviation);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<OfficeType> GetOfficeTypesAll(bool showDeleted = false)
        {
            try
            {
                return OfficeTypeIntegration.GetOfficeTypesAll(showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<OfficeType> GetOfficeTypesHierarchyIndex(int HierarchyIndex)
        {
            try
            {
                return OfficeTypeIntegration.GetOfficeTypesByHierarchyIndex(HierarchyIndex);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<OfficeType> GetOfficeTypesParentOfficeTypeID(int ParentOfficeTypeID)
        {
            try
            {
                return OfficeTypeIntegration.GetOfficeTypesByHierarchyIndex(ParentOfficeTypeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<OfficeType> GetOfficeTypesByCompanyID(int ComapnyID=-1)
        {
            try
            {
                return OfficeTypeIntegration.GetOfficeTypesByCompanyID(ComapnyID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

		public List<OfficeType> GetOfficeTypeListByUserID(int userID)
		{
			//return OfficeTypeIntegration.GetOfficeTypeListByUserID(userID);

			string UniqueKey = "OfficeTypeListByUserID_" + userID.ToString();
			if (HttpRuntime.Cache[UniqueKey] == null)
			{
				List<OfficeType> OfficeTypeList = OfficeTypeIntegration.GetOfficeTypeListByUserID(userID);
				HttpRuntime.Cache[UniqueKey] = OfficeTypeList;
			}
			return (List<OfficeType>)(HttpRuntime.Cache[UniqueKey]);
		}
        #endregion

        //#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)

        //public Boolean FillOfficeTypesAll(Control Cnt, bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = GetOfficeTypesAll () ;
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "OfficeTypeName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "OfficeTypeName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource =GetOfficeTypesAll(); ; ;
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public Boolean FillOfficeTypesByHierarchyIndex(Control Cnt, int HierarchyIndex)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = GetOfficeTypesHierarchyIndex(HierarchyIndex);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "OfficeTypeName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "OfficeTypeName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = GetOfficeTypesHierarchyIndex(HierarchyIndex);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public Boolean FillOfficeTypesByParentOfficeTypeID(Control Cnt, int ParentOfficeTypeID)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = GetOfficeTypesParentOfficeTypeID(ParentOfficeTypeID);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "OfficeTypeName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "OfficeTypeName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = GetOfficeTypesParentOfficeTypeID(ParentOfficeTypeID);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public Boolean FillOfficeTypesByComapnyID(Control Cnt, int CompanyID=-1)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = GetOfficeTypesByCompanyID(CompanyID);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "OfficeTypeName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "OfficeTypeName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource =  GetOfficeTypesByCompanyID(CompanyID);
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
