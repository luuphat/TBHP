﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs;
using DLLFuniture;

public partial class Web_Subject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    private void LoadData()
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {          
            News obj = new News();
            obj.DataObject = objdata;
            NewsCollection col = new NewsCollection();
            col = obj.GetList(string.Empty);
            if (col != null)
            {
                rptData.DataSource = col;
                rptData.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadData()" + ex);
        }
        finally {
            objdata.DeConnect();
        }
    }
}