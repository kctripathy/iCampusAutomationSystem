using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class DCAccountIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementations
        public static DCAccount DataRowToObject(DataRow dr)
        {
			DCAccount TheDCAccount = new DCAccount
			{
				DCAccountID = int.Parse(dr["DCAccountID"].ToString()),
				DCAccountCode = dr["DCAccountCode"].ToString(),
				CustomerName = dr["CustomerName"].ToString(),
				FatherName = dr["FatherName"].ToString(),
				Address_Present_TownOrCity = dr["Address_Present_TownOrCity"].ToString(),
				Address_Present_Landmark = dr["Address_Present_Landmark"].ToString(),
				Address_Present_PinCode = dr["Address_Present_PinCode"].ToString(),
				Address_Present_DistrictID = int.Parse(dr["Address_Present_DistrictID"].ToString()),
				Address_Present_DistrictName=dr["Address_Present_DistrictName"].ToString(),
				Address_Present_StateName=dr["Address_Present_StateName"].ToString(),
				Address_Present_CountryName=dr["Address_Present_CountryName"].ToString(),
				CommencementDate = DateTime.Parse(dr["CommencementDate"].ToString()).ToString(MicroConstants.DateFormat),
				InstallmentAmountDaily = decimal.Parse(dr["InstallmentAmountDaily"].ToString()),
				InstallmentAmountMonthly = decimal.Parse(dr["InstallmentAmountMonthly"].ToString()),
				DCCollectorID = int.Parse(dr["DCCollectorID"].ToString()),
				DCCollectorCode=dr["DCCollectorCode"].ToString(),
				DCCollectorName = dr["DCCollectorName"].ToString(),
				AccountStatus = dr["AccountStatus"].ToString(),
				BalanceAmount = decimal.Parse(dr["BalanceAmount"].ToString()),
				IsToBeUpdated = bool.Parse(dr["IsToBeUpdated"].ToString()),
				OfficeID=int.Parse(dr["OfficeID"].ToString()),
				OfficeName=dr["OfficeName"].ToString()
			};

            return TheDCAccount;
        }

        public static List<DCAccount> GetDCAccountList(bool allOffices = false, bool showDeleted = false)
        {
			List<DCAccount> DCAccountList = new List<DCAccount>();

			DataTable DCAccountTable = DCAccountDataAccess.GetInstance.GetDCAccountList(allOffices,showDeleted);

            foreach (DataRow dr in DCAccountTable.Rows)
            {
				DCAccount TheDCAccount = DataRowToObject(dr);

                DCAccountList.Add(TheDCAccount);
            }

            return DCAccountList;
        }

		public static List<DCAccount> GetUnallotedDCAccounts(bool allOffices = false, bool showDeleted = false)
		{
			List<DCAccount> DCAccountList = new List<DCAccount>();

			DataTable DCAccountTable = DCAccountDataAccess.GetInstance.GetUnallotedDCAccounts(allOffices, showDeleted);

			foreach(DataRow dr in DCAccountTable.Rows)
			{
				DCAccount TheDCAccount = DataRowToObject(dr);

				DCAccountList.Add(TheDCAccount);
			}

			return DCAccountList;
		}

		public static DCAccount GetDCAccountById(int theDCAccountID)
		{
			DataRow DCAccountRow = DCAccountDataAccess.GetInstance.GetDCAccountById(theDCAccountID);

			DCAccount TheDCAccount = DataRowToObject(DCAccountRow);

			return TheDCAccount;
		}

        public static int InsertDcAccount(DCAccount theDCAccount)
        {
            return DCAccountDataAccess.GetInstance.InsertDCAccount(theDCAccount);
        }

        public static int UpdateDcAccount(DCAccount theDcAccount)
        {
            return DCAccountDataAccess.GetInstance.UpdateDCAccount(theDcAccount);
        }

        public static int DeleteDcAccount(DCAccount theDcAccount)
        {
            return DCAccountDataAccess.GetInstance.DeleteDCAccount(theDcAccount);
        }
        #endregion
    }
}
