﻿using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_control_wucsys_users : System.Web.UI.UserControl
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
        lblHandle.Text = "Thêm mới user";
        lblmessage.Text = string.Empty;
    }

    private void Insert()
    {

        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            system_user obj = new system_user();
            obj.DataObject = objdata;
            obj.UserName = txtType.Text.Trim();
            obj.Passwords = txtValue.Text.Trim();
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

    private system_UsersCollection LoadData(string stextsearch)
    {
        Data objdata = new Data(Global.ConnectionSql);
        system_UsersCollection col = null;
        try
        {
            system_user obj = new system_user();
            obj.DataObject = objdata;
            col = obj.Getlist(stextsearch);
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
            system_UsersCollection col = null;
            col = this.LoadData(txtSearch.Text.Trim());
            if (col == null)
            {
                col = new system_UsersCollection();
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

    private system_UsersCollection GetSubData(system_UsersCollection Source, int start, int end)
    {
        int iTotalRecord = Source.Count;
        system_UsersCollection subSource = new system_UsersCollection();
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
            system_user obj = new system_user();
            obj.DataObject = objdata;

            if (obj.GetByID(ID))
            {
                txtType.Text = obj.UserName;
                txtValue.Text = obj.Passwords;
                Handle = HandleValue.Edit;
                lblHandle.Text = "Sửa user";
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
            system_user obj = new system_user();
            obj.DataObject = objdata;
            obj.ID = id;
            obj.UserName = txtType.Text.Trim();
            obj.Passwords = txtValue.Text.Trim();
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
            system_user obj = new system_user();
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
            system_user obj = (system_user)e.Item.DataItem;
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