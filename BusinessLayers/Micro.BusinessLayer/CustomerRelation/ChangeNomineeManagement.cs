using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class ChangeNomineeManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ChangeNomineeManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ChangeNomineeManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChangeNomineeManagement();
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
        public string DefaultColumns = "CustomerNomineeID, CustomerAccountID, NomineeName";
        public string DisplayMember = "NomineeName";
        public string ValueMember = "CustomerNomineeID";
        #endregion

        #region Methods & Implementation
        public int InsertNomineeDetails(ChangeNominee theNominee)
        {
            return ChangeNomineeIntegration.InsertNomineeDetails(theNominee);
        }
        #endregion

    }
}
