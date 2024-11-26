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
    public class ShopController : Controller
    {
        private IShop Shop;
        public ShopController(IShop _Shop)
        {
            Shop = _Shop;
        }

        [HttpGet]
        [Route("getlastid")]
        public IActionResult GetLastID()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Shop.GetLastID());
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
        [Route("getshops")]
        public IActionResult GetShops()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Shop.GetShops());
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
        public IActionResult Insert([FromBody] ShopModel shop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Shop.Insert(shop));
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

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] ShopModel shop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Shop.Update(shop));
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

        [HttpPut]
        [Route("updatestatus")]
        public IActionResult UpdateStatus([FromBody] ShopModel shop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Shop.UpdateStatus(shop));
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
        [Route("delete/{shop_id}")]
        public IActionResult Delete(string shop_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Shop.Delete(shop_id));
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

        [HttpPut]
        [Route("updateclosetimeshift/{shop_id}")]
        public IActionResult UpdateCloseTimeShift(string shop_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Shop.UpdateCloseTimeShift(shop_id));
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
