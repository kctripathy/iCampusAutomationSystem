using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class PolicySurrenderManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PolicySurrenderManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PolicySurrenderManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PolicySurrenderManagement();
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
        public string DefaultColumn = "CustomerAccountCode, CustomerName, SurrenderFormNumber, SurrenderDate, SurrenderPrincipalPaid, SurrenderInterestPaid, SurrenderBonusPaid, SurrenderPrincipalDeductions,  SurrenderTotalPaid";
        public string DisplayMember = "CustomerAccountCode";
        public string ValueMember = "SurrenderID";
        #endregion

        #region Methods & Implementations
        public  List<PolicySurrender> GetPolicySurrenderList(bool allOffices = false, bool showDeleted = false)
        {
            return PolicySurrenderIntegration.GetPolicySurrenderList(allOffices, showDeleted);
        }

        public PolicySurrender GetSurrenderChargesbyCustomerAccountID(int customerAccountID)
        {
            return PolicySurrenderIntegration.GetSurrenderChargesbyCustomerAccountID(customerAccountID);
        }

        public int InsertPolicySurrender(PolicySurrender thePolicySurrender)
        {
            return PolicySurrenderIntegration.InsertPolicySurrender(thePolicySurrender);
        }
        #endregion
    }
}
