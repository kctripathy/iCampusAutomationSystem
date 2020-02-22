using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class CustomerDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CustomerDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CustomerDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerDataAccess();
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
        public DataTable GetCustomerList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_Customers_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }


        public DataTable GetCustomerListByOfficeIDs(bool allOffices, string officeIDs)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.VarChar, officeIDs));
                SelectCommand.CommandText = "pCRM_Customers_SelectByOfficeID";
                
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetCustomerListByCustomerLoans(bool allOffices, string officeIDs)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.VarChar, officeIDs));
                SelectCommand.CommandText = "pRPT_Customers_SelectByCustomerLoans";
                
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetCustomerMediclaimEligibilityList(bool allOffices = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_Customers_MediclaimEligibilityList";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetCustomerByID(int customerID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, customerID));
                SelectCommand.CommandText = "pCRM_Customers_SelectByCustomerID";
                
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertCustomer(Customer theCustomer)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theCustomer.Salutation));
                InsertCommand.Parameters.Add(GetParameter("@CustomerName", SqlDbType.VarChar, theCustomer.CustomerName));
                InsertCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theCustomer.FatherName));
                InsertCommand.Parameters.Add(GetParameter("@HusbandName", SqlDbType.VarChar, theCustomer.HusbandName));
                InsertCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theCustomer.Gender));
                InsertCommand.Parameters.Add(GetParameter("@MaritalStatus", SqlDbType.VarChar, theCustomer.MaritalStatus));
                InsertCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.VarChar, theCustomer.DateOfBirth));
                InsertCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theCustomer.Age));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theCustomer.Address_Present_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theCustomer.Address_Present_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theCustomer.Address_Present_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theCustomer.Address_Present_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theCustomer.Address_Permanent_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theCustomer.Address_Permanent_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theCustomer.Address_Permanent_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theCustomer.Address_Permanent_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theCustomer.PhoneNumber));
                InsertCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theCustomer.Mobile));
                InsertCommand.Parameters.Add(GetParameter("@EMailID", SqlDbType.VarChar, theCustomer.EMailID));
                InsertCommand.Parameters.Add(GetParameter("@Occupation", SqlDbType.VarChar, theCustomer.Occupation));
                InsertCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                InsertCommand.CommandText = "pCRM_Customers_Insert";
                
                ExecuteStoredProcedure(InsertCommand);
                
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                
                return ReturnValue;
            }
        }

        public int UpdateCustomer(Customer theCustomer)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, theCustomer.CustomerID));
                UpdateCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theCustomer.Salutation));
                UpdateCommand.Parameters.Add(GetParameter("@CustomerName", SqlDbType.VarChar, theCustomer.CustomerName));
                UpdateCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theCustomer.FatherName));
                UpdateCommand.Parameters.Add(GetParameter("@HusbandName", SqlDbType.VarChar, theCustomer.HusbandName));
                UpdateCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theCustomer.Gender));
                UpdateCommand.Parameters.Add(GetParameter("@MaritalStatus", SqlDbType.VarChar, theCustomer.MaritalStatus));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.VarChar, theCustomer.DateOfBirth));
                UpdateCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theCustomer.Age));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theCustomer.Address_Present_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theCustomer.Address_Present_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theCustomer.Address_Present_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theCustomer.Address_Present_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theCustomer.Address_Permanent_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theCustomer.Address_Permanent_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theCustomer.Address_Permanent_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theCustomer.Address_Permanent_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theCustomer.PhoneNumber));
                UpdateCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theCustomer.Mobile));
                UpdateCommand.Parameters.Add(GetParameter("@EMailID", SqlDbType.VarChar, theCustomer.EMailID));
                UpdateCommand.Parameters.Add(GetParameter("@Occupation", SqlDbType.VarChar, theCustomer.Occupation));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_Customers_Update";
                
                ExecuteStoredProcedure(UpdateCommand);
                
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                
                return ReturnValue;
            }
        }

        public int DeleteCustomer(Customer theCustomer)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, theCustomer.CustomerID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pCRM_Customers_Delete";
               
                ExecuteStoredProcedure(DeleteCommand);
                
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                
                return ReturnValue;
            }
        }
        #endregion
    }
}
