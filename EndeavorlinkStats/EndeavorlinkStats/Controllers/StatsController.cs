using EndeavorlinkStats.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using EndeavorlinkStats.Models;

namespace EndeavorlinkStats.Controllers
{
    public class StatsController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IStatsService _statService;
        private InterfaceModel iface;
        private OperatorStatsModel ostats;
        private Dictionary<int, List<sp_get_movistar_anual_Result>> recordsMovistar;
        private Dictionary<int, List<sp_get_claro_anual_Result>> recordsClaro;
        private Dictionary<int, List<sp_get_comcel_anual_Result>> recordsComcel;

        public StatsController(IUsuarioService usuarioService, IStatsService statsService)
        {
            _usuarioService = usuarioService;
            _statService = statsService;
            iface = new InterfaceModel();
            ostats = new OperatorStatsModel();
            recordsMovistar = new Dictionary<int, List<sp_get_movistar_anual_Result>>();
            recordsClaro = new Dictionary<int, List<sp_get_claro_anual_Result>>();
            recordsComcel = new Dictionary<int, List<sp_get_comcel_anual_Result>>();
        }
        //
        // GET: /Stats/

        public ActionResult Index()
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Login");
            String user = Session["username"].ToString().ToLower();
            int id_user = _usuarioService.getID(user);
            iface.operatorsForCountry = _usuarioService.getOperatorModel(id_user);
            return View(iface);
        }

        public PartialViewResult updateDashboardStats(String oper)
        {
            throw new NotImplementedException();
        }

        public PartialViewResult getDashboardStats()
        {
            String user = Session["username"].ToString().ToLower();
            int id_user = _usuarioService.getID(user);
            if (id_user == 3000 || id_user == 3100)
            {
                if (Session["movistarAdmin"] == null)
                {
                    iface.movistarStatsMonthAdmin = _statService.getMovistarStatsAdmin(DateTime.Now.Month, DateTime.Now.Year);
                    Session["movistarAdmin"] = iface.movistarStatsMonthAdmin;
                }
                else
                {
                    iface.movistarStatsMonthAdmin = (List<sp_perums_getStats_Result>)Session["movistarAdmin"];
                }
                if (Session["claroAdmin"] == null)
                {
                    iface.claroStatsMonthAdmin = _statService.getClaroStatsAdmin(DateTime.Now.Month, DateTime.Now.Year);
                    Session["claroAdmin"] = iface.claroStatsMonthAdmin;
                }
                else
                {
                    iface.claroStatsMonthAdmin = (List<sp_get_claro_stats_Result>)Session["claroAdmin"];
                }
                if (Session["comcelAdmin"] == null)
                {
                    iface.comcelStatsMonthAdmin = _statService.getComcelStatsAdmin(DateTime.Now.Month, DateTime.Now.Year);
                    Session["comcelAdmin"] = iface.comcelStatsMonthAdmin;
                }
                else
                {
                    iface.comcelStatsMonthAdmin = (List<sp_stats_getComcelAdmin_Result>)Session["comcelAdmin"];
                }
            }
            else
            {
                iface.movistarStatsMonthByUserId = _statService.getMovistarStatsByUserId(id_user, DateTime.Now.Month, DateTime.Now.Year);
                iface.claroStatsMonthByUserId = _statService.getClaroStatsByUserId(id_user, DateTime.Now.Month, DateTime.Now.Year);
                iface.comcelStatsMonthByUserId = _statService.getComcelStatsByUserId(id_user, DateTime.Now.Month, DateTime.Now.Year);
            }
            return PartialView("dashboardStats", iface);
        }

        public PartialViewResult getOperatorStatPage(String oper, String month, String year)
        {
            ostats.year = year;

            if (oper == "movistar")
            {
                sortMovistarList(_statService.getMovistarStatsAnual(_usuarioService.getID(Session["username"].ToString()), int.Parse(year)));
                
                ostats.movistarAnual = recordsMovistar;
            }
            if (oper == "claro")
            {
                sortClaroList(_statService.getClaroStatsAnual(_usuarioService.getID(Session["username"].ToString()),int.Parse(year)));
                ostats.claroAnual = recordsClaro;
            }
            if (oper == "comcel")
            {
                sortComcelList(_statService.getComcelStatsAnual(_usuarioService.getID(Session["username"].ToString()), int.Parse(year)));
                ostats.comcelAnual = recordsComcel;
            }
            return PartialView("OperatorStatsPage", ostats);
        }

        public ActionResult Stats()
        {
            return View();
        }

        public ActionResult Charts()
        {
            return View();
        }

        public ActionResult Table_dynamic()
        {
            return View();
        }
        public ActionResult forms()
        {
            return View();
        }

        private void sortMovistarList(List<sp_get_movistar_anual_Result> stats)
        {
            List<String> serviceCodeDistinct = stats.Distinct().Select(x => x.service_code).ToList();
            foreach (var item in serviceCodeDistinct)
            {
                if (!recordsMovistar.ContainsKey(int.Parse(item)))
                {
                    recordsMovistar.Add(int.Parse(item), stats.FindAll(x => x.service_code == item));
                }
            }
        }

        private void sortClaroList(List<sp_get_claro_anual_Result> stats)
        {
            List<String> serviceCodeDistinct = stats.Distinct().Select(x => x.billingCode).ToList();
            foreach (var item in serviceCodeDistinct)
            {
                if (!recordsClaro.ContainsKey(int.Parse(item)))
                {
                    recordsClaro.Add(int.Parse(item), stats.FindAll(x => x.billingCode == item));
                }
            }
        }

        private void sortComcelList(List<sp_get_comcel_anual_Result> stats)
        {
            List<decimal> serviceCodeDistinct = stats.Distinct().Select(x => x.servicecode).ToList();
            foreach (var item in serviceCodeDistinct)
            {
                if (!recordsComcel.ContainsKey((int)item))
                {
                    recordsComcel.Add((int)item, stats.FindAll(x => x.servicecode == item));
                }
            }
        }
    }
}
