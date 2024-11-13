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
    public class GroupController : Controller
    {
        private IGroup Group;
        public GroupController(IGroup _Group)
        {
            Group = _Group;
        }

        [HttpGet]
        [Route("getgroups")]
        public IActionResult GetGroups()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Group.GetGroups());
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
                    return Ok(Group.GetLastID());
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
        public IActionResult Insert([FromBody] GroupMenuModel group)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Group.Insert(group));
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
        public IActionResult Update([FromBody] GroupMenuModel group)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Group.Update(group));
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
        [Route("delete/{group_id}")]
        public IActionResult Delete(string group_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Group.Delete(group_id));
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
