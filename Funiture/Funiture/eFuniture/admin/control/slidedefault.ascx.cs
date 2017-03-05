﻿using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_control_slidedefault : System.Web.UI.UserControl
{
    protected string sTitle = string.Empty;

   
    public int ImageID
    {
        get
        {
            object obj = ViewState["ImageID"];
            return ((obj == null) ? -1 : Convert.ToInt32(ViewState["ImageID"]));
        }
        set { ViewState["ImageID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        sTitle = "Ảnh Slide";
        if (!IsPostBack)
        {
            this.BindingData();
        }
        //Đăng ký control cho file upload
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(btnUpload);
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
                rptData.DataSource = col;
                rptData.DataBind();
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

    private void BindingData()
    {
        try
        {
            SlideCollection col = null;
            col = this.LoadSlide();
            rptData.DataSource = col;
            rptData.DataBind();

        }
        catch (Exception ex)
        {
            Global.WriteLogError("BindingData()" + ex);
        }

    }

    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            //Lấy data
            Slide obj = (Slide)e.Item.DataItem;
            if (obj == null) { return; }
            ImageButton btnDelete = e.Item.FindControl("btnDelete") as ImageButton;
            if (btnDelete != null)
            {
                btnDelete.ImageUrl = "~/Images/delete.png";
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("rptData_ItemDataBound : " + ex);
        }
    }

    protected void rptData_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            ImageID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {
                Deleted(ImageID);
            }
            if (e.CommandName == "DoUpdated")
            {
               // Deleted(ImageID);
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("rptData_ItemDataBound ()" + ex);
        }
    }

    private void Deleted(int ImageID)
    {
        Libs.Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Slide obj = new Slide();
            obj.DataObject = objdata;
            bool ok = obj.Delete(ImageID);
            this.BindingData();
        }
        catch (Exception ex)
        {
            Global.WriteLogError("Deleted() " + ex);

        }
        finally
        {
            objdata.DeConnect();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        mpUpload.Show();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Slide obj = new Slide();
            obj.DataObject = objdata;
            HttpFileCollection httpFileCollection = Request.Files;
            for (int i = 0; i < httpFileCollection.Count; i++)
            {
                HttpPostedFile httpPostedFile = httpFileCollection[i];
                if (httpPostedFile.ContentLength > 0)
                {
                    obj.Images = Global.GetConfigKey("ads") + httpPostedFile.FileName;
                    obj.Links = txtlinks.Text.Trim();
                    obj.Tabs = ddltabs.SelectedValue;
                    obj.Title = string.Empty;
                    obj.UserCreated = Session["username"].ToString();
                    obj.IsDeleted = false;
                    int iresult = Convert.ToInt32(obj.Add());
                    httpPostedFile.SaveAs(Server.MapPath("~/" + Global.GetConfigKey("ads")) + "/" + System.IO.Path.GetFileName(httpPostedFile.FileName));
                }
            }
            this.BindingData();
        }
        catch (Exception ex)
        {
            Global.WriteLogError("Update () " + ex);
            mpUpload.Show();
        }
        finally
        {
            objdata.DeConnect();
        }
    }
}