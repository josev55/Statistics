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
        private InterfaceModel iface;
        public StatsController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        //
        // GET: /Stats/

        public ActionResult Index()
        {
            String user = Session["username"].ToString().ToLower();
            int id_user = _usuarioService.getID(user);
            iface = _usuarioService.getOperatorModel(id_user);
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
