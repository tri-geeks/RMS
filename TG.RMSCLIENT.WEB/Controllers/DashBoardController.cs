using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class DashBoardController : Controller
    {
        //
        // GET: /DashBoard/

        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["UserID"] == null)
                return RedirectToAction("Index", "Account");
            else
                return View();
        }

    }
}
