using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_control_wucslide : System.Web.UI.UserControl
{
    protected string sTitle = string.Empty;

    public int ProductID
    {
        get
        {
            object obj = ViewState["ProductID"];
            return ((obj == null) ? -1 : Convert.ToInt32(ViewState["ProductID"]));
        }
        set { ViewState["ProductID"] = value; }
    }

    public int ImageID
    {
        get
        {
            object obj = ViewState["ImageID"];
            return ((obj == null) ? -1 : Convert.ToInt32(ViewState["ImageID"]));
        }
        set { ViewState["ImageID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        sTitle = Request["n"].ToString();
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["pid"]))
            {
                ProductID = Convert.ToInt32(Request["pid"]);
                this.BindingData();
            }
        }
    }

    private ImgCollection LoadProduct(int ProductID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        ImgCollection col = new ImgCollection();
        try
        {
            Img obj = new Img();
            obj.DataObject = objdata;
            col = obj.Getlist(ProductID);
            if (col != null)
            {
                rptData.DataSource = col;
                rptData.DataBind();
            }
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
            ImgCollection col = null;
            col = this.LoadProduct(ProductID);
            rptData.DataSource = col;
            rptData.DataBind();

        }
        catch (Exception ex)
        {
            Global.WriteLogError("BindingData()" + ex);
        }

    }

    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            //Lấy data
            Img obj = (Img)e.Item.DataItem;
            if (obj == null) { return; }
            ImageButton btnDelete = e.Item.FindControl("btnDelete") as ImageButton;
            if (btnDelete != null)
            {
                btnDelete.ImageUrl = "~/Images/delete.png";
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
            ImageID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {
                Deleted(ImageID);
            }          
        }
        catch (Exception ex)
        {
            Global.WriteLogError("rptData_ItemDataBound ()" + ex);
        }
    }

    private void Deleted(int ImageID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Img obj = new Img();
            obj.DataObject = objdata;
            bool ok = obj.Delete(ImageID);
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

}