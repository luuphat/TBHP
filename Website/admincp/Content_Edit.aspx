<%@ Page Title="Log In" Language="C#" MasterPageFile="~/admincp/Site.master" AutoEventWireup="true"
    CodeFile="Content_Edit.aspx.cs" Inherits="Content_Edit" ValidateRequest="false" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="accountInfo">
        <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
        <fieldset class="register">
            <p>
                <asp:Label ID="lblTitle" runat="server" AssociatedControlID="txtTitle">Tiêu đề:</asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtTitleRequired" runat="server" ControlToValidate="txtTitle"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <p style="display: none">
                <asp:Label ID="lblLink" runat="server" AssociatedControlID="txtLink">Liên kết:</asp:Label>
                <asp:TextBox ID="txtLink" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="LinkRequired" runat="server" ControlToValidate="txtLink"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblDetail" runat="server" AssociatedControlID="txtDetail">Chi tiết:</asp:Label>
                <textarea id="txtDetail" runat="server" style="width: 100%; height: 400px"></textarea>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" CommandName="Submit" Text="Cập nhật" OnClick="btnSubmit_Click" />
            </p>
        </fieldset>
    </div>
    <script type="text/javascript" src="scripts/nicEditLoad.js"></script>
</asp:Content>
