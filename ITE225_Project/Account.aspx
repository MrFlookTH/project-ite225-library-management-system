<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <h2>ประวัติการยืมหนังสือ</h2>
    <asp:DropDownList ID="ddlBorrow" runat="server" CssClass="form-control" Height="35px" Width="200px" style="margin-top:20px; margin-left:20px" AutoPostBack="True" OnSelectedIndexChanged="ddlBorrow_SelectedIndexChanged">
        <asp:ListItem Value="Borrowed" Selected="True">รายการที่ยังไม่ส่งคืน</asp:ListItem>
        <asp:ListItem Value="Late">รายการที่ส่งคืนล่าช้า</asp:ListItem>
        <asp:ListItem Value="Returned">รายการที่ส่งคืนแล้ว</asp:ListItem>
        <asp:ListItem Value="All">รายการทั้งหมด</asp:ListItem>
    </asp:DropDownList>
     <table class="list">   
            <asp:Repeater ID="RepeaterBorrow" runat="server">
            <HeaderTemplate>  
                <tr>
                    <th>หมายเลขยืม</th>
                    <th>ชื่อหนังสือ</th>
                    <th>วันที่ยืม</th>
                    <th>ส่งคืน</th>
                    <th>สถานะ</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><a href="book.aspx?BookID=<%#Eval("BookID") %>" target="_blank"><%#Eval("BorrowID") %></a></td>
                        <td><a href="book.aspx?BookID=<%#Eval("BookID") %>" target="_blank"><%#Eval("Title") %></a></td>
                    <td><%#Eval("BorrowDate","{0:d}") %></td>
                    <td><%#Eval("ReturnDate","{0:d}") %></td>
                    <td style="font-weight:bold">
                        <%# ProcessStatus(Eval("ReturnDate"),Eval("Returned"))%>
                    </td>
                </tr>
            </ItemTemplate>   
        </asp:Repeater>
    </table>
    <asp:Panel ID="PanelAlertBorrow" runat="server" Visible="false">
        <p style="text-align:center">- ไม่พบข้อมูล -</p><br />
    </asp:Panel>


    <h2>หนังสือแนะนำ</h2>
    <div class="book-list">
            <asp:Repeater ID="RepeaterBookRecommend" runat="server">
                <ItemTemplate>
                    <a href="book.aspx?BookID=<%#Eval("BookID") %>" data-toggle="tooltip" data-placement="top" title="<%#Eval("Title") %>" target="_blank"><img src="image/book/<%#Eval("BookID") %>.jpg" width="100" height="130" /></a>
                </ItemTemplate>
            </asp:Repeater>    
    </div>
    
</asp:Content>

