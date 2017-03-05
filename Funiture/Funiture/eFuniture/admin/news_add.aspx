<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/admin.master" AutoEventWireup="true" CodeFile="news_add.aspx.cs" Inherits="admin_news_add" %>
<%@ Register Src="~/admin/control/wucnews_add.ascx" TagPrefix="wcu" TagName="newsadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <wcu:newsadd ID="news" runat="server" />
</asp:Content>

