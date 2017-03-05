<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="controls_Menu" %>
<div id="ja-mainnav">
    <ul id="ja-cssmenu" class="clearfix">
        <li class="havechild"><a href="type.aspx" class="menu-item"><span>Danh mục 1</span></a>
            <ul>
                <li class="havechild"><a href="type_add.aspx" class="menu-item"><span>Thêm mới</span></a>
                </li>
            </ul>
        </li>
        <li class="havechild"><a href="category.aspx" class="menu-item"><span>Danh mục 2</span></a>
            <ul>
                <li class="havechild"><a href="category_add.aspx" class="menu-item"><span>Thêm mới</span></a>
                </li>
            </ul>
        </li>
        <li class="havechild"><a href="product.aspx" class="menu-item"><span>Sản phẩm</span></a>
            <ul>
                <li class="havechild"><a href="product_add.aspx" class="menu-item"><span>Thêm mới</span></a>
                </li>
            </ul>
        </li>
        <li class="havechild"><a href="new.aspx" class="menu-item"><span>Tin tức</span></a>
            <ul>
                <li class="havechild"><a href="new_add.aspx" class="menu-item"><span>Thêm mới</span></a>
                </li>
            </ul>
        </li>
        <li class="havechild"><a href="content_edit.aspx?id=gioi-thieu" class="menu-item"><span>
            Giới thiệu</span></a> </li>
        <li class="havechild"><a href="ad.aspx" class="menu-item"><span>Quảng cáo</span></a>
            <ul>
                <li class="havechild"><a href="ad_add.aspx" class="menu-item"><span>Thêm mới</span></a>
                </li>
            </ul>
        </li>
        <li class="havechild"><a href="setting.aspx" class="menu-item"><span>Cấu hình</span></a>
        </li>
        <li class="havechild"><a href="changepassword.aspx" class="menu-item"><span>Đổi mật
            khẩu</span></a> </li>
        <li class="havechild"><a href="logout.aspx" class="menu-item"><span>Thoát</span></a>
        </li>
    </ul>
</div>
