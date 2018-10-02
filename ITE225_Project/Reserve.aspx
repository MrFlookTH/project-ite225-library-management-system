<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="Reserve.aspx.cs" Inherits="Reserve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 226px;
            padding:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <h2>ระบบจองหนังสือ</h2>
    <h3 class="table-head">ข้อมูลการยืมหนังสือ</h3>
    <table class="list">
    <asp:Repeater ID="RepeaterBorrowing" runat="server">
        <HeaderTemplate>
            <tr>
                <th>หมายเลขยืม</th>
                <th>ชื่อหนังสือ</th>
                <th>วันที่ยืม</th>
                <th>วันที่ส่งคืน</th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
            <td><%#Eval("BorrowID") %></td>
            <td><%#Eval("Title") %></td>
            <td><%#Eval("BorrowDate","{0:d}") %></td>
            <td><%#Eval("ReturnDate","{0:d}") %></td>
        </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>

