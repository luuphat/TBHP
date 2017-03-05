﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DLLFuniture;
using Libs;
using System.Web.UI.HtmlControls;


public partial class Cms_Control_wucTypes : System.Web.UI.UserControl
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

    public int TypeID
    {
        get
        {
            object obj = ViewState["TypeID"];
            return ((obj == null) ? -1 : Convert.ToInt32(ViewState["TypeID"]));
        }
        set { ViewState["TypeID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IniInsert();
            BindingData();
        }
    }

    private void IniInsert()
    {
        txtTypeName.Text = string.Empty;
        cbkIsStatus.Checked = true;
        txtSort.Text = string.Empty;
        Handle = HandleValue.Add;
        lblHandle.Text = "Thêm mới loại sản phẩm";
        lblmessage.Text = string.Empty;
    }

    private void Insert()
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Types obj = new Types();
            obj.DataObject = objdata;
            obj.TypeName = txtTypeName.Text.Trim();
            obj.Link = txtTypeName.Text.Trim().Replace(" ","-");
            obj.Sort = txtSort.Text.Trim();
            obj.IsActived = cbkIsStatus.Checked;
            int result = Convert.ToInt32(obj.Add());
            if (result > 0)
            {
                this.BindingData();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sucess", "messagesucess();", true);
            }
            else if (result == 0)
            {
                lblmessage.Text = "Dữ liệu bị trùng. Vui lòng kiểm tra lại !";
                mdPopup.Show();
                return;

            }
            else
            {
                
            }

        }
        catch (Exception ex)
        {
            Global.WriteLogError("Insert() " + ex);

        }
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
            Update(TypeID);
        }
    }

    private TypesCollection LoadData(string stextsearch)
    {
        TypesCollection col = null;
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Types obj = new Types();
            obj.DataObject = objdata;
            col = obj.Getlist(stextsearch);
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadCategory()" + ex);
        }
        return col;
    }

    private void BindingData()
    {
        try
        {
            TypesCollection col = null;
            col = this.LoadData(string.Empty);
            if (col == null)
            {
                col = new TypesCollection();
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

    private TypesCollection GetSubData(TypesCollection Source, int start, int end)
    {
        int iTotalRecord = Source.Count;
        TypesCollection subSource = new TypesCollection();
        if (Source != null)
        {
            for (int i = start; i < end; i++)
            {
                subSource.Add(Source[i]);
            }
        }
        return subSource;
    }

    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            //Lấy data
            Types obj = (Types)e.Item.DataItem;
            if (obj == null) { return; }
            //Set ID (unique id)

            HtmlInputCheckBox cbxSelect = e.Item.FindControl("cbxcheck") as HtmlInputCheckBox;
            if (cbxSelect != null)
            {
                TypeID = Convert.ToInt32(obj.TypeID);
                cbxSelect.Attributes.Add("uid", obj.TypeID.ToString());

            }
            //set image
            ImageButton ibtIsActived = e.Item.FindControl("ibtIsActived") as ImageButton;
            if (ibtIsActived != null)
            {
                ibtIsActived.ImageUrl = "~/Images/uncheck.png";
                if (obj.IsActived) { ibtIsActived.ImageUrl = "~/Images/check.png"; }
                ibtIsActived.Attributes.Add("checked", obj.IsActived.ToString());
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
            TypeID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DoUpdate")
            {
                IniUpdate(TypeID);
            }
            if (e.CommandName == "DoDeteled")
            {
                mpdeleted.Show();
            }  
            if (e.CommandName == "DoSetActive")
            {
                ImageButton ibtIsActived = e.Item.FindControl("ibtIsActived") as ImageButton;
                bool bIsActived = Convert.ToBoolean(ibtIsActived.Attributes["checked"]);
                this.SetActived(TypeID, !bIsActived);
            }

        }
        catch (Exception ex)
        {
            Global.WriteLogError("rptData_ItemDataBound ()" + ex);
        }
    }

    private void IniUpdate(int TypeID)
    {
        Data objdata = new Data(Global.GetConfigKey("strConnerction"));
        Types obj = new Types();
        obj.DataObject = objdata;

        if (obj.GetByID(TypeID))
        {
            txtTypeName.Text = obj.TypeName;
            //cbkIsActived.Checked = objcategory.IsActived;
            txtSort.Text = obj.Sort;
            cbkIsStatus.Checked = obj.IsActived;
            Handle = HandleValue.Edit;
            lblHandle.Text = "Sửa thể loại";
            mdPopup.Show();
        }
       
    }

    private void Update(int TypeID)
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            
            Types obj = new Types();
            obj.DataObject = objdata;
            obj.TypeID = TypeID;
            obj.TypeName = txtTypeName.Text.Trim();
            obj.IsActived = cbkIsStatus.Checked;
            obj.Sort = txtSort.Text;
            obj.Link = txtTypeName.Text.Trim().Replace(" ", "-");
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

    private bool Deleted(int TypeID)
    {
        bool ok = false;
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Types obj = new Types();
            obj.DataObject = objdata;
            ok= obj.Delete(TypeID);
        }
        catch (Exception ex)
        {
            Global.WriteLogError("Deleted() " + ex);

        }
        return ok;

    }

    protected void btnDeleted_Click(object sender, EventArgs e)
    {
        Deleted(TypeID);
        this.BindingData();
    }

    private void SetActived(int TypeID, bool IsActived)
    {
        try
        {
            Data data = new Data(Global.ConnectionSql);
            Types obj = new Types();
            obj.DataObject = data;
            obj.TypeID = TypeID;
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

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindingData();
    }

    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        this.BindingData();
    }

}