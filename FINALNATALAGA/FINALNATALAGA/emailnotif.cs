using System;
using System.Net;
using System.Net.Mail;

namespace final

{
    public class 
        EmailService
    {
        private string smtpServer = "smtp.gmail.com";  // Change based on your provider
        private int smtpPort = 587;  // Use 465 for SSL if needed
        private string emailSender = "abanorolin@gmail.com";  // Your email address
        private string emailPassword = "nttg aayk mpje gedl";  // Use an App Password

        public void SendEmail(string recipient, string subject, string body)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(emailSender, emailPassword);
                    smtp.EnableSsl = true; // Must be true for secure connections
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    using (MailMessage message = new MailMessage(emailSender, recipient, subject, body))
                    {
                        message.IsBodyHtml = true;
                        smtp.Send(message);
                    }
                }

                Console.WriteLine("THANK YOU FOR TRUSTING US");
                                                                                                                                                                                      
            }
            catch (Exception ex)
            {
                Console.WriteLine("UNSUCCESSFUL TRY AGAIN!");                                                                                      
                                                                               
            }
        }
    }
}
