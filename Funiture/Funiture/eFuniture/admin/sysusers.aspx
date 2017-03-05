<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/admin.master" AutoEventWireup="true" CodeFile="sysusers.aspx.cs" Inherits="admin_sysusers" %>
<%@ Register Src="~/admin/control/wucsys_users.ascx" TagPrefix="wuc" TagName="sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <wuc:sys ID="s" runat="server" />
</asp:Content>

