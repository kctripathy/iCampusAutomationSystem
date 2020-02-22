using System;

namespace Micro.Objects.HumanResource
{
     [Serializable]
    public class PayComponent
    {
        public int PayComponentID
        {
            get;
            set;
        }

         public string PayComponentDescription
         {
            get;
            set;
         }

         public String PayComponentType
         {
             get;
             set;
         }

        public int DisplayOrder
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