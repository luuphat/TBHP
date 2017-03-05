﻿using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_control_wuccategory_edit : System.Web.UI.UserControl
{
    public int CategoryID
    {
        get
        {
            object obj = ViewState["CategoryID"];
            return ((obj == null) ? -1 : Convert.ToInt32(ViewState["CategoryID"]));
        }
        set { ViewState["CategoryID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["cid"]))
            {
                CategoryID = Convert.ToInt32(Request["cid"]);
                IniUpdate(CategoryID);
            }
        }
    }

    private void LoadTreeDDL()
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {            
            Category objcategory = new Category();
            objcategory.DataObject = objdata;
            ddlParentName.Items.Clear();
            ddlParentName.Items.Insert(0, new ListItem("------Chọn chủ đề cha-----", "0"));
            CategoryCollection col = objcategory.GetAll(string.Empty,-1);
            if (col == null) { return; }
            int baseID = 0;
            foreach (Category category in col)
            {
                if (category.ParentID < baseID)
                {
                    baseID = category.ParentID;
                }
            }
            foreach (Category category in col)
            {
                if (category.ParentID == baseID)
                {
                    ddlParentName.Items.Add(new ListItem(category.CategoryName, category.CategoryID.ToString()));
                    AddChildrenHandle(category.CategoryID, col);
                }
            }

        }
        catch (Exception ex)
        {
            Global.WriteLogError("Update () " + ex);

        }
        finally
        {
            objdata.DeConnect();
        }
    }

    private void AddChildrenHandle(int ParentID, CategoryCollection col)
    {
        // recursive tree loader. Passes back in a node to retireve its childre until there are no more children for this node.
        foreach (Category category in col)                     // locate all children of this category
        {
            if (category.ParentID == ParentID)                 // found a child
            {
                string sTab = "....";
                ddlParentName.Items.Add(new ListItem(sTab + category.CategoryName, category.CategoryID.ToString()));
                AddChildrenHandle(category.CategoryID, col);                     // find this child's children
            }
        }
    }

    private void IniUpdate(int CategoryID)
    {
        Data objdata = new Data(Global.GetConfigKey("strConnerction"));
        try
        {
            Category objcategory = new Category();
            objcategory.DataObject = objdata;
            LoadTreeDDL();
            lblHandleTitle.Text = "Sửa danh mục";
            if (objcategory.GetByID(CategoryID))
            {
                txtTitle.Text = objcategory.CategoryName;
                cbkIsActived.Checked = objcategory.IsActived;
                ddlParentName.SelectedValue = objcategory.ParentID.ToString();
                txtRandID.Text = objcategory.RandID.ToString();
                if (!string.IsNullOrEmpty(objcategory.Images))
                {
                    imgImages.ImageUrl = objcategory.Images;
                    imgImages.Attributes.Add("images", objcategory.Images);
                }

            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("IniUpdate() " + ex);
        }
        finally
        {
            objdata.DeConnect();
 
        }
    }

    private void Update(int CategoryID)
    {
        Data objdata = new Data(Global.GetConfigKey("strConnerction"));
        try
        {           
            Category objcategory = new Category();
            objcategory.DataObject = objdata;
            objcategory.CategoryID = CategoryID;
            objcategory.CategoryName = txtTitle.Text.Trim();
            objcategory.IsActived = cbkIsActived.Checked;
            objcategory.ParentID = Convert.ToInt32(ddlParentName.SelectedValue);
            objcategory.Links = txtTitle.Text.Trim().Replace(" ", "-");
            objcategory.RandID = Convert.ToInt32(txtRandID.Text);
            //GetImage
            if (!string.IsNullOrEmpty(imgImages.Attributes["images"]))
            {
                objcategory.Images = imgImages.Attributes["images"];
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
                objcategory.Images = Global.GetConfigKey("uploadproduct") + filename;
            }
            int iResult = Convert.ToInt32(objcategory.Update());
            if (iResult > 0)
            {
               // Response.Redirect("~/admin/Category.aspx");
                Response.Write("<script>window.location='Category.aspx'</script>");

            }
            else if (iResult == 0)
            {

                lblMessage.Text = "Trùng dữ liệu vui lòng kiểm tra lại";
                return;
            }
            else
            {
                lblMessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu. Liên hệ với người quản trị để khắc phục";
                return;
            }            

        }
        catch (Exception ex)
        {
            Global.WriteLogError("Update () " + ex);
            lblMessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu. Liên hệ với người quản trị để khắc phục";

        }
        finally
        {
            objdata.DeConnect();
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        Update(CategoryID);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.location='Category.aspx'</script>");
    }
    string GetDate
    {
        get
        {
            return DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
        }
    }
}