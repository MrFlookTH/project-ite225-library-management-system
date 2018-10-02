<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .formAdminLogin label {
            font-size:20px;
            font-weight:bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <h2 id="head">ผู้ดูแลระบบ</h2> 
    <asp:Panel ID="PanelAdminLogin" runat="server" DefaultButton="btnAdminLogin">
        <table class="formContent">
        <tr>
            <td style="text-align: right"><label for="email">Username : </label></td>
            <td><asp:TextBox CssClass="form-control" ID="adminUser" placeholder="Enter Username" runat="server" AutoCompleteType="Disabled"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right"><label for="email">Password : </label></td>
            <td><asp:TextBox CssClass="form-control" ID="adminPass" placeholder="Enter Password" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp</td>
            <td>
                <asp:Button CssClass="btn btn-primary" ID="btnAdminLogin" runat="server" Text="เข้าสู่ระบบ" OnClick="btnAdminLogin_Click" />
            </td>
        </tr>
    </table>
    </asp:Panel>
    

    <asp:Panel ID="PanelAdminMenu" runat="server" Visible="false">
        <div class="admin-menu">
            <ul>
                <li><a href="Search.aspx"><img src="image/menu-borrow.jpg" width="150" height="150" /></a></li>
                <li><a href="Admin_Return.aspx"><img src="image/menu-return.jpg" width="150" height="150" /></a></li>
                <li><a href="Admin_UserProfile.aspx"><img src="image/menu-member.jpg" width="150" height="150" /></a></li>
                <li><a href="Admin_Setting.aspx"><img src="image/menu-setting.jpg" width="150" height="150" /></a></li>
                <li><a href="#" runat="server" onserverclick="btnLogout_Click"><img src="image/menu-logout.jpg" width="150" height="150" /></a></li>
            </ul>
        </div>
    </asp:Panel>
</asp:Content>

