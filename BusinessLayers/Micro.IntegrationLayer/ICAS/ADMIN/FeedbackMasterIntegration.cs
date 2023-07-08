using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.ADMIN;
using Micro.DataAccessLayer.ICAS.ADMIN;
using Micro.Commons;
using System.Data;

namespace Micro.IntegrationLayer.ICAS.ADMIN
{
    public partial class FeedbackMasterIntegration
    {
        #region Declaration

        #endregion

        #region Methods & Implementation For Question
        public static QuestionMasters DataRowToObject(DataRow dr)
        {
            QuestionMasters TheFeedbackMaster = new QuestionMasters();

            TheFeedbackMaster.QuestionID = int.Parse(dr["QuestionID"].ToString());
            TheFeedbackMaster.QuestionTitle = dr["QuestionTitle"].ToString();
            TheFeedbackMaster.QuestionDesc = dr["QuestionDesc"].ToString();
            TheFeedbackMaster.OfficeID = int.Parse(dr["OfficeID"].ToString());
            TheFeedbackMaster.CompanyID = int.Parse(dr["CompanyID"].ToString());
            TheFeedbackMaster.AddedBy = int.Parse(dr["AddedBy"].ToString());
            TheFeedbackMaster.IsActive = bool.Parse(dr["IsActive"].ToString());
            TheFeedbackMaster.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());

            return TheFeedbackMaster;
        }

        public static FeedbackQuestion ConvertDataRowToObject(DataRow dr)
        {
            FeedbackQuestion TheFeedbackMaster = new FeedbackQuestion();

            //TheFeedbackMaster.QuestionID = int.Parse(dr["QuestionID"].ToString());
            //TheFeedbackMaster.QuestionTitle = dr["QuestionTitle"].ToString();
            //TheFeedbackMaster.QuestionDesc = dr["QuestionDesc"].ToString();

            //TheFeedbackMaster.Option1 = dr["Option1"].ToString();
            //TheFeedbackMaster.Option2 = dr["Option2"].ToString();
            //TheFeedbackMaster.Option3 = dr["Option3"].ToString();
            //TheFeedbackMaster.Option4 = dr["Option4"].ToString();

            //TheFeedbackMaster.IsActive = bool.Parse(dr["IsActive"].ToString());
            //TheFeedbackMaster.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());

            return TheFeedbackMaster;
        }

        public static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
        {
            DataTable dtUniqRecords = new DataTable();
            dtUniqRecords = dt.DefaultView.ToTable(true, Columns);
            return dtUniqRecords;
        }

        public static List<Feedback> GetFeedbackQuestions()
        {
            List<Feedback> feedbacksList = new List<Feedback>();
            DataTable FeedbackQuestionTable = FeedbackMasterDataAccess.GetInstance.GetFeedbackQuestionsAndOptions();

            string[] TobeDistinct = { "FeedbackId", "FeedbackDesc", "feedback_date_start", "feedback_date_end" };
            DataTable dtDistinct = GetDistinctRecords(FeedbackQuestionTable, TobeDistinct);


            foreach (DataRow dRow in dtDistinct.Rows)
            {
                Feedback f = new Feedback();
                f.FeedbackID = int.Parse(dRow["FeedbackId"].ToString());
                f.FeedbackDesc = dRow["FeedbackDesc"].ToString();
                f.FeedbackStartDate = DateTime.Parse(dRow["feedback_date_start"].ToString());
                f.FeedbackEndDate = DateTime.Parse(dRow["feedback_date_end"].ToString());
                f.FeedbackQuestions = GetFeedbackQuestionsList(f.FeedbackID, FeedbackQuestionTable);
                feedbacksList.Add(f);
            }
            return feedbacksList;
        }

        public static int SubmitFeedback(Dictionary<string, string> feedback)
        {
            return FeedbackMasterDataAccess.GetInstance.SubmitFeedback(feedback);
        }

