﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucContent.ascx.cs" Inherits="General_wucContent" %>


        <td id="column-center" valign="top">
            <div class="slider">
                <div class="slider-wrapper theme-default">
                    <div id="slider" class="nivoSlider">
                        <img src="../Images/banner1.jpg" />
                        <img src="../Images/banner2.jpg" /><img src="../Images/banner3.jpg" /></div>
                </div>
            </div>
            <asp:Repeater ID="rptDataTypes" runat="server" OnItemDataBound="rptDataTypes_ItemDataBound">
                <ItemTemplate>
                <div class="column-center-padding">
                <div class="centerColumn" id="Div6">
                    <div id="Div7"></div>
                    <div class="centerBoxWrapper" id="Div8">
                        <h2 class="centerBoxHeading"><%#Eval("TypeName") %> </h2>
                        <asp:Repeater ID="rptDataCategory" runat="server">
                            <ItemTemplate>
                                <div class="centerBoxContentsFeatured centeredContent back">

                                    <div class="product-col">
                                        <div class="img">
                                            <a href="<% = Global.Root %>/Web/Category.aspx?cid=<%#Eval("CategoryID") %>">
                                                <img src="../Images/01.jpg" width="150" height="150" /></a>
                                        </div>
                                        <div class="prod-info">
                                            <div class="wrapper">
                                                <div class="price"><a class="name" href="<% = Global.Root %>/Web/Category.aspx?cid=<%#Eval("CategoryID") %>"><%#Eval("CategoryName") %></a> </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <br class="clearBoth" />
                    <div class="clear"></div>
                </div>
            </div>
                </ItemTemplate>
            </asp:Repeater>
        
        </td>
  
