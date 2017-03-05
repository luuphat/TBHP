using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Web_Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            string frommail = Global.GetConfigKey("frommail");
            bool ok = sendMailGoogle(frommail, txtEmail.Text.Trim(), txtName.Text.Trim(), txtcontent.Text.Trim());
            if (!ok) { return; }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("btnSend_Click ()" + ex);
        }
        finally
        {
          
        }
    }
    private bool sendMailGoogle(string fromMail, string toMail, string subject, string body)
    {
        bool isSuccess = false;
        try
        {
            string mailmethod = Global.GetConfigKey("mailmethod");
            string pass = Global.GetConfigKey("pass");
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            SmtpClient SmtpServer = new SmtpClient(mailmethod);
            mail.From = new MailAddress(fromMail, "Thiết Bị Hồng Phúc");
            mail.To.Add(toMail);
            mail.Subject = subject;
            mail.Body = "<html><body>" + "<a href=\"#\">" + subject + "</a>" + " <br />" + body + "</body></html>";
            mail.IsBodyHtml = true;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential(fromMail, pass);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            isSuccess = true;
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtcontent.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Global.WriteLogError("sendMailGoogle()========>" + ex);
        }
        return isSuccess;

    }
}