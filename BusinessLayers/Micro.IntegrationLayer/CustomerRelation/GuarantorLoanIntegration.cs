using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class GuarantorLoanIntegration
	{
		#region Declaration
		#endregion

		#region Methods & Implementation
        public static GuarantorLoan DataRowToObject(DataRow dr)
        {
            GuarantorLoan TheGuarantorLoan = new GuarantorLoan();

            TheGuarantorLoan.GuarantorLoanID = int.Parse(dr["GuarantorLoanID"].ToString());
            //TheGuarantorLoan.GuarantorLoanCode=dr["GuarantorLoanCode"].ToString();
            TheGuarantorLoan.GuarantorLoanApplicationID = int.Parse(dr["GuarantorLoanApplicationID"].ToString());
            TheGuarantorLoan.LoanIssueDate = DateTime.Parse(dr["LoanIssueDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheGuarantorLoan.LoanAppliedBy = dr["LoanAppliedBy"].ToString();
            TheGuarantorLoan.LoanApplicantID = int.Parse(dr["LoanApplicantID"].ToString());
            TheGuarantorLoan.LoanApplicantName = dr["LoanApplicantName"].ToString();
            TheGuarantorLoan.LoanApplicationNumber = dr["LoanApplicationNumber"].ToString();
            TheGuarantorLoan.LoanApplicationDate = DateTime.Parse(dr["LoanApplicationDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheGuarantorLoan.LoanApplicationFee = decimal.Parse(dr["LoanApplicationFee"].ToString());
            TheGuarantorLoan.RequiredFor = dr["RequiredFor"].ToString();
            TheGuarantorLoan.LoanAmountApplied = decimal.Parse(dr["LoanAmountApplied"].ToString());
            TheGuarantorLoan.LoanAmount = decimal.Parse(dr["LoanAmount"].ToString());
            TheGuarantorLoan.RateOfInterest = decimal.Parse(dr["RateOfInterest"].ToString());
            TheGuarantorLoan.InstallmentType = dr["InstallmentType"].ToString();
            TheGuarantorLoan.TenureInMonths = int.Parse(dr["TenureInMonths"].ToString());
            TheGuarantorLoan.EMIStartsFromDate = DateTime.Parse(dr["EMIStartsFromDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheGuarantorLoan.IsClosed = bool.Parse(dr["IsClosed"].ToString());
            if (TheGuarantorLoan.IsClosed)
                TheGuarantorLoan.ClosureDate = DateTime.Parse(dr["ClosureDate"].ToString()).ToString(MicroConstants.DateFormat);


            return TheGuarantorLoan;
        }

        public static List<GuarantorLoan> GetGuarantorLoanList(bool allOffices = true, bool showDeleted = false, bool showClosed = false)
		{
			List<GuarantorLoan> GuarantorLoanList = new List<GuarantorLoan>();

			DataTable GetGuarantorLoanTable =  GuarantorLoanDataAccess.GetInstance.GetGuarantorLoanList(allOffices,showDeleted,showClosed);

			foreach(DataRow dr in GetGuarantorLoanTable.Rows)
			{
                GuarantorLoan TheGuarantorLoan = DataRowToObject(dr);

				GuarantorLoanList.Add(TheGuarantorLoan);
			}
			return GuarantorLoanList;
		}

        //public static List<GuarantorLoan> GetGuarantorLoans(string loanAppliedBy, string officeIds)
        //{
        //    var GuarantorLoans = (from TheLoans in GetGuarantorLoanList()
        //                                    where TheLoans.LoanAppliedBy == loanAppliedBy
        //                                    && officeIds.Contains((TheLoans.OfficeID).ToString())
        //                                    select TheLoans).ToList();

        //    List<GuarantorLoan> GuarantorLoanList = new List<GuarantorLoan>();

        //    foreach(GuarantorLoan TheLoan in GuarantorLoans)
        //    {
        //        GuarantorLoan TheGuarantorLoan = new GuarantorLoan();

        //        TheGuarantorLoan.GuarantorLoanID = TheLoan.GuarantorLoanID;
        //        TheGuarantorLoan.GuarantorLoanApplicationID = TheLoan.GuarantorLoanApplicationID;
        //        TheGuarantorLoan.LoanAppliedBy = TheLoan.LoanAppliedBy;
        //        TheGuarantorLoan.LoanApplicantID = TheLoan.LoanApplicantID;
        //        TheGuarantorLoan.LoanApplicantName = TheLoan.LoanApplicantName;
        //        TheGuarantorLoan.LoanApplicationNumber = TheLoan.LoanApplicationNumber;
        //        TheGuarantorLoan.LoanApplicationDate = TheLoan.LoanApplicationDate;
        //        TheGuarantorLoan.LoanApplicationFee = TheLoan.LoanApplicationFee;
        //        TheGuarantorLoan.RequiredFor = TheLoan.RequiredFor;
        //        TheGuarantorLoan.LoanAmountApplied = TheLoan.LoanAmountApplied;
        //        TheGuarantorLoan.LoanIssueDate = TheLoan.LoanIssueDate;
        //        TheGuarantorLoan.LoanAmount = TheLoan.LoanAmount;
        //        TheGuarantorLoan.RateOfInterest = TheLoan.RateOfInterest;
        //        TheGuarantorLoan.InstallmentType =TheLoan.InstallmentType;
        //        TheGuarantorLoan.TenureInMonths = TheLoan.TenureInMonths;
        //        TheGuarantorLoan.EMIStartsFromDate =TheLoan.EMIStartsFromDate;
        //        TheGuarantorLoan.IsClosed = TheLoan.IsClosed;
        //        if(TheGuarantorLoan.IsClosed)
        //            TheGuarantorLoan.ClosureDate = TheLoan.ClosureDate;

        //        GuarantorLoanList.Add(TheGuarantorLoan);
        //    }
        //    return GuarantorLoanList;
        //}
        
        public static List<GuarantorLoan> GetAllPreviousLoanDetailByID(int LoanApplicantID, string LoanAppliedBy)
        {
            List<GuarantorLoan> GuarantorPreviousLoanDetailsList = new List<GuarantorLoan>();

            DataTable GetGuarantorPreviousLoanDetails = GuarantorLoanDataAccess.GetInstance.GetAllPreviousLoanDetailByID(LoanApplicantID, LoanAppliedBy);

            foreach (DataRow dr in GetGuarantorPreviousLoanDetails.Rows)
            {
                GuarantorLoan TheGuarantorPreviousLoanDetails = DataRowToObject(dr);

                GuarantorPreviousLoanDetailsList.Add(TheGuarantorPreviousLoanDetails);
            }
            return GuarantorPreviousLoanDetailsList;
        }

        public static List<GuarantorLoan> GetGuarantorLoansByOfficeID(bool allOffices, string officeIds)
        {
            List<GuarantorLoan> GuarantorLoanList = new List<GuarantorLoan>();

            DataTable GetGuarantorLoanTable = GuarantorLoanDataAccess.GetInstance.GetGuarantorLoansByOfficeID(allOffices, officeIds);

            foreach (DataRow dr in GetGuarantorLoanTable.Rows)
            {
                GuarantorLoan TheGuarantorLoan = DataRowToObject(dr);


                GuarantorLoanList.Add(TheGuarantorLoan);
            }
            return GuarantorLoanList;
        }

        public static GuarantorLoan GetPreviousLoanDetails(int LoanApplicantID, string RecordValue)
		{
            DataRow GetPreviousLoanTable = GuarantorLoanDataAccess.GetInstance.GetPreviousLoanDetails(LoanApplicantID, RecordValue);

            GuarantorLoan ThePreviousLoanDetails = DataRowToObject(GetPreviousLoanTable);

			return ThePreviousLoanDetails;
		}

        public static GuarantorLoan GetEMIChartDetails(int LoanApplicantID)
		{
            DataRow GetLoanApplicationTable = GuarantorLoanDataAccess.GetInstance.GetEMIChartDetails(LoanApplicantID);

            GuarantorLoan TheLoanApplicationDetails = DataRowToObject(GetLoanApplicationTable);

			
			return TheLoanApplicationDetails;
		}

		public static List<GuarantorLoan> EMITable(double RateOfInterest, double Tenure, double PrincipalAmount, double Emiamount)
		{
			List<GuarantorLoan> EMITableList = new List<GuarantorLoan>();

			DataTable GetEMITable = new DataTable();

			GetEMITable = GuarantorLoanDataAccess.GetInstance.EMITable(RateOfInterest, Tenure, PrincipalAmount, Emiamount);

			foreach(DataRow dr in GetEMITable.Rows)
			{
				GuarantorLoan TheGuarantorLoan = new GuarantorLoan();

				TheGuarantorLoan.Interestrate = double.Parse(dr["RateOfInterest"].ToString());
				TheGuarantorLoan.Tenure = double.Parse(dr["Tenure"].ToString());
				TheGuarantorLoan.PrincipalAmount = double.Parse(dr["PrincipalAmount"].ToString());
				TheGuarantorLoan.Emiamount = double.Parse(dr["Emiamount"].ToString());

                EMITableList.Add(TheGuarantorLoan);
			}
			return EMITableList;

		}

        public static GuarantorLoan GetGuarantorLoanDetails(int GuarantorLoanID)
        {
            DataRow GetGuarantorLoanTable = GuarantorLoanDataAccess.GetInstance.GetGuarantorLoanDetails(GuarantorLoanID);

            GuarantorLoan TheLoanGuarantorLoanDetails = DataRowToObject(GetGuarantorLoanTable);

            return TheLoanGuarantorLoanDetails;

        }

        public static List<GuarantorLoan> GetGuarantorLoansByLoanAppliedBy(string loanAppliedBy, bool allOffices, string officeIds)
        {
            List<GuarantorLoan> GuarantorLoanList = new List<GuarantorLoan>();

            DataTable GetGuarantorLoanTable = GuarantorLoanDataAccess.GetInstance.GetGuarantorLoansByLoanAppliedBy(loanAppliedBy, allOffices, officeIds);

            foreach (DataRow dr in GetGuarantorLoanTable.Rows)
            {
                GuarantorLoan TheGuarantorLoan = DataRowToObject(dr);

                GuarantorLoanList.Add(TheGuarantorLoan);
            }
            return GuarantorLoanList;
        }

		public static int InsertGuarantorLoan(GuarantorLoan theGuarantorLoan)
		{
			return GuarantorLoanDataAccess.GetInstance.InsertGuarantorLoan(theGuarantorLoan);
		}

		public static int UpdateGuarantorLoan(GuarantorLoan theGuarantorLoan)
		{
			return GuarantorLoanDataAccess.GetInstance.UpdateGuarantorLoan(theGuarantorLoan);
		}

		public static int DeleteGuarantorLoan(GuarantorLoan theGuarantorLoan)
		{
			return GuarantorLoanDataAccess.GetInstance.DeleteGuarantorLoan(theGuarantorLoan);
		}

        public static GuarantorLoan GetGuarantorLoansById(int GuarantorLoanID)
		{
            DataRow GuarantorLoanRow = GuarantorLoanDataAccess.GetInstance.GetGuarantorLoansById(GuarantorLoanID);

            GuarantorLoan TheGuarantorLoan = DataRowToObject(GuarantorLoanRow);

            return TheGuarantorLoan;
		}
		#endregion
	}
}
