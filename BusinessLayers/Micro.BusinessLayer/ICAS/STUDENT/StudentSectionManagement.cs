using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.IntegrationLayer.ICAS.STUDENT;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public class StudentSectionManagement
    {
         #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static StudentSectionManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StudentSectionManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentSectionManagement();
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
        public string DisplayMember = "ClassName";
        public string ValueMember = "ClassID";
        #region Methods & Implementation
        #endregion
        //public List<Streams> GetStreamList()
        //{
        //    return StreamIntegration.GetStreamList();
        //}

        public List<StudentSection> GetStudentListBySectionID(int SectionID)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return StudentSectionIntegration.GetStudentListBySectionID(SectionID);
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
        public List<StudentSection> GetSectionList(string searchText)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return StudentSectionIntegration.GetSectionList(searchText);
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
        public int InsertStudentSection(StudentSection theSection)
        {
            return StudentSectionIntegration.InsertStudentSection(theSection);
        }
        public int UpdateStudentSection(StudentSection theSection)
        {
            return StudentSectionIntegration.UpdateStudentSection(theSection);
        }
    }  
}
