using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tbhp.DataAccess;

public partial class Upload : System.Web.UI.Page
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
    void UploadImage()
    {
        if (this.IsValid && this.uplImage.HasFile)
        {
            if (MyFunction.validUploadImage(uplImage.FileName.Substring(uplImage.FileName.LastIndexOf('.'))))
            {
                uplImage.SaveAs(Server.MapPath("~/uploads/images/" + uplImage.FileName));
                ShowMessage("File đã được tải lên");
            }
            else
            {
                lblMessage.Text = "File không đúng định dạng. Chỉ chấp nhận các dạng file *.jpg, *.jpeg, *.gif, *.png, *.bmp, *.swf";
            }
        }
    }
    void ShowMessage(string str)
    {
        Response.Write("<script>alert('"+str+"')</script>");
    }

}
