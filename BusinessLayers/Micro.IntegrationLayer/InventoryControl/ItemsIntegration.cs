using System.Collections.Generic;
using Micro.Objects;
using System.Data;
using Micro.DataAccessLayer;
using Micro.Objects.InventoryControl;
using System.Data.SqlClient;
using Micro.DataAccessLayer.InventoryControl;
using System;

namespace Micro.IntegrationLayer.InventoryControl
{
	public partial class AssetIntegration
	{
		#region Declaration
		#endregion

		#region Item Group's Methods and Implementations
		public static ItemGroup DataRowToObjectItemGroup(DataRow itemGroupdr)
		{
			ItemGroup TheItemGroup = new ItemGroup();

			TheItemGroup.ItemGroupID = int.Parse(itemGroupdr["ItemGroupID"].ToString());
			TheItemGroup.ItemGroupName = itemGroupdr["ItemGroupName"].ToString();
			TheItemGroup.ItemGroupParentID = itemGroupdr["ItemGroupParentID"].Equals(DBNull.Value) ? 0 : int.Parse(itemGroupdr["ItemGroupParentID"].ToString());
			TheItemGroup.ItemGroupParentName = itemGroupdr["ItemGroupParentName"].ToString();

			return TheItemGroup;
		}

		public static List<ItemGroup> GetItemGroupsList(bool allCompanies = false, bool showDeleted = false)
		{
			List<ItemGroup> TheItemGroupsList = new List<ItemGroup>();
			DataTable ItemGroupTable = AssetDataAccess.GetInstance.GetItemGroupsList(allCompanies, showDeleted);

			foreach (DataRow itemGroupdr in ItemGroupTable.Rows)
			{
				ItemGroup theItemGroup = DataRowToObjectItemGroup(itemGroupdr);
				TheItemGroupsList.Add(theItemGroup);
			}
			return TheItemGroupsList;
		}

		public static int InsertItemGroup(ItemGroup theItemGroup)
		{
			return AssetDataAccess.GetInstance.InsertItemGroup(theItemGroup);
		}

		public static int UpdateItemGroup(ItemGroup theItemGroup)
		{
			return AssetDataAccess.GetInstance.UpdateItemGroup(theItemGroup);
		}

		public static int DeleteItemGroup(ItemGroup theItemGroup)
		{
			return AssetDataAccess.GetInstance.DeleteItemGroup(theItemGroup);
		}

		public static ItemGroup GetItemGroupByID(int itemGroupID)
		{
			DataRow TheItemGroupRow = AssetDataAccess.GetInstance.GetItemGroupByID(itemGroupID);
			ItemGroup theItemGroup = DataRowToObjectItemGroup(TheItemGroupRow);

			return theItemGroup;
		}
		#endregion

		#region Item's Methods and Implementations
		public static Item DataRowToObjectItem(DataRow itemdr)
		{
			Item TheItem = new Item();

			TheItem.ItemID = int.Parse(itemdr["ItemID"].ToString());
			TheItem.ItemGroupID = int.Parse(itemdr["ItemGroupID"].ToString());
			TheItem.ItemGroupName = itemdr["ItemGroupName"].ToString();
			TheItem.ItemCode = itemdr["ItemCode"].ToString();
			TheItem.ItemName = itemdr["ItemName"].ToString();
			TheItem.UnitOfMeasurement = itemdr["UnitOfMeasurement"].ToString();

            if (itemdr["ItemImageSmall"] != DBNull.Value)
            {
                TheItem.ItemImageSmall = (byte[])itemdr["ItemImageSmall"];
                TheItem.Base64StringSmall = Convert.ToBase64String(TheItem.ItemImageSmall, 0, TheItem.ItemImageSmall.Length);
            }
            else
            {
                TheItem.ItemImageSmall = new byte[0];
            }
            

			if (itemdr["ItemImageMedium"] != DBNull.Value)
				TheItem.ItemImageMedium = (byte[])itemdr["ItemImageMedium"];
			else
				TheItem.ItemImageMedium = new byte[0];

			if (itemdr["ItemImageLarge"] != DBNull.Value)
				TheItem.ItemImageLarge = (byte[])itemdr["ItemImageLarge"];
			else
				TheItem.ItemImageLarge = new byte[0];

			TheItem.OfficeID = int.Parse(itemdr["OfficeID"].ToString());
			TheItem.CompanyID = int.Parse(itemdr["CompanyID"].ToString());

			return TheItem;
		}

		public static List<Item> GetItemsList(bool allOffices = false, bool showDeleted = false)
		{
			List<Item> TheItemList = new List<Item>();
			DataTable ItemTable = AssetDataAccess.GetInstance.GetItemsList(allOffices, showDeleted);

			foreach (DataRow itemdr in ItemTable.Rows)
			{
				Item theItem = DataRowToObjectItem(itemdr);
				TheItemList.Add(theItem);
			}
			return TheItemList;
		}

