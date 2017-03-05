using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

public partial class Setting_Edit : System.Web.UI.Page
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
            Settings obj = new Settings();
            obj.Id = GetID();
            obj.Type = txtTitle.Text;
            obj.Value = txtLink.Text;
            obj.Update(obj);
            Response.Write("<script>alert('Cập nhật dữ liệu thành công');window.location='setting.aspx'</script>");
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
            Settings obj = new Settings().GetById(GetID());
            if (obj != null)
            {
                txtTitle.Text = obj.Type;
                txtLink.Text = obj.Value;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    string GetID()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            try
            {
                return Request.QueryString["id"].ToString();
            }
            catch { }
        }
        return string.Empty;
    }
}
