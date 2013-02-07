using EndeavorlinkStats.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace EndeavorlinkStats.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private readonly IUsuarioService _usuarioService;
        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public ActionResult Index()
        {
            if (HttpContext.Request.Cookies.Count != 0)
            {
                return RedirectToAction("Index", "Stats");
            }
            return View();
        }

        [HttpPost]
        public String logIn(String user, String pass)
        {
            var usuario = _usuarioService.getUser(user);

            if (usuario.pwd.Equals(pass))
            {
                HttpContext.Response.Cookies.Add(new HttpCookie(usuario.id_user.ToString(), usuario.name));
                return JsonConvert.SerializeObject(new { Result = "OK", ID = usuario.id_user });
            }
            else
            {
                return JsonConvert.SerializeObject(new { Result = "FAILED", ID = -1 });
            }
        }


    }
}
