using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

public partial class General_wucMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTypeName();
            LoadDataTopProduct();
            LoadDataTopNews();
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

    private void LoadDataTopProduct()
    {
        try
        {
            List<Products> list = new Products().GetList();
            if (list != null )
            {
                rptTopproduct.DataSource = list;
                rptTopproduct.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadData Top product(): " + ex);
        }
    }

    protected string cutTitle(string str, int skt)
    {
        string s = string.Empty;
        if (str.Length > skt)
        {
            s = str.Substring(0, skt);
            s = s + "...";
        }
        else
            s = str;
        return s;
    }

    private void LoadDataTopNews()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NewsID", typeof(int));
            dt.Columns.Add("STT", typeof(int));           
            dt.Columns.Add("Title", typeof(string));
            DataRow row;
            List<News> list = new News().GetListTop();
            if (list.Count > 0)
            {
                int i = 1;
                foreach (News n in list)
                {
                     row= dt.NewRow();
                     row["NewsID"] = n.NewsID;
                     row["STT"] = i++;
                     row["Title"] = n.Title;
                     dt.Rows.Add(row);
                }
                rptTopNews.DataSource = dt;
                rptTopNews.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadDataTopNews() : " + ex);
        }
    }
}