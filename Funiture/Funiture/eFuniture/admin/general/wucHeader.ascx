﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucHeader.ascx.cs" Inherits="admin_general_wucHeader" %>
	<!-- START OF HEADER -->
	<div class="header radius3">
    	<div class="headerinner">
        	
            <a href="../admin/Default.aspx"><img src="images/starlight_admin_template_logo_small.png" alt="" /></a>
            
              
            <div class="headright">
            	<div class="headercolumn">&nbsp;</div>
            	<div id="searchPanel" class="headercolumn">
                <%--	<div class="searchbox">
                        <form action="#" method="post">
                            <input type="text" id="keyword" name="keyword" class="radius2" value="Search here" /> 
                        </form>
                    </div><!--searchbox-->--%>
                </div><!--headercolumn-->
          <%--  	<div id="notiPanel" class="headercolumn">
                    <div class="notiwrapper">
                        <a href="ajax/messages.html" class="notialert radius2">5</a>
                        <div class="notibox">
                            <ul class="tabmenu">
                                <li class="current"><a href="ajax/messages.html" class="msg">Messages (2)</a></li>
                                <li><a href="ajax/activities.html" class="act">Recent Activity (3)</a></li>
                            </ul>
                            <br clear="all" />
                            <div class="loader"><img src="images/loaders/loader3.gif" alt="Loading Icon" /> Loading...</div>
                            <div class="noticontent"></div><!--noticontent-->
                        </div><!--notibox-->
                    </div><!--notiwrapper-->
                </div><!--headercolumn-->--%>
                <div id="userPanel" class="headercolumn">
                    <a href="#" class="userinfo radius2">
                        <img src="images/avatar.png" alt="" class="radius2" />
                        <span><strong><% = Session["UserName"] %></strong></span>
                    </a>
                    <div class="userdrop">
                        <ul>
                          <%--  <li><a href="../../Login/ForgotPassword.aspx">Quên mật khẩu</a></li>--%>
                            <li><a href="../../Login/ChangePass.aspx">Đổi mật khẩu</a></li>
                            <li><a href="../../Login/Login.aspx">Thoát</a></li>
                        </ul>
                    </div><!--userdrop-->
                </div><!--headercolumn-->
            </div><!--headright-->
        
        </div><!--headerinner-->
	</div><!--header-->
    <!-- END OF HEADER -->