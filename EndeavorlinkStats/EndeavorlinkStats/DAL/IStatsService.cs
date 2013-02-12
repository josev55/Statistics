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
    }
}