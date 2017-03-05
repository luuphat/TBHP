using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;


public partial class Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    void LoadData()
    {
        try
        {
            var list = from c in new Categories().GetList().OrderByDescending(r=>r.CategoryID)
                       join t in new Types().GetList() on c.TypeID equals t.TypeID
                       select new {c.CategoryID, c.CategoryName, t.TypeName };
            GridView1.DataSource = list.ToList();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadData();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)GridView1.DataKeys[e.RowIndex].Value;
            Categories obj = new Categories();
            obj.Delete(id);
            Response.Write("<script>window.location.reload();</script>");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}