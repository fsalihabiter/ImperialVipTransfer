using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.Common
{
    public class MailHelper
    {
        public static bool SendMail(string body, string to, string subject, bool isHtml = true)
        {
            return SendMail(body, new List<string> { to }, subject, isHtml);
        }

        public static bool SendMail(string body, List<string> to, string subject, bool isHtml = true)
        {
            bool result = false;

            try
            {
                foreach (var item in to)
                {
                    var message = new MailMessage
                    {
                        From = new MailAddress(ConfigHelper.Get<string>("MailUser")),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = isHtml
                    };

                    message.To.Add(new MailAddress(item));
                    using (var smtp = new SmtpClient(
                        ConfigHelper.Get<string>("MailHost"),
                        ConfigHelper.Get<int>("MailPort")))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials =
                            new NetworkCredential(
                                ConfigHelper.Get<string>("MailUser"),
                                ConfigHelper.Get<string>("MailPass"));
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = false;
                        smtp.Timeout = 5000;
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        smtp.Send(message);
                    }
                    message.To.Clear();
                }
            }
            catch (SmtpException)
            {
            }

            return result;
        }


        public static bool SendRezervasyonMail(string body, bool isHtml = true)
        {
            bool result = false;

            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(ConfigHelper.Get<string>("MailUser")),
                    Subject = "Rezervasyon Talebi - Imperial Vip Transfer",
                    Body = body,
                    IsBodyHtml = isHtml
                };

                message.To.Add(new MailAddress(ConfigHelper.Get<string>("MailUser")));
                using (var smtp = new SmtpClient(
                    ConfigHelper.Get<string>("MailHost"),
                    ConfigHelper.Get<int>("MailPort")))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials =
                        new NetworkCredential(
                            ConfigHelper.Get<string>("MailUser"),
                            ConfigHelper.Get<string>("MailPass"));
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = false;
                    smtp.Timeout = 5000;
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    smtp.Send(message);
                }
                result = true;
                message.To.Clear();
            }
            catch (SmtpException)
            {
            }

            return result;
        }

        public static bool SendBizeUlasinMail(string body, bool isHtml = true)
        {
            bool result = false;

            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(ConfigHelper.Get<string>("MailUser")),
                    Subject = "Bize Ulaşın - Imperial Vip Transfer",
                    Body = body,
                    IsBodyHtml = isHtml
                };

                message.To.Add(new MailAddress(ConfigHelper.Get<string>("MailUser")));
                using (var smtp = new SmtpClient(
                    ConfigHelper.Get<string>("MailHost"),
                    ConfigHelper.Get<int>("MailPort")))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials =
                        new NetworkCredential(
                            ConfigHelper.Get<string>("MailUser"),
                            ConfigHelper.Get<string>("MailPass"));
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = false;
                    smtp.Timeout = 5000;
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    smtp.Send(message);
                }
                result = true;
                message.To.Clear();
            }
            catch (SmtpException e)
            {
            }

            return result;
        }

        public static bool SendInfoMail(string body, string to, string subject, bool isHtml = true)
        {
            return SendInfoMail(body, new List<string> { to }, subject, isHtml);
        }

        public static bool SendInfoMail(string body, List<string> to, string subject, bool isHtml = true)
        {
            bool result = false;

            try
            {
                foreach (var item in to)
                {
                    var message = new MailMessage
                    {
                        From = new MailAddress(ConfigHelper.Get<string>("MailUser")),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = isHtml
                    };

                    message.To.Add(new MailAddress(item));
                    using (var smtp = new SmtpClient(
                        ConfigHelper.Get<string>("MailHost"),
                        ConfigHelper.Get<int>("MailPort")))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials =
                            new NetworkCredential(
                                ConfigHelper.Get<string>("MailUser"),
                                ConfigHelper.Get<string>("MailPass"));
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = false;
                        smtp.Timeout = 5000;
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        smtp.Send(message);
                    }
                    message.To.Clear();
                }
            }
            catch (SmtpException)
            {
            }

            return result;
        }
    }
}
