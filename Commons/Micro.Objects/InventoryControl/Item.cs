using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.InventoryControl
{
	#region ItemGroup
	public class ItemGroup
	{
		public int ItemGroupID
		{
			get;
			set;
		}
		public string ItemGroupName
		{
			get;
			set;
		}
		public int ItemGroupParentID
		{
			get;
			set;
		}
		public string ItemGroupParentName
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
		public int CompanyID
		{
			get;
			set;
		}
	}
	#endregion

	#region Item
	public class Item
	{
		public int ItemID
		{
			get;
			set;
		}

		public string ItemCode
		{
			get;
			set;
		}
		public string ItemName
		{
			get;
			set;
		}
		public int ItemGroupID
		{
			get;
			set;
		}
		public string ItemGroupName
		{
			get;
			set;
		}
		public string UnitOfMeasurement
		{
			get;
			set;
		}
		//public string QuantityOnHand
		//{
		//    get;
		//    set;
		//}
		//public decimal ItemPrice
		//{
		//    get;
		//    set;
		//}
		//public int CurrencyID
		//{
		//    get;
		//    set;
		//}
		public byte[] ItemImageSmall
		{
			get;
			set;
		}
		//public string SettingKeyNameSmall
		//{
		//    get;
		//    set;
		//}
		public byte[] ItemImageMedium
		{
			get;
			set;
		}
		//public string SettingKeyNameMidium
		//{
		//    get;
		//    set;
		//}
		public byte[] ItemImageLarge
		{
			get;
			set;
		}
		//public string SettingKeyNameLarge
		//{
		//    get;
		//    set;
		//}
		public string ItemSmallImageUrl
		{
			get;
			set;
		}

        public String Base64StringSmall
        {
            get;
            set;
        }
        public String Base64StringMedium
        {
            get;
            set;
        }
        public String Base64StringLarge
        {
            get;
            set;
        }
        public decimal ItemPricePerUnit
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
        public decimal SubTotal
        {
            get
            {
                if (Quantity == 0)
                {
                    return ItemPricePerUnit;
                }
                else
                {
                   decimal total = this.ItemPricePerUnit * this.Quantity;
                    return total;
                }
            }
        }
		public int OfficeID
		{
			get;
			set;
		}
		public int AddedBy
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
		public int CompanyID
		{
			get;
			set;
		}
	}
	#endregion

	#region Ingredient
	public class Ingredient
	{
		public int IngredientID
		{
			get;
			set;
		}
		public int InvcItemID
		{
			get;
			set;
		}
		public string ItemDescription
		{
			get;
			set;
		}
		public string IngredientName
		{
			get;
			set;
		}
		public decimal QuanitiyUsed
		{
			get;
			set;
		}
		public string UnitOfMeasurment
		{
			get;
			set;
		}
		public int OfficeID
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
		public int CompanyID
		{
			get;
			set;
		}
	}
	#endregion
}
