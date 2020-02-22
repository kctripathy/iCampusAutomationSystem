using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class MicroMenu
    {
        public int MenuID
        {
            get;
            set;
        }

        public string MenuItemName
        {
            get;
            set;
        }

        public string ShortCutKey
        {
            get;
            set;
        }

        public string ShortCutDisplayString
        {
            get;
            set;
        }
        
        public int ParentMenuID
        {
            get;
            set;
        }

        public int ModuleID
        {
            get;
            set;
        }

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
