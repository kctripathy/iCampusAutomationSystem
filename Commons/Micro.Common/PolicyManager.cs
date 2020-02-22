using System;

namespace Micro.Commons
{
    /// <summary>
    /// Manages Customer Account / Policy
    /// </summary>
    /// <author> Syed Ameer </author>
    /// <date> 15-Feb-2012 </date>

    public static class PolicyManager
    {
        /// <summary>
        /// Returns number of installments to be paid on each intervals of mode.
        /// </summary>
        /// <param name="policyMode">The installment mode. e.g. Mly.</param>
        /// <param name="conversionType">Return type. May be Installments or Intervals.</param>
        /// <returns></returns>
        public static int PolicyModeToNumber(string policyMode, MicroEnums.PolicyModeConversionType conversionType)
        {
            int ReturnValue = 1;

            if (conversionType.Equals(MicroEnums.PolicyModeConversionType.Installments))
            {
                if (policyMode.Equals(MicroEnums.GetStringValue(MicroEnums.PolicyMode.Mly)))
                    ReturnValue = 12;

                else if (policyMode.Equals(MicroEnums.GetStringValue(MicroEnums.PolicyMode.Qly)))
                    ReturnValue = 4;

                else if (policyMode.Equals(MicroEnums.GetStringValue(MicroEnums.PolicyMode.Hly)))
                    ReturnValue = 2;

				else
					ReturnValue = 1;
            }

			else if (conversionType.Equals(MicroEnums.PolicyModeConversionType.Intervals))
            {
                if (policyMode.Equals(MicroEnums.GetStringValue(MicroEnums.PolicyMode.Mly)))
                    ReturnValue = 1;

                else if (policyMode.Equals(MicroEnums.GetStringValue(MicroEnums.PolicyMode.Qly)))
                    ReturnValue = 3;

                else if (policyMode.Equals(MicroEnums.GetStringValue(MicroEnums.PolicyMode.Hly)))
                    ReturnValue = 6;

				else
					ReturnValue = 12;
            }

            return ReturnValue;
        }

        /// <summary>
        /// Returns total number of installments to be paid.
        /// </summary>
        /// <param name="policyMode">The installment mode. e.g. Mly.</param>
        /// <param name="termInMonths">Tenure of a policy in terms of month.</param>
        /// <returns></returns>
        public static int InstallmentsToBePaid(string policyMode, int termInMonths)
        {
            int ReturnValue = 1;

            if (!policyMode.Equals(MicroEnums.GetStringValue(MicroEnums.PolicyMode.OneTime)))
            {
                int Intervals = PolicyModeToNumber(policyMode, MicroEnums.PolicyModeConversionType.Intervals);
                ReturnValue = termInMonths / Intervals;
            }

            return ReturnValue;
        }

		/// <summary>
		/// Returns Commencement Date (Specially in case of revived customer account)
		/// </summary>
		/// <param name="dueDateofMaturity">Redemption date of the policy.</param>
		/// <param name="termInMonths">Tenure of a policy in terms of month.</param>
		/// <returns></returns>
		public static DateTime DateofCommencement(DateTime dueDateofMaturity, int termInMonths)
		{
			DateTime ReturnValue = dueDateofMaturity.AddMonths(-termInMonths);

			return ReturnValue;
		}

        /// <summary>
        /// Returns Redemption date i.e. Date of Maturity.
        /// </summary>
        /// <param name="dateofCommencement">Starting date of the policy.</param>
        /// <param name="termInMonths">Tenure of a policy in terms of month.</param>
        /// <returns></returns>
        public static DateTime DueDateofMaturity(DateTime dateofCommencement, int termInMonths)
        {
            DateTime ReturnValue = dateofCommencement;

            ReturnValue = dateofCommencement.AddMonths(termInMonths);

            return ReturnValue;
        }

        /// <summary>
        /// Returns due date of last installment to be paid.
        /// </summary>
        /// <param name="dateofCommencement">Starting date of the policy.</param>
        /// <param name="policyMode">The installment mode. e.g. Mly.</param>
        /// <param name="termInMonths">Tenure of a policy in terms of month.</param>
        /// <returns></returns>
        public static DateTime DueDateofLastPayment(DateTime dateofCommencement, string policyMode, int termInMonths)
        {
            DateTime ReturnValue = dateofCommencement;

            if (!policyMode.Equals(MicroEnums.GetStringValue(MicroEnums.PolicyMode.OneTime)))
            {
                int Intervals = PolicyModeToNumber(policyMode, MicroEnums.PolicyModeConversionType.Intervals);
                ReturnValue = DueDateofMaturity(dateofCommencement, termInMonths).AddMonths(-Intervals);
            }

            return ReturnValue;
        }

        /// <summary>
        /// Returns number of installment due.
        /// </summary>
        /// <param name="installmentFrom">An integer value specifing installment from number.</param>
        /// <param name="installmentTo">An integer value specifing installment to number</param>
        /// <returns></returns>
        public static int NumberOfInstallmentsDue(int installmentFrom, int installmentTo)
        {
            int ReturnValue = 0;

            if (installmentTo == installmentFrom)
            {
                ReturnValue = 1;
            }
            else
            {
                ReturnValue = ((installmentTo + 1) - installmentFrom);
            }

            return ReturnValue;
        }

