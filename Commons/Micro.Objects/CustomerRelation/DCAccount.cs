using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class DCAccount
    {
		public int DCAccountID
        {
            get;
            set;
        }

		public string DCAccountCode
        {
            get;
            set;
        }

		public string CustomerName
        {
            get;
            set;
        }

		public string FatherName
        {
            get;
            set;
        }

        public string Address_Present_TownOrCity
        {
            get;
            set;
        }

        public string Address_Present_Landmark
        {
            get;
            set;
        }

        public string Address_Present_PinCode
        {
            get;
            set;
        }

        public int Address_Present_DistrictID
        {
            get;
            set;
        }

		public string Address_Present_DistrictName
		{
			get;
			set;
		}

		public string Address_Present_StateName
		{
			get;
			set;
		}

		public string Address_Present_CountryName
		{
			get;
			set;
		}

        public string CommencementDate
        {
            get;
            set;
        }

        public decimal InstallmentAmountMonthly
        {
            get;
            set;
        }

        public decimal InstallmentAmountDaily
        {
            get;
            set;
        }

        public int DCCollectorID
        {
            get;
            set;
        }

		public string DCCollectorName
		{
			get;
			set;
		}

		public string DCCollectorCode
		{
			get;
			set;
		}

        public string AccountStatus
        {
            get;
            set;
        }

        public decimal BalanceAmount
        {
            get;
            set;
        }

        public bool IsToBeUpdated
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
