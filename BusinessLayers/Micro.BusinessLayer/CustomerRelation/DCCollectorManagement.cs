using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial  class DCCollectorManagement
    {
        #region Declaration
        public string DefaultColumns = "DCCollectorCode, DCCollectorName, Phone, MaximumCollectionAmountAllowed, MaximumMinutesAllowed, MaximumTransactionsAllowed";
        public string DisplayMember = "DCCollectorName";
        public string ValueMember = "DCCollectorID";
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DCCollectorManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DCCollectorManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DCCollectorManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Methods & Implementation

        public List<DCCollector> GetDCCollectorList(bool allOffices = false, bool showDeleted = false)
        {
            return DCCollectorIntegration.GetDCCollectorList(allOffices,showDeleted);
        }

		public List<DCCollector> GetDuplicateDCCollectorList(string dccollectorName, string fatherName, string dateofBirth, bool allOffices = false, bool showDeleted = false)
		{
			return DCCollectorIntegration.GetDuplicateDCCollectorList(dccollectorName, fatherName, dateofBirth, allOffices, showDeleted);
		}

        public DCCollector GetDCCollectorsById(int DCCollectorID)
        {
            return DCCollectorIntegration.GetDCCollectorsById(DCCollectorID);
        }

        public int InsertDCCollector(DCCollector theDCCollector)
        {
            return DCCollectorIntegration.InsertDCCollector(theDCCollector);
        }

        public int UpdateDCCollector(DCCollector theDCCollector)
        {
            return DCCollectorIntegration.UpdateDCCollector(theDCCollector);
        }

        public int DeleteDCCollector(DCCollector theDCCollector)
        {
            return DCCollectorIntegration.DeleteDCCollector(theDCCollector);
        }

        #endregion

    }
}