        private static List<FeedbackQuestion> GetFeedbackQuestionsList(int feedbackId, DataTable feedbackQuestionTable)
        {
            List<FeedbackQuestion> FeedbackQuestionList = new List<FeedbackQuestion>();
            string[] TobeDistinct = { "FeedbackId", "QuestionId", "QuestionDesc" };
            DataTable dtDistinct = GetDistinctRecords(feedbackQuestionTable, TobeDistinct);
            foreach (DataRow dr in dtDistinct.Rows)
            {
                FeedbackQuestion f = new FeedbackQuestion();
                f.QuestionID = int.Parse(dr["QuestionID"].ToString());
                f.QuestionDesc = dr["QuestionDesc"].ToString();
                f.FeedbackQuestionOptions = GetOptions(f.QuestionID, feedbackQuestionTable);
                FeedbackQuestionList.Add(f);
            }
            return FeedbackQuestionList;
        }

        private static List<FeedbackQuestionOption> GetOptions(int questionID, DataTable feedbackQuestionTable)
        {
            List<FeedbackQuestionOption> feedbackQuestionOptions = new List<FeedbackQuestionOption>();
            foreach (DataRow dr in feedbackQuestionTable.Rows)
            {
                if (int.Parse(dr["QuestionID"].ToString()) == questionID)
                {
                    FeedbackQuestionOption f = new FeedbackQuestionOption();
                    f.OptionID = int.Parse(dr["OptionId"].ToString());
                    f.OptionDesc = dr["OptionDesc"].ToString();
                    feedbackQuestionOptions.Add(f);
                }
            }
            return feedbackQuestionOptions;
        }

        public static List<QuestionMasters> GetFeedbackQuestionsList()
        {
            List<QuestionMasters> FeedbackQuestionList = new List<QuestionMasters>();
            DataTable FeedbackQuestionTable = FeedbackMasterDataAccess.GetInstance.GetFeedbackQuestionsList();
            foreach (DataRow dr in FeedbackQuestionTable.Rows)
            {
                QuestionMasters TheFeedbackMaster = DataRowToObject(dr);
                FeedbackQuestionList.Add(TheFeedbackMaster);
            }
            return FeedbackQuestionList;

        }

        public static List<QuestionMasters> GetFeedbackQuestionAndOptions()
        {
            List<QuestionMasters> FeedbackQuestionList = new List<QuestionMasters>();
            DataTable FeedbackQuestionTable = FeedbackMasterDataAccess.GetInstance.GetFeedbackQuestionsList();
            foreach (DataRow dr in FeedbackQuestionTable.Rows)
            {
                QuestionMasters TheFeedbackMaster = DataRowToObject(dr);
                FeedbackQuestionList.Add(TheFeedbackMaster);
            }
            return FeedbackQuestionList;

        }

        public static int InsertFeedbackQuestions(QuestionMasters theFeedbackMaster)
        {
            return FeedbackMasterDataAccess.GetInstance.InsertFeedbackQuestions(theFeedbackMaster);
        }

        public static int UpdateFeedbackQuestions(QuestionMasters theFeedbackMaster)
        {
            return FeedbackMasterDataAccess.GetInstance.UpdateFeedbackQuestions(theFeedbackMaster);
        }

        public static int DeleteFeedbackQuestions(QuestionMasters theFeedbackMaster)
        {
            return FeedbackMasterDataAccess.GetInstance.DeleteFeedbackQuestions(theFeedbackMaster);
        }
        #endregion

        #region Methods & Implementation For Option

        public static OptionMasters DataRowToObjectOption(DataRow dr)
        {
            OptionMasters TheOptionMaster = new OptionMasters();

            TheOptionMaster.OptionID = int.Parse(dr["OptionID"].ToString());
            TheOptionMaster.OptionCode = dr["OptionCode"].ToString();
            TheOptionMaster.QuestionID = int.Parse(dr["QuestionID"].ToString());
            TheOptionMaster.QuestionDesc = dr["QuestionDesc"].ToString();
            TheOptionMaster.Option1 = dr["Option1"].ToString();
            TheOptionMaster.Option2 = dr["Option2"].ToString();
            TheOptionMaster.Option3 = dr["Option3"].ToString();
            TheOptionMaster.Option4 = dr["Option4"].ToString();
            TheOptionMaster.OfficeID = int.Parse(dr["OfficeID"].ToString());
            TheOptionMaster.CompanyID = int.Parse(dr["CompanyID"].ToString());
            TheOptionMaster.AddedBy = int.Parse(dr["AddedBy"].ToString());
            TheOptionMaster.IsActive = bool.Parse(dr["IsActive"].ToString());
            TheOptionMaster.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());


