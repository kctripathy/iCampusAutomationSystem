using System.Collections.Generic;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;
using System.Web;

namespace Micro.BusinessLayer.Administration
{
    public partial class CompanyManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CompanyManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CompanyManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CompanyManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        public string DefaultColumn = "CompanyName, CompanyCode, CompanyRegistrationNumber, CompanyEPFRegistrationNumber";
        public string DisplayMember = "CompanyName";
        public string ValueMember = "CompanyID";
        #endregion

        #region Methods & Implementation
        public List<Company> GetMicroCompanyList()
        {
            return CompanyIntegration.GetMicroCompanyList();
        }
        public List<Company> GetCompaniesByUserID(int UserID)
        {
            return CompanyIntegration.GetCompaniesByUserID(UserID);
        }

        public Company GetCompanyByComapnyID(int CompanyID)
        {

            //return CompanyIntegration.GetCompanyByComapnyID(CompanyID);
			string UniqueKey = "GetCompanyByComapnyID_" + CompanyID.ToString();
			if (HttpRuntime.Cache[UniqueKey] == null)
			{
				Company theCompany = CompanyIntegration.GetCompanyByComapnyID(CompanyID);
				HttpRuntime.Cache[UniqueKey] = theCompany;
			}
			return ((Company)(HttpRuntime.Cache[UniqueKey]));
        }

        public int InsertCompany(Company theMicroCompany)
        {
            return CompanyIntegration.InsertCompany(theMicroCompany);
        }
        public int UpdateCompany(Company theMicroCompany)
        {
            return CompanyIntegration.UpdateCompany(theMicroCompany);
        }
        public int DeleteCompany(Company theMicroCompany)
        {
            return CompanyIntegration.DeleteCompany(theMicroCompany);
        }
        #endregion
    }
}
