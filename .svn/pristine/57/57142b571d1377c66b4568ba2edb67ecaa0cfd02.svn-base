using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;


public partial class Category_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCategory();
            LoadData();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Categories obj = new Categories();
            obj.CategoryID = GetID();
            obj.CategoryName = txtTitle.Text;
            obj.TypeID = Convert.ToInt32(ddlCategory.SelectedValue);
            obj.Link = string.Empty;
            obj.Sort = Convert.ToInt32(txtSort.Text);
            obj.Status = chkStatus.Checked;
            obj.Update(obj);
            Response.Write("<script>alert('Cập nhật dữ liệu thành công');window.location='category.aspx'</script>");
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
            Categories obj = new Categories().GetByCategoryID(GetID());
            if (obj != null)
            {
                txtTitle.Text = obj.CategoryName;
                ddlCategory.SelectedValue = obj.TypeID.ToString();
                txtSort.Text = obj.Sort.ToString();
                chkStatus.Checked = obj.Status;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    void LoadCategory()
    {
        try
        {
            var list = from l in new Types().GetList()
                        select l;
            ddlCategory.DataSource = list.ToList();
            ddlCategory.DataTextField = "typename";
            ddlCategory.DataValueField = "typeid";
            ddlCategory.DataBind();
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
