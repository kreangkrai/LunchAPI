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
    public class AuthenController : Controller
    {
        private IAuthen Authen;
        public AuthenController(IAuthen _Authen)
        {
            Authen = _Authen;
        }
        [HttpGet("{username}/{password}")]
        public IActionResult ActiveDirectoryAuthenticate(string username, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AuthenModel authen = Authen.ActiveDirectoryAuthenticate(username, password);
                    return Ok(authen);
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
