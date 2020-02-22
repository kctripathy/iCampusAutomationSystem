using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.EXAM
{
    [Serializable]
    public class ExamResult
    {
        public int ExamID
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
        public string StudentCode
        {
            get;
            set;
        }
        public string StudentName
        {
            get;
            set;
        }
        public string ExamName
        {
            get;
            set;
        }
        public string ExamDate
        {
            get;
            set;
        }
        public string SubjectName
        {
            get;
            set;
        }
        
        public int SubjectFullMark
        {
            get;
            set;
        }
        public int SubjectPassMark
        {
            get;
            set;
        }
        public int MarksObtained
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
