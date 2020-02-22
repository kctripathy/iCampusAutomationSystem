using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class GuarantorLoanApplicationIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static GuarantorLoanApplication DataRowToObject(DataRow dr)
        {
            GuarantorLoanApplication TheGuarantorLoanApplication = new GuarantorLoanApplication
            {
                GuarantorLoanApplicationID = int.Parse(dr["GuarantorLoanApplicationID"].ToString()),
                LoanAppliedBy = dr["LoanAppliedBy"].ToString(),
                LoanApplicantID = int.Parse(dr["LoanApplicantID"].ToString()),
                LoanApplicationNumber = dr["LoanApplicationNumber"].ToString(),
                LoanApplicantName = dr["LoanApplicantName"].ToString(),
                LoanApplicationDate = DateTime.Parse(dr["LoanApplicationDate"].ToString()).ToString(MicroConstants.DateFormat),
                LoanApplicationFee = decimal.Parse(dr["LoanApplicationFee"].ToString()),
                RequiredFor = dr["RequiredFor"].ToString(),
                LoanAmountApplied = decimal.Parse(dr["LoanAmountApplied"].ToString()),
                ApprovalStatus = dr["ApprovalStatus"].ToString(),
                Remarks = dr["Remarks"].ToString(),
                OfficeID = int.Parse(dr["OfficeID"].ToString())
            };

            return TheGuarantorLoanApplication;
        }

        public static List<GuarantorLoanApplication> GetGuarantorLoanApplicationList(bool allOffices = false, bool showDeleted = false)
        {
            List<GuarantorLoanApplication> GuarantorLoanApplicationList = new List<GuarantorLoanApplication>();

            DataTable GetGuarantorLoanApplicationTable = GuarantorLoanApplicationDataAccess.GetInstance.GetGuarantorLoanApplicationList(allOffices, showDeleted);

            foreach (DataRow dr in GetGuarantorLoanApplicationTable.Rows)
            {
                GuarantorLoanApplication TheGuarantorLoanApplication = DataRowToObject(dr);

                GuarantorLoanApplicationList.Add(TheGuarantorLoanApplication);
            }

            return GuarantorLoanApplicationList;
        }

        public static GuarantorLoanApplication GetGuarantorLoanApplicationByID(int guarantorLoanApplicationID)
        {
            GuarantorLoanApplication TheGuarantorLoanApplication;
            DataRow GuarantorLoanApplicationRow = GuarantorLoanApplicationDataAccess.GetInstance.GetGuarantorLoanApplicationByID(guarantorLoanApplicationID);

            if (GuarantorLoanApplicationRow != null)
                TheGuarantorLoanApplication = DataRowToObject(GuarantorLoanApplicationRow);
            else
                TheGuarantorLoanApplication = new GuarantorLoanApplication();

            return TheGuarantorLoanApplication;
        }

        public static List<GuarantorLoanApplication> GetGuarantorLoanApplicationListByApprovalStatus(string approvalStatus, bool allOffices = false)
        {
            List<GuarantorLoanApplication> TheGuarantorLoanApplicationList = new List<GuarantorLoanApplication>();

            DataTable TheGuarantorLoanApplicationTable = GuarantorLoanApplicationDataAccess.GetInstance.GetGuarantorLoanApplicationListByApprovalStatus(approvalStatus, allOffices);

            foreach (DataRow dr in TheGuarantorLoanApplicationTable.Rows)
            {
                GuarantorLoanApplication TheGuarantorLoanApplication = DataRowToObject(dr);

                TheGuarantorLoanApplicationList.Add(TheGuarantorLoanApplication);
            }

            return TheGuarantorLoanApplicationList;
        }

        public static List<GuarantorLoanApplication> GetGuarantorLoanApplicationListByApplicantID(int loanApplicantID)
        {
            List<GuarantorLoanApplication> TheGuarantorLoanApplicationList = new List<GuarantorLoanApplication>();

            DataTable TheGuarantorLoanApplicationTable = GuarantorLoanApplicationDataAccess.GetInstance.GetGuarantorLoanApplicationListByApplicantID(loanApplicantID);

            foreach (DataRow dr in TheGuarantorLoanApplicationTable.Rows)
            {
                GuarantorLoanApplication TheGuarantorLoanApplication = DataRowToObject(dr);

                TheGuarantorLoanApplicationList.Add(TheGuarantorLoanApplication);
            }

            return TheGuarantorLoanApplicationList;
        }

        public static List<GuarantorLoanApplication> GetGuarantorLoanApplicationListByApplicantID(int loanApplicantID, string loanAppliedBy)
        {
            List<GuarantorLoanApplication> FilteredApplicationList;
            List<GuarantorLoanApplication> GuarantorLoanApplicationList = GetGuarantorLoanApplicationListByApplicantID(loanApplicantID);

            if (GuarantorLoanApplicationList.Count > 0)
                FilteredApplicationList = (from LoanApplications in GuarantorLoanApplicationList
                                           where LoanApplications.LoanAppliedBy.Equals(loanAppliedBy)
                                           select LoanApplications).ToList();
            else
                FilteredApplicationList = new List<GuarantorLoanApplication>();

            return FilteredApplicationList;
        }

        public static List<GuarantorLoanApplication> GetGuarantorLoanApplicationListByApplicantID(int loanApplicantID, string loanAppliedBy, string approvalStatus)
        {
            List<GuarantorLoanApplication> FilteredApplicationList;
            List<GuarantorLoanApplication> GuarantorLoanApplicationList = GetGuarantorLoanApplicationListByApplicantID(loanApplicantID, loanAppliedBy);

            if (GuarantorLoanApplicationList.Count > 0)
                FilteredApplicationList = (from LoanApplications in GuarantorLoanApplicationList
                                           where LoanApplications.ApprovalStatus.Equals(approvalStatus)
                                           select LoanApplications).ToList();
            else
                FilteredApplicationList = new List<GuarantorLoanApplication>();

            return FilteredApplicationList;
        }

        public static int InsertGuarantorLoanApplication(GuarantorLoanApplication theGuarantorLoanApplication)
        {
            return GuarantorLoanApplicationDataAccess.GetInstance.InsertGuarantorLoanApplication(theGuarantorLoanApplication);
        }

        public static int UpdateGuarantorLoanApplication(GuarantorLoanApplication theGuarantorLoanApplication)
        {
            return GuarantorLoanApplicationDataAccess.GetInstance.UpdateGuarantorLoanApplication(theGuarantorLoanApplication);
        }

        public static int DeleteGuarantorLoanApplication(GuarantorLoanApplication theGuarantorLoanApplication)
        {
            return GuarantorLoanApplicationDataAccess.GetInstance.DeleteGuarantorLoanApplication(theGuarantorLoanApplication);
        }

        public static int RejectGuarantorLoanApplication(GuarantorLoanApplication theLoanReject)
        {
            return GuarantorLoanApplicationDataAccess.GetInstance.RejectGuarantorLoanApplication(theLoanReject);
        }
        #endregion
    }
}
