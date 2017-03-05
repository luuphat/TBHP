﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wuccontent.ascx.cs" Inherits="admin_control_wuccontent" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style>    
  #divmessagesuccess {
       
        text-align:center;
        font-weight:bold;
        margin-top:100px;
        margin-left:40%;
        position:absolute;      
        font-size:12px;font-family: "CenturyGothicRegular", "Century Gothic", Arial, Helvetica, sans-serif;font-weight:bold; 
    }
    .None {
        display:none;
      
    }
    /* popup contetns */

.popupcontents {width:650px; height:450px; border:1px solid #ccc;background-color:#fff; box-shadow:10px 10px inset;box-shadow:1px 1px 5px #dddddd;z-index:-1;
}

    .popupcontents .headercontent {width :97%; border-bottom:1px solid #ddd;padding:10px;height:20px; float:left;}
        .popupcontents .headerdontent .aaa {
            font-size:12px;font-family: "CenturyGothicRegular", "Century Gothic", Arial, Helvetica, sans-serif;font-weight:bold;padding:5px;float:left;
           border:1px solid #000;
        }
        .popupcontents .headercontent .btnclosebt {float:right;width:10%; border:1px solid #000; 
           
        }
            .popupcontents .headercontent .btnclosebt img {border:none;
            }
    .popupcontents .ctcontent {
        float:left;padding:20px;font-size:12px;font-family: "CenturyGothicRegular", "Century Gothic", Arial, Helvetica, sans-serif;line-height:30px;
    }
        .popupcontents .ctcontent .tdcontent {
            width:25%;
        }
        .popupcontents .ctcontent .td1content {
           width:70%;
        }

/* End popup */
            
/*   button */
.btnAdd { width:100px;float:right;padding:0px 5px 0px 5px;margin:0px 10px 0px 0px;}

    .btn:hover {cursor:pointer;color :#5c677c;
    }

.btnOk {
   float:left; border:1px solid #ccc;background-color:none;background-image: url(../images/titlem.png);width:80px;background-repeat: repeat-x;cursor:pointer;font-size:12px;font-family: "CenturyGothicRegular", "Century Gothic", Arial, Helvetica, sans-serif;font-weight:bold;height:20px;margin-top:20px;
   font-size:12px;font-family: "CenturyGothicRegular", "Century Gothic", Arial, Helvetica, sans-serif;
}
    .btnOk:hover {
        background-color:#f2f2f2;cursor:pointer;
    }
.btnOk img{
    border:none;cursor:pointer;padding-top:3px;padding-left:3px;
}
.btnCencal {
   float:left; border:1px solid #ccc;background-color:none;background-image: url(../images/titlem.png);width:80px;background-repeat: repeat-x;cursor:pointer;font-size:12px;font-family: "CenturyGothicRegular", "Century Gothic", Arial, Helvetica, sans-serif;font-weight:bold;height:20px;margin-left:5px;margin-top:20px;
   font-size:12px;font-family: "CenturyGothicRegular", "Century Gothic", Arial, Helvetica, sans-serif;
}
    .btnCencal:hover {
        background-color:#f2f2f2;cursor:pointer;
    }
.btnCencal img{
    border:none;cursor:pointer;padding-top:3px;height:16px;padding-left:3px;
}

.btndefault {
   border:none;background:none;float:right;cursor:pointer;margin-top:2px;
}



/* modal popup */
.modalBackground
{
	z-index:1000 !important;
	background: black;
	filter:alpha(opacity=20);
	opacity: .20;
	-ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=20)"; 
}
.modalPopup
{
	background:#FFFFFF;
	z-index:1001 !important;
}
</style>
<script type="text/javascript">

    function messagesucess() {
        var message = $('#divmessagesuccess');
        message.removeClass('None');
        message.fadeIn(2000);
        message.fadeOut(2000);
    }

</script>

  <div class="maincontent noright">
