using System;


namespace Micro.Objects.HumanResource
{
    [Serializable]

    public partial class EmployeeProfile
    {
        public Employee Employee = new Employee();

        public int EmployeeProfilleID
        {
            get;
            set;
        }
		public int EmployeeID
		{
			get;
			set;
		}
		public string EmployeeName
		{
			get;
			set;
		}
		public string EmployeeCode
		{
			get;
			set;
		}
        public int SettingKeyID
        {
            get;
            set;
        }

        public string SettingKeyName
        {
            get;
            set;
        }

        public string SettingKeyDescription
        {
            get;
            set;
        }

		public byte[] SettingKeyValue
        {
            get;
            set;
        }

        public string SettingKeyReference
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public string CommonKeyValue
        {
            get;
            set;
        }

        public int OfficeID
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
