using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs;
using DLLFuniture;

public partial class Web_slide : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                int pid = Convert.ToInt32(Request["id"]);
                LoadSlide(Convert.ToInt32(Request["id"]));
            }
        }
  
    }
    private void LoadSlide(int productID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Img obj = new Img();
            obj.DataObject = objdata;
            ImgCollection col = new ImgCollection();
            col = obj.Getlist(productID);
            if (col != null)
            {
                rptData.DataSource = col;
                rptData.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadSlide()" + ex);
        }
        finally
        {
            objdata.DeConnect();
        }

    }
}