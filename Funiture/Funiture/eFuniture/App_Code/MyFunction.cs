using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;
using System.Web.Security;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;

public static class MyFunction
{
    public static string ConvertUrl(string str)
    {
        string str1 = str.ToLower();
        for (int i = 1; i < VietnameseSigns.Length; i++)
        {
            for (int j = 0; j < VietnameseSigns[i].Length; j++)

                str1 = str1.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
        }
        str1 = str1.Trim('-');
        str1 = str1.Replace("--", "-");
        return str1;
    }
    private static readonly string[] VietnameseSigns = new string[]
    {
        "aeouidy-",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "éèẹẻẽêếềệểễ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "úùụủũưứừựửữ",
        "íìịỉĩ",
        "đ",
        "ýỳỵỷỹ",
        "!@$%^*()+=<>?/,.:\"&#[]~ '’",
    };
    public static string EncodePassword(string password)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
    }
    public static string CutTitle(string str, int n)
    {
        if (str.Length > n)
        {
            return str.Substring(0, n);
        }
        return str;
    }
    public static System.Drawing.Bitmap ResizeImage(System.Drawing.Bitmap src, int newWidth, int newHeight)
    {
        System.Drawing.Bitmap result = new System.Drawing.Bitmap((int)newWidth, (int)newHeight);
        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage((System.Drawing.Image)result))
            g.DrawImage(src, 0, 0, (int)newWidth, (int)newHeight);
        return result;
    }
    public static string WriteFlash(string f, int w, int h)
    {
        string str = "";
        str += "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0'";
        str += "width='" + w + "' height='" + h + "'>";
        str += "<param name='movie' value='uploads/ads/" + f + "' />";
        str += "<param name='quality' value='high' />";
        str += "<param name='wmode' value='transparent'>";
        str += "<embed src='uploads/ads/" + f + "' quality='high' type='application/x-shockwave-flash'";
        str += "wmode='transparent' width='" + w + "' height='" + h + "' pluginspage='http://www.macromedia.com/go/getflashplayer' />";
        str += "</object>";
        return str;
    }
    public static bool SendMail(string form, string to, string title, string boby)
    {
        try
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("todaysolution.net@gmail.com", "C5E1048114004400944F168DEC529C21AC3D5FE0"),
                EnableSsl = true
            };
            MailMessage mm = new MailMessage(form, to);
            mm.Subject = title;
            mm.Body = boby;
            mm.IsBodyHtml = true;
            client.Send(mm);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool validUploadImage(string str)
    {
        string[] a = { ".jpg", ".jpeg", ".gif", ".png", ".bmp", ".swf" };
        for (int i = 0; i < a.Length; i++)
        {
            if (str.ToLower() == a[i].ToString())
                return true;
        }
        return false;
    }
}
