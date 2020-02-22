using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class CRMPolicy
    {
		public int PolicyTypeID
		{
			get;
			set;
		}

		public string PolicyTypeDescription
		{
			get;
			set;
		}

		public string PolicySubType
		{
			get;
			set;
		}

		public int PolicyID
        {
            get;
            set;
        }

        public string PolicyName
        {
            get;
            set;
        }

        public string PolicyFromOrganization
        {
            get;
            set;
        }

		public string TenureInYears
		{
			get;
			set;
		}

		public int TenureInMonths
		{
			get;
			set;
		}

        public bool AllowDeathCompensation
        {
            get;
            set;
        }

        public bool AllowMediclaim
        {
            get;
            set;
        }

        public bool AllowPolicySurrender
        {
            get;
            set;
        }

        public bool AllowPreMaturity
        {
            get;
            set;
        }

        public bool AllowRevival
        {
            get;
            set;
        }

		public string DatabaseTableName
		{
			get;
			set;
		}

		public string StoredProcedureName
		{
			get;
			set;
		}

		public string EffectiveDateFrom
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

        public int PremiumTableID
        {
            get;
            set;
        }

        public string PremiumTableReferenceName
        {
            get;
            set;
        }

        public string PremiumTableDescriptiveName
        {
            get;
            set;
        }
    }
}



