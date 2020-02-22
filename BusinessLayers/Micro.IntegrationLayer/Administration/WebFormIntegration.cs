using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.IntegrationLayer.Administration
{
public partial	class WebFormIntegration
	{
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static List<WebForm> GetWebFormsAll()
        {
            try
            {
                return SetWebFormList(WebFormDataAccess.GetInstance.GetWebFormsAll());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }


        private static List<WebForm> SetWebFormList(DataTable WebModuleTable)
        {
            try
            {
                List<WebForm> WebFormList = new List<WebForm>();
                foreach (DataRow dr in WebModuleTable.Rows)
                {
                    WebForm theWebForm = new WebForm();
                    theWebForm.WebFormID = int.Parse(dr["WebFormID"].ToString());
                    theWebForm.ModuleID = int.Parse(dr["ModuleID"].ToString());
                    theWebForm.WebFormName = dr["WebFormName"].ToString();
                    theWebForm.WebFormURL = dr["WebFormURL"].ToString();
                    theWebForm.WebFormImageURL = dr["WebFormImageURL"].ToString();
                    theWebForm.ModuleName = dr["ModuleName"].ToString();
                    theWebForm.CompanyCode = dr["CompanyCode"].ToString();
                    theWebForm.IsActive = bool.Parse(dr["IsActive"].ToString());
                    theWebForm.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());
                    theWebForm.WebFormDescription = dr["WebFormDescription"].ToString();

                    WebFormList.Add(theWebForm);

                }
                return WebFormList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
	}
}
