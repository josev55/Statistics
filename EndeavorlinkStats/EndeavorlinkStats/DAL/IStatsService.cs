using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndeavorlinkStats.DAL
{
    public interface IStatsService
    {
        List<sp_stats_getMovistarMonthByUser_Result> getMovistarStatsByUserId(int id_user,int month, int year);
        List<sp_stats_getClaroMonthByUserId_Result> getClaroStatsByUserId(int id_user, int month, int year);
        List<sp_stats_getComcelStatsByUserId_Result> getComcelStatsByUserId(int id_user, int month, int year);
        List<sp_perums_getStats_Result> getMovistarStatsAdmin(int month, int year);
        List<sp_get_claro_stats_Result> getClaroStatsAdmin(int month, int year);
        List<sp_stats_getComcelAdmin_Result> getComcelStatsAdmin(int month,int year);
        List<sp_get_movistar_anual_Result> getMovistarStatsAnual(int id_user, int year);
        List<sp_get_claro_anual_Result> getClaroStatsAnual(int id_user, int year);
        int get_id_operator(String oper);
    }
}