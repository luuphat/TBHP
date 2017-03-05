﻿using DLLFuniture;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs;
using DLLFuniture;

public partial class General_wucMenu : System.Web.UI.UserControl
{
    private int CategoryID
    {
        get
        {
            object obj = ViewState["CategoryID"];
            return ((obj == null) ? -1 : Convert.ToInt32(ViewState["CategoryID"]));
        }
        set
        {
            ViewState["CategoryID"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadParent();
            LoadDataTopProduct();
            LoadDataTopNews();
        }
    }
  
    //protected void rptDataTypes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    //get data 
    //    if (e.Item.ItemIndex < 0) { return; }
    //    Types type = (Types)e.Item.DataItem;
    //    int typeid = Convert.ToInt32(type.TypeID);
    //    Repeater rptcategory = (Repeater)e.Item.FindControl("rptDataCategory");
    //    LoadCategorybyTypeID(typeid, rptcategory);
    //}

    //private void LoadCategorybyTypeID(int typeID, Repeater rpt)
    //{
    //    Data objdata = new Data(Global.ConnectionSql);
    //    try
    //    {
    //        CategoriesCollection col = null;
    //        try
    //        {

    //            Categories obj = new Categories();
    //            obj.DataObject = objdata;
    //            col = obj.GetAll(string.Empty, typeID);
    //            rpt.DataSource = col;
    //            rpt.DataBind();
    //        }
    //        catch (Exception ex)
    //        {
    //            Global.WriteLogError("LoadCategory()" + ex);
    //        }
    //        finally {
    //            objdata.DeConnect();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Global.WriteLogError("LoadCategorybyTypeID --> home(): " + ex);
    //    }
    //}

    private void LoadDataTopProduct()
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Products obj = new Products();
            obj.DataObject = objdata;
            ProductsCollection col = obj.GetListTop();
            if (col != null)
            {
                rptTopproduct.DataSource = col;
                rptTopproduct.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadData Top product(): " + ex);
        }
        finally {
            objdata.DeConnect();
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
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NewsID", typeof(int));
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            DataRow row;
            News obj = new News();
            obj.DataObject = objdata;
            NewsCollection col = obj.GetListTop();
            if (col != null)
            {
                int i = 1;
                foreach (News n in col)
                {
                    row = dt.NewRow();
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
        finally {
            objdata.DeConnect();
        }
    }

    //private TypesCollection LoadDataType(string stextsearch)
    //{
    //    Data objdata = new Data(Global.ConnectionSql);
    //    TypesCollection col = null;
    //    try
    //    {
    //        Types obj = new Types();
    //        obj.DataObject = objdata;
    //        col = obj.Getlist(stextsearch);
    //    }
    //    catch (Exception ex)
    //    {
    //        Global.WriteLogError("LoadDataType()" + ex);
    //    }
    //    finally {
    //        objdata.DeConnect();
    //    }
    //    return col;
    //}

    //private void BindingDataType()
    //{
    //    try
    //    {
    //        TypesCollection col = null;
    //        col = this.LoadDataType(string.Empty);
    //        if (col == null)
    //        {
    //            col = new TypesCollection();
    //            // lblCount.Text = "Có 0" + " record";
    //            rptDataTypes.DataSource = col;
    //            rptDataTypes.DataBind();
    //        }
    //        else
    //        {
    //            rptDataTypes.DataSource = col;
    //            rptDataTypes.DataBind();
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Global.WriteLogError("BindingData()" + ex);
    //    }
    //}

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
        Getsubmenu(rptsub, iParentID);
    }

    private void Getsubmenu(Repeater rpt, int parentid)
    {
        Libs.Data objdata = new Libs.Data(Global.ConnectionSql);
        try
        {            
            Category objsubjectItem = new Category();
            objsubjectItem.DataObject = objdata;
            CategoryCollection col = objsubjectItem.Getlist(parentid);
            if (col == null) { return; }
            rpt.DataSource = col;
            rpt.DataBind();
        }
        catch (Exception ex)
        {
            Global.WriteLogError("Getsubmenu()" + ex);
        }
        finally
        {
            objdata.DeConnect();
        }
    }
    
}