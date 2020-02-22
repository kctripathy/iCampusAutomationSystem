using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STUDENT
{
    public class StudentPreviousQual
    { 
        public string QualName
        {
            get;
            set;
        }
        public string QualCode
        {
            get;
            set;
        }
        public string PassingYear
        {
            get;
            set;
        }
        public int PreQualID
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
        public int QualID
        {
            get;
            set;
        }
        public string Board
        {
            get;
            set;
        }
        public string Division
        {
            get;
            set;
        }
        public string Percentage
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
