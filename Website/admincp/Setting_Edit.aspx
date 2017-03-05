<%@ Page Title="Log In" Language="C#" MasterPageFile="~/admincp/Site.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="Setting_Edit.aspx.cs" Inherits="Setting_Edit" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="accountInfo">
        <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
        <fieldset class="register">
            <p>
                <asp:Label ID="lblTitle" runat="server" AssociatedControlID="txtTitle">Tiêu đề:</asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="textEntry" ReadOnly="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtTitleRequired" runat="server" ControlToValidate="txtTitle"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblLink" runat="server" AssociatedControlID="txtLink">Nội dung:</asp:Label>
                <asp:TextBox ID="txtLink" runat="server" CssClass="textEntry" TextMode="MultiLine" Height="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtLinkRequired" runat="server" ControlToValidate="txtLink"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" CommandName="Submit" Text="Cập nhật" OnClick="btnSubmit_Click" />
            </p>
        </fieldset>
    </div>
</asp:Content>
