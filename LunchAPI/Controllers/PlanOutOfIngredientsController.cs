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
    public class PlanOutOfIngredientsController : Controller
    {
        private IPlanOutOfIngredients PlanOutOfIngredients;
        public PlanOutOfIngredientsController(IPlanOutOfIngredients _PlanOutOfIngredients)
        {
            PlanOutOfIngredients = _PlanOutOfIngredients;
        }

        [HttpGet]
        [Route("getplanoutofingredients")]
        public IActionResult GetPlanOutOfIngredients()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(PlanOutOfIngredients.GetPlanOutOfIngredients());
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
        [Route("getplanoutofingredientsbydate/{now}")]
        public IActionResult GetPlanOutOfIngredientsByDate(DateTime now)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(PlanOutOfIngredients.GetPlanOutOfIngredientsByDate(now));
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
        [Route("getplanoutofingredientsbyshop/{shop_id}")]
        public IActionResult GetPlanOutOfIngredientsByShop(string shop_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(PlanOutOfIngredients.GetPlanOutOfIngredientsByShop(shop_id));
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
        public IActionResult Insert([FromBody] PlanOutOfIngredientsModel plan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(PlanOutOfIngredients.Insert(plan));
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
        [Route("deletebyid/{id}")]
        public IActionResult DeleteById(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(PlanOutOfIngredients.DeleteById(id));
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
        [Route("deletebyshop/{shop_id}")]
        public IActionResult DeleteByShop(string shop_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(PlanOutOfIngredients.DeleteByShop(shop_id));
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
