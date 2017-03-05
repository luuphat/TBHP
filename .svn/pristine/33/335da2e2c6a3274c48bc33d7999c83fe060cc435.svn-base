<%@ Page Title="" Language="C#" MasterPageFile="~/admincp/Site.master" AutoEventWireup="true"
    CodeFile="Type.aspx.cs" Inherits="Type" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
    <p>
        <asp:GridView ID="GridView1" runat="server" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
            DataKeyNames="typeid" OnRowDeleting="GridView1_RowDeleting" 
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TypeName" HeaderText="Tiêu đề" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="type_edit.aspx?id=<%# Eval("typeid") %>">
                            <img src="images/icon_edit.png" /></a>
                    </ItemTemplate>
                    <ItemStyle Width="25px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDelete" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm('Bạn có chắc muốn xóa?');"
                            runat="server" ToolTip="Xóa" ImageUrl="images/icon_delete.png"></asp:ImageButton>
                    </ItemTemplate>
                    <ItemStyle Width="25px" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
    </p>
</asp:Content>
