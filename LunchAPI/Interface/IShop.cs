using LunchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchAPI.Interface
{
    public interface IShop
    {
        List<ShopModel> GetShops();
        string GetLastID();
        string Insert(ShopModel shop);
        string Update(ShopModel shop);
        string UpdateStatus(ShopModel shop);
        string Delete(string shop_id);
        string UpdateCloseTimeShift(string shop_id);
    }
}
