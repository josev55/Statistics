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
    
    public partial class tbl_sia_transaction
    {
        public tbl_sia_transaction()
        {
            this.tbl_sia_distinct_transaction = new HashSet<tbl_sia_distinct_transaction>();
        }
    
        public decimal id_tx { get; set; }
        public decimal id_user { get; set; }
        public string id_usertxid { get; set; }
        public decimal id_operator { get; set; }
        public string id_rating { get; set; }
        public string contentId { get; set; }
        public string contentName { get; set; }
        public decimal msisdn { get; set; }
        public string url_ok { get; set; }
        public string url_cancel { get; set; }
        public string url_error { get; set; }
        public string url_unsuc { get; set; }
        public string extraparam { get; set; }
        public System.DateTime creation_date { get; set; }
        public decimal cod_response { get; set; }
        public string transactionId { get; set; }
        public string txtype { get; set; }
        public Nullable<System.DateTime> last_renew { get; set; }
        public Nullable<decimal> retry { get; set; }
        public Nullable<System.DateTime> nextretry { get; set; }
    
        public virtual ICollection<tbl_sia_distinct_transaction> tbl_sia_distinct_transaction { get; set; }
    }
}