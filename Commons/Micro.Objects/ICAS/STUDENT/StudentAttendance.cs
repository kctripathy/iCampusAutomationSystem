using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STUDENT
{
    
    [Serializable]
    public class StudentAttendance
    {
        public int AttenID
        {
            get;
            set;
        }
        public string StudentIDS
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
        public int StaffID
        {
            get;
            set;
        }
        public string EmployeeName
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
