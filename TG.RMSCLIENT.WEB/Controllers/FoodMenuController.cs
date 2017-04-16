using BGW.MANAGER.FoodChartMenuManager;
using BGW.MODEL.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.IMSF.WEB.Models;
using TG.RMSCLIENT.WEB.Security;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class FoodMenuController : Controller
    {
        //
        // GET: /FoodMenu/
        FoodChartMenuManager _FoodChartMenuManager = new FoodChartMenuManager();
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [CustomAuthorizeAttribute]
        [CustomActionFilter]
        public ActionResult FoodMenuA()
        {
            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [CustomAuthorizeAttribute]
        [CustomActionFilter]
        public ActionResult ViewMenuList()
        {
            return View();
        }

        public JsonResult LoadFoodMenu()
        {
            return Json(_FoodChartMenuManager.CboMenu(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadFoodSubMenu()
        {
            return Json(_FoodChartMenuManager.CboSubMenu(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult FoodChartMenu(FoodChartMenuModel foodChartMenumodel, HttpPostedFileBase file)
        {
            var filename = Path.GetFileName(file.FileName);
            var actualpath = Path.Combine(Server.MapPath("~/MenuIMG/"), filename);
            var Virtualpath = @"/MenuIMG/" + filename;

            if (foodChartMenumodel.VirtualPath == null)
            {
                foodChartMenumodel.VirtualPath = Virtualpath;
                foodChartMenumodel.ActualPath = actualpath;
                file.SaveAs(actualpath);
            }
            else
            {
                var DeleteImg = Server.MapPath("~/MenuIMG/") + Path.GetFileName(foodChartMenumodel.VirtualPath);
                System.IO.File.Delete(DeleteImg);
                foodChartMenumodel.VirtualPath = Virtualpath;
                foodChartMenumodel.ActualPath = actualpath;
                file.SaveAs(actualpath);
            }

            if (foodChartMenumodel.MenuID == 0)
                foodChartMenumodel.Added();
            else
                foodChartMenumodel.Updated();

            List<FoodChartMenuModel> foodchartlist = new List<FoodChartMenuModel>();
            foodchartlist.Add(foodChartMenumodel);
            _FoodChartMenuManager.SaveFoodChartMenu(foodchartlist);
            return Json(0);
        }

        public JsonResult GetFoodMenuList ()
        {
            return Json(_FoodChartMenuManager.GetFoodMenuList(),JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFoodMenuListByMenuID(Int64 MenuID)
        {
            return Json(_FoodChartMenuManager.GetFoodMenuListByMenuID(MenuID), JsonRequestBehavior.AllowGet);
        }
    }
}
