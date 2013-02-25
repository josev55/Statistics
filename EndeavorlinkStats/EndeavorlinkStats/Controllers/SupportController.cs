using EndeavorlinkStats.DAL;
using EndeavorlinkStats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EndeavorlinkStats.Controllers
{
    public class SupportController : Controller
    {
        //
        // GET: /Support/
        private readonly ISupportService _supportService;
        SMSModel smsModel = new SMSModel();
        public SupportController(ISupportService supportService)
        {
            _supportService = supportService;
        }
        public ActionResult Index()
        {
            if (Session["username"].ToString().Equals("admin") || Session["username"].ToString().Equals("support"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("err403", "Error");
            }
            
        }

        /// <summary>
        /// Get the specific support page for the operator
        /// </summary>
        /// <param name="oper">
        /// Operator for the requested page
        /// </param>
        /// <returns>Partial View</returns>
        [HttpGet]
        public PartialViewResult getSupportByOperator(String oper)
        {
            if (oper == "movistar")
            {
                return PartialView("movistar_support");
            }
            else if (oper == "claro")
            {
                return PartialView("claro_support");
            }
            else if (oper == "comcel")
            {
                return PartialView("comcel_support");
            }
            else
            {
                return PartialView("telcel_support");
            }
        }
        public PartialViewResult getMOMTByMSISDN(String msisdn, String oper)
        {
            smsModel.oper = oper;
            smsModel.sms_mo = _supportService.getMObyMSISDN(msisdn);
            smsModel.sms_mt = _supportService.getMTbyMSISDN(msisdn);
            return PartialView("smsreport", smsModel);
        }
        [HttpGet]
        public PartialViewResult getShortcodes(String oper, String view)
        {
            smsModel.sms_sc = _supportService.getShortcodesByOperator(oper);
            return PartialView(view, smsModel);
        }
        [HttpPost]
        public Boolean cancellUser(String msisdn, String shortcode, String msg, String oper)
        {
            return _supportService.insertSMS(shortcode, msg, msisdn,oper);
        }
        [HttpGet]
        public PartialViewResult getBuscadorSMS(String oper)
        {
            smsModel.oper = oper;
            return PartialView("buscadorSMS", smsModel);
        }

        [HttpPost]
        public Boolean sendSMS(String msisdn, String shortcode, String msg, String oper)
        {
            return _supportService.sendSMS(shortcode, msg, msisdn,oper);
        }

        [HttpGet]
        public ActionResult testCP(String msisdn, String shortcode, String msg)
        {
            //ClaroHelpers.ClaroSMS.sendClaroPeru(msisdn, msg, shortcode);
            return View();
        }

    }
}
