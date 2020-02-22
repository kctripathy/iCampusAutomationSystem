using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.EXAM
{
    [Serializable]
    public class ExamMark
    {
        public int Exam_Mark_ScheduleID
        {
            get;
            set;
        }
        public int ExamScheduleID
        {
            get;
            set;
        }
        public string StudentID
        {
            get;
            set;
        }
        public int MarksObtained
        {
            get;
            set;
        }
        public string VarifiedBy
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