        /// <summary>
        /// Returns number of installment due.
        /// </summary>
        /// <param name="dateofCommencement">Starting date of the policy.</param>
        /// <param name="policyMode">The installment mode. e.g. Mly.</param>
        /// <param name="termInMonths">Tenure of a policy in terms of month.</param>
        /// <param name="installmentsPaid">Number of installments already paid.</param>
        /// <param name="dateofPayment">Date of payment.</param>
        /// <returns></returns>
        public static int NumberOfInstallmentsDue(DateTime dateofCommencement, string policyMode, int termInMonths, int installmentsPaid, DateTime dateofPayment)
        {
            int ReturnValue = 0;

            if (!policyMode.Equals(MicroEnums.GetStringValue(MicroEnums.PolicyMode.OneTime)))
            {
                int InstallmentsInterval = (PolicyModeToNumber(policyMode, MicroEnums.PolicyModeConversionType.Intervals));
                int DateDifferenceInMonths = MicroGlobals.GetDateDifferenceInMonths(dateofPayment, dateofCommencement);
                int InstallmentsToBePaid = 0;

                if (DateDifferenceInMonths >= termInMonths)
                    InstallmentsToBePaid = (termInMonths / InstallmentsInterval);
                else
                    InstallmentsToBePaid = ((DateDifferenceInMonths - (DateDifferenceInMonths % InstallmentsInterval)) / InstallmentsInterval);

                if (installmentsPaid < InstallmentsToBePaid)
                    ReturnValue = InstallmentsToBePaid - installmentsPaid;
                else
                    ReturnValue = 0;
            }

            return ReturnValue;
        }

        /// <summary>
        /// Returns due date of an installment for Recurring Deposits.
        /// </summary>
        /// <param name="dateofCommencement">Starting date of the policy.</param>
        /// <param name="policyMode">The installment mode. e.g. Mly.</param>
        /// <param name="installmentNumber">An integer value specifing installment number.</param>
        /// <returns></returns>
        public static DateTime DueDateofInstallment(DateTime dateofCommencement, string policyMode, int installmentNumber)
        {
            DateTime ReturnValue = dateofCommencement;

            if (!policyMode.Equals(MicroEnums.GetStringValue(MicroEnums.PolicyMode.OneTime)))
            {
                int Intervals = PolicyModeToNumber(policyMode, MicroEnums.PolicyModeConversionType.Intervals);
                int DuesInMonths = Intervals * (installmentNumber-1);

                ReturnValue = dateofCommencement.AddMonths(DuesInMonths);
            }

            return ReturnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateofCommencement"></param>
        /// <param name="policyMode"></param>
        /// <param name="termInMonths"></param>
        /// <param name="installmentAmount"></param>
        /// <param name="installmentFrom"></param>
        /// <param name="installmentTo"></param>
        /// <param name="installmentsPaid"></param>
        /// <param name="fineFee"></param>
        /// <param name="gracePeriods"></param>
        /// <param name="dateofPayment"></param>
        /// <returns></returns>
        public static decimal LateFee(DateTime dateofCommencement, string policyMode, int termInMonths, decimal installmentAmount, int installmentFrom, int installmentTo, int installmentsPaid, decimal fineFee, int gracePeriods, DateTime dateofPayment)
        {
            decimal ReturnValue;
            bool IsFineApplicable = false;

            int InstallmentsFinable;
            int TotalInstallments = (NumberOfInstallmentsDue(installmentFrom, installmentTo));
            int TotalInstallmentsDue = NumberOfInstallmentsDue(dateofCommencement, policyMode, termInMonths, installmentsPaid, dateofPayment);

            if (TotalInstallments < TotalInstallmentsDue)
                InstallmentsFinable = TotalInstallments;
            else
                InstallmentsFinable = TotalInstallmentsDue;

            if (TotalInstallmentsDue == 1)
            {
                DateTime InstallmentDueDate = DueDateofInstallment(dateofCommencement, policyMode, installmentFrom);
                int DifferenceInDays = dateofPayment.Subtract(InstallmentDueDate).Days;

                if (DifferenceInDays > gracePeriods)
                    IsFineApplicable = true;
                else
                    IsFineApplicable = false;

                //TODO: Check Escapes (Who deposits installments in two parts in same months to save fine.)
            }


            if (TotalInstallments < (TotalInstallmentsDue * 2))
                IsFineApplicable = true;
            else
                IsFineApplicable = false;

            if (IsFineApplicable)
                ReturnValue = ((InstallmentsFinable * fineFee) * installmentAmount);
            else
                ReturnValue = 0;

            return ReturnValue;
        }

		/// <summary>
		/// Returns Policy Type Description of given policy.
		/// </summary>
		/// <param name="installmentMode">Installment Mode</param>
		/// <param name="policyName">Policy Name</param>
		/// <returns></returns>
		public static string PolicyTypeDescription(string installmentMode, string policyName)
		{
			string ReturnValue = string.Format("{0} {1}", installmentMode, policyName);

			return ReturnValue;
		}
    }
}
