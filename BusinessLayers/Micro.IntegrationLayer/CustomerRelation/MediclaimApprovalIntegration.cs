using System;
using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.DataAccessLayer.CustomerRelation;
using System.Data;
using Micro.Commons;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class MediclaimApprovalIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static MediclaimApproval DataRowToObject(DataRow dr)
        {
            MediclaimApproval TheMediclaimApproval = new MediclaimApproval();

            TheMediclaimApproval.MediclaimApprovalID = int.Parse(dr["MediclaimApprovalID"].ToString());
            TheMediclaimApproval.MediclaimApplicationID = int.Parse(dr["MediclaimApplicationID"].ToString());
            TheMediclaimApproval.MediclaimApplicationNumber = dr["MediclaimApplicationNumber"].ToString();
            TheMediclaimApproval.CustomerID = int.Parse(dr["CustomerID"].ToString());
            TheMediclaimApproval.CustomerCode = dr["CustomerCode"].ToString();
            TheMediclaimApproval.CustomerName = dr["CustomerName"].ToString();
            TheMediclaimApproval.MediclaimApprovalDate = DateTime.Parse(dr["MediclaimApprovalDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheMediclaimApproval.ApprovedByEmployeeID = int.Parse(dr["ApprovedByEmployeeID"].ToString());
            TheMediclaimApproval.ApprovedByEmployeeCode = dr["ApprovedByEmployeeCode"].ToString();
            TheMediclaimApproval.ApprovedByEmployeeName = dr["ApprovedByEmployeeName"].ToString();
            TheMediclaimApproval.MediclaimApprovalAmount = decimal.Parse(dr["MediclaimApprovalAmount"].ToString());
            TheMediclaimApproval.Remarks = dr["Remarks"].ToString();

            return TheMediclaimApproval;
        }

        public static List<MediclaimApproval> GetMediClaimApprovalList(bool allOffices = false, bool showDeleted = false)
        {
            List<MediclaimApproval> MediclaimApprovalList = new List<MediclaimApproval>();
            DataTable MediclaimApplicationTable = MediclaimApprovalDataAccess.GetInstance.GetMediClaimApprovalList(allOffices, showDeleted);

            foreach (DataRow dr in MediclaimApplicationTable.Rows)
            {
                MediclaimApproval TheMediclaimApplication = DataRowToObject(dr);

                MediclaimApprovalList.Add(TheMediclaimApplication);
            }

            return MediclaimApprovalList;
        }

        public static List<MediclaimApproval> GetUnPaidMediClaimApprovalList(bool allOffices = false)
        {
            List<MediclaimApproval> UnPaidMediclaimApprovalList = new List<MediclaimApproval>();
            DataTable MediclaimApplicationTable = MediclaimApprovalDataAccess.GetInstance.GetUnPaidMediClaimApprovalList(allOffices);

            foreach (DataRow dr in MediclaimApplicationTable.Rows)
            {
                MediclaimApproval TheMediclaimApplication = DataRowToObject(dr);

                UnPaidMediclaimApprovalList.Add(TheMediclaimApplication);
            }

            return UnPaidMediclaimApprovalList;
        }

        public static MediclaimApproval GetMediclaimApprovalByID(int mediclaimApprovalID)
        {
            DataRow TheMediclaimApprovalRow = MediclaimApprovalDataAccess.GetInstance.GetMediclaimApprovalByID(mediclaimApprovalID);

            MediclaimApproval TheMediclaimApproval = DataRowToObject(TheMediclaimApprovalRow);

            return TheMediclaimApproval;
        }
        
        public static int InsertMediclaimApproval(MediclaimApproval theMediclaimApproval)
        {
            return MediclaimApprovalDataAccess.GetInstance.InsertMediclaimApproval(theMediclaimApproval);
        }
        #endregion
    }
}
