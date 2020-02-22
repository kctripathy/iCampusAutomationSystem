using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial  class DCDeviceIntegration
   {
       #region Declaration
       #endregion

       #region Methods & Implementation
       public static DCDevice DataRowToObject(DataRow dr)
       {
           DCDevice TheDCDevice = new DCDevice();
           TheDCDevice.DCCollectorID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["DCCollectorID"].ToString()));
           TheDCDevice.DCDeviceID = int.Parse(dr["DCDeviceID"].ToString());
           TheDCDevice.DCDeviceCode = dr["DCDeviceCode"].ToString();
           TheDCDevice.DCDeviceSerialNumber = dr["DCDeviceSerialNumber"].ToString();
           TheDCDevice.DCCollectorCode = dr["DCCollectorCode"].ToString();
           TheDCDevice.DCCollectorName = dr["DCCollectorName"].ToString();
           TheDCDevice.AddedBy = int.Parse(dr["AddedBy"].ToString());
           TheDCDevice.OfficeID = int.Parse(dr["OfficeID"].ToString());
		   TheDCDevice.OfficeName = dr["OfficeName"].ToString();
           TheDCDevice.DateAdded = DateTime.Parse(dr["DateAdded"].ToString()).ToString(MicroConstants.DateFormat);

           return TheDCDevice;
       }

       public static List<DCDevice> GetDCDeviceList(bool allOffices = false, bool showDeleted = false)
       {
           List<DCDevice> DCDeviceList = new List<DCDevice>();

           DataTable DCDeviceTable = new DataTable();
           DCDeviceTable = DCDeviceDataAccess.GetInstance.GetDCDeviceList(allOffices,showDeleted);

           foreach (DataRow dr in DCDeviceTable.Rows)
           {
               DCDevice TheDCDevice = DataRowToObject(dr);

               DCDeviceList.Add(TheDCDevice);
           }
           return DCDeviceList;
       }

       public static DCDevice GetDCDevicesById(int DCDeviceID)
       {
           DataRow DCDevicesRow = DCDeviceDataAccess.GetInstance.GetDCDevicesById(DCDeviceID);

           DCDevice TheDCDeviceRow = DataRowToObject(DCDevicesRow);

           return TheDCDeviceRow;
       }

       public static int InsertDCDevices(DCDevice theDCDevice)
       {
           return DCDeviceDataAccess.GetInstance.InsertDCDevices(theDCDevice);
       }

       public static int UpdateDCDevices(DCDevice theDCDevice)
       {
           return DCDeviceDataAccess.GetInstance.UpdateDCDevices(theDCDevice);
       }

       public static int DeleteDCDevices(DCDevice theDCDevice)
       {
           return DCDeviceDataAccess.GetInstance.DeleteDCDevices(theDCDevice);
       }
       #endregion
   }
}
