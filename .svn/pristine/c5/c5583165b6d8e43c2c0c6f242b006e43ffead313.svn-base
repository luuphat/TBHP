<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucslide.ascx.cs" Inherits="admin_control_wucslide" %>


<asp:UpdatePanel ID="upPanel" runat="server">
    <ContentTemplate>
   <div class="content"  style="height:500px;margin-left:260px;width:77%;">
                    
                    <div class="contenttitle">
                    	<h2 class="image"><span><% = sTitle %></span></h2>
                    </div><!--contenttitle-->
                      <div></div>
                    <br />
                    <ul class="imagelist">
                        <asp:Repeater ID="rptData" runat="server" OnItemDataBound="rptData_ItemDataBound" OnItemCommand="rptData_ItemCommand">
                            <ItemTemplate>
                                <li>
                                    <img src="<%#Eval("Images") %>" alt="" />
                                    <span><a href="<% = Global.Root %><%#Eval("Images") %> " class="view"></a><%--<a class="delete"></a>--%><asp:ImageButton ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ImageID") %>' CommandName="Delete" OnClientClick="return confirm('Bạn có chắc muốn xóa?');"  runat="server" ToolTip="Xóa"></asp:ImageButton> </span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    	
                     </ul>
                </div><!--content-->
    </div>
  </ContentTemplate>
</asp:UpdatePanel>