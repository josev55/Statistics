using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EndeavorlinkStats.DAL;

namespace EndeavorlinkStats.Models
{
    public class SMSModel
    {
        public List<sp_get_mo_support_Result> sms_mo { get; set; }
        public List<sp_get_mt_support_Result> sms_mt { get; set; }
        public List<tbl_sms_sc> sms_sc { get; set; }
        public String oper { get; set; }
    }
}