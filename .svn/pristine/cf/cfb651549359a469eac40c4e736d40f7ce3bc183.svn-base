using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

public partial class Web_ProductDetail : System.Web.UI.Page
{
    private int pid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            //pid = Convert.ToInt32(Request["id"]);
            //LoadData(pid);
        }
       
    }
   private  void LoadData(int id)
    {
        try
        {
            Products obj = new Products().GetByNewsID(id);
            if (obj != null)
            {
               
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadData()" + ex);
        }
    }
}