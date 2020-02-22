using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;



namespace Micro.BusinessLayer.HumanResource
{
    public partial class HolidayManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static HolidayManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static HolidayManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HolidayManagement();
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
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertHoliday(Holiday _Holiday)
        {
            try
            {
                return HolidayIntegration.InsertHoliday(_Holiday);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateHoliday(Holiday _Holiday)
        {
            try
            {
                return HolidayIntegration.UpdateHoliday(_Holiday);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteHoliday(int HolidayID)
        {
            try
            {
                return HolidayIntegration.DeleteHoliday(HolidayID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public List<Holiday> GetAllHolidays(string searchText="" , bool showDeleted = false)
        {
            try
            {
                return HolidayIntegration.GetAllHolidays(searchText,showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<Holiday> GetAllHolidaysByCalenderYear(int CalenderYear,string searchText="", bool showDeleted = false)
        {
            try
            {
                return HolidayIntegration.GetAllHolidaysByCalenderYear(CalenderYear, searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public Holiday GetHolidayByID(int HolidayID)
        {
            try
            {
                return HolidayIntegration.GetHolidayByID(HolidayID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        //public Boolean FillHolidays(Control Cnt, string searchText = null, bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = HolidayManagement.GetInstance.GetAllHolidays(searchText,showDeleted);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "Occasion";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "Occasion";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = HolidayManagement.GetInstance.GetAllHolidays(searchText, showDeleted);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        //public Boolean FillHolidaysByCalenderYear(Control Cnt, int CalenderYear,string searchText = null, bool showDeleted = false)
        //{
        //    try
        //    {
        //        if (Cnt is DevExpress.XtraEditors.LookUpEdit)
        //        {
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = HolidayManagement.GetInstance.GetAllHolidaysByCalenderYear (CalenderYear , searchText, showDeleted);
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "Occasion";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "Occasion";
        //            ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
        //        }
        //        else if (Cnt is DevExpress.XtraGrid.GridControl)
        //        {
        //            ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = HolidayManagement.GetInstance.GetAllHolidaysByCalenderYear(CalenderYear , searchText, showDeleted);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}

        #endregion

        #region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)
        #endregion
    }
}
