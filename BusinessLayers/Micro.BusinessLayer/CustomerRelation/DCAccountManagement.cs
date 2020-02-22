using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class DCAccountManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DCAccountManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DCAccountManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DCAccountManagement();
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
		public string DefaultColumns = "DCAccountCode, CustomerName, FatherName, CommencementDate, InstallmentAmountDaily, InstallmentAmountMonthly, BalanceAmount, DCCollectorName";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "DCAccountID";
        #endregion

        #region Methods & Implementation
        public List<DCAccount> GetDCAccountList(bool allOffices = false, bool showDeleted = false)
        {
            return DCAccountIntegration.GetDCAccountList(allOffices,showDeleted);
        }

		public List<DCAccount> GetUnallotedDCAccounts(bool allOffices = false, bool showDeleted = false)
		{
			return DCAccountIntegration.GetUnallotedDCAccounts(allOffices, showDeleted);
		}

		public DCAccount GetDCAccountById(int DCAccountID)
		{
			return DCAccountIntegration.GetDCAccountById(DCAccountID);
		}

        public int InsertDCAccount(DCAccount theDCAccount)
        {
            return DCAccountIntegration.InsertDcAccount(theDCAccount);
        }

        public int UpdateDCAccount(DCAccount theDCAccount)
        {
            return DCAccountIntegration.UpdateDcAccount(theDCAccount);
        }

        public int DeleteDCAccount(DCAccount theDCAccount)
        {
            return DCAccountIntegration.DeleteDcAccount(theDCAccount);
        }
        #endregion
    }
}
