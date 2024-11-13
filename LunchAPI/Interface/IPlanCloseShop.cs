﻿using LunchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchAPI.Interface
{
    public interface IPlanCloseShop
    {
        List<PlanCloseShopModel> GetPlanCloseShops();
        List<PlanCloseShopModel> GetPlanCloseShopsByDate(DateTime now);
        string Insert(PlanCloseShopModel plan);
        string Delete(string shop_id,DateTime date);
    }
}
