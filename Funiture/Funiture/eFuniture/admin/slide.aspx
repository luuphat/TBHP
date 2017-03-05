<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/admin.master" AutoEventWireup="true" CodeFile="slide.aspx.cs" Inherits="admin_slide" %>
<%@ Register Src="~/admin/control/wucslide.ascx" TagPrefix="wuc" TagName="Slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <wuc:Slide ID="slideimage" runat="server" />
</asp:Content>

