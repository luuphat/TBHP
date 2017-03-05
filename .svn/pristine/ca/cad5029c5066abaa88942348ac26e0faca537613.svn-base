<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucMenu.ascx.cs" Inherits="General_wucMenu" %>
  <td id="column-left" style="width: 228px;">
            <div style="width: 228px;">
                <div class="box-head">SẢN PHẨM</div>
                <div id="default-example" data-collapse>
               
                    <asp:Repeater ID="rptParent" runat="server"  OnItemDataBound="rptParent_ItemDataBound">
                        <ItemTemplate>
                              <h1><%#Eval("CategoryName") %> </h1>
                                <div class="submenu">
                                    <ul>
                                         <asp:Repeater ID="rptsub" runat="server">
                                             <ItemTemplate>
                                                  <li><a href="<% = Global.Root %>/Web/Category.aspx?cid=<%#Eval("CategoryID") %>"><%#Eval("CategoryName") %></a> </li>
                                             </ItemTemplate>
                                         </asp:Repeater>
                                    </ul>
                                </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="box" id="specials" style="width: 230px;">
                    <div class="box-head"><a href="#">Sản Phẩm Mới</a> </div>
                    <div class="box-spmoi">
                       <%-- <asp:Repeater ID="rptTopproduct1" runat="server">
                            <ItemTemplate>
                                <div class="sideBoxContent product-col-main">
                                    <div class="sale"></div>
                                    <div class="img">
                                        <a href="<% = Global.Root %>/Web/ProductDetail.aspx?id=<%#Eval("NewsID") %>&cid=<%#Eval("CategoryID") %>">
                                            <img src="<% = Global.Root %><%#Eval("Image") %>" width="197" height="197" /></a><br />
                                    </div>
                                    <div class="prod-info">
                                        <a class="name" href="<% = Global.Root %>/Web/ProductDetail.aspx?id=<%#Eval("NewsID") %>&cid=<%#Eval("CategoryID") %>"> <%#Eval("Title") %></a>
                                        <div class="text">
                                           <%# cutTitle(Eval("Description").ToString(),100) %>
                                        </div>
                                    </div>
                                    <div class="price"><a class="normalprice" href="<% = Global.Root %>/Web/ProductDetail.aspx?id=<%#Eval("NewsID") %>&cid=<%#Eval("CategoryID") %>">Chi tiết >></a></div>
                                    <div class="btns"></div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>--%>
                        <ul>
                            <asp:Repeater ID="rptTopproduct" runat="server">
                                <ItemTemplate>
                                    <li><a href="<% = Global.Root %>/Web/ProductDetail.aspx?id=<%#Eval("NewsID") %>&cid=<%#Eval("CategoryID") %>">
                                        <img src="<% = Global.Root %><%#Eval("Image") %>" width="197" height="197" align="left" /></a><a href="<% = Global.Root %>/Web/ProductDetail.aspx?id=<%#Eval("NewsID") %>&cid=<%#Eval("CategoryID") %>"><%# cutTitle(Eval("Description").ToString(),100) %></a></li>
                                    <%--   <li><a  href="#"><img src="images/02.jpg" align="left" > </a> <a href="#">Thùng rác chim cánh cụt</a></li> --%>
                                </ItemTemplate>
                            </asp:Repeater>
                     </ul>
                    </div>
                </div>
                <div class="box" id="bestsellers" style="width: 230px;">
                    <div class="box-head"> <a href="#">Tin Tức</a> </div>
                    <div class="box-body">
                        <div id="bestsellersContent" class="sideBoxContent">
                            <div class="wrapper">
                                <ol>
                                    <asp:Repeater ID="rptTopNews" runat="server">
                                        <ItemTemplate>
                                            <li><span>0<%#Eval("STT").ToString() %></span>
                                                <a class="screenshot" href="<% =Global.Root %>/Web/NewsDetail.aspx?id=<%#Eval("NewsID") %>"> <%#Eval("Title") %></a>
                                            </li>                                            
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ol>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </td>