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
    public class MenuController : Controller
    {
        private IMenu Menu;
        public MenuController(IMenu _Menu)
        {
            Menu = _Menu;
        }

        [HttpGet]
        [Route("getmenus")]
        public IActionResult GetMenus()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Menu.GetMenus());
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
        [Route("getmenubyshop/{shop_id}")]
        public IActionResult GetMenuByShop(string shop_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Menu.GetMenuByShop(shop_id));
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
        [Route("getmenubymenu/{menu_id}")]
        public IActionResult GetMenuByMenu(string menu_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Menu.GetMenuByMenu(menu_id));
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
        [Route("searchmenubyshop/{shop_id}/{menu}")]
        public IActionResult SearchMenuByShop(string shop_id, string menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Menu.SearchMenuByShop(shop_id, menu));
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
        [Route("getlastid")]
        public IActionResult GetLastID()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Menu.GetLastID());
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
        public IActionResult Insert([FromBody] MenuModel menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Menu.Insert(menu));
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
        public IActionResult Update([FromBody] MenuModel menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Menu.Update(menu));
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
        [Route("delete/{menu_id}")]
        public IActionResult Delete(string menu_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Menu.Delete(menu_id));
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
