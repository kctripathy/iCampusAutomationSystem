#region System Namespace
using System.Data;
using System.Data.SqlClient;
#endregion

#region Micro Namespaces
using Micro.Objects.HumanResource;
#endregion

namespace Micro.DataAccessLayer.HumanResource
{
    public partial class PayCategoryDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PayCategoryDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PayCategoryDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PayCategoryDataAccess();
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

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertPayCategory(PayCategory thePayCategory)
        {
            int ReturnValue = 0;

            SqlCommand InsertCommand = new SqlCommand();

            InsertCommand.CommandType = CommandType.StoredProcedure;
            InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            InsertCommand.Parameters.Add(GetParameter("@PayCategoryDescription", SqlDbType.VarChar, thePayCategory.PayCategoryDescription));
            InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            InsertCommand.CommandText = "pHRM_PayCategories_Insert";

            ExecuteStoredProcedure(InsertCommand);
            ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int UpdatePayCategory(PayCategory thePayCategory)
        {
            int ReturnValue = 0;

            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            UpdateCommand.Parameters.Add(GetParameter("@PayCategoryID", SqlDbType.Int, thePayCategory.PayCategoryID));
            UpdateCommand.Parameters.Add(GetParameter("@PayCategoryDescription", SqlDbType.VarChar, thePayCategory.PayCategoryDescription));
            UpdateCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, thePayCategory.IsActive));
            UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            UpdateCommand.CommandText = "pHRM_PayCategories_Update";

            ExecuteStoredProcedure(UpdateCommand);
            ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int DeletePayCategory(PayCategory thePayCategory)
        {
            int ReturnValue = 0;

            SqlCommand DeleteCommand = new SqlCommand();

            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            DeleteCommand.Parameters.Add(GetParameter("@PayCategoryID", SqlDbType.Int, thePayCategory.PayCategoryID));
            DeleteCommand.CommandText = "pHRM_PayCategories_Delete";

            ExecuteStoredProcedure(DeleteCommand);
            ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        #endregion

        #region Data Retrive Mathods

        public DataTable GetPayCategories(string searchText)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
            SelectCommand.CommandText = "pHRM_PayCategories_SelectAll";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataRow GetPayCategoryById(int recordId)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@PayCategoryID", SqlDbType.Int, recordId));
            SelectCommand.CommandText = "pHRM_PayCategories_SelectByPayCategoryID";

            return ExecuteGetDataRow(SelectCommand);
        }

        #endregion
    }
}
