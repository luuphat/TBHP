﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Web.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="Web_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <td id="column-center" align="top"  style="padding-top:12px;">
          <div class="column-center-padding">
          <div class="centerColumn" id="indexDefault">
            <div id="indexDefaultMainContent"></div>
            <div class="centerBoxWrapper" id="featuredProducts">
               <h2 class="centerBoxHeading"> TÌM KIẾM </h2>
                <div class="product">
                     <ul>
                         <asp:Repeater ID="rptData" runat="server">
                             <ItemTemplate>
	                            <li>
		                            <div style="padding-top:3px;text-align:center;"><a href="<% = Global.Root %>/Web/ProductDetail.aspx?cid=<%#Eval("CategoryID") %>&id=<%#Eval("NewsID") %>" style="color:red;"><%#Eval("ProductCode") %></a></div>
		                            <p style=" padding-top:-10px">
			                             <a href="<% = Global.Root %>/Web/ProductDetail.aspx?cid=<%#Eval("CategoryID") %>&id=<%#Eval("NewsID") %>">
			                            <img src="<% = Global.Root %><%#Eval("Image") %>"/></a></p>
		                            <p class="title"><a  href="<% = Global.Root %>/Web/ProductDetail.aspx?cid=<%#Eval("CategoryID") %>&id=<%#Eval("NewsID") %>"><%#Eval("Title") %></a></p>
	                            </li>
                             </ItemTemplate>
                          </asp:Repeater>
                     </ul>
                </div>
              <br class="clearBoth"/>            
              <div class="clear"></div>
            </div>
          </div> 
          </div>
      </td>
</asp:Content>

