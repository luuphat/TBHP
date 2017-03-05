<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Web.master" AutoEventWireup="true" CodeFile="NewsDetail.aspx.cs" Inherits="Web_NewsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <td id="column-center" valign="top"><div class="column-center-padding">
            <div class="centerColumn" id="indexDefault">
              <div id="indexDefaultMainContent"></div>
              <div class="centerBoxWrapper" id="featuredProducts">
                <h2 class="centerBoxHeading">Chi tiết</h2>
                <div class="centerBoxContentsFeatured centeredContent back">
                    <div style="font-size:20px;font-weight:bold;color:#f00;margin:0px 0px 10px 10px;" ><% = _title %> </div>
                    <div style="margin:0px 0px 10px 5px">
                        <%=_content %>
                    </div>
                </div>
              </div>
            </div>
          </div></td>
</asp:Content>

