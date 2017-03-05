using DLLFuniture;
using Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_control_wucnews_edit : System.Web.UI.UserControl
{
    public int NewsID
    {
        get
        {
            object obj = ViewState["NewsID"];
            return ((obj == null) ? -1 : Convert.ToInt32(ViewState["NewsID"]));
        }
        set { ViewState["NewsID"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["nid"]))
            {
                NewsID = Convert.ToInt32(Request["nid"]);
                IniUpdate(NewsID);
            }
        }
    }

    private void IniUpdate(int NewsID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {

            News obj = new News();
            obj.DataObject = objdata;
            lblHandleTitle.Text = "Sửa tin tức";
            imgImages.ImageUrl = Global.Root + Global.GetConfigKey("uploadnews") + "alternate.png";
            if (obj.GetByID(NewsID))
            {
                if (!string.IsNullOrEmpty(obj.Image))
                {
                    imgImages.ImageUrl = obj.Image;
                    imgImages.Attributes.Add("images", obj.Image);
                }

                txtTitle.Text = obj.Title;
                txtDescription.Text = obj.Description;
                radContents.Content = obj.Detail;

            }
        }
        catch (Exception ex)
        {
            Global.WriteLogError("IniUpdate() " + ex);
        }
        finally
        {
            objdata.DeConnect();
        }
    }

    private void Update(int NewsID)
    {
        Data objdata = new Data(Global.ConnectionSql);
        try
        {
            News obj = new News();
            obj.DataObject = objdata;
            obj.NewsID = NewsID;
            obj.Title = txtTitle.Text.Trim();
            obj.Description = txtDescription.Text.Trim();
            obj.Detail = radContents.Content;
            obj.Links = txtTitle.Text.Trim().Replace(" ", "-");
            //GetImage
            if (!string.IsNullOrEmpty(imgImages.Attributes["images"]))
            {
                obj.Image = imgImages.Attributes["images"];
            }
            if (this.uplImage.HasFile)
            {
                Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromBinary(this.uplImage.FileBytes);
                Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                actResize.Width = 150;
                actResize.Height = 150;
                uploadedImage.Actions.Add(actResize);
                Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                imgDraw.Elements.Add(uploadedImage);
                imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                imgDraw.JpegCompressionLevel = 90;
                string filename = GetDate + "_" + uplImage.FileName;
                imgDraw.Save(Server.MapPath(Global.GetConfigKey("uploadnews") + filename));
                obj.Image = Global.GetConfigKey("uploadnews") + filename;
            }
            int iResult = Convert.ToInt32(obj.Update());
            if (iResult > 0)
            {
                Response.Write("<script>window.location='news.aspx'</script>");

            }
            else if (iResult == 0)
            {

                lblMessage.Text = "Trùng dữ liệu vui lòng kiểm tra lại";
                return;
            }
            else
            {
                lblMessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu. Liên hệ với người quản trị để khắc phục";
                return;
            }

        }
        catch (Exception ex)
        {
            Global.WriteLogError("Update () " + ex);
            lblMessage.Text = "Lỗi xảy ra trong quá trình lưu dữ liệu. Liên hệ với người quản trị để khắc phục";
            return;
        }
        finally
        {
            objdata.DeConnect();
        }
    }

    string GetDate
    {
        get
        {
            return DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        Update(NewsID);
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.location='news.aspx'</script>");
    }
}