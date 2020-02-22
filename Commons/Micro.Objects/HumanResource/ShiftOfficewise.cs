using System;
using Micro.Objects.Administration;


namespace Micro.Objects.HumanResource
{
    [Serializable]

    public partial class ShiftOfficewise
    {
        public Shift Shift = new Shift();
        public Office Office = new Office();


        public int ShiftOfficewiseID
        {
            get;
            set;
        }
        public int ShiftTimingID
        {
            get;
            set;
        }

        public string InTime
        {
            get;
            set;
        }

        public string ShiftDescription
        {
            get;
            set;
        }

        public string ShiftAlias
        {
            get;
            set;
        }

        public string OutTime
        {
            get;
            set;
        }
        public int ShiftID
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
