using System.Data;
using System.Data.SqlClient;
using Micro.Objects.FinancialAccounts;

namespace Micro.DataAccessLayer.FinancialAccounts
{
    public partial class AccountRemittanceDataAccess: AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static AccountRemittanceDataAccess instance = new AccountRemittanceDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static AccountRemittanceDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Declaration
        #endregion

        #region Methods & Implementation
        #endregion
    }
}
