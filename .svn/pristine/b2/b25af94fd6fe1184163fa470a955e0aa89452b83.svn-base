using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs;
using DLLFuniture;
public partial class Web_Category : System.Web.UI.Page
{
    protected string _categoryname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["cid"]))
            {
                _categoryname = GetbyID(Convert.ToInt32(Request["cid"]));
                LoadProductbyCategoryID(Convert.ToInt32(Request["cid"]));
            }
        }
    }
    private void LoadProductbyCategoryID(int CategoryID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {          
            Products obj = new Products();
            obj.DataObject = objdata;
            ProductsCollection col = obj.GetListByCategoryID(CategoryID,string.Empty);            
            if (col != null)
            {
                rptData.DataSource = col;
                rptData.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadProductbyCategoryID home(): " + ex);
        }
        finally
        {
            objdata.DeConnect();
        }
    }
    private string  GetbyID(int CategoryID)
    {
        string _name = string.Empty;
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Category obj = new Category();
            obj.DataObject = objdata;
            if (obj.GetByID(CategoryID))
            {
                _name = obj.CategoryName;
            }
            
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadProductbyCategoryID home(): " + ex);
        }
        finally
        {
            objdata.DeConnect();
        }
        return _name;
    }
}