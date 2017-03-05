<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/admincp/Site.master"
    AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Account_ChangePassword" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="accountInfo">
        <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="txtNewPassword"
            ControlToValidate="txtConfirmNewPassword" CssClass="failureNotification">Mật khẩu không giống nhau!</asp:CompareValidator>
        <fieldset class="register">
            <p>
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Mật khẩu cũ:</asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblNewPassword" runat="server" AssociatedControlID="txtNewPassword">Mật khẩu mới:</asp:Label>
                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="txtNewPassword"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblConfirmNewPassword" runat="server" AssociatedControlID="txtConfirmNewPassword">Mật khẩu xác nhận:</asp:Label>
                <asp:TextBox ID="txtConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="txtConfirmNewPassword"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" CommandName="Submit" Text="Đổi mật khẩu"
                    OnClick="btnSubmit_Click" />
            </p>
        </fieldset>
    </div>
</asp:Content>
