using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DMS.Utility.Library
{
    public class EmailSender
    {
        public string SMTPServer { get; set; }
        public string MailError { get; set; }

        public Boolean sendEmail(String SenderEmail, string SenderPassword, String emailTo, String emailCC,  String subject, String body, bool IsBodyHtml, List<string> attachments = null, string EmailBCC= null)
        {
            try
            {
                MailAddress mailTo = new MailAddress(SenderEmail);
                if (emailTo.Contains(";"))
                {
                    String[] addr = emailTo.Split(';');
                    for (int i = 0; i < addr.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(addr[i])) mailTo = new MailAddress(addr[i]);
                    }
                }
                else
                {
                    mailTo = new MailAddress(emailTo);
                }

                MailAddress mailFrom = new MailAddress(SenderEmail);
                MailMessage mailMessage = new MailMessage(mailFrom, mailTo);

                if (!String.IsNullOrEmpty(subject))
                {
                    mailMessage.Subject = subject;
                }
                else
                {
                    MailError = "Subject is missing";
                    return false;
                }

                if (!String.IsNullOrEmpty(body))
                {
                    mailMessage.Body = body;
                }
                else
                {
                    MailError = "Email body is missing";
                    return false;
                }

                mailMessage.IsBodyHtml = IsBodyHtml;

                if (emailTo.Contains(";"))
                {
                    String[] addr = emailTo.Split(';');
                    for (int i = 0; i < addr.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(addr[i])) mailMessage.To.Add(addr[i]);
                    }
                }


                // EMAIL CC
                if (!String.IsNullOrEmpty(emailCC))
                {
                    if (emailCC.Contains(";"))
                    {
                        String[] addr = emailCC.Split(';');
                        for (int i = 0; i < addr.Length; i++) if (!string.IsNullOrEmpty(addr[i])) mailMessage.CC.Add(addr[i]);
                    }
                    else
                    {
                        mailMessage.CC.Add(emailCC);
                    }
                }


                // EMAIL BCC
                if (!String.IsNullOrEmpty(EmailBCC))
                {
                    if (EmailBCC.Contains(";"))
                    {
                        String[] addr = emailCC.Split(';');
                        for (int i = 0; i < addr.Length; i++) if (!string.IsNullOrEmpty(addr[i])) mailMessage.Bcc.Add(addr[i]);
                    }
                    else
                    {
                        mailMessage.CC.Add(EmailBCC);
                    }
                }


                String strSMTPServer = "";
                if (!string.IsNullOrEmpty(SMTPServer)) strSMTPServer = SMTPServer;
                else strSMTPServer =  "smtp.office365.com";


                if (attachments != null)
                {
                    foreach (string item in attachments)
                    {
                        FileInfo file = new FileInfo(item);

                        if (file.Exists)
                        {
                            mailMessage.Attachments.Add(new Attachment(file.FullName));
                        }

                    }
                }

                using (SmtpClient smtpClient = new SmtpClient(strSMTPServer, 587))
                {
                    smtpClient.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    //smtpClient.UseDefaultCredentials = true;
                    if (mailMessage != null)
                    {
                        smtpClient.Send(mailMessage);
                        smtpClient.Dispose();
                        mailMessage.Dispose();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MailError = ex.Message;
                return false;
            }
        }


    }
}
