﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;


public partial class New_Edit : System.Web.UI.Page
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
            News obj = new News();
            obj.NewsID = GetID();
            obj.Title = txtTitle.Text;
            obj.Link = MyFunction.ConvertUrl(txtTitle.Text);
            obj.Description = txtDescription.Text;
            obj.Detail = txtDetail.Value.Replace("'", "’");
            if (this.IsValid && this.uplImage.HasFile)
            {
                Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromBinary(this.uplImage.FileBytes);
                Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                actResize.Width = 150;
                actResize.Height = 130;
                uploadedImage.Actions.Add(actResize);
                Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                imgDraw.Elements.Add(uploadedImage);
                imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                imgDraw.JpegCompressionLevel = 90;
                string filename = GetDate + "_" + uplImage.FileName;
                imgDraw.Save(Server.MapPath("~/uploads/news/" + filename));
                obj.Image = filename;
            }
            else
            {
                obj.Image = hdnImage.Value;
            }
            obj.Update(obj);
            Response.Write("<script>alert('Cập nhật dữ liệu thành công');window.location='new.aspx'</script>");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    void LoadData()
    {
        try
        {
            News obj = new News().GetByNewsID(GetID());
            if (obj != null)
            {
                txtTitle.Text = obj.Title;
                txtDescription.Text = obj.Description;
                txtDetail.Value = obj.Detail;
                hdnImage.Value = obj.Image;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    string GetDate
    {
        get
        {
            return DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
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
