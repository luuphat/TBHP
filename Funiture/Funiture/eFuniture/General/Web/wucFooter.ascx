﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucFooter.ascx.cs" Inherits="General_wucFooter" %>
<div id="footer">
    <div class="extra">
        <div class="main-width">
            <div class="thongtin">
                <ul>
                    <asp:Repeater ID="rptFooter" runat="server">
                        <ItemTemplate>
                            <li>
                               <div class="thongtintt">
                                 <img src='<% = Global.Root %><%#Eval("Image") %>' height="40" width="40" align="absmiddle" /> <%#Eval("Title") %> 
                                </div> 
                                <div style="text-align:left;">
                                    <p><%#Eval("Description") %> </p>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                  
                 <%--   <li>
                        <div class="thongtintt">
                            <img src="../images/iconphone.png" align="absmiddle" />Điện thoại: </div>
                        <div>
                            <p>
                                <strong>Phone: </strong>08.62 64 61 31 - 08.22 36 96 74 </br>
                                <strong>Tel: </strong>0908 18 76 28 - 0907 84 37 46 </br>
                                <strong>Fax: </strong>08.62 64 61 31
                            </p>
                        </div>

                    </li>
                    <li>
                        <div class="thongtintt">
                            <img src="../images/icontt.png" align="absmiddle" />THÔNG TIN THANH TOÁN</div>
                        <div>
                            <p>
                                ST: 1701893748</br>
STK: 011060320001</br>
Ngân hàng Đông Á (DAB), nhánh  Quận 10, TP. Hồ Chí Minh
                            </p>
                        </div>

                    </li>--%>

                </ul>
            </div>

            <div class="wrapper">
                <div class="footer-menu">
                    <div id="navSupp"></div>
                </div>
            <%--    <div class="copyright">
                    <p>
                       <%= _footer %>
                    </p>
                </div>--%>

            </div>
        </div>
    </div>
</div>
