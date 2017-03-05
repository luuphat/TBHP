<%@ Page Title="" Language="C#" MasterPageFile="~/admincp/Site.master" AutoEventWireup="true"
    CodeFile="Setting.aspx.cs" Inherits="Setting" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Type" HeaderText="Tiêu đề" />
                <asp:TemplateField HeaderText="Nội dung">
                    <ItemTemplate>
                        <%# Eval("Value") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="setting_edit.aspx?id=<%# Eval("id") %>">
                            <img src="images/icon_edit.png" /></a>
                    </ItemTemplate>
                    <ItemStyle Width="25px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDelete" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm('Bạn có chắc muốn xóa?');"
                            runat="server" ToolTip="Xóa" ImageUrl="images/icon_delete.png"></asp:ImageButton>
                    </ItemTemplate>
                    <ItemStyle Width="25px" HorizontalAlign="Center" />
                </asp:TemplateField>--%>
            </Columns>
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
    </p>
</asp:Content>
