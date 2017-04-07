﻿using BGW.MODEL.Menu;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.FoodChartMenuManager
{
   public class FoodChartMenuManager
    {
        #region Object Initialization
        DBManager _conManager = new DBManager();
        FoodChartMenuModel _foodChartModel = new FoodChartMenuModel();
        #endregion

        #region Save FoodChartMenu
        public void SaveFoodChartMenu(List<FoodChartMenuModel> foodChartMenulist)
        {
            try
            {
                foreach (FoodChartMenuModel foodChartMenuItem in foodChartMenulist)
                {
                    if (foodChartMenuItem.MenuID == 0)
                        foodChartMenuItem.MenuID = _conManager.PrimaryKey("FoodChartMenu");
                }
                _conManager.SaveCollection(foodChartMenulist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get

        public List<FoodChartMenuModel> GetFoodMenuList()
        {
            try
            {
                return _conManager.GetDefaultCollection(_foodChartModel, string.Format("[Masterdata].[spGetMenuList]"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public FoodChartMenuModel GetFoodMenuListByMenuID(Int64 MenuID)
        {
            try
            {
                return _conManager.SingleCollection(_foodChartModel, string.Format("SELECT * FROM Masterdata.Menu WHERE MenuID={0}",MenuID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object CboMenu()
        {
            try
            {
                return _conManager.PopulateComboBox("SELECT * FROM [Settings].[MenuCategory]", "MCID", "CategoryName", "-Select Menu-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public object CboSubMenu()
        {
            try
            {
                return _conManager.PopulateComboBox("SELECT * FROM [Settings].[MenuSubCategory]", "SubCategoryID", "SubCategoryName", "-Select Sub Menu-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public object CboCurrency()
        {
            try
            {
                return _conManager.PopulateComboBox("SELECT * FROM [dbo].[Currency]", "CurrencyID", "CurrencyName", "-Select Currency-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public FoodChartMenuModel LoadTabItem()
        {
            try
            {
                return _conManager.SingleCollection(_foodChartModel, string.Format("SELECT * FROM [Settings].[MenuCategory] ORDER BY CategoryName"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}