using LunchAPI.Interface;
using LunchAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanCloseShopController : Controller
    {
        private IPlanCloseShop PlanCloseShop;
        public PlanCloseShopController(IPlanCloseShop _PlanCloseShop)
        {
            PlanCloseShop = _PlanCloseShop;
        }

        [HttpGet]
        [Route("getplancloseshops")]
        public IActionResult GetPlanCloseShops()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(PlanCloseShop.GetPlanCloseShops());
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getplancloseshopsbydate")]
        public IActionResult GetPlanCloseShopsByDate(DateTime now)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(PlanCloseShop.GetPlanCloseShopsByDate(now));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] PlanCloseShopModel plan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(PlanCloseShop.Insert(plan));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("delete/{shop_id}/{date}")]
        public IActionResult Delete(string shop_id, DateTime date)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(PlanCloseShop.Delete(shop_id, date));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
