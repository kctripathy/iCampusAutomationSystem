using Micro.Objects.CustomerRelation;
using System.Data.SqlClient;
using System.Data;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class ChangeIntroducerDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ChangeIntroducerDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ChangeIntroducerDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChangeIntroducerDataAccess();
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
        public int InsertIntroducer(ChangeIntroducer theIntroducer)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, theIntroducer.CustomerAccountID));
                InsertCommand.Parameters.Add(GetParameter("@NewFieldForceID", SqlDbType.Int, theIntroducer.NewFieldForceID));
                InsertCommand.Parameters.Add(GetParameter("@TodaysDate", SqlDbType.VarChar, theIntroducer.TodaysDate));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_ChangeIntroducers_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        #endregion
        

    }
}
