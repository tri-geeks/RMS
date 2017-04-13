using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.MANAGER.FoodMenuCategoryWiseManager;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class FoodMenuCategoryWiseController : Controller
    {
        //
        // GET: /FoodMenuCategoryWise/
        

        public ActionResult Index()
        {
            return View("FoodMenuCategoryWise");
        }

        //public JsonResult GetFoodSubMenuListByCategory(Int64 cateroryID)
        //{
        //    return Json(_FoodChartMenuManager.GetFoodMenuListByMenuID(cateroryID), JsonRequestBehavior.AllowGet);
        //}

    }
}
