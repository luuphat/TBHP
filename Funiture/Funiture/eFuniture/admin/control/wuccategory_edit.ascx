﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wuccategory_edit.ascx.cs" Inherits="admin_control_wuccategory_edit" %>



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
                <label>Tiêu đề</label>
                <span class="field">
                    <asp:TextBox ID="txtTitle" runat="server" class="smallinput"></asp:TextBox>                    
                </span>
            </p>

            <p>
                <label>Chủ đề cha</label>
                <span class="field">                   
                    <asp:DropDownList ID="ddlParentName" runat="server" class="dualselect "></asp:DropDownList>
                </span>
            </p>
            <p>
                <label>Thứ tự</label>
                <span class="field">
                    <asp:TextBox ID="txtRandID" runat="server" class="smallinput"></asp:TextBox>    
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="handle" Display="Dynamic"   ControlToValidate="txtRandID"   ForeColor="Red"  ErrorMessage="(*)"></asp:RequiredFieldValidator>                                  
                     <asp:CompareValidator ID="rqfRand" runat="server" ControlToValidate="txtRandID" Type="Integer"  ValidationGroup="handle" Display="Dynamic"   Operator="DataTypeCheck" ErrorMessage="(*)" ForeColor="Red" />
                </span>
            </p>
            <p>
                <label>Ảnh đại diện</label>
                <span class="field">                   
                     <asp:FileUpload ID="uplImage" runat="server" CssClass="textEntry" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="uplImage"
                                                    CssClass="message" ErrorMessage="File ảnh không đúng định dạng" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$"></asp:RegularExpressionValidator><asp:HiddenField
                                                        ID="hdnImage" runat="server" />
                </span>
            </p>          
            <p>
                <label>Kích hoạt</label>
                <span class="field">
                    <asp:CheckBox ID="cbkIsActived" runat="server" />
                </span>
            </p>
             <p>
                <label></label>
                <span class="field">
                   <asp:Label ID="lblMessage" runat="server"></asp:Label>
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
