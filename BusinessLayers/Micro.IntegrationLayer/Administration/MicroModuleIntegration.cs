using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;
using Micro.Commons;

namespace Micro.IntegrationLayer.Administration
{
    public partial class MicroModuleIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static MicroModule DataRowToObject(DataRow dr)
        {
            MicroModule TheMicroModule = new MicroModule
            {
                ModuleID = int.Parse(dr["ModuleID"].ToString()),
                ModuleName = dr["ModuleName"].ToString(),
                ModuleMenuText = dr["ModuleMenuText"].ToString(),
                ParentModuleID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ParentModuleID"].ToString())),
                IsActive = bool.Parse(dr["IsActive"].ToString()),
                IsDeleted = bool.Parse(dr["IsDeleted"].ToString())
            };

            return TheMicroModule;
        }

        public static List<MicroModule> GetMicroModules()
        {
            List<MicroModule> MicroModuleList = new List<MicroModule>();
            DataTable MicroModuleTable = MicroModuleDataAccess.GetInstance.GetMicroModules();

            foreach (DataRow dr in MicroModuleTable.Rows)
            {
                MicroModule TheMicroModule = DataRowToObject(dr);

                MicroModuleList.Add(TheMicroModule);
            }

            return MicroModuleList;
        }

        public static MicroModule GetMicroModuleByName(string moduleName)
        {
            List<MicroModule> MicroModuleList = GetMicroModules();
            MicroModule TheMicroModule = new MicroModule();

            if (MicroModuleList.Count > 0)
            {
                var MicroModuleFilteredList = (from TheModule in MicroModuleList
                                               where TheModule.ModuleMenuText == moduleName
                                               select TheModule).ToList();

                foreach (MicroModule EachMicroModule in MicroModuleFilteredList)
                {
                    TheMicroModule = EachMicroModule;
                }
            }

            return TheMicroModule;
        }
        #endregion
    }
}
