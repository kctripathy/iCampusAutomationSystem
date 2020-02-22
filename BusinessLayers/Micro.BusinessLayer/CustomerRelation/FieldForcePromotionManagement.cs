using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
   public  class FieldForcePromotionManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static FieldForcePromotionManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static FieldForcePromotionManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FieldForcePromotionManagement();
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

        public string DefaultColumns = "FieldForceName,FieldForceCode,BusinessFromDate,BusinessToDate,ExistingRankDescription,PromotedToRankDescription";
        public string DisplayMember = "FieldForceName";
        public string ValueMember = "FieldForcePromotionID";
        #endregion

        #region Methods & Implementation

        public List<FieldForcePromotion> GetFieldForcePromotionList(string FromDate, string ToDate, bool allOffices = false, bool showDeleted = false)
        {
            return FieldForcePromotionIntegration.GetFieldForcePromotionList(FromDate,ToDate);
        }

        public List<FieldForcePromotion> GetPromotedRankDescription(int FieldForceRankID, string FromDate, string ToDate, bool allOffices = false, bool showDeleted = false)
        {
            return FieldForcePromotionIntegration.GetPromotedRankDescription(FieldForceRankID,FromDate, ToDate);
        }

        public FieldForcePromotion GetFieldForcePromotionByID(int FieldForcePromotionID)
        {
            return FieldForcePromotionIntegration.GetFieldForcePromotionByID(FieldForcePromotionID);
        }

       

        public  int InsertFieldForcePromotionProvisionalList(string FromDate, string ToDate, string OfficeIDs)
        {
            return FieldForcePromotionIntegration.InsertFieldForcePromotionProvisionalList(FromDate, ToDate, OfficeIDs);
        }

        public  int InsertFieldForcePromote(string OfficeIDs, string DateFrom, string DateTo, int ApprovedBy)
        {
            return FieldForcePromotionIntegration.InsertFieldForcePromote(OfficeIDs, DateFrom, DateTo, ApprovedBy);
        }

        public  int RejectFieldForcePromote(FieldForcePromotion theFieldForcePromotion)
        {
            return FieldForcePromotionIntegration.RejectFieldForcePromote(theFieldForcePromotion);
        }

        #endregion
    }
}
