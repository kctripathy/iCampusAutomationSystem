using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class AccountsRevivalManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountsRevivalManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountsRevivalManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountsRevivalManagement();
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
		public string DefaultColumn="CustomerAccountCode, CustomerName, RevivalDate, RevivedFromInstallmentNumber";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "RevivalID";
		#endregion

		#region Methods & Implementation
		public List<AccountsRevival> GetAccountsRevivalList(bool allOffices = false, bool showDeleted = false)
        {
            return AccountsRevivalIntegration.GetAccountsRevivalList(allOffices,showDeleted); 
        }

        public int InsertAccountsRevivals(AccountsRevival theAccountsRevival)
        {
			return AccountsRevivalIntegration.InsertAccountsRevivals(theAccountsRevival);
        }
        #endregion
    }
}
