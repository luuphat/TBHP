using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;


public partial class Content_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Contents obj = new Contents();
            obj.Title = txtTitle.Text;
            obj.ID = txtLink.Text;
            obj.Detail = txtDetail.Value;
            obj.Add(obj);
            Response.Write("<script>alert('Cập nhật dữ liệu thành công');window.location='content.aspx'</script>");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}
