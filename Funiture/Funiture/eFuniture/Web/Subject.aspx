﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Web.master" AutoEventWireup="true" CodeFile="Subject.aspx.cs" Inherits="Web_Subject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <td id="column-center" valign="top"  ><div class="column-center-padding">
            <div class="centerColumn" id="indexDefault">
              <div id="indexDefaultMainContent"></div>
              <div class="centerBoxWrapper" id="featuredProducts">
                <h2 class="centerBoxHeading">Tin Tức</h2>
                <div class="centerBoxContentsFeatured centeredContent back"></div>
                  <div id="contentlistnews">
                      <asp:Repeater ID="rptData" runat="server">
                          <ItemTemplate>
                               <div class="listnews">
                                  <a href="<% =Global.Root %>/Web/NewsDetail.aspx?id=<%#Eval("NewsID") %>">
                                      <img src="<%#Eval("Image") %>" align="left" width="150" height="120" /></a>
                                  <p class="titlelistnews"><a href="<% =Global.Root %>/Web/NewsDetail.aspx?id=<%#Eval("NewsID") %>"> <%#Eval("Title") %></a></p>
                                  <p><%#Eval("Description") %> </p>
                              </div>
                          </ItemTemplate>
                      </asp:Repeater>
                     
                  </div>
              </div>
            </div>
          </div></td>

</asp:Content>
