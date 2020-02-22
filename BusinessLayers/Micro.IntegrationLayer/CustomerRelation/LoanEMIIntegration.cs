using System;
using System.Linq;
using System.Collections.Generic;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class LoanEMIIntegration
	{
		public static double GetLoanEMIAmount(double rateOfInterest, double tenureInMonths, double loanAmount)
		{
			//The monthly payment can be found by using the following formula:
			//  P = (Pv*R) / [1 - (1 + R)^(-n)] 
			//where
			//  P   = Monthly Payment
			//  Pv  = Present Value (beginning value or amount of loan)
			//  R   = Periodic Interest Rate (Annual Percentage Rate / No of interest periods per year)
			//  n   = No of interest periods for overall time period (i.e., interest periods per year * number of years)

			double ReturnValue;

			double P;
			double Pv = loanAmount;
			double R = ((rateOfInterest / 100) / 12);
			double n = tenureInMonths;

			P = (Pv * R) / (1 - Math.Pow((1 + R), (-n)));

			ReturnValue = P;

			return ReturnValue;
		}

		public static List<LoanEMI> GetLoanEMIChart(decimal rateOfInterest, decimal tenureInMonths, decimal loanAmount)
		{
			List<LoanEMI> TheLoanEMIChart = new List<LoanEMI>();

			double RateOfInterest = double.Parse(((rateOfInterest / 100) / 12).ToString());
			double Tenure = double.Parse(tenureInMonths.ToString());
			double PrincipalAmount = double.Parse(loanAmount.ToString());

			double EMIAmount = Math.Round(GetLoanEMIAmount(double.Parse(rateOfInterest.ToString()), Tenure, PrincipalAmount), 0);
			double EMIInterest = 0;
			double EMIPrincipal = 0;
			double EMIOutstandings = PrincipalAmount;

			double TotalInterestPayable=0;
			double TotalPrincipalPayable=0;
			double TotalPayable=0;

			for(int Counter = 1;Counter <= Tenure;Counter++)
			{
				if(Counter < Tenure)
				{
					EMIInterest = Math.Round((EMIOutstandings * RateOfInterest), 0);
					EMIPrincipal = EMIAmount - EMIInterest;
					EMIOutstandings = Math.Round((EMIOutstandings - EMIPrincipal), 0);

					TotalInterestPayable = TotalInterestPayable + EMIInterest;
					TotalPrincipalPayable = TotalPrincipalPayable + EMIPrincipal;
					TotalPayable = TotalPrincipalPayable + TotalInterestPayable;

					LoanEMI TheLoanEMI = new LoanEMI
					{
						EMINumber = Counter,
						EMIAmount = decimal.Parse(EMIAmount.ToString()),
						InterestAmount = decimal.Parse(EMIInterest.ToString()),
						PrincipalReduction = decimal.Parse(EMIPrincipal.ToString()),
						BalanceDue = decimal.Parse(EMIOutstandings.ToString()),
						TotalInterestPayable = decimal.Parse(TotalInterestPayable.ToString()),
						TotalPrincipalPayable = decimal.Parse(TotalPrincipalPayable.ToString()),
						TotalPayable = decimal.Parse(TotalPayable.ToString()),
						RoundOff = 0
					};

					TheLoanEMIChart.Add(TheLoanEMI);
				}
				else
				{
					EMIInterest = Math.Round((EMIOutstandings * RateOfInterest), 0);
					EMIPrincipal = EMIAmount - EMIInterest;
					EMIOutstandings = Math.Round((EMIOutstandings - EMIPrincipal), 0);

					EMIInterest = EMIInterest - EMIOutstandings;
					EMIPrincipal = EMIPrincipal + EMIOutstandings;

					TotalInterestPayable = TotalInterestPayable + EMIInterest;
					TotalPrincipalPayable = TotalPrincipalPayable + EMIPrincipal;
					TotalPayable = TotalPrincipalPayable + TotalInterestPayable;

					LoanEMI TheLoanEMI = new LoanEMI
					{
						EMINumber = Counter,
						EMIAmount = decimal.Parse(EMIAmount.ToString()),
						InterestAmount = decimal.Parse(EMIInterest.ToString()),
						PrincipalReduction = decimal.Parse(EMIPrincipal.ToString()),
						BalanceDue = 0,
						TotalInterestPayable = decimal.Parse(TotalInterestPayable.ToString()),
						TotalPrincipalPayable = decimal.Parse(TotalPrincipalPayable.ToString()),
						TotalPayable = decimal.Parse(TotalPayable.ToString()),
						RoundOff = decimal.Parse(EMIOutstandings.ToString())
					};

					TheLoanEMIChart.Add(TheLoanEMI);
				}
			}

			return TheLoanEMIChart;
		}

		public static LoanEMI GetLoanEMIByEMINumber(decimal rateOfInterest, decimal tenureInMonths, decimal loanAmount, int emiNumber)
		{
			LoanEMI TheLoanEMI = new LoanEMI();

			var TheLoanEMIChart = from LoanEMIChart in GetLoanEMIChart(rateOfInterest, tenureInMonths, loanAmount)
								  where LoanEMIChart.EMINumber == emiNumber
								  select LoanEMIChart;

			foreach(LoanEMI EachEMI in TheLoanEMIChart)
			{
				TheLoanEMI = EachEMI;
			}

			return TheLoanEMI;
		}

		public static LoanEMI GetLoanEMIByEMINumber(List<LoanEMI> theLoanEMIChart, int emiNumber)
		{
			LoanEMI TheLoanEMI = new LoanEMI();

			var TheLoanEMIChart = from LoanEMIChart in theLoanEMIChart
								  where LoanEMIChart.EMINumber == emiNumber
								  select LoanEMIChart;

			foreach(LoanEMI EachEMI in TheLoanEMIChart)
			{
				TheLoanEMI = EachEMI;
			}

			return TheLoanEMI;
		}

		public static LoanEMI GetLoanSettlement(decimal rateOfInterest, decimal tenureInMonths, decimal loanAmount, int installmentsPaid)
		{
			decimal TotalInterestAmountDue = (from LoanEMIChart in GetLoanEMIChart(rateOfInterest, tenureInMonths, loanAmount)
											  where LoanEMIChart.EMINumber > installmentsPaid && LoanEMIChart.EMINumber <= 12
											  select LoanEMIChart.InterestAmount).Sum();

			decimal TotalPrincipalAmountDue= (from LoanEMIChart in GetLoanEMIChart(rateOfInterest, tenureInMonths, loanAmount)
											  where LoanEMIChart.EMINumber == installmentsPaid
											  select LoanEMIChart.BalanceDue).First();
			LoanEMI TheLoanEMI = new LoanEMI();

			TheLoanEMI.EMINumber = installmentsPaid + 1;
			TheLoanEMI.EMIAmount = TheLoanEMI.PrincipalReduction + TheLoanEMI.InterestAmount;
			TheLoanEMI.PrincipalReduction = TotalPrincipalAmountDue;
			TheLoanEMI.InterestAmount = TotalInterestAmountDue;
			TheLoanEMI.BalanceDue = 0;
			TheLoanEMI.RoundOff = 0;

			return TheLoanEMI;
		}
	}
}
