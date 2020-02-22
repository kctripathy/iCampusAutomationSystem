using Micro.Objects.CustomerRelation;
using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class OneTimeCertificateDataAccess : AbstractData_SQLClient
    {
        #region Declaration
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static OneTimeCertificateDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static OneTimeCertificateDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new OneTimeCertificateDataAccess();
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

        public DataTable GetOneTimeCertificateList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "pCRM_OneTimeCertificates_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetOneTimeCertificatesByDate(string FromDate, string ToDate, bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@FromDate", SqlDbType.VarChar, FromDate));
                SelectCommand.Parameters.Add(GetParameter("@ToDate", SqlDbType.VarChar, ToDate));
                SelectCommand.Parameters.Add(GetParameter("@allOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "PCRM_OneTimeCertificates_SelectByDate";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
		public DataRow GetOneTimeCertificatesByOneTimeCertificateID(int OneTimeCertificateID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@OneTimeCertificateID", SqlDbType.Int, OneTimeCertificateID));
				SelectCommand.CommandText = "pCRM_OneTimeCertificates_SelectByOneTimeCertificateID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}
        public DataTable GetOneTimeCertificatesByFieldForceID(int FieldForceID, bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, FieldForceID));
                SelectCommand.Parameters.Add(GetParameter("@allOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));

                SelectCommand.CommandText = "PCRM_OneTimeCertificates_SelectByFieldForceID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertOneTimeCertificate(OneTimeCertificate theCertificate)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, theCertificate.CustomerAccountID));
                InsertCommand.Parameters.Add(GetParameter("@DatePrinted", SqlDbType.VarChar, theCertificate.DatePrinted));
				InsertCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_OneTimeCertificates_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int IssueOneTimeCertificate(OneTimeCertificate theCertificate,string OneTimeCertificateIDs)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@OneTimeCertificateIDs", SqlDbType.VarChar, OneTimeCertificateIDs));
                InsertCommand.Parameters.Add(GetParameter("@ReceivedBy", SqlDbType.VarChar, theCertificate.ReceivedBy));
                InsertCommand.Parameters.Add(GetParameter("@ReceivedOnDate", SqlDbType.VarChar, theCertificate.ReceivedOnDate));
                InsertCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_OneTimeCertificates_Issue";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int PrintDuplicateOneTimeCertificate(OneTimeCertificate theCertificate)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@OneTimeCertificateID", SqlDbType.Int, theCertificate.OneTimeCertificateID));
                InsertCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theCertificate.Remarks));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_OneTimeCertificatesPrintLog_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        #endregion
    }
}
