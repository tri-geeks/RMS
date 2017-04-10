using BGW.MANAGER.FoodChartMenuManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class ViewMenuController : Controller
    {
        //
        // GET: /ViewMenu/
        FoodChartMenuManager _foodChartMenuManager = new FoodChartMenuManager();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadFoodMenu()
        {
            var list = _foodChartMenuManager.LoadTabItem();
            return Json(_foodChartMenuManager.LoadTabItem(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadSixMenuItem(string categoryName)
        {
            //var list = _foodChartMenuManager.LoadSixMenuItem();
            return Json(_foodChartMenuManager.LoadSixMenuItem(categoryName), JsonRequestBehavior.AllowGet);
        }

    }
}
