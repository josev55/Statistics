using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using ClaroHelpers;


namespace EndeavorlinkStats.DAL
{
    public class SupportService : ISupportService
    {
        private readonly StatsContextContainer _repository = new StatsContextContainer();

        public List<sp_get_mo_support_Result> getMObyMSISDN(string msisdn)
        {
            return _repository.sp_get_mo_support(msisdn).ToList();
        }

        public List<sp_get_mt_support_Result> getMTbyMSISDN(string msisdn)
        {
            return _repository.sp_get_mt_support(msisdn).ToList();
        }


        public Boolean insertSMS(String shortcode, String msg, String msisdn, String oper)
        {
            ObjectParameter id_mo = new ObjectParameter("id_mo", typeof(int));
            var operador = oper == "movistar" ? "MOVPERU" : (oper == "claro" ? "CLAROPERU" : (oper == "comcel" ? oper.ToUpper() : "TELCEL"));
            var id_operator = (from op in _repository.tbl_operator where op.name == operador select op.id_operator).First();
            var id_sc = (from s in _repository.tbl_sms_sc where s.sc == shortcode && s.id_operator == id_operator select s.id_sc).First();
            try
            {
                if (!(oper == "comcel"))
                {
                    _repository.sp_inject_mo(int.Parse(id_sc.ToString()), msg, Int64.Parse(msisdn));
                    return true;
                }
                ClaroSMS.sendClaroColombia(id_sc.ToString(), msg, msisdn);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<tbl_sms_sc> getShortcodesByOperator(string oper)
        {
            var operador = oper == "movistar" ? "MOVPERU" : (oper == "claro" ? "CLAROPERU" : (oper == "comcel" ? oper.ToUpper() : "TELCEL"));
            return (from s in _repository.tbl_sms_sc join o in _repository.tbl_operator on s.id_operator equals o.id_operator where o.name == operador select s).ToList();
        }



        public bool sendSMS(string shortcode, string msg, string msisdn, string operador)
        {
            ObjectParameter id = new ObjectParameter("id", typeof(int));
            var oper = operador == "movistar" ? "MOVPERU" : (operador == "claro" ? "CLAROPERU" : (operador == "comcel" ? operador.ToUpper() : "TELCEL"));
            var id_operator = (from op in _repository.tbl_operator where op.name == oper select op.id_operator).First();
            var id_sc = (from s in _repository.tbl_sms_sc where (s.sc == shortcode) && (s.id_operator == id_operator) select s.id_sc).First();
            try
            {
                if (operador == "claro")
                {
                    ClaroSMS.sendClaroPeru(msisdn, msg, shortcode);
                    _repository.sp_inject_mt((new Random().Next(9999)).ToString(), 3100, Int64.Parse(msisdn), msg, "", int.Parse(id_sc.ToString()), "t");
                    return true;
                }
                else
                {
                    _repository.sp_inject_mt((new Random().Next(9999)).ToString(), 3100, Int64.Parse(msisdn), msg, "", int.Parse(id_sc.ToString()), "t");
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}