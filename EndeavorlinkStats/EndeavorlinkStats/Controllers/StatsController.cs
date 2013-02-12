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
        public List<sp_stats_getMovistarMonthByUser_Result> movistarPeruStatsMonthly;
        public StatsController(IUsuarioService usuarioService, IStatsService statsService)
        {
            _usuarioService = usuarioService;
            _statService = statsService;
            iface = new InterfaceModel();
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
            iface.movistarStatsMonthByUserId = _statService.getMovistarStatsByUserId(id_user, DateTime.Now.Month, DateTime.Now.Year);
            return View(iface);
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
    }
}
