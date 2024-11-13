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
    public class ReserveController : Controller
    {
        private IReserve Reserve;
        public ReserveController(IReserve _Reserve)
        {
            Reserve = _Reserve;
        }

        [HttpGet]
        [Route("getreserves")]
        public IActionResult GetReserves()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Reserve.GetReserves());
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
        [Route("getreservebydate/{date}")]
        public IActionResult GetReserveByDate(DateTime date)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Reserve.GetReserveByDate(date));
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
        [Route("getreservebydateemployee/{date}/{employee_id}")]
        public IActionResult GetReserveByDateEmployee(DateTime date, string employee_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Reserve.GetReserveByDateEmployee(date, employee_id));
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
        [Route("getreservebyshopdateemployee/{shop_id}/{date}/{employee_id}")]
        public IActionResult GetReserveByShopDateEmployee(string shop_id, DateTime date, string employee_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Reserve.GetReserveByShopDateEmployee(shop_id,date,employee_id));
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
        [Route("getreservebyshopdate/{shop_id}/{date}")]
        public IActionResult GetReserveByShopDate(string shop_id, DateTime date)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Reserve.GetReserveByShopDate(shop_id, date));
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
        public IActionResult Insert([FromBody] ReserveModel reserve)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Reserve.Insert(reserve));
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
        [Route("updatedelivery")]
        public IActionResult UpdateDelivery([FromBody] ReserveModel reserve)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Reserve.UpdateDelivery(reserve));
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
        [Route("updatestatus/{reserve_id}/{status}")]
        public IActionResult UpdateStatus(string reserve_id, string status)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Reserve.UpdateStatus(reserve_id, status));
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
        [Route("updatereview/{reserve_id}/{review}")]
        public IActionResult UpdateReview(string reserve_id, int review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Reserve.UpdateReview(reserve_id, review));
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
        [Route("computeamountdeliverybalance/{delivery_service}/{count_reserve}/{current_balance}")]
        public IActionResult ComputeAmountDeliveryBalance(int delivery_service, int count_reserve, int current_balance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Reserve.ComputeAmountDeliveryBalance(delivery_service, count_reserve, current_balance));
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
