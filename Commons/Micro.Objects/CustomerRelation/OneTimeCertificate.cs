using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class OneTimeCertificate
    {
        public int OneTimeCertificateID
        {
            get;
            set;
        }
        public string OneTimeCertificateCode
        {
            get;
            set;
        }
        public int CustomerAccountID
        {
            get;
            set;
        }
        public string DatePrinted
        {
            get;
            set;
        }
        public string ReceivedBy
        {
            get;
            set;
        }
        public string ReceivedOnDate
        {
            get;
            set;
        }
        public string Remarks
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
        public int OfficeID
        {
            get;
            set;
        }
        public string OfficeCode
        {
            get;
            set;
        }
        public string OfficeName
        {
            get;
            set;
        }
        public string CustomerAccountCode
        {
            get;
            set;
        }

    }
}