using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_control_wucnews : System.Web.UI.UserControl
{
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
            this.BindingData();
        }
    }

    private NewsCollection LoadData()
    {
        Data objdata = new Data(Global.ConnectionSql);
        NewsCollection col = null;
        try
        {
            News obj = new News();
            obj.DataObject = objdata;
            col = obj.GetList(txtSearch.Text.Trim());
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadProduct()" + ex);
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
            NewsCollection col = null;
            col = this.LoadData();
            if (col == null)
            {
                col = new NewsCollection();
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

    private NewsCollection GetSubData(NewsCollection Source, int start, int end)
    {
        int iTotalRecord = Source.Count;
        NewsCollection subSource = new NewsCollection();
        if (Source != null)
        {
            for (int i = start; i < end; i++)
            {
                subSource.Add(Source[i]);
            }
        }
        return subSource;
    }

    private void Deleted(int NewsID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            News obj = new News();
            obj.DataObject = objdata;
            bool ok = obj.Delete(NewsID);
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
    }

    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        this.BindingData();
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindingData();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/news_add.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindingData();
    }

    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            //Lấy data
            News obj = (News)e.Item.DataItem;
            if (obj == null) { return; }
            ////Set x
            ////set image
            //ImageButton ibtIsActived = e.Item.FindControl("ibtIsActived") as ImageButton;
            //if (ibtIsActived != null)
            //{
            //    ibtIsActived.ImageUrl = "~/Images/uncheck.png";
            //    if (obj.IsActived) { ibtIsActived.ImageUrl = "~/Images/check.png"; }
            //    ibtIsActived.Attributes.Add("checked", obj.IsActived.ToString());
            //}
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
            NewsID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {
                Deleted(NewsID);
            }
            if (e.CommandName == "DoSetActive")
            {
                ImageButton ibtIsActived = e.Item.FindControl("ibtIsActived") as ImageButton;
                bool bIsActived = Convert.ToBoolean(ibtIsActived.Attributes["checked"]);
               // this.SetActived(NewsID, !bIsActived);
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("rptData_ItemDataBound ()" + ex);
        }
    }
}