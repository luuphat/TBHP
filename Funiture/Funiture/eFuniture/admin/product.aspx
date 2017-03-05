<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/admin.master" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="admin_product" %>
<%@ Register Src="~/admin/control/wucproduct.ascx" TagPrefix="wuc" TagName="Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <wuc:Product ID="product" runat="server" />
</asp:Content>

