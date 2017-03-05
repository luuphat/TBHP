<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Login_ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quên mật khẩu </title>
    <link href="../Css/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      <div>
            <div class="login">
                <div class="heading">
                    <h1>
                        <img src="../images/lock_unlock.png" alt="">
                        Lấy lại mật khẩu</h1>
                </div>
                <div class="contentlogin">
                    <table width="90%" border="0" cellspacing="0" cellpadding="0" align="center" class="tb_login">
                        <tr>
                            <td width="40%" rowspan="3">
                                <img src="../images/login.jpg" /></td>
                            <td width="60%">Tên đăng nhập:<br />
                                <label>
                                    <asp:TextBox ID="txtUserName" ValidationGroup="email" Width="200px" runat="server" CssClass="button"></asp:TextBox>
                                    <%--  <input type="text" name="textfield" id="textfield" class="button" />--%>
                                </label>
                            </td>
                        </tr>
                    <%--   <tr>
                            <td width="60%">Mật khẩu mới:<br />
                                <label>
                                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                </label>
                            </td>
                             

                        </tr>--%>
                          <tr>
                            <td width="60%">Email của bạn:<br />
                                <label>
                                    <asp:TextBox ID="txtEmail" Width="200px" runat="server"></asp:TextBox>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="(*)"  ValidationGroup="email" ControlToValidate="txtEmail" 
                
                                        ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                    </asp:RegularExpressionValidator>
                                    
                                </label>
                            </td>
                             

                        </tr>
                        <tr>
                             <td width="60%"> <asp:Label ID="lblmessage" runat="server"></asp:Label> </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><span>
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"  ValidationGroup="email" /></span></td>
                        </tr>
                    </table>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
