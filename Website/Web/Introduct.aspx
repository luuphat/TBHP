﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Web.master" AutoEventWireup="true" CodeFile="Introduct.aspx.cs" Inherits="Web_Introduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <td id="column-center" valign="top"><div class="column-center-padding">
            <div class="centerColumn" id="indexDefault">
              <div id="indexDefaultMainContent"></div>
              <div class="centerBoxWrapper" id="featuredProducts">
                <h2 class="centerBoxHeading"><% = _title %> </h2>
                <div class="centerBoxContentsFeatured centeredContent back">
                    <div>
                        <%=_content %>
                    </div>
                </div>
              </div>
            </div>
          </div></td>
</asp:Content>

