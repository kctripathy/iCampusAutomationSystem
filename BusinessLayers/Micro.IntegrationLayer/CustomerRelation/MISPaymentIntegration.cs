using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class MISPaymentIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementations
        public static MISPayment DataRowToObject(DataRow dr)
        {
            MISPayment TheMISPayment = new MISPayment();

            TheMISPayment.MISPaymentID = int.Parse(dr["MISPaymentID"].ToString());
            TheMISPayment.CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString());
            TheMISPayment.CustomerName = dr["CustomerName"].ToString();
            TheMISPayment.MISFirstDueDate = DateTime.Parse(dr["MISFirstDueDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheMISPayment.MISLastDueDate = DateTime.Parse(dr["MISLastDueDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheMISPayment.MISNumberFrom = int.Parse(dr["MISNumberFrom"].ToString());
            TheMISPayment.MISNumberTo = int.Parse(dr["MISNumberTo"].ToString());
            TheMISPayment.MISPayable = decimal.Parse(dr["MISPayable"].ToString());
            TheMISPayment.MISPaymentDate = DateTime.Parse(dr["MISPaymentDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheMISPayment.MISPaid = decimal.Parse(dr["MISPaid"].ToString());
            TheMISPayment.MISPaymentMode = dr["MISPaymentMode"].ToString();

            return TheMISPayment;
        }

		public static List<MISPayment> GetMISPaymentList(string searchText = "")
        {
            List<MISPayment> MISPaymentList = new List<MISPayment>();

            DataTable MISPaymentTable = new DataTable();
            MISPaymentTable = MISPaymentDataAccess.GetInstance.GetMISPaymentList(searchText);

            foreach (DataRow dr in MISPaymentTable.Rows)
            {
				MISPayment TheMISPayment = DataRowToObject(dr);

				MISPaymentList.Add(TheMISPayment);
            }

            return MISPaymentList;
        }

        public static List<MISPayment> GetMISPaymentsByCustomerAccountID(int customerAccountID)
        {
            List<MISPayment> MISPaymentList = new List<MISPayment>();

            DataTable MISPaymentTable = new DataTable();
			MISPaymentTable = MISPaymentDataAccess.GetInstance.GetMISPaymentsByCustomerAccountID(customerAccountID);

            foreach (DataRow dr in MISPaymentTable.Rows)
            {
                MISPayment TheMISPayment = DataRowToObject(dr);

                MISPaymentList.Add(TheMISPayment);
            }

            return MISPaymentList;
        }

        public static MISPayment GetLastMISPayment(int customerAccountID)
        {
            MISPayment TheMISPayment = new MISPayment();

            if (GetMISPaymentsByCustomerAccountID(customerAccountID).Count>0)
            {
                var LastMISPayment = (from MISPaymentList in GetMISPaymentsByCustomerAccountID(customerAccountID)
                                              orderby DateTime.Parse(MISPaymentList.MISLastDueDate) descending
                                              select MISPaymentList).First();

                TheMISPayment = (MISPayment)LastMISPayment;
            }

            return TheMISPayment;
        }

		public static int InsertMISPayment(MISPayment theMISPayment)
        {
            return MISPaymentDataAccess.GetInstance.InsertMISPayment(theMISPayment);
        }
        #endregion
    }
}
