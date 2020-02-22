using System;
using System.Collections.Generic;
using System.Linq;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;
using System.Data;
using Micro.Commons;

namespace Micro.IntegrationLayer.CustomerRelation
{
  public partial class FieldForcePromotionIntegration
  {
      #region Declaration
      #endregion

      #region Methods & Implementations
      public static FieldForcePromotion DataRowToObject(DataRow dr)
      {
          FieldForcePromotion TheFieldForcePromotion = new FieldForcePromotion();
          TheFieldForcePromotion.FieldForcePromotionID = int.Parse(dr["FieldForcePromotionID"].ToString());
          TheFieldForcePromotion.FieldForceID = int.Parse(dr["FieldForceID"].ToString());
          TheFieldForcePromotion.FieldForceName = dr["FieldForceName"].ToString();
          TheFieldForcePromotion.FieldForceCode = dr["FieldForceCode"].ToString();
          TheFieldForcePromotion.BusinessFromDate = DateTime.Parse(dr["BusinessFromDate"].ToString()).ToString(MicroConstants.DateFormat);
          TheFieldForcePromotion.BusinessToDate = DateTime.Parse(dr["BusinessToDate"].ToString()).ToString(MicroConstants.DateFormat);
          TheFieldForcePromotion.BusinessNew = decimal.Parse(dr["BusinessNew"].ToString());
          TheFieldForcePromotion.BusinessRenew = decimal.Parse(dr["BusinessRenew"].ToString());
          TheFieldForcePromotion.BusinessOneTime = decimal.Parse(dr["BusinessOneTime"].ToString());
          TheFieldForcePromotion.ExistingRankID = int.Parse(dr["ExistingRankID"].ToString());
          TheFieldForcePromotion.ExistingRankDescription = dr["ExistingRankDescription"].ToString();
          TheFieldForcePromotion.PromotedToRankID = int.Parse(dr["PromotedToRankID"].ToString());
          TheFieldForcePromotion.PromotedToRankDescription = dr["PromotedToRankDescription"].ToString();
          TheFieldForcePromotion.PromotionStatus = dr["PromotionStatus"].ToString();
          TheFieldForcePromotion.HasAccepted = bool.Parse(dr["HasAccepted"].ToString());
          if (!string.IsNullOrEmpty(dr["StatusChangeDate"].ToString()))
          {
              TheFieldForcePromotion.StatusChangeDate = DateTime.Parse(dr["StatusChangeDate"].ToString()).ToString(MicroConstants.DateFormat);
          }
          TheFieldForcePromotion.StatusChangedByEmployeeID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["StatusChangedByEmployeeID"].ToString()));
          TheFieldForcePromotion.Remarks = dr["Remarks"].ToString();
          TheFieldForcePromotion.OfficeID = int.Parse(dr["OfficeID"].ToString());

          return TheFieldForcePromotion;
      }

      public static List<FieldForcePromotion> GetFieldForcePromotionList(string FromDate, string ToDate, bool allOffices = false, bool showDeleted = false)
      {
          List<FieldForcePromotion> FieldForcePromotionList = new List<FieldForcePromotion>();
          DataTable FieldForcePromotionTable = FieldForcePromotionDataAccess.GetInstance.GetFieldForcePromotionList(FromDate,ToDate);

          foreach (DataRow dr in FieldForcePromotionTable.Rows)
          {
              FieldForcePromotion TheFieldForcePromotion = DataRowToObject(dr);

              FieldForcePromotionList.Add(TheFieldForcePromotion);
          }

          return FieldForcePromotionList;
      }

      public static List<FieldForcePromotion> GetPromotedRankDescription(int FieldForceRankID,string FromDate, string ToDate, bool allOffices = false, bool showDeleted = false)
      {
          List<FieldForcePromotion> FieldForcePromotionList = new List<FieldForcePromotion>();
          List<FieldForcePromotion> PromotionList = GetFieldForcePromotionList(FromDate, ToDate);

          if (PromotionList.Count > 0)
          {
              var PromotedList = (from FieldForcePromotions in PromotionList
                                  where FieldForcePromotions.ExistingRankID == FieldForceRankID && FieldForcePromotions.PromotionStatus == "Provisional"
                                         select FieldForcePromotions);
              
              foreach (FieldForcePromotion TheFieldForcePromotion in PromotedList)
              {
                  FieldForcePromotionList.Add(TheFieldForcePromotion);
              }
          }

          return FieldForcePromotionList;
      }

      public static FieldForcePromotion GetFieldForcePromotionByID(int FieldForcePromotionID)
      {
          DataRow TheFieldForcePromotionRow = FieldForcePromotionDataAccess.GetInstance.GetFieldForcePromotionByID(FieldForcePromotionID);

          FieldForcePromotion TheFieldForcePromotion = DataRowToObject(TheFieldForcePromotionRow);

          return TheFieldForcePromotion;
      }

      public static int InsertFieldForcePromotionProvisionalList(string FromDate, string ToDate, string OfficeIDs)
      {
          return FieldForcePromotionDataAccess.GetInstance.InsertFieldForcePromotionProvisionalList(FromDate,ToDate,OfficeIDs);
      }

      public static int InsertFieldForcePromote(string OfficeIDs,string DateFrom,string DateTo,int ApprovedBy )
      {
          return FieldForcePromotionDataAccess.GetInstance.InsertFieldForcePromote(OfficeIDs,DateFrom,DateTo,ApprovedBy);
      }

      public static int RejectFieldForcePromote(FieldForcePromotion theFieldForcePromotion)
      {
          return FieldForcePromotionDataAccess.GetInstance.RejectFieldForcePromote(theFieldForcePromotion);
      }
      #endregion

  }
}
