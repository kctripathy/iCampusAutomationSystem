using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.Commons;
using Micro.DataAccessLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.IntegrationLayer.ICAS.FINANCE
{
    public partial class DefaultFeeIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementaion
        public static DefaultFeeSetup DataRowToObject(DataRow dr)
        {
            DefaultFeeSetup TheFee = new DefaultFeeSetup
            {
                QualID = int.Parse(dr["QualID"].ToString()),
                StreamID = int.Parse(dr["StreamID"].ToString()),
                STREAM=dr["STREAM"].ToString(),
                QUALIFICATION=dr["QUALIFICATION"].ToString(),
                AccountTypeID = int.Parse(dr["AccountTypeID"].ToString()),
                ACCOUNT_TYPE=dr["ACCOUNT_TYPE"].ToString(),
                ACCOUNT_CODE=dr["ACCOUNT_CODE"].ToString(),
                AccountGroupID = int.Parse(dr["AccountGroupID"].ToString()),
                ACCOUNT_GROUP=dr["ACCOUNT_GROUP"].ToString(),
                AccountID = int.Parse(dr["AccountID"].ToString()),
                ACCOUNT_NAME=dr["ACCOUNT_NAME"].ToString(),
                DefaultFee =decimal.Parse(MicroGlobals.ReturnZeroIfNull(dr["DefaultFee"].ToString())),
                IsActive = bool.Parse(dr["IsActive"].ToString()),
                IsDeleted = bool.Parse(dr["IsDeleted"].ToString()),
                AddedBy = int.Parse(dr["AddedBy"].ToString()),
                OfficeID = int.Parse(dr["OfficeID"].ToString()),
                CompanyID = int.Parse(dr["CompanyID"].ToString()),               
            };

            return TheFee;
        }

        public static List<DefaultFeeSetup> GetDefaultFeeList()
        {
            List<DefaultFeeSetup> FeeList = new List<DefaultFeeSetup>();

            DataTable GetDefaultFee = DefaultFeeDataAccess.GetInstance.GetDefaultFeeList();

            foreach (DataRow dr in GetDefaultFee.Rows)
            {
                DefaultFeeSetup TheFee = DataRowToObject(dr);
                FeeList.Add(TheFee);
            }

            return FeeList;
        }

        public static List<DefaultFeeSetup> GetDefaultFeeListByQual_Stream(int QualID, int StreamID)
        {
            List<DefaultFeeSetup> FeeList = new List<DefaultFeeSetup>();

            DataTable GetDefaultFee = DefaultFeeDataAccess.GetInstance.GetDefaultFeeListByQual_Stream(QualID, StreamID);

            foreach (DataRow dr in GetDefaultFee.Rows)
            {
                DefaultFeeSetup TheFee = DataRowToObject(dr);
                FeeList.Add(TheFee);
            }
            return FeeList;
        }

        public static int InsertDefaultFee(DefaultFeeSetup thesetup)
        {
            return DefaultFeeDataAccess.GetInstance.InsertDefaultAccountFee(thesetup);
        }

        //public static int UpdateAccount(AccountName theAccount)
        //{
        //    return AccountNameDataAccess.GetInstance.UpdateAccount(theAccount);
        //}

        //public static int DeleteAccount(AccountName theAccount)
        //{
        //    return AccountNameDataAccess.GetInstance.DeleteAccount(theAccount);
        //}

        //public static int UpdateDisplayOrder(List<AccountName> accountList)
        //{
        //    return AccountNameDataAccess.GetInstance.UpdateDisplayOrder(accountList);
        //}
        #endregion
    }
}
