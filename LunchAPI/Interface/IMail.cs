using LunchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchAPI.Interface
{
    public interface IMail
    {
        List<MailModel> GetEmailAddress();
        string SendEmailTransfer(string transfer, string receiver, int amount, int balance, DateTime date);
        string SendEmailReceiver(string transfer, string receiver, int amount, int balance, DateTime date);
        string SendEmailAdminTopup(string admin, string topup, int amount, string url, DateTime date);
        string SendEmailTopup(string topup, int amount, DateTime date);
        string SendEmailApproveTopup(string topup, int amount, DateTime date);
        string SendEmailCancelTopup(string topup, int amount, DateTime date);
        string SendEmailPay(string payer, int amount, int balance, DateTime date);
    }
}
