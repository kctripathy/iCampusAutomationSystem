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
    public partial class LeaveTypeSettingIntegration
    {
        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertLeaveTypeSettings(LeaveTypeSettings _LeaveTypeSettings)
        {
            try
            {
                return LeaveTypeSettingDataAccess.GetInstance.InsertLeaveTypeSettings(_LeaveTypeSettings);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateLeaveTypeSettings(LeaveTypeSettings _LeaveTypeSettings)
        {
            try
            {
                return LeaveTypeSettingDataAccess.GetInstance.UpdateLeaveTypeSettings(_LeaveTypeSettings);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteLeaveTypeSettings(int LeaveTypeSettingID)
        {
            try
            {
                return LeaveTypeSettingDataAccess.GetInstance.DeleteLeaveTypeSettings(LeaveTypeSettingID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        #endregion

        #region Data Retrive Mathods

        public static List<LeaveTypeSettings> GetLeaveTypeSettingsList(string searchText = null, bool showDeleted = false)
        {
            try
            {
                List<LeaveTypeSettings> LeaveTypeSettingsList = new List<LeaveTypeSettings>();

                DataTable LeaveTypeTable = new DataTable();
                LeaveTypeTable = LeaveTypeSettingDataAccess.GetInstance.GetLeaveTypeSettingsList(searchText, showDeleted);

                foreach (DataRow dr in LeaveTypeTable.Rows)
                {
                    LeaveTypeSettings _LeaveTypeSettings = new LeaveTypeSettings();

                    _LeaveTypeSettings.LeaveTypeSettingID = int.Parse(dr["LeaveTypeSettingID"].ToString());
                    _LeaveTypeSettings.LeaveTypeID = int.Parse(dr["LeaveTypeID"].ToString());
                    _LeaveTypeSettings.LeaveTypeDescription = dr["LeaveTypeDescription"].ToString();
                    _LeaveTypeSettings.LeaveTypeAlias = dr["LeaveTypeAlias"].ToString();

                    _LeaveTypeSettings.OfficeID = int.Parse(dr["OfficeID"].ToString());
                    _LeaveTypeSettings.OfficeName = dr["OfficeName"].ToString();

                    _LeaveTypeSettings.CreditInterval = dr["LeaveCreditInterval"].ToString();
                    _LeaveTypeSettings.Quarter1 = int.Parse(dr["Quarter1"].ToString());
                    _LeaveTypeSettings.Quarter2 = int.Parse(dr["Quarter2"].ToString());
                    _LeaveTypeSettings.Quarter3 = int.Parse(dr["Quarter3"].ToString());
                    _LeaveTypeSettings.Quarter4 = int.Parse(dr["Quarter4"].ToString());

                    _LeaveTypeSettings.IsActive = Boolean.Parse(dr["IsActive"].ToString());

                    LeaveTypeSettingsList.Add(_LeaveTypeSettings);
                }

                return LeaveTypeSettingsList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static LeaveTypeSettings SetLeaveTypeSettings(DataRow LeaveTypeSettingsRow)
        {
            try
            {
                LeaveTypeSettings _LeaveTypeSettings = new LeaveTypeSettings();


                if (LeaveTypeSettingsRow != null)
                {
                    _LeaveTypeSettings.LeaveTypeSettingID = int.Parse(LeaveTypeSettingsRow["LeaveTypeSettingID"].ToString());

                    _LeaveTypeSettings.LeaveTypeID = int.Parse(LeaveTypeSettingsRow["LeaveTypeID"].ToString());
                    _LeaveTypeSettings.LeaveTypeDescription = LeaveTypeSettingsRow["LeaveTypeDescription"].ToString();
                    _LeaveTypeSettings.LeaveTypeAlias = LeaveTypeSettingsRow["LeaveTypeAlias"].ToString();

                    _LeaveTypeSettings.NumberOfDaysAllowed = int.Parse(LeaveTypeSettingsRow["NumberOfDaysAllowed"].ToString());
                    _LeaveTypeSettings.NumberOfConsecutiveDaysAllowed = int.Parse(LeaveTypeSettingsRow["NumberOfConsecutiveDaysAllowed"].ToString());
                    _LeaveTypeSettings.ForGender = LeaveTypeSettingsRow["ForGender"].ToString();
                    _LeaveTypeSettings.CreditPeriodInMonths = int.Parse(LeaveTypeSettingsRow["CreditPeriodInMonths"].ToString());
                    _LeaveTypeSettings.MaximumAccumulatedDays = int.Parse(LeaveTypeSettingsRow["MaximumAccumulatedDays"].ToString());
                    _LeaveTypeSettings.CalculationMode = int.Parse(LeaveTypeSettingsRow["CalculationMode"].ToString());
                    _LeaveTypeSettings.IsTransferrable = bool.Parse(LeaveTypeSettingsRow["IsTransferrable"].ToString());
                    _LeaveTypeSettings.IsEncashable = bool.Parse(LeaveTypeSettingsRow["IsEncashable"].ToString());
                    _LeaveTypeSettings.EffectiveDate = DateTime.Parse(LeaveTypeSettingsRow["EffectiveDateFrom"].ToString());

                    _LeaveTypeSettings.CreditInterval = LeaveTypeSettingsRow["LeaveCreditInterval"].ToString();
                    _LeaveTypeSettings.Quarter1 = int.Parse(LeaveTypeSettingsRow["Quarter1"].ToString());
                    _LeaveTypeSettings.Quarter2 = int.Parse(LeaveTypeSettingsRow["Quarter2"].ToString());
                    _LeaveTypeSettings.Quarter3 = int.Parse(LeaveTypeSettingsRow["Quarter3"].ToString());
                    _LeaveTypeSettings.Quarter4 = int.Parse(LeaveTypeSettingsRow["Quarter4"].ToString());

                    _LeaveTypeSettings.OfficeID = int.Parse(LeaveTypeSettingsRow["OfficeID"].ToString());
                    _LeaveTypeSettings.OfficeName = LeaveTypeSettingsRow["OfficeName"].ToString();
                }
                else
                {
                    _LeaveTypeSettings.LeaveTypeSettingID = -1;
                    _LeaveTypeSettings.NumberOfDaysAllowed = 0;
                    _LeaveTypeSettings.NumberOfConsecutiveDaysAllowed = 0;
                    _LeaveTypeSettings.ForGender = "BOTH";
                }
                return _LeaveTypeSettings;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static LeaveTypeSettings GetLeaveTypeSettingsByLeaveTypeSettingID(int LeaveTypeSettingID)
        {
            try
            {
                return SetLeaveTypeSettings(LeaveTypeSettingDataAccess.GetInstance.GetLeaveTypeSettingsByLeaveTypeSettingID(LeaveTypeSettingID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static LeaveTypeSettings GetLeaveTypeSettingsByOfficeIDandLeaveTypeID(int LeaveTypeID, int OfficeID = -1)
        {
            try
            {
                return SetLeaveTypeSettings(LeaveTypeSettingDataAccess.GetInstance.GetLeaveTypeSettingsByOfficeIDandLeaveTypeID(LeaveTypeID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
