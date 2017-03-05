<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/admin.master" AutoEventWireup="true" CodeFile="AdsSlide.aspx.cs" Inherits="admin_AdsSlide" %>
<%@ Register Src="~/admin/control/slidedefault.ascx" TagPrefix="wuc" TagName="Ads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <wuc:Ads ID="ads" runat="server" />
</asp:Content>

