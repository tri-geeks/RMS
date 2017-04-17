using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.MANAGER.FoodMenuCategoryWiseManager;
using BGW.MANAGER.FoodChartMenuManager;
using BGW.IMSF.WEB.Models;
using TG.RMSCLIENT.WEB.Security;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class FoodMenuCategoryWiseController : Controller
    {
        //
        // GET: /FoodMenuCategoryWise/

        FoodChartMenuManager _FoodChartMenuManager = new FoodChartMenuManager();
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [CustomAuthorizeAttribute]
        [CustomActionFilter]
        public ActionResult Index(string categoryName)
        {
            ViewBag.categoryName = categoryName;
            return View("FoodMenuCategoryWise");
        }
       // [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server, Duration = 1000, VaryByParam = "categoryName")]
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
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server, Duration = 1000, VaryByParam = "SubCategoryName")]
        public JsonResult LoadAllSubCategoryItem(string SubCategoryName)
        {
            try
            {
                return Json(_FoodChartMenuManager.LoadAllSubCategoryItem(SubCategoryName), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
