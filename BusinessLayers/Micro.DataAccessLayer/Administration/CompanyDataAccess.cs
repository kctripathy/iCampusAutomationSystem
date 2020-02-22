using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
    public partial class CompanyDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static CompanyDataAccess instance = new CompanyDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static CompanyDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation
        public DataTable GetMicroCompanyList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pADM_Companies_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetCompanyByComapnyID(int CompanyID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, CompanyID));
                SelectCommand.CommandText = "pADM_Companies_SelectByCompanyID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataTable GetCompaniesByUserID(int UserID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, UserID));
                SelectCommand.CommandText = "pADM_Companies_SelectByUserID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertCompany(Company theMicroCompany)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;

                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@CompanyName", SqlDbType.VarChar, theMicroCompany.CompanyName));
				InsertCommand.Parameters.Add(GetParameter("@CompanyAliasName", SqlDbType.VarChar, theMicroCompany.CompanyAliasName));
				InsertCommand.Parameters.Add(GetParameter("@EstablishmentDate", SqlDbType.DateTime, theMicroCompany.EstablishmentDate));
                InsertCommand.Parameters.Add(GetParameter("@CompanyMailingName", SqlDbType.VarChar, theMicroCompany.CompanyMailingName));
                InsertCommand.Parameters.Add(GetParameter("@CompanyRegisteredOfficeID", SqlDbType.Int, theMicroCompany.CompanyRegisteredOfficeID));
                InsertCommand.Parameters.Add(GetParameter("@CompanyHeadOfficeID", SqlDbType.Int, theMicroCompany.CompanyHeadOfficeID));
                InsertCommand.Parameters.Add(GetParameter("@CompanyRegistrationNumber", SqlDbType.VarChar, theMicroCompany.CompanyRegistrationNumber));
                InsertCommand.Parameters.Add(GetParameter("@CompanyEPFRegistrationNumber", SqlDbType.VarChar, theMicroCompany.CompanyEPFRegistrationNumber));
                InsertCommand.Parameters.Add(GetParameter("@CompanyLogoBigSize", SqlDbType.VarBinary, theMicroCompany.CompanyLogoBigSize));
                InsertCommand.Parameters.Add(GetParameter("@CompanyLogoMediumSize", SqlDbType.VarBinary, theMicroCompany.CompanyLogoMediumSize));
                InsertCommand.Parameters.Add(GetParameter("@CompanyLogoSmallSize", SqlDbType.VarBinary, theMicroCompany.CompanyLogoSmallSize));
                InsertCommand.Parameters.Add(GetParameter("@CompanyLoginImage", SqlDbType.VarBinary, theMicroCompany.CompanyLoginImage));
                InsertCommand.Parameters.Add(GetParameter("@CompanyLoginLabelForeColor", SqlDbType.VarChar, theMicroCompany.CompanyLoginLabelForeColor));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pADM_Companies_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int UpdateCompany(Company theMicroCompany)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, theMicroCompany.CompanyID));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyName", SqlDbType.VarChar, theMicroCompany.CompanyName));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyCode", SqlDbType.VarChar, theMicroCompany.CompanyCode));
				UpdateCommand.Parameters.Add(GetParameter("@CompanyAliasName", SqlDbType.VarChar, theMicroCompany.CompanyAliasName));
				//UpdateCommand.Parameters.Add(GetParameter("@EstablishmentDate", SqlDbType.DateTime, theMicroCompany.EstablishmentDate));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyMailingName", SqlDbType.VarChar, theMicroCompany.CompanyMailingName));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyRegisteredOfficeID", SqlDbType.Int, theMicroCompany.CompanyRegisteredOfficeID));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyHeadOfficeID", SqlDbType.Int, theMicroCompany.CompanyHeadOfficeID));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyRegistrationNumber", SqlDbType.VarChar, theMicroCompany.CompanyRegistrationNumber));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyEPFRegistrationNumber", SqlDbType.VarChar, theMicroCompany.CompanyEPFRegistrationNumber));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyLogoBigSize", SqlDbType.VarBinary, theMicroCompany.CompanyLogoBigSize));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyLogoMediumSize", SqlDbType.VarBinary, theMicroCompany.CompanyLogoMediumSize));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyLogoSmallSize", SqlDbType.VarBinary, theMicroCompany.CompanyLogoSmallSize));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyLoginImage", SqlDbType.VarBinary, theMicroCompany.CompanyLoginImage));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyLoginLabelForeColor", SqlDbType.VarChar, theMicroCompany.CompanyLoginLabelForeColor));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pADM_Companies_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int DeleteCompany(Company theMicroCompany)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, theMicroCompany.CompanyID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pADM_Companies_Delete";

                ExecuteStoredProcedure(DeleteCommand);

                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        #endregion
    }
}
