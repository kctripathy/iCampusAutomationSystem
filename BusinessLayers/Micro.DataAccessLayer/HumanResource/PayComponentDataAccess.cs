#region System Namespace
using System.Data;
using System.Data.SqlClient;
#endregion

#region Micro Namespaces
using Micro.Objects.HumanResource;
#endregion

namespace Micro.DataAccessLayer.HumanResource
{
    public partial class PayComponentDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PayComponentDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PayComponentDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PayComponentDataAccess();
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

        public int InsertPayComponent(PayComponent thePayComponent)
        {
            int ReturnValue = 0;

            SqlCommand InsertCommand = new SqlCommand();

            InsertCommand.CommandType = CommandType.StoredProcedure;
            InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            InsertCommand.Parameters.Add(GetParameter("@PayComponentDescription", SqlDbType.VarChar, thePayComponent.PayComponentDescription));
            InsertCommand.Parameters.Add(GetParameter("@PayComponentType", SqlDbType.VarChar, thePayComponent.PayComponentType));
            InsertCommand.Parameters.Add(GetParameter("@DisplayOrder", SqlDbType.Int, thePayComponent.DisplayOrder));

            InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            InsertCommand.CommandText = "pHRM_PayComponents_Insert";

            ExecuteStoredProcedure(InsertCommand);
            ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int UpdatePayCompenent(PayComponent thePayComponent)
        {
            int ReturnValue = 0;

            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            UpdateCommand.Parameters.Add(GetParameter("@PayComponentID", SqlDbType.Int, thePayComponent.PayComponentID));
            UpdateCommand.Parameters.Add(GetParameter("@PayComponentDescription", SqlDbType.VarChar, thePayComponent.PayComponentDescription));
            UpdateCommand.Parameters.Add(GetParameter("@PayComponentType", SqlDbType.VarChar, thePayComponent.PayComponentType));
            UpdateCommand.Parameters.Add(GetParameter("@DisplayOrder", SqlDbType.Int, thePayComponent.DisplayOrder));
            UpdateCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, thePayComponent.IsActive));
            UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            UpdateCommand.CommandText = "pHRM_PayComponents_Update";

            ExecuteStoredProcedure(UpdateCommand);
            ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int DeletePayCompenent(PayComponent thePayComponent)
        {
            int ReturnValue = 0;

            SqlCommand DeleteCommand = new SqlCommand();

            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            DeleteCommand.Parameters.Add(GetParameter("@PayComponentID", SqlDbType.Int, thePayComponent.PayComponentID));
            DeleteCommand.CommandText = "pHRM_PayComponents_Delete";

            ExecuteStoredProcedure(DeleteCommand);
            ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        #endregion

        #region Data Retrive Mathods

        public DataTable GetPayComponents(string searchText)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
            SelectCommand.CommandText = "pHRM_PayComponents_SelectAll";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataRow GetPayComponentById(int recordId)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@PayComponentID", SqlDbType.Int, recordId));
            SelectCommand.CommandText = "pHRM_PayComponents_SelectByPayComponentID";

            return ExecuteGetDataRow(SelectCommand);
        }

        #endregion
    }
}
