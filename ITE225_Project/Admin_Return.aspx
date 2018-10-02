<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Return.aspx.cs" Inherits="Admin_Return" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <h2 id="head">ระบบจัดการข้อมูลสมาชิก</h2>
    <asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
        <table class="formContent">
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regUser">ID ผู้ยืม : </label></td>
            <td><asp:TextBox CssClass="form-control" ID="txtUser" placeholder="กรุณากรอก ID ผู้ยืม" runat="server" AutoCompleteType="Disabled" MaxLength="15"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Button ID="btnSearch" runat="server" Text="ค้นหาข้อมูล" CssClass="btn btn-primary" OnClick="btnSearch_Click" /></td>
        </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="PanelUserProfile" runat="server" Visible="false">
        <table class="formContent" style="padding-bottom:25px;">
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regUser">ชื่อผู้ใช้งาน : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="regUser" placeholder="กรุณากรอกชื่อผู้ใช้" runat="server" AutoCompleteType="Disabled" MaxLength="15" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">
                <label for="IDNumber">เลขบัตรประชาชน : </label></td>
            <td class="auto-style2">
                <asp:TextBox CssClass="form-control" ID="regIDNumber" placeholder="กรุณากรอกหมายเลขบัตรประชาชน" runat="server" AutoCompleteType="Disabled" MaxLength="13" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regFirstName">ชื่อผู้ยืม : </label></td>
            <td class="auto-style2">
                <asp:TextBox CssClass="form-control" ID="regName" placeholder="กรุณากรอกชื่อ" runat="server" AutoCompleteType="Disabled" MaxLength="20" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        </table>
    </asp:Panel>




    <asp:Panel ID="PanelBorrow" runat="server" Visible="false">
    <h2>ข้อมูลการยืมหนังสือ</h2>
        <table class="list">   
        <asp:Repeater ID="RepeaterBorrow" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>&nbsp;</th>
                    <th>หมายเลขยืม</th>
                    <th>ชื่อหนังสือ</th>
                    <th>วันที่ยืม</th>
                    <th>ส่งคืน</th>                  
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkBorrowID" runat="server" />
                        <asp:HiddenField ID="HiddenBorrowID" runat="server" Value='<%#Eval("BorrowID") %>' />
                        <asp:HiddenField ID="HiddenBookID" runat="server" Value='<%#Eval("BookID") %>' />
                    </td>
                    <td><%#Eval("BorrowID") %></td>
                        <td><a href="book.aspx?BookID=<%#Eval("BookID") %>" target="_blank"><%#Eval("Title") %></a></td>
                    <td><%#Eval("BorrowDate","{0:d}") %></td>
                    <td><%#Eval("ReturnDate","{0:d}") %></td>
                </tr>
            </ItemTemplate>   
        </asp:Repeater>
    </table>
    <div class="btn-bottom" style="padding-left:220px">
        <table>
            <tr>
                <td><asp:Button ID="btnReturn" runat="server" Text="คืนหนังสือ" CssClass="btn btn-primary" OnClick="btnReturn_Click" /></td>
                <td><asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="btn" OnClick="btnCancel_Click" /></td>
            </tr>
        </table>  
    </div>
    </asp:Panel>

    


    <asp:Panel ID="PanelAlert" runat="server" Visible="false">
        <p style="text-align:center">- ไม่มีข้อมูลการยืมหนังสือ -</p><br />
        <p style="text-align:center"><a href="#" runat="server" onserverclick="btnCancel_Click">ย้อนกลับ</a></p>
    </asp:Panel>
    
</asp:Content>

