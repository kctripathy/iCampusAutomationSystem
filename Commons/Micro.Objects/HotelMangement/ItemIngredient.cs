using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.Hotel
{
    public class ItemIngredient
    {
        public int ItemID
        {
            get;
            set;
        }
        public int ItemIngredientID
        {
            get;
            set;
        }
        public string ItemIngredientCode
        {
            get;
            set;
        }
		public string ItemDescription
        {
            get;
            set;
        }
		public string UnitOfMeasurement
        {
            get;
            set;
        }
		public string QuantityOnHand
        {
            get;
            set;
        }
		public decimal ItemPrice
        {
            get;
            set;
        }
		public int CurrencyID
        {
            get;
            set;
        }
		public byte[] ItemSmallImage
		{
			get;
			set;
		}
		public string SettingKeyNameSmall
		{
			get;
			set;
		}
		public byte[] ItemMidiumImage
		{
			get;
			set;
		}
		public string SettingKeyNameMidium
		{
			get;
			set;
		}
		public byte[] ItemLargeImage
		{
			get;
			set;
		}
		public string SettingKeyNameLarge
		{
			get;
			set;
		}
		public int OfficeID
		{
			get;
			set;
		}
		public int CompanyID
        {
            get;
            set;
        }
		public int AddedBy
        {
            get;
            set;
        }
    }
}
