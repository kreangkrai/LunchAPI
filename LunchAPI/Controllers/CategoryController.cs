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
    public class CategoryController : Controller
    {
        private ICategory Category;
        public CategoryController(ICategory _Category)
        {
            Category = _Category;
        }

        [HttpGet]
        [Route("getlastid")]
        public IActionResult GetLastID()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Category.GetLastID());
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
        [Route("getcategories")]
        public IActionResult GetCategories()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Category.GetCategories());
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
        public IActionResult Insert([FromBody] CategoryMenuModel category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Category.Insert(category));
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
        public IActionResult Update([FromBody] CategoryMenuModel category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Category.Update(category));
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
        [Route("delete/{category_id}")]
        public IActionResult Delete(string category_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Category.Delete(category_id));
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
