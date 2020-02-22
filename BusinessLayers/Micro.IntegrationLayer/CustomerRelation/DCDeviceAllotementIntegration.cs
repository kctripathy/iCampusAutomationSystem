using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class DCDeviceAllotementIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static DCDeviceAllotment DataRowToObject(DataRow dr)
        {
            DCDeviceAllotment TheDCDeviceAllotment = new DCDeviceAllotment();

            TheDCDeviceAllotment.DCDeviceAllotmentID = int.Parse(dr["DCDeviceAllotmentID"].ToString());
            TheDCDeviceAllotment.DCDeviceID = int.Parse(dr["DCDeviceID"].ToString());
            TheDCDeviceAllotment.DCDeviceCode = dr["DCDeviceCode"].ToString();
            TheDCDeviceAllotment.DCDeviceSerialNumber = dr["DCDeviceSerialNumber"].ToString();
            TheDCDeviceAllotment.DCCollectorID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["DCCollectorID"].ToString()));
            TheDCDeviceAllotment.DCCollectorName = dr["DCCollectorName"].ToString();
            TheDCDeviceAllotment.EffectiveDateFrom = dr["EffectiveDateFrom"].ToString();
            TheDCDeviceAllotment.EffectiveDateTo = dr["EffectiveDateTo"].ToString();
            TheDCDeviceAllotment.AddedBy = int.Parse(dr["AddedBy"].ToString());
            TheDCDeviceAllotment.OfficeID = int.Parse(dr["OfficeID"].ToString());
            TheDCDeviceAllotment.DateAdded = DateTime.Parse(dr["DateAdded"].ToString()).ToString(MicroConstants.DateFormat);

            return TheDCDeviceAllotment;
        }

        public static List<DCDeviceAllotment> GetDCDeviceAllotementList(bool allOffices = false, bool showDeleted = false)
        {
            List<DCDeviceAllotment> DCDeviceAllotmentList = new List<DCDeviceAllotment>();

            DataTable DCDeviceAllotmentTable = new DataTable();
            DCDeviceAllotmentTable = DCDeviceAllotmentDataAccess.GetInstance.GetDCDeviceAllotementList(allOffices,showDeleted);

            foreach (DataRow dr in DCDeviceAllotmentTable.Rows)
            {
                DCDeviceAllotment TheDCDevice = DataRowToObject(dr);

                DCDeviceAllotmentList.Add(TheDCDevice);
            }

            return DCDeviceAllotmentList;
        }

        public static int InsertDCDeviceAllotment(DCDeviceAllotment theDCDeviceAllotment)
        {
            return DCDeviceAllotmentDataAccess.GetInstance.InsertDCDeviceAllotment(theDCDeviceAllotment);
        }
        #endregion
    }
}
