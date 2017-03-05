using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using tbhp.DataAccess;

public partial class handler_category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.Write(LoadData());
            Response.End();
        }
        catch { }
    }
    string LoadData()
    {
        string id = Request["id"];
        if (!string.IsNullOrEmpty(id))
        {
            var list = from l in new Categories().GetList()
                       where l.TypeID == Convert.ToInt32(id)
                       select new { l.CategoryID, l.CategoryName };
            return JsonConvert.SerializeObject(list);
        }
        return "";
    }
}