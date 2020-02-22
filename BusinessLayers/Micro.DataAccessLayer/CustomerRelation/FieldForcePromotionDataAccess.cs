using Micro.Objects.CustomerRelation;
using System.Data.SqlClient;
using System.Data;

namespace Micro.DataAccessLayer.CustomerRelation
{
   public partial  class FieldForcePromotionDataAccess:AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static FieldForcePromotionDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static FieldForcePromotionDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FieldForcePromotionDataAccess();
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

        public DataTable GetFieldForcePromotionList(string FromDate,string ToDate ,bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.Parameters.Add(GetParameter("@FromDate", SqlDbType.VarChar, FromDate));
                SelectCommand.Parameters.Add(GetParameter("@ToDate", SqlDbType.VarChar, ToDate));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "pCRM_FieldForcePromotions_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetFieldForcePromotionByID(int FieldForcePromotionID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@FieldForcePromotionID", SqlDbType.Int, FieldForcePromotionID));
                SelectCommand.CommandText = "pCRM_FieldForcePromotions_SelectByFieldForcePromotionID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertFieldForcePromotionProvisionalList(string FromDate, string ToDate, string OfficeIDs)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@FromDate", SqlDbType.VarChar, FromDate));
                InsertCommand.Parameters.Add(GetParameter("@ToDate", SqlDbType.VarChar, ToDate));
                InsertCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.VarChar, OfficeIDs));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_FieldForcePromotions_GenerateProvisionalList";

                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int InsertFieldForcePromote(string OfficeIDs,string DateFrom,string DateTo,int ApprovedBy )
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@DateFrom", SqlDbType.VarChar, DateFrom));
                InsertCommand.Parameters.Add(GetParameter("@DateTo", SqlDbType.VarChar, DateTo));
                InsertCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.VarChar, OfficeIDs));
                InsertCommand.Parameters.Add(GetParameter("@ApprovedBy", SqlDbType.Int, ApprovedBy));
                InsertCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_FieldForcePromotions_Promote";

                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            } 
        }

        public int RejectFieldForcePromote(FieldForcePromotion theFieldForcePromotion )
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@FieldForcePromotionID", SqlDbType.Int, theFieldForcePromotion.FieldForcePromotionID));
                UpdateCommand.Parameters.Add(GetParameter("@HasAccepted", SqlDbType.Bit, theFieldForcePromotion.HasAccepted));
                UpdateCommand.Parameters.Add(GetParameter("@RejectedBy", SqlDbType.Int, theFieldForcePromotion.RejectedBy));
                UpdateCommand.Parameters.Add(GetParameter("@ReasonOfRejection", SqlDbType.VarChar, theFieldForcePromotion.Remarks));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_FieldForcePromotions_Reject";

                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }


        #endregion
    }
}
