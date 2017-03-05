<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/CMS.master" AutoEventWireup="true" CodeFile="settings.aspx.cs" Inherits="Cms_settings" %>
<%@ Register Src="~/Cms/Control/facebook.ascx" TagPrefix="wuc" TagName="Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <wuc:Settings ID="settings" runat="server" />
</asp:Content>

