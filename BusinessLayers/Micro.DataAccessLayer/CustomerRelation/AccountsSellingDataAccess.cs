using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;
using System.Data;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class AccountsSellingDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountsSellingDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountsSellingDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountsSellingDataAccess();
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

        public int InsertSellingAccount(CustomerAccount theCustomerAccount)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, theCustomerAccount.CustomerAccountID));
                InsertCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, theCustomerAccount.CustomerID));
                InsertCommand.Parameters.Add(GetParameter("@IsJointApplication", SqlDbType.Bit, theCustomerAccount.IsJointApplication));
                InsertCommand.Parameters.Add(GetParameter("@ApplicationFormNumber", SqlDbType.VarChar, theCustomerAccount.ApplicationFormNumber));
                InsertCommand.Parameters.Add(GetParameter("@SecondApplicantName", SqlDbType.VarChar, theCustomerAccount.SecondApplicantName));
                InsertCommand.Parameters.Add(GetParameter("@SecondApplicantAge", SqlDbType.Int, theCustomerAccount.SecondApplicantAge));
                InsertCommand.Parameters.Add(GetParameter("@SecondApplicantSignature", SqlDbType.VarBinary, theCustomerAccount.SecondApplicantSignature));
                InsertCommand.Parameters.Add(GetParameter("@SecondApplicantPANGIR", SqlDbType.VarChar, theCustomerAccount.SecondApplicantPANGIR));
                InsertCommand.Parameters.Add(GetParameter("@ThirdApplicantName", SqlDbType.VarChar, theCustomerAccount.ThirdApplicantName));
                InsertCommand.Parameters.Add(GetParameter("@ThirdApplicantAge", SqlDbType.Int, theCustomerAccount.ThirdApplicantAge));
                InsertCommand.Parameters.Add(GetParameter("@ThirdApplicantSignature", SqlDbType.VarBinary, theCustomerAccount.ThirdApplicantSignature));
                InsertCommand.Parameters.Add(GetParameter("@ThirdApplicantPANGIR", SqlDbType.VarChar, theCustomerAccount.ThirdApplicantPANGIR));
                 InsertCommand.Parameters.Add(GetParameter("@NomineeName", SqlDbType.VarChar, theCustomerAccount.NomineeName));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_TownOrCity", SqlDbType.VarChar, theCustomerAccount.Nominee_Permanent_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_Landmark", SqlDbType.VarChar, theCustomerAccount.Nominee_Permanent_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_PinCode", SqlDbType.VarChar, theCustomerAccount.Nominee_Permanent_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_DistrictID", SqlDbType.Int, theCustomerAccount.Nominee_Permanent_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@NomineeRelationship", SqlDbType.VarChar, theCustomerAccount.NomineeRelationship));
               
                InsertCommand.Parameters.Add(GetParameter("@NomineeAge", SqlDbType.Int, theCustomerAccount.NomineeAge));
                InsertCommand.Parameters.Add(GetParameter("@SellingState", SqlDbType.Bit, theCustomerAccount.SellingState));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_CustomerAccountsSelling_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        #endregion
    }
}
