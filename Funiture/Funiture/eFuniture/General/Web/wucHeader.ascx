﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucHeader.ascx.cs" Inherits="General_wucHeader" %>
  <div id="header">
            <div class="logo"> <a href="http://beta.thietbihongphuc.com/"><img src="../images/logo.png"  /> </a></div>
            <div class="menu">
              <div id="">
                <ul>
                      <li class="selected  first"> <a href="../Default.aspx"> <span class="corner"></span> <span> <span>Trang chủ</span></span></a></li>
                      <li class=""> <a href="../Web/Introduct.aspx"><span> <span>Giới thiệu</span> </span> </a> </li>
                      <li class=""> <a href="../../Web/Subject.aspx"> <span class="corner"></span> <span> <span>Tin tức</span> </span> </a> </li>
                      <li class=""> <a href="../Web/Contact.aspx"> <span class="corner"></span> <span> <span>Liên hệ</span> </span> </a> </li>
                    </ul>
              </div>
            </div>
           <div class="phone"> <a class="st1" href="#"><span>0908187628</span></a></div>
            <div class="social">
              <ul>
                <li><a href="http://www.facebook.com"><img src="../images/facebook.png" alt="" width="30" height="30"/></a></li>
                <li><a href="http://www.twitter.com"><img src="../images/twitter.png" alt="" width="30" height="30"/></a></li>
              </ul>
            </div>
             <div id="head-search">
             <%--  <input name="" type="button" class="btsearch" />--%>
                 <asp:Button ID="btnsearch" runat="server" CssClass="btsearch" OnClick="btnsearch_Click" />
                  <%--<input type="text" name="keyword" size="18" class="input1" maxlength="100" style="width: -30px"/>--%>
                 <asp:TextBox ID="txtsearch" runat="server" size="18" class="input1" maxlength="100" style="width: -30px"></asp:TextBox>
            </div>
          </div>

