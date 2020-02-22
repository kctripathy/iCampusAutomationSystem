using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
   public partial class ChangeIntroducerManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static ChangeIntroducerManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static ChangeIntroducerManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChangeIntroducerManagement();
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
       public int  InsertIntroducer(ChangeIntroducer theIntroducer)
       {
           return ChangeIntroducerIntegration.InsertIntroducer(theIntroducer);
       }
        #endregion
    }
}
