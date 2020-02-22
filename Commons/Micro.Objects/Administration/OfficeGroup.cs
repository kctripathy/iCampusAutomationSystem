using System;
using System.Collections.Generic;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class OfficeGroup
    {
        public int OfficeGroupID
        {
            get;
            set;
        }

        public string OfficeGroupName
        {
            get;
            set;
        }

        public string OfficeGroupDescription
        {
            get;
            set;
        }

        public List<OfficeGroupTemplate> GroupOffices = new List<OfficeGroupTemplate>();

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

    public class OfficeGroupTemplate
    {

        public int OfficeGroupTemplateID
        {
            get;
            set;
        }

        public int OfficeGroupID
        {
            get;
            set;
        }

        public Office office=new Office();

        public DateTime EffectiveDateFrom
        {
            get;
            set;
        }

        public DateTime EffectiveDateTo
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
