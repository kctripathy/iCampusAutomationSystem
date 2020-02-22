using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.Administration
{
	public class ErrorLog
	{
        public Int64 ErrorRecordID
        {
            get;
            set;
        }
        public DateTime ErrorDate
        {
            get;
            set;
        }
        public string Ticket
        {
            get;
            set;
        }
        public string Environment
        {
            get;
            set;
        }
        public string ThePage
        {
            get;
            set;
        }
        public string TheMessage
        {
            get;
            set;
        }
        public string TheInnerMessage
        {
            get;
            set;
        }
        public string ErrorStack
        {
            get;
            set;
        }

        public string UserDomain
        {
            get;
            set;
        }
        public string Language
        {
            get;
            set;
        }
        public string TargetSite
        {
            get;
            set;
        }
        public string TheClass
        {
            get;
            set;
        }
        public string TheUserAgent
        {
            get;
            set;
        }
        public string TypeLog
        {
            get;
            set;
        }
        public int UserID
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
