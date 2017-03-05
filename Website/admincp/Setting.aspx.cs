using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;


public partial class Setting : System.Web.UI.Page
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
            GridView1.DataSource = new Settings().GetList();
            GridView1.DataBind();
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
            Settings obj = new Settings();
            obj.Delete(id);
            Response.Write("<script>window.location.reload();</script>");
        }
        catch { }
    }
}