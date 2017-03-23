using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/

        public ActionResult UserInformation()
        {
            return View();
        }

        public ActionResult MenuPermission()
        {
            return View();
        }

        public ActionResult MenuCategory()
        {
            return View();
        }
        public ActionResult MenuSubCategory()
        {
            return View();
        }

    }
}
