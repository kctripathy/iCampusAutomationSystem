//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCon.iCAS.WebApplication.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ADMN_TRN_ErrorLog
    {
        public long ErrorRecordID { get; set; }
        public Nullable<System.DateTime> ErrorDate { get; set; }
        public string Ticket { get; set; }
        public string Environment { get; set; }
        public string ThePage { get; set; }
        public string TheMessage { get; set; }
        public string TheInnerMessage { get; set; }
        public string ErrorStack { get; set; }
        public string UserDomain { get; set; }
        public string Language { get; set; }
        public string TargetSite { get; set; }
        public string TheClass { get; set; }
        public string TheUserAgent { get; set; }
        public string TypeLog { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> OfficeId { get; set; }
    }
}
