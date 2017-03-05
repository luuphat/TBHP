using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

public partial class Account_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Users obj = new Users();
            obj.Username = Session["UserLogin"].ToString();
            obj.Password = MyFunction.EncodePassword(txtPassword.Text);
            if (obj.DoiMatKhau(obj, MyFunction.EncodePassword(txtNewPassword.Text)))
            {
                Response.Redirect("ChangePasswordSuccess.aspx");
            }
            else
            {
                lblMessage.Text = "Mật khẩu cũ không chính xác.";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}
