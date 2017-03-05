﻿using DLLFuniture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs;
using System.Web.UI.HtmlControls;
using System.IO;


public partial class Cms_Control_wucProducts : System.Web.UI.UserControl
{
    private enum HandleValue
    {
        Add,
        Edit,
        Nothing
    }

    private HandleValue Handle
    {
        get
        {
            object obj = ViewState["Handle"];
            return ((obj == null) ? HandleValue.Nothing : (HandleValue)ViewState["Handle"]);
        }
        set { ViewState["Handle"] = value; }
    }

    public int CategoryID
    {
        get
        {
            object obj = ViewState["CategoryID"];
            return ((obj == null) ? -1 : Convert.ToInt32(ViewState["CategoryID"]));
        }
        set { ViewState["CategoryID"] = value; }
    }

    public int NewsID
    {
        get
        {
            object obj = ViewState["NewsID"];
            return ((obj == null) ? -1 : Convert.ToInt32(ViewState["NewsID"]));
        }
        set { ViewState["NewsID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindingData();
        }
        //Đăng ký control cho file upload
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(btnOk);
    }

    private void IniInsert()
    {
        txtTitle.Text = string.Empty;
        cbkIsStatus.Checked = true;
        radContents.Content = string.Empty;
        txtDescription.Text = string.Empty;
        cbkIsStatus.Checked = true;
        LoadDDLCategory();
        Handle = HandleValue.Add;
        lblHandle.Text = "Thêm mới sản phẩm";
        lblmessage.Text = string.Empty;
        mdPopup.Show();
    }

    private void LoadDDLCategory()
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Categories obj = new Categories();
            obj.DataObject = objdata;
            ddlCategory.Items.Clear();
            CategoriesCollection col = obj.GetAll(string.Empty, -1);
            if (col == null) { return; }
            ddlCategory.DataSource = col;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadDDLCategory () " + ex);
            lblmessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu. Liên hệ với người quản trị để khắc phục";
            mdPopup.Show();

        }
    }

    private void Insert()
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Products obj = new Products();
            obj.DataObject = objdata;
            obj.Title = txtTitle.Text.Trim();
            obj.Description = txtDescription.Text.Trim();
            // obj.Detail = radContents.Content;
            obj.IsActived = cbkIsStatus.Checked;
            obj.Links = txtTitle.Text.Trim().Replace(" ", "-");            
            obj.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            if (this.uplImage.HasFile)
            {
                Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromBinary(this.uplImage.FileBytes);
                Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                actResize.Width = 150;
                actResize.Height = 150;
                uploadedImage.Actions.Add(actResize);
                Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                imgDraw.Elements.Add(uploadedImage);
                imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                imgDraw.JpegCompressionLevel = 90;
                string filename = GetDate + "_" + uplImage.FileName;
                imgDraw.Save(Server.MapPath(Global.GetConfigKey("uploadproduct") + filename));
                obj.Image = Global.GetConfigKey("uploadproduct") + filename;
            }
            else
            {
                obj.Image = Global.GetConfigKey("uploadproduct") + "alternate.png";
            }
            obj.Date = DateTime.Now;
            int result = Convert.ToInt32(obj.Add());
            if (result > 0)// no error
            {
                this.BindingData();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sucess", "messagesucess();", true);
            }
            else if (result == 0)
            {
                lblmessage.Text = "Trùng dữ liệu vui lòng kiểm tra lại";
                mdPopup.Show();
            }
            else
            {
                lblmessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu. Liên hệ với người quản trị để khắc phục";
                mdPopup.Show();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("Insert() " + ex);

        }
    }

    string GetDate
    {
        get
        {
            return DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
        }
    }

    private ProductsCollection LoadProduct(int CategoryID)
    {
        ProductsCollection col = null;
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Products obj = new Products();
            obj.DataObject = objdata;
            col = obj.GetListByCategoryID(CategoryID,string.Empty);
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadProduct()" + ex);
        }
        return col;
    }

    private void BindingData()
    {
        try
        {
            ProductsCollection col = null;
            col = this.LoadProduct(-1);
            if (col == null)
            {
                col = new ProductsCollection();
                lblCount.Text = "Có 0" + " record";
                rptData.DataSource = col;
                rptData.DataBind();
            }
            else
            {
                lblCount.Text = "Có " + col.Count.ToString() + " record";
                lblCount.ForeColor = System.Drawing.Color.Blue;
                anpPager.RecordCount = col.Count;
                anpPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                anpPager.ShowFirstLast = false;
                col = this.GetSubData(col, anpPager.StartRecordIndex - 1, anpPager.EndRecordIndex);
                rptData.DataSource = col;
                rptData.DataBind();
            }

        }
        catch (Exception ex)
        {
            Global.WriteLogError("BindingData()" + ex);
        }
    }

    private ProductsCollection GetSubData(ProductsCollection Source, int start, int end)
    {
        int iTotalRecord = Source.Count;
        ProductsCollection subSource = new ProductsCollection();
        if (Source != null)
        {
            for (int i = start; i < end; i++)
            {
                subSource.Add(Source[i]);
            }
        }
        return subSource;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        IniInsert();
        mdPopup.Show();
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (Handle == HandleValue.Add)
        {
            Insert();
        }
        if (Handle == HandleValue.Edit)
        {
            Update(NewsID);
        }
    }

    private void IniUpdate(int NewsID)
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Products obj = new Products();
            obj.DataObject = objdata;
            LoadDDLCategory();
            imgImages.ImageUrl = Global.Root + Global.GetConfigKey("uploadproduct") + "alternate.png";
            if (obj.GetByID(NewsID))
            {
                if (!string.IsNullOrEmpty(obj.Image))
                {
                    imgImages.ImageUrl = obj.Image;
                    imgImages.Attributes.Add("images", obj.Image);
                }
                txtTitle.Text = obj.Title;
                txtDescription.Text = obj.Description;
                ddlCategory.SelectedValue = obj.CategoryID.ToString();
                radContents.Content= obj.Detail;
                cbkIsStatus.Checked = obj.IsActived;
                ddlCategory.SelectedValue = obj.CategoryID.ToString();
                Handle = HandleValue.Edit;
                lblHandle.Text = "Sửa sản phẩm";
                mdPopup.Show();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("IniUpdate() " + ex);
        }

    }

    private void Update(int NewsID)
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Products obj = new Products();
            obj.DataObject = objdata;
            obj.NewsID = NewsID;
            obj.Title = txtTitle.Text.Trim();
            obj.Description = txtDescription.Text.Trim();
            obj.Detail = radContents.Content;
            obj.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            obj.IsActived = cbkIsStatus.Checked;
            obj.Links = txtTitle.Text.Trim().Replace(" ", "-");
            //GetImage
            if (!string.IsNullOrEmpty(imgImages.Attributes["images"]))
            {
                obj.Image = imgImages.Attributes["images"];
            }
            if (this.uplImage.HasFile)
            {
                Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromBinary(this.uplImage.FileBytes);
                Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                actResize.Width = 150;
                actResize.Height = 150;
                uploadedImage.Actions.Add(actResize);
                Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                imgDraw.Elements.Add(uploadedImage);
                imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                imgDraw.JpegCompressionLevel = 90;
                string filename = GetDate + "_" + uplImage.FileName;
                imgDraw.Save(Server.MapPath(Global.GetConfigKey("uploadproduct") + filename));
                obj.Image = Global.GetConfigKey("uploadproduct") + filename;
            }
            int iResult = Convert.ToInt32(obj.Update());
            if (iResult > 0)
            {
                this.BindingData();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sucess", "messagesucess();", true);

            }
            else if (iResult == 0)
            {

                lblmessage.Text = "Trùng dữ liệu vui lòng kiểm tra lại";
                mdPopup.Show();
            }
            else
            {
                lblmessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu. Liên hệ với người quản trị để khắc phục";
                mdPopup.Show();
            }

        }
        catch (Exception ex)
        {
            Global.WriteLogError("Update () " + ex);
            lblmessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu. Liên hệ với người quản trị để khắc phục";
            mdPopup.Show();
        }
    }

    private void SetActived(int NewsID, bool IsActived)
    {
        try
        {
            Libs.Data data = new Libs.Data(Global.ConnectionSql);
            Products obj = new Products();
            obj.DataObject = data;
            obj.NewsID = NewsID;
            obj.IsActived = IsActived;
            if (obj.SetActived()) //no error
            {
                this.BindingData();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sucess", "messagesucess();", true);
            }
            else
            {
                lblmessage.Text = "Sửa dữ liệu không thành công";
                mdPopup.Show();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("SetActived() " + ex);
            lblmessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu. Liên hệ với người quản trị để khắc phục";
            mdPopup.Show();
        }
    }

    private void Deleted(int NewsID)
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Products obj = new Products();
            obj.DataObject = objdata;
            bool ok = obj.Delete(NewsID);
        }
        catch (Exception ex)
        {
            Global.WriteLogError("Deleted() " + ex);

        }
    }

    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            //Lấy data
            Products obj = (Products)e.Item.DataItem;
            if (obj == null) { return; }
            //Set x
            //set image
            ImageButton ibtIsActived = e.Item.FindControl("ibtIsActived") as ImageButton;
            if (ibtIsActived != null)
            {
                ibtIsActived.ImageUrl = "~/Images/uncheck.png";
                if (obj.IsActived) { ibtIsActived.ImageUrl = "~/Images/check.png"; }
                ibtIsActived.Attributes.Add("checked", obj.IsActived.ToString());
            }
            ////set image
            //ImageButton imgProduct = e.Item.FindControl("imgProduct") as ImageButton;
            //if (imgProduct != null)
            //{
            //    imgProduct.ImageUrl = Global.Root + obj.Image;
            //    imgProduct.Attributes.Add("checked", obj.Image.ToString());
            //}
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
            NewsID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DoUpdate")
            {
                IniUpdate(NewsID);
            }
            if (e.CommandName == "DoDeteled")
            {
                mpdeleted.Show();
            }
            if (e.CommandName == "DoUpload")
            {
                mpUpload.Show();
            }
            if (e.CommandName == "DoSetActive")
            {
                ImageButton ibtIsActived = e.Item.FindControl("ibtIsActived") as ImageButton;
                bool bIsActived = Convert.ToBoolean(ibtIsActived.Attributes["checked"]);
                this.SetActived(NewsID, !bIsActived);
            }

        }
        catch (Exception ex)
        {
            Global.WriteLogError("rptData_ItemDataBound ()" + ex);
        }
    }

    protected void btnDeleted_Click(object sender, EventArgs e)
    {
        Deleted(NewsID);
        this.BindingData();
    }

    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        this.BindingData();
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindingData();
    }

    protected void btnCencal_Click(object sender, EventArgs e)
    {
        mdPopup.Hide();
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Img obj = new Img();
            obj.DataObject = objdata;
            HttpFileCollection httpFileCollection = Request.Files;
            for (int i = 0; i < httpFileCollection.Count; i++)
            {
                HttpPostedFile httpPostedFile = httpFileCollection[i];
                if (httpPostedFile.ContentLength > 0)
                {
                    obj.Images = Global.GetConfigKey("uploadproduct") + httpPostedFile.FileName;
                    obj.ProductID = NewsID;
                    obj.Sort = 1;
                    int iresult = Convert.ToInt32(obj.Add());
                    httpPostedFile.SaveAs(Server.MapPath("~/" + Global.GetConfigKey("uploadproduct")) + "/" + System.IO.Path.GetFileName(httpPostedFile.FileName));
                }
            }
            this.BindingData();
        }
        catch (Exception ex)
        {
            Global.WriteLogError("Update () " + ex);
            lblmessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu" ;
            mpUpload.Show();
        }
    }

}