using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STUDENT
{
    public class SubjectTypes
    {
        public int SubjectTypeID 
        {
            get;
            set;
        }
        public string SubjectTypeName
        {
            get;
            set;
        }
        public int QualID 
        {
            get;
            set;
        }
        public string QualName
        {
              get;
              set;
        }
        public string StreamID
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
