//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EndeavorlinkStats.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_charge_peru_claro
    {
        public decimal id_charge { get; set; }
        public System.DateTime create_date { get; set; }
        public decimal id_user { get; set; }
        public decimal msisdn { get; set; }
        public string billingCode { get; set; }
        public string responseCode { get; set; }
    
        public virtual tbl_user tbl_user { get; set; }
    }
}
