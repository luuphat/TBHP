using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

public partial class Category_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCategory();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Categories obj = new Categories();
            obj.CategoryName = txtTitle.Text;
            obj.TypeID = Convert.ToInt32(ddlCategory.SelectedValue);
            obj.Link = string.Empty;
            obj.Sort = Convert.ToInt32(txtSort.Text);
            obj.Status = chkStatus.Checked;
            obj.Add(obj);
            Alert.Show("Cập nhật dữ liệu thành công");
            txtTitle.Text = string.Empty;
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
}
