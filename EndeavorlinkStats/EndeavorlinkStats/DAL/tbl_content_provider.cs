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
    
    public partial class tbl_content_provider
    {
        public tbl_content_provider()
        {
            this.tbl_cp_callback = new HashSet<tbl_cp_callback>();
        }
    
        public decimal id { get; set; }
        public string contentProvider { get; set; }
        public decimal shortcode { get; set; }
        public decimal servicecode { get; set; }
        public decimal subservicecode { get; set; }
    
        public virtual ICollection<tbl_cp_callback> tbl_cp_callback { get; set; }
    }
}
