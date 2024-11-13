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
    public class IngredientsController : Controller
    {
        private IIngredients Ingredients;
        public IngredientsController(IIngredients _Ingredients)
        {
            Ingredients = _Ingredients;
        }

        [HttpGet]
        [Route("getlastid")]
        public IActionResult GetLastID()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Ingredients.GetLastID());
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
        [Route("getingredients")]
        public IActionResult GetIngredients()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Ingredients.GetIngredients());
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
        public IActionResult Insert([FromBody] IngredientsMenuModel ingredients)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Ingredients.Insert(ingredients));
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
        public IActionResult Update([FromBody] IngredientsMenuModel ingredients)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Ingredients.Update(ingredients));
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
        [Route("delete/{ingredients_id}")]
        public IActionResult Delete(string ingredients_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Ingredients.Delete(ingredients_id));
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
