using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class ChangeNomineeDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ChangeNomineeDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ChangeNomineeDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChangeNomineeDataAccess();
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
        public int InsertNomineeDetails(ChangeNominee theNominee)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, theNominee.CustomerAccountID));
                InsertCommand.Parameters.Add(GetParameter("@NomineeName", SqlDbType.VarChar, theNominee.NomineeName));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_TownOrCity", SqlDbType.VarChar, theNominee.Nominee_Permanent_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_Landmark", SqlDbType.VarChar, theNominee.Nominee_Permanent_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_PinCode", SqlDbType.VarChar, theNominee.Nominee_Permanent_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Nominee_Permanent_DistrictID", SqlDbType.Int, theNominee.Nominee_Permanent_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@NomineeRelationship", SqlDbType.VarChar, theNominee.NomineeRelationship));
                InsertCommand.Parameters.Add(GetParameter("@NomineeAge", SqlDbType.Int, theNominee.NomineeAge));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_CustomerNominees_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        } 
        #endregion
    }
}
