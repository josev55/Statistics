using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndeavorlinkStats.DAL
{
    public class StatsService : IStatsService
    {
        private readonly smartg _repository = new smartg();
        public List<sp_stats_getMovistarMonthByUser_Result> getMovistarStatsByUserId(int id_user, int month, int year)
        {
            return _repository.sp_stats_getMovistarMonthByUser(id_user, year, month).ToList();
        }
    }
}