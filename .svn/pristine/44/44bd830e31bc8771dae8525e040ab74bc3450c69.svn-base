<%@ Page Title="" Language="C#" MasterPageFile="~/admincp/Site.master" AutoEventWireup="true"
    CodeFile="Product.aspx.cs" Inherits="admincp_Service" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="newsid"
            OnRowDeleting="GridView1_RowDeleting" PageSize="20">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Sản phẩm" />
                 <asp:TemplateField HeaderText="Hình ảnh">
                    <ItemTemplate>
                       <img src="<% = Global.Root %><% =Global.GetConfigKey("Imagesproducts") %><%#Eval("Image") %>" width="70" height="70" align="middle" />
                    </ItemTemplate>
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày đăng">
                    <ItemTemplate>
                        <%# string.Format("{0:dd/MM/yyyy}",Eval("date")) %>
                    </ItemTemplate>
                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="product_edit.aspx?id=<%# Eval("newsid") %>">
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
