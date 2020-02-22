using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;
using System.Web;

namespace Micro.BusinessLayer.Administration
{
    public partial class OfficeManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static OfficeManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static OfficeManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new OfficeManagement();
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
        public string DefaultColumn = "OfficeName, OfficeCode";
        public string DisplayMember = "OfficeName";
        public string ValueMember = "OfficeID";
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertOffice(Office theMicroOffice)
        {
            try
            {
                return OfficeIntegration.InsertMicroOffice(theMicroOffice);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateOffice(Office theMicroOffice)
        {
            try
            {
                return OfficeIntegration.UpdateMicroOffice(theMicroOffice);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteOffice(int OfficeID)
        {
            try
            {
                return OfficeIntegration.DeleteMicroOffice(OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
                #endregion

        #region Methods & Implementation
        public List<Office> GetOfficeList()
        {
            return OfficeIntegration.GetOfficeList();
        }

        public List<Office> GetOfficeListByUserID(int userID)
        {
            return OfficeIntegration.GetOfficeListByUserID(userID);
        }

        public List<Office> GetOfficeByCompanyID(int CompanyID)
        {
            return OfficeIntegration.GetOfficeByCompanyID(CompanyID);
        }

        public Office GetOfficeByID(int officeID)
        {
            return OfficeIntegration.GetOfficeByID(officeID);
        }

        public List<Office> GetOfficeListByTypeID(int officeTypeID)
        {
            //return OfficeIntegration.GetOfficeListByTypeID(officeTypeID);

			string UniqueKey = "OfficeListByTypeID_" + officeTypeID.ToString();
			if (HttpRuntime.Cache[UniqueKey] == null)
			{
				List<Office> OfficeTypeList = OfficeIntegration.GetOfficeListByTypeID(officeTypeID);
				HttpRuntime.Cache[UniqueKey] = OfficeTypeList;
			}
			return (List<Office>)(HttpRuntime.Cache[UniqueKey]);
        }

        public List<Office> GetOfficeListByUserOfficeTypeID(int officeTypeID)
        {
            return OfficeIntegration.GetOfficeListByUserOfficeTypeID(officeTypeID);
        }

        public List<Office> GetUnitOfficeListByCompanyID()
        {
            return OfficeIntegration.GetUnitOfficeListByCompanyID();
        }

        public List<Office> GetOfficeListByReportingOfficeID(int officeID)
        {
            //return OfficeIntegration.GetOfficeListByReportingOfficeID(officeID);

			string UniqueKey = "GetOfficeListByReportingOfficeID" + officeID.ToString();
			if (HttpRuntime.Cache[UniqueKey] == null)
			{
				List<Office> OfficeList = OfficeIntegration.GetOfficeListByReportingOfficeID(officeID);
				HttpRuntime.Cache[UniqueKey] = OfficeList;
			}
			return (List<Office>)(HttpRuntime.Cache[UniqueKey]);
        }

        public List<Office> GetBranchOfficeListByOfficeID(int officeID)
        {
            return OfficeIntegration.GetBranchOfficeListByOfficeID(officeID);
        }

        public List<Office> GetBranchOfficeListByOfficeTypeID(int officeID, int officeTypeID, bool showChildOffices)
        {
            return OfficeIntegration.GetBranchOfficeListByOfficeTypeID(officeID, officeTypeID, showChildOffices);
        }

        public List<Office> GetOfficeTreeByUserID(int userID)
        {
            return OfficeIntegration.GetOfficeTreeByUserID(userID);
        }

        public List<Office> GetOfficeListByCompanyID(int CompanyID=-1)
        {
            try
            {
                return OfficeIntegration.GetOfficeListByCompanyID(CompanyID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        //public Boolean FillOfficeList(Control Cnt)
        //{
        //    string Context = "Micro.BusinessLayer.Administration.MicroOfficeManagement.FillAllOfficesByReportingOffice";
        //    try
        //    {
        //        int officeID = Micro.Commons.Connection.LoggedOnUser.OfficeID;

        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = GetOfficeList();
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = OfficeManagement.GetInstance.DisplayMember;
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = OfficeManagement.GetInstance.ValueMember;
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = GetOfficeList(); 
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(Context, ex));
        //    }
        //}

        //public Boolean FillOfficeListByCompanyID(Control Cnt,int CompanyID=-1)
        //{
        //    try
        //    {
        //        int officeID = Micro.Commons.Connection.LoggedOnUser.OfficeID;

        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = GetOfficeListByCompanyID(CompanyID);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "OfficeName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "OfficeName";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = GetOfficeList();
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public Boolean FillOfficeListByReportingOffice(Control Cnt)
        //{
        //    string Context = "Micro.BusinessLayer.Administration.MicroOfficeManagement.FillAllOfficesByReportingOffice";
        //    try
        //    {
        //        int officeID = Micro.Commons.Connection.LoggedOnUser.OfficeID;

        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = OfficeManagement.GetInstance.GetOfficeListByReportingOfficeID(officeID);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = OfficeManagement.GetInstance.DisplayMember;
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = OfficeManagement.GetInstance.ValueMember;
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = OfficeIntegration.GetOfficeListByReportingOfficeID(officeID);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(Context, ex));
        //    }
        //}



        public List<Office> GetOfficeListByReportingOfficeIDs(int OfficeID = -1)
        {
            try
            {
                return OfficeIntegration.GetOfficeListByReportingOfficeID(OfficeID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        #endregion
    }
}
