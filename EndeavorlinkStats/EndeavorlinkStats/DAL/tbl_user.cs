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
    
    public partial class tbl_user
    {
        public tbl_user()
        {
            this.tbl_charge_peru_claro = new HashSet<tbl_charge_peru_claro>();
            this.tbl_perums_callback = new HashSet<tbl_perums_callback>();
            this.tbl_sms_mt = new HashSet<tbl_sms_mt>();
            this.tbl_sms_sc_url = new HashSet<tbl_sms_sc_url>();
        }
    
        public decimal id_user { get; set; }
        public string name { get; set; }
        public string pwd { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<tbl_charge_peru_claro> tbl_charge_peru_claro { get; set; }
        public virtual ICollection<tbl_perums_callback> tbl_perums_callback { get; set; }
        public virtual ICollection<tbl_sms_mt> tbl_sms_mt { get; set; }
        public virtual ICollection<tbl_sms_sc_url> tbl_sms_sc_url { get; set; }
    }
}