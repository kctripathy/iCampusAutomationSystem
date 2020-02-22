using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.InventoryControl;
using Micro.IntegrationLayer;
using Micro.IntegrationLayer.InventoryControl;
using Micro.Commons;

namespace Micro.BusinessLayer.InventoryControl
{
	public partial class AssetManagement
	{
		#region ItemGroup
		#region Declaration
		public string ItemGroupDisplayMember = "ItemGroupName";
		public string ItemGroupValueMember = "ItemGroupID";
		#endregion

		public List<ItemGroup> GetItemGroupsList(bool allCompanies = false, bool showDeleted = false)
		{
			return AssetIntegration.GetItemGroupsList(allCompanies, showDeleted);
		}

		public ItemGroup GetItemGroupByID(int itemGroupID)
		{
			return AssetIntegration.GetItemGroupByID(itemGroupID);
		}


		public int InsertItemGroup(ItemGroup theItemGroup)
		{
			return AssetIntegration.InsertItemGroup(theItemGroup);
		}

		public int UpdateItemGroup(ItemGroup theItemGroup)
		{
			return AssetIntegration.UpdateItemGroup(theItemGroup);
		}

		public int DeleteItemGroup(ItemGroup theItemGroup)
		{
			return AssetIntegration.DeleteItemGroup(theItemGroup);
		}
		#endregion

		#region Item
		#region Declaration
		public string ItemDisplayMember = "ItemName";
		public string ItemValueMember = "ItemID";
		#endregion

		public List<Item> GetItemsList(bool allOffices = false, bool showDeleted = false)
		{
			return AssetIntegration.GetItemsList(allOffices, showDeleted);
		}

		public List<Item> GetItemsListWithItemImage(bool allOffices = false, bool showDeleted = false)
		{
			List<Item> ItemList = GetItemsList(allOffices, showDeleted);

			foreach (Item theItem in ItemList)
			{
				theItem.ItemSmallImageUrl = BasePage.GetProfileImageUrl(theItem.ItemID.ToString(), "", theItem.ItemName);
			}

			return ItemList;
		}

		public List<Item> GetItemsListByCompanyID()
		{
			return AssetIntegration.GetItemsListByCompanyID();
		}

		public List<Item> GetProductListByCompanyID()
		{
			return AssetIntegration.GetProductListByCompanyID();
		}

		public Item GetItemByID(int itemID)
		{
			return AssetIntegration.GetItemByID(itemID);
		}

		public int InsertItem(Item theItem)
		{
			return AssetIntegration.InsertItem(theItem);
		}

		public int UpdateItem(Item theItem)
		{
			return AssetIntegration.UpdateItem(theItem);
		}

		public int DeleteItem(Item theItem)
		{
			return AssetIntegration.DeleteItem(theItem);
		}
		#endregion

		#region Ingredient
		#region Declaration
		public string IngredientDisplayMember = "IngredientName";
		public string IngredientValueMember = "IngredientId";
		#endregion

		public List<Ingredient> GetIngredientsList(bool allOffices = false, bool showDeleted = false)
		{
			return AssetIntegration.GetIngredientsList(allOffices, showDeleted);
		}

		public Ingredient GetIngredientByID(int IngredientID)
		{
			return AssetIntegration.GetIngredientByID(IngredientID);
		}

		public int InsertIngredient(Ingredient theIngredient)
		{
			return AssetIntegration.InsertIngredient(theIngredient);
		}

		public int UpdateIngredient(Ingredient theIngredient)
		{
			return AssetIntegration.UpdateIngredient(theIngredient);
		}

		public int DeleteIngredient(Ingredient theIngredient)
		{
			return AssetIntegration.DeleteIngredient(theIngredient);
		}
		#endregion
	}
}
