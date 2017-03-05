<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/admin.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="admin_news" %>
<%@ Register Src="~/admin/control/wucnews.ascx" TagPrefix="wuc" TagName="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <wuc:News ID="news" runat="server" />
</asp:Content>

