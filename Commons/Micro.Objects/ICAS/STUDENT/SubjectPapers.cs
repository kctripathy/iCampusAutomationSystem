using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STUDENT
{
    [Serializable]
    public class SubjectPapers
    {
        public int SubjectPaperID
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public string SubjectPaperName
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
        public bool SubjectPracticalFlag
        {
            get;
            set;
        }
        public int SubjectPracticalMark
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
