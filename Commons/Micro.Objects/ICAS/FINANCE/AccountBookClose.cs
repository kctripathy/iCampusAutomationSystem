using System;

namespace Micro.Objects.ICAS.FINANCE
{
    [Serializable]
    public class AccountBookClose
    {
        public int RecordNumber
        {
            get;
            set;
        }

        public int AccountYearID
        {
            get;
            set;
        }

        public string  AccountYearMonth
        {
            get;
            set;
        }

        public char IsBookClosed
        {
            get;
            set;
        }

        public int  BookClosedByUserID
        {
            get;
            set;
        }

        public string  BookCloseDateTime
        {
            get;
            set;
        }

         public int  AuthorisationID
        {
            get;
            set;
        }

         public int  SocietyID
        {
            get;
            set;
        }

         public int  OfficeID
        {
            get;
            set;
        }


    }
}
