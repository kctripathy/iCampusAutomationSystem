using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.InventoryControl
{
    public class ItemDetail
    {
        public int ItemDetailID
        {
            get;
            set;
        }
        public int ItemID
        {
            get;
            set;
        }
        public string TransactionDate
        {
            get;
            set;
        }
        public int ItemQuantity
        {
            get;
            set;
        }
        public decimal ItemPricePerUnit
        {
            get;
            set;
        }
        public decimal ItemValue
        {
            get;
            set;
        }
        public string EntrySide
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public string DateAdded
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }
        public string ItemName
        {
            get;
            set;
        }
    }
}
