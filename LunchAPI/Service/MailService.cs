using LunchAPI.Interface;
using LunchAPI.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LunchAPI.Service
{
    public class MailService : IMail
    {
        public List<MailModel> GetEmailAddress()
        {
            List<MailModel> mails = new List<MailModel>();
            var dirEntry = new DirectoryEntry(string.Format("LDAP://192.168.15.1", "rd", "Contrologic1988"));
            var searcher = new DirectorySearcher(dirEntry)
            {
                Filter = "(&(&(objectClass=user)(objectClass=person)))"
            };
            var resultCollection = searcher.FindAll();

            for (int i = 0; i < resultCollection.Count; i++)
            {
                if (resultCollection[i].Properties["mail"].Count == 1)
                {
                    var email = (string)resultCollection[i].Properties["mail"][0];
                    var name = (string)resultCollection[i].Properties["name"][0];
                    mails.Add(new MailModel()
                    {
                        name = name.ToLower(),
                        email = email
                    });
                }
            }
            return mails;
        }

        public string SendEmailTransfer(string transfer,string receiver,int amount , int balance,DateTime date)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                string password = "P@ssw0rd";
                string from = "lor@contrologic.co.th";
                mail.From = new MailAddress(from);
                mail.To.Add(transfer);

                mail.Subject = "แจ้งเตือนระบบโอนเงินโปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:16px;""><b>แจ้งเตือนระบบโอนเงิน</b></p>
                    <p>วันที่ทำรายการ : {date.ToString("dd/MM/yyyy HH:mm:ss")}</p>
                    <p>เพื่อเข้าบัญชี   : {receiver}</p>
                    <p>จำนวนเงิน    : {amount} บาท</p>
                    <p>ยอดคงเหลือ   : {balance} บาท</p>
                ");

                mail.IsBodyHtml = true;
                mail.Body = body;
                SmtpServer.EnableSsl = false;
                SmtpServer.Host = "192.168.15.3";
                SmtpServer.Port = 25;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(from, password);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Success";
        }
        public string SendEmailReceiver(string transfer, string receiver, int amount, int balance, DateTime date)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                string password = "P@ssw0rd";
                string from = "lor@contrologic.co.th";
                mail.From = new MailAddress(from);
                mail.To.Add(receiver);

                mail.Subject = "แจ้งเตือนระบบรับเงินโปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:16px;""><b>แจ้งเตือนระบบรับเงิน</b></p>
                    <p>วันที่ทำรายการ : {date.ToString("dd/MM/yyyy HH:mm:ss")}</p>
                    <p>จากบัญชี     : {transfer}</p>
                    <p>จำนวนเงิน    : {amount} บาท</p>
                    <p>ยอดคงเหลือ   : {balance} บาท</p>
                ");

                mail.IsBodyHtml = true;
                mail.Body = body;
                SmtpServer.EnableSsl = false;
                SmtpServer.Host = "192.168.15.3";
                SmtpServer.Port = 25;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(from, password);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Success";
        }
        public string SendEmailAdminTopup(string admin, string topup, int amount, string url, DateTime date)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                string password = "P@ssw0rd";
                string from = "lor@contrologic.co.th";
                mail.From = new MailAddress(from);
                mail.To.Add(admin);
                mail.To.Add(topup);

                string imageUrl = url;
                string tempPath = Path.GetTempFileName();
                string imagePath = Path.ChangeExtension(tempPath, ".jpg");
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(imageUrl, imagePath);
                }
                Attachment item = new Attachment(imagePath);
                mail.Attachments.Add(item);
                mail.Subject = "แจ้งเตือนระบบเติมเงินโปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:16px;""><b>แจ้งเตือนระบบเติมเงิน</b></p>
                    <p>วันที่ทำรายการ : {date.ToString("dd/MM/yyyy HH:mm:ss")}</p>
                    <p>จากบัญชี     : {topup}</p>
                    <p>จำนวนเงิน    : {amount} บาท</p>
                    <p>สถานะ      : รออนุมัติ</p>
                ");

                mail.IsBodyHtml = true;
                mail.Body = body;
                SmtpServer.EnableSsl = false;
                SmtpServer.Host = "192.168.15.3";
                SmtpServer.Port = 25;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(from, password);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Success";
        }
        public string SendEmailTopup(string topup, int amount, DateTime date)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                string password = "P@ssw0rd";
                string from = "lor@contrologic.co.th";
                mail.From = new MailAddress(from);
                mail.To.Add(topup);

                mail.Subject = "แจ้งเตือนระบบเติมเงินโปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:16px;""><b>แจ้งเตือนระบบเติมเงิน</b></p>
                    <p>วันที่ทำรายการ : {date.ToString("dd/MM/yyyy HH:mm:ss")}</p>
                    <p>จำนวนเงิน    : {amount} บาท</p>
                ");

                mail.IsBodyHtml = true;
                mail.Body = body;
                SmtpServer.EnableSsl = false;
                SmtpServer.Host = "192.168.15.3";
                SmtpServer.Port = 25;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(from, password);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Success";
        }
        public string SendEmailApproveTopup(string topup, int amount, DateTime date)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                string password = "P@ssw0rd";
                string from = "lor@contrologic.co.th";
                mail.From = new MailAddress(from);
                mail.To.Add(topup);

                mail.Subject = "แจ้งเตือนระบบเติมเงินโปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:16px;""><b>แจ้งเตือนระบบเติมเงิน</b></p>
                    <p>วันที่ทำรายการ : {date.ToString("dd/MM/yyyy HH:mm:ss")}</p>
                    <p>จำนวนเงิน    : {amount} บาท</p>
                    <p>สถานะ      : อนุมัติแล้ว</p>
                ");

                mail.IsBodyHtml = true;
                mail.Body = body;
                SmtpServer.EnableSsl = false;
                SmtpServer.Host = "192.168.15.3";
                SmtpServer.Port = 25;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(from, password);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Success";
        }
        public string SendEmailCancelTopup(string topup, int amount, DateTime date)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                string password = "P@ssw0rd";
                string from = "lor@contrologic.co.th";
                mail.From = new MailAddress(from);
                mail.To.Add(topup);

                mail.Subject = "แจ้งเตือนระบบเติมเงินโปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:16px;""><b>แจ้งเตือนระบบเติมเงิน</b></p>
                    <p>วันที่ทำรายการ : {date.ToString("dd/MM/yyyy HH:mm:ss")}</p>
                    <p>จำนวนเงิน    : {amount} บาท</p>
                    <p>สถานะ      : ไม่อนุมัติ</p>
                ");

                mail.IsBodyHtml = true;
                mail.Body = body;
                SmtpServer.EnableSsl = false;
                SmtpServer.Host = "192.168.15.3";
                SmtpServer.Port = 25;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(from, password);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Success";
        }
        public string SendEmailPay(string payer, int amount, int balance, DateTime date)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                string password = "P@ssw0rd";
                string from = "lor@contrologic.co.th";
                mail.From = new MailAddress(from);
                mail.To.Add(payer);

                mail.Subject = "แจ้งเตือนระบบจ่ายเงินโปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:16px;""><b>แจ้งเตือนระบบจ่ายเงิน</b></p>
                    <p>วันที่ทำรายการ : {date.ToString("dd/MM/yyyy HH:mm:ss")}</p>
                    <p>จำนวนเงิน    : {amount} บาท</p>
                    <p>ยอดคงเหลือ   : {balance} บาท</p>
                ");

                mail.IsBodyHtml = true;
                mail.Body = body;
                SmtpServer.EnableSsl = false;
                SmtpServer.Host = "192.168.15.3";
                SmtpServer.Port = 25;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(from, password);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Success";
        }
    }
}
