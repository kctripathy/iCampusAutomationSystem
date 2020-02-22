using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial class GuarantorLoanRecoveryIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

       public static GuarantorLoanRecoveries DataRowToObject(DataRow dr)
       {
           GuarantorLoanRecoveries TheGuarantorLoanRecoveries = new GuarantorLoanRecoveries();

           TheGuarantorLoanRecoveries.GuarantorLoanReceiptID = int.Parse(dr["GuarantorLoanReceiptID"].ToString());
           TheGuarantorLoanRecoveries.ReceiptSeries = dr["ReceiptSeries"].ToString();
           TheGuarantorLoanRecoveries.GuarantorLoanReceiptNumber=dr["GuarantorLoanReceiptNumber"].ToString();
           TheGuarantorLoanRecoveries.GuarantorLoanID = int.Parse(dr["GuarantorLoanID"].ToString());
           TheGuarantorLoanRecoveries.DateOfRecovery = DateTime.Parse(dr["DateOfRecovery"].ToString()).ToString(MicroConstants.DateFormat);
           TheGuarantorLoanRecoveries.AmountPaid = Decimal.Parse(dr["AmountPaid"].ToString());
           TheGuarantorLoanRecoveries.AmountPaidAsPrincipal = Decimal.Parse(dr["AmountPaidAsPrincipal"].ToString());
           TheGuarantorLoanRecoveries.AmountPaidAsInterest = Decimal.Parse(dr["AmountPaidAsInterest"].ToString());
           TheGuarantorLoanRecoveries.InstallmentNumber = int.Parse(dr["InstallmentNumber"].ToString());
           TheGuarantorLoanRecoveries.Remark = dr["Remark"].ToString();
           TheGuarantorLoanRecoveries.PaymentMode = dr["PaymentMode"].ToString();
           TheGuarantorLoanRecoveries.PaymentReference = dr["PaymentReference"].ToString();

           return TheGuarantorLoanRecoveries;
       }

        public static List<GuarantorLoanRecoveries> GetGuarantorLoanRecoveries(string searchText)
       {
           List<GuarantorLoanRecoveries> GuarantorLoanRecoveriesList = new List<GuarantorLoanRecoveries>();

           DataTable GuarantorLoanRecoveryTable = GuarantorLoanRecoveryDataAccess.GetInstance.GetGuarantorLoanRecoveries(searchText);

           foreach (DataRow dr in GuarantorLoanRecoveryTable.Rows)
           {
               GuarantorLoanRecoveries TheGuarantorLoanRecoveries = DataRowToObject(dr);


               GuarantorLoanRecoveriesList.Add(TheGuarantorLoanRecoveries);
           }
           return GuarantorLoanRecoveriesList;
       }

        public static List<GuarantorLoanRecoveries> GetActiveLoanDetails(int loanApplicantId, string loanAppliedBy)
        {
			List<GuarantorLoanRecoveries> GuarantorLoanRecoveriesList = new List<GuarantorLoanRecoveries>();

			DataTable GuarantorLoanRecoveryTable = GuarantorLoanRecoveryDataAccess.GetInstance.GetActiveLoanDetails(loanApplicantId, loanAppliedBy);

			foreach (DataRow dr in GuarantorLoanRecoveryTable.Rows)
			{
				GuarantorLoanRecoveries TheGuarantorLoanRecoveries = new GuarantorLoanRecoveries();

				TheGuarantorLoanRecoveries.GuarantorLoanID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["GuarantorLoanID"].ToString()));
					if (TheGuarantorLoanRecoveries.GuarantorLoanID != 0)
					{
					TheGuarantorLoanRecoveries.GuarantorLoanCode = dr["GuarantorLoanCode"].ToString();
					TheGuarantorLoanRecoveries.LoanApplicationDate = DateTime.Parse(dr["LoanApplicationDate"].ToString()).ToString(MicroConstants.DateFormat);
					TheGuarantorLoanRecoveries.LoanIssueDate = DateTime.Parse(dr["LoanIssueDate"].ToString()).ToString(MicroConstants.DateFormat);
					if (TheGuarantorLoanRecoveries.LastRecoveryDate != null)
					{
						TheGuarantorLoanRecoveries.LastRecoveryDate = DateTime.Parse(dr["LastRecoveryDate"].ToString()).ToString(MicroConstants.DateFormat);
					}
					TheGuarantorLoanRecoveries.LoanAmount = decimal.Parse(MicroGlobals.ReturnZeroIfNull(dr["LoanAmount"].ToString()));
					TheGuarantorLoanRecoveries.DuePrincipalAmount = decimal.Parse(MicroGlobals.ReturnZeroIfNull(dr["DuePrincipalAmount"].ToString()));
					TheGuarantorLoanRecoveries.DueInterestAmount = decimal.Parse(MicroGlobals.ReturnZeroIfNull(dr["DueInterestAmount"].ToString()));
					TheGuarantorLoanRecoveries.InterestPaid = decimal.Parse(MicroGlobals.ReturnZeroIfNull(dr["InterestPaid"].ToString()));
					TheGuarantorLoanRecoveries.LoanAmountRecovered = decimal.Parse(MicroGlobals.ReturnZeroIfNull(dr["LoanAmountRecovered"].ToString()));
					TheGuarantorLoanRecoveries.NumberOfInstallmentsPaid = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["NumberOfInstallmentsPaid"].ToString()));

					GuarantorLoanRecoveriesList.Add(TheGuarantorLoanRecoveries);
				}
			}
			return GuarantorLoanRecoveriesList;

        }

        public static List<GuarantorLoanRecoveries> GetGuarantorLoanRecoveriesByGuarantorLoanId(int guarantorloanId)
        {
            List<GuarantorLoanRecoveries> GuarantorLoanRecoveriesList = new List<GuarantorLoanRecoveries>();
            DataTable GuarantorLoanRecoveryTable = GuarantorLoanRecoveryDataAccess.GetInstance.GetGuarantorLoanRecoveriesByGuarantorLoanId(guarantorloanId);

            foreach (DataRow dr in GuarantorLoanRecoveryTable.Rows)
            {
                GuarantorLoanRecoveries TheGuarantorLoanRecoveries = DataRowToObject(dr);

                GuarantorLoanRecoveriesList.Add(TheGuarantorLoanRecoveries);
            }
            return GuarantorLoanRecoveriesList;
        }
        
        public static bool GetGuarantorLoanRecoveriesByGuarantorLoanId(int guarantorloanId, decimal loanAmount)
        {
            var GuarantorLoanRecovery = false;
            List<GuarantorLoanRecoveries> TheGuarantorLoanRecoveriesList =  GetGuarantorLoanRecoveriesByGuarantorLoanId(guarantorloanId);

            if (TheGuarantorLoanRecoveriesList.Count > 0)
            {
                GuarantorLoanRecovery = (from TheLoanRecovery in TheGuarantorLoanRecoveriesList
                                             select TheLoanRecovery.AmountPaidAsPrincipal).Sum() == loanAmount;
            }

            return GuarantorLoanRecovery;                            
        }

        public static GuarantorLoanRecoveries GetGuarantorLoanRecoveriesById(int recordId)
        {
            DataRow GuarantorLoanRecoveryRow = GuarantorLoanRecoveryDataAccess.GetInstance.GetGuarantorLoanRecoveriesById(recordId);

            GuarantorLoanRecoveries TheGuarantorLoanRecoveries = DataRowToObject(GuarantorLoanRecoveryRow);

            return TheGuarantorLoanRecoveries;
        }

        public static List<GuarantorLoanRecoveries> GetLoanHistoryDetails(int RecordID)
        {
            List<GuarantorLoanRecoveries> GuarantorLoanHistoryDetailsList = new List<GuarantorLoanRecoveries>();

            DataTable GetLoanHistoryDetails = new DataTable();
            GetLoanHistoryDetails = GuarantorLoanRecoveryDataAccess.GetInstance.GetLoanHistoryDetails(RecordID);

            foreach (DataRow dr in GetLoanHistoryDetails.Rows)
            {
                GuarantorLoanRecoveries TheLoanHistoryDetails = DataRowToObject(dr);

                GuarantorLoanHistoryDetailsList.Add(TheLoanHistoryDetails);
            }
            return GuarantorLoanHistoryDetailsList;
        }


        public static int InsertGuarantorLoanRecovery(GuarantorLoanRecoveries theGuarantorLoanRecovery)
        {
            return GuarantorLoanRecoveryDataAccess.GetInstance.InsertGuarantorLoanRecovery(theGuarantorLoanRecovery);
        }

        public static int UpdateGuarantorLoanRecovery(GuarantorLoanRecoveries theGuarantorLoanRecovery)
        {
            return GuarantorLoanRecoveryDataAccess.GetInstance.UpdateGuarantorLoanRecovery(theGuarantorLoanRecovery);
        }

        public static int DeleteGuarantorLoanRecovery(GuarantorLoanRecoveries theGuarantorLoanRecovery)
        {
            return GuarantorLoanRecoveryDataAccess.GetInstance.DeleteGuarantorLoanRecovery(theGuarantorLoanRecovery);
        }
        #endregion
    }
}
