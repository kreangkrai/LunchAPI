using LunchAPI.Interface;
using LunchAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : Controller
    {
        private IMail Mail;
        public MailController(IMail _Mail)
        {
            Mail = _Mail;
        }

        [HttpGet]
        [Route("gets")]
        public IActionResult SendEmailTransfer()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Mail.GetEmailAddress());
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
        [Route("transfer")]
        public IActionResult SendEmailTransfer([FromBody] MailDataModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Mail.SendEmailTransfer(data.transfer, data.receiver, data.amount, data.balance, data.date));
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
        [Route("receiver")]
        public IActionResult SendEmailReceiver([FromBody] MailDataModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Mail.SendEmailReceiver(data.transfer, data.receiver, data.amount, data.balance, data.date));
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
        [Route("admintopup")]
        public IActionResult SendEmailAdminTopup([FromBody] MailDataModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Mail.SendEmailAdminTopup(data.admin, data.topup, data.amount, data.url, data.date));
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
        [Route("topup")]
        public IActionResult SendEmailTopup([FromBody] MailDataModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Mail.SendEmailTopup(data.topup, data.amount, data.date));
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
        [Route("approvetopup")]
        public IActionResult SendEmailApproveTopup([FromBody] MailDataModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Mail.SendEmailApproveTopup(data.topup, data.amount, data.date));
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
        [Route("canceltopup")]
        public IActionResult SendEmailCancelTopup([FromBody] MailDataModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Mail.SendEmailCancelTopup(data.topup, data.amount, data.date));
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
        [Route("pay")]
        public IActionResult SendEmailPay([FromBody] MailDataModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Mail.SendEmailPay(data.payer, data.amount, data.balance, data.date));
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
