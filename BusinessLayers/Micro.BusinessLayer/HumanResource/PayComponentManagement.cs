using System.Collections.Generic;
using Micro.Objects.HumanResource;
using Micro.IntegrationLayer.HumanResource;

namespace Micro.BusinessLayer.HumanResource
{
    public partial class PayComponentManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PayComponentManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PayComponentManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PayComponentManagement();
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

        public int InsertPayComponent(PayComponent thePayComponent)
        {
            return PayComponentIntegration.InsertPayComponent(thePayComponent);
        }

        public int UpdatePayComponent(PayComponent thePayComponent)
        {
            return PayComponentIntegration.UpdatePayComponent(thePayComponent);
        }

        public int DeletePayComponent(PayComponent thePayComponent)
        {
            return PayComponentIntegration.DeletePayComponent(thePayComponent);
        }

        #endregion

        #region Data Retrive Mathods

        public List<PayComponent> GetPayComponents(string searchText)
        {
            return PayComponentIntegration.GetPayComponents(searchText);
        }

        public PayComponent GetPayComponentById(int recordId)
        {
            return PayComponentIntegration.GetPayComponentById(recordId);
        }

        #endregion

        #region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)
        #endregion
    }
}
