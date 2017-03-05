<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/admin.master" AutoEventWireup="true" CodeFile="CreateEditCategory.aspx.cs" Inherits="admin_CreateEditCategory" %>
<%@ Register Src="~/admin/control/wuccreate_edit_category.ascx" TagPrefix="wuc" TagName="createedit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <wuc:createedit ID="CreateEdit" runat="server" />
</asp:Content>