            return TheOptionMaster;
        }

        public static List<OptionMasters> GetOptionMastersList()
        {
            List<OptionMasters> OptionMastersList = new List<OptionMasters>();
            DataTable OptionMastersTable = FeedbackMasterDataAccess.GetInstance.GetOptionsList();
            foreach (DataRow dr in OptionMastersTable.Rows)
            {
                OptionMasters TheOptionMaster = DataRowToObjectOption(dr);
                OptionMastersList.Add(TheOptionMaster);
            }
            return OptionMastersList;

        }

        public static int InsertOptions(OptionMasters theOptionMaster)
        {
            return FeedbackMasterDataAccess.GetInstance.InsertOptions(theOptionMaster);
        }

        public static int UpdateOptions(OptionMasters theOptionMaster)
        {
            return FeedbackMasterDataAccess.GetInstance.UpdateOptions(theOptionMaster);
        }

        public static int DeleteOptions(OptionMasters theOptionMaster)
        {
            return FeedbackMasterDataAccess.GetInstance.DeleteOptions(theOptionMaster);
        }
        #endregion

        #region Methods & Implementation For FeedBack

        public static FeedBackMasters DataRowToObjectFeedBack(DataRow dr)
        {
            FeedBackMasters TheFeedBackMasters = new FeedBackMasters();

            TheFeedBackMasters.FeedbackID = int.Parse(dr["FeedbackID"].ToString());
            TheFeedBackMasters.QuestionID = int.Parse(dr["QuestionID"].ToString());
            TheFeedBackMasters.OptionValue = dr["OptionValue"].ToString();
            TheFeedBackMasters.QuestionTitle = dr["QuestionTitle"].ToString();
            TheFeedBackMasters.QuestionDesc = dr["QuestionDesc"].ToString();
            TheFeedBackMasters.UserID = int.Parse(dr["UserID"].ToString());
            TheFeedBackMasters.OfficeID = int.Parse(dr["OfficeID"].ToString());
            TheFeedBackMasters.AddedBy = int.Parse(dr["AddedBy"].ToString());
            TheFeedBackMasters.IsActive = bool.Parse(dr["IsActive"].ToString());
            TheFeedBackMasters.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());

            return TheFeedBackMasters;
        }

        public static List<FeedBackMasters> GetFeedBackMastersList()
        {
            List<FeedBackMasters> FeedBackMastersList = new List<FeedBackMasters>();
            DataTable FeedBackMastersTable = FeedbackMasterDataAccess.GetInstance.GetFeedBackList();
            foreach (DataRow dr in FeedBackMastersTable.Rows)
            {
                FeedBackMasters TheFeedbackMaster = DataRowToObjectFeedBack(dr);
                FeedBackMastersList.Add(TheFeedbackMaster);
            }
            return FeedBackMastersList;

        }
        public static List<FeedBackMasters> GetFeedBackMastersList(int userID)
        {
            List<FeedBackMasters> FeedBackMastersList = new List<FeedBackMasters>();
            DataTable FeedBackMastersTable = FeedbackMasterDataAccess.GetInstance.GetFeedBackList(userID);
            foreach (DataRow dr in FeedBackMastersTable.Rows)
            {
                FeedBackMasters TheFeedbackMaster = DataRowToObjectFeedBack(dr);
                FeedBackMastersList.Add(TheFeedbackMaster);
            }
            return FeedBackMastersList;

        }
        public static int InsertFeedBack(string QuestionIDs, string OptionValue)
        {
            return FeedbackMasterDataAccess.GetInstance.InsertFeedBack(QuestionIDs, OptionValue);
        }

        public static int UpdateFeedBack(FeedBackMasters theFeedBackMaster)
        {
            return FeedbackMasterDataAccess.GetInstance.UpdateFeedBack(theFeedBackMaster);
        }

        public static int DeleteFeedBack(FeedBackMasters theFeedBackMaster)
        {
            return FeedbackMasterDataAccess.GetInstance.DeleteFeedBack(theFeedBackMaster);
        }
        #endregion

    }
}
