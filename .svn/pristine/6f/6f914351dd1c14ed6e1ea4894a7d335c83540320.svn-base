using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs;
using DLLFuniture;

public partial class General_wucContent : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadParent();
            LoadSlide();
        }
    }
    private SlideCollection LoadSlide()
    {
        Data objdata = new Data(Global.ConnectionSql);
        SlideCollection col = new SlideCollection();
        try
        {
            Slide obj = new Slide();
            obj.DataObject = objdata;
            col = obj.GetAll();
            if (col != null)
            {
                rptslide.DataSource = col;
                rptslide.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadProduct()" + ex);
        }
        finally
        {
            objdata.DeConnect();
        }
        return col;

    }


    private void LoadParent()
    {
        Libs.Data objdata = new Libs.Data(Global.ConnectionSql);
        try
        {
            Category objsubject = new Category();
            objsubject.DataObject = objdata;
            CategoryCollection colparent = objsubject.GetlistParent();
            if (colparent == null) { return; }
            rptParent.DataSource = colparent;
            rptParent.DataBind();
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadParent() " + ex);
        }
        finally
        {
            objdata.DeConnect();
        }
    }

    protected void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //get data

        if (e.Item.ItemIndex < 0) { return; }
        Category source = (Category)e.Item.DataItem;
        int iParentID = Convert.ToInt32(source.CategoryID);
        Repeater rptsub = (Repeater)e.Item.FindControl("rptsub");
        LoadCategoryNamebyParentID(rptsub, iParentID);
    }

    private void LoadCategoryNamebyParentID(Repeater rpt, int parentid)
    {
        Libs.Data objdata = new Libs.Data(Global.ConnectionSql);
        try
        {
            Category obj = new Category();
            obj.DataObject = objdata;
            CategoryCollection col = obj.Getlist(parentid);
            if (col == null) { return; }
            rpt.DataSource = col;
            rpt.DataBind();
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadCategoryNamebyParentID()" + ex);
        }
        finally
        {
            objdata.DeConnect();
        }
    }

}