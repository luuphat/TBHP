using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Global
/// </summary>
public class Global
{
    public static string Root
    {
        get
        {
            string sPathRoot = HttpContext.Current.Request.ApplicationPath;
            if (sPathRoot == "/")
                return "";
            else
                return sPathRoot;
        }
    }

    public static double CacheTimeOut
    {
        get
        {
            double dCacheTimeout = 24 * 60; //1 ngày
            try
            {
                dCacheTimeout = Convert.ToDouble(Global.GetConfigKey("CacheTimeOut"));
            }
            catch
            {
                Global.WriteLogError("Not found key config CacheTimeOut !");
            }
            return dCacheTimeout;
        }
    }

    public static string GetConfigKey(string Key)
    {
        string sKey = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings[Key]);
        if (string.IsNullOrEmpty(sKey)) { return string.Empty; }
        else { return sKey; }
    }

    public static void WriteLogError(string errorMessage)
    {
        try
        {
            string path = "~/Error/" + DateTime.Today.ToString("dd-mm-yy") + ".txt";
            if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
            }
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                w.WriteLine("\r\nLog Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                string err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString() +
                              ". Error Message:" + errorMessage;
                w.WriteLine(err);
                w.WriteLine("__________________________");
                w.Flush();
                w.Close();
            }
        }
        catch (Exception ex)
        {
            WriteLogError(ex.Message);
        }

    }

    public static bool IsValidImagesFile(string filename, int filesize)
    {
        bool result = false;
        //Check extension file
        int index = filename.LastIndexOf(".");
        string[] strImageExts = { "gif", "jpg", "jpeg", "jpe", "png", "bmp" };
        if (index > 0)
        {
            string ext = filename.Substring(index + 1).ToLower();
            for (int i = 0; i < strImageExts.Length; i++)
            {
                if (ext == strImageExts[i])
                {
                    result = true;
                    break;
                }
            }
        }
        if (!result) return result;
        //Check filesize
        int FileSizeValid = Convert.ToInt32(Global.GetConfigKey("PresentationImageSize"));
        if (filesize > FileSizeValid)
        {
            return false;
        }
        return true;
    }

    public static bool IsValidVideoFile(string filename)
    {
        int index = filename.LastIndexOf(".");
        string[] strImageExts = { "flv" };
        if (index > 0)
        {
            string ext = filename.Substring(index + 1).ToLower();
            int count = 0;
            for (int i = 0; i < strImageExts.Length; i++)
                if (ext != strImageExts[i])
                    count++;
            if (count == strImageExts.Length)
                return false;
            else
                return true;
        }
        return false;
    }

    public static bool IsValidFlashFile(string filename)
    {
        int index = filename.LastIndexOf(".");
        string[] strImageExts = { "swf" };
        if (index > 0)
        {
            string ext = filename.Substring(index + 1).ToLower();
            int count = 0;
            for (int i = 0; i < strImageExts.Length; i++)
                if (ext != strImageExts[i])
                    count++;
            if (count == strImageExts.Length)
                return false;
            else
                return true;
        }
        return false;
    }

    public static bool IsNumber(string Number)
    {
        if (string.IsNullOrEmpty(Number)) { return false; }
        return System.Text.RegularExpressions.Regex.IsMatch(Number, "^\\d+(\\.\\d+)?$");
    }

    public static bool IsEmail(string sEmail)
    {
        bool bIsOk = true;
        if (string.IsNullOrEmpty(sEmail))
        {
            bIsOk = false;
        }
        else
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);
            if (!re.IsMatch(sEmail))
                bIsOk = false;
        }
        return bIsOk;
    }

    public static bool IsPhoneNumber(string sPhone)
    {
        bool bIsOk = true;
        if (!IsNumber(sPhone) || sPhone.Length > 11 || sPhone.Length < 6)
        {
            bIsOk = false;
        }
        return bIsOk;
    }

    public static bool IsValidBannerFile(string filename)
    {
        int index = filename.LastIndexOf(".");
        string[] strExts = Global.GetConfigKey("ArrayBannerFile").Split(',');
        if (index > 0)
        {
            string ext = filename.Substring(index + 1).ToLower();
            int count = 0;
            for (int i = 0; i < strExts.Length; i++)
                if (ext != strExts[i].ToLower())
                    count++;
            if (count == strExts.Length)
                return false;
            else
                return true;
        }
        return false;
    }

    public static string FilterFileName(string filename)
    {
        try
        {
            filename = filename.Replace("\"", "");
            filename = filename.Replace("'", "");
            filename = filename.Replace("\\", "");
            filename = filename.Replace(",", "");
            filename = filename.Replace(":", "");
            filename = filename.Replace("(", "");
            filename = filename.Replace(")", "");
            filename = filename.Replace("`", "");
            filename = filename.Replace("{", "");
            filename = filename.Replace("}", "");
            filename = filename.Replace("[", "");
            filename = filename.Replace("  ", " ");
            filename = filename.Replace(" ", "-");
            filename = filename.Replace("]", "");
            filename = filename.Replace("*", "");
            filename = filename.Replace(";", "");
            return Libs.Globals.FilterVietkey(filename);
        }
        catch (Exception exp)
        {
            Global.WriteLogError(exp.ToString());
            return string.Empty;
        }
    }

    public static string ConnectionSql
    {
        get { return Global.GetConfigKey("strConnerction"); }
    }
}