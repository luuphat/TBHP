<%@ Page Title="Log In" Language="C#" MasterPageFile="~/admincp/Site.master" AutoEventWireup="true"
    CodeFile="Category_Add.aspx.cs" Inherits="Category_Add" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="accountInfo">
        <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
        <fieldset class="register">
            <p>
                <asp:Label ID="lblCategory" runat="server" AssociatedControlID="ddlCategory">Danh mục:</asp:Label>
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="textEntry">
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="lblTitle" runat="server" AssociatedControlID="txtTitle">Tiêu đề:</asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtTitleRequired" runat="server" ControlToValidate="txtTitle"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblSort" runat="server" AssociatedControlID="txtSort">Thứ tự:</asp:Label>
                <asp:TextBox ID="txtSort" runat="server" CssClass="wtext" onkeypress="isNumeric(event)"
                    Text="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtSortRequired" runat="server" ControlToValidate="txtSort"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:CheckBox ID="chkStatus" Checked="true" runat="server" />
                <asp:Label ID="lblStatus" runat="server" AssociatedControlID="chkStatus" CssClass="inline">Cho phép hiển thị</asp:Label>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" CommandName="Submit" Text="Thêm mới" OnClick="btnSubmit_Click" />
            </p>
        </fieldset>
    </div>
</asp:Content>
