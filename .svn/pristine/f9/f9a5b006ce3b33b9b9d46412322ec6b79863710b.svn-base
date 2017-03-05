using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs;
using DLLFuniture;

public partial class Web_NewsDetail : System.Web.UI.Page
{
    protected string _content = string.Empty;
    protected string _title = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null)
            {
                GetNewDetail(Convert.ToInt32(Request["id"].ToString()));
            }
        }

    }
    private void GetNewDetail(int ID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            News obj = new News();
            obj.DataObject = objdata;
            obj.GetByID(ID);
            _title = obj.Title;
            _content = obj.Detail;
        }
        catch (Exception ex)
        {
            Global.WriteLogError("GetNewDetail()" + ex);
        }
        finally
        {
            objdata.DeConnect();
        }
         
    }
}