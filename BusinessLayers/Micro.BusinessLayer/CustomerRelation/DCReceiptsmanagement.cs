using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class DCReceiptsmanagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DCReceiptsmanagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DCReceiptsmanagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DCReceiptsmanagement();
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
        public string DefaultColumns = "DCReceiptID, DCReceiptDate, DCReceiptNumber, DCAmountActualCollectionDateTime,CustomerName,DCCollectorName,DCAccountCode";
        public string DisplayMember = "DCReceiptNumber";
        public string ValueMember = "DCReceiptID";
        #endregion

        #region Declaration
        public List<DCReceipt> GetDCReceiptList(bool allOffices = false, bool showDeleted = false)
        {
            return DCReceiptIntegration.GetDCReceiptList(allOffices,showDeleted);
        }

        public List<DCReceipt> GetDCReceiptsByAccountID(int DCAccountID)
        {
            return DCReceiptIntegration.GetDCReceiptsByAccountID(DCAccountID);
        }

        public DCReceipt GetDCReceiptsByReceiptId(int DCReceiptID)
        {
            return DCReceiptIntegration.GetDCReceiptsByReceiptId(DCReceiptID);
        }

        public int InsertDcReceipt(DCReceipt theDcReceipt)
        {
            return DCReceiptIntegration.InsertDcReceipt(theDcReceipt);
        }

        public int CancelDcReceipt(DCReceipt theDcReceipt)
        {
            return DCReceiptIntegration.CancelDcReceipt(theDcReceipt);
        }
        #endregion
    }
}
