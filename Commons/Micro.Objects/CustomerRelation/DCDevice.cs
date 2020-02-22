using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class DCDevice
    {
        public int DCDeviceID
        {
            get;
            set;
        }
        public string DCDeviceCode
        {
            get;
            set;
        }
        public string DCDeviceSerialNumber
        {
            get;
            set;
        }
        public int DCCollectorID
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
		public string OfficeName
		{
			get;
			set;
		}
        public string DateAdded
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public string DCCollectorCode
        {
            get;
            set;
        }
        public string DCCollectorName
        {
            get;
            set;
        }
        public string AddedByName
        {
            get;
            set;
        }
        public string ModifiedByName
        {
            get;
            set;
        }
    }
}
