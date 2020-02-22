using System;

namespace Micro.Objects.ICAS.FINANCE
{
    [Serializable]
   public class Voucher_BatchPosting
    {
        //Columns from Accountin Transactions
        public int RecordNumber
        {
            get;
            set;
        }
        public string VoucherNumber
        {
            get;
            set;
        }
        public string TranDate
        {
            get;
            set;
        }
        public int TranNumber
        {
            get;
            set;
        }
        public int SerialNumber
        {
            get;
            set;
        }
        public int AccountsID
        {
            get;
            set;
        }
        public string AccountDescription
        {
            get;
            set;
        }
        public string AccountCode
        {
            get;
            set;
        }
        public string TranType
        {
            get;
            set;
        }
        public decimal TranAmount
        {
            get;
            set;
        }
        public string BalanceType
        {
            get;
            set;
        }
        public string Narration
        {
            get;
            set;
        }
        public string IsPosted
        {
            get;
            set;
        }
        public int PostedBy
        {
            get;
            set;
        }
        public string PostedDate
        {
            get;
            set;
        }
        public string PostMode
        {
            get;
            set;
        }
        public string VC_FIELD1
        {
            get;
            set;
        }
        public string VC_FIELD2
        {
            get;
            set;
        }
        public int NU_FIELD1
        {
            get;
            set;
        }
        public int NU_FIELD2
        {
            get;
            set;
        }
        public string DT_FIELD1
        {
            get;
            set;
        }
        public string DT_FIELD2
        {
            get;
            set;
        }
        public char CH_FIELD1
        {
            get;
            set;
        }
        public char CH_FIELD2
        {
            get;
            set;
        }

        //Columns from Account Group
        public int AccountGroupID
        {
            get;
            set;
        }
        public string AccountGroupDescription
        {
            get;
            set;
        }


        //Columns from Accounting Year 
        public int AccountingYearID
        {
            get;
            set;
        }
        public string AccountingYearDescription
        {
            get;
            set;
        }
        public string YearStartDate
        {
            get;
            set;
        }
        public string YearEndDate
        {
            set;
            get;
        }
        public int ACC_YEAR_ID
        {
            get;
            set;
        }
        public string ACC_YEAR_CODE
        {
            get;
            set;
        }
        public string CURRENT_START_DATE
        {
            get;
            set;
        }
        public string CURRENT_END_DATE
        {
            get;
            set;
        }
        public string PREVIOUS_START_DATE
        {
            get;
            set;
        }
        public string PREVIOUS_END_DATE
        {
            get;
            set;
        }
        public string BOOK_CLOSING_FLAG
        {
            get;
            set;
        }
        public string YEAR_CLOSING_FLAG
        {
            get;
            set;
        }
        public string STATUS_FLAG
        {
            get;
            set;
        }
        public string MOD_DATE
        {
            get;
            set;
        }
        public string AUTH_CODE
        {
            get;
            set;
        }
        public int SlNo
        {
            get;
            set;
        }
        public string ForMonth
        {
            get;
            set;
        }

        //Columns from Office and Society
        public int OfficeTypeID
        {
            get;
            set;
        }
        public string OfficeTypeName
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
        public string OfficeName
        {
            get;
            set;
        }
        public string OfficeCode
        {
            get;
            set;
        }
        public int SocietyID
        {
            get;
            set;
        }
        public string SocietyName
        {
            get;
            set;
        }
        public string SocietyAliasName
        {
            get;
            set;
        }
        public string SocietyCode
        {
            get;
            set;
        }
    }

    [Serializable]
    public class Voucher2Post
    {
        //Columns from Accountin Transactions
        public int RecordNumber
        {
            get;
            set;
        }
        public string VoucherNumber
        {
            get;
            set;
        }
        public string TranDate
        {
            get;
            set;
        }
        public int TranNumber
        {
            get;
            set;
        }
        public int SerialNumber
        {
            get;
            set;
        }
        public int AccountsID
        {
            get;
            set;
        }
        public string AccountDescription
        {
            get;
            set;
        }
        public string AccountCode
        {
            get;
            set;
        }
        public string TranType
        {
            get;
            set;
        }
        public decimal TranAmount
        {
            get;
            set;
        }
        public string BalanceType
        {
            get;
            set;
        }
        public string Narration
        {
            get;
            set;
        }
        public string IsPosted
        {
            get;
            set;
        }
        public int PostedBy
        {
            get;
            set;
        }
        public string PostedDate
        {
            get;
            set;
        }
        public string PostMode
        {
            get;
            set;
        }
        public string VC_FIELD1
        {
            get;
            set;
        }
        public string VC_FIELD2
        {
            get;
            set;
        }
        public int NU_FIELD1
        {
            get;
            set;
        }
        public int NU_FIELD2
        {
            get;
            set;
        }
        public string DT_FIELD1
        {
            get;
            set;
        }
        public string DT_FIELD2
        {
            get;
            set;
        }
        public char CH_FIELD1
        {
            get;
            set;
        }
        public char CH_FIELD2
        {
            get;
            set;
        }

        //Columns from Account Group
        public int AccountGroupID
        {
            get;
            set;
        }
        public string AccountGroupDescription
        {
            get;
            set;
        }


        //Columns from Accounting Year 
        public int AccountingYearID
        {
            get;
            set;
        }
        public string AccountingYearDescription
        {
            get;
            set;
        }
        public string YearStartDate
        {
            get;
            set;
        }
        public string YearEndDate
        {
            set;
            get;
        }
        public int ACC_YEAR_ID
        {
            get;
            set;
        }
        public string ACC_YEAR_CODE
        {
            get;
            set;
        }
        public string CURRENT_START_DATE
        {
            get;
            set;
        }
        public string CURRENT_END_DATE
        {
            get;
            set;
        }
        public string PREVIOUS_START_DATE
        {
            get;
            set;
        }
        public string PREVIOUS_END_DATE
        {
            get;
            set;
        }
        public string BOOK_CLOSING_FLAG
        {
            get;
            set;
        }
        public string YEAR_CLOSING_FLAG
        {
            get;
            set;
        }
        public string STATUS_FLAG
        {
            get;
            set;
        }
        public string MOD_DATE
        {
            get;
            set;
        }
        public string AUTH_CODE
        {
            get;
            set;
        }
        public int SlNo
        {
            get;
            set;
        }
        public string ForMonth
        {
            get;
            set;
        }

        //Columns from Office and Society
        public int OfficeTypeID
        {
            get;
            set;
        }
        public string OfficeTypeName
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
        public string OfficeName
        {
            get;
            set;
        }
        public string OfficeCode
        {
            get;
            set;
        }
        public int SocietyID
        {
            get;
            set;
        }
        public string SocietyName
        {
            get;
            set;
        }
        public string SocietyAliasName
        {
            get;
            set;
        }
        public string SocietyCode
        {
            get;
            set;
        }
    }

    [Serializable]
    public class Voucher2PostUpdate
    {
        public int TranNumber
        {
            get;
            set;
        }

        public bool CheckState
        {
            get;
            set;
        }

        public int PostedBy
        {
            get;
            set;
        }
       
        public int OfficeID
        {
            get;
            set;
        }
    }
}
