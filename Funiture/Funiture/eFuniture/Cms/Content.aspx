<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/CMS.master" AutoEventWireup="true" CodeFile="Content.aspx.cs" Inherits="Cms_Content" %>
<%@ Register Src="~/Cms/Control/wucContents.ascx" TagPrefix="wuc" TagName="Contents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <wuc:Contents ID="contents" runat="server" />   
</asp:Content>

