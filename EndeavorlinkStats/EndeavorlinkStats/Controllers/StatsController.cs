using EndeavorlinkStats.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace EndeavorlinkStats.Controllers
{
    public class StatsController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public StatsController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        //
        // GET: /Stats/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stats()
        {
            return View();
        }
    }
}
