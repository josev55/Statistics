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
    
    public partial class tbl_sms_sc_url
    {
        public tbl_sms_sc_url()
        {
            this.tbl_sms_mo_deliver = new HashSet<tbl_sms_mo_deliver>();
        }
    
        public decimal id_url { get; set; }
        public decimal id_user { get; set; }
        public decimal id_sc { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string isactive { get; set; }
    
        public virtual ICollection<tbl_sms_mo_deliver> tbl_sms_mo_deliver { get; set; }
        public virtual tbl_user tbl_user { get; set; }
    }
}
