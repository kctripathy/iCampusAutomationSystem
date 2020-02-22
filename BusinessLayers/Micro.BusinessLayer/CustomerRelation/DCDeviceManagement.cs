using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
   public partial  class DCDeviceManagement
   {
       #region Declaration
       public string DefaultColumns = "DCDeviceID, DCDeviceCode, DCDeviceSerialNumber, DCCollectorCode, DCCollectorName";
       public string DisplayMember = "DCDeviceSerialNumber";
       public string ValueMember = "DCDeviceID";
       #endregion
       
       #region Code to make this as Singleton Class
       /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static DCDeviceManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static DCDeviceManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DCDeviceManagement();
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
       public List<DCDevice> GetDCDeviceList(bool allOffices = false, bool showDeleted = false)
       {
           return DCDeviceIntegration.GetDCDeviceList(allOffices,showDeleted);
       }

       public DCDevice GetDCDevicesById(int DCDeviceID)
       {
           return DCDeviceIntegration.GetDCDevicesById(DCDeviceID);
       }

       public int InsertDCDevices(DCDevice theDCDevice)
       {
           return DCDeviceIntegration.InsertDCDevices(theDCDevice);
       }

       public int UpdateDCDevices(DCDevice theDCDevice)
       {
           return DCDeviceIntegration.UpdateDCDevices(theDCDevice);
       }

       public int DeleteDCDevices(DCDevice theDCDevice)
       {
           return DCDeviceIntegration.DeleteDCDevices(theDCDevice);
       }
        #endregion
    }
}
