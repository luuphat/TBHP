﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucCategory.ascx.cs" Inherits="admin_control_wucCategory" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

  <div class="maincontent noright">
<div class="maincontentinner">
    <ul class="maintabmenu">
        <li class="current"><a href="dashboard.html">Danh sách danh mục</a></li>
    </ul>
    <!--maintabmenu-->
    <asp:UpdatePanel ID="upList" runat="server">
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
                    <td style="width:15%;float:left;">
                        <span >
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="text1" Width="90%"></asp:TextBox>
                        </span>
                    </td>
                     <td style="width:15%;float:left;">
                        <span >
                            <asp:DropDownList ID="ddlHandleCategoryID" runat="server"  class="dualselect"></asp:DropDownList>
                        </span>
                    </td>
                     <td style="width:7%;float:left;margin-left:60px;">
                         <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" CssClass="btn" />                      
                    </td>
                     <td style="width:10%;float:left;margin-left:10px;">
                         <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" OnClick="btnAdd_Click" CssClass="btn" />                      
                    </td>
                    <td style="float:left;padding-left:30px; padding-bottom:10px; font-size:12px;">
                        Tổng cộng: <asp:Label ID="lblcount" runat="server" ForeColor="Red" ></asp:Label>
                    </td>
                    <td style="float:right;padding-right:0px; padding-bottom:10px;">
                         &nbsp;
                    <asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                    </asp:DropDownList>
                &nbsp;
                    </td >
                   <td style="width:10%;margin-right:5px;float:right; padding-bottom:10px;">  
                       <webdiyer:AspNetPager ID="anpPager"   runat="server" PagingButtonSpacing="5px"  onpagechanged="anpPager_PageChanged"
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
                <col class="con0" />
                <col class="con1" />
                <col class="con0" />
                <col class="con1" />
            </colgroup>
            <thead>
                <tr>
                    <th class="head0">
                         <input type="checkbox"  id="checkboxAll" onclick="javascript: selectAll(this)"  /></th>
                    <th class="head1">ID</th>
                    <th class="head1">Ảnh đại diện</th>
                    <th class="head1">Tên thể loại</th>
                    <th class="head0">Chủ đề cha</th>
                    <th class="head1">Kích hoạt</th>
                    <th class="head0">Ngày đăng </th>    
                    <th class="head1">#</th>                
                </tr>
            </thead>
       
            <tbody>
                <asp:Repeater ID="rptData" runat="server" runat="server" OnItemDataBound="rptData_ItemDataBound" OnItemCommand="rptData_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td class="center">
                                  <input type="checkbox" id="cbxcheck" runat="server" class="selectInstance" /></td>
                              <td><img height="100" width="120" src='<% = Global.Root %><%#Eval("Images") %> '/>  </td>
                            <td><a href="../admin/categoryedit.aspx?cid=<%# Eval("CategoryID") %>"> <%#Eval("CategoryID") %> </a></td>
                            <td><a href="../admin/categoryedit.aspx?cid=<%# Eval("CategoryID") %>"><%#Eval("CategoryName") %> </a></td>
                            <td><%#Eval("ParentCategoryName") %> </td>
                            <td class="center"><asp:ImageButton ID="ibtIsActived" runat="server" CommandName="DoSetActive" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CategoryID") %>'/></td>
                            <td class="center"><%#Convert.ToDateTime(Eval("InputTime")).ToString("dd/MM/yyyy") %></td>
                            <td> <asp:ImageButton ID="btnDelete" CausesValidation="false" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CategoryID") %>' CommandName="Delete" OnClientClick="return confirm('Bạn có chắc muốn xóa?');"
                            runat="server" ToolTip="Xóa"></asp:ImageButton></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
              
             
            </tbody>
        </table>

        <br clear="all" />

    </div>
    <!--content-->
      </ContentTemplate>
    </asp:UpdatePanel>
</div>
      </div>
<!--maincontentinner-->
<script type="text/javascript">
    function selectAll(target) {
        var items = $('.selectInstance');
        for (i = 0; i < items.length; i++) {
            items[i].checked = target.checked;
        }
    }
    function iniUpdate() {
        var hasObject = false;
        var items = $('.selectInstance');
        for (i = 0; i < items.length; i++) {
            if (items[i].checked) {
                hasObject = true;
                break;
            }
        }
        if (!hasObject) { alert("Chưa chọn đối tượng cần cập nhật !"); }
        return hasObject;
    }

    function iniDelete() {
        var items = $('.selectInstance');
        //   var dvdelete = $('#dvdeleted');
        for (i = 0; i < items.length; i++) {
            if (items[i].checked) {

                $("#dvfade").addClass('fade');
                $("#dvdeleted").removeClass('None');
                $('#dvdeleted').show();
                return;
            }
        }
        alert("Chưa chọn đối tượng nào để xóa !");

    }

    function UniniDelete() {
        $("#dvfade").removeClass('fade');
        $("#dvdeleted").addClass('None');
        $('#dvdeleted').hide();
    }

</script>