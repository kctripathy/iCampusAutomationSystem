using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class OfficeType
    {
        public int OfficeTypeID
        {
            get;
            set;
        }

        public string OfficeTypeName
        {
            get;
            set;
        }

        public string OfficeTypeDescription
        {
            get;
            set;
        }

        public string OfficeTypeAbbreviation
        {
            get;
            set;
        }

        public int ParentOfficeTypeID
        {
            get;
            set;
        }

        public string ParentOfficeTypeName
        {
            get;
            set;
        }

        public int HierarchyIndex
        {
            get;
            set;
        }

        public string LastGeneratedCode
        {
            get;
            set;
        }

        public int CompanyID
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }

        public int AddedBy
        {
            get;
            set;
        }

        public int ModifiedBy
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
