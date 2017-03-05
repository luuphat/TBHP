<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/CMS.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="Cms_News" %>
<%@ Register Src="~/Cms/Control/wucNews.ascx" TagPrefix="wuc" TagName="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <wuc:News ID="news" runat="server" />
</asp:Content>

