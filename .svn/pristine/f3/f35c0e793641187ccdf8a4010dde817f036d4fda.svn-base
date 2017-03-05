using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["t"]))
            {
                LoadProductbyCategoryID(-1, Request["t"].ToString());
            }
        }
    }
    private void LoadProductbyCategoryID(int CategoryID,string textearch)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Products obj = new Products();
            obj.DataObject = objdata;
            ProductsCollection col = obj.GetListByCategoryID(CategoryID, textearch);
            if (col != null)
            {
                rptData.DataSource = col;
                rptData.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadProductbyCategoryID Search(): " + ex);
        }
        finally
        {
            objdata.DeConnect();
        }
    }
}