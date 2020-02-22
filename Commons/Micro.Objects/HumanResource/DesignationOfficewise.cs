using System;
using Micro.Objects.Administration;


namespace Micro.Objects.HumanResource
{
    [Serializable]

    public partial class DesignationOfficewise
    {
        public Designation DESIGNATION = new Designation();
        public Office Office = new Office();

        public int DesignationOfficewiseID
        {
            get;
            set;
        }


        public int DesignationID
        {
            get { return DESIGNATION.DesignationID; }
            set { DESIGNATION.DesignationID = value; }
        }
        public string DesignationDescription
        {
            get { return DESIGNATION.DesignationDescription; }
            set { DESIGNATION.DesignationDescription = value; }
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
