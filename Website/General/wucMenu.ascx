﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucMenu.ascx.cs" Inherits="General_wucMenu" %>
  <td id="column-left" style="width: 228px;">
            <div style="width: 228px;">
                <div id="default-example" data-collapse>
                    <asp:Repeater ID="rptDataTypes" runat="server" OnItemDataBound="rptDataTypes_ItemDataBound">
                        <ItemTemplate>
                              <h1><%#Eval("TypeName") %> </h1>
                                <div class="submenu">
                                    <ul>
                                         <asp:Repeater ID="rptDataCategory" runat="server">
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
                    <div class="box-body">
                        <asp:Repeater ID="rptTopproduct" runat="server">
                            <ItemTemplate>
                                <div class="sideBoxContent product-col-main">
                                    <div class="sale"></div>
                                    <div class="img">
                                        <a href="#">
                                            <img src="../Images/19.jpg" width="197" height="197" /></a><br />
                                    </div>
                                    <div class="prod-info">
                                        <a class="name" href="#"><%#Eval("Title") %></a>
                                        <div class="text">
                                           <%# cutTitle(Eval("Description").ToString(),100) %>
                                        </div>
                                    </div>
                                    <div class="price"><a class="normalprice" href="<% = Global.Root %>/Web/ProductDetail.aspx?id=<%#Eval("NewsID") %>&cid=<%#Eval("CategoryID") %>">Chi tiết >></a></div>
                                    <div class="btns"></div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                       
                    </div>
                </div>
                <div class="box" id="bestsellers" style="width: 230px;">
                    <div class="box-head">Tin Tức</div>
                    <div class="box-body">
                        <div id="bestsellersContent" class="sideBoxContent">
                            <div class="wrapper">
                                <ol>
                                    <asp:Repeater ID="rptTopNews" runat="server">
                                        <ItemTemplate>
                                            <li><span>0<%#Eval("STT").ToString() %></span>
                                                <a class="screenshot" href="<% =Global.Root %>/Web/NewsDetail.aspx?id=<%#Eval("NewsID") %>"><%#Eval("Title") %> </a>
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