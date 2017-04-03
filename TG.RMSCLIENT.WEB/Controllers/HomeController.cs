using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult SendRating(string r, string s, string id, string url)
        {
            int autoId = 0;
            int thisRating = 0;
            int sectionId = 0;
            int.TryParse(s, out sectionId);
            int.TryParse(r, out thisRating);
            int.TryParse(id, out autoId);
            if (!User.Identity.IsAuthenticated)
            {
                return Json("Not authenticated!");
            }
            if (autoId.Equals(0))
            {
                return Json("Record to vote doesn't exist");
            }
            switch (s)
            {
                case "5":
                    var isIt = 
                default:
                    break;
            }
        }
    }
}
