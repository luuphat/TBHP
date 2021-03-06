﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Web.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="Web_ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <td id="column-center" valign="top"><div class="column-center-padding">
          <div class="centerColumn" id="indexDefault">
            <div id="indexDefaultMainContent"></div>
            <div class="centerBoxWrapper" id="featuredProducts">
              <h2 class="centerBoxHeading"><span class="red"> <strong><% = productcode %> </strong></span>- <% = sTitle %> </h2>
               
              <div class="centerBoxContentsFeatured centeredContent back"></div>
              <div class="detail">
                <div  class="detail_left">
                  <%-- <iframe  src="slide.aspx?id=<% = productID %>" width="320" height="330" frameBorder="0" scrolling="no"></iframe>--%>
                    <img src="<% = Global.Root %><% = imgproduct %>" width="330" height="240" />
                </div>
                <div  class="detail_right">                 
                 <%-- <div class="kt">
                    <p><% = description %> </p>
                  </div>--%>
                  <div class="kt">
                      <p style="font-size: 16px"><strong>Mô tả</strong></p>
                       <p><%= content %> </p>
                  </div>
                </div>
              </div>
             
            </div>
          </div>
        </div>
        <div class="column-center-padding">
           <div class="centerColumn" id="Div1">
            <div id="Div2"></div>
            <div class="centerBoxWrapper" id="Div3">
              <h2 class="centerBoxHeading">Sản Phẩm Liên Quan </h2>
             <%--   <asp:Repeater ID="rptRelate" runat="server">
                    <ItemTemplate>
                         <div class="centerBoxContentsFeatured centeredContent back">
                              <div style="height:275px;margin-top:5px;padding-bottom:10px;">
                               <div class="product-col">
                              <div class="img"> <a href="<% = Global.Root %>/Web/ProductDetail.aspx?cid=<%#Eval("CategoryID") %>&id=<%#Eval("NewsID") %>"><img src="<%#Eval("Image") %>" width="150" height="150"/></a></div>
                             
                            </div>
                                <div style="width:150px;padding-left:5px;">
                                   <div class="prod-info1"> <a class="name" href="<% = Global.Root %>/Web/ProductDetail.aspx?cid=<%#Eval("CategoryID") %>&id=<%#Eval("NewsID") %>"><strong><%#Eval("Title") %></strong></a>
                                    <div class="prod-code"><%#Eval("ProductCode") %></div>
                                    <div class="text"><%#Eval("Description") %></div>
                                    <div class="wrapper">
                                      <div class="price"><a href="<% = Global.Root %>/Web/ProductDetail.aspx?cid=<%#Eval("CategoryID") %>&id=<%#Eval("NewsID") %>">Chi tiết ></a></div>
                                    </div>
                                  </div>
                               </div>
                            </div>

                          </div>
                    </ItemTemplate>
                </asp:Repeater>--%>
                 <div class="product">
                        <ul>
                        <asp:Repeater ID="rptRelate" runat="server">
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
                                    <li><p> <a href="<% = Global.Root %>/Web/ProductDetail.aspx?cid=<%#Eval("CategoryID") %>&id=<%#Eval("NewsID") %>"><img src="<% = Global.Root %><%#Eval("Image") %>"/></a></p>
                                     <p class="titlerelate">
                                         <a  href="<% = Global.Root %>/Web/ProductDetail.aspx?cid=<%#Eval("CategoryID") %>&id=<%#Eval("NewsID") %>"><strong><%#Eval("Title") %></strong> </a></br>                                        
                                          <a style="color:red"><%#Eval("ProductCode") %></a>  
                                     </p>
                                    
                                  </li>
                               
                            </ItemTemplate>
                        </asp:Repeater>
                        </ul>
                      </div>

              <br class="clearBoth"/>
            </div>
          </div>
        </div>
      
    
      </td>
    
</asp:Content>

