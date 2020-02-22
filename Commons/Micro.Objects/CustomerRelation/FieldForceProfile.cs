using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class FieldForceProfile
    {
        public int FieldForceProfileID
        {
            get;
            set;
        }

        public int FieldForceID
        {
            get;
            set;
        }

		public string FieldForceCode
		{
			get;
			set;
		}

		public string FieldForceName
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
			//Only for Web-Application
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
