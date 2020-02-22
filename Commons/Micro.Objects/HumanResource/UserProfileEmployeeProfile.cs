using System;
using System.Drawing;

namespace Micro.Objects.HumanResource
{
    [Serializable]
public 	class UserProfileEmployeeProfile
	{
       

        public int EmployeeID
        {
            get;
            set;
        }
        public int SettingKeyID
        {
            get;
            set;
        }
        public Image SettingKeyValue
        {
            get;
            set;
        }
        public string SettingKeyDescription
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
        public DateTime DateModified
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
	}
}
