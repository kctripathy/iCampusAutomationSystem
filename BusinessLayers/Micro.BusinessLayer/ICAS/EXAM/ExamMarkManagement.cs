using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.EXAM;
using Micro.IntegrationLayer.ICAS.EXAM;

namespace Micro.BusinessLayer.ICAS.EXAM
{
    public partial class ExamMarkManagement
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
        public string ValueMember = "StudentID";
        #region Methods & Implementation
        #endregion
        public static List<ExamMark> GetExamsMarkList()
        {
            return ExamMarkIntegration.GetExamsMarkList();
        }

        public List<ExamMark> GetRolesList(System.String searchText = null, bool showDeleted = false)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return ExamMarkIntegration.GetExamsMarkList();
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
        public static int InsertExamMarks(ExamMark theExamMark)
        {
            return ExamMarkIntegration.InsertExamMark(theExamMark);
        }
        public static int UpdateExamMarks(ExamMark theExamMark)
        {
            return ExamMarkIntegration.UpdateExamMark(theExamMark);
        }
        public static int DeleteExamMarks(ExamMark theExamMark)
        {
            return ExamMarkIntegration.DeleteExamMark(theExamMark);
        }
    }

}
