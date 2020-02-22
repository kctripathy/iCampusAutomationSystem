using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.ICAS.ADMIN;



namespace Micro.DataAccessLayer.ICAS.ADMIN
{
    public partial class FeedbackMasterDataAccess:AbstractData_SQLClient
    {

        #region Code to make this a Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static FeedbackMasterDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static FeedbackMasterDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FeedbackMasterDataAccess();
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

        #region Methods & Implementation for Question
        public DataTable GetFeedbackQuestionsList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //Micro.Commons.Connection.LoggedOnUser.OfficeID
                SelectCommand.CommandText = "pICAS_Questions_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertFeedbackQuestions(QuestionMasters theFeedbackMaster)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@QuestionCode", SqlDbType.VarChar, theFeedbackMaster.QuestionCode));
                InsertCommand.Parameters.Add(GetParameter("@QuestionTitle", SqlDbType.VarChar, theFeedbackMaster.QuestionTitle));
                InsertCommand.Parameters.Add(GetParameter("@QuestionDesc", SqlDbType.VarChar, theFeedbackMaster.QuestionDesc));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));
                InsertCommand.CommandText = "pICAS_Questions_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
            }
            return ReturnValue;
        }

        public int UpdateFeedbackQuestions(QuestionMasters theFeedbackMaster)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@QuestionID", SqlDbType.Int, theFeedbackMaster.QuestionID));
                UpdateCommand.Parameters.Add(GetParameter("@QuestionCode", SqlDbType.VarChar, theFeedbackMaster.QuestionCode));
                UpdateCommand.Parameters.Add(GetParameter("@QuestionTitle", SqlDbType.VarChar, theFeedbackMaster.QuestionTitle));
                UpdateCommand.Parameters.Add(GetParameter("@QuestionDesc", SqlDbType.VarChar, theFeedbackMaster.QuestionDesc));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));
                UpdateCommand.CommandText = "pICAS_Questions_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
            }
            return ReturnValue;
        }

        public int DeleteFeedbackQuestions(QuestionMasters theFeedbackMaster)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@QuestionID", SqlDbType.Int, theFeedbackMaster.QuestionID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));
                DeleteCommand.CommandText = "pICAS_Questions_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion

        #region Method & Implementation For Option

        public DataTable GetOptionsList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //Micro.Commons.Connection.LoggedOnUser.OfficeID
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "pICAS_QuestionOption_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertOptions(OptionMasters theOptionMaster)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@OptionCode", SqlDbType.VarChar, theOptionMaster.OptionCode));
                InsertCommand.Parameters.Add(GetParameter("@QuestionID", SqlDbType.Int, theOptionMaster.QuestionID));
                InsertCommand.Parameters.Add(GetParameter("@Option1", SqlDbType.VarChar, theOptionMaster.Option1));
                InsertCommand.Parameters.Add(GetParameter("@Option2", SqlDbType.VarChar, theOptionMaster.Option2));
                InsertCommand.Parameters.Add(GetParameter("@Option3", SqlDbType.VarChar, theOptionMaster.Option3));
                InsertCommand.Parameters.Add(GetParameter("@Option4", SqlDbType.VarChar, theOptionMaster.Option4));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));
                InsertCommand.CommandText = "pICAS_QuestionOption_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
            }
            return ReturnValue;
        }

        public int UpdateOptions(OptionMasters theOptionMaster)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@OptionID", SqlDbType.Int, theOptionMaster.OptionID));
                UpdateCommand.Parameters.Add(GetParameter("@QuestionID", SqlDbType.Int, theOptionMaster.QuestionID));
                UpdateCommand.Parameters.Add(GetParameter("@Option1", SqlDbType.VarChar, theOptionMaster.Option1));
                UpdateCommand.Parameters.Add(GetParameter("@Option2", SqlDbType.VarChar, theOptionMaster.Option2));
                UpdateCommand.Parameters.Add(GetParameter("@Option3", SqlDbType.VarChar, theOptionMaster.Option3));
                UpdateCommand.Parameters.Add(GetParameter("@Option4", SqlDbType.VarChar, theOptionMaster.Option4));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));
                UpdateCommand.CommandText = "pICAS_QuestionOption_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
            }
            return ReturnValue;
        }

        public int DeleteOptions(OptionMasters theOptionMaster)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@OptionID", SqlDbType.Int, theOptionMaster.OptionID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));
                DeleteCommand.CommandText = "pICAS_Question_Option_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion

        #region Method & Implementation For FeedBack

        public DataTable GetFeedBackList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //Micro.Commons.Connection.LoggedOnUser.OfficeID
                SelectCommand.CommandText = "pICAS_UserFeedbacks_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetFeedBackList(int userID, bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, 44)); //Micro.Commons.Connection.LoggedOnUser.OfficeID
                SelectCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, userID)); //Micro.Commons.Connection.LoggedOnUser.OfficeID
                SelectCommand.CommandText = "pICAS_UserFeedbacks_SelectAllByUserID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public int InsertFeedBack(string QuestionIDs,string OptionValues)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.Parameters.Add(GetParameter("@QuestionIDs", SqlDbType.VarChar, QuestionIDs));
                InsertCommand.Parameters.Add(GetParameter("@OptionValues", SqlDbType.VarChar, OptionValues));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));
                InsertCommand.CommandText = "pICAS_UserFeedbacks_Inserts";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            }
            return ReturnValue;
        }

        public int UpdateFeedBack(FeedBackMasters theFeedBackMasters)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 44));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));
                UpdateCommand.CommandText = "";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
            }
            return ReturnValue;
        }

        public int DeleteFeedBack(FeedBackMasters theFeedBackMasters)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@QuestionID", SqlDbType.Int, theFeedBackMasters.FeedbackID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));
                DeleteCommand.CommandText = "";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion

    }
}
