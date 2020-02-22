using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.IntegrationLayer.ICAS.EXAM;
using Micro.Objects.ICAS.EXAM;

namespace Micro.BusinessLayer.ICAS.EXAM
{
    public class ExamScheduleManagement
    {
        #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ExamScheduleManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ExamScheduleManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExamScheduleManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion
        
        public string DisplayMember = "ExamScheduleName";
        public string ValueMember = "ExamScheduleID";

        public string StudentMember = "StudentName";
        public string StudentValueMember = "StudentID";

        public int InsertSchedules(ObjExamSehedules theSehedules)
        {
            return ExamScheduleIntegration.InsertExamSedhule(theSehedules);
        }
        public int UpdateSchedules(ObjExamSehedules theSehedules)
        {
            return ExamScheduleIntegration.UpdateExamSedhule(theSehedules);
        }
        public int DeleteSchedules(ObjExamSehedules theSehedules)
        {
            return ExamScheduleIntegration.DeleteExamSedhule(theSehedules);
        }
        public List<ObjExamSehedules> GetExamSeduleList()
        {
            return ExamScheduleIntegration.GetExamSeduleList();
        }
        public List<ExamSecludeStudentList> GetSeduleStudentList(int SecludeID ,bool alloffices , bool showDeleted)
        {
            return ExamScheduleIntegration.GetSeduleStudentList(SecludeID,false,false);
        }
       
    }
}
