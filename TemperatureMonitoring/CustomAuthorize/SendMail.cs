using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace TemperatureMonitoring.CustomAuthorize
{
    public class SendMail
    {
        public static void SendmailTemp(string [] recipientsto, string subbject, string pbody, string _exporttime)
        {
            try
            {
                //DataTable dtEmail = DAL.SQL.GetDataTabale(string.Format("select distinct email from EMAIL_SETTING where transporter='{0}'  and CustCode='" + Cust_code + "'", Transporter), CommandType.Text);

                //string[] recipientscc = File.ReadAllLines(Application.StartupPath + @"/listmailCC_DHLSerial_MAIN.txt");
                ////string[] recipientscc = File.ReadAllLines(Application.StartupPath + @"/listmailCC_DHLSerial_TEST.txt");
                //string recipientcc;
                ////string[] recipientsto = File.ReadAllLines(Application.StartupPath + @"/listmailto_DHLSerial_TEST.txt");
                //string[] recipientsto = File.ReadAllLines(Application.StartupPath + @"/listmailto_DHLSerial_MAIN.txt");
                string recipientto;
                //SmtpClient client = new SmtpClient("smtp.gmail.com");

                //string[] recipientsto = new string[] { "minhsang.nguyen@vn.yusen-logistics.com" };
                SmtpClient client = new SmtpClient()
                {
                    Host = "172.19.199.10",
                    Port = 25,
                    Credentials = new NetworkCredential("system.notification@vn.yusen-logistics.com", "Abc12345"),
                    EnableSsl = false


                };




                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                ////smtp google test
                //SmtpClient client = new SmtpClient()
                //{
                //    Host = "smtp.gmail.com",
                //    Port = 587,
                //    UseDefaultCredentials = false,
                //    Credentials = new NetworkCredential("x33ng.12a1@gmail.com", "iml-lokhung"),

                //    EnableSsl = true
                //};

                mail.From = new MailAddress("system.notification@vn.yusen-logistics.com");
                //mail.From = new MailAddress("x33ng.12a1@gmail.com");

                // list mailcc
                //if (recipientscc != null)
                //{
                //    foreach (var recipientLine in recipientscc)
                //    {
                //        // Just to take care of leading/trailing spaces and blank lines
                //        recipientcc = recipientLine.Trim();
                //        if (!string.IsNullOrEmpty(recipientcc))
                //        {
                //            MailAddress cc = new MailAddress(recipientcc);
                //            mail.CC.Add(cc);
                //        }
                //    }
                //}


                // list mailto 
                foreach (var recipientLine in recipientsto)
                {
                    // Just to take care of leading/trailing spaces and blank lines
                    recipientto = recipientLine.Trim();
                    if (!string.IsNullOrEmpty(recipientto))
                    {
                        MailAddress to = new MailAddress(recipientto);
                        mail.To.Add(to);
                    }
                }

                // MailAddress to = new MailAddress(pMailto);
                //mail.To.Add(to);
                //foreach (var recipientLine in recipientscc)
                //{
                //    // Just to take care of leading/trailing spaces and blank lines
                //    recipientcc = recipientLine.Trim();
                //    if (!string.IsNullOrEmpty(recipientcc))
                //    {
                //        MailAddress cc = new MailAddress(recipientcc);
                //        mail.CC.Add(cc);
                //    }
                //}
                //msg.From = new MailAddress("cnghia.tt@gmail.com");
                //  msg.From = new MailAddress("YLVN.IMP2@sg.yusen-logistics.com");
                mail.Subject = string.Format(@"{0} ({1}) ",subbject, DateTime.Now.ToString("dd/MMM/yyyy"));

                mail.Body = pbody;
//                @"Dear Transportation Team,

 

//                Kindly refer to the attached file for Serial List extracted from system.

 

//                This is auto messages from system. Please, DON'T REPLY.

 

//Thank you.
//HCM Warehouse Team.";
                //mail.Body = pbody; //body
                //mail.IsBodyHtml = true;
                //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(pbody, null, "text/html");

                ////Add Image
                //LinkedResource img001 = new LinkedResource(System.AppDomain.CurrentDomain.BaseDirectory + @"\Imgs\image001.png", "image/png");
                //img001.ContentId = "image001.png";
                //LinkedResource img002 = new LinkedResource(System.AppDomain.CurrentDomain.BaseDirectory + @"\Imgs\image002.png", "image/png");
                //img002.ContentId = "image002.png";

                //Add the Image to the Alternate view
                //htmlView.LinkedResources.Add(img001);
                //htmlView.LinkedResources.Add(img002);

                //mail.AlternateViews.Add(htmlView);

                //  Attachment data = new Attachment();
                // data.
                //if (System.IO.File.Exists(pFilename))
                //    mail.Attachments.Add(new Attachment(pFilename));

                //if (System.IO.File.Exists(strCancelDO))
                //    mail.Attachments.Add(new Attachment(strCancelDO));
                //Add this line to bypass the certificate validation
                //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                //        System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                //        System.Security.Cryptography.X509Certificates.X509Chain chain,
                //        System.Net.Security.SslPolicyErrors sslPolicyErrors)
                //{
                //    return true;
                //};
                client.Send(mail);
                //if (mail.Attachments != null)
                //{
                //    for (int i = mail.Attachments.Count - 1; i >= 0; i--)
                //    {
                //        mail.Attachments[i].Dispose();
                //    }
                //    mail.Attachments.Clear();
                //    mail.Attachments.Dispose();
                //}
                mail.Dispose();
                mail = null;
                //  MessageBox.Show("Successfully Sent Message.");

            }
            catch (Exception ex)
            {


                //string ErrorLogpath = Application.StartupPath + @"\ErrorLog\SentMaillog";
                //string LogErrorFile = ErrorLogpath + @"\ErrorSendMailLog_sendmail" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + ".txt";
                //File.AppendAllText(LogErrorFile, System.Environment.NewLine + "\t" + subject[0].ToString() + string.Format("{0:yyyyMMdd}", DateTime.Now.ToLongTimeString()) + "-------------");
                //File.AppendAllText(LogErrorFile, System.Environment.NewLine + ex.ToString());
                //string _parameterDO = string.Empty;
                //foreach (DataRow dr in dtSerialDHL.Rows)
                //{
                //    _parameterDO = _parameterDO + "','" + dr["DO_NO"].ToString();
                //}
                //_parameterDO = _parameterDO.Trim().Substring(3);
                //string _sql = string.Format(@"Update bill_do set Export_sts = 1,EXPORT_DATE_TIME=NULL where DO_NO in ('{0}')", _parameterDO);
                //DAL.SQL.excutequery(_sql, CommandType.Text);
            }
        }

    }
}