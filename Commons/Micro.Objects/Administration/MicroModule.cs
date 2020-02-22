using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class MicroModule
    {
        public int ModuleID
        {
            get;
            set;
        }

        public string ModuleName
        {
            get;
            set;
        }

        public string ModuleMenuText
        {
            get;
            set;
        }

        public int ParentModuleID
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
    }
}
