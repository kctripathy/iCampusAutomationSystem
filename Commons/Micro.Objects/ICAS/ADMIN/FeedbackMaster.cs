using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.ADMIN
{

    #region FOR API

    public class Feedback
    {
        public int FeedbackID
        {
            get;
            set;
        }

        public string FeedbackDesc
        {
            get;
            set;
        }

        public DateTime FeedbackStartDate
        {
            get;
            set;
        }

        public DateTime FeedbackEndDate
        {
            get;
            set;
        }

        public List<FeedbackQuestion> FeedbackQuestions
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        } = true;

        public int IsOpen
        {
            get;
            set;
        } 
    }

    public class FeedbackMasterAddViewModel
    {
        public string FeedbackDesc
        {
            get;
            set;
        }

        public DateTime FeedbackStartDate
        {
            get;
            set;
        }

        public DateTime FeedbackEndDate
        {
            get;
            set;
        }
    }


    public class FeedbackQuestion
    {
        public int QuestionID
        {
            get;
            set;
        }

        public string QuestionDesc
        {
            get;
            set;
        }

        public List<FeedbackQuestionOption> FeedbackQuestionOptions
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        } = true;
    }

    public class FeedbackQuestionOption
    {
        public int OptionID
        {
            get;
            set;
        }

        public string OptionDesc
        {
            get;
            set;
        }
    }


    public class StudentWhoSubmittedFeedback
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string roll_no { get; set; }
        public DateTime feedback_submit_date { get; set; }
    }

    public class StudentFeedbackAnswer
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int question_id { get; set; }
        public string question { get; set; }
        public int option_id { get; set; }
        public string option { get; set; }
    }

    public class FeedbackQuestionInput {
        public int feedback_id { get; set; }
        public string question { get; set; }
        public List<FeedbackQuestionInputOption> options { get; set; }
    }

    public class FeedbackQuestionInputOption
    {
        public string option { get; set; }
    }
    #endregion


    [Serializable]
    public class QuestionMasters
    {
        public int QuestionID
        {
            get;
            set;
        }
        public string QuestionCode
        {
            get;
            set;
        }
        public string QuestionTitle
        {
            get;
            set;
        }
        public string QuestionDesc
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }
        public string DateAdded
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }
    }

    public class Question
    {
        public int QuestionID
        {
            get;
            set;
        }
        public string QuestionCode
        {
            get;
            set;
        }
        public string QuestionTitle
        {
            get;
            set;
        }
        public string QuestionDesc
        {
            get;
            set;
        }

        public Option options { get; set; }
    }

    public class Option
    {
        public int OptionID
        {
            get;
            set;
        }
        public string OptionCode
        {
            get;
            set;
        }
        public int QuestionID
        {
            get;
            set;
        }
        public string QuestionDesc
        {
            get;
            set;
        }

        public string Option1
        {
            get;
            set;
        }
        public string Option2
        {
            get;
            set;
        }
        public string Option3
        {
            get;
            set;
        }
        public string Option4
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }
        public string DateAdded
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }
    }


    public class OptionMasters
    {
        public int OptionID
        {
            get;
            set;
        }
        public string OptionCode
        {
            get;
            set;
        }
        public int QuestionID
        {
            get;
            set;
        }
        public string QuestionDesc
        {
            get;
            set;
        }

        public string Option1
        {
            get;
            set;
        }
        public string Option2
        {
            get;
            set;
        }
        public string Option3
        {
            get;
            set;
        }
        public string Option4
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }
        public string DateAdded
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }
    }

    public class FeedBackMasters
    {
        public int FeedbackID
        {
            get;
            set;
        }
        public string FeedBackCode
        {
            get;
            set;
        }
        public string OptionValue
        {
            get;
            set;
        }
        public int QuestionID
        {
            get;
            set;
        }
        public string QuestionTitle
        {
            get;
            set;
        }
        public string QuestionDesc
        {
            get;
            set;
        }
        public int OptionID
        {
            get;
            set;
        }
        public int UserID
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }
        public string DateAdded
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }
    }
}
