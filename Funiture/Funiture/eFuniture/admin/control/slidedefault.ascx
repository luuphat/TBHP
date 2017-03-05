<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slidedefault.ascx.cs" Inherits="admin_control_slidedefault" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<style>
 
.popupSlide {width:400px; height:260px; border:1px solid #ccc;background-color:#fff; box-shadow:10px 10px inset;box-shadow:1px 1px 5px #dddddd;
}
 .popupSlide .headerpopup {width :95%; border-bottom:1px solid #ddd;padding:10px;height:20px; float:left;}
        .popupSlide .headerpopup .titlepopup {
            font-size:12px;font-family: "CenturyGothicRegular", "Century Gothic", Arial, Helvetica, sans-serif;font-weight:bold;padding:5px;width:50%;float:left;
        }
        .popupSlide .headerpopup .btnclose {
            float:right;width:10%;
        }
            .popupSlide .headerpopup .btnclose img {border:none;
            }
    .popupSlide .contentpopup {
        float:left;padding:10px;font-size:12px;font-family: "CenturyGothicRegular", "Century Gothic", Arial, Helvetica, sans-serif;line-height:10px;width:95%;height:200px;overflow:scroll;
    }
        .popupSlide .contentpopup .tdpopup {
            width:20%;
        }
        .popupSlide .contentpopup .td1popup {
           width:70%;
        }
             
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
   border:none;background:none;float:right;cursor:pointer;
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

<asp:UpdatePanel ID="upPanel" runat="server">
    <ContentTemplate>
    
   <div class="content" style="height:500px;margin-left:260px;width:77%;">
                    <div class="contenttitle">
                    	<h2 class="image"><span><% = sTitle %></span></h2>
                    </div><!--contenttitle-->
         <br />
          <ul class="buttonlist">
                        <li><asp:Button ID="btnAdd" runat="server" CssClass="stdbtn btn_blue" Text="Thêm ảnh" OnClick="btnAdd_Click" /> </li>
                   </ul>
                    <br />
                    <ul class="imagelist">
                        <asp:Repeater ID="rptData" runat="server" OnItemDataBound="rptData_ItemDataBound" OnItemCommand="rptData_ItemCommand">
                            <ItemTemplate>
                                <li>
                                    <img src="<%#Eval("Images") %>" width="250" height="150" alt="" />
                                    <span><a href="<% = Global.Root %><%#Eval("Images") %> " class="view"></a><%--<a class="delete"></a>--%><asp:ImageButton ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ImagesID") %>' CommandName="Delete" OnClientClick="return confirm('Bạn có chắc muốn xóa?');"  runat="server" ToolTip="Xóa"></asp:ImageButton> 
                                        <asp:ImageButton ID="ibtUpdated" ImageUrl="~/images/edit.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ImagesID") %>' CommandName="DoUpdated"  runat="server" ToolTip="Sửa"></asp:ImageButton> 

                                    </span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    	
                     </ul>
                </div><!--content-->
         <div id="dvUpload" runat="server" />
    <cc1:ModalPopupExtender ID="mpUpload" runat="server" TargetControlID="dvUpload"  DropShadow="false" RepositionMode="RepositionOnWindowResizeAndScroll" CancelControlID="btnCloseUpload"  PopupControlID="pUpload" BackgroundCssClass="modalBackground" />
            <asp:Panel ID="pUpload" runat="server" Height="300px">
               <div class="popupSlide">
                   <div class="headerpopup"> <div class="titlepopup">Upload silde ảnh </div><%--<div class="btnclose"><img src="../../images/close1.gif" align="right" /> </div>--%></div>
                   <div class="contentpopup">
                       <table style="width:100%;">                           
                           <tr>
                               <td> Ảnh :</td>
                               <td class="td1">
                                   <div id="fileUploadarea">
                                       <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="Solid" BorderColor="Gray" /><br />
                                   </div>
                                 <%--   <div>
                                               <input style="display: block;" id="btnAddMoreImages" type="button" value="Thêm ảnh" onclick="AddMoreImages();" />
                                    </div>--%>
                                   
                                  
                               </td>
                           </tr>
                           <tr>
                               <td> Link:  </td>
                               <td><asp:TextBox ID="txtlinks" runat="server" Width="250"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td> Tab:</td>
                               <td> <asp:DropDownList ID="ddltabs" runat="server">
                                           <asp:ListItem Selected="True" Value="_parent" Text="Link trang mới"></asp:ListItem>
                                           <asp:ListItem Value="_blank" Text="Link trong trang"></asp:ListItem>
                                       </asp:DropDownList>
                                   
                               </td>
                           </tr>
                           <tr>
                               <td class="tdpopup"></td>
                               <td class="td1popup"><div class="btnOk"><img src="../../images/add.png" align="left"/><asp:Button ID="btnUpload" Text="Upload" runat="server" CssClass="btndefault" OnClick="btnUpload_Click" /></div><div class="btnCencal"> <img src="../../images/quit.png" align="left"/><asp:Button ID="btnCloseUpload" runat="server" Text="Bỏ qua" CssClass="btndefault"  /></div> </td>
                           </tr>
                       </table>
                   </div>
               </div>
            </asp:Panel>

 <script language="javascript" type="text/javascript">
     function AddMoreImages() {

         if (!document.getElementById && !document.createElement)
             return false;
         var fileUploadarea = document.getElementById("fileUploadarea");
         if (!fileUploadarea)
             return false;
         var newLine = document.createElement("br");
         fileUploadarea.appendChild(newLine);
         var newFile = document.createElement("input");
         newFile.type = "file";
         newFile.setAttribute("class", "fileUpload");
         if (!AddMoreImages.lastAssignedId)
             AddMoreImages.lastAssignedId = 100;
         newFile.setAttribute("id", "FileUpload" + AddMoreImages.lastAssignedId);
         newFile.setAttribute("name", "FileUpload" + AddMoreImages.lastAssignedId);
         var div = document.createElement("div");
         div.appendChild(newFile);
         div.setAttribute("id", "div" + AddMoreImages.lastAssignedId);
         fileUploadarea.appendChild(div);
         AddMoreImages.lastAssignedId++;
     }
    </script>
  </ContentTemplate>
</asp:UpdatePanel>
