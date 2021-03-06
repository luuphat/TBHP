﻿using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_control_wuccreate_edit_category : System.Web.UI.UserControl
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IniInsert();
            LoadTreeDDL();     
        }
           
    }

    private void IniInsert()
    {
        txtTitle.Text = "";
        cbkIsActived.Checked = true;
        LoadTreeDDL();     
        lblHandleTitle.Text = "Thêm mới thể loại";              
    }

    private void Insert()
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Category obj = new Category();
            obj.DataObject = objdata;
            obj.CategoryName = txtTitle.Text.Trim();
            obj.IsActived = true;
            obj.Links = txtTitle.Text.Trim().Replace(" ", "");
            obj.RandID = Convert.ToInt32(txtRandID.Text);
            obj.ParentID = Convert.ToInt32(ddlParentName.SelectedValue.ToString());
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
                obj.Images = Global.GetConfigKey("uploadproduct") + filename;
            }
            else
            {
                obj.Images = Global.GetConfigKey("uploadproduct") + "alternate.png";
            }
            int result = Convert.ToInt32(obj.Add());
            if (result > 0)// no error
            {
                Response.Write("<script>window.location='Category.aspx'</script>");
            }
            else if (result == 0)
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
            Global.WriteLogError("Insert() " + ex);
            lblMessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu. Liên hệ với người quản trị để khắc phục";
            return;
        }
        finally
        {
            objdata.DeConnect();
        }
    }

    private void LoadTreeDDL()
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
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

    protected void btnOk_Click(object sender, EventArgs e)
    {
        Insert();
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