using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
    public partial class GuestDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static GuestDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static GuestDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GuestDataAccess();
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
        public DataTable GetGuestList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pADM_Guests_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetGuestByID(int GuestID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@GuestID", SqlDbType.Int, GuestID));
                SelectCommand.CommandText = "pADM_Guests_SelectByGuestID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataRow GetGuestByCode(string GuestCode)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@GuestCode", SqlDbType.VarChar, GuestCode));
                SelectCommand.CommandText = "pADM_Guests_SelectByGuestCode";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertGuest(Guest theGuest)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theGuest.Salutation));
                InsertCommand.Parameters.Add(GetParameter("@GuestName", SqlDbType.VarChar, theGuest.GuestName));
                InsertCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theGuest.Age));
                InsertCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theGuest.Gender));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theGuest.Address_Present_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theGuest.Address_Present_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theGuest.Address_Present_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theGuest.Address_Present_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theGuest.PhoneNumber));
                InsertCommand.Parameters.Add(GetParameter("@MobileNumber", SqlDbType.VarChar, theGuest.MobileNumber));
                InsertCommand.Parameters.Add(GetParameter("@OfficialEMailID", SqlDbType.VarChar, theGuest.OfficialEMailID));
                InsertCommand.Parameters.Add(GetParameter("@PersonalEMailID", SqlDbType.VarChar, theGuest.PersonalEMailID));
                InsertCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theGuest.Remarks));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pADM_Guests_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

		public int InsertLoginGuest(Guest theGuest,int CompanyID)
		{
			int ReturnValue = 0;

			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@GuestName", SqlDbType.VarChar, theGuest.GuestName));
				InsertCommand.Parameters.Add(GetParameter("@MobileNumber", SqlDbType.VarChar, theGuest.MobileNumber));
				InsertCommand.Parameters.Add(GetParameter("@PersonalEMailID", SqlDbType.VarChar, theGuest.PersonalEMailID));
				InsertCommand.Parameters.Add(GetParameter("CompanyID", SqlDbType.Int, CompanyID));
				InsertCommand.CommandText = "pADM_Login_Guests_Insert";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

        public int UpdateGuest(Guest theGuest)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@GuestID", SqlDbType.Int, theGuest.GuestID));
                UpdateCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theGuest.Salutation));
                UpdateCommand.Parameters.Add(GetParameter("@GuestName", SqlDbType.VarChar, theGuest.GuestName));
                UpdateCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theGuest.Age));
                UpdateCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theGuest.Gender));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theGuest.Address_Present_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theGuest.Address_Present_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theGuest.Address_Present_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theGuest.Address_Present_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theGuest.PhoneNumber));
                UpdateCommand.Parameters.Add(GetParameter("@MobileNumber", SqlDbType.VarChar, theGuest.MobileNumber));
                UpdateCommand.Parameters.Add(GetParameter("@OfficialEMailID", SqlDbType.VarChar, theGuest.OfficialEMailID));
                UpdateCommand.Parameters.Add(GetParameter("@PersonalEMailID", SqlDbType.VarChar, theGuest.PersonalEMailID));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                UpdateCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theGuest.Remarks));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pADM_Guests_Update";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int DeleteGuest(Guest theGuest)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@GuestID", SqlDbType.Int, theGuest.GuestID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pADM_Guests_Delete";

                ExecuteStoredProcedure(DeleteCommand);

                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        #endregion

    }
}
