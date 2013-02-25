using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EndeavorlinkStats.DAL;

namespace EndeavorlinkStats.Models
{
    public class InterfaceModel
    {
        public Dictionary<String,List<String>> operatorsForCountry;
        public List<sp_stats_getMovistarMonthByUser_Result> movistarStatsMonthByUserId;
        public List<sp_stats_getClaroMonthByUserId_Result> claroStatsMonthByUserId;
        public List<sp_stats_getComcelStatsByUserId_Result> comcelStatsMonthByUserId;
        public List<sp_perums_getStats_Result> movistarStatsMonthAdmin;
        public List<sp_get_claro_stats_Result> claroStatsMonthAdmin;
        public List<sp_stats_getComcelAdmin_Result> comcelStatsMonthAdmin;
        public InterfaceModel()
        {
            operatorsForCountry = new Dictionary<string, List<string>>();
            movistarStatsMonthByUserId = new List<sp_stats_getMovistarMonthByUser_Result>();
            claroStatsMonthByUserId = new List<sp_stats_getClaroMonthByUserId_Result>();
            comcelStatsMonthByUserId = new List<sp_stats_getComcelStatsByUserId_Result>();
            movistarStatsMonthAdmin = new List<sp_perums_getStats_Result>();
            claroStatsMonthAdmin = new List<sp_get_claro_stats_Result>();
            comcelStatsMonthAdmin = new List<sp_stats_getComcelAdmin_Result>();
        }
    }
}