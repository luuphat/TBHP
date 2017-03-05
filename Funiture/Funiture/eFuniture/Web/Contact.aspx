﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Web.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Web_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <td id="column-center" valign="top" ><div class="column-center-padding">
            <div class="centerColumn" id="indexDefault">
              <div id="indexDefaultMainContent"></div>
              <div class="centerBoxWrapper" id="featuredProducts">
                <h2 class="centerBoxHeading">Liên hệ</h2>
                <div class="centerBoxContentsFeatured centeredContent back"></div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tbcontact" align="center" >
                  <tr>
                    <td width="20%">Tên</td>
                    <td width="65%"><asp:TextBox ID="txtName" runat="server" CssClass="tfcontact"></asp:TextBox></td>
                      <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="handle" Display="Dynamic"   ControlToValidate="txtName" ValidateRequestMode="Enabled"   ForeColor="Red"  ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr>
                    <td>Email</td>
                    <td><asp:TextBox ID="txtEmail" runat="server" CssClass="tfcontact" ></asp:TextBox></td>
                      <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="handle" Display="Dynamic"   ControlToValidate="txtEmail" ValidateRequestMode="Enabled"   ForeColor="Red"  ErrorMessage="(*)"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"  ForeColor="Red" ErrorMessage="(*)"></asp:RegularExpressionValidator>
                      </td>
                  </tr>
                  <tr>
                    <td>Nội dung</td>
                    <td> <asp:TextBox ID="txtcontent" runat="server" TextMode="MultiLine" Height="150px" CssClass="tfarea" ></asp:TextBox></td>
                      <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="handle" Display="Dynamic"   ControlToValidate="txtcontent" ValidateRequestMode="Enabled"   ForeColor="Red"  ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr>
                    <td></td>
                    <td><asp:Button ID="btnSend" runat="server"  Text="Gửi" OnClick="btnSend_Click" ValidationGroup="handle"  class="bt" /> </td>
                  </tr>
                </table>
              </div>
            </div>
          </div></td>
</asp:Content>

