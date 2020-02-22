using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class DCDeviceAllotmentManagement
    {
        #region Declaration
        public string DefaultColumns = "DCDeviceID , DCDeviceCode, DCDeviceSerialNumber, DCCollectorName";
        public string DisplayMember = "DCCollectorName";
        public string ValueMember = "DCDeviceAllotmentID";
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DCDeviceAllotmentManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DCDeviceAllotmentManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DCDeviceAllotmentManagement();
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
        public List<DCDeviceAllotment> GetDCDeviceAllotementList(bool allOffices = false, bool showDeleted = false)
        {
            return DCDeviceAllotementIntegration.GetDCDeviceAllotementList(allOffices,showDeleted);
        }

        public int InsertDCDeviceAllotment(DCDeviceAllotment theDCDeviceAllotment)
        {
            return DCDeviceAllotementIntegration.InsertDCDeviceAllotment(theDCDeviceAllotment);
        }
        #endregion

    }
}
