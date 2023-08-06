using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.LIBRARY
{
    public class Transaction
    {
        public Int64 ID { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } // I - ISSUE R - RETURN
        public int UserID { get; set; } // 
        public string UserType { get; set; } // S- STUDENT, E-EMPLOYEE
        public float FineAmount { get; set; }

    }

    public class LibrarySettings
    {
        public int SettingKeyID { get; set; }
        public string SettingKeyName { get; set; }
        public int SettingID { get; set; }
        public string SettingValue { get; set; }
        public DateTime EffectiveDateFrom { get; set; }
        public DateTime? EffectiveDateTo { get; set; } = null;
        public bool IsActive { get; set; }
    }


    public class LibraryTransactionInputPayLoad
    {
        public int TRAN_ID { get; set; }
        public int USER_REF_ID { get; set; }
        public List<Int64> BOOK_ID_LIST { get; set; }
        public DateTime? BOOK_ISSUE_DATE { get; set; } = null;
        public DateTime? BOOK_RETURN_DATE { get; set; } = null;
        public int NO_OF_DAYS_CAN_KEEP { get; set; }
        public double FINE_AMOUNT_PER_DAY { get; set; }
        public double FINE_AMOUNT_PAID { get; set; }
        public string RECEIPT_NO { get; set; }
        public int TRANSACTION_BY_USER_ID { get; set; }
    }



    public class LibraryTransaction
    {
        public int TRAN_ID { get; set; }
        public Int64 BOOK_ID { get; set; }
        public DateTime BOOK_ISSUE_DATE { get; set; }
        public DateTime? BOOK_RETURN_DATE { get; set; } = null;
        
        public int USER_ID { get; set; }
        public Int64 USER_REF_ID { get; set; }
        public string USER_TYPE { get; set; }
        public string USER_NAME { get; set; }
        public string USER_FULL_NAME { get; set; }
        public int AC_NO { get; set; }
        public string TITLE { get; set; }

        public double FINE_AMOUNT_PER_DAY { get; set; }
        public int NO_OF_DAYS_CAN_KEEP { get; set; }
        public int NO_OF_DAYS_BOOK_KEPT { get; set; }
        public int TOTAL_DAY_DUE_FOR_FINE { get; set; }
        public double TOTAL_FINE_AMOUNT { get; set; }
        public double TOTAL_FINE_AMOUNT_PAID { get; set; }
        public DateTime? FINE_AMOUNT_PAID_DATE { get; set; }

        public int BOOK_ISSUED_BY_USER_ID { get; set; }
        public string BOOK_ISSUED_BY_EMP_NAME { get; set; }

        public int BOOK_RECEIVED_BY_USER_ID { get; set; }
        public string BOOK_RECEIVED_BY_EMP_NAME { get; set; }

    }



    public class LibrarySettingInput
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class LibrarySettingGetPayload
    {
        public DateTime? fromDate { get; set; } = null;
        public DateTime? toDate { get; set; } = null;
        public int? userId { get; set; } = null;
    }
}
