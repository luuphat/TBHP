using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

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
                GetIntroduct(Convert.ToInt32(Request["id"].ToString()));
            }
        }

    }
    private void GetIntroduct(int ID)
    {
        News obj = new News().GetByNewsID(ID);
        _title = obj.Title;
        _content = obj.Detail;        
    }
}