﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

public partial class Ad_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Ads obj = new Ads();
            obj.Id = GetID();
            obj.Name = txtTitle.Text;
            obj.Link = txtLink.Text;
            obj.Location = ddlLocation.SelectedValue;
            obj.Type = ddlType.SelectedValue;
            obj.Width = Convert.ToInt32(txtWidth.Text);
            obj.Height = Convert.ToInt32(txtHeight.Text);
            obj.Item = Convert.ToInt32(txtSort.Text);
            if (this.IsValid && this.uplImage.HasFile)
            {
                uplImage.SaveAs(Server.MapPath("~/uploads/ads/" + uplImage.FileName));
                obj.Image = uplImage.FileName;
            }
            else
            {
                obj.Image = hdnImage.Value;
            }
            obj.Status = chkStatus.Checked;
            obj.Update(obj);            
            Response.Write("<script>alert('Cập nhật dữ liệu thành công');window.location='ad.aspx'</script>");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            
        }
    }

    void LoadData()
    {
        try
        {
            Ads obj = new Ads().GetById(GetID());
            if (obj != null)
            {
                txtTitle.Text = obj.Name;
                txtLink.Text = obj.Link;
                txtWidth.Text = obj.Width.ToString();
                txtHeight.Text = obj.Height.ToString();
                hdnImage.Value = obj.Image;
                txtSort.Text = obj.Item.ToString();
                ddlLocation.SelectedValue = obj.Location;
                ddlType.SelectedValue = obj.Type;
                chkStatus.Checked = obj.Status;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    int GetID()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            try
            {
                return Convert.ToInt32(Request.QueryString["id"]);
            }
            catch { }
        }
        return 0;
    }
}
