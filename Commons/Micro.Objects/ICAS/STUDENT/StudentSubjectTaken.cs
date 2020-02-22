using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STUDENT
{
    public class StudentSubjectTaken
    {
        public int StudentSubjectsTakenID
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
        public string SubjectType
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public string SubjectName
        {
            get;
            set;
        }
        public int SessionID
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
    }
}
