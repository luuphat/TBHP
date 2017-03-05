using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs;
using DLLFuniture;
using System.Data;

public partial class Web_ProductDetail : System.Web.UI.Page
{
    private int pid = 0;
    private int cid = 0;
    protected int productID = 0;
    protected string productcode = "0";
    protected string imgproduct = string.Empty;
    protected string sTitle = string.Empty;
    protected string description = string.Empty;
    protected string content = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["id"]) && !string.IsNullOrEmpty(Request["cid"]))
        {
            pid = Convert.ToInt32(Request["id"]);
            cid = Convert.ToInt32(Request["cid"]);
            LoadData(pid);
            LoadRelate(cid, pid);
            UpdateViews(pid);           
        }
       
    }
   private  void LoadData(int id)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            Products obj = new Products();
            obj.DataObject = objdata;
            if (obj.GetByID(pid))
            {
                productID = obj.NewsID;
                sTitle = obj.Title;
                description = obj.Description;
                if (obj.ProductCode != null)
                { 
                    productcode = obj.ProductCode;
                    imgproduct = obj.Image;
                }
                content = obj.Detail;
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

   private void LoadRelate(int cid, int pid)
   {
       Data objdata = new Data(Global.ConnectionSql);
       try
       {          
           Products obj = new Products();
           obj.DataObject = objdata;
           ProductsCollection col = obj.GetListRelate(cid, pid);
           if (col != null)
           {
               rptRelate.DataSource = col;
               rptRelate.DataBind();
           }

       }
       catch (Exception ex)
       {
           Global.WriteLogError("LoadRelate()" + ex);
       }
       finally
       {
           objdata.DeConnect();
       }
   }

   private void LoadDataRelateTop(int cid, int pid)
   {
       Data objdata = new Data(Global.ConnectionSql);
       try
       {
           DataTable dt = new DataTable();
           dt.Columns.Add("ProductCode", typeof(string));
           dt.Columns.Add("STT", typeof(int));
           dt.Columns.Add("Title", typeof(string));
           DataRow row;        
           Products obj = new Products();
           obj.DataObject = objdata;
           ProductsCollection col = obj.GetListRelate(cid, pid);
           if (col != null)
           {
               int i = 1;
               foreach (Products n in col)
               {
                   row = dt.NewRow();
                   row["ProductCode"] = n.ProductCode;
                   row["STT"] = i++;
                   row["Title"] = n.Title;
                   dt.Rows.Add(row);
               }
              // rptDataTopRelate.DataSource = dt;
             //  rptDataTopRelate.DataBind();
           }
       }
       catch (Exception ex)
       {
           Global.WriteLogError("LoadDataTopNews() : " + ex);
       }
       finally
       {
           objdata.DeConnect();
       }
   }

   private void UpdateViews(int id)
   {
       Data objdata = new Data(Global.ConnectionSql);
       try
       {
           Products obj = new Products();
           obj.DataObject = objdata;
           int result = obj.UpdateCountViews(id);

       }
       catch (Exception ex)
       {
           Global.WriteLogError("UpdateViews()" + ex);
       }
       finally
       {
           objdata.DeConnect();
       }
   }
}