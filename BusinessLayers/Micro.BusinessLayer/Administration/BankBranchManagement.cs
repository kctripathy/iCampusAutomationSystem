using System.Collections.Generic;
using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
    public partial class BankBranchManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static BankBranchManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static BankBranchManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BankBranchManagement();
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
        #endregion

        #region Methods & Implementation
        public List<BankBranch> GetAllBankBranch(string SearchText)
        {
            return BankBranchIntegration.GetAllBankBranch(SearchText);
        }

        public BankBranch GetBankBranchesByBranchId(int BankBranchID)
        {
            return BankBranchIntegration.GetBankBranchesByBranchId(BankBranchID);
        }

        public List<BankBranch> GetAllBankBranchByBankID(int BankID)
        {
            return BankBranchIntegration.GetAllBankBranchByBankID(BankID);
        }

        public int InsertBankBranch(BankBranch theBankBranch)
        {
            return BankBranchIntegration.InsertBankBranch(theBankBranch);
        }
        public int UpdateBankBranch(BankBranch theBankBranch)
        {
            return BankBranchIntegration.UpdateBankBranch(theBankBranch);
        }
        public int DeleteBankBranch(BankBranch theBankBranch)
        {
            return BankBranchIntegration.DeleteBankBranch(theBankBranch);
        }

        #endregion

    }
}
