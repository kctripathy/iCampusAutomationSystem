
namespace Micro.DataAccessLayer.CustomerRelation
{
   public partial class ChangeFieldChainDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static ChangeFieldChainDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static ChangeFieldChainDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChangeFieldChainDataAccess();
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
        #endregion
    }
}
