using System;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class CRMScrollDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CRMScrollDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CRMScrollDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CRMScrollDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Methods & Implementation
        public DataTable GetCRMScrollList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_Scrolls_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

		public DataTable GetCRMScrollListByDate(DateTime scrollDate)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@ScrollDate", SqlDbType.DateTime, scrollDate));
				SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pCRM_Scrolls_SelectByScrollDate";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

        public DataRow GetCRMScrollByID(int scrollID)
        {
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@ScrollID", SqlDbType.Int, scrollID));
				SelectCommand.CommandText = "pCRM_Scrolls_SelectByScrollID";

				return ExecuteGetDataRow(SelectCommand);
			}
        }

        public DataRow GetLastCRMScrollByOfficeID()
        {
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pCRM_Scrolls_SelectLastScrollByOfficeID";

				return ExecuteGetDataRow(SelectCommand);
			}
        }

        public int InsertCRMScroll(CRMScroll theCRMScroll)
        {
            int ReturnValue = 0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@ScrollDate", SqlDbType.VarChar, theCRMScroll.ScrollDate));
				InsertCommand.Parameters.Add(GetParameter("@DepositorName", SqlDbType.VarChar, theCRMScroll.DepositorName));
				InsertCommand.Parameters.Add(GetParameter("@ScrollAmountPayable", SqlDbType.Decimal, theCRMScroll.ScrollAmountPayable));
				InsertCommand.Parameters.Add(GetParameter("@ScrollAmountPaid", SqlDbType.Decimal, theCRMScroll.ScrollAmountPaid));
				InsertCommand.Parameters.Add(GetParameter("@ScrollStatus", SqlDbType.VarChar, theCRMScroll.ScrollStatus));
				InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pCRM_Scrolls_Insert";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
        }

        public int UpdateCRMScroll(CRMScroll theCRMScroll)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@ScrollID", SqlDbType.Int, theCRMScroll.ScrollID));
                UpdateCommand.Parameters.Add(GetParameter("@DepositorName", SqlDbType.VarChar, theCRMScroll.DepositorName));
                UpdateCommand.Parameters.Add(GetParameter("@ScrollAmountPayable", SqlDbType.Decimal, theCRMScroll.ScrollAmountPayable));
                UpdateCommand.Parameters.Add(GetParameter("@ScrollAmountPaid", SqlDbType.Decimal, theCRMScroll.ScrollAmountPaid));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_Scrolls_Update";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

		public int UpdateCRMScrollStatus(int theCRMScrollID, decimal theCRMScrollAmountPaid, string theCRMScrollStatus)
		{
			int ReturnValue = 0;

			using(SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@ScrollID", SqlDbType.Int, theCRMScrollID));
				UpdateCommand.Parameters.Add(GetParameter("@ScrollAmountPaid", SqlDbType.Decimal, theCRMScrollAmountPaid));
				UpdateCommand.Parameters.Add(GetParameter("@ScrollStatus", SqlDbType.VarChar, theCRMScrollStatus));
				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				UpdateCommand.CommandText = "pCRM_Scrolls_UpdateScrollStatus";

				ExecuteStoredProcedure(UpdateCommand);

				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

        public int DeleteCRMScroll(CRMScroll theCRMScroll)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@ScrollID", SqlDbType.Int, theCRMScroll.ScrollID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pCRM_Scrolls_Delete";

                ExecuteStoredProcedure(DeleteCommand);

                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        #endregion
    }
}