        public static List<Item> GetItemsListByCompanyID()
        {
            List<Item> TheItemList = new List<Item>();
            DataTable ItemTable = AssetDataAccess.GetInstance.GetItemsListByCompanyID();

            foreach (DataRow itemdr in ItemTable.Rows)
            {
                Item theItem = DataRowToObjectItem(itemdr);
                TheItemList.Add(theItem);
            }
            return TheItemList;
        }
        public static List<Item> GetProductListByCompanyID()
        {
            List<Item> TheItemList = new List<Item>();
            DataTable ItemTable = AssetDataAccess.GetInstance.GetProductListByCompanyID();

            foreach (DataRow itemdr in ItemTable.Rows)
            {
                Item theItem = new Item();
                theItem.ItemID = int.Parse(itemdr["ItemID"].ToString());
                theItem.ItemName = itemdr["ItemName"].ToString();
                theItem.ItemCode = itemdr["ItemCode"].ToString();
                if (itemdr["ItemImageSmall"] != DBNull.Value)
                {
                    theItem.ItemImageSmall = (byte[])itemdr["ItemImageSmall"];
                    theItem.Base64StringSmall = Convert.ToBase64String(theItem.ItemImageSmall, 0, theItem.ItemImageSmall.Length);
                }
                else
                {
                    theItem.ItemImageSmall = new byte[0];
                }
                if (itemdr["ItemImageMedium"] != DBNull.Value)
                {
                    theItem.ItemImageMedium = (byte[])itemdr["ItemImageMedium"];
                }
                else
                {
                    theItem.ItemImageMedium = new byte[0];
                }
                if (itemdr["ItemImageLarge"] != DBNull.Value)
                {
                    theItem.ItemImageLarge = (byte[])itemdr["ItemImageLarge"];
                }
                else
                {
                    theItem.ItemImageLarge = new byte[0];
                }
                if (itemdr["ItemPricePerUnit"].ToString()!=null )
                {
                    theItem.ItemPricePerUnit = (decimal)itemdr["ItemPricePerUnit"];
                }
                TheItemList.Add(theItem);
            }
            return TheItemList;
        }

		public static int InsertItem(Item theItem)
		{
			return AssetDataAccess.GetInstance.InsertItem(theItem);
		}

		public static int UpdateItem(Item theItem)
		{
			return AssetDataAccess.GetInstance.UpdateItem(theItem);
		}

		public static int DeleteItem(Item theItem)
		{
			return AssetDataAccess.GetInstance.DeleteItem(theItem);
		}

		public static Item GetItemByID(int itemID)
		{
			DataRow TheItemRow = AssetDataAccess.GetInstance.GetItemByID(itemID);
			Item theItem = DataRowToObjectItem(TheItemRow);

			return theItem;
		}
		#endregion

		#region Ingredient's Methods and Implementations
		public static Ingredient DataRowToObjectIngredient(DataRow dr)
		{
			Ingredient TheIngredient = new Ingredient();

			TheIngredient.IngredientID = int.Parse(dr["IngredientID"].ToString());
			TheIngredient.InvcItemID = int.Parse(dr["InvcItemID"].ToString());
			TheIngredient.ItemDescription = dr["ItemDescription"].ToString();
			TheIngredient.IngredientName = dr["IngredientName"].ToString();
			TheIngredient.QuanitiyUsed = decimal.Parse(dr["QuanitiyUsed"].ToString());
			TheIngredient.UnitOfMeasurment = dr["UnitOfMeasurment"].ToString();
			TheIngredient.OfficeID = int.Parse(dr["OfficeID"].ToString());
			TheIngredient.CompanyID = int.Parse(dr["CompanyID"].ToString());

			return TheIngredient;
		}

		public static List<Ingredient> GetIngredientsList(bool allOffices = false, bool showDeleted = false)
		{
			List<Ingredient> TheIngredientList = new List<Ingredient>();
			DataTable ItemTable = AssetDataAccess.GetInstance.GetIngredientsList(allOffices, showDeleted);

			foreach (DataRow dr in ItemTable.Rows)
			{
				Ingredient theItem = DataRowToObjectIngredient(dr);
				TheIngredientList.Add(theItem);
			}
			return TheIngredientList;
		}

		public static int InsertIngredient(Ingredient theItem)
		{
			return AssetDataAccess.GetInstance.InsertIngredient(theItem);
		}

		public static int UpdateIngredient(Ingredient theItem)
		{
			return AssetDataAccess.GetInstance.UpdateIngredient(theItem);
		}

		public static int DeleteIngredient(Ingredient theItem)
		{
			return AssetDataAccess.GetInstance.DeleteIngredient(theItem);
		}

		public static Ingredient GetIngredientByID(int ingredientID)
		{
			DataRow TheItemRow = AssetDataAccess.GetInstance.GetIngredientByID(ingredientID);
			Ingredient theItem = DataRowToObjectIngredient(TheItemRow);

			return theItem;
		}
		#endregion
	}
}
