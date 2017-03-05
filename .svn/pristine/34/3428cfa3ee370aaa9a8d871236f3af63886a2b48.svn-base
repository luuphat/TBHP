using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DLLFuniture;
using System.Web.UI.HtmlControls;

public partial class Cms_Control_wucCategories : System.Web.UI.UserControl
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
            //IniInsert();
           
            BindingData();
        }
    }

    private void IniInsert()
    {
        txtCategoryName.Text = string.Empty;
        cbkIsStatus.Checked = true;
        txtSort.Text = string.Empty;
        LoadTreeDDL();
        Handle = HandleValue.Add;
        lblHandle.Text = "Thêm mới danh mục";
        lblmessage.Text = string.Empty;
        mdPopup.Show();
    }

    private void Insert()
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Categories obj = new Categories();
            obj.DataObject = objdata;
            obj.CategoryName = txtCategoryName.Text.Trim();
            obj.IsActived = cbkIsStatus.Checked;
            obj.Sort = txtSort.Text.Trim();
            obj.Links = txtCategoryName.Text.Trim().Replace(" ", "-");
            obj.TypeID = Convert.ToInt32(ddlTypes.SelectedValue);            
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

    private void LoadTreeDDL()
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Types obj = new Types();
            obj.DataObject = objdata;
            ddlTypes.Items.Clear();
            TypesCollection col = obj.Getlist(string.Empty);
            if (col == null) { return; }
            ddlTypes.DataSource = col;
            ddlTypes.DataTextField = "TypeName";
            ddlTypes.DataValueField = "TypeID";
            ddlTypes.DataBind();
        }
        catch (Exception ex)
        {
            Global.WriteLogError("Load DDLTYpe () " + ex);
            lblmessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu. Liên hệ với người quản trị để khắc phục";
            mdPopup.Show();
           
        }
    }

    private CategoriesCollection LoadCategory(string stextsearch, int TypeID)
    {
        CategoriesCollection col = null;
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Categories obj = new Categories();
            obj.DataObject = objdata;
            col = obj.GetAll(stextsearch, TypeID);
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
            CategoriesCollection col = null;
            col = this.LoadCategory(string.Empty,-1);
            if (col == null)
            {
                col = new CategoriesCollection();
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
            Global.WriteLogError("BindingCategory()" + ex);
        }
    }

    private CategoriesCollection GetSubData(CategoriesCollection Source, int start, int end)
    {
        int iTotalRecord = Source.Count;
        CategoriesCollection subSource = new CategoriesCollection();
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
            Update(CategoryID);
        }
    }

    protected void lbtEdit_Click(object sender, EventArgs e)
    {
        try
        {
            //Lấy đối tượng cần xử lý
            foreach (RepeaterItem item in rptData.Items)
            {
                HtmlInputCheckBox cbxSelect = item.FindControl("cbxcheck") as HtmlInputCheckBox;
                if (cbxSelect != null)
                {
                    if (cbxSelect.Checked)
                    {
                        CategoryID = Convert.ToInt32(cbxSelect.Attributes["uid"]);
                        IniUpdate(CategoryID);
                        return;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            Global.WriteLogError("lbtEdit_Click ()" + ex);
        }
    }

    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            //Lấy data
            Categories obj = (Categories)e.Item.DataItem;
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
            CategoryID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DoUpdate")
            {
                IniUpdate(CategoryID);
            }
            if (e.CommandName == "DoDeteled")
            {
                mpdeleted.Show();
            }  
            if (e.CommandName == "DoSetActive")
            {
                ImageButton ibtIsActived = e.Item.FindControl("ibtIsActived") as ImageButton;
                bool bIsActived = Convert.ToBoolean(ibtIsActived.Attributes["checked"]);
                this.SetActived(CategoryID, !bIsActived);
            }

        }
        catch (Exception ex)
        {
            Global.WriteLogError("rptData_ItemDataBound ()" + ex);
        }
    }

    private void IniUpdate(int CategoryID)
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Categories obj = new Categories();
            obj.DataObject = objdata;
            LoadTreeDDL();
            if (obj.GetByID(CategoryID))
            {
                txtCategoryName.Text = obj.CategoryName;
                cbkIsStatus.Checked = obj.IsActived;
                ddlTypes.SelectedValue = obj.TypeID.ToString();
                txtSort.Text = obj.Sort;
                Handle = HandleValue.Edit;
                lblHandle.Text = "Sửa danh mục";
                mdPopup.Show();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("IniUpdate() " +  ex);
        }
        
    }

    private void SetActived(int CategoryID, bool IsActived)
    {
        try
        {
            Libs.Data data = new Libs.Data(Global.ConnectionSql);
            Categories obj = new Categories();
            obj.DataObject = data;
            obj.CategoryID = CategoryID;
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

    private void Deleted(int CategoryID)
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Categories obj = new Categories();
            obj.DataObject = objdata;
            bool ok = obj.Delete(CategoryID);
        }
        catch (Exception ex)
        {
            Global.WriteLogError("Deleted() " + ex);

        }
    }

    protected void btnDeleted_Click(object sender, EventArgs e)
    {
        Deleted(CategoryID);
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

    private void Update(int CategoryID)
    {
        try
        {
            Data objdata = new Data(Global.ConnectionSql);
            Categories obj = new Categories();
            obj.DataObject = objdata;
            obj.CategoryID = CategoryID;
            obj.CategoryName = txtCategoryName.Text.Trim();
            obj.IsActived = cbkIsStatus.Checked;
            obj.Links = txtCategoryName.Text.Trim().Replace(" ", "-");
            obj.Sort = txtSort.Text.Trim();
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

    protected void btnCencal_Click(object sender, EventArgs e)
    {
        mdPopup.Hide();
    }
}