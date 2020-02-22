using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.EXAM;
using Micro.IntegrationLayer.ICAS.EXAM;

namespace Micro.BusinessLayer.ICAS.EXAM
{
    public partial class ExamManagement
    {
        #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ExamManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ExamManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExamManagement();
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
        public string DisplayMember = "ExamName";
        public string ValueMember = "ExamID";
        #region Methods & Implementation
        #endregion
        public List<Exams> GetExamsList()
        {
            return ExamIntegration.GetExamsList();
        }

        public List<Exams> GetRolesList(System.String searchText = null, bool showDeleted = false)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return ExamIntegration.GetExamsList();
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
        public static int InsertExam(Exams theExam)
        {
            return ExamIntegration.InsertExam(theExam);
        }
        public static int UpdateExam(Exams theExam)
        {
            return ExamIntegration.UpdateExam(theExam);
        }
        public static int DeleteExam(Exams theExam)
        {
            return ExamIntegration.DeleteExam(theExam);
        }


    }

}
