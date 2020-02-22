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
    
    public partial class ADMN_MST_Companies
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAliasName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyMailingName { get; set; }
        public Nullable<int> CompanyRegisteredOfficeID { get; set; }
        public Nullable<int> CompanyHeadOfficeID { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string CompanyEPFRegistrationNumber { get; set; }
        public byte[] CompanyLogoBigSize { get; set; }
        public string CompanyLogoBigType { get; set; }
        public byte[] CompanyLogoMediumSize { get; set; }
        public string CompanyLogoMediumType { get; set; }
        public byte[] CompanyLogoSmallSize { get; set; }
        public string CompanyLogoSmallType { get; set; }
        public byte[] CompanyLoginImage { get; set; }
        public string CompanyLoginImageType { get; set; }
        public string CompanyLoginLabelForeColor { get; set; }
        public Nullable<System.DateTime> EstablishmentDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<int> AddedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string VC_FIELD1 { get; set; }
        public string VC_FIELD2 { get; set; }
        public Nullable<int> NU_FIELD1 { get; set; }
        public Nullable<int> NU_FIELD2 { get; set; }
        public Nullable<System.DateTime> DT_FIELD1 { get; set; }
        public Nullable<System.DateTime> DT_FIELD2 { get; set; }
        public string CH_FIELD1 { get; set; }
        public string CH_FIELD2 { get; set; }
    }
}
