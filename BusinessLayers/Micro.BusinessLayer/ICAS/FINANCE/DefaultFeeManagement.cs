using System.Collections.Generic;
using Micro.IntegrationLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.BusinessLayer.ICAS.FINANCE
{
    public partial class DefaultFeeManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
        private static DefaultFeeManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
        public static DefaultFeeManagement GetInstance
		{
			get
			{
				if (_Instance == null)
				{
                    _Instance = new DefaultFeeManagement();
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
		public string DisplayMember = "AccountDescription";
        public string ValueMember = "AccountID";
        #endregion

		#region Methods & Implementation
        public List<DefaultFeeSetup> GetDefaultFeeList()
        {
            return DefaultFeeIntegration.GetDefaultFeeList();
        }

        public List<DefaultFeeSetup> GetDefaultFeeListByQual_Stream(int QualID, int StreamID)
        {
            return DefaultFeeIntegration.GetDefaultFeeListByQual_Stream(QualID, StreamID);
        }



        public int InsertDefaultFee(DefaultFeeSetup theFee)
        {
            return DefaultFeeIntegration.InsertDefaultFee(theFee);
        }

        //public int UpdateAccount(AccountName theAccount)
        //{
        //    return AccountNameIntegration.UpdateAccount(theAccount);
        //}

        //public int DeleteAccount(AccountName theAccount)
        //{
        //    return AccountNameIntegration.DeleteAccount(theAccount);
        //}

        //public int UpdateDisplayOrder(List<AccountName> accountList)
        //{
        //    return AccountNameIntegration.UpdateDisplayOrder(accountList);
        //}
		#endregion
	}
}
