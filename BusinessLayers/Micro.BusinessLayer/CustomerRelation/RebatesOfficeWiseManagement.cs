using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class RebatesOfficeWiseManagement
    {
        #region Declaration

        public string DefaultColumn = "PolicyName,PolicyTypeDescription,InstallmentMode,RebatePer,RebateValue,EffectiveDateFrom";
        public string DisplayMember = "PolicyName";
        public string ValueMember = "RebateOfficewiseID";
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static RebatesOfficeWiseManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static RebatesOfficeWiseManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new RebatesOfficeWiseManagement();
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

        public List<RebatesOfficeWise> GetRebateOfficeWiseList(bool allOffices = false, bool showDeleted = false)
        {
            return RebatesOfficeWiseIntegration.GetRebateOfficeWiseList(allOffices, showDeleted);
        }

        public List<RebatesOfficeWise> GetRebatesSelectByOfficeID(bool ShowInOfficewise = false)
        {
            return RebatesOfficeWiseIntegration.GetRebatesSelectByOfficeID(ShowInOfficewise);
        }

        public int InsertOfficeWiseRebates(string RebateIDs, string EffectiveDateFrom)
        {
            return RebatesOfficeWiseIntegration.InsertOfficeWiseRebates(RebateIDs, EffectiveDateFrom);
        }
        public int DeleteOfficeWiseRebates(string RebateIDs)
        {
            return RebatesOfficeWiseIntegration.DeleteOfficeWiseRebates(RebateIDs);
        }
        #endregion
    }
}
