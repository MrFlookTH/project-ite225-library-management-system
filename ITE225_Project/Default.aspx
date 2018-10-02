<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    
    <h2>ข่าวประชาสัมพันธ์</h2>
    <ul style="margin:20px;">
        <asp:Repeater ID="RepeaterNews" runat="server">
            <ItemTemplate>
                <li><a href="news.aspx?id=<%#Eval("NewsID") %>"><%#Eval("Title") %></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <h2>หนังสือมาใหม่</h2>
    <div class="book-list">
            <a href="#" data-toggle="tooltip" data-placement="top" title="Windows 8 ฉบับสมบูรณ์"><img src="image/book/ex10.jpg" width="100" height="130" /></a>
            <a href="#" data-toggle="tooltip" data-placement="top" title="Windows Phone 8"><img src="image/book/ex2.jpg" width="100" height="130"/></a>
            <a href="book.aspx" data-toggle="tooltip" data-placement="top" title="Basic iOS App Development"><img src="image/book/ex5.jpg" width="100" height="130" /></a>
            <a href="#" data-toggle="tooltip" data-placement="top" title="เก่งศัพท์และสนทนาภาษาจีน"><img src="image/book/ex4.jpg" width="100" height="130" /></a>
            <a href="#" data-toggle="tooltip" data-placement="top" title="Mirrorless"><img src="image/book/ex3.jpg" width="100" height="130" /></a>
            
    </div>
    <h2>หนังสือยอดนิยม</h2>
    <div class="book-list">
            <a href="#" data-toggle="tooltip" data-placement="top" title="Android"><img src="image/book/ex7.jpg" width="100" height="130" /></a>
            <a href="#" data-toggle="tooltip" data-placement="top" title="การเขียนโปรแกรมด้วยภาษา C"><img src="image/book/ex8.jpg" width="100" height="130"/></a>
            <a href="#" data-toggle="tooltip" data-placement="top" title="ช่างคอมมืออาชีพ 2014"><img src="image/book/ex9.jpg" width="100" height="130" /></a>
    </div>
</asp:Content>

