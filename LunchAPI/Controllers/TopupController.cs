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
    public class TopupController : Controller
    {
        private ITopup Topup;
        public TopupController(ITopup _Topup)
        {
            Topup = _Topup;
        }

        [HttpGet]
        [Route("gettopups")]
        public IActionResult GetTopups()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Topup.GetTopups());
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
        [Route("gettopupbyemployee/{employee_id}")]
        public IActionResult GetTopupByEmployee(string employee_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Topup.GetTopupByEmployee(employee_id));
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
        public IActionResult Insert([FromBody] TopupModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Topup.Insert(model));
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
        public IActionResult UpdateStatus([FromBody] TopupModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Topup.UpdateStatus(model));
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
