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
    }
}