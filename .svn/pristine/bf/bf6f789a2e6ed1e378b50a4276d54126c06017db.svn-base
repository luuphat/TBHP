<%@ Page Title="Log In" Language="C#" MasterPageFile="~/admincp/Site.master" AutoEventWireup="true"
    CodeFile="Upload.aspx.cs" Inherits="Upload" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Upload File
    </h2>
    <div class="accountInfo">
        <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
        <fieldset class="register">
            <p>
                <asp:Label ID="lblImage" runat="server" AssociatedControlID="uplImage">Chọn file :</asp:Label>
                <asp:FileUpload ID="uplImage" runat="server" CssClass="textEntry" />
                <asp:RequiredFieldValidator ID="uplImageRequiredField" runat="server" ControlToValidate="uplImage"
                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" CommandName="Submit" Text="Upload" OnClick="btnSubmit_Click" />
            </p>
        </fieldset>
    </div>
</asp:Content>
