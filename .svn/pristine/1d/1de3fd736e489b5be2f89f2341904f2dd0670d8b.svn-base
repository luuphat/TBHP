<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePass.aspx.cs" Inherits="Login_ChangePass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="../Css/login.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 40%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="login">
                <div class="heading">
                    <h1>
                        <img src="../images/lock_unlock.png" alt="">
                       Đổi mật khẩu</h1>
                </div>
                <div class="contentlogin">
                    <table width="90%" border="0" cellspacing="0" cellpadding="0" align="center" class="tb_login">
                        <tr>
                            <td rowspan="3" class="auto-style1">
                                <img src="../images/login.jpg" /></td>
                            <td width="60%">Mật khẩu củ:<br />
                                <label>
                                    <asp:TextBox ID="txtOldPassword"  Width=" 200px" TextMode="Password" runat="server" CssClass="button"></asp:TextBox>
                                    <%--  <input type="text" name="textfield" id="textfield" class="button" />--%>
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td width="60%">Mật khẩu mới:<br />
                                <label>
                                    <asp:TextBox ID="txtNewPassword"  Width=" 200px"  runat="server" TextMode="Password"></asp:TextBox>
                                </label>
                                </br><a href="ForgotPassword.aspx" class="linkforgot">Quên mật khẩu</a></td>
                          
                        </tr>
                        <tr>
                             <label><td width="60%"><asp:Label ID="lblmessage" runat="server"></asp:Label> <br /></label>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <label>
                                <asp:Button ID="btnLogin" runat="server" Text="Đổi mật khẩu" OnClick="btnLogin_Click" />
                            </td>
                        </tr>
                    </table>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
