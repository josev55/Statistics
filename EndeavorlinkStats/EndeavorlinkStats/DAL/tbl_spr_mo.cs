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
    
    public partial class tbl_spr_mo
    {
        public decimal id_mo { get; set; }
        public string phone { get; set; }
        public Nullable<int> shortNum { get; set; }
        public string msgText { get; set; }
        public Nullable<decimal> msgId { get; set; }
        public string userp { get; set; }
        public string pwd { get; set; }
        public Nullable<int> idOperator { get; set; }
        public string enc { get; set; }
        public string refMsgId { get; set; }
        public System.DateTime tstamp { get; set; }
    
        public virtual tbl_spr_operator tbl_spr_operator { get; set; }
    }
}
