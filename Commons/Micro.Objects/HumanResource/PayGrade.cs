using System;

namespace Micro.Objects.HumanResource
{
    [Serializable]
   public class PayGrade
    {
        public int PayGradeID
        {
            get;
            set;
        }

        public string PayGradeDescription
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
    }
}
