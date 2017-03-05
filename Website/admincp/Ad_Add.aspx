<%@ Page Title="Log In" Language="C#" MasterPageFile="~/admincp/Site.master" AutoEventWireup="true"
    CodeFile="Ad_Add.aspx.cs" Inherits="Ad_Add" %>

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
                <asp:Label ID="lblLink" runat="server" AssociatedControlID="txtLink">Liên kết:</asp:Label>
                <asp:TextBox ID="txtLink" runat="server" CssClass="textEntry" Text="http://"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtLinkRequired" runat="server" ControlToValidate="txtLink"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <table>
                <tr>
                    <td class="right">
                        <asp:Label ID="lblLocation" runat="server" AssociatedControlID="ddlLocation">Vị trí:</asp:Label>
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="wlist">
                            <asp:ListItem Value="left">Left</asp:ListItem>
                            <asp:ListItem Value="top">Top</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblTyle" runat="server" AssociatedControlID="ddlType">Loại banner:</asp:Label>
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="wlist">
                            <asp:ListItem Value="image" Text="Image"></asp:ListItem>
                            <asp:ListItem Value="flash" Text="Flash"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblWidth" runat="server" AssociatedControlID="txtWidth">Chiều rộng:</asp:Label>
                        <asp:TextBox ID="txtWidth" runat="server" CssClass="wtext" onkeypress="isNumeric(event)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtWidthRequired" runat="server" ControlToValidate="txtWidth"
                            CssClass="failureNotification">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblHeight" runat="server" AssociatedControlID="txtHeight">Chiều cao:</asp:Label>
                        <asp:TextBox ID="txtHeight" runat="server" CssClass="wtext" onkeypress="isNumeric(event)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtHeightRequired" runat="server" ControlToValidate="txtHeight"
                            CssClass="failureNotification">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <p>
                <asp:Label ID="lblSort" runat="server" AssociatedControlID="txtSort">Thứ tự:</asp:Label>
                <asp:TextBox ID="txtSort" runat="server" CssClass="wtext" onkeypress="isNumeric(event)"
                    Text="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtSortRequired" runat="server" ControlToValidate="txtSort"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblImage" runat="server" AssociatedControlID="uplImage">Hình ảnh:</asp:Label><asp:Label
                    ID="txtImage" runat="server"></asp:Label>
                <asp:FileUpload ID="uplImage" runat="server" CssClass="textEntry" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="uplImage"
                    CssClass="message" ErrorMessage="File ảnh không đúng định dạng" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP)|(swf)|(SWF))$"></asp:RegularExpressionValidator>
            </p>
            <p>
                <asp:CheckBox ID="chkStatus" Checked="true" runat="server" />
                <asp:Label ID="lblStatus" runat="server" AssociatedControlID="chkStatus" CssClass="inline">Cho phép hiển thị</asp:Label>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" CommandName="Submit" Text="Cập nhật" OnClick="btnSubmit_Click" />
            </p>
        </fieldset>
    </div>
</asp:Content>
