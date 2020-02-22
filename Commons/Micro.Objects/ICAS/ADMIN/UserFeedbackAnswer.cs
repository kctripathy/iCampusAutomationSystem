using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.ADMIN
{
     public class UserFeedbackAnswer
    {
        public int UserFeedbackAnswerID
        {
            get;
            set;
        }
        public int AskedQuestionId
        {
            get;
            set;
        }

        public int UserAnswerValue
        {
            get;
            set;
        }

    }
}

