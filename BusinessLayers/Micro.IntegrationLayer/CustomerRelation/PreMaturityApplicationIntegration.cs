using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class PreMaturityApplicationIntegration
	{
		#region Methods & Implementation

		public static PreMaturityApplication DataRowToObject(DataRow dr)
		{
			PreMaturityApplication ThePreMaturityApplications = new PreMaturityApplication();

			ThePreMaturityApplications.PreMaturityApplicationID = int.Parse(dr["PreMaturityApplicationID"].ToString());
			ThePreMaturityApplications.PreMaturityApplicationDate = DateTime.Parse(dr["PreMaturityApplicationDate"].ToString()).ToString(MicroConstants.DateFormat);
			ThePreMaturityApplications.CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString());
			if(!string.IsNullOrEmpty(dr["DeathCertificate"].ToString()))
			{
				ThePreMaturityApplications.DeathCertificate = (byte[])dr["DeathCertificate"];
			}

			ThePreMaturityApplications.PreMaturityRemark = dr["PreMaturityRemark"].ToString();
			ThePreMaturityApplications.PreMaturityApplicationLetterDate = DateTime.Parse(dr["PreMaturityApplicationLetterDate"].ToString()).ToString(MicroConstants.DateFormat);
			ThePreMaturityApplications.PreMaturityApplicationLetterReference = dr["PreMaturityApplicationLetterReference"].ToString();
			ThePreMaturityApplications.PreMaturityApprovalStatus = dr["PreMaturityApprovalStatus"].ToString();
			ThePreMaturityApplications.CustomerName = dr["CustomerName"].ToString();
			ThePreMaturityApplications.CustomerID = int.Parse(dr["CustomerID"].ToString());
			ThePreMaturityApplications.CustomerAccountCode = dr["CustomerAccountCode"].ToString();

			return ThePreMaturityApplications;
		}

		public static List<PreMaturityApplication> GetPrematurityApplicationList(bool allOffices = false, bool showDeleted = false)
		{
			List<PreMaturityApplication> PreMaturityApplicationList = new List<PreMaturityApplication>();

			DataTable PreMaturityApplicationTable = PreMaturityApplicationDataAccess.GetInstance.GetPrematurityApplicationList(allOffices, showDeleted);

			foreach(DataRow dr in PreMaturityApplicationTable.Rows)
			{
				PreMaturityApplication ThePreMaturityApplications = DataRowToObject(dr);

				PreMaturityApplicationList.Add(ThePreMaturityApplications);
			}

			return PreMaturityApplicationList;
		}

		public static PreMaturityApplication GetPreMaturityApplicationByID(int preMaturityApplicationID)
		{
			DataRow PreMaturityApplicationRow = PreMaturityApplicationDataAccess.GetInstance.GetPreMaturityApplicationByID(preMaturityApplicationID);

			PreMaturityApplication ThePreMaturityApplications = DataRowToObject(PreMaturityApplicationRow);

			return ThePreMaturityApplications;
		}

		public static List<PreMaturityApplication> GetPreMaturityApplicationListByCustomerAccountID(int customerAccountID)
		{
			List<PreMaturityApplication> PreMaturityApplicationList = new List<PreMaturityApplication>();
			DataTable PreMaturityApplicationDataTable = PreMaturityApplicationDataAccess.GetInstance.GetPreMaturityApplicationListByCustomerAccountID(customerAccountID);

			foreach(DataRow dr in PreMaturityApplicationDataTable.Rows)
			{
				PreMaturityApplication ThePreMaturityApplications = DataRowToObject(dr);

				PreMaturityApplicationList.Add(ThePreMaturityApplications);
			}

			return PreMaturityApplicationList;
		}

		public static PreMaturityApplication GetLastPreMaturtiyApplicationByCustomerAccountID(int customerAccountID)
		{
			PreMaturityApplication ThePreMaturityApplication  = null;
			
			List<PreMaturityApplication> PreMaturityApplicationList = GetPreMaturityApplicationListByCustomerAccountID(customerAccountID);

			if(PreMaturityApplicationList.Count > 0)
			{
				var LastPreMaturityApplication = (from TheApplicationList in PreMaturityApplicationList
												  where TheApplicationList.PreMaturityApprovalStatus != MicroEnums.GetStringValue(MicroEnums.ApprovalStatus.Rejected)
												  orderby DateTime.Parse(TheApplicationList.PreMaturityApplicationDate)
												  select TheApplicationList).LastOrDefault();

				ThePreMaturityApplication = (PreMaturityApplication)LastPreMaturityApplication;
			}

			return ThePreMaturityApplication;
		}

		public static List<PreMaturityApplication> GetPreMaturityApplicationListByApprovalStatus(string approvalStatus, bool allOffices = true)
		{
			List<PreMaturityApplication> ThePreMaturityApplicationsList = new List<PreMaturityApplication>();

			DataTable ThePreMaturityApplicationsTable = PreMaturityApplicationDataAccess.GetInstance.GetPreMaturityApplicationListByApprovalStatus(approvalStatus, allOffices);

			foreach(DataRow dr in ThePreMaturityApplicationsTable.Rows)
			{
				PreMaturityApplication ThePreMaturityApplications = DataRowToObject(dr);

				ThePreMaturityApplicationsList.Add(ThePreMaturityApplications);
			}

			return ThePreMaturityApplicationsList;
		}

		public static int InsertPrematurityApplication(PreMaturityApplication thePreMaturityApplications)
		{
			return PreMaturityApplicationDataAccess.GetInstance.InsertPrematurityApplication(thePreMaturityApplications);
		}

		public static int UpdatePrematurityApplication(PreMaturityApplication thePreMaturityApplications)
		{
			return PreMaturityApplicationDataAccess.GetInstance.UpdatePrematurityApplication(thePreMaturityApplications);
		}
		#endregion
	}
}
