﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="slide.aspx.cs" Inherits="Web_slide" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/skin.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../js/jquery.galleria.min.js"></script>
   <script type="text/javascript" src="../js/jquery.jcarousel.pack.js"></script>
    <script type="text/javascript" src="../js/tutorial.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<div class="imglarge" align="center"><img src="../Images/img.jpg" /></div>
                    <div class="imgsmall"> <a href=""><img src="../Images/img.jpg" /> </a> <a href=""><img src="../Images/img.jpg" /> </a> <a href=""><img src="../Images/img.jpg" /> </a><a href=""><img src="../Images/img.jpg" /> </a></div>--%>
                      <div id="img"></div>
                            <ul id="gallery" class="jcarousel-skin-tango">               
                                <asp:Repeater ID="rptData" runat="server">
                                    <ItemTemplate>
                                           <li><a href="<%#Eval("Images") %>"><img src="<%#Eval("Images") %>" width="310" height="240" alt="" /></a></li>                                        
                                    </ItemTemplate>
                                </asp:Repeater>
                           
             
                            </ul>
    </div>
    </form>
</body>
</html>
