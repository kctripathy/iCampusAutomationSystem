using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.EXAM;
using Micro.IntegrationLayer.ICAS.EXAM;

namespace Micro.BusinessLayer.ICAS.EXAM
{
    public partial class ExamResultManagement
    {
        #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ExamResultManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ExamResultManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExamResultManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        #endregion
        //public string DisplayMember = "ExamName";
        //public string ValueMember = "ExamID";
        #region Methods & Implementation
        #endregion
        public List<ExamResult> GetExamResultList(ExamResult ResultObj)
        {
            return ExamResultIntegration.GetExamsResultList(ResultObj);
        }              
    }

}
