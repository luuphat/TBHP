using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_control_wucCategory : System.Web.UI.UserControl
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
            LoadTreeDDL();
            BindingCategory();
        }
    }

    private CategoryCollection LoadCategory(string stextsearch,int CategoryID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        CategoryCollection col = null;
        try
        {

            Category objcategory = new Category();
            objcategory.DataObject = objdata;
            col = objcategory.GetAll(stextsearch, CategoryID);
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadCategory()" + ex);
        }
        finally
        {
            objdata.DeConnect();
        }
        return col;
    }

    private void BindingCategory()
    {
        try
        {
            CategoryCollection col = null;
            col = this.LoadCategory(txtSearch.Text.Trim(), Convert.ToInt32(ddlHandleCategoryID.SelectedValue));
            if (col == null)
            {
                col = new CategoryCollection();
             //   lblCount.Text = "Có 0" + " record";
                rptData.DataSource = col;
                rptData.DataBind();
            }
            else
            {
                lblcount.Text = "Có " + col.Count.ToString() + " record";
                lblcount.ForeColor = System.Drawing.Color.Blue;
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

    private CategoryCollection GetSubData(CategoryCollection Source, int start, int end)
    {
        int iTotalRecord = Source.Count;
        CategoryCollection subSource = new CategoryCollection();
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
            Category objCategory = (Category)e.Item.DataItem;
            if (objCategory == null) { return; }
            //Set ID (unique id)

            HtmlInputCheckBox cbxSelect = e.Item.FindControl("cbxcheck") as HtmlInputCheckBox;
            if (cbxSelect != null)
            {
                CategoryID = Convert.ToInt32(objCategory.CategoryID);
                cbxSelect.Attributes.Add("uid", objCategory.CategoryID.ToString());

            }
        
            //set image
            ImageButton ibtIsActived = e.Item.FindControl("ibtIsActived") as ImageButton;
            if (ibtIsActived != null)
            {
                ibtIsActived.ImageUrl = "~/Images/uncheck.png";
                if (objCategory.IsActived) { ibtIsActived.ImageUrl = "~/Images/check.png"; }
                ibtIsActived.Attributes.Add("checked", objCategory.IsActived.ToString());
            }
            //set image
            ImageButton btnDelete = e.Item.FindControl("btnDelete") as ImageButton;
            if (btnDelete != null)
            {
                btnDelete.ImageUrl = "~/Images/delete.gif";
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
            if (e.CommandName == "Delete")
            {
                Deleted(CategoryID);
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindingCategory();
    }

    private void SetActived(int CategoryID, bool IsActived)
    {
         Libs.Data data = new Libs.Data(Global.ConnectionSql);
        try
        {           
            Category objcategory = new Category();
            objcategory.DataObject = data;
            objcategory.CategoryID = CategoryID;
            objcategory.IsActived = IsActived;
            if (objcategory.SetActived()) //no error
            {
                this.BindingCategory();

            }
            else
            {

                return;
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("SetActived() " + ex);

        }
        finally
        {
            data.DeConnect();
        }
    }

    private void Deleted(int CategoryID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
           
            Category obj = new Category();
            obj.DataObject = objdata;
            bool ok = obj.Delete(CategoryID);
            BindingCategory();
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
        //Response.Write("<script>window.location='CreateEditCategory.aspx'</script>");
        Response.Redirect("~/admin/CreateEditCategory.aspx");
    }

    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        this.BindingCategory();
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindingCategory();
    }

    private void LoadTreeDDL()
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Category objcategory = new Category();
            objcategory.DataObject = objdata;
            ddlHandleCategoryID.Items.Clear();
            ddlHandleCategoryID.Items.Insert(0, new ListItem("------[Tất cả]-----", "-1"));
            CategoryCollection col = objcategory.GetAll(string.Empty, -1);
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
                    ddlHandleCategoryID.Items.Add(new ListItem(category.CategoryName, category.CategoryID.ToString()));
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
                ddlHandleCategoryID.Items.Add(new ListItem(sTab + category.CategoryName, category.CategoryID.ToString()));
                AddChildrenHandle(category.CategoryID, col);                     // find this child's children
            }
        }
    }
}