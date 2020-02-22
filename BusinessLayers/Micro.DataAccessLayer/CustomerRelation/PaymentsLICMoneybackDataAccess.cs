using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;
using Micro.Commons;

namespace Micro.DataAccessLayer.CustomerRelation 
{
    public partial class PaymentsLICMoneybackDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PaymentsLICMoneybackDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PaymentsLICMoneybackDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaymentsLICMoneybackDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        #endregion

        #region Methods & Implementations
        public DataTable GetLICMoneybackPaymentsListByCustomerAccountID(int customerAccountID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, customerAccountID));
                SelectCommand.CommandText = "pCRM_LICMoneyBack_SelectByCustomerAccountID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int UpdateLICMoneyBackPayment(List<PaymentsLICMoneyback> paymentsLICMoneyBackList)
        {
            int ReturnValue = 0;

            int ListCount = paymentsLICMoneyBackList.Count;
            int ListCounter = 0;

            SqlCommand[] UpdateCommand = new SqlCommand[ListCount];

            foreach (PaymentsLICMoneyback EachPaymentsLICMoneyback in paymentsLICMoneyBackList)
            {
                using (UpdateCommand[ListCounter] = new SqlCommand())
                {

                    UpdateCommand[ListCounter].CommandType = CommandType.StoredProcedure;
                    UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                    UpdateCommand[ListCounter].Parameters.Add(GetParameter("@LICMoneyBackID", SqlDbType.Int, EachPaymentsLICMoneyback.LICMoneyBackID));
                    UpdateCommand[ListCounter].Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, EachPaymentsLICMoneyback.CustomerAccountID));
                    UpdateCommand[ListCounter].Parameters.Add(GetParameter("@DueDateOfPayment", SqlDbType.VarChar, EachPaymentsLICMoneyback.DueDateOfPayment));
                    UpdateCommand[ListCounter].Parameters.Add(GetParameter("@MoneyBackPayable", SqlDbType.Decimal, EachPaymentsLICMoneyback.MoneyBackPayable));
                    UpdateCommand[ListCounter].Parameters.Add(GetParameter("@MoneyBackDescription", SqlDbType.VarChar, EachPaymentsLICMoneyback.MoneyBackDescription));
                    UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ActualDateOfPayment", SqlDbType.VarChar, EachPaymentsLICMoneyback.ActualDateOfPayment));
                    UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ActualMoneyBackAmountPaid", SqlDbType.Decimal, EachPaymentsLICMoneyback.ActualMoneyBackAmountPaid));
                    UpdateCommand[ListCounter].Parameters.Add(GetParameter("@PaymentStatus", SqlDbType.VarChar, EachPaymentsLICMoneyback.PaymentStatus));
                    UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                    UpdateCommand[ListCounter].CommandText = "pCRM_LICMoneyBack_Update";
                    ListCounter++;
                }

            }

            ExecuteStoredProcedure(UpdateCommand);

            if ((ReturnValue + ListCount).Equals(0))
            {
                ReturnValue = (int)MicroEnums.DataOperationResult.Success + 1;
            }
            else
            {
                ReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            }

            return ReturnValue;
        }
        #endregion
    }
}
