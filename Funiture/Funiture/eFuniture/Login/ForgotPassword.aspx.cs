using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Users obj = new Users();
            obj.DataObject = objdata;
            int result = Convert.ToInt32(obj.ForgotPass2(txtUserName.Text.Trim()));
            if (result == 0)
            {
                lblmessage.Text = "Tên đăng nhập không đúng";
                lblmessage.ForeColor = Color.Red;
                return;
            }
            else
            {
                string frommail = Global.GetConfigKey("frommail");
                sendMailGoogle(frommail, txtEmail.Text.Trim(), "Thiết bị hồng phúc- Lấy lại mật khẩu", "Mật khẩu của bạn :" + result.ToString());
                Response.Write("<script>window.location='Login.aspx'</script>");
               // Response.Redirect("~/Login/Login.aspx");
            }

        }
        catch (Exception ex)
        {
           
            Global.WriteLogError("btnLogin_Click()" + ex);
            Response.Redirect("~/Login/Login.aspx");
        }
        finally
        {
            objdata.DeConnect();
        }
    }

    private void sendMailGoogle(string fromMail, string toMail, string subject, string body)
    {
       
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
          
        }
        catch (Exception ex)
        {
            Global.WriteLogError("sendMailGoogle()========>" + ex);
        }
    }
}
