using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class MediclaimApprovalManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static MediclaimApprovalManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static MediclaimApprovalManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MediclaimApprovalManagement();
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
        public string DefaultColumn = "CustomerName, MediclaimApprovalDate, MediclaimApprovalAmount, ApprovedByEmployeeName";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "MediclaimApprovalID";
        #endregion

        #region Methods & Implementation
        public List<MediclaimApproval> GetMediClaimApprovalList(bool allOffices = false, bool showDeleted = false)
        {
            return MediclaimApprovalIntegration.GetMediClaimApprovalList(allOffices, showDeleted);
        }

        public List<MediclaimApproval> GetUnPaidMediClaimApprovalList(bool allOffices = false)
        {
            return MediclaimApprovalIntegration.GetUnPaidMediClaimApprovalList(allOffices);
        }

        public MediclaimApproval GetMediclaimApprovalByID(int mediclaimApprovalID)
        {
            return MediclaimApprovalIntegration.GetMediclaimApprovalByID(mediclaimApprovalID);
        }

        public int InsertMediclaimApproval(MediclaimApproval theMediclaimApproval)
        {
            return MediclaimApprovalIntegration.InsertMediclaimApproval(theMediclaimApproval);
        }
        #endregion
    }
}
