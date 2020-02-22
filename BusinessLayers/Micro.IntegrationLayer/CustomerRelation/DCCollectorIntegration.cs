using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using System.Linq;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial class DCCollectorIntegration
   {
       #region Declaration
       #endregion

       #region Methods & Implementation

       public static DCCollector DataRowToObject(DataRow dr)
       {
           DCCollector TheDCCollector = new DCCollector();

           TheDCCollector.DCCollectorID = int.Parse(dr["DCCollectorID"].ToString());
           TheDCCollector.Salutation = dr["Salutation"].ToString();
           TheDCCollector.DCCollectorName = dr["DCCollectorName"].ToString();
           TheDCCollector.DCCollectorCode = dr["DCCollectorCode"].ToString();
           TheDCCollector.FatherName = dr["FatherName"].ToString();
           TheDCCollector.SpouseName = dr["SpouseName"].ToString();
           TheDCCollector.Gender = dr["Gender"].ToString();
           TheDCCollector.MaritalStatus = dr["MaritalStatus"].ToString();
           TheDCCollector.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString()).ToString(MicroConstants.DateFormat);
           TheDCCollector.Age = int.Parse(dr["Age"].ToString());
           TheDCCollector.Address_Present_TownOrCity = dr["Address_Present_TownOrCity"].ToString();
           TheDCCollector.Address_Present_Landmark = dr["Address_Present_Landmark"].ToString();
           TheDCCollector.Address_Present_PinCode = dr["Address_Present_PinCode"].ToString();
           TheDCCollector.Address_Present_DistrictID = int.Parse(dr["Address_Present_DistrictID"].ToString());
		   TheDCCollector.Address_Present_DistrictName = dr["Address_Present_DistrictName"].ToString();
		   TheDCCollector.Address_Present_CountryName = dr["Address_Present_CountryName"].ToString();
		   TheDCCollector.Address_Present_StateName = dr["Address_Present_StateName"].ToString();

           TheDCCollector.Address_Permanent_TownOrCity = dr["Address_Permanent_TownOrCity"].ToString();
           TheDCCollector.Address_Permanent_Landmark = dr["Address_Permanent_Landmark"].ToString();
           TheDCCollector.Address_Permanent_PinCode = dr["Address_Permanent_PinCode"].ToString();
           TheDCCollector.Address_Permanent_DistrictID = int.Parse(dr["Address_Permanent_DistrictID"].ToString());
		   TheDCCollector.Address_Permanent_DistrictName = dr["Address_Permanent_DistrictName"].ToString();
		   TheDCCollector.Address_Permanent_StateName = dr["Address_Permanent_StateName"].ToString();
		   TheDCCollector.Address_Permanent_CountryName = dr["Address_Permanent_CountryName"].ToString();
           TheDCCollector.Phone = dr["Phone"].ToString();
           TheDCCollector.Mobile = dr["Mobile"].ToString();
           TheDCCollector.Email = dr["Email"].ToString();
           TheDCCollector.Qualification = dr["Qualification"].ToString();
           TheDCCollector.Occupation = dr["Occupation"].ToString();
           TheDCCollector.Nationality = dr["Nationality"].ToString();
           TheDCCollector.Religion = dr["Religion"].ToString();
           TheDCCollector.Caste = dr["Caste"].ToString();

           if (!string.IsNullOrEmpty(dr["Photo"].ToString()))
           {
               TheDCCollector.Photo = (byte[])dr["Photo"];
           }
           if (!string.IsNullOrEmpty(dr["Signature"].ToString()))
           {
               TheDCCollector.Signature = (byte[])dr["Signature"];
           }

           TheDCCollector.DateOfJoining = DateTime.Parse(dr["DateOfJoining"].ToString()).ToString(MicroConstants.DateFormat);
           TheDCCollector.DCCollectorPassword = dr["DCCollectorPassword"].ToString();
           TheDCCollector.MaximumCollectionAmountAllowed = decimal.Parse(dr["MaximumCollectionAmountAllowed"].ToString());
           TheDCCollector.MaximumMinutesAllowed = int.Parse(dr["MaximumMinutesAllowed"].ToString());
           TheDCCollector.MaximumTransactionsAllowed = int.Parse(dr["MaximumTransactionsAllowed"].ToString());
           TheDCCollector.CanDownloadMaster = bool.Parse(dr["CanDownloadMaster"].ToString());
           TheDCCollector.CanDoTransactions = bool.Parse(dr["CanDoTransactions"].ToString());
           TheDCCollector.CanCancelTransaction = bool.Parse(dr["CanCancelTransaction"].ToString());
           TheDCCollector.CanPrintDuplicateReceipts = bool.Parse(dr["CanPrintDuplicateReceipts"].ToString());
           TheDCCollector.OfficeID = int.Parse(dr["OfficeID"].ToString());
		   TheDCCollector.OfficeName = dr["OfficeName"].ToString();
           TheDCCollector.AddedBy = int.Parse(dr["AddedBy"].ToString());
           TheDCCollector.DateAdded = DateTime.Parse(dr["DateAdded"].ToString()).ToString(MicroConstants.DateFormat);

           return TheDCCollector;
       }

       public static List<DCCollector> GetDCCollectorList(bool allOffices = false, bool showDeleted = false)
       {
           List<DCCollector> DCCollectorList = new List<DCCollector>();

           DataTable DCCollectorTable = new DataTable();
           DCCollectorTable = DCCollectorDataAccess.GetInstance.GetDCCollectorList(allOffices,showDeleted);

           foreach (DataRow dr in DCCollectorTable.Rows)
           {
               DCCollector TheDCCollector = DataRowToObject(dr);

               DCCollectorList.Add(TheDCCollector);
           }

           return DCCollectorList;
       }

	   public static List<DCCollector> GetDuplicateDCCollectorList(string dccollectorName, string fatherName, string dateofBirth, bool allOffices = false, bool showDeleted = false)
	   {
		   List<DCCollector> TheDCCollectorList = GetDCCollectorList(allOffices, showDeleted);


		   List<DCCollector> TheDuplicateDCCollectorList = new List<DCCollector>();

		   if (TheDCCollectorList.Count > 0)
		   {
			   var DuplicateDCCollectorList = (from DCCollectorList in TheDCCollectorList
											where DCCollectorList.DCCollectorName.ToUpper() == dccollectorName.ToUpper()
											&& DCCollectorList.FatherName.ToUpper() == fatherName.ToUpper()
											&& DCCollectorList.DateOfBirth.ToUpper() == dateofBirth.ToUpper()
											select DCCollectorList).ToList();

			   foreach (DCCollector EachDCCollector in DuplicateDCCollectorList)
			   {
				   DCCollector TheDCCollector = (DCCollector)EachDCCollector;

				   TheDuplicateDCCollectorList.Add(TheDCCollector);
			   }
		   }

		   return TheDuplicateDCCollectorList;
	   }

       public static DCCollector GetDCCollectorsById(int DCCollectorID)
       {
           DataRow DCCollectorRow = DCCollectorDataAccess.GetInstance.GetDCCollectorsById(DCCollectorID);

           DCCollector TheDCCollectorRow = DataRowToObject(DCCollectorRow);

           return TheDCCollectorRow;
       }

       public static int InsertDCCollector(DCCollector theDCCollector)
       {
           return DCCollectorDataAccess.GetInstance.InsertDCCollector(theDCCollector);
       }

       public static int UpdateDCCollector(DCCollector theDCCollector)
       {
           return DCCollectorDataAccess.GetInstance.UpdateDCCollector(theDCCollector);
       }

       public static int DeleteDCCollector(DCCollector theDCCollector)
       {
           return DCCollectorDataAccess.GetInstance.DeleteDCCollector(theDCCollector);
       }

       #endregion
   }
}
