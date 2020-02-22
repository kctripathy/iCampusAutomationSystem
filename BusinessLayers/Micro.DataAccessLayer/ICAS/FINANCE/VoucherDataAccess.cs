using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Micro.Commons;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.DataAccessLayer.ICAS.FINANCE
{
    public partial class VoucherDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static VoucherDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static VoucherDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new VoucherDataAccess();
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

        #region Methods & Implementation
        public int InsertVouchers(Voucher theVoucher)
        {
            int ReturnValue = 0;

            SqlCommand InsertCommand = new SqlCommand();

            InsertCommand.CommandType = CommandType.StoredProcedure;
            InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            InsertCommand.Parameters.Add(GetParameter("@VoucherCode", SqlDbType.VarChar, theVoucher.VoucherCode));
            InsertCommand.Parameters.Add(GetParameter("@VoucherType", SqlDbType.VarChar, theVoucher.VoucherType));
            InsertCommand.Parameters.Add(GetParameter("@VoucherDate", SqlDbType.VarChar, theVoucher.VoucherDate));
            InsertCommand.Parameters.Add(GetParameter("@VoucherNarration", SqlDbType.VarChar, theVoucher.VoucherNarration));
            InsertCommand.Parameters.Add(GetParameter("@IsPosted", SqlDbType.Bit, theVoucher.IsPosted));
            InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
            InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            InsertCommand.CommandText = "pFIN_Vouchers_Insert";

            ExecuteStoredProcedure(InsertCommand);
            ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int InsertVoucherDetails(List<VoucherDetails> theVoucherDetailsList)
        {
            int ReturnValue = 0;

            int ListCount = theVoucherDetailsList.Count;
            int ListCounter = 0;

            SqlCommand[] InsertCommand = new SqlCommand[ListCount];

            foreach (VoucherDetails TheVoucherDetails in theVoucherDetailsList)
            {
                InsertCommand[ListCounter] = new SqlCommand();

                InsertCommand[ListCounter].CommandType = CommandType.StoredProcedure;
                InsertCommand[ListCounter].Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand[ListCounter].Parameters.Add(GetParameter("@VoucherID", SqlDbType.Int, TheVoucherDetails.VoucherID));
                InsertCommand[ListCounter].Parameters.Add(GetParameter("@AccountLedgerDescription", SqlDbType.VarChar, TheVoucherDetails.AccountLedgerDescription));
                InsertCommand[ListCounter].Parameters.Add(GetParameter("@VoucherAmount", SqlDbType.Decimal, TheVoucherDetails.VoucherAmount));
                InsertCommand[ListCounter].Parameters.Add(GetParameter("@VoucherEntryType", SqlDbType.VarChar, TheVoucherDetails.VoucherEntryType));
                InsertCommand[ListCounter].Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand[ListCounter].CommandText = "pFIN_VoucherDetails_Insert";

                ListCounter++;
            }

            ReturnValue = ExecuteStoredProcedure(InsertCommand);

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
