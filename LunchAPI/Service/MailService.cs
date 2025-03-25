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

                mail.Subject = "แจ้งเตือนระบบโอนเงิน โปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:36px;font-family:Cordia New""><b>แจ้งเตือนระบบโอนเงิน</b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b>รายละเอียดการโอนเงิน</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">วันที่ทำรายการ      : <b>{date.ToString("dd/MM/yyyy HH:mm:ss")}</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">ผู้รับเงินโอน        : <b>{receiver.Split('@')[0]}</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">จำนวนเงินที่โอน     : <b>{amount}</b> บาท</p>
                    <p style=""font-size:24px;font-family:Cordia New"">ยอดคงเหลือในปัจจุบัน : <b>{balance}</b> บาท</p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>ขอบคุณที่ใช้บริการ</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Best Regards,</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Lunch Order Reserve (LOR)</i></b></p>
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

                mail.Subject = "แจ้งเตือนระบบรับเงิน โปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:36px;""><b>คุณได้รับเงินโอนเรียบร้อยแล้ว</b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b>รายละเอียดการโอนเงิน</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">วันที่ทำรายการ      : <b>{date.ToString("dd/MM/yyyy HH:mm:ss")}</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">ผู้โอนเงิน        : <b>{transfer.Split('@')[0]}</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">จำนวนเงินที่ได้รับ     : <b>{amount}</b> บาท</p>
                    <p style=""font-size:24px;font-family:Cordia New"">ยอดคงเหลือในปัจจุบัน : <b>{balance}</b> บาท</p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>ขอบคุณที่ใช้บริการ</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Best Regards,</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Lunch Order Reserve (LOR)</i></b></p>
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
                mail.Subject = "แจ้งเตือนระบบเติมเงิน โปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:36px;""><b>มีผู้ทำรายการเติมเงิน</b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b>รายละเอียดการเติมเงิน</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">วันที่ทำรายการ     : <b>{date.ToString("dd/MM/yyyy HH:mm:ss")}</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">ผู้ทำรายการเติมเงิน  : <b>{topup.Split('@')[0]}</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">จำนวนเงิน        : <b>{amount}</b> บาท</p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>ขอบคุณที่ใช้บริการ</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Best Regards,</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Lunch Order Reserve (LOR)</i></b></p>
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

                mail.Subject = "แจ้งเตือนระบบเติมเงิน โปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:36px;""><b>ทำรายการเติมเงินเรียบร้อยแล้ว กรุณารอแอดมินดำเนินการ</b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b>รายละเอียดการเติมเงิน</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">วันที่ทำรายการ     : <b>{date.ToString("dd/MM/yyyy HH:mm:ss")}</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">จำนวนเงิน        : <b>{amount}</b> บาท</p>
                    <p style=""font-size:22px;font-family:Cordia New"">สถานะ           : <b>รอดำเนินการ</b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>ขอบคุณที่ใช้บริการ</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Best Regards,</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Lunch Order Reserve (LOR)</i></b></p>
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
        public string SendEmailApproveTopup(string topup, int amount,int balance, DateTime date)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                string password = "P@ssw0rd";
                string from = "lor@contrologic.co.th";
                mail.From = new MailAddress(from);
                mail.To.Add(topup);

                mail.Subject = "แจ้งเตือนระบบเติมเงิน โปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:36px;color:blue""><b>การเติมเงินเข้าบัญชีคุณสำเร็จแล้ว</b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b>รายละเอียดการเติมเงิน</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">วันที่ทำรายการ        : <b>{date.ToString("dd/MM/yyyy HH:mm:ss")}</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">จำนวนเงิน           : <b>{amount}</b> บาท</p>
                    <p style=""font-size:22px;font-family:Cordia New"">สถานะ              : <b>สำเร็จ</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">ยอดเงินคงเหลือในปัจจุบัน : <b>{balance}</b> บาท</p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>ขอบคุณที่ใช้บริการ</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Best Regards,</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Lunch Order Reserve (LOR)</i></b></p>
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

                mail.Subject = "แจ้งเตือนระบบเติมเงิน โปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:36px;color:red""><b>การเติมเงินเข้าบัญชีคุณไม่สำเร็จ</b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b>รายละเอียดการเติมเงิน</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">วันที่ทำรายการ        : <b>{date.ToString("dd/MM/yyyy HH:mm:ss")}</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">จำนวนเงิน           : <b>{amount}</b> บาท</p>
                    <p style=""font-size:22px;font-family:Cordia New"">สถานะ              : <b>ถูกยกเลิก</b></p>
                    <p style=""font-size:24px;font-family:Cordia New""><b>กรุณาทำรายการใหม่อีกครั้ง</b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>ขอบคุณที่ใช้บริการ</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Best Regards,</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Lunch Order Reserve (LOR)</i></b></p>
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

                mail.Subject = "แจ้งเตือนระบบจ่ายเงิน โปรแกรมจองข้าว";
                string body = string.Format($@"
                    <p style=""font-size:36px;color:blue""><b>การสั่งอาหารของคุณสำเร็จแล้ว</b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b>รายละเอียดการสั่งอาหาร</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">วันที่ทำรายการ        : <b>{date.ToString("dd/MM/yyyy HH:mm:ss")}</b></p>
                    <p style=""font-size:22px;font-family:Cordia New"">จำนวนเงิน           : <b>{amount}</b> บาท</p>
                    <p style=""font-size:24px;font-family:Cordia New"">ยอดคงเหลือในปัจจุบัน   : <b>{balance}</b> บาท</p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>ขอบคุณที่ใช้บริการ</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Best Regards,</i></b></p>
                    <p style=""font-size:28px;font-family:Cordia New""><b><i>Lunch Order Reserve (LOR)</i></b></p>
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
