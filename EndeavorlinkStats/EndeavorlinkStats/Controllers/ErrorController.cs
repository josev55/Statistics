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

    }
}
