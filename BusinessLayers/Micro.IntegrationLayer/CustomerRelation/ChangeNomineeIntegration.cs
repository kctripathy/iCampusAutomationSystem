using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;
using System.Data;

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial class ChangeNomineeIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

       public static ChangeNominee DataRowToObject(DataRow dr)
       {
           ChangeNominee TheChangeNominee = new ChangeNominee();

           TheChangeNominee.CustomerNomineeID = int.Parse(dr["CustomerNomineeID"].ToString());
           TheChangeNominee.CustomerAccountID=int.Parse(dr["CustomerAccountID"].ToString());
           TheChangeNominee.NomineeName=dr["NomineeName"].ToString();
           TheChangeNominee.Nominee_Permanent_TownOrCity=dr["Nominee_Permanent_TownOrCity"].ToString();
           TheChangeNominee.Nominee_Permanent_Landmark=dr["Nominee_Permanent_Landmark"].ToString();
           TheChangeNominee.Nominee_Permanent_PinCode=dr["Nominee_Permanent_PinCode"].ToString();
           TheChangeNominee.Nominee_Permanent_DistrictID=int.Parse(dr["Nominee_Permanent_DistrictID"].ToString());
           TheChangeNominee.NomineeRelationship=dr["NomineeRelationship"].ToString();
           TheChangeNominee.NomineeAge=int.Parse(dr["NomineeAge"].ToString());

           return TheChangeNominee;
       }

       public static int InsertNomineeDetails(ChangeNominee theNominee)
       {
           return ChangeNomineeDataAccess.GetInstance.InsertNomineeDetails(theNominee);
       }
        #endregion
    } 
}
