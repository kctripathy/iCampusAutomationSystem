using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.IntegrationLayer.ICAS.ADMIN;
using Micro.Objects.ICAS.ADMIN;
using System.Data;

namespace Micro.BusinessLayer.ICAS.ADMIN
{
    public class FeedbackMasterManagement
    {
        #region Code to make this a Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static FeedbackMasterManagement _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static FeedbackMasterManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FeedbackMasterManagement();
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

        #region Methods & Implementation For Question
        public List<QuestionMasters> GetFeedbackQuestionsList()
        {
            return FeedbackMasterIntegration.GetFeedbackQuestionsList();
        }

        public int InsertFeedbackQuestions(QuestionMasters theFeedbackMaster)
        {
            return FeedbackMasterIntegration.InsertFeedbackQuestions(theFeedbackMaster);
        }
        public int UpdateFeedbackQuestions(QuestionMasters theFeedbackMaster)
        {
            return FeedbackMasterIntegration.UpdateFeedbackQuestions(theFeedbackMaster);
        }
        public int DeleteFeedbackMaster(QuestionMasters theFeedbackMaster)
        {
            return FeedbackMasterIntegration.DeleteFeedbackQuestions(theFeedbackMaster);
        }

        #endregion

        #region Methods & Implementation For Option
        public List<OptionMasters> GetOptionMastersList()
        {
            return FeedbackMasterIntegration.GetOptionMastersList();
        }

        public int InsertOptions(OptionMasters theOptionMasters)
        {
            return FeedbackMasterIntegration.InsertOptions(theOptionMasters);
        }
        public int UpdateOptions(OptionMasters theOptionMasters)
        {
            return FeedbackMasterIntegration.UpdateOptions(theOptionMasters);
        }
        public int DeleteOptions(OptionMasters theOptionMasters)
        {
            return FeedbackMasterIntegration.DeleteOptions(theOptionMasters);
        }

        #endregion

        #region Methods & Implementation For FeedBack
        public List<FeedBackMasters> GetFeedBackMastersList()
        {
            return FeedbackMasterIntegration.GetFeedBackMastersList();
        }
        public List<FeedBackMasters> GetFeedBackMastersList(int userID)
        {
            return FeedbackMasterIntegration.GetFeedBackMastersList(userID);
        }
        public int InsertFeedBack(string QuestionIDs, string OptionValue)
        {
            return FeedbackMasterIntegration.InsertFeedBack(QuestionIDs,OptionValue);
        }

        public int UpdateFeedBack(FeedBackMasters theFeedBackMasters)
        {
            return FeedbackMasterIntegration.UpdateFeedBack(theFeedBackMasters);
        }

        public int DeleteFeedBack(FeedBackMasters theFeedBackMasters)
        {
            return FeedbackMasterIntegration.DeleteFeedBack(theFeedBackMasters);
        }

        #endregion


    }
}
