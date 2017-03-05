using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_ChangePass : System.Web.UI.Page
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
            int result = Convert.ToInt32(obj.ChangePass(Session["UserName"].ToString(), txtOldPassword.Text.Trim(), txtNewPassword.Text.Trim()));
            if (result > 0)
            {
                //Response.Redirect("~/Login/Login.aspx");
                Response.Write("<script>window.location='Login.aspx'</script>");
            }
            else
            {
                lblmessage.Text = "Mật khẩu củ không đúng";
                lblmessage.ForeColor = Color.Red;
                return;
            }
        }
        catch (Exception ex)
        {          
            Response.Redirect("~/Login/Login.aspx");
        }
        finally
        {
            objdata.DeConnect();
        }
    }

}