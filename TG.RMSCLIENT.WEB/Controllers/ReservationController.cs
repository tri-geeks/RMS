using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.IMSF.WEB.Models;
using BGW.MANAGER.ReservationManager;
using BGW.MODEL.Reservation;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class ReservationController : Controller
    {
        ReservationManager _allocationManager = new ReservationManager();
        [CustomAuthorizeAttribute]
        public ActionResult ReservationAllocation()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ReservationAllocationC(List<ReservationAllocationModel> allocationList, DateTime datepicker)
        {
            try
            {
                foreach(ReservationAllocationModel raitem in allocationList)
                {
                    if (raitem.AllocationID == 0)
                        raitem.Added();
                    else
                        raitem.Updated();
                    raitem.AllocationDate = datepicker;
                }
                _allocationManager.SaveReservationAllocation(allocationList);
                return Json("success");
            }
            catch(Exception ex)
            {                
                throw new Exception(ex.Message);
            } 
        }

        public JsonResult CboReservationType()
        {
            try
            {
                return Json(_allocationManager.VCboReservationType(), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult GetAllocationList(DateTime allocationDate)
        {
            try
            {
                return Json(_allocationManager.GetAllocationList(allocationDate), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult GetTimePeriod(Int64 ReservationTypeID)
        {
            try
            {
                return Json(_allocationManager.GetTimePeriod(ReservationTypeID),JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
