using System;
using Micro.Objects.Administration;


namespace Micro.Objects.HumanResource
{
    [Serializable]

    public partial class LeaveTypeOfficewise
    {
        //public LeaveType LeaveType = new LeaveType();
        public Office Office = new Office();

        public int LeaveTypeOfficewiseID
        {
            get;
            set;
        }

        public int LeaveTypeID
        {
            get;
            set;
        }

        public string LeaveTypeDescription
        {
            get;
            set;
        }

        public string LeaveTypeAlias
        {
            get;
            set;
        }

        public int OfficeID
        {
            get { return Office.OfficeID; }
            set { Office.OfficeID = value; }
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
