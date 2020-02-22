
namespace Micro.BusinessLayer.HumanResource
{
    public partial  class OfficeTimingManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static OfficeTimingManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static OfficeTimingManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new OfficeTimingManagement();
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
