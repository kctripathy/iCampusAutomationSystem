using System;

namespace Micro.Objects
{
    [Serializable]
    public class Routine
    {
        public Routine(string formName)
        {
            FormName = formName;
        }

        public Routine(string formName, string methodName)
        {
            FormName = formName;
            MethodName = methodName;
        }

        public string FormName
        {
            get;
            set;
        }

        public string MethodName
        {
            get;
            set;
        }
    }
}
