using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STUDENT
{
    
    [Serializable]
    public class StudentSection
    {
        public int SectionGroupID
        {
            get;
            set;
        }
        public int CourseID
        {
            get;
            set;
        }
        public int StreamID
        {
            get;
            set;
        }
        public int ClassID
        {
            get;
            set;
        }        
        public string StudentIDS
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
        public int SectionID
        {
            get;
            set;
        }
        public string SectionName
        {
            get;
            set;
        }        
        public string Comment
        {
            get;
            set;
        }
        public int SessionID
        {
            get;
            set;
        }

        //for listing the studentIDS
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
        public string ROLLNo
        {
            get;
            set;
        }
        public int QualID
        {
            get;
            set;
        }
        //end listing
    
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
