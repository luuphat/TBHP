<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucContents.ascx.cs" Inherits="Cms_Control_wucContents" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

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
</style>
<script type="text/javascript">

    function messagesucess() {
        var message = $('#divmessagesuccess');
        message.removeClass('None');
        message.fadeIn(2000);
        message.fadeOut(2000);
    }

</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    
<div id="center">
    <div class="titlecenter">
         <img src="../../Images/calender.png" width="16" height="16" align="left" />
        <div class="infocenter"> THỂ LOẠI  </div>   
         <div class="btnAdd"><asp:Button ID="btnAdd" runat="server" Text="Thêm mới" CssClass="btn" OnClick="btnAdd_Click" /> </div>
    </div>
   
     <div class="linecenter">____________________________________________________________________________</div>
    <div>
        <div id="content">
        <div class="divtableheader">
            <div class="tableheader" > Tên thể loại </div>
        </div>
         <asp:Repeater ID="rptData" runat="server"  OnItemDataBound="rptData_ItemDataBound" OnItemCommand="rptData_ItemCommand">
             <ItemTemplate>
                 <div class="news">
                     <p class="titlenews"><asp:LinkButton ID="lbtUpdate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>' CssClass="picker" CommandName="DoUpdate" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'></asp:LinkButton></p>                                  
                     <div class="divedit">
                         <a href ="#"><div class="editnews"><asp:LinkButton ID="lbtEdit" runat="server" Text="Sửa" CommandName="DoUpdate" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'></asp:LinkButton> </div></a> 
                         |  <a href ="#"><div class="deletenews"><asp:LinkButton ID="lbtDeleted" runat="server" Text="Xóa" CommandName="DoDeteled" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'></asp:LinkButton> </div></a> 
                     </div>
                 </div>
             </ItemTemplate>
         </asp:Repeater>
       
       <div class="footnews">
           <ul class="paging">
            <li class="subpaging"><asp:Label ID="lblCount" runat="server" ></asp:Label> </li>         
           <li class="subpaging">PageSize:
            <asp:DropDownList ID="ddlPageSize" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                 <asp:ListItem Text="10" Value="10"></asp:ListItem>
                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                <asp:ListItem Text="50" Value="50"></asp:ListItem>
            </asp:DropDownList>
           </li>
           <li class="subpaging">
               <webdiyer:aspnetpager id="anpPager" runat="server" pagingbuttonspacing="5px" onpagechanged="anpPager_PageChanged"
                   pagingbuttontype="text" cssclass="pager" currentpagebuttonclass="currentStyle fllf" prevnextbuttonsclass="prevNextStyle fllf" prevpagetext="<" pagingbuttonsclass="indexStyle fllf" nextpagetext=">" showpageindexbox="Never" numericbuttoncount="5">
            </webdiyer:aspnetpager>

           </li>
          </ul>
           <%--<a href="#" ><p>Xem nhiều hơn [.....] </p></a> --%>
       </div>
    </div>
    </div>
</div>

<div>
     <div id="dvmodal" runat="server" />
    <cc1:ModalPopupExtender ID="mdPopup" runat="server" TargetControlID="dvmodal"  CancelControlID="btnCencal" DropShadow="false" RepositionMode="RepositionOnWindowResizeAndScroll"  PopupControlID="ModalPanel" BackgroundCssClass="modalBackground" />
            <asp:Panel ID="ModalPanel" runat="server" CssClass="modalPopup">
               <div class="popupcontents">
                   <div class="header"> <div class="title"> <asp:Label ID="lblHandle" runat="server"></asp:Label> </div><div class="btnclose"><img src="../../images/close.gif" align="right" /> </div></div>
                   <div class="content">
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
                               <td class="td"> </td>
                               <td class="td1"><asp:Label ID="lblmessage" runat="server" ></asp:Label></td>
                           </tr>
                           <tr>
                               <td class="td"></td>
                               <td class="td1"><div class="btnOk"><img src="../../images/add.png" align="left"/><asp:Button ID="btnOk" Text="Đồng ý" runat="server" ValidationGroup="handle" CssClass="btndefault" OnClick="btnOk_Click" /></div><div class="btnCencal"> <img src="../../images/quit.png" align="left"/><asp:Button ID="btnCencal" runat="server" Text="Bỏ qua" CssClass="btndefault"  /></div> </td>
                           </tr>
                       </table>
                   </div>
               </div>
            </asp:Panel>
</div>


 <div id="dvDeleted" runat="server" />
    <cc1:ModalPopupExtender ID="mpdeleted" runat="server" TargetControlID="dvDeleted"  DropShadow="false" RepositionMode="RepositionOnWindowResizeAndScroll"  PopupControlID="pDeleted" BackgroundCssClass="modalBackground" />
            <asp:Panel ID="pDeleted" runat="server">
               <div class="popupDeleted">
                   <div class="header"> <div class="title"> Thông báo </div><div class="btnclose"><img src="../../images/close.gif" align="right" /> </div></div>
                   <div class="content">
                       <table style="width:100%;">                           
                           <tr>
                               <td class="td"> </td>
                               <td class="td1">Bạn có muốn xóa không ? </td>
                           </tr>
                           <tr>
                               <td class="td"></td>
                               <td class="td1"><div class="btnOk"><img src="../../images/add.png" align="left"/><asp:Button ID="btnDeleted" Text="Đồng ý" runat="server" CssClass="btndefault" OnClick="btnDeleted_Click" /></div><div class="btnCencal"> <img src="../../images/quit.png" align="left"/><asp:Button ID="btnExist" runat="server" Text="Bỏ qua" CssClass="btndefault"  /></div> </td>
                           </tr>
                       </table>
                   </div>
               </div>
            </asp:Panel>

<div id="divmessagesuccess" class="None">
    <div><img src="../../Images/sucess.png" style="margin-right:10px" /><span>Cập nhập thành công </span> </div>
</div>
        </ContentTemplate>
</asp:UpdatePanel>
