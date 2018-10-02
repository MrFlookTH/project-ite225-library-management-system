<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <h2>หมวดหมู่ : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h2>
        <table class="list">
        <tr>
            <th>ID</th>
            <th>ชื่อหนังสือ</th>
            <th>ผู้แต่ง</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td><a href="book.aspx?BookID=<%#Eval("BookID") %>"><%#Eval("BookID") %></a></td>
                    <td><a href="book.aspx?BookID=<%#Eval("BookID") %>"><%#Eval("Title") %></a></td>
                    <td><%#Eval("Name") %></td>

                 </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <p style="text-align:center">จำนวนทั้งหมด <asp:Label ID="LabelCount" runat="server"></asp:Label> เล่ม</p>

    
</asp:Content>

