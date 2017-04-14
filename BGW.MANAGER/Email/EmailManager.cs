using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BGW.MANAGER.Email
{
    public class EmailManager
    {
        public void Email(EmailCriteriaVM objEmailCriteriaVM)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["email_sender"], ConfigurationManager.AppSettings["sender_name"]);
            MailMessage _mail = new MailMessage();            
            bool IsSuccess = false;
            string Subject = objEmailCriteriaVM.Subject;
            try
            {
                _mail.From = fromAddress;

                if (!string.IsNullOrEmpty(Subject))
                {
                    _mail.Subject = Subject;
                }
                _mail.Body = objEmailCriteriaVM.Content;
                _mail.Body = ConfigurationSettings.AppSettings["email_body"];
                //if (ConfigurationManager.AppSettings["email_logo_path"] != null)
                //{
                    string writtenText = objEmailCriteriaVM.Content;
                    //string text = ConfigurationSettings.AppSettings["email_body"];
                    //string logo = ConfigurationManager.AppSettings["email_logo_path"];
                    //_mail.Body = _mail.Body.Replace(logo, "cid:logo");
                    //Attachment oAttachment = new Attachment(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["email_logo_path"]));
                    string contentID = "logo";
                    //oAttachment.ContentId = contentID;
                    //_mail.Attachments.Add(oAttachment);
                    _mail.Body = "<html><body>" + objEmailCriteriaVM.Content + "<img src=\"cid:" + contentID + "\"></body></html>";
                //}
                _mail.IsBodyHtml = true;
                smtpClient.Host = ConfigurationManager.AppSettings["SMTP"];
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["enableSsl"]))
                    smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["enableSsl"].ToString());
                if (ConfigurationManager.AppSettings["SMTPPort"] != null)
                    smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"].ToString());

                smtpClient.Timeout = 600000;
                smtpClient.Send(_mail);
                IsSuccess = true;

                //EMailDBContext _ctx = new EMailDBContext();
               // string today = DateTime.Now.ToString("MM/dd/yyyy");
                //List<EmailStatusLog> emailStat = _ctx.emailStatusLogs.Where(x => x.Date == today && x.IsActive == true && x.Investor_Code == emailreceipent.stInvestor_code).ToList();
                //foreach (var item in emailStat)
                //{
                //    if (item.Id != null)
                //    {
                //        if (IsSuccess == true)
                //        {
                //            item.EmailSendStatus = true;
                //            item.IsActive = false;
                //        }
                //        _ctx.SaveChanges();
                //    }
                //}

            }
            catch (Exception ex)
            {
                IsSuccess = false;
                string lastErrorTypeName = ex.GetType().ToString();
                string lastErrorMessage = ex.Message;
                //EMailDBContext _ctx = new EMailDBContext();
                //List<ExceptionLog> lstExceptionLog = new List<ExceptionLog>();
                //ExceptionLog objExceptionLog = new ExceptionLog();
                //objExceptionLog.ExceptionDate = DateTime.Now;
                //objExceptionLog.Description = lastErrorTypeName + " : " + lastErrorMessage;
                //_ctx.exceptionLog.Add(objExceptionLog);
                //_ctx.SaveChanges();
            }
            finally
            {
                bool IsAttachment = (_mail.Attachments.Count > 0 ? true : false);
            }

        }
    }
}
