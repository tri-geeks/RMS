using BGW.MANAGER.Settings.UserSettingsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using BGW.MANAGER.Settings;

namespace BGW.IMSF.WEB.Models
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string UserName { get; set; }

        public CustomAuthorizeAttribute()
        {
            this.UserName = System.Web.HttpContext.Current.Session["UserName"].ToString();
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool _Authorize = false;
            SettingsManager userManager = new SettingsManager();
            var res = userManager.GetUserList().FirstOrDefault(e => e.UserName == UserName);
            if (res != null)
                _Authorize = true;
            else
                _Authorize = false;
            return _Authorize;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("controller", "Account");
                redirectTargetDictionary.Add("action", "Index");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);

            }
        }

    }


    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public AuthorizeAttribute()
        {
        }
        protected virtual bool AuthorizeCore(HttpContextBase httpContext)
        {
            return false;
        }
        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
        }
        protected void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
        }

    }


}