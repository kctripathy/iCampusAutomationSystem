using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;
using Micro.Objects.InventoryControl;

namespace Micro.DataAccessLayer.InventoryControl
{
	public partial class AssetDataAccess
	{
		#region Declaration
		#endregion

		#region Item Group
		public DataTable GetItemGroupsList(bool allCompanies = false, bool showDeleted = false)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@AllCompanies", SqlDbType.Bit, allCompanies));
				SelectCommand.Parameters.Add(GetParameter("@CompanyId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
				SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
				SelectCommand.CommandText = "pINVC_ItemGroups_SelectAll";
				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public int InsertItemGroup(ItemGroup theItemGroup)
		{
			int ReturnValue = 0;

			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@ItemGroupName", SqlDbType.VarChar, theItemGroup.ItemGroupName));
				InsertCommand.Parameters.Add(GetParameter("@ItemGroupParentID", SqlDbType.Int, theItemGroup.ItemGroupParentID));
				InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				InsertCommand.CommandText = "pINVC_ItemGroups_Insert_Update";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public int UpdateItemGroup(ItemGroup theItemGroup)
		{
			int ReturnValue = 0;

			using (SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@ItemGroupID", SqlDbType.Int, theItemGroup.ItemGroupID));
				UpdateCommand.Parameters.Add(GetParameter("@ItemGroupName", SqlDbType.VarChar, theItemGroup.ItemGroupName));
				UpdateCommand.Parameters.Add(GetParameter("@ItemGroupParentID", SqlDbType.Int, theItemGroup.ItemGroupParentID));
				UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				UpdateCommand.CommandText = "pINVC_ItemGroups_Insert_Update";

				ExecuteStoredProcedure(UpdateCommand);

				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public DataRow GetItemGroupByID(int itemGroupID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@ItemGroupID", SqlDbType.Int, itemGroupID));
				SelectCommand.CommandText = "pINVC_ItemGroups_SelectByItemGroupID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public int DeleteItemGroup(ItemGroup theItemGroup)
		{
			int ReturnValue = 0;

			using (SqlCommand DeleteCommand = new SqlCommand())
			{
				DeleteCommand.CommandType = CommandType.StoredProcedure;
				DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				DeleteCommand.Parameters.Add(GetParameter("@ItemGroupID", SqlDbType.Int, theItemGroup.ItemGroupID));
				DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				DeleteCommand.CommandText = "pINVC_ItemGroups_Delete";

				ExecuteStoredProcedure(DeleteCommand);

				ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}
		#endregion

		#region Item
		public DataTable GetItemsList(bool allOffices = false, bool showDeleted = false)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
				SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
				SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pINVC_Items_SelectAll";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

        public DataTable GetItemsListByCompanyID()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                SelectCommand.CommandText = "pINVC_Items_SelectByCompanyID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetProductListByCompanyID()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CompanyID",SqlDbType.Int,6 ));// Micro.Commons.Connection.LoggedOnUser.CompanyID
                SelectCommand.CommandText = "pINVC_Items_SelectBy";

               return ExecuteGetDataTable(SelectCommand);

                
            }
        }
		public int InsertItem(Item theItem)
		{
			int ReturnValue = 0;

			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@ItemCode", SqlDbType.VarChar, theItem.ItemCode));
				InsertCommand.Parameters.Add(GetParameter("@ItemName", SqlDbType.VarChar, theItem.ItemName));
				InsertCommand.Parameters.Add(GetParameter("@ItemGroupID", SqlDbType.Int, theItem.ItemGroupID));
				InsertCommand.Parameters.Add(GetParameter("@UnitOfMeasurement", SqlDbType.VarChar, theItem.UnitOfMeasurement));
				//InsertCommand.Parameters.Add(GetParameter("@QuantityOnHand", SqlDbType.VarChar, theItem.QuantityOnHand));
				//InsertCommand.Parameters.Add(GetParameter("@ItemPrice", SqlDbType.Decimal, theItem.ItemPrice));
				//InsertCommand.Parameters.Add(GetParameter("@CurrencyID", SqlDbType.Int, theItem.CurrencyID));
				InsertCommand.Parameters.Add(GetParameter("@ItemImageSmall", SqlDbType.VarBinary, theItem.ItemImageSmall));
				//InsertCommand.Parameters.Add(GetParameter("@SettingKeyNameSmall", SqlDbType.VarChar, theItem.SettingKeyNameSmall));
				InsertCommand.Parameters.Add(GetParameter("@ItemImageMedium", SqlDbType.VarBinary, theItem.ItemImageMedium));
				//InsertCommand.Parameters.Add(GetParameter("@SettingKeyNameMidium", SqlDbType.VarChar, theItem.SettingKeyNameMidium));
				InsertCommand.Parameters.Add(GetParameter("@ItemImageLarge", SqlDbType.VarBinary, theItem.ItemImageLarge));
				//InsertCommand.Parameters.Add(GetParameter("@SettingKeyNameLarge", SqlDbType.VarChar, theItem.SettingKeyNameLarge));
				InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				InsertCommand.CommandText = "pINVC_Items_Insert_Update";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public int UpdateItem(Item theItem)
		{
			int ReturnValue = 0;

			using (SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@ItemID", SqlDbType.Int, theItem.ItemID));
				UpdateCommand.Parameters.Add(GetParameter("@ItemCode", SqlDbType.VarChar, theItem.ItemCode));
				UpdateCommand.Parameters.Add(GetParameter("@ItemName", SqlDbType.VarChar, theItem.ItemName));
				UpdateCommand.Parameters.Add(GetParameter("@ItemGroupID", SqlDbType.Int, theItem.ItemGroupID));
				UpdateCommand.Parameters.Add(GetParameter("@UnitOfMeasurement", SqlDbType.VarChar, theItem.UnitOfMeasurement));
				UpdateCommand.Parameters.Add(GetParameter("@ItemImageSmall", SqlDbType.VarBinary, theItem.ItemImageSmall));
				UpdateCommand.Parameters.Add(GetParameter("@ItemImageMedium", SqlDbType.VarBinary, theItem.ItemImageMedium));
				UpdateCommand.Parameters.Add(GetParameter("@ItemImageLarge", SqlDbType.VarBinary, theItem.ItemImageLarge));
				UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				UpdateCommand.CommandText = "pINVC_Items_Insert_Update";

				ExecuteStoredProcedure(UpdateCommand);

				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public DataRow GetItemByID(int itemID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@ItemID", SqlDbType.Int, itemID));
				SelectCommand.CommandText = "pINVC_Items_SelectByItemID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public int DeleteItem(Item theItem)
		{
			int ReturnValue = 0;

			using (SqlCommand DeleteCommand = new SqlCommand())
			{
				DeleteCommand.CommandType = CommandType.StoredProcedure;
				DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				DeleteCommand.Parameters.Add(GetParameter("@ItemID", SqlDbType.Int, theItem.ItemID));
				DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				DeleteCommand.CommandText = "pINVC_Items_Delete";

				ExecuteStoredProcedure(DeleteCommand);

				ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}
		#endregion

		#region Ingredient
		public DataTable GetIngredientsList(bool allOffices = false, bool showDeleted = false)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
				SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
				SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pHOTEL_Ingredients_SelectAll";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public int InsertIngredient(Ingredient theIngredient)
		{
			int ReturnValue = 0;

			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@InvcItemID", SqlDbType.Int, theIngredient.InvcItemID));
				InsertCommand.Parameters.Add(GetParameter("@IngredientName", SqlDbType.VarChar, theIngredient.IngredientName));
				InsertCommand.Parameters.Add(GetParameter("@QuanitiyUsed", SqlDbType.Decimal, theIngredient.QuanitiyUsed));
				InsertCommand.Parameters.Add(GetParameter("@UnitOfMeasurment", SqlDbType.VarChar, theIngredient.UnitOfMeasurment));
				InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pHOTEL_Ingredients_Insert_Update";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public int UpdateIngredient(Ingredient theIngredient)
		{
			int ReturnValue = 0;

			using (SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@IngredientID", SqlDbType.Int, theIngredient.IngredientID));
				UpdateCommand.Parameters.Add(GetParameter("@InvcItemID", SqlDbType.Int, theIngredient.InvcItemID));
				UpdateCommand.Parameters.Add(GetParameter("@IngredientName", SqlDbType.VarChar, theIngredient.IngredientName));
				UpdateCommand.Parameters.Add(GetParameter("@QuanitiyUsed", SqlDbType.Decimal, theIngredient.QuanitiyUsed));
				UpdateCommand.Parameters.Add(GetParameter("@UnitOfMeasurment", SqlDbType.VarChar, theIngredient.UnitOfMeasurment));
				UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
				UpdateCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				UpdateCommand.CommandText = "pHOTEL_Ingredients_Insert_Update";

				ExecuteStoredProcedure(UpdateCommand);

				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public DataRow GetIngredientByID(int ingredientID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@IngredientID", SqlDbType.Int, ingredientID));
				SelectCommand.CommandText = "pHOTEL_Ingredients_SelectByIngrediantID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public int DeleteIngredient(Ingredient theIngredient)
		{
			int ReturnValue = 0;

			using (SqlCommand DeleteCommand = new SqlCommand())
			{
				DeleteCommand.CommandType = CommandType.StoredProcedure;
				DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				DeleteCommand.Parameters.Add(GetParameter("@IngredientID", SqlDbType.Int, theIngredient.IngredientID));
				DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				DeleteCommand.CommandText = "pHOTEL_Ingredients_Delete";

				ExecuteStoredProcedure(DeleteCommand);

				ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}
		#endregion
	}
}
