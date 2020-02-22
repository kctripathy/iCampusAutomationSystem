using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class Company
    {
        public int CompanyID
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;

        }

		public string CompanyAliasName
		{
			get;set;
		}

        public string CompanyCode
        {
            get;
            set;
        }

        public string CompanyMailingName
        {
            get;
            set;
        }

        public int CompanyRegisteredOfficeID
        {
            get;
            set;
        }

        public int CompanyHeadOfficeID
        {
            get;
            set;
        }

        public string CompanyRegistrationNumber
        {
            get;
            set;
        }

        public string CompanyEPFRegistrationNumber
        {
            get;
            set;
        }

        public byte[] CompanyLogoBigSize
        {
            get;
            set;
        }

        public byte[] CompanyLogoMediumSize
        {
            get;
            set;
        }

        public byte[] CompanyLogoSmallSize
        {
            get;
            set;
        }

        public byte[] CompanyLoginImage
        {
            get;
            set;
        }

        public string CompanyLoginLabelForeColor
        {
            get;
            set;
        }
        public DateTime EstablishmentDate
        {
            get;
            set;
        }
		public bool IsActive
		{
			get;
			set;
		}
    }
}
