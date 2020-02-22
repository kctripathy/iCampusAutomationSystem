using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.IntegrationLayer.ICAS.STUDENT;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public class SubjectPaperManagement
    {
        
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static SubjectPaperManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static SubjectPaperManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SubjectPaperManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
      

        #region Declaration
        public string DisplayMember = "SubjectPaperName";
        public string ValueMember = "SubjectPaperID";
        #endregion

       
        public static List<SubjectPapers> GetPaperListBySubjectID(int PaperID, string searchText, bool showDeleted)
        {
            try
            {
                return SubjectPaperIntegration.GetPaperListBySubjectID(PaperID, searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
    }
}


 