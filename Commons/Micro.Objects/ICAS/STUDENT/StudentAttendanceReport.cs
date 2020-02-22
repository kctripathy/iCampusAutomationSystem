using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STUDENT
{
    
    [Serializable]
    public class StudentAttendanceReport
    {
        public int AttenID
        {
            get;
            set;
        }
        
        public string QualCode
        {
            get;
            set;
        }
        public string StreamName
        {
            get;
            set;
        }
        public string ClassName
        {
            get;
            set;
        }
        public int SectionID
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
        
        public string Date
        {
            get;
            set;
        }
        public string ClassStartTime
        {
            get;
            set;
        }
        public string ClassCloseTime
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
    
          
    }
}
