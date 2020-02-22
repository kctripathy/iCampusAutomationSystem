using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class DCReceiptIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementations
        public static DCReceipt DataRowToObject(DataRow dr)
        {
            DCReceipt TheDCReceipt = new DCReceipt();

            TheDCReceipt.DCReceiptID = int.Parse(dr["DCReceiptID"].ToString());
            TheDCReceipt.DCAccountID = int.Parse(dr["DCAccountID"].ToString());
            TheDCReceipt.DCAccountCode = dr["DCAccountCode"].ToString();
            TheDCReceipt.CustomerName = dr["CustomerName"].ToString();
            TheDCReceipt.DCReceiptDate = DateTime.Parse(dr["DCReceiptDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheDCReceipt.DCReceiptAmount = decimal.Parse(dr["DCReceiptAmount"].ToString());
            TheDCReceipt.DCReceiptNumber = dr["DCReceiptNumber"].ToString();
            TheDCReceipt.DCCollectorID = int.Parse(dr["DCCollectorID"].ToString());
            TheDCReceipt.DCCollectorCode = dr["DCCollectorCode"].ToString();
            TheDCReceipt.DCCollectorName = dr["DCCollectorName"].ToString();
            TheDCReceipt.DCDeviceID = int.Parse(dr["DCDeviceID"].ToString());
            TheDCReceipt.DCDeviceCode = dr["DCDeviceCode"].ToString();
            TheDCReceipt.DCDeviceSerialNumber = dr["DCDeviceSerialNumber"].ToString();
            TheDCReceipt.DCPaymentMode = dr["DCPaymentMode"].ToString();
            TheDCReceipt.DCPaymentReference = dr["DCPaymentReference"].ToString();
            TheDCReceipt.DCAmountActualCollectionDateTime = DateTime.Parse(dr["DCReceiptDate"].ToString()).ToString(MicroConstants.DateFormat);

            return TheDCReceipt;
        }

        public static List<DCReceipt> GetDCReceiptList(bool allOffices = false, bool showDeleted = false)
        {
            List<DCReceipt> DcReceiptList = new List<DCReceipt>();

            DataTable DcReceiptTable = new DataTable();
            DcReceiptTable = DCReceiptDataAccess.GetInstance.GetDCReceiptList(allOffices,showDeleted);

            foreach (DataRow dr in DcReceiptTable.Rows)
            {
                DCReceipt TheDcReceipt = DataRowToObject(dr);

                DcReceiptList.Add(TheDcReceipt);
            }

            return DcReceiptList;
        }

        public static List<DCReceipt> GetDCReceiptsByAccountID(int DCAccountID)
        {
            List<DCReceipt> DcReceiptList = new List<DCReceipt>();

            DataTable DcReceiptTable = new DataTable();
            DcReceiptTable = DCReceiptDataAccess.GetInstance.GetDCReceiptsByAccountID(DCAccountID);

            foreach (DataRow dr in DcReceiptTable.Rows)
            {
                DCReceipt TheDcReceipt = DataRowToObject(dr);

                DcReceiptList.Add(TheDcReceipt);
            }

            return DcReceiptList;
        }

        public static DCReceipt GetDCReceiptsByReceiptId(int DCReceiptID)
        {
            DataRow DcReceiptRow = DCReceiptDataAccess.GetInstance.GetDCReceiptsByReceiptId(DCReceiptID);

            DCReceipt TheDcReceiptRow = DataRowToObject(DcReceiptRow);

            return TheDcReceiptRow;
        }

        public static int InsertDcReceipt(DCReceipt theDcReceipt)
        {
            return DCReceiptDataAccess.GetInstance.InsertDcReceipt(theDcReceipt);
        }

        public static int CancelDcReceipt(DCReceipt theDcReceipt)
        {
            return DCReceiptDataAccess.GetInstance.CancelDcReceipt(theDcReceipt);
        }
        #endregion
    }
}
