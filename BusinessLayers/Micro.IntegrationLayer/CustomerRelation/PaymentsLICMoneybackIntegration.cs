using System;
using System.Collections.Generic;
using System.Linq;
using Micro.Objects.CustomerRelation;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class PaymentsLICMoneybackIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementations
        internal static PaymentsLICMoneyback DataRowToObject(DataRow dr)
        {
            PaymentsLICMoneyback TheLICMoneybackPayment = new PaymentsLICMoneyback();
            {
                TheLICMoneybackPayment.LICMoneyBackID = int.Parse(dr["LICMoneyBackID"].ToString());
                TheLICMoneybackPayment.CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString());
                TheLICMoneybackPayment.CustomerAccountCode = dr["CustomerAccountCode"].ToString();
                TheLICMoneybackPayment.CustomerName = dr["CustomerName"].ToString();
                TheLICMoneybackPayment.DueDateOfPayment = DateTime.Parse(dr["DueDateOfPayment"].ToString()).ToString(MicroConstants.DateFormat);
                TheLICMoneybackPayment.MoneyBackPayable = decimal.Parse(dr["MoneyBackPayable"].ToString());
                TheLICMoneybackPayment.MoneyBackDescription = dr["MoneyBackDescription"].ToString();
                if (!string.IsNullOrEmpty(dr["ActualDateOfPayment"].ToString()))
                    TheLICMoneybackPayment.ActualDateOfPayment = DateTime.Parse(dr["ActualDateOfPayment"].ToString()).ToString(MicroConstants.DateFormat);
                TheLICMoneybackPayment.ActualMoneyBackAmountPaid = decimal.Parse(MicroGlobals.ReturnZeroIfNull(dr["ActualMoneyBackAmountPaid"].ToString()));
                TheLICMoneybackPayment.PaymentStatus = dr["PaymentStatus"].ToString();
            }

            return TheLICMoneybackPayment;
        }

        public static List<PaymentsLICMoneyback> GetLICMoneybackPaymentsListByCustomerAccountID(int customerAccountID)
        {
            List<PaymentsLICMoneyback> LICMoneybackPaymentList = new List<PaymentsLICMoneyback>();
            DataTable LICMoneybackPaymentTable = PaymentsLICMoneybackDataAccess.GetInstance.GetLICMoneybackPaymentsListByCustomerAccountID(customerAccountID);

            foreach (DataRow dr in LICMoneybackPaymentTable.Rows)
            {
                PaymentsLICMoneyback TheLICMoneybackPayment = DataRowToObject(dr);

                LICMoneybackPaymentList.Add(TheLICMoneybackPayment);
            }

            return LICMoneybackPaymentList;
        }

        public static List<PaymentsLICMoneyback> GetLICMoneybackPaymentsStatusListByCustomerAccountID(string paymentStatus, int customerAccountID)
        {
            List<PaymentsLICMoneyback> TheMoneybackPaymentList = new List<PaymentsLICMoneyback>();

            var MoneybackPaymentList = (from LICMoneybackPayments in GetLICMoneybackPaymentsListByCustomerAccountID(customerAccountID)
                                        where LICMoneybackPayments.PaymentStatus == paymentStatus
                                        select LICMoneybackPayments);

            foreach (PaymentsLICMoneyback TheLICMoneybackPayments in MoneybackPaymentList)
            {
                PaymentsLICMoneyback ThePaymentsLICMoneyback = (PaymentsLICMoneyback)TheLICMoneybackPayments;

                TheMoneybackPaymentList.Add(ThePaymentsLICMoneyback);
            }

            return TheMoneybackPaymentList;
        }

        public static List<PaymentsLICMoneyback> GetLICMoneybackPaymentsDueListByCustomerAccountID(DateTime dueDateOfPayment, int customerAccountID)
        {
            List<PaymentsLICMoneyback> TheMoneybackPaymentList = new List<PaymentsLICMoneyback>();

            var MoneybackPaymentList = (from LICMoneybackPayments in GetLICMoneybackPaymentsListByCustomerAccountID(customerAccountID)
                                        where (DateTime.Parse(LICMoneybackPayments.DueDateOfPayment) <= dueDateOfPayment)
                                        && LICMoneybackPayments.PaymentStatus == "Due"
                                        select LICMoneybackPayments);

            foreach (PaymentsLICMoneyback TheLICMoneybackPayments in MoneybackPaymentList)
            {
                PaymentsLICMoneyback ThePaymentsLICMoneyback = (PaymentsLICMoneyback)TheLICMoneybackPayments;

                TheMoneybackPaymentList.Add(ThePaymentsLICMoneyback);
            }

            return TheMoneybackPaymentList;
        }

        public static int UpdateLICMoneyBackPayment(List<PaymentsLICMoneyback> paymentsLICMoneyBackList)
        {
            return PaymentsLICMoneybackDataAccess.GetInstance.UpdateLICMoneyBackPayment(paymentsLICMoneyBackList);
        }
        #endregion
    }
}
