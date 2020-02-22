using System.Collections.Generic;
using Micro.Objects.FinancialAccounts;
using Micro.DataAccessLayer.FinancialAccounts;

namespace Micro.IntegrationLayer.FinancialAccounts
{
    public partial class VoucherIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementations
        public static int InsertVouchers(Voucher theVoucher)
        {
            return VoucherDataAccess.GetInstance.InsertVouchers(theVoucher);
        }

        public static int InsertVoucherDetails(List<VoucherDetails> theVoucherDetailsList)
        {
            return VoucherDataAccess.GetInstance.InsertVoucherDetails(theVoucherDetailsList);
        }
        #endregion
    }
}
