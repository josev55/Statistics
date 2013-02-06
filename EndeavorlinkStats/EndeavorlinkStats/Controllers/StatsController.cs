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

        [HttpPost]
        public String logIn(String user, String pass)
        {
            var usuario = _usuarioService.getUser(user);

            if (usuario.Equals(pass))
            {
                return JsonConvert.SerializeObject(new { Result = "OK", ID = usuario.id_user });
            }
            else
            {
                return JsonConvert.SerializeObject(new { Result = "FAILED", ID = -1 });
            }
        }

    }
}
