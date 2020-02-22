using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.InventoryControl;
using System.Data.SqlClient;
using System.Data;

namespace Micro.DataAccessLayer.InventoryControl
{
    public partial class ItemDetailDataAccess: AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ItemDetailDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ItemDetailDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ItemDetailDataAccess();
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

        public DataTable GetAllReceivedItem()
        {
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.CommandText = "pINVC_ItemDetails_SelectAll";
            return ExecuteGetDataTable(SelectCommand);
        }

        public DataRow GetReceivedItemByID(int ItemDetailID)
        {
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@ItemDetailID", SqlDbType.Int, ItemDetailID));
            SelectCommand.CommandText = "";
            return ExecuteGetDataRow(SelectCommand);
        }

        public int InsertReceivedItem(ItemDetail TheItemDetail)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@ItemID", SqlDbType.Int, TheItemDetail.ItemID));
                InsertCommand.Parameters.Add(GetParameter("@TransactionDate", SqlDbType.VarChar, TheItemDetail.TransactionDate));
                InsertCommand.Parameters.Add(GetParameter("@ItemQuantity", SqlDbType.Int, TheItemDetail.ItemQuantity));
                InsertCommand.Parameters.Add(GetParameter("@ItemPricePerUnit", SqlDbType.Decimal, TheItemDetail.ItemPricePerUnit));
                InsertCommand.Parameters.Add(GetParameter("@ItemValue", SqlDbType.Decimal, TheItemDetail.ItemValue));
                InsertCommand.Parameters.Add(GetParameter("@EntrySide", SqlDbType.VarChar, TheItemDetail.EntrySide));
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pINVC_ItemDetails_Insert_Update";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int UpdateReceivedItem(ItemDetail TheItemDetail)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@ItemDetailID", SqlDbType.Int, TheItemDetail.ItemDetailID));
                UpdateCommand.Parameters.Add(GetParameter("@ItemID", SqlDbType.Int, TheItemDetail.ItemID));
                UpdateCommand.Parameters.Add(GetParameter("@TransactionDate", SqlDbType.VarChar, TheItemDetail.TransactionDate));
                UpdateCommand.Parameters.Add(GetParameter("@ItemQuantity", SqlDbType.Int, TheItemDetail.ItemQuantity));
                UpdateCommand.Parameters.Add(GetParameter("@ItemPricePerUnit", SqlDbType.Decimal, TheItemDetail.ItemPricePerUnit));
                UpdateCommand.Parameters.Add(GetParameter("@ItemValue", SqlDbType.Decimal, TheItemDetail.ItemValue));
                UpdateCommand.Parameters.Add(GetParameter("@EntrySide", SqlDbType.VarChar, TheItemDetail.EntrySide));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pINVC_ItemDetails_Insert_Update";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int DeleteReceivedItem(ItemDetail TheItemDetail)
        {
            int ReturnValue = 0;
            SqlCommand DeleteCommand = new SqlCommand();
            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            DeleteCommand.Parameters.Add(GetParameter("@ItemDetailID", SqlDbType.Int, TheItemDetail.ItemDetailID));
            DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            DeleteCommand.CommandText = "pINVC_ItemDetails_Delete";
            ExecuteStoredProcedure(DeleteCommand);
            ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
            return ReturnValue;
        }
        #endregion
    }
}
