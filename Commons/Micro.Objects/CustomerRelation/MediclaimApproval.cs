using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class MediclaimApproval
    {
        public int MediclaimApprovalID
        {
            get;
            set;
        }

        public int MediclaimApplicationID
        {
            get;
            set;
        }

        public string MediclaimApplicationNumber
        {
            get;
            set;
        }

        public int CustomerID
        {
            get;
            set;
        }

        public string CustomerName
        {
            get;
            set;
        }

        public string CustomerCode
        {
            get;
            set;
        }

        public string MediclaimApprovalDate
        {
            get;
            set;
        }

        public int ApprovedByEmployeeID
        {
            get;
            set;
        }

        public string ApprovedByEmployeeCode
        {
            get;
            set;
        }

        public string ApprovedByEmployeeName
        {
            get;
            set;
        }

        public decimal MediclaimApprovalAmount
        {
            get;
            set;
        }

        public string Remarks
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

				