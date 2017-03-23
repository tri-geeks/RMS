using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class FoodMenuController : Controller
    {
        //
        // GET: /FoodMenu/

        public ActionResult FoodMenuA()
        {
            return View();
        }


        public ActionResult ViewMenuList()
        {
            return View();
        }
    }
}
