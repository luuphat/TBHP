﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucContent.ascx.cs" Inherits="General_wucContent" %>


        <td id="column-center" valign="top">
            <div class="slider">
                <div class="slider-wrapper theme-default">
                    <div id="slider" class="nivoSlider">
                        <%--<img src="../Images/banner1.jpg" />
                        <img src="../Images/banner2.jpg" />
                        <img src="../Images/banner3.jpg" />--%>
                        <asp:Repeater ID="rptslide" runat="server">
                            <ItemTemplate>
                              <a href="#"><img src="<% =Global.Root %><%#Eval("Images") %>"  width="710" height="344" /></a>  
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <asp:Repeater ID="rptParent" runat="server" OnItemDataBound="rptParent_ItemDataBound">
                <ItemTemplate>
                <div class="column-center-padding">
                 <div class="centerColumn" id="indexDefault">
                   <div id="indexDefaultMainContent"></div>
                    <div class="centerBoxWrapper" id="featuredProducts">
                        <h2 class="centerBoxHeading"><%#Eval("CategoryName") %> </h2>
                        <div class="product">
                        <ul>
                        <asp:Repeater ID="rptsub" runat="server">
                            <ItemTemplate>
                               <%-- <div class="centerBoxContentsFeatured centeredContent back">
                                    <div class="product">
                                        <div class="img">
                                            <a href="<% = Global.Root %>/Web/Category.aspx?cid=<%#Eval("CategoryID") %>">
                                                <img src="<% = Global.Root %><%#Eval("Images") %>" width="150" height="150" /></a>
                                        </div>
                                        <div class="prod-info">
                                            <div class="wrapper">
                                                <div class="price"><a class="name" href="<% = Global.Root %>/Web/Category.aspx?cid=<%#Eval("CategoryID") %>"><%#Eval("CategoryName") %></a> </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                                    <li><p> <a href="<% = Global.Root %>/Web/Category.aspx?cid=<%#Eval("CategoryID") %>"><img src="<% = Global.Root %><%#Eval("Images") %>"/></a></p>
                                     <p class="title"><a  href="<% = Global.Root %>/Web/Category.aspx?cid=<%#Eval("CategoryID") %>"><%#Eval("CategoryName") %></a></p>
                                  </li>
                               
                            </ItemTemplate>
                        </asp:Repeater>
                        </ul>
                      </div>
                    </div>

                    <br class="clearBoth" />
                    <div class="clear"></div>
                </div>
            </div>
                </ItemTemplate>
            </asp:Repeater>
        
        </td>
  
