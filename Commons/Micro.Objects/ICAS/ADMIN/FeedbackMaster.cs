using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.ADMIN
{
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
