using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

public partial class General_wucContent : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTypeName();
        }
    }
    private void LoadTypeName()
    {
        try
        {
            List<Types> list = new Types().GetList();
            if (list != null)
            {
                rptDataTypes.DataSource = list;
                rptDataTypes.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadData home(): " + ex);
        }
    }
    protected void rptDataTypes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       //get data 
        if (e.Item.ItemIndex < 0) { return; }
        Types type = (Types)e.Item.DataItem;
        int typeid = Convert.ToInt32(type.TypeID);
        Repeater rptcategory = (Repeater)e.Item.FindControl("rptDataCategory");
        LoadCategorybyTypeID(typeid, rptcategory);
    }
    private void LoadCategorybyTypeID(int typeID, Repeater rpt)
    {
        try
        {
            List<Categories> list = new Categories().GetCategorybyTypeID(typeID);
            if (list != null)
            {
                rpt.DataSource = list;
                rpt.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadData home(): " + ex);
        }
    }
}