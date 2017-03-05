<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/admin.master" AutoEventWireup="true" CodeFile="size.aspx.cs" Inherits="admin_size" %>
<%@ Register Src="~/admin/control/wucsize.ascx" TagPrefix="wuc" TagName="Size" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <wuc:Size ID="size" runat="server" />
</asp:Content>

