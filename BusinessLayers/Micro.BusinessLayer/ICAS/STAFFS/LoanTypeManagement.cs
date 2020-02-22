using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using Micro.IntegrationLayer.ICAS.STAFFS;

namespace Micro.BusinessLayer.ICAS.STAFFS
{
   public partial class LoanTypeManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static LoanTypeManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static LoanTypeManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoanTypeManagement();
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
        public string DefaultColumns = "LoanTypeDescriptions";
        public string DisplayMember = "LoanTypeDescriptions";
        public string ValueMember = "LoanID";
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)



        #endregion

        #region Data Retrive Mathods
        public List<LoanType> GetLoanTypeList(bool allOffices = false, bool showDeleted = false)
        {
            return LoanTypeIntegration.GetLoanTypeList(allOffices,showDeleted);
        }

        #endregion
    

    }
}
