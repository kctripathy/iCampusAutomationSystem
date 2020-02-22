using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
   public partial class BrokerageFeeStructureOfficeWiseManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static BrokerageFeeStructureOfficeWiseManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static BrokerageFeeStructureOfficeWiseManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BrokerageFeeStructureOfficeWiseManagement();
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
       public string DefaultColumn = "BrokerageType,PolicyName,PolicyTypeDescription,PolicyFromOrganization";
       public string DisplayMember = "BrokerageType";
       public string ValueMember = "BrokerageFeeStructureID";
        #endregion

        #region Methods & Implementation
       public List<BrokerageFeeStructureOfficeWise> GetBrokerageFeeStructureOfficeWise(int officeId)
       {
           return BrokerageFeeStructureOfficeWiseIntegration.GetBrokerageFeeStructureOfficeWise(officeId);
       }

       public List<BrokerageFeeStructureOfficeWise> GetBrokerageFeeStructureOfficeWiseList()
       {
           return BrokerageFeeStructureOfficeWiseIntegration.GetBrokerageFeeStructureOfficeWiseList();
       }

       public List<BrokerageFeeStructureOfficeWise> GetBrokerageFeeStructureSelectByOfficeID(bool ShowInOfficewise = false)
       {
           return BrokerageFeeStructureOfficeWiseIntegration.GetBrokerageFeeStructureSelectByOfficeID(ShowInOfficewise);
       }

       //public List<BrokerageFeeStructureOfficeWise> GetBrokerageFeeStructureOfficeWiseSelectByControllingOfficeID(string searchText)
       //{
       //    return BrokerageFeeStructureOfficeWiseIntegration.GetBrokerageFeeStructureOfficeWiseSelectByControllingOfficeID(searchText);
       //}

       public int UpdateBrokerageFeeStructureOfficeWise(List<BrokerageFeeStructureOfficeWise> theBrokerageFeeStructureOfficeWiseList)
       {
           return BrokerageFeeStructureOfficeWiseIntegration.UpdateBrokerageFeeStructureOfficeWise(theBrokerageFeeStructureOfficeWiseList);
       }
       public  int InsertBrokerageFeeStructureOfficeWise(string BrokerageFeeStructureIDs, string EffectiveDateFrom)
       {
           return BrokerageFeeStructureOfficeWiseIntegration.InsertBrokerageFeeStructureOfficeWise(BrokerageFeeStructureIDs, EffectiveDateFrom);
       }
       public  int DeleteBrokerageFeeStructureOfficeWise(string BrokerageFeeStructureIDs)
       {
           return BrokerageFeeStructureOfficeWiseIntegration.DeleteBrokerageFeeStructureOfficeWise(BrokerageFeeStructureIDs);
       }
       #endregion
    }
}
