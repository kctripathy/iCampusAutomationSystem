using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.InventoryControl;
using Micro.DataAccessLayer.InventoryControl;
using System.Data;
using Micro.Commons;

namespace Micro.IntegrationLayer.InventoryControl
{
    public partial class ItemDetailIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

        public static ItemDetail DataRowToBookingObject(DataRow dr)
        {
            ItemDetail theItemDetail = new ItemDetail();
            {
                theItemDetail.ItemDetailID = int.Parse(dr["ItemDetailID"].ToString());
                theItemDetail.ItemID = int.Parse(dr["ItemID"].ToString());
                theItemDetail.ItemName = dr["ItemName"].ToString();
                if (!string.IsNullOrEmpty(dr["TransactionDate"].ToString()))
                {
                    theItemDetail.TransactionDate = DateTime.Parse(dr["TransactionDate"].ToString()).ToString(MicroConstants.DateFormat);
                }
                theItemDetail.ItemQuantity = int.Parse(dr["ItemQuantity"].ToString());
                theItemDetail.ItemPricePerUnit = decimal.Parse(dr["ItemPricePerUnit"].ToString());
                theItemDetail.ItemValue = decimal.Parse(dr["ItemValue"].ToString());
                theItemDetail.EntrySide = dr["EntrySide"].ToString();
            }
            return theItemDetail;
        }

        public static List<ItemDetail> GetAllReceivedItem()
        {
            List<ItemDetail> ItemDetailList = new List<ItemDetail>();
            DataTable ItemDetailTable = new DataTable();
            ItemDetailTable = ItemDetailDataAccess.GetInstance.GetAllReceivedItem();
            foreach (DataRow dr in ItemDetailTable.Rows)
            {
                ItemDetail theItemDetail = DataRowToBookingObject(dr);
                ItemDetailList.Add(theItemDetail);
            }
            return ItemDetailList;
        }

        public static ItemDetail GetReceivedItemByID(int ItemDetailID)
        {
            DataRow ItemDetailRow = ItemDetailDataAccess.GetInstance.GetReceivedItemByID(ItemDetailID);
            ItemDetail theItemDetail = DataRowToBookingObject(ItemDetailRow);
            return theItemDetail;
        }

        public static int InsertReceivedItem(ItemDetail TheItemDetail)
        {
            return ItemDetailDataAccess.GetInstance.InsertReceivedItem(TheItemDetail);
        }

        public static int UpdateReceivedItem(ItemDetail TheItemDetail)
        {
            return ItemDetailDataAccess.GetInstance.UpdateReceivedItem(TheItemDetail);
        }

        public static int DeleteReceivedItem(ItemDetail TheItemDetail)
        {
            return ItemDetailDataAccess.GetInstance.DeleteReceivedItem(TheItemDetail);
        }
        #endregion
    }
}
