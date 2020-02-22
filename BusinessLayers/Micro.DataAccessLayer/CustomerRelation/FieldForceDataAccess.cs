using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class FieldForceDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static FieldForceDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static FieldForceDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FieldForceDataAccess();
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
        public DataTable GetFieldForceList(bool allOffices = false, bool showDeleted = false)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
				SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pCRM_FieldForces_SelectAll";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable GetFieldForceListByOfficeID(int OfficeID ,bool allOffices = false, bool showDeleted = false)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
				SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
				SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, OfficeID));
				SelectCommand.CommandText = "pCRM_FieldForces_SelectAll";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataRow GetFieldForceById(int fieldForceID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, fieldForceID));
				SelectCommand.CommandText = "pCRM_FieldForces_SelectByFieldForceID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

        public DataRow GetFieldForceByCode(string fieldForceCode)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@fieldForceCode", SqlDbType.VarChar, fieldForceCode));
                SelectCommand.CommandText = "pCRM_FieldForces_SelectByFieldForceCode";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataTable GetFieldForceByFieldForceRankID(int fieldForceRankID = 0, bool allOffices = false)
        {
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@FieldForceRankID", SqlDbType.Int, fieldForceRankID));
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
				SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pCRM_FieldForces_SelectByFieldForceRankID";

				return ExecuteGetDataTable(SelectCommand);
			}
        }

		public DataTable GetFieldForceChainByFieldForceID(int fieldForceID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, fieldForceID));
				SelectCommand.CommandText = "pCRM_FieldForces_SelectChainByFieldForceID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

        public DataRow GetAverageCommissionByFieldForceId(int fieldForceID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, fieldForceID));
                SelectCommand.CommandText = "pCRM_FieldForces_AverageCommissionByFieldForceID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }  

        public int InsertFieldForce(FieldForce theFieldForce, FieldForceProfile thePhoto, FieldForceProfile theSignature)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@FieldForceRankID", SqlDbType.Int, theFieldForce.FieldForceRankID));
                InsertCommand.Parameters.Add(GetParameter("@FieldForceRankDescription", SqlDbType.VarChar, theFieldForce.FieldForceRankDescription));
                InsertCommand.Parameters.Add(GetParameter("@ReportingToFieldForceID", SqlDbType.Int, theFieldForce.ReportingToFieldForceID));
                InsertCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theFieldForce.Salutation));
                InsertCommand.Parameters.Add(GetParameter("@FieldForceName", SqlDbType.VarChar, theFieldForce.FieldForceName));
                InsertCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theFieldForce.FatherName));
                InsertCommand.Parameters.Add(GetParameter("@HusbandName", SqlDbType.VarChar, theFieldForce.HusbandName));
                InsertCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theFieldForce.Gender));
                InsertCommand.Parameters.Add(GetParameter("@MaritalStatus", SqlDbType.VarChar, theFieldForce.MaritalStatus));
                InsertCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.VarChar, theFieldForce.DateOfBirth));
                InsertCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theFieldForce.Age));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theFieldForce.Address_Present_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theFieldForce.Address_Present_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theFieldForce.Address_Present_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theFieldForce.Address_Present_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theFieldForce.Address_Permanent_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theFieldForce.Address_Permanent_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theFieldForce.Address_Permanent_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theFieldForce.Address_Permanent_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theFieldForce.PhoneNumber));
                InsertCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theFieldForce.Mobile));
                InsertCommand.Parameters.Add(GetParameter("@EMailID", SqlDbType.VarChar, theFieldForce.EMailID));
                InsertCommand.Parameters.Add(GetParameter("@FieldForce_Qualification", SqlDbType.VarChar, theFieldForce.FieldForce_Qualification));
                InsertCommand.Parameters.Add(GetParameter("@Occupation", SqlDbType.VarChar, theFieldForce.Occupation));
                InsertCommand.Parameters.Add(GetParameter("@Nationality", SqlDbType.VarChar, theFieldForce.Nationality));
                InsertCommand.Parameters.Add(GetParameter("@Religion", SqlDbType.VarChar, theFieldForce.Religion));
                InsertCommand.Parameters.Add(GetParameter("@Caste", SqlDbType.VarChar, theFieldForce.Caste));
                InsertCommand.Parameters.Add(GetParameter("@NomineeName", SqlDbType.VarChar, theFieldForce.NomineeName));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_TownOrCity", SqlDbType.VarChar, theFieldForce.Nominee_Permanent_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_Landmark", SqlDbType.VarChar, theFieldForce.Nominee_Permanent_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_PinCode", SqlDbType.VarChar, theFieldForce.Nominee_Permanent_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_DistrictID", SqlDbType.Int, theFieldForce.Nominee_Permanent_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@NomineeRelationship", SqlDbType.VarChar, theFieldForce.NomineeRelationship));
                InsertCommand.Parameters.Add(GetParameter("@NomineeAge", SqlDbType.Int, theFieldForce.NomineeAge));
                InsertCommand.Parameters.Add(GetParameter("@IsNomineeACoWorker", SqlDbType.Bit, theFieldForce.IsNomineeACoWorker));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Qualification", SqlDbType.VarChar, theFieldForce.Nominee_Qualification));
                InsertCommand.Parameters.Add(GetParameter("@BankBranchID", SqlDbType.Int, theFieldForce.BankBranchID));
                InsertCommand.Parameters.Add(GetParameter("@BankAccountNumber", SqlDbType.VarChar, theFieldForce.BankAccountNumber));
                InsertCommand.Parameters.Add(GetParameter("@PhotoKeyName", SqlDbType.VarChar, thePhoto.SettingKeyName));
                InsertCommand.Parameters.Add(GetParameter("@PhotoKeyDescription", SqlDbType.VarChar, thePhoto.SettingKeyDescription));
                InsertCommand.Parameters.Add(GetParameter("@PhotoKeyValue", SqlDbType.VarBinary, thePhoto.SettingKeyValue));
                InsertCommand.Parameters.Add(GetParameter("@PhotoKeyReference", SqlDbType.VarChar, thePhoto.SettingKeyReference));
                InsertCommand.Parameters.Add(GetParameter("@SignatureKeyName", SqlDbType.VarChar, theSignature.SettingKeyName));
                InsertCommand.Parameters.Add(GetParameter("@SignatureKeyDescription", SqlDbType.VarChar, theSignature.SettingKeyDescription));
                InsertCommand.Parameters.Add(GetParameter("@SignatureKeyValue", SqlDbType.VarBinary, theSignature.SettingKeyValue));
                InsertCommand.Parameters.Add(GetParameter("@SignatureKeyReference", SqlDbType.VarChar, theSignature.SettingKeyReference));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_FieldForces_Insert";
                
                ExecuteStoredProcedure(InsertCommand);
                
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                
                return ReturnValue;
            }
        }

        public int UpdateFieldForce(FieldForce theFieldForce, FieldForceProfile thePhoto, FieldForceProfile theSignature)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, theFieldForce.FieldForceID));
                UpdateCommand.Parameters.Add(GetParameter("@FieldForceRankID", SqlDbType.Int, theFieldForce.FieldForceRankID));
                UpdateCommand.Parameters.Add(GetParameter("@FieldForceRankDescription", SqlDbType.VarChar, theFieldForce.FieldForceRankDescription));
                UpdateCommand.Parameters.Add(GetParameter("@ReportingToFieldForceID", SqlDbType.Int, theFieldForce.ReportingToFieldForceID));
                UpdateCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theFieldForce.Salutation));
                UpdateCommand.Parameters.Add(GetParameter("@FieldForceName", SqlDbType.VarChar, theFieldForce.FieldForceName));
                UpdateCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theFieldForce.FatherName));
                UpdateCommand.Parameters.Add(GetParameter("@HusbandName", SqlDbType.VarChar, theFieldForce.HusbandName));
                UpdateCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theFieldForce.Gender));
                UpdateCommand.Parameters.Add(GetParameter("@MaritalStatus", SqlDbType.VarChar, theFieldForce.MaritalStatus));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.VarChar, theFieldForce.DateOfBirth));
                UpdateCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theFieldForce.Age));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theFieldForce.Address_Present_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theFieldForce.Address_Present_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theFieldForce.Address_Present_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theFieldForce.Address_Present_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theFieldForce.Address_Permanent_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theFieldForce.Address_Permanent_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theFieldForce.Address_Permanent_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theFieldForce.Address_Permanent_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@PhoneNumber", SqlDbType.VarChar, theFieldForce.PhoneNumber));
                UpdateCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theFieldForce.Mobile));
                UpdateCommand.Parameters.Add(GetParameter("@EMailID", SqlDbType.VarChar, theFieldForce.EMailID));
                UpdateCommand.Parameters.Add(GetParameter("@FieldForce_Qualification", SqlDbType.VarChar, theFieldForce.FieldForce_Qualification));
                UpdateCommand.Parameters.Add(GetParameter("@Occupation", SqlDbType.VarChar, theFieldForce.Occupation));
                UpdateCommand.Parameters.Add(GetParameter("@Nationality", SqlDbType.VarChar, theFieldForce.Nationality));
                UpdateCommand.Parameters.Add(GetParameter("@Religion", SqlDbType.VarChar, theFieldForce.Religion));
                UpdateCommand.Parameters.Add(GetParameter("@Caste", SqlDbType.VarChar, theFieldForce.Caste));
                UpdateCommand.Parameters.Add(GetParameter("@NomineeName", SqlDbType.VarChar, theFieldForce.NomineeName));
                UpdateCommand.Parameters.Add(GetParameter("@Nominee_Permanent_TownOrCity", SqlDbType.VarChar, theFieldForce.Nominee_Permanent_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Nominee_Permanent_Landmark", SqlDbType.VarChar, theFieldForce.Nominee_Permanent_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Nominee_Permanent_PinCode", SqlDbType.VarChar, theFieldForce.Nominee_Permanent_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Nominee_Permanent_DistrictID", SqlDbType.Int, theFieldForce.Nominee_Permanent_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@NomineeRelationship", SqlDbType.VarChar, theFieldForce.NomineeRelationship));
                UpdateCommand.Parameters.Add(GetParameter("@NomineeAge", SqlDbType.Int, theFieldForce.NomineeAge));
                UpdateCommand.Parameters.Add(GetParameter("@IsNomineeACoWorker", SqlDbType.Bit, theFieldForce.IsNomineeACoWorker));
                UpdateCommand.Parameters.Add(GetParameter("@Nominee_Qualification", SqlDbType.VarChar, theFieldForce.Nominee_Qualification));
                UpdateCommand.Parameters.Add(GetParameter("@BankBranchID", SqlDbType.Int, theFieldForce.BankBranchID));
                UpdateCommand.Parameters.Add(GetParameter("@BankAccountNumber", SqlDbType.VarChar, theFieldForce.BankAccountNumber));
                UpdateCommand.Parameters.Add(GetParameter("@PhotoKeyName", SqlDbType.VarChar, thePhoto.SettingKeyName));
                UpdateCommand.Parameters.Add(GetParameter("@PhotoKeyDescription", SqlDbType.VarChar, thePhoto.SettingKeyDescription));
                UpdateCommand.Parameters.Add(GetParameter("@PhotoKeyValue", SqlDbType.VarBinary, thePhoto.SettingKeyValue));
                UpdateCommand.Parameters.Add(GetParameter("@PhotoKeyReference", SqlDbType.VarChar, thePhoto.SettingKeyReference));
                UpdateCommand.Parameters.Add(GetParameter("@SignatureKeyName", SqlDbType.VarChar, theSignature.SettingKeyName));
                UpdateCommand.Parameters.Add(GetParameter("@SignatureKeyDescription", SqlDbType.VarChar, theSignature.SettingKeyDescription));
                UpdateCommand.Parameters.Add(GetParameter("@SignatureKeyValue", SqlDbType.VarBinary, theSignature.SettingKeyValue));
                UpdateCommand.Parameters.Add(GetParameter("@SignatureKeyReference", SqlDbType.VarChar, theSignature.SettingKeyReference));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_FieldForces_Update";
               
                ExecuteStoredProcedure(UpdateCommand);
                
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
               
                return ReturnValue;
            }
        }

        public int DeleteFieldForce(FieldForce theFieldForce)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, theFieldForce.FieldForceID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pCRM_FieldForces_Delete";
                
                ExecuteStoredProcedure(DeleteCommand);
                
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                
                return ReturnValue;
            }
        }
        #endregion
    }
}
