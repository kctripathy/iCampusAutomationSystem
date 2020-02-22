using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.IntegrationLayer.InventoryControl;
using Micro.Objects.InventoryControl;

namespace Micro.BusinessLayer.InventoryControl
{
    public partial class ItemDetailManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ItemDetailManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ItemDetailManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ItemDetailManagement();
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
        #endregion

        #region Methods & Implementation
        public List<ItemDetail> GetAllReceivedItem()
        {
            return ItemDetailIntegration.GetAllReceivedItem();
        }

        public ItemDetail GetReceivedItemByID(int ItemDetailID)
        {
            return ItemDetailIntegration.GetReceivedItemByID(ItemDetailID);
        }

        public int InsertReceivedItem(ItemDetail TheItemDetail)
        {
            return ItemDetailIntegration.InsertReceivedItem(TheItemDetail);
        }

        public int UpdateReceivedItem(ItemDetail TheItemDetail)
        {
            return ItemDetailIntegration.UpdateReceivedItem(TheItemDetail);
        }

        public int DeleteReceivedItem(ItemDetail TheItemDetail)
        {
            return ItemDetailIntegration.DeleteReceivedItem(TheItemDetail);
        }
        #endregion
    }
}
