using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;


public partial class Content_Edit : System.Web.UI.Page
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
            Contents obj = new Contents();
            obj.ID = GetID();
            obj.Title = txtTitle.Text;
            obj.Detail = txtDetail.Value;
            obj.Update(obj);
            Response.Write("<script>alert('Cập nhật dữ liệu thành công');window.location.reload()</script>");
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
            Contents obj = new Contents().GetByID(GetID());
            if (obj != null)
            {
                txtTitle.Text = obj.Title;
                txtLink.Text = obj.ID;
                txtDetail.Value = obj.Detail;
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
