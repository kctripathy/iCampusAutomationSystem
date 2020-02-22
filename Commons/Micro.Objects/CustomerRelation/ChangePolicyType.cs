using System;

namespace Micro.Objects.CustomerRelation
{      [Serializable]
   public class ChangePolicyType
    {
     public int PolicyRevivalID
     {
         get;
         set;
     }
    public int AccountID
     {
         get;
         set;
     }
     public string DateOfRevival
     {
         get;
         set;
     }
     public int NoOfInstallmentsRevived
     {
         get;
         set;
     }
     public int RevivedFromInstallmentNumber
     {
         get;
         set;
     }
     public string DateOfMaturityCurrent
     {
         get;
         set;
     }
     public string DateOfMaturityNew
     {
         get;
         set;
     }
     public int RevivedByID
     {
         get;
         set;
     }
     public int OfficeID
     {
         get;
         set;
     }
     public bool IsActive
     {
         get;
         set;
     }
      public bool IsDeleted
     {
         get;
         set;
     }
    public string DateAdded
     {
         get;
         set;
     }
    public int AddedBy
     {
         get;
         set;
     }
      public string DateModified
     {
         get;
         set;
     }
    public int ModifiedBy
     {
         get;
         set;
     }

    }
}
