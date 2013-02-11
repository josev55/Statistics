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
        private Dictionary<String, String> loginName;
        private readonly IUsuarioService _usuarioService;
        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            loginName = new Dictionary<string, string>();
            loginName.Add("atlas", "Atlas");
            loginName.Add("vivazz", "Vivazz");
        }

        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("Index", "Stats");
            }
            return View();
        }

        [HttpPost]
        public ActionResult logIn(String login, String password)
        {
            try
            {
                var usuario = _usuarioService.getUser(login);

                if (usuario.pwd.Equals(password))
                {
                    String value = login;
                    loginName.TryGetValue(login, out value);
                    Session["username"] = value;
                    return RedirectToAction("Index", "Stats");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (ArgumentException)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult logOut(String username)
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Login");
        }

    }
}
