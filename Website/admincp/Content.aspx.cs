using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;


public partial class Content : System.Web.UI.Page
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
            var list = (from l in new Contents().GetList()
                        where l.ID != "support" && l.ID != "CustomAdsSidebar"
                        select l).ToList();
            GridView1.DataSource = list;
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
            string id = (string)GridView1.DataKeys[e.RowIndex].Value;
            Contents obj = new Contents();
            obj.Delete(id);
            Response.Write("<script>window.location.reload();</script>");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}