using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class PreMaturityApprovalManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PreMaturityApprovalManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PreMaturityApprovalManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PreMaturityApprovalManagement();
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
        public string DefaultColumns = "CustomerAccountCode, CustomerName, PreMaturityApprovalDate, PreMaturityPrincipalPayable, PreMaturityPrincipalApproved, PreMaturityInterestPayable, PreMaturityInterestApproved";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "PreMaturityApprovalID";
        #endregion

        #region Methods & Implementation
        public List<PreMaturityApproval> GetPrematurityApplications(bool allOffices = false)
        {
            return PreMaturityApprovalIntegration.GetPrematurityApprovalUnpaidList(allOffices);
        }

        public PreMaturityApproval GetPrematurityApprovalDetailsById(int PreMaturityApprovalID)
        {
            return PreMaturityApprovalIntegration.GetPrematurityApprovalDetailsById(PreMaturityApprovalID);
        }

        public int InsertPreMaturityApproval(PreMaturityApproval thePreMaturityApprovals)
        {
            return PreMaturityApprovalIntegration.InsertPreMaturityApproval(thePreMaturityApprovals);
        }

        /// <summary>
        /// Reject The Prematurity Application
        /// </summary>
        /// <param name="thePreMaturityApplication"></param>
        /// <returns></returns>
        public int RejectPreMaturityApplication(PreMaturityApplication thePreMaturityApplication)
        {
            return PreMaturityApprovalIntegration.RejectPreMaturityApplication(thePreMaturityApplication);
        }
        #endregion
    }
}
