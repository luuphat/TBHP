using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

public partial class Web_Introduct : System.Web.UI.Page
{
    protected string _content = string.Empty;
    protected string _title = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.GetIntroduct("gioi-thieu");
        }        
    }
    private void GetIntroduct(string ID)
    {
        Contents obj = new Contents().GetByID(ID);
        _content = obj.Detail;
        _title = obj.Title;
    }

}