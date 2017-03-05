<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="admincp_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <style>
        body{font-family:Arial;font-size:12px;}
    </style>
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <div style="padding-top: 150px">
            <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" 
            BorderStyle="Solid" BorderWidth="1px" 
            FailureText="Mật khẩu không chính xác!" Font-Names="Verdana" 
            Font-Size="0.9em" LoginButtonText="Đăng nhập" PasswordLabelText="Mật khẩu:" 
            RememberMeText="Nhớ mật khẩu truy cập" TitleText="Đăng nhập" 
            UserNameLabelText="Tên đăng nhập:" onauthenticate="Login1_Authenticate" 
            BorderPadding="4" ForeColor="#333333" Height="161px" Width="233px">
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#FFFFFF" 
                Font-Size="0.9em" />
            <TextBoxStyle Font-Size="0.8em" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        </asp:Login>
        </div>
        </form>
    </center>
</body>
</html>
