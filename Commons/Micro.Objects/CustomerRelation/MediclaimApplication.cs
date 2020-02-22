using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class MediclaimApplication
    {
        public int MediclaimApplicationID
        {
            get;
            set;
        }

        public int CustomerID
        {
            get;
            set;
        }

        public string CustomerCode
        {
            get;
            set;
        }

        public string CustomerName
        {
            get;
            set;
        }

        public string MediclaimApplicationNumber
        {
            get;
            set;
        }

        public string MediclaimApplicationDate
        {
            get;
            set;
        }

        public string ReasonForClaim
        {
            get;
            set;
        }

        public string ApprovalStatus
        {
            get;
            set;
        }

        public int ApprovedByEmployeeID
        {
            get;
            set;
        }
        
        public string Remarks
        {
            get;
            set;
        }
		public string OfficeName
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
