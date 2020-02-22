using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class MediclaimApplicationManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static MediclaimApplicationManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static MediclaimApplicationManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MediclaimApplicationManagement();
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
        public string DefaultColumn = "CustomerName, MediclaimApplicationNumber, MediclaimApplicationDate, ReasonForClaim, ApprovalStatus";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "MediclaimApplicationID";
        #endregion

        #region Methods & Implementation
        public List<MediclaimApplication> GetMediclaimApplicationsList(bool allOffices = false, bool showDeleted = false)
        {
            return MediclaimApplicationIntegration.GetMediclaimApplicationsList(allOffices, showDeleted);
        }

        public List<MediclaimApplication> GetMediclaimApplicationsListByApprovalStatus(string approvalStatus, bool allOffices = false)
        {
            return MediclaimApplicationIntegration.GetMediclaimApplicationsListByApprovalStatus(approvalStatus, allOffices);
        }

        public List<MediclaimApplication> GetMediclaimApplicationsListByCustomerID(int customerID)
        {
            return MediclaimApplicationIntegration.GetMediclaimApplicationsListByCustomerID(customerID);
        }

        public MediclaimApplication GetApprovalStatuswiseMediclaimApplication(int customerID)
        {
            return MediclaimApplicationIntegration.GetApprovalStatuswiseMediclaimApplication(customerID);
        }

        public MediclaimApplication GetMediclaimApplicationByID(int mediclaimApplicationID)
        {
            return MediclaimApplicationIntegration.GetMediclaimApplicationByID(mediclaimApplicationID);
        }

        public int InsertMediclaimApplication(MediclaimApplication theMediclaimApplication)
        {
            return MediclaimApplicationIntegration.InsertMediclaimApplication(theMediclaimApplication);
        }

        public int UpdateMediclaimApplication(MediclaimApplication theMediclaimApplication)
        {
            return MediclaimApplicationIntegration.UpdateMediclaimApplication(theMediclaimApplication);
        }

        public int UpdateMediclaimApplicationApprovalStatus(MediclaimApplication theMediclaimApplication)
        {
            return MediclaimApplicationIntegration.UpdateMediclaimApplicationApprovalStatus(theMediclaimApplication);
        }

        public int DeleteMediclaimApplication(MediclaimApplication theMediclaimApplication)
        {
            return MediclaimApplicationIntegration.DeleteMediclaimApplication(theMediclaimApplication);
        }
        #endregion
    }
}
