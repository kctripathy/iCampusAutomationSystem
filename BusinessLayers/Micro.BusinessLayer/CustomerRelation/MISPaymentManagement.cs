using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class MISPaymentManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static MISPaymentManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static MISPaymentManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MISPaymentManagement();
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
        public string DefaultColumns = "CustomerName, MISFirstDueDate, MISLastDueDate, MISNumberFrom, MISNumberTo, MISPayable, MISPaymentDate, MISPaid";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "MISPaymentID";
        #endregion

        #region Methods & Implementations
        public List<MISPayment> GetMISInterestPaymentList(string searchText)
        {
            return MISPaymentIntegration.GetMISPaymentList(searchText);
        }

        public List<MISPayment> GetMISPaymentsByCustomerAccountID(int customerAccountID)
        {
            return MISPaymentIntegration.GetMISPaymentsByCustomerAccountID(customerAccountID);
        }

        /// <summary>
        /// MIS Last Due Date
        /// </summary>
        /// <param name="customerAccountID"></param>
        /// <returns></returns>
        public MISPayment GetLastMISInterestPayment(int customerAccountID)
        {
            return MISPaymentIntegration.GetLastMISPayment(customerAccountID);
        }

        public int InsertMISInterestPayments(MISPayment theMISPayment)
        {
            return MISPaymentIntegration.InsertMISPayment(theMISPayment);
        }
        #endregion
    }
}
