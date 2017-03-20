
using BGW.MANAGER.Settings.UserSettingsManager;
using BGW.MANAGER.Settings.Variable;
using BGW.MANAGER.Variable;
using BGW.MODEL.Settings.UserSettingsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class AccountController : Controller
    {

        public static string User { get; set; }

        public static string Url1 { get; set; }
        public static string Url2 { get; set; }


        public ActionResult Index()
        {           
                return View();
        }

        [HttpPost]
        public ActionResult Index(UserInformationModel model)
        {
            try
            {
                //System.Web.HttpContext.Current.Session["UserName"] = "";
                //UserInformationManager userManager = new UserInformationManager();
                //UserInformationModel userModel = userManager.GetUser(model.UserName, model.Password);
                //if (userModel != null)
                //{
                //    System.Web.HttpContext.Current.Session["UserName"] = userModel.UserName;
                //    User = userModel.UserName;
                //    return RedirectToAction("DashBoardView", "DashBoard");
                //}
                //else
                //{
                return RedirectToAction("Index", "DashBoard");
                    //return RedirectToAction("Index", "Account");
                //}

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Account");
                throw new Exception(ex.Message);
            }

        }
        public ActionResult LogOut()
        {
            Session.Remove("UserName");
            return RedirectToAction("Index", "Account");
        }

    }
}
