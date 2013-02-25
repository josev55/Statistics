using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EndeavorlinkStats.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult err404()
        {
            return View("404");
        }

        public ActionResult err500()
        {
            return View("500");
        }
        public ActionResult err403()
        {
            return View("403");
        }
    }
}
