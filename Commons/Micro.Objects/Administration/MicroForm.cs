using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class MicroForm
    {
        public int FormID
        {
            get;
            set;
        }

        public string FormName
        {
            get;
            set;
        }

        public string ActualFormName
        {
            get;
            set;
        }

        public string ActualFormClassName
        {
            get;
            set;
        }

        public int ModuleID
        {
            get;
            set;
        }

		public string ModuleName
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
