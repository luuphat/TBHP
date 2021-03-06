﻿using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class General_wucFooter : System.Web.UI.UserControl
{
    protected string _footer = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //  _footer = GetPhone("footer");
            LoadData();
        }
    }
    private string GetPhone(string ID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        string _value = string.Empty;
        try
        {
            Settings obj = new Settings();
            obj.DataObject = objdata;
            obj.GetByID(ID);
            _value = obj.Value;
            
        }
        catch (Exception ex)
        {
            Global.WriteLogError("GetPhone ()" + ex);
        }
        finally {
            objdata.DeConnect();
        }
        return _value;
    }

    private void LoadData()
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Footer obj = new Footer();
            obj.DataObject = objdata;
            FooterCollection col = new FooterCollection();
            col = obj.GetList(string.Empty);
            if (col != null)
            {
                rptFooter.DataSource = col;
                rptFooter.DataBind();
            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("LoadData()" + ex);
        }
        finally
        {
            objdata.DeConnect();
        }
    }
}