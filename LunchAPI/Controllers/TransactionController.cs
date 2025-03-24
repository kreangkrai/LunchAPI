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
    public class TransactionController : Controller
    {
        private ITransaction Transaction;
        public TransactionController(ITransaction _Transaction)
        {
            Transaction = _Transaction;
        }

        [HttpGet]
        [Route("gettransactions")]
        public IActionResult GetTransactions()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Transaction.GetTransactions());
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
        [Route("getcentralmoneytransactions")]
        public IActionResult GetCentralMoneyTransactions()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Transaction.GetCentralMoneyTransactions());
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
        [Route("gettransactionbyemployee/{employee_id}")]
        public IActionResult GetTransactionByEmployee(string employee_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Transaction.GetTransactionByEmployee(employee_id));
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
        [Route("gettransactionbydate/{date}")]
        public IActionResult GetTransactionByDate(DateTime date)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Transaction.GetTransactionByDate(date));
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
        [Route("gettransactionbymonth/{month}")]
        public IActionResult GetTransactionByMonth(string month)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Transaction.GetTransactionByMonth(month));
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
        public IActionResult Insert([FromBody] TransactionModel transaction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(Transaction.Insert(transaction));
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
