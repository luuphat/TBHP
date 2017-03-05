using Libs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DLLFuniture;
using Libs;

public partial class Login_Login : System.Web.UI.Page
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
            if (obj.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
            {
                Session["username"] = obj.UserName;
                Session["Password"] = obj.Passwords;
                Response.Redirect(Global.Root + "/admin/Default.aspx");
               // Response.Write("<script>window.location='Default.aspx'</script>");
            }
            else
            {
               
                lblmessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng !";
                lblmessage.ForeColor = Color.Red;
                return;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect(Global.Root + "/admin/Default.aspx");
           // Global.WriteLogError("btnLogin_Click() " + ex.ToString());         
          //  return;
        }
        finally
        {
            objdata.DeConnect();
        }
    }
}