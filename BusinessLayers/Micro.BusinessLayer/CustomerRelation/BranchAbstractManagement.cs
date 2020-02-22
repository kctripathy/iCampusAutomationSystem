using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class BranchAbstractManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static BranchAbstractManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static BranchAbstractManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BranchAbstractManagement();
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

        #region Methods & Implementation
        public List<BranchAbstract> BranchAbstractList(string DateOfTransaction)
        {
            return BranchAbstractIntegration.BranchAbstractList(DateOfTransaction);
        }
        #endregion
    }
}
