using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class PreMaturityApplicationManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PreMaturityApplicationManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PreMaturityApplicationManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PreMaturityApplicationManagement();
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
        public string DefaultColumns = "PreMaturityApplicationDate, CustomerAccountCode, CustomerName ,PreMaturityRemark, PreMaturityApplicationLetterDate, PreMaturityApplicationLetterReference, PreMaturityApprovalStatus";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "PreMaturityApplicationID";
        #endregion

        #region Methods & Implementation
        public List<PreMaturityApplication> GetPrematurityApplicationList(bool allOffices = false, bool showDeleted = false)
        {
            return PreMaturityApplicationIntegration.GetPrematurityApplicationList(allOffices, showDeleted);
        }

        public PreMaturityApplication GetPreMaturityApplicationByID(int preMaturityApplicationID)
        {
            return PreMaturityApplicationIntegration.GetPreMaturityApplicationByID(preMaturityApplicationID);
        }

        public List<PreMaturityApplication> GetPreMaturityApplicationListByCustomerAccountID(int customerAccountID)
        {
            return PreMaturityApplicationIntegration.GetPreMaturityApplicationListByCustomerAccountID(customerAccountID);
        }

        /// <summary>
        /// Prematurity Application By Application Date using LINQ
        /// </summary>
        /// <param name="customerAccountID"></param>
        /// <returns></returns>
        public PreMaturityApplication GetLastPreMaturtiyApplicationByCustomerAccountID(int customerAccountID)
        {
            return PreMaturityApplicationIntegration.GetLastPreMaturtiyApplicationByCustomerAccountID(customerAccountID);
        }

        public List<PreMaturityApplication> GetPreMaturityApplicationListByApprovalStatus(string approvalStatus, bool allOffices = true)
        {
            return PreMaturityApplicationIntegration.GetPreMaturityApplicationListByApprovalStatus(approvalStatus, allOffices);
        }

        public int InsertPrematurityApplication(PreMaturityApplication thePreMaturityApplications)
        {
            return PreMaturityApplicationIntegration.InsertPrematurityApplication(thePreMaturityApplications);
        }

        public int UpdatePrematurityApplication(PreMaturityApplication thePreMaturityApplications)
        {
            return PreMaturityApplicationIntegration.UpdatePrematurityApplication(thePreMaturityApplications);
        }
        #endregion
    }
}
