using System.Collections.Generic;
using Micro.IntegrationLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.BusinessLayer.ICAS.FINANCE
{
    public partial class AccountTransactionManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountTransactionManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountTransactionManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountTransactionManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaraton
        
        public string DefaultColumns = "AccountDescription, AccountHeadDescription";
        public string DisplayMember = "TransactionID";
        public string ValueMember = "AccountDescription";
        #endregion

        #region Methods & Implementation
        public List<AccountTransaction> GetAccountTransactionList(bool allOffices = false, bool showDeleted = false)
        {
            return AccountTransactionIntegration.GetAccountTransactionList(allOffices, showDeleted);
        }

        public List<AccountTransaction> GetAccountTransactionListByDate(string transactionDate, bool allOffices = false, bool showDeleted = false)
        {
            return AccountTransactionIntegration.GetAccountTransactionListByDate(transactionDate, allOffices, showDeleted);
        }

        public AccountTransaction GetAccountTransactionByID(int transactionID)
        {
            return AccountTransactionIntegration.GetAccountTransactionByID(transactionID);
        }

        public decimal GetCashBalances()
        {
            return AccountTransactionIntegration.GetCashBalances();
        }

        public int InsertAccountTransaction(AccountTransaction theAccountTransaction)
        {
            return AccountTransactionIntegration.InsertAccountTransaction(theAccountTransaction);
        }

        public int DeleteAccountTransaction(AccountTransaction theAccountTransaction,int Record)
        {
            return AccountTransactionIntegration.DeleteAccountTransaction(theAccountTransaction, Record);
        }
        #endregion
    }
}
