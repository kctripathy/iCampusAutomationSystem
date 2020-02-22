using System;
using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class PaymentsMediclaimIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementations
        public static MediclaimPayment DataRowToObject(DataRow dr)
        {
            MediclaimPayment TheMediclaimPayment = new MediclaimPayment();

            TheMediclaimPayment.MediclaimPaymentID = int.Parse(dr["MediclaimPaymentID"].ToString());
            TheMediclaimPayment.MediclaimApplicationID = int.Parse(dr["MediclaimApplicationID"].ToString());
            TheMediclaimPayment.CustomerCode = dr["CustomerCode"].ToString();
            TheMediclaimPayment.CustomerName = dr["CustomerName"].ToString();
            TheMediclaimPayment.PaymentDate = DateTime.Parse(dr["PaymentDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheMediclaimPayment.AmountPaid = decimal.Parse(dr["AmountPaid"].ToString());

            return TheMediclaimPayment;
        }

        public static List<MediclaimPayment> GetMediClaimPaymentList(bool allOffices = false, bool showDeleted = false)
        {
            List<MediclaimPayment> MediclaimPaymentList = new List<MediclaimPayment>();
            DataTable MediclaimPaymentTable = PaymentsMediclaimDataAccess.GetInstance.GetMediClaimPaymentList(allOffices, showDeleted);

            foreach (DataRow dr in MediclaimPaymentTable.Rows)
            {
                MediclaimPayment TheMediclaimPayment = DataRowToObject(dr);

                MediclaimPaymentList.Add(TheMediclaimPayment);
            }

            return MediclaimPaymentList;
        }

        public static MediclaimPayment GetMediclaimPaymentByMediClaimApplicationID(int mediclaimApplicationID)
        {
            MediclaimPayment TheMediclaimPayment;
            DataRow TheMediclaimPaymentRow = PaymentsMediclaimDataAccess.GetInstance.GetMediclaimPaymentByMediClaimApplicationID(mediclaimApplicationID);

            if (TheMediclaimPaymentRow != null)
                TheMediclaimPayment = DataRowToObject(TheMediclaimPaymentRow);
            else
                TheMediclaimPayment = new MediclaimPayment();

            return TheMediclaimPayment;
        }

        public static int InsertMediclaimPayment(MediclaimPayment theMediclaimPayment)
        {
            return PaymentsMediclaimDataAccess.GetInstance.InsertMediclaimPayment(theMediclaimPayment);
        }
        #endregion
    }
}
