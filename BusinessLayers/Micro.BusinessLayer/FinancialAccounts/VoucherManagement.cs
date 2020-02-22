using System.Collections.Generic;
using Micro.Objects.FinancialAccounts;
using Micro.IntegrationLayer.FinancialAccounts;

namespace Micro.BusinessLayer.FinancialAccounts
{
    public partial class VoucherManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static VoucherManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static VoucherManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new VoucherManagement();
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
        public string DefaultColumns = "";
        public string DisplayMember = "";
        public string ValueMember = "";
        #endregion

        #region Methods & Implemetation
        public int InsertVouchers(Voucher theVoucher)
        {
            return VoucherIntegration.InsertVouchers(theVoucher);
        }

        public int InsertVoucherDetails(List<VoucherDetails> theVoucherDetailsList)
        {
            return VoucherIntegration.InsertVoucherDetails(theVoucherDetailsList);
        }
        #endregion
    }
}
