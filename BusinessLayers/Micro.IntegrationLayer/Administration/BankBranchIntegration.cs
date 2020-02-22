using System;
using System.Collections.Generic;
using Micro.Objects.Administration;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
   public partial  class BankBranchIntegration
   {
       #region Declaration
       #endregion

       #region Methods & Implementation

       public static BankBranch DataRowToObject(DataRow dr)
       {
           BankBranch TheBankBranch = new BankBranch();

           TheBankBranch.BankBranchID = int.Parse(dr["BankBranchID"].ToString());
           TheBankBranch.BankID = int.Parse(dr["BankID"].ToString());
           
           TheBankBranch.BranchName = dr["BranchName"].ToString();

           TheBankBranch.BranchAddress = dr["BranchAddress"].ToString();
           TheBankBranch.CityOrTown = dr["CityOrTown"].ToString();
           TheBankBranch.DistrictID = int.Parse(dr["DistrictID"].ToString());
           TheBankBranch.PinCode = dr["PinCode"].ToString();
           TheBankBranch.BankName = dr["BankName"].ToString();

           TheBankBranch.AddedBy = int.Parse(dr["AddedBy"].ToString());
           TheBankBranch.DateAdded = DateTime.Parse(dr["DateAdded"].ToString()).ToString(MicroConstants.DateFormat);

           return TheBankBranch;
       }

       public static List<BankBranch> GetAllBankBranch(string SearchText)
       {
           List<BankBranch> BankBranchList = new List<BankBranch>();

           DataTable BankBranchTable = new DataTable();
           BankBranchTable = BankBranchDataAccess.GetInstance.GetAllBankBranch(SearchText);

           foreach (DataRow dr in BankBranchTable.Rows)
           {
               BankBranch TheBankBranch = DataRowToObject(dr);

               BankBranchList.Add(TheBankBranch);
           }

           return BankBranchList;
       }

       public static List<BankBranch> GetAllBankBranchByBankID(int BankID)
       {
           List<BankBranch> BankBranchList = new List<BankBranch>();

           DataTable BankBranchTable = new DataTable();
           BankBranchTable = BankBranchDataAccess.GetInstance.GetAllBankBranchByBankID(BankID);

           foreach (DataRow dr in BankBranchTable.Rows)
           {
               BankBranch TheBankBranch = DataRowToObject(dr);

               BankBranchList.Add(TheBankBranch);
           }

           return BankBranchList;
       }

       public static BankBranch GetBankBranchesByBranchId(int BankBranchID)
       {
           DataRow BankBranchRow = BankBranchDataAccess.GetInstance.GetBankBranchesByBranchId(BankBranchID);

           BankBranch TheBankBranch = DataRowToObject(BankBranchRow);

           return TheBankBranch;
       }

       public static int InsertBankBranch(BankBranch theBankBranch)
       {
           return BankBranchDataAccess.GetInstance.InsertBankBranch(theBankBranch);
       }

       public static int UpdateBankBranch(BankBranch theBankBranch)
       {
           return BankBranchDataAccess.GetInstance.UpdateBankBranch(theBankBranch);
       }

       public static int DeleteBankBranch(BankBranch theBankBranch)
       {
           return BankBranchDataAccess.GetInstance.DeleteBankBranch(theBankBranch);
       }
       #endregion

   }
}
