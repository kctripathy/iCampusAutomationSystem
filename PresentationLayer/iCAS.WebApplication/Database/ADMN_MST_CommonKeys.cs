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
    
    public partial class ADMN_MST_CommonKeys
    {
        public int CommonKeyID { get; set; }
        public string CommonKeyName { get; set; }
        public string CommonKeyValue { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<int> AddedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> CompanyID { get; set; }
    }
}
