<%@ Page Title="Log In" Language="C#" MasterPageFile="~/admincp/Site.master" AutoEventWireup="true"
    CodeFile="New_Edit.aspx.cs" Inherits="New_Edit" ValidateRequest="false" %>

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
            <p>
                <asp:Label ID="lblDescription" runat="server" AssociatedControlID="txtDescription">Mô tả ngắn:</asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="textEntry"
                    Height="80"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblLink" runat="server" AssociatedControlID="txtDetail">Chi tiết:</asp:Label>
                <textarea id="txtDetail" runat="server" style="width: 100%; height: 400px"></textarea>
            </p>
            <p>
                <asp:Label ID="lblImage" runat="server" AssociatedControlID="uplImage">Hình ảnh:</asp:Label>
                <asp:FileUpload ID="uplImage" runat="server" CssClass="textEntry" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="uplImage"
                    CssClass="message" ErrorMessage="File ảnh không đúng định dạng" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$"></asp:RegularExpressionValidator><asp:HiddenField
                        ID="hdnImage" runat="server" />
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" CommandName="Submit" Text="Cập nhật" OnClick="btnSubmit_Click" />
            </p>
        </fieldset>
    </div>
    <script type="text/javascript" src="scripts/nicEditLoad.js"></script>
</asp:Content>
