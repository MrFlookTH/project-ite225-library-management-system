<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_UserProfile.aspx.cs" Inherits="Admin_UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <h2>ระบบจัดการข้อมูลสมาชิก</h2>
    <asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
        <table class="formContent">
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regUser">ID สมาชิก : </label></td>
            <td><asp:TextBox CssClass="form-control" ID="txtUser" placeholder="กรุณากรอก ID ผู้ยืม" runat="server" AutoCompleteType="Disabled" MaxLength="15"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Button ID="btnSearch" runat="server" Text="ค้นหาข้อมูล" CssClass="btn btn-primary" OnClick="btnSearch_Click" /></td>
        </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelUserProfile" runat="server" Visible="false">
        <table class="formContent">
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regUser">ชื่อผู้ใช้งาน : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="regUser" placeholder="กรุณากรอกชื่อผู้ใช้" runat="server" AutoCompleteType="Disabled" MaxLength="15" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">
                <label for="IDNumber">เลขบัตรประชาชน : </label></td>
            <td class="auto-style2">
                <asp:TextBox CssClass="form-control" ID="regIDNumber" placeholder="กรุณากรอกหมายเลขบัตรประชาชน" runat="server" AutoCompleteType="Disabled" MaxLength="13"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regFirstName">ชื่อจริง : </label></td>
            <td class="auto-style2">
                <asp:TextBox CssClass="form-control" ID="regFirstname" placeholder="กรุณากรอกชื่อจริง" runat="server" AutoCompleteType="Disabled" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regLastName">นามสกุล : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="regLastname" placeholder="กรุณากรอกนามสกุล" runat="server" AutoCompleteType="Disabled" MaxLength="20"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regLastName">ที่อยู่ : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="regAddress" placeholder="กรุณากรอกที่อยู่" runat="server" Rows="4" TextMode="MultiLine" style="resize:none"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regTel">เบอร์โทรศัพท์ : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="regTel" placeholder="กรุณากรอกเบอร์โทรศัพท์" runat="server" TextMode="Phone" AutoCompleteType="Disabled" MaxLength="10"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regEmail">E-mail : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="regEmail" placeholder="กรุณากรอก E-mail" runat="server" TextMode="Email" AutoCompleteType="Disabled" MaxLength="30"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">
                <asp:Button CssClass="btn btn-primary" ID="btnEditProfile" runat="server" Text="บันทึกข้อมูล" OnClick="btnEditProfile_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="btn" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

