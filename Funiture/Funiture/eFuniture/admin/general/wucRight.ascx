﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucRight.ascx.cs" Inherits="admin_general_wucRight" %>
<%@ Register Src="~/admin/control/wucStatistic.ascx" TagPrefix="wuc" TagName="Statistics" %>

  <div class="maincontent">
        	<div class="maincontentinner">
            	
                <ul class="maintabmenu">
                	<li class="current"><a href="../admin/Default.aspx">Trang chủ</a></li>
                </ul><!--maintabmenu-->
                
                <div class="content">
                	<ul class="widgetlist">
                    	<li><a href="../admin/Category.aspx" class="events">Danh mục</a></li>
                    	<li><a href="../admin/product.aspx" class="message">Sản phẩm</a></li>
                        <li><a href="../admin/news.aspx" class="upload">Tin tức</a></li>
                    	<li><a href="../admin/content.aspx" class="events">Giới thiệu</a></li>
                    	<li><a href="../admin/setting.aspx" class="message">Cấu hình chung</a></li>
                    </ul>
                    
                    <br clear="all" /><br />
                    
                   <%-- <div class="contenttitle">
                    	<h2 class="chart"><span>Thống kê doanh thu</span></h2>
                    </div><!--contenttitle-->--%>
                    <br />
                    <%--<div id="chartplace2" style="height:300px;"></div>--%>
                </div><!--content-->
            </div><!--maincontentinner-->
        </div><!--maincontent-->
        
        <div class="mainright">
        	<div class="mainrightinner">
            	
                     <div class="widgetbox">
                	<div class="title"><h2 class="tabbed"><span>Lượt xem</span></h2></div>
                    <div class="widgetcontent padding0">
                    	<div id="tabs">
                        	<ul>
                                <li><a href="#tabs-1">Nhiều nhất</a></li>
                                <li><a href="#tabs-2">ít nhất</a></li>
                                
                            </ul>
                            <div id="tabs-1">
                                <ul>
                                    <asp:Repeater ID="rptdatamost" runat="server">
                                        <ItemTemplate>
                                            <li><img src="<% = Global.Root %><%#Eval("Image") %>" alt="" /> <a href="../admin/product_edit.aspx?pid=<%# Eval("NewsID") %>"><%#Eval("Title") %></a> (<%#Eval("CountViews") %>)</li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <div id="tabs-2">
                                <ul >
                                	<asp:Repeater ID="rptdataleast" runat="server">
                                        <ItemTemplate>
                                            <li><img src="<% = Global.Root %><%#Eval("Image") %>" alt="" /> <a href="../admin/product_edit.aspx?pid=<%# Eval("NewsID") %>"><%#Eval("Title") %></a> (<%#Eval("CountViews") %>)</li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                         
                        </div><!--#tabs-->
                    </div><!--widgetcontent-->
                </div><!--widgetbox-->

                <div class="widgetbox">
                	<div class="title"><h2 class="chart"><span>Thống kê lượt truy cập</span></h2></div>
                    <div class="chartbox widgetcontent">
                        <wuc:Statistics ID="statistics" runat="server" />
                    </div><!--widgetcontent-->
                </div>
            </div><!--mainrightinner-->
        </div><!--mainright-->
