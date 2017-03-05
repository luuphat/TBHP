using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs;
using DLLFuniture;
using System.Web.UI.HtmlControls;

public partial class admin_control_wucsize : System.Web.UI.UserControl
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

    public int uID
    {
        get
        {
            object obj = ViewState["uID"];
            return ((obj == null) ? -1 : Convert.ToInt32(ViewState["uID"]));
        }
        set { ViewState["uID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IniInsert();
            this.BindingData();
        }
    }

    private void IniInsert()
    {
        txtType.Text = string.Empty;
        txtValue.Text = string.Empty;
        Handle = HandleValue.Add;
        lblHandle.Text = "Thêm mới kích thước";
        lblmessage.Text = string.Empty;
    }

    private void Insert()
    {

        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            size obj = new size();
            obj.DataObject = objdata;
            obj.Width = txtType.Text.Trim();
            obj.Height = txtValue.Text.Trim();
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
                lblmessage.Text = "Lỗi xảy ra. Vui lòng liên hệ người quản trị để khắc phục !";
                Global.WriteLogError("Insert() " + "");
                mdPopup.Show();
            }

        }
        catch (Exception ex)
        {
            Global.WriteLogError("Insert() " + ex);

        }
        finally
        {
            objdata.DeConnect();
        }
    }

    private sizeCollection LoadData(string stextsearch)
    {
        Data objdata = new Data(Global.ConnectionSql);
        sizeCollection col = null;
        try
        {
            size obj = new size();
            obj.DataObject = objdata;
            col = obj.GetAll();
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadData()" + ex);
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
            sizeCollection col = null;
            col = this.LoadData(txtSearch.Text.Trim());
            if (col == null)
            {
                col = new sizeCollection();
                lblcount.Text = "Có 0" + " record";
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
            Global.WriteLogError("BindingData()" + ex);
        }
    }

    private sizeCollection GetSubData(sizeCollection Source, int start, int end)
    {
        int iTotalRecord = Source.Count;
        sizeCollection subSource = new sizeCollection();
        if (Source != null)
        {
            for (int i = start; i < end; i++)
            {
                subSource.Add(Source[i]);
            }
        }
        return subSource;
    }

    private void IniUpdate(int ID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            size obj = new size();
            obj.DataObject = objdata;

            if (obj.GetByID(ID))
            {
                txtType.Text = obj.Width;
                txtValue.Text = obj.Height;
                Handle = HandleValue.Edit;
                lblHandle.Text = "Sửa kích thước";
                mdPopup.Show();
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

    private void Update(int id)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            size obj = new size();
            obj.DataObject = objdata;
            obj.ID = id;
            obj.Width = txtType.Text.Trim();
            obj.Height = txtValue.Text.Trim();
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
        finally
        {
            objdata.DeConnect();
        }
    }

    private bool Deleted(int id)
    {
        Data objdata = new Data(Global.ConnectionSql);
        bool ok = false;
        try
        {
            size obj = new size();
            obj.DataObject = objdata;
            ok = obj.Delete(id);
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
        return ok;

    }

    protected void btnDeleted_Click(object sender, EventArgs e)
    {
        Deleted(uID);

    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindingData();
    }

    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        this.BindingData();
    }

    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            //Lấy data
            size obj = (size)e.Item.DataItem;
            if (obj == null) { return; }
            //Set ID (unique id)

            HtmlInputCheckBox cbxSelect = e.Item.FindControl("cbxcheck") as HtmlInputCheckBox;
            if (cbxSelect != null)
            {
                uID = obj.ID;
                cbxSelect.Attributes.Add("uid", obj.ID.ToString());
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
            uID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DoUpdate")
            {
                IniUpdate(uID);
            }
            if (e.CommandName == "Delete")
            {
                Deleted(uID);
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("rptData_ItemDataBound ()" + ex);
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
            Update(uID);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindingData();

    }
}