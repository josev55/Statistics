using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EndeavorlinkStats.DAL
{
    public interface ISupportService
    {
        List<sp_get_mo_support_Result> getMObyMSISDN(String msisdn);
        List<sp_get_mt_support_Result> getMTbyMSISDN(String msisdn);
        List<tbl_sms_sc> getShortcodesByOperator(String oper);
        Boolean insertSMS(String shortcode, String msg, String msisdn, String operador);
        Boolean sendSMS(String shortcode, String msg, String msisdn, String operador);
    }
}
