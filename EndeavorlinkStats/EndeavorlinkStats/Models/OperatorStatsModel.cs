using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndeavorlinkStats.Models
{
    public class OperatorStatsModel
    {
        public String oper { get; set; }
        public String year { get; set; }
        public Dictionary<int, List<DAL.sp_get_movistar_anual_Result>> movistarAnual;
        public Dictionary<int, List<DAL.sp_get_claro_anual_Result>> claroAnual;

        public OperatorStatsModel()
        {
            movistarAnual = new Dictionary<int, List<DAL.sp_get_movistar_anual_Result>>();
            claroAnual = new Dictionary<int, List<DAL.sp_get_claro_anual_Result>>();
        }
    }
}