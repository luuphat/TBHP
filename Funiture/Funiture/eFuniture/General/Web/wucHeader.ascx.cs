﻿using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class General_wucHeader : System.Web.UI.UserControl
{
   
    protected string _phone = string.Empty;
    protected string _facebook = string.Empty;
    protected string _twitter = string.Empty;   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           _phone= GetPhone("hotline");
           _facebook= GetPhone("facebook");
           _twitter = GetPhone("twitter");
        }
    }
    private string  GetPhone(string ID)
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
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/search.aspx?t=" + txtsearch.Text.Trim());
    }
}