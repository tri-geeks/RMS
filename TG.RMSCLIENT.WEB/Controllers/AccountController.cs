
using BGW.MANAGER.Settings.UserSettingsManager;
using BGW.MANAGER.Settings.Variable;
using BGW.MANAGER.Variable;
using BGW.MODEL.Settings.UserSettingsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.MANAGER.Settings;
using System.Web.SessionState;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class AccountController : Controller
    {        

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
                SettingsManager userManager = new SettingsManager();
               UserInformationModel userModel = userManager.GetUser(model.UserName, model.Password);
                if (userModel != null)
                {
                    System.Web.HttpContext.Current.Session["UserName"] = userModel.UserName;
                    System.Web.HttpContext.Current.Session["UserID"] = userModel.UserID;
                    return RedirectToAction("Index", "DashBoard");
                }
                else
                {
                    ///return RedirectToAction("Index", "DashBoard");
                    return RedirectToAction("Index", "Account");
                }

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
            Session.Remove("UserID");
            Session.Clear();
            return RedirectToAction("Index", "Account");
        }

        public ActionResult About()
        {
            return View();
        }


    }
}
