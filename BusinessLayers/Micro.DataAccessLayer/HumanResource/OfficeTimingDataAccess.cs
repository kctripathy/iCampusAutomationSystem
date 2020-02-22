
namespace Micro.DataAccessLayer.HumanResource
{
   public partial class OfficeTimingDataAccess:AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static OfficeTimingDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static OfficeTimingDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new OfficeTimingDataAccess();
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
        #endregion

        #region Data Retrive Mathods
        #endregion
    }
}
