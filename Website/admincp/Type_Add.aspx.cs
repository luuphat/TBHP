using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;


public partial class Type_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Types obj = new Types();
            obj.TypeName = txtTitle.Text;
            obj.Link = string.Empty;
            obj.Sort = Convert.ToInt32(txtSort.Text);
            obj.Status = chkStatus.Checked;
            obj.Add(obj);
            Response.Write("<script>alert('Cập nhật dữ liệu thành công');window.location='type.aspx'</script>");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}
