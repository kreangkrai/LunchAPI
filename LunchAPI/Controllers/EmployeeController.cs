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
    public class EmployeeController : Controller
    {
        private IEmployee Employee;
        public EmployeeController(IEmployee _Employee)
        {
            Employee = _Employee;
        }

        [HttpGet]
        [Route("getemployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Employee.GetEmployees());
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
        [Route("getuserad")]
        public IActionResult GetUserAD()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Employee.GetUserAD());
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
        [Route("getlastemployee")]
        public IActionResult GetLastEmployee()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Employee.GetLastEmployee());
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
        [Route("getemployeesctl")]
        public IActionResult GetEmployeeCTL()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Employee.GetEmployeeCTL());
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
        public IActionResult Insert([FromBody] EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Employee.Insert(employee));
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
        [Route("updaterole")]
        public IActionResult UpdateRole([FromBody] EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Employee.UpdateRole(employee));
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
        [Route("updatebalance")]
        public IActionResult UpdateBalance([FromBody] EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Employee.UpdateBalance(employee));
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
        public IActionResult UpdateStatus([FromBody] EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Employee.UpdateStatus(employee));
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
