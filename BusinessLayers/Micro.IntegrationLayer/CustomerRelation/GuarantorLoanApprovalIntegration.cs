using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class GuarantorLoanApprovalIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

        public static GuarantorLoanApproval DataRowToObject(DataRow dr)
        {
            GuarantorLoanApproval TheGuarantorLoanApproval = new GuarantorLoanApproval();

            TheGuarantorLoanApproval.GuarantorLoanApprovalID = int.Parse(dr["GuarantorLoanApprovalID"].ToString());
            TheGuarantorLoanApproval.GuarantorLoanApplicationID = int.Parse(dr["GuarantorLoanApplicationID"].ToString());
            TheGuarantorLoanApproval.LoanApplicationNumber = dr["LoanApplicationNumber"].ToString();
            TheGuarantorLoanApproval.LoanApprovalDate = DateTime.Parse(dr["LoanApprovalDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheGuarantorLoanApproval.LoanApprovalAmount = decimal.Parse(dr["LoanApprovalAmount"].ToString());
            TheGuarantorLoanApproval.LoanApprovedTenureInMonths = int.Parse(dr["LoanApprovedTenureInMonths"].ToString());
            TheGuarantorLoanApproval.LoanApprovedRateOfInterest = decimal.Parse(dr["LoanApprovedRateOfInterest"].ToString());
            TheGuarantorLoanApproval.LoanApplicantName = dr["LoanApplicantName"].ToString();

            return TheGuarantorLoanApproval;
        }

        public static List<GuarantorLoanApproval> GetAllUnpaidApproveLoanList(bool allOffices = true)
        {
            List<GuarantorLoanApproval> GuarantorApprovedLoanList = new List<GuarantorLoanApproval>();

            DataTable GetGuarantorApprovedLoanTable = GuarantorLoanApprovalDataAccess.GetInstance.GetAllUnpaidApproveLoanList(allOffices);

            foreach (DataRow dr in GetGuarantorApprovedLoanTable.Rows)
            {
                GuarantorLoanApproval TheGuarantorApprovedLoan = DataRowToObject(dr);

                GuarantorApprovedLoanList.Add(TheGuarantorApprovedLoan);
            }
            return GuarantorApprovedLoanList;
        }

        public static GuarantorLoanApproval GetAllApproveLoanDetailByID(int GuarantorLoanApprovalID)
        {
            DataRow GetApprovalLoanDetailsTable = GuarantorLoanApprovalDataAccess.GetInstance.GetAllApproveLoanDetailByID(GuarantorLoanApprovalID);

            GuarantorLoanApproval TheLoanApplicationDetails = DataRowToObject(GetApprovalLoanDetailsTable);

            return TheLoanApplicationDetails;
        }

        public static int InsertGuarantorLoanApproval(GuarantorLoanApproval theLoanApproval)
        {
            return GuarantorLoanApprovalDataAccess.GetInstance.InsertGuarantorLoanApproval(theLoanApproval);
        }

        #endregion
    }
}
