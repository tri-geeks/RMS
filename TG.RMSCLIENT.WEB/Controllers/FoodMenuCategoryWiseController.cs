using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.MANAGER.FoodMenuCategoryWiseManager;
using BGW.MANAGER.FoodChartMenuManager;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class FoodMenuCategoryWiseController : Controller
    {
        //
        // GET: /FoodMenuCategoryWise/

        FoodChartMenuManager _FoodChartMenuManager = new FoodChartMenuManager();
        public ActionResult Index(string categoryName)
        {
            ViewBag.categoryName = categoryName;
            return View("FoodMenuCategoryWise");
        }

        public JsonResult LoadSubMenuTabItem(string categoryName)
        {
            try
            {
                return Json(_FoodChartMenuManager.LoadSubMenuTabItem(categoryName), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
