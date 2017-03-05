using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

public partial class Web_Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["cid"]))
            {
                LoadProductbyCategoryID(Convert.ToInt32(Request["cid"]));
            }
        }
    }
    private void LoadProductbyCategoryID(int CategoryID)
    {
        try
        {
            List<Products> list = new Products().GetListProductbyCategoryID(CategoryID);
            if (list != null)
            {
                rptData.DataSource = list;
                rptData.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadData home(): " + ex);
        }
    }
}