using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndeavorlinkStats.DAL
{
    public class StatsService : IStatsService
    {
        private readonly StatsContextContainer _repository = new StatsContextContainer();
        
        public List<sp_stats_getMovistarMonthByUser_Result> getMovistarStatsByUserId(int id_user, int month, int year)
        {
            return _repository.sp_stats_getMovistarMonthByUser(id_user, year, month).ToList();
        }


        public List<sp_stats_getClaroMonthByUserId_Result> getClaroStatsByUserId(int id_user, int month, int year)
        {
            return _repository.sp_stats_getClaroMonthByUserId(month, year,id_user).ToList();
        }


        public List<sp_stats_getComcelStatsByUserId_Result> getComcelStatsByUserId(int id_user, int month, int year)
        {
            return _repository.sp_stats_getComcelStatsByUserId(year, month, id_user).ToList();
        }


        public List<sp_perums_getStats_Result> getMovistarStatsAdmin(int month, int year)
        {
            return _repository.sp_perums_getStats(year,month).ToList();
        }

        public List<sp_get_claro_stats_Result> getClaroStatsAdmin(int month, int year)
        {
            return _repository.sp_get_claro_stats(month, year).ToList();
            throw new NotImplementedException();
        }

        public List<sp_stats_getComcelAdmin_Result> getComcelStatsAdmin(int month,int year)
        {
            return _repository.sp_stats_getComcelAdmin(year, month).ToList();
        }


        public List<sp_get_movistar_anual_Result> getMovistarStatsAnual(int id_user, int year)
        {
            return _repository.sp_get_movistar_anual(year, id_user).ToList();
        }


        public int get_id_operator(string oper)
        {
            return (int)(from op in _repository.tbl_operator where op.name == oper select op.id_operator).First();
        }


        public List<sp_get_claro_anual_Result> getClaroStatsAnual(int id_user, int year)
        {
            return _repository.sp_get_claro_anual(year, id_user).ToList();
        }


        public List<sp_get_comcel_anual_Result> getComcelStatsAnual(int id_user, int year)
        {
            return _repository.sp_get_comcel_anual(year, id_user).ToList();
        }
    }
}