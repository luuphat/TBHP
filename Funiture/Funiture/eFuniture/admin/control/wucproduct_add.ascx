﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucproduct_add.ascx.cs" Inherits="admin_control_wucproduct_add" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<style>
    .rad {
        margin-left:220px;
    }
</style>


  <div class="maincontent noright">
<div class="maincontentinner">
    <ul class="maintabmenu multipletabmenu">
        <li class="current"><a href="#">Danh mục</a></li>
      
    </ul>
    <!--maintabmenu-->

    <div class="content">

        <div class="contenttitle">
            <h2 class="form"><span><asp:Label ID="lblHandleTitle" runat="server"></asp:Label> </span></h2>
        </div>
        <!--contenttitle-->

        <br />
         <div style="float:right;margin:30px 100px 0px 0px;" ><asp:Image ID="imgImages" runat="server" Height="150px" Width="150px" /></div>
        <div class="stdform">
             <p>
                <label>Chủ đề cha</label>
                <span class="field">                   
                    <asp:DropDownList ID="ddlCategory" runat="server" class="dualselect "></asp:DropDownList>
                </span>
            </p>
             <p>
                <label>Tiêu đề</label>
                <span class="field">
                    <asp:TextBox ID="txtTitle" runat="server" class="smallinput"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="rqfTitle" runat="server" ValidationGroup="handle" Display="Dynamic"   ControlToValidate="txtTitle"   ForeColor="Red"  ErrorMessage="(*)"></asp:RequiredFieldValidator>                  
                </span>
            </p>
             <p>
                <label>Mã sản phẩm</label>
                <span class="field">
                    <asp:TextBox ID="txtProductCode" runat="server" class="smallinput"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="handle" Display="Dynamic"   ControlToValidate="txtTitle"   ForeColor="Red"  ErrorMessage="(*)"></asp:RequiredFieldValidator>                  
                </span>
            </p>
             <p>
                <label>Mô tả ngắn </label>
                <span class="field">
                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="50" runat="server" class="smallinput"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="handle" Display="Dynamic"   ControlToValidate="txtDescription"   ForeColor="Red"  ErrorMessage="(*)"></asp:RequiredFieldValidator>                  
                </span>
            </p>
             <p>
                <label>Ảnh sản phẩm</label>
                <span class="field">                   
                     <asp:FileUpload ID="uplImage" runat="server" CssClass="textEntry" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="uplImage"
                                                    CssClass="message" ErrorMessage="File ảnh không đúng định dạng" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$"></asp:RegularExpressionValidator><asp:HiddenField
                                                        ID="hdnImage" runat="server" />
                </span>
            </p>
            
             <div>

                <label>Chi tiết</label>                
                
                 <telerik:RadEditor ID="radContents" runat="server" Skin="Office2007" Width="500px" Height="250" CssClass="rad" ToolsFile="~/RadEditorToolsMail.xml">
                                            <ImageManager MaxUploadFileSize="500000"  ViewPaths="~/uploads/news" UploadPaths="~/uploads/news" DeletePaths="~/uploads/news"/>
                                            <FlashManager MaxUploadFileSize="500000" ViewPaths="~/uploads/news" UploadPaths="~/uploads/news" DeletePaths="~/uploads/news"/>
                                            <DocumentManager MaxUploadFileSize="500000" ViewPaths="~/uploads/news" UploadPaths="~/uploads/news" DeletePaths="~/uploads/news" />
                                            <CssFiles><telerik:EditorCssFile Value="~/Css/EditorStyle.css" /></CssFiles>
                                        </telerik:RadEditor>
                
            </div>
            <p>
                <label>Mới nhất</label>
                <span class="field">                   
                    <asp:CheckBox ID="cbkMostSale" runat="server" />
                </span>
            </p>
            
             <p>
                <label></label>
                <span class="field">
                   <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                </span>
            </p>      
            <p>    
                  <label>&nbsp</label>
                  <span class="field">
                <asp:Button ID="btnOk" runat="server" CssClass="submit radius2"  Text="Đồng ý" OnClick="btnOk_Click" />
                <a href="#"><asp:Button ID="btnExit" runat="server" CssClass="reset radius2" Text="Bỏ qua" OnClick="btnReset_Click" /></a> 
                      </span>
            </p>     
        </div>
    </div>
    <!--content-->

</div>
</div>
<!--maincontentinner-->


<!--footer-->