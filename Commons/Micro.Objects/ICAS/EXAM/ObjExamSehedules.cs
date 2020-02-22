using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.EXAM
{
    [Serializable]
    public class ObjExamSehedules
    {
        public int ExamScheduleID
        {
            get;
            set;
        }
        public string ExamScheduleName
        {
            get;
            set;
        }
        public int ExamID
        {
            get;
            set;
        }
        public int StreamID
        {
            get;
            set;
        }
        public int QualID
        {
            get;
            set;
        }
        public int ClassID
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public int FullMark
        {
            get;
            set;
        }
        public int PassMark
        {
            get;
            set;
        }       
        public string ExamDate
        {
            get;
            set;
        }
        public string StartTime
        {
            get;
            set;
        }

        public string CloseTime
        {
            get;
            set;
        }

        public int InvisilatorUserID
        {
            get;
            set;
        }
        public int RoomNo
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
