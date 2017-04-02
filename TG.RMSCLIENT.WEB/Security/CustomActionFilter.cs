using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Routing;
using BGW.MANAGER.Settings;

namespace TG.RMSCLIENT.WEB.Security
{
    //[AttributeUsage(AttributeTargets.All)]
    public class CustomActionFilter: ActionFilterAttribute
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public Int64 UserID { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SetActionController(filterContext.RouteData);
            if (GetPermission() == null)
            {
                filterContext.Result = new RedirectToRouteResult(Url());
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            SetActionController(filterContext.RouteData);
            if (GetPermission() == null)
            {
                filterContext.Result = new RedirectToRouteResult(Url());
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            SetActionController(filterContext.RouteData);
            if (GetPermission() == null)
            {
                filterContext.Result = new RedirectToRouteResult(Url());
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            SetActionController(filterContext.RouteData);
            if (GetPermission() == null)
            {
                filterContext.Result = new RedirectToRouteResult(Url());
            }
        }

        public void SetActionController(RouteData routeData)
        {
            SettingsManager userManager = new SettingsManager();
            //MenuPermissionManager permissionManager = new MenuPermissionManager();

            ControllerName = routeData.Values["controller"].ToString();
            ActionName = routeData.Values["action"].ToString();
            UserID = Convert.ToInt64(System.Web.HttpContext.Current.Session["UserID"]);

            if (System.Web.HttpContext.Current.Session["UserID"] == null)
                new RedirectToRouteResult(Url());
            //var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            //Urj = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            //Debug.WriteLine(message, "Action Filter Log");

        }

        public RouteValueDictionary Url()
        {
            RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
            redirectTargetDictionary.Add("area", "");
            redirectTargetDictionary.Add("action", "Index");
            redirectTargetDictionary.Add("controller", "DashBoard");
            return redirectTargetDictionary;
        }

        public object GetPermission()
        {
            //UserName = AccountController.UserName;
            SettingsManager menuManager = new SettingsManager();
            if (ControllerName == "Account")
                return null;
            else
                return menuManager.GetValidUser(UserID, ControllerName, ActionName);
        }
    }
}