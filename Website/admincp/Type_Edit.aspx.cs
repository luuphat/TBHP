using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;


public partial class Type_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Types obj = new Types();
            obj.TypeID = GetID();
            obj.TypeName = txtTitle.Text;
            obj.Link = MyFunction.ConvertUrl(txtTitle.Text);
            obj.Sort = Convert.ToInt32(txtSort.Text);
            obj.Status = chkStatus.Checked;
            obj.Update(obj);
            Response.Write("<script>alert('Cập nhật dữ liệu thành công');window.location='type.aspx'</script>");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    void LoadData()
    {
        try
        {
            Types obj = new Types().GetByTypeID(GetID());
            if (obj != null)
            {
                txtTitle.Text = obj.TypeName;
                txtSort.Text = obj.Sort.ToString();
                chkStatus.Checked = obj.Status;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    int GetID()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            try
            {
                return Convert.ToInt32(Request.QueryString["id"]);
            }
            catch { }
        }
        return 0;
    }
}
