using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;
using System;

namespace Micro.IntegrationLayer.Administration
{
    public partial class CompanyIntegration
    {
        #region Methods & Implementation
        public static Company DataRowToObject(DataRow dr)
        {
            Company TheMicroCompany = new Company();

            TheMicroCompany.CompanyID = int.Parse(dr["CompanyID"].ToString());
            TheMicroCompany.CompanyName = dr["CompanyName"].ToString();
			TheMicroCompany.CompanyAliasName = dr["CompanyAliasName"].ToString();
            TheMicroCompany.CompanyCode = dr["CompanyCode"].ToString();
            TheMicroCompany.CompanyMailingName = dr["CompanyMailingName"].ToString();
            TheMicroCompany.CompanyRegisteredOfficeID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["CompanyRegisteredOfficeID"].ToString()));
            TheMicroCompany.CompanyHeadOfficeID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["CompanyHeadOfficeID"].ToString()));
            TheMicroCompany.CompanyRegistrationNumber = dr["CompanyRegistrationNumber"].ToString();
			TheMicroCompany.IsActive = bool.Parse(dr["IsActive"].ToString());
            TheMicroCompany.CompanyEPFRegistrationNumber = dr["CompanyEPFRegistrationNumber"].ToString();
			TheMicroCompany.EstablishmentDate = DateTime.Parse(dr["EstablishmentDate"].ToString());
            if (!string.IsNullOrEmpty(dr["CompanyLogoBigSize"].ToString()))
                TheMicroCompany.CompanyLogoBigSize = (byte[])dr["CompanyLogoBigSize"];
            if (!string.IsNullOrEmpty(dr["CompanyLogoMediumSize"].ToString()))
                TheMicroCompany.CompanyLogoMediumSize = (byte[])dr["CompanyLogoMediumSize"];
            if (!string.IsNullOrEmpty(dr["CompanyLogoSmallSize"].ToString()))
                TheMicroCompany.CompanyLogoSmallSize = (byte[])dr["CompanyLogoSmallSize"];
            if (!string.IsNullOrEmpty(dr["CompanyLoginImage"].ToString()))
                TheMicroCompany.CompanyLoginImage = (byte[])dr["CompanyLoginImage"];
            TheMicroCompany.CompanyLoginLabelForeColor = dr["CompanyLoginLabelForeColor"].ToString();

            return TheMicroCompany;
        }

        public static List<Company> GetMicroCompanyList()
        {
            List<Company> MicroCompanyList = new List<Company>();
            DataTable MicroCompanyTable = CompanyDataAccess.GetInstance.GetMicroCompanyList();

            foreach (DataRow dr in MicroCompanyTable.Rows)
            {
                Company TheMicroCompany = DataRowToObject(dr);

                MicroCompanyList.Add(TheMicroCompany);
            }

            return MicroCompanyList;
        }

        public static List<Company> GetCompaniesByUserID(int UserID)
        {
            List<Company> MicroCompanyList = new List<Company>();
            DataTable MicroCompanyTable = CompanyDataAccess.GetInstance.GetCompaniesByUserID(UserID);

            foreach (DataRow dr in MicroCompanyTable.Rows)
            {
                Company TheMicroCompany = DataRowToObject(dr);

                MicroCompanyList.Add(TheMicroCompany);
            }

            return MicroCompanyList;
        }

        public static Company GetCompanyByComapnyID(int CompanyID)
        {
			Company TheMicroCompany = new Company();

            DataRow MicroCompanyRow = CompanyDataAccess.GetInstance.GetCompanyByComapnyID(CompanyID);

			if (MicroCompanyRow != null)
			{
				TheMicroCompany = DataRowToObject(MicroCompanyRow);

			}
            return TheMicroCompany;
        }

        public static int InsertCompany(Company theMicroCompany)
        {
            return CompanyDataAccess.GetInstance.InsertCompany(theMicroCompany);
        }

        public static int UpdateCompany(Company theMicroCompany)
        {
            return CompanyDataAccess.GetInstance.UpdateCompany(theMicroCompany);
        }

        public static int DeleteCompany(Company theMicroCompany)
        {
            return CompanyDataAccess.GetInstance.DeleteCompany(theMicroCompany);
        }
        #endregion
    }
}
