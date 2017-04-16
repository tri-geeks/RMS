using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.IMSF.WEB.Models;
using BGW.MANAGER.Settings;
using BGW.MODEL.Settings;
using BGW.MODEL.Settings.UserSettingsModel;
using TG.RMSCLIENT.WEB.Security;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class SettingsController : Controller
    {
        #region Object Initialization

        SettingsManager _settingManager = new SettingsManager();
        #endregion
        #region User Informatio
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [CustomAuthorizeAttribute]
        [CustomActionFilter]
        public ActionResult UserInformation()
        {
            return View();
        }
        [HttpPost]
        public JsonResult UserInformationC(UserInformationModel userModel)
        {
            if (userModel.UserID == null)
                userModel.Added();
            else
                userModel.Updated();
            List<UserInformationModel> userList = new List<UserInformationModel>();
            userList.Add(userModel);
            _settingManager.SaveUser(userList);
            return Json("success");
            //if (ModelState.IsValid)
            //{
            //    _settingManager.SaveUser(userList);
            //    return Json("success");
            //}
            //else
            //{
            //    return Json("error");
            //}

        }

        public JsonResult GetUserList()
        {
            try
            {
                return Json(_settingManager.GetUserList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Permission
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [CustomAuthorizeAttribute]
        [CustomActionFilter]
        public ActionResult MenuPermission()
        {
            return View();
        }
        [HttpPost]
        public JsonResult MenuPermissionC(List<MenuPermissionModel> menuList)
        {
            foreach (MenuPermissionModel menuitem in menuList)
            {
                if (menuitem.PermissionID == 0)
                    menuitem.Added();
                else
                    menuitem.Updated();
            }
            _settingManager.SaveMenuPermission(menuList);
            return Json(0);
        }
        public JsonResult CboUser()
        {
            return Json(_settingManager.VCboUser(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMenuListBuUserID(Int64 id)
        {
            try
            {
                return Json(_settingManager.GetMenulistByUserID(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Menu Category
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [CustomAuthorizeAttribute]
        [CustomActionFilter]
        public ActionResult MenuCategory()
        {
            return View();
        }
        [HttpPost]
        public JsonResult MenuCategoryC(List<MenuCategoryModel> categoryList)
        {
            try
            {
                foreach (MenuCategoryModel ctitem in categoryList)
                {
                    if (ctitem.MCID == 0)
                        ctitem.Added();
                    else
                        ctitem.Updated();
                }
                _settingManager.SaveMenuCategory(categoryList);
                return Json("success");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult GetMenuCategoryList()
        {
            try
            {
                return Json(_settingManager.GetMenuCategoryList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Menu Sub Category 
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [CustomAuthorizeAttribute]
        [CustomActionFilter]
        public ActionResult MenuSubCategory()
        {       
            return View();
        }
        [HttpPost]
        public JsonResult MenuSubCategoryC(List<MenuSubCategoryModel> menuSubCategoryList)
        {
            try
            {
                foreach(MenuSubCategoryModel subItem in menuSubCategoryList)
                {
                    if (subItem.SubCategoryID ==0)
                        subItem.Added();
                    else
                        subItem.Updated();
                }
                _settingManager.SaveSubCategory(menuSubCategoryList);
                return Json("success");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult CboMenuCategory()
        {
            try
            {
                return Json(_settingManager.VCboMenuCategory(), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult GetMenuSubCtegoryList()
        {
            try
            {
                return Json(_settingManager.GetMenuSubCtegoryList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Reservation Type
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [CustomAuthorizeAttribute]
        [CustomActionFilter]
        public ActionResult ReservationType()
        {
            return View();
        }

        [HttpPost]

        public JsonResult ReservationTypeC(List<ReservationTypeModel> rtypelist)
        {
            try
            {
                foreach(ReservationTypeModel ritem in rtypelist)
                {
                    if (ritem.ReservationTypeID == 0)
                        ritem.Added();
                    else
                        ritem.Updated();
                }
                _settingManager.SaveReservationType(rtypelist);
                return Json(0);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult GetReservationTypeList()
        {
            try
            {
                return Json(_settingManager.GetReservationTypeList(), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        #endregion

    }
}
