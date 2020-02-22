using System.Collections.Generic;
using Micro.IntegrationLayer.HumanResource;
using Micro.Objects.HumanResource;

namespace Micro.BusinessLayer.HumanResource
{
    public partial class PayGradeManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PayGradeManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PayGradeManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PayGradeManagement();
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

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertPayGrade(PayGrade thePayGrade)
        {
            return PayGradeIntegration.InsertPayGrade(thePayGrade);
        }

        public int UpdatePayGrade(PayGrade thePayGrade)
        {
            return PayGradeIntegration.UpdatePayGrade(thePayGrade);
        }

        public int DeletePayGrade(PayGrade thePayGrade)
        {
            return PayGradeIntegration.DeletePayGrade(thePayGrade);
        }

        #endregion

        #region Data Retrive Mathods

        public List<PayGrade> GetPayGrades(string searchText)
        {
            return PayGradeIntegration.GetPayGrades(searchText);
        }

        public PayGrade GetPayGradeById(int recordId)
        {
            return PayGradeIntegration.GetPayGrdaeById(recordId);
        }

        #endregion

        #region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)
        #endregion
    }
}
