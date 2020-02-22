using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class CRMScrollIntegration
	{
		#region Methods & Implementation
		private static CRMScroll DataRowToObject(DataRow dr)
		{
			CRMScroll TheCRMScroll = new CRMScroll
			{
				ScrollID = int.Parse(dr["ScrollID"].ToString()),
				ScrollNumber = int.Parse(dr["ScrollNumber"].ToString()),
				ScrollDate = DateTime.Parse(dr["ScrollDate"].ToString()).ToString(MicroConstants.DateFormat),
				DepositorName = dr["DepositorName"].ToString(),
				ScrollAmountPayable = decimal.Parse(dr["ScrollAmountPayable"].ToString()),
				ScrollAmountPaid = decimal.Parse(dr["ScrollAmountPaid"].ToString()),
				ScrollStatus = dr["ScrollStatus"].ToString(),
				OfficeID = int.Parse(dr["OfficeID"].ToString()),
				OfficeName = dr["OfficeName"].ToString()
			};

			return TheCRMScroll;
		}

        public static List<CRMScroll> GetCRMScrollListByDate(DateTime scrollDate)
		{
			List<CRMScroll> ScrollList = new List<CRMScroll>();

			DataTable ScrollTable  = CRMScrollDataAccess.GetInstance.GetCRMScrollListByDate(scrollDate);

			foreach(DataRow dr in ScrollTable.Rows)
			{
				CRMScroll TheCRMScroll = DataRowToObject(dr);

				ScrollList.Add(TheCRMScroll);
			}

			return ScrollList;
		}

        public static CRMScroll GetCRMScrollByID(int scrollID)
		{
			DataRow TheCRMScrollDataRow = CRMScrollDataAccess.GetInstance.GetCRMScrollByID(scrollID);
			CRMScroll TheCRMScroll = DataRowToObject(TheCRMScrollDataRow);

			return TheCRMScroll;
		}

		public static CRMScroll GetLastCRMScrollByOfficeID()
		{
			DataRow TheCRMScrollDataRow = CRMScrollDataAccess.GetInstance.GetLastCRMScrollByOfficeID();
			CRMScroll TheCRMScroll = DataRowToObject(TheCRMScrollDataRow);
			
			return TheCRMScroll;
		}

		public static int InsertCRMScroll(CRMScroll theCRMScroll)
		{
			return CRMScrollDataAccess.GetInstance.InsertCRMScroll(theCRMScroll);
		}

        public static int UpdateCRMScroll(CRMScroll theCRMScroll)
        {
            return CRMScrollDataAccess.GetInstance.UpdateCRMScroll(theCRMScroll);
        }

		public static int UpdateCRMScrollStatus(int theCRMScrollID, decimal theCRMScrollAmountPaid, string theCRMScrollStatus)
		{
			return CRMScrollDataAccess.GetInstance.UpdateCRMScrollStatus(theCRMScrollID, theCRMScrollAmountPaid, theCRMScrollStatus);
		}

        public static int DeleteCRMScroll(CRMScroll theCRMScroll)
        {
            return CRMScrollDataAccess.GetInstance.DeleteCRMScroll(theCRMScroll);
        }
		#endregion
	}
}
