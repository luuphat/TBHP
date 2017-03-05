<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login-CMS </title>
    <link href="../Css/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="login">
                <div class="heading">
                    <h1>
                        <img src="../images/lock_unlock.png" alt="">
                        Tài khoản đăng nhập</h1>
                </div>
                <div class="contentlogin">
                    <table width="90%" border="0" cellspacing="0" cellpadding="0" align="center" class="tb_login">
                        <tr>
                            <td width="40%" rowspan="3">
                                <img src="../images/login.jpg" /></td>
                            <td width="60%">Tên đăng nhập:<br />
                                <label>
                                    <asp:TextBox ID="txtUserName" Width="200px" runat="server" CssClass="button"></asp:TextBox>
                                    <%--  <input type="text" name="textfield" id="textfield" class="button" />--%>
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td width="60%">Mật khẩu:<br />
                                <label>
                                    <asp:TextBox ID="txtPassword"  Width="200px" runat="server" TextMode="Password"></asp:TextBox>
                                    <%--<input type="text" name="textfield" id="textfield" />--%>
                                </label>
                                </br><a href="ForgotPassword.aspx" class="linkforgot">Quên mật khẩu</a></td>
                             
                        </tr>
                        <tr>
                            <td width="60%"><asp:Label ID="lblmessage" runat="server"></asp:Label> </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><span>
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></span></td>
                        </tr>
                    </table>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