<div class="maincontentinner">

    <ul class="maintabmenu">
        <li class="current"><a href="#">Nội dung</a></li>
    </ul>
    <!--maintabmenu-->
  <asp:UpdatePanel ID="upContent" runat="server">
      <ContentTemplate>

    <div class="content">

        <div class="contenttitle radiusbottom0">
            <h2 class="table"><span>&nbsp;</span></h2>
        </div>
        <!--contenttitle-->
        <div class="tableoptions">
            <table  style="width:100%;">
                <tr>
                    <td style="width:7%;float:left;"><label>Chuỗi tìm</label></td>
                    <td style="width:30%;float:left;">
                        <span >
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="text1" Width="100%"></asp:TextBox>
                        </span>
                    </td>
                     <td style="width:7%;float:left;margin-left:10px;">
                         <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" CssClass="btn" />                      
                    </td>
                    <td style="float:left;padding-left:200px; padding-bottom:10px; font-size:12px;">
                        Tổng cộng: <asp:Label ID="lblcount" runat="server" ForeColor="Red" ></asp:Label>
                    </td>
                    <td style="width:10%;float:right;padding-right:100px; padding-bottom:10px;">
                         &nbsp;
                    <asp:DropDownList ID="ddlPageSize" runat="server">
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                    </asp:DropDownList>
                &nbsp;
                    </td >
                   <td style="width:10%;margin-right:5px;float:right; padding-bottom:10px;">  <webdiyer:AspNetPager ID="anpPager"   runat="server" PagingButtonSpacing="5px" 
                                                    PagingButtonType="text" CssClass="pager pagging" CurrentPageButtonClass="currentStyle fllf" PrevNextButtonsClass="prevNextStyle fllf" PrevPageText="<" PagingButtonsClass="indexStyle fllf" NextPageText=">" ShowPageIndexBox="Never" NumericButtonCount="5">
                                                </webdiyer:AspNetPager>
                   </td>
                </tr>
            </table>
        </div>
        <!--tableoptions-->
        <table cellpadding="0" cellspacing="0" border="0" id="table1" class="stdtable stdtablecb">
            <colgroup>
                <col class="con0" />
                <col class="con1" />
            </colgroup>
            <thead>
                <tr>
                    <th class="head0">
                         <input type="checkbox"  id="checkboxAll" onclick="javascript: selectAll(this)"  /></th>
                    <th class="head1">Tiêu đề</th>  
                      <th class="head0">Nội dung</th>                      
                </tr>
            </thead>
       
            <tbody>
                <asp:Repeater ID="rptData" runat="server" runat="server" OnItemDataBound="rptData_ItemDataBound" OnItemCommand="rptData_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td class="center">
                                  <input type="checkbox" id="cbxcheck" runat="server" class="selectInstance" /></td>
                            <td><asp:LinkButton ID="lbtUpdate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' CssClass="picker" CommandName="DoUpdate" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'></asp:LinkButton></td>
                            <td><%#cutTitle(Eval("Detail").ToString(),300) %> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
              
             
            </tbody>
        </table>

        <br clear="all" />

    </div>


  <div id="dvmodal" runat="server" />
    <cc1:ModalPopupExtender ID="mdPopup" runat="server" TargetControlID="dvmodal"  CancelControlID="btnCencal" DropShadow="false" RepositionMode="RepositionOnWindowResizeAndScroll"  PopupControlID="ModalPanel" BackgroundCssClass="modalBackground" />
            <asp:Panel ID="ModalPanel" runat="server" CssClass="modalPopup">
               <div class="popupcontents">
                   <div class="headercontent"> <div class="aaa"> <asp:Label ID="lblHandle" runat="server"></asp:Label> </div></div>
                   <div class="ctcontent">
                       <table style="width:100%;">
                           <tr>
                               <td class="td"> Tiêu đề : </td>
                               <td class="td1"> <asp:TextBox ID="txtTitle" Width="500px" runat="server" ValidationGroup="handle"></asp:TextBox> </td>
                               <td><asp:RequiredFieldValidator ID="rqfTypeName" runat="server" ValidationGroup="handle" Display="Dynamic"   ControlToValidate="txtTitle" ValidateRequestMode="Enabled"   ForeColor="Red"  ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
                           </tr>
                            <tr>
                               <td class="td">Chi tiết: </td>
                               <td class="td1">  
                                    <telerik:RadEditor ID="radContents" runat="server" Skin="Office2007" Width="500px" Height="250" ToolsFile="~/RadEditorToolsMail.xml">
                                            <ImageManager MaxUploadFileSize="500000"  ViewPaths="~/uploads/news" UploadPaths="~/uploads/news" DeletePaths="~/uploads/news"/>
                                            <FlashManager MaxUploadFileSize="500000" ViewPaths="~/uploads/news" UploadPaths="~/uploads/news" DeletePaths="~/uploads/news"/>
                                            <DocumentManager MaxUploadFileSize="500000" ViewPaths="~/uploads/news" UploadPaths="~/uploads/news" DeletePaths="~/uploads/news" />
                                            <CssFiles><telerik:EditorCssFile Value="~/Css/EditorStyle.css" /></CssFiles>
                                        </telerik:RadEditor>
                                    <%--<CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>--%>
                               </td>
                            </tr>
                           <tr>
                               <td class="tdcontent"> </td>
                               <td class="td1content"><asp:Label ID="lblmessage" runat="server" ></asp:Label></td>
                           </tr>
                           <tr>
                               <td class="tdcontent"></td>
                               <td class="td1content"><div class="btnOk"><img src="../../images/add.png" align="left"/><asp:Button ID="btnOk" Text="Đồng ý" runat="server" ValidationGroup="handle" CssClass="btndefault" OnClick="btnOk_Click" /></div><div class="btnCencal"> <img src="../../images/quit.png" align="left"/><asp:Button ID="btnCencal" runat="server" Text="Bỏ qua" CssClass="btndefault"  /></div> </td>
                           </tr>
                       </table>
                   </div>
               </div>
            </asp:Panel>

    <!--content-->

</div>
<!--maincontentinner-->


      </ContentTemplate>
  </asp:UpdatePanel>
</div>