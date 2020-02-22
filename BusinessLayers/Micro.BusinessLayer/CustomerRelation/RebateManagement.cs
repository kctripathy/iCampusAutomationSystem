using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class RebateManagement
    {
        #region Declaration

        public string DefaultColumn = "RebateID,PolicyName,PolicyTypeDescription,InstallmentMode,RebatePer,RebateValue,EffectiveDateFrom";
        public string DisplayMember = "PolicyName";
        public string ValueMember = "RebateID";
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
		/// Declare a private static variable
		/// </summary>
		private static RebateManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static RebateManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new RebateManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

        #region Methods & Implementation
        public List<Rebate> GetRebateList()
        {
            return RebateIntegration.GetRebateList();
        }

        public Rebate  GetRebateByID(int RebateID)
        {
            return RebateIntegration.GetRebateByID(RebateID);
        }

        public int InsertRebate(Rebate theRebate)
        {
            return RebateIntegration.InsertRebate(theRebate);
        }

        public int UpdateRebate(Rebate theRebate)
        {
            return RebateIntegration.UpdateRebate(theRebate);
        }

        public int DeleteRebate(Rebate theRebate)
        {
            return RebateIntegration.DeleteRebate(theRebate);
        }

        public decimal GetRebateAmount(int policyTypeID, string installmentMode, decimal installmentAmount)
		{
			return RebateIntegration.GetRebateAmount(policyTypeID, installmentMode, installmentAmount);
        }
        #endregion
    }
}
