using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.EXAM
{   

        [Serializable]
        public class Exams
        {
            public int ExamID
            {
                get;
                set;
            }
            public string ExamName
            {
                get;
                set;
            }
            public int SessionID
            {
                get;
                set;
            }
            public int QualID
            {
                get;
                set;
            }
            public string DateOfStart
            {
                get;
                set;
            }
            public string DateOfClose
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

