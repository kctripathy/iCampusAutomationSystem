using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class WebForm
    {
        public int WebFormID
        {
            get;
            set;
        }
        public int ModuleID
        {
            get;
            set;
        }
        public string WebFormName
        {
            get;
            set;
        }
        public string WebFormURL
        {
            get;
            set;
        }
        public string WebFormImageURL
        {
            get;
            set;
        }
        public string ModuleName
        {
            get;
            set;
        }
        public string CompanyCode
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
        public string WebFormDescription
        {
            get;
            set;
        }

    }
}
