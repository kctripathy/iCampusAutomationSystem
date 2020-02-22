using System;

namespace Micro.Objects.HumanResource
{
    [Serializable]
    public class Designation
    {

        public int DesignationID
        {
            get;
            set;
        }

        public string DesignationDescription
        {
            get;
            set;
        }

        public int RoleID
        {
            get;
            set;
        }

        public string RoleDescription
        {
            get;
            set;
        }

        public int ReportingToDesignationID
        {
            get;
            set;
        }

        public string ReportingToDesignationDescription
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
