using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

public partial class Ad_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            UploadImage();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    void AddData()
    {
        try
        {
            Ads obj = new Ads();
            obj.Name = txtTitle.Text;
            obj.Link = txtLink.Text;
            obj.Location = ddlLocation.SelectedValue;
            obj.Type = ddlType.SelectedValue;
            obj.Width = Convert.ToInt32(txtWidth.Text);
            obj.Height = Convert.ToInt32(txtHeight.Text);
            obj.Item = Convert.ToInt32(txtSort.Text);
            obj.View = 0;
            obj.Image = txtImage.Text;
            obj.Status = chkStatus.Checked;
            obj.Add(obj);
            ShowMessage("Dữ liệu đã được cập nhật");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    void UploadImage()
    {
        if (this.IsValid && this.uplImage.HasFile)
        {
            if (MyFunction.validUploadImage(uplImage.FileName.Substring(uplImage.FileName.LastIndexOf('.'))))
            {
                uplImage.SaveAs(Server.MapPath("~/uploads/ads/" + uplImage.FileName));
                txtImage.Text = uplImage.FileName;
                AddData();
            }
            else
            {
                lblMessage.Text = "File không đúng định dạng. Chỉ chấp nhận các dạng file *.jpg, *.jpeg, *.gif, *.png, *.bmp, *.swf";
            }
        }
    }
    void ShowMessage(string str)
    {
        Response.Write("<script>alert('"+str+"');window.location='ad.aspx'</script>");
    }

}
