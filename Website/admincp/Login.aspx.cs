using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using tbhp.DataAccess;


public partial class admincp_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLogin"] != null)
        {
            Response.Redirect("~/admincp/");
        }
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            Users obj = new Users();
            obj.Username = Login1.UserName;
            obj.Password = MyFunction.EncodePassword(Login1.Password);
            if (obj.DangNhap(obj))
            {
                Session["UserLogin"] = Login1.UserName;
                Response.Redirect("~/admincp/");
            }
        }
        catch { }
    }
}
