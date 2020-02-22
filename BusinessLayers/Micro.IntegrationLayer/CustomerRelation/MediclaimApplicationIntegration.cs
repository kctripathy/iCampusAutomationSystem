using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Micro.Objects.CustomerRelation;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class MediclaimApplicationIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static MediclaimApplication DataRowToObject(DataRow dr)
        {
            MediclaimApplication TheMediclaimApplication = new MediclaimApplication();

            TheMediclaimApplication.MediclaimApplicationID = int.Parse(dr["MediclaimApplicationID"].ToString());
            TheMediclaimApplication.CustomerID = int.Parse(dr["CustomerID"].ToString());
            TheMediclaimApplication.CustomerCode = dr["CustomerCode"].ToString();
            TheMediclaimApplication.CustomerName = dr["CustomerName"].ToString();
            TheMediclaimApplication.MediclaimApplicationNumber = dr["MediclaimApplicationNumber"].ToString();
            TheMediclaimApplication.MediclaimApplicationDate = DateTime.Parse(dr["MediclaimApplicationDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheMediclaimApplication.ReasonForClaim = dr["ReasonForClaim"].ToString();
            TheMediclaimApplication.ApprovalStatus = dr["ApprovalStatus"].ToString();
			TheMediclaimApplication.OfficeName = dr["OfficeName"].ToString();
            TheMediclaimApplication.Remarks = dr["Remarks"].ToString();

            return TheMediclaimApplication;
        }

        public static List<MediclaimApplication> GetMediclaimApplicationsList(bool allOffices = false, bool showDeleted = false)
        {
            List<MediclaimApplication> MediclaimApplicationsList = new List<MediclaimApplication>();
            DataTable MediclaimApplicationTable = MediclaimApplicationDataAccess.GetInstance.GetMediclaimApplicationsList(allOffices, showDeleted);

            foreach (DataRow dr in MediclaimApplicationTable.Rows)
            {
                MediclaimApplication TheMediclaimApplication = DataRowToObject(dr);

                MediclaimApplicationsList.Add(TheMediclaimApplication);
            }

            return MediclaimApplicationsList;
        }

        public static List<MediclaimApplication> GetMediclaimApplicationsListByApprovalStatus(string approvalStatus, bool allOffices = false)
        {
            List<MediclaimApplication> MediclaimApplicationsList = new List<MediclaimApplication>();
            DataTable MediclaimApplicationTable = MediclaimApplicationDataAccess.GetInstance.GetMediclaimApplicationsListByApprovalStatus(approvalStatus, allOffices);

            foreach (DataRow dr in MediclaimApplicationTable.Rows)
            {
                MediclaimApplication TheMediclaimApplication = DataRowToObject(dr);

                MediclaimApplicationsList.Add(TheMediclaimApplication);
            }

            return MediclaimApplicationsList;
        }

        public static List<MediclaimApplication> GetMediclaimApplicationsListByCustomerID(int customerID)
        {
            List<MediclaimApplication> MediclaimApplicationsList = new List<MediclaimApplication>();
            DataTable MediclaimApplicationTable = MediclaimApplicationDataAccess.GetInstance.GetMediclaimApplicationsListByCustomerID(customerID);

            foreach (DataRow dr in MediclaimApplicationTable.Rows)
            {
                MediclaimApplication TheMediclaimApplication = DataRowToObject(dr);

                MediclaimApplicationsList.Add(TheMediclaimApplication);
            }

            return MediclaimApplicationsList;
        }

        public static MediclaimApplication GetApprovalStatuswiseMediclaimApplication(int customerID, bool allOffices = false, bool showDeleted = false)
        {
            MediclaimApplication ReturnValue;
            var ApprovalStatuswiseMediclaimApplication = (from mediclaimApplication in GetMediclaimApplicationsList(allOffices, showDeleted)
                                                          where mediclaimApplication.CustomerID == customerID
                                                          select mediclaimApplication).SingleOrDefault();

            if (ApprovalStatuswiseMediclaimApplication != null)
                ReturnValue = ApprovalStatuswiseMediclaimApplication;
            else
                ReturnValue = new MediclaimApplication();

            return ReturnValue;
        }

        public static MediclaimApplication GetMediclaimApplicationByID(int mediclaimApplicationID)
        {
            DataRow TheMediclaimApplicationRow = MediclaimApplicationDataAccess.GetInstance.GetMediclaimApplicationByID(mediclaimApplicationID);

            MediclaimApplication TheMediclaimApplication = DataRowToObject(TheMediclaimApplicationRow);

            return TheMediclaimApplication;
        }

        public static int InsertMediclaimApplication(MediclaimApplication theMediclaimApplication)
        {
            return MediclaimApplicationDataAccess.GetInstance.InsertMediclaimApplication(theMediclaimApplication);
        }

        public static int UpdateMediclaimApplication(MediclaimApplication theMediclaimApplication)
        {
            return MediclaimApplicationDataAccess.GetInstance.UpdateMediclaimApplication(theMediclaimApplication);
        }

        public static int UpdateMediclaimApplicationApprovalStatus(MediclaimApplication theMediclaimApplication)
        {
            return MediclaimApplicationDataAccess.GetInstance.UpdateMediclaimApplicationApprovalStatus(theMediclaimApplication);
        }

        public static int DeleteMediclaimApplication(MediclaimApplication theMediclaimApplication)
        {
            return MediclaimApplicationDataAccess.GetInstance.DeleteMediclaimApplication(theMediclaimApplication);
        }
        #endregion
    }
}
