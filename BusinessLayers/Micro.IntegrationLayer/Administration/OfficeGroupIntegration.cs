using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

using Micro.Objects.Administration;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
    public class OfficeGroupIntegration
    {
        #region Declaration
        #endregion

        #region Office Groups

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertOfficeGroup(OfficeGroup OfficeGroup)
        {
            try
            {
                return OfficeGroupsDataAccess.GetInstance.InsertOfficeGroup(OfficeGroup);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateOfficeGroup(OfficeGroup OfficeGroup)
        {
            try
            {
                return OfficeGroupsDataAccess.GetInstance.UpdateOfficeGroup(OfficeGroup);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteOfficeGroup(int OfficeGroupID)
        {
            try
            {
                return OfficeGroupsDataAccess.GetInstance.DeleteOfficeGroup(OfficeGroupID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static OfficeGroup ConvertFromDatarowToObject(DataRow dataRow)
        {
            try
            {
                OfficeGroup OfficeGroup = new OfficeGroup();

                if (dataRow != null)
                {
                    OfficeGroup.OfficeGroupID = int.Parse(dataRow["OfficeGroupID"].ToString());
                    OfficeGroup.OfficeGroupName = dataRow["OfficeGroupName"].ToString();
                    OfficeGroup.OfficeGroupDescription = dataRow["OfficeGroupDescription"].ToString();
                    OfficeGroup.IsActive = (bool)dataRow["IsActive"];
                    OfficeGroup.IsDeleted = (bool)dataRow["IsDeleted"];
                }
                return OfficeGroup;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public static OfficeGroup GetOfficeGroupByOfficeGroupID(int OfficeGroupID)
        {
            try
            {
                return ConvertFromDatarowToObject(OfficeGroupsDataAccess.GetInstance.GetOfficeGroupsByOfficeGroupID(OfficeGroupID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public static List<OfficeGroup> GetOfficeGroupsAll(bool showDeleted = false)
        {
            try
            {
                DataTable OfficeGroupsTable = OfficeGroupsDataAccess.GetInstance.GetOfficeGroupsAll(showDeleted);
                List<OfficeGroup> OfficeGroupList = new List<OfficeGroup>();
                foreach (DataRow dr in OfficeGroupsTable.Rows)
                {
                    OfficeGroupList.Add(ConvertFromDatarowToObject(dr));
                }
                return OfficeGroupList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<OfficeGroup> GetOfficeGroupList(bool showDeleted = false)
        {
            try
            {
                DataTable OfficeGroupsTable = OfficeGroupsDataAccess.GetInstance.GetOfficeGroupsAll(showDeleted);
                List<OfficeGroup> OfficeGroupList = new List<OfficeGroup>();
                foreach (DataRow dr in OfficeGroupsTable.Rows)
                {
                    OfficeGroupList.Add(ConvertFromDatarowToObject(dr));
                }
                return OfficeGroupList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static List<OfficeGroup> GetOfficeGroupsByCompanyID(int CompanyID = -1)
        {
            try
            {
                DataTable OfficeGroupsTable = OfficeGroupsDataAccess.GetInstance.GetOfficeGroupsByCompanyID(CompanyID);
                List<OfficeGroup> OfficeGroupList = new List<OfficeGroup>();
                foreach (DataRow dr in OfficeGroupsTable.Rows)
                {
                    OfficeGroupList.Add(ConvertFromDatarowToObject(dr));
                }
                return OfficeGroupList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        #endregion

        #endregion


        #region Office Group Templates

        #region Transactional Mathods(Insert,Update,Delete)

        public static int InsertOfficeGroupTemplate(OfficeGroupTemplate OfficeGrouptemplate)
        {
            try
            {
                return OfficeGroupsDataAccess.GetInstance.InsertOfficeGroupTemplate(OfficeGrouptemplate);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int UpdateOfficeGroupTemplate(OfficeGroupTemplate OfficeGrouptemplate)
        {
            try
            {
                return OfficeGroupsDataAccess.GetInstance.UpdateOfficeGroupTemplate(OfficeGrouptemplate);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public static int DeleteOfficeGroupTemplate(int OfficeGroupTemplateID)
        {
            try
            {
                return OfficeGroupsDataAccess.GetInstance.DeleteOfficeGroupTemplate(OfficeGroupTemplateID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public static OfficeGroupTemplate ConvertFromDatarowToObjectOfficeTemplate(DataRow dataRow)
        {
            try
            {
                OfficeGroupTemplate officeGroupTemplate = new OfficeGroupTemplate();

                if (dataRow != null)
                {
                    officeGroupTemplate.OfficeGroupTemplateID = int.Parse(dataRow["OfficeGroupTemplateID"].ToString());
                    officeGroupTemplate.OfficeGroupID = int.Parse(dataRow["OfficeGroupID"].ToString());
                    officeGroupTemplate.office.OfficeID  = int.Parse(dataRow["OfficeID"].ToString());
                    officeGroupTemplate.EffectiveDateFrom  = DateTime.Parse( dataRow["EffectiveDateFrom"].ToString());
                    officeGroupTemplate.EffectiveDateTo = DateTime.Parse(dataRow["EffectiveDateTo"].ToString());
                    //officeGroupTemplate.IsActive = (bool)dataRow["IsActive"];
                    //officeGroupTemplate.IsDeleted = (bool)dataRow["IsDeleted"];
                }
                return officeGroupTemplate;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public static OfficeGroupTemplate GetOfficeGroupTemplateByOfficeGroupTemplateID(int OfficeGroupTemplateID)
        {
            try
            {
                return ConvertFromDatarowToObjectOfficeTemplate(OfficeGroupsDataAccess.GetInstance.GetOfficeGroupTemplateByOfficeGroupTemplateID(OfficeGroupTemplateID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public static List<OfficeGroupTemplate> GetOfficeGroupTemplatesByOfficeGroupID(int OfficeGroupID)
        {
            try
            {
                DataTable OfficeGroupsTable = OfficeGroupsDataAccess.GetInstance.GetOfficeGroupTemplatesByOfficeGroupID(OfficeGroupID);
                List<OfficeGroupTemplate> OfficeGroupTemplates = new List<OfficeGroupTemplate>();
                foreach (DataRow dr in OfficeGroupsTable.Rows)
                {
                    OfficeGroupTemplates.Add(ConvertFromDatarowToObjectOfficeTemplate(dr));
                }
                return OfficeGroupTemplates;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

         #endregion

        #endregion
    }
}
