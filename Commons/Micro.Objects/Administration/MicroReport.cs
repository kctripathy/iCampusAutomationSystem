using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class MicroReport
    {
        public int ReportID
        {
            get;
            set;
        }

        public string ReportDisplayName
        {
            get;
            set;
        }

        public string ReportFileName
        {
            get;
            set;
        }

        public string ReportFilePath
        {
            get;
            set;
        }

        public string ReportTitle
        {
            get;
            set;
        }

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
