<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 226px;
            padding:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <h2>ค้นหาหนังสือ</h2>
    <asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
        <table style="width: 306px; margin-left:20px; margin-top:20px;">
        <tr>
            <td class="auto-style1">
                <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" Height="35px" Width="200px">
                <asp:ListItem Value="Title">ชื่อหนังสือ (Book Title)</asp:ListItem>
                <asp:ListItem Value="Author">ชื่อผู้แต่ง (Author)</asp:ListItem>
                    <asp:ListItem Value="Publisher">ชื่อสำนักพิมพ์ (Publisher)</asp:ListItem>
                    <asp:ListItem Value="BookID">รหัสหนังสือ</asp:ListItem>
                <asp:ListItem>ISBN</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1">
                <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" Height="35px" Width="200px">
                <asp:ListItem Value="all">ค้นหาหมวดหมู่ทั้งหมด</asp:ListItem>
                <asp:ListItem Value="1">ความรู้ทั่วไป, คอมพิวเตอร์</asp:ListItem>
                <asp:ListItem Value="2">ปรัชญา</asp:ListItem>
                <asp:ListItem Value="3">ศาสนา</asp:ListItem>
                <asp:ListItem Value="4">สังคมศาสตร์</asp:ListItem>
                <asp:ListItem Value="5">ภาษาศาสตร์</asp:ListItem>
                <asp:ListItem Value="6">วิทยาศาสตร์, คณิตศาสตร์</asp:ListItem>
                <asp:ListItem Value="7">การจัดการ, การบัญชี</asp:ListItem>
                <asp:ListItem Value="8">ศิลปะ, ดนตรี</asp:ListItem>
                <asp:ListItem Value="9">วรรณคดี</asp:ListItem>
                <asp:ListItem Value="10">ประวัติศาสตร์</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                <asp:TextBox CssClass="form-control" ID="TextBoxSearch" runat="server" placeholder="กรุณากรอกคำค้นหา"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button CssClass="btn btn-primary" ID="btnSearch" runat="server" Text="ค้นหา" Width="90px" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    </asp:Panel>
    

    <asp:Panel ID="PanelResult" runat="server" Visible="false">
        <table class="list">
        <tr>
            <th>ISBN</th>
            <th>ชื่อหนังสือ</th>
            <th>ผู้แต่ง</th>
            <th>สำนักพิมพ์</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td><a href="book.aspx?BookID=<%#Eval("BookID") %>"><%#Eval("ISBN") %></a></td>
                    <td><a href="book.aspx?BookID=<%#Eval("BookID") %>"><%#Eval("Title") %></a></td>
                    <td><%#Eval("AName") %></td>
                    <td><%#Eval("PName") %></td>
                </tr>
            </ItemTemplate>      
        </asp:Repeater>    
    </table>
    <!--
    <div class="page">
        <ul>
            <li>1 | </li>
            <li><a href="#">2</a>|</li>
            <li><a href="#">3</a>|</li>
            <li><a href="#">4</a></li>
        </ul>
    </div>
    -->
    </asp:Panel>

</asp:Content>

